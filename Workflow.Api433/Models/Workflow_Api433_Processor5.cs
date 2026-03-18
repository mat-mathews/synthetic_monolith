using Admin.Handlers61;
using Admin.Mappers;
using Admin.Web46;
using BatchJobs.Client;
using Billing.Core191;
using Billing.Models;
using Common.Processors142;
using Common.Web488;
using DataAccess.Api454;
using Export.Core372;
using Imaging.Contracts473;
using Imaging.Models459;
using Integration.Service147;
using Scheduling.Core;
using Security.Core;
using Security.Handlers162;
using Security.Service383;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;

namespace Workflow.Api433
{
    internal abstract class Workflow_Api433_Processor5
    {
        private readonly string _sql = "SELECT * FROM Customers WHERE Id = @Id";
        public void Execute()
        {
            // Workflow_Api433_Processor5 implementation
        }

/// <summary>
/// Validates the Processor5 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateProcessor5(Processor5Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Processor5));
        return false;
    }

    /* Multi-line validation logic:
     * 1. Check field lengths
     * 2. Validate business rules
     * 3. Cross-reference with existing data */
    if (input.Name.Length > 255)
    {
        _logger.LogWarning("Validation failed: Name exceeds maximum length");
        return false;
    }

    // Additional business rule checks
    var existingItems = _repository.FindByName(input.Name);
    if (existingItems.Any(x => x.Id != input.Id))
    {
        _logger.LogWarning("Duplicate name detected: {Name}", input.Name);
        return false;
    }

    return true;
}

/// <summary>
/// Processes the Processor5 operation asynchronously.
/// </summary>
public async Task<Processor5Result> ProcessProcessor5Async(
    Processor5Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Processor5), request.Id);

    // Validate input parameters
    if (request == null)
        throw new ArgumentNullException(nameof(request));

    try
    {
        /* Begin transaction scope for data consistency.
         * This ensures all database operations either
         * complete successfully or roll back together. */
        using var scope = new TransactionScope(
            TransactionScopeAsyncFlowOption.Enabled);

        var entity = await _repository
            .GetByIdAsync(request.Id, cancellationToken)
            .ConfigureAwait(false);

        if (entity == null)
        {
            _logger.LogWarning("Entity not found: {Id}", request.Id);
            return new Processor5Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Processor5));
        return new Processor5Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Processor5));
        return new Processor5Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Processor5 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Processor5Dto>> GetProcessor5ListAsync(
    Processor5Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Processor5Entity>().AsQueryable();

    // Apply filters conditionally
    if (!string.IsNullOrEmpty(filter.SearchTerm))
    {
        var term = filter.SearchTerm.ToLowerInvariant();
        query = query.Where(x =>
            x.Name.ToLower().Contains(term) ||
            x.Description.ToLower().Contains(term));
    }

    if (filter.Status.HasValue)
        query = query.Where(x => x.Status == filter.Status.Value);

    if (filter.CreatedAfter.HasValue)
        query = query.Where(x => x.CreatedAt >= filter.CreatedAfter.Value);

    // Get total count for pagination
    var totalCount = await query.CountAsync();

    // Apply sorting and pagination
    var items = await query
        .OrderByDescending(x => x.CreatedAt)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .Select(x => new Processor5Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Processor5Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Processor5Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Processor5Service(
    ILogger<Processor5Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Processor5:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Processor5 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Processor5Data> GetCachedProcessor5Async(string key)
{
    var cacheKey = $"Processor5_{key}";

    if (_cache.TryGetValue(cacheKey, out Processor5Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromProcessor5SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Param46Id { get; set; }
public string Param46Name { get; set; }
public string Param46Description { get; set; }
public DateTime Param46CreatedAt { get; set; }
public DateTime? Param46UpdatedAt { get; set; }
public string Param46CreatedBy { get; set; }
public bool IsParam46Active { get; set; }
public int Param46SortOrder { get; set; }


public int Attr69Id { get; set; }
public string Attr69Name { get; set; }
public string Attr69Description { get; set; }
public DateTime Attr69CreatedAt { get; set; }
public DateTime? Attr69UpdatedAt { get; set; }
public string Attr69CreatedBy { get; set; }
public bool IsAttr69Active { get; set; }
public int Attr69SortOrder { get; set; }


public int Entry73Id { get; set; }
public string Entry73Name { get; set; }
public string Entry73Description { get; set; }
public DateTime Entry73CreatedAt { get; set; }
public DateTime? Entry73UpdatedAt { get; set; }
public string Entry73CreatedBy { get; set; }
public bool IsEntry73Active { get; set; }
public int Entry73SortOrder { get; set; }


public int Detail70Id { get; set; }
public string Detail70Name { get; set; }
public string Detail70Description { get; set; }
public DateTime Detail70CreatedAt { get; set; }
public DateTime? Detail70UpdatedAt { get; set; }
public string Detail70CreatedBy { get; set; }
public bool IsDetail70Active { get; set; }
public int Detail70SortOrder { get; set; }


public int Record67Id { get; set; }
public string Record67Name { get; set; }
public string Record67Description { get; set; }
public DateTime Record67CreatedAt { get; set; }
public DateTime? Record67UpdatedAt { get; set; }
public string Record67CreatedBy { get; set; }
public bool IsRecord67Active { get; set; }
public int Record67SortOrder { get; set; }


public int Detail84Id { get; set; }
public string Detail84Name { get; set; }
public string Detail84Description { get; set; }
public DateTime Detail84CreatedAt { get; set; }
public DateTime? Detail84UpdatedAt { get; set; }
public string Detail84CreatedBy { get; set; }
public bool IsDetail84Active { get; set; }
public int Detail84SortOrder { get; set; }


public int Field38Id { get; set; }
public string Field38Name { get; set; }
public string Field38Description { get; set; }
public DateTime Field38CreatedAt { get; set; }
public DateTime? Field38UpdatedAt { get; set; }
public string Field38CreatedBy { get; set; }
public bool IsField38Active { get; set; }
public int Field38SortOrder { get; set; }


public int Entry44Id { get; set; }
public string Entry44Name { get; set; }
public string Entry44Description { get; set; }
public DateTime Entry44CreatedAt { get; set; }
public DateTime? Entry44UpdatedAt { get; set; }
public string Entry44CreatedBy { get; set; }
public bool IsEntry44Active { get; set; }
public int Entry44SortOrder { get; set; }


public int Attr70Id { get; set; }
public string Attr70Name { get; set; }
public string Attr70Description { get; set; }
public DateTime Attr70CreatedAt { get; set; }
public DateTime? Attr70UpdatedAt { get; set; }
public string Attr70CreatedBy { get; set; }
public bool IsAttr70Active { get; set; }
public int Attr70SortOrder { get; set; }


public int Field9Id { get; set; }
public string Field9Name { get; set; }
public string Field9Description { get; set; }
public DateTime Field9CreatedAt { get; set; }
public DateTime? Field9UpdatedAt { get; set; }
public string Field9CreatedBy { get; set; }
public bool IsField9Active { get; set; }
public int Field9SortOrder { get; set; }


public int Detail81Id { get; set; }
public string Detail81Name { get; set; }
public string Detail81Description { get; set; }
public DateTime Detail81CreatedAt { get; set; }
public DateTime? Detail81UpdatedAt { get; set; }
public string Detail81CreatedBy { get; set; }
public bool IsDetail81Active { get; set; }
public int Detail81SortOrder { get; set; }


public int Config53Id { get; set; }
public string Config53Name { get; set; }
public string Config53Description { get; set; }
public DateTime Config53CreatedAt { get; set; }
public DateTime? Config53UpdatedAt { get; set; }
public string Config53CreatedBy { get; set; }
public bool IsConfig53Active { get; set; }
public int Config53SortOrder { get; set; }


public int Item56Id { get; set; }
public string Item56Name { get; set; }
public string Item56Description { get; set; }
public DateTime Item56CreatedAt { get; set; }
public DateTime? Item56UpdatedAt { get; set; }
public string Item56CreatedBy { get; set; }
public bool IsItem56Active { get; set; }
public int Item56SortOrder { get; set; }


public int Config83Id { get; set; }
public string Config83Name { get; set; }
public string Config83Description { get; set; }
public DateTime Config83CreatedAt { get; set; }
public DateTime? Config83UpdatedAt { get; set; }
public string Config83CreatedBy { get; set; }
public bool IsConfig83Active { get; set; }
public int Config83SortOrder { get; set; }


public int Field69Id { get; set; }
public string Field69Name { get; set; }
public string Field69Description { get; set; }
public DateTime Field69CreatedAt { get; set; }
public DateTime? Field69UpdatedAt { get; set; }
public string Field69CreatedBy { get; set; }
public bool IsField69Active { get; set; }
public int Field69SortOrder { get; set; }


public int Item99Id { get; set; }
public string Item99Name { get; set; }
public string Item99Description { get; set; }
public DateTime Item99CreatedAt { get; set; }
public DateTime? Item99UpdatedAt { get; set; }
public string Item99CreatedBy { get; set; }
public bool IsItem99Active { get; set; }
public int Item99SortOrder { get; set; }


public int Detail62Id { get; set; }
public string Detail62Name { get; set; }
public string Detail62Description { get; set; }
public DateTime Detail62CreatedAt { get; set; }
public DateTime? Detail62UpdatedAt { get; set; }
public string Detail62CreatedBy { get; set; }
public bool IsDetail62Active { get; set; }
public int Detail62SortOrder { get; set; }


public int Attr74Id { get; set; }
public string Attr74Name { get; set; }
public string Attr74Description { get; set; }
public DateTime Attr74CreatedAt { get; set; }
public DateTime? Attr74UpdatedAt { get; set; }
public string Attr74CreatedBy { get; set; }
public bool IsAttr74Active { get; set; }
public int Attr74SortOrder { get; set; }


public int Entry93Id { get; set; }
public string Entry93Name { get; set; }
public string Entry93Description { get; set; }
public DateTime Entry93CreatedAt { get; set; }
public DateTime? Entry93UpdatedAt { get; set; }
public string Entry93CreatedBy { get; set; }
public bool IsEntry93Active { get; set; }
public int Entry93SortOrder { get; set; }


public int Field67Id { get; set; }
public string Field67Name { get; set; }
public string Field67Description { get; set; }
public DateTime Field67CreatedAt { get; set; }
public DateTime? Field67UpdatedAt { get; set; }
public string Field67CreatedBy { get; set; }
public bool IsField67Active { get; set; }
public int Field67SortOrder { get; set; }


public int Attr69Id { get; set; }
public string Attr69Name { get; set; }
public string Attr69Description { get; set; }
public DateTime Attr69CreatedAt { get; set; }
public DateTime? Attr69UpdatedAt { get; set; }
public string Attr69CreatedBy { get; set; }
public bool IsAttr69Active { get; set; }
public int Attr69SortOrder { get; set; }


public int Detail40Id { get; set; }
public string Detail40Name { get; set; }
public string Detail40Description { get; set; }
public DateTime Detail40CreatedAt { get; set; }
public DateTime? Detail40UpdatedAt { get; set; }
public string Detail40CreatedBy { get; set; }
public bool IsDetail40Active { get; set; }
public int Detail40SortOrder { get; set; }


public int Config71Id { get; set; }
public string Config71Name { get; set; }
public string Config71Description { get; set; }
public DateTime Config71CreatedAt { get; set; }
public DateTime? Config71UpdatedAt { get; set; }
public string Config71CreatedBy { get; set; }
public bool IsConfig71Active { get; set; }
public int Config71SortOrder { get; set; }


public int Attr34Id { get; set; }
public string Attr34Name { get; set; }
public string Attr34Description { get; set; }
public DateTime Attr34CreatedAt { get; set; }
public DateTime? Attr34UpdatedAt { get; set; }
public string Attr34CreatedBy { get; set; }
public bool IsAttr34Active { get; set; }
public int Attr34SortOrder { get; set; }


public int Item26Id { get; set; }
public string Item26Name { get; set; }
public string Item26Description { get; set; }
public DateTime Item26CreatedAt { get; set; }
public DateTime? Item26UpdatedAt { get; set; }
public string Item26CreatedBy { get; set; }
public bool IsItem26Active { get; set; }
public int Item26SortOrder { get; set; }


public int Entry94Id { get; set; }
public string Entry94Name { get; set; }
public string Entry94Description { get; set; }
public DateTime Entry94CreatedAt { get; set; }
public DateTime? Entry94UpdatedAt { get; set; }
public string Entry94CreatedBy { get; set; }
public bool IsEntry94Active { get; set; }
public int Entry94SortOrder { get; set; }


public int Config70Id { get; set; }
public string Config70Name { get; set; }
public string Config70Description { get; set; }
public DateTime Config70CreatedAt { get; set; }
public DateTime? Config70UpdatedAt { get; set; }
public string Config70CreatedBy { get; set; }
public bool IsConfig70Active { get; set; }
public int Config70SortOrder { get; set; }


public int Param74Id { get; set; }
public string Param74Name { get; set; }
public string Param74Description { get; set; }
public DateTime Param74CreatedAt { get; set; }
public DateTime? Param74UpdatedAt { get; set; }
public string Param74CreatedBy { get; set; }
public bool IsParam74Active { get; set; }
public int Param74SortOrder { get; set; }


public int Detail29Id { get; set; }
public string Detail29Name { get; set; }
public string Detail29Description { get; set; }
public DateTime Detail29CreatedAt { get; set; }
public DateTime? Detail29UpdatedAt { get; set; }
public string Detail29CreatedBy { get; set; }
public bool IsDetail29Active { get; set; }
public int Detail29SortOrder { get; set; }


public int Detail37Id { get; set; }
public string Detail37Name { get; set; }
public string Detail37Description { get; set; }
public DateTime Detail37CreatedAt { get; set; }
public DateTime? Detail37UpdatedAt { get; set; }
public string Detail37CreatedBy { get; set; }
public bool IsDetail37Active { get; set; }
public int Detail37SortOrder { get; set; }


public int Record48Id { get; set; }
public string Record48Name { get; set; }
public string Record48Description { get; set; }
public DateTime Record48CreatedAt { get; set; }
public DateTime? Record48UpdatedAt { get; set; }
public string Record48CreatedBy { get; set; }
public bool IsRecord48Active { get; set; }
public int Record48SortOrder { get; set; }


public int Field59Id { get; set; }
public string Field59Name { get; set; }
public string Field59Description { get; set; }
public DateTime Field59CreatedAt { get; set; }
public DateTime? Field59UpdatedAt { get; set; }
public string Field59CreatedBy { get; set; }
public bool IsField59Active { get; set; }
public int Field59SortOrder { get; set; }


public int Field58Id { get; set; }
public string Field58Name { get; set; }
public string Field58Description { get; set; }
public DateTime Field58CreatedAt { get; set; }
public DateTime? Field58UpdatedAt { get; set; }
public string Field58CreatedBy { get; set; }
public bool IsField58Active { get; set; }
public int Field58SortOrder { get; set; }


public int Detail85Id { get; set; }
public string Detail85Name { get; set; }
public string Detail85Description { get; set; }
public DateTime Detail85CreatedAt { get; set; }
public DateTime? Detail85UpdatedAt { get; set; }
public string Detail85CreatedBy { get; set; }
public bool IsDetail85Active { get; set; }
public int Detail85SortOrder { get; set; }


public int Config57Id { get; set; }
public string Config57Name { get; set; }
public string Config57Description { get; set; }
public DateTime Config57CreatedAt { get; set; }
public DateTime? Config57UpdatedAt { get; set; }
public string Config57CreatedBy { get; set; }
public bool IsConfig57Active { get; set; }
public int Config57SortOrder { get; set; }


public int Entry71Id { get; set; }
public string Entry71Name { get; set; }
public string Entry71Description { get; set; }
public DateTime Entry71CreatedAt { get; set; }
public DateTime? Entry71UpdatedAt { get; set; }
public string Entry71CreatedBy { get; set; }
public bool IsEntry71Active { get; set; }
public int Entry71SortOrder { get; set; }


public int Item84Id { get; set; }
public string Item84Name { get; set; }
public string Item84Description { get; set; }
public DateTime Item84CreatedAt { get; set; }
public DateTime? Item84UpdatedAt { get; set; }
public string Item84CreatedBy { get; set; }
public bool IsItem84Active { get; set; }
public int Item84SortOrder { get; set; }


public int Param52Id { get; set; }
public string Param52Name { get; set; }
public string Param52Description { get; set; }
public DateTime Param52CreatedAt { get; set; }
public DateTime? Param52UpdatedAt { get; set; }
public string Param52CreatedBy { get; set; }
public bool IsParam52Active { get; set; }
public int Param52SortOrder { get; set; }


public int Config23Id { get; set; }
public string Config23Name { get; set; }
public string Config23Description { get; set; }
public DateTime Config23CreatedAt { get; set; }
public DateTime? Config23UpdatedAt { get; set; }
public string Config23CreatedBy { get; set; }
public bool IsConfig23Active { get; set; }
public int Config23SortOrder { get; set; }


public int Param31Id { get; set; }
public string Param31Name { get; set; }
public string Param31Description { get; set; }
public DateTime Param31CreatedAt { get; set; }
public DateTime? Param31UpdatedAt { get; set; }
public string Param31CreatedBy { get; set; }
public bool IsParam31Active { get; set; }
public int Param31SortOrder { get; set; }


public int Record87Id { get; set; }
public string Record87Name { get; set; }
public string Record87Description { get; set; }
public DateTime Record87CreatedAt { get; set; }
public DateTime? Record87UpdatedAt { get; set; }
public string Record87CreatedBy { get; set; }
public bool IsRecord87Active { get; set; }
public int Record87SortOrder { get; set; }


public int Item59Id { get; set; }
public string Item59Name { get; set; }
public string Item59Description { get; set; }
public DateTime Item59CreatedAt { get; set; }
public DateTime? Item59UpdatedAt { get; set; }
public string Item59CreatedBy { get; set; }
public bool IsItem59Active { get; set; }
public int Item59SortOrder { get; set; }


public int Param57Id { get; set; }
public string Param57Name { get; set; }
public string Param57Description { get; set; }
public DateTime Param57CreatedAt { get; set; }
public DateTime? Param57UpdatedAt { get; set; }
public string Param57CreatedBy { get; set; }
public bool IsParam57Active { get; set; }
public int Param57SortOrder { get; set; }


public int Field33Id { get; set; }
public string Field33Name { get; set; }
public string Field33Description { get; set; }
public DateTime Field33CreatedAt { get; set; }
public DateTime? Field33UpdatedAt { get; set; }
public string Field33CreatedBy { get; set; }
public bool IsField33Active { get; set; }
public int Field33SortOrder { get; set; }


public int Field59Id { get; set; }
public string Field59Name { get; set; }
public string Field59Description { get; set; }
public DateTime Field59CreatedAt { get; set; }
public DateTime? Field59UpdatedAt { get; set; }
public string Field59CreatedBy { get; set; }
public bool IsField59Active { get; set; }
public int Field59SortOrder { get; set; }


public int Entry51Id { get; set; }
public string Entry51Name { get; set; }
public string Entry51Description { get; set; }
public DateTime Entry51CreatedAt { get; set; }
public DateTime? Entry51UpdatedAt { get; set; }
public string Entry51CreatedBy { get; set; }
public bool IsEntry51Active { get; set; }
public int Entry51SortOrder { get; set; }


public int Item35Id { get; set; }
public string Item35Name { get; set; }
public string Item35Description { get; set; }
public DateTime Item35CreatedAt { get; set; }
public DateTime? Item35UpdatedAt { get; set; }
public string Item35CreatedBy { get; set; }
public bool IsItem35Active { get; set; }
public int Item35SortOrder { get; set; }


public int Field30Id { get; set; }
public string Field30Name { get; set; }
public string Field30Description { get; set; }
public DateTime Field30CreatedAt { get; set; }
public DateTime? Field30UpdatedAt { get; set; }
public string Field30CreatedBy { get; set; }
public bool IsField30Active { get; set; }
public int Field30SortOrder { get; set; }


public int Config88Id { get; set; }
public string Config88Name { get; set; }
public string Config88Description { get; set; }
public DateTime Config88CreatedAt { get; set; }
public DateTime? Config88UpdatedAt { get; set; }
public string Config88CreatedBy { get; set; }
public bool IsConfig88Active { get; set; }
public int Config88SortOrder { get; set; }


public int Item73Id { get; set; }
public string Item73Name { get; set; }
public string Item73Description { get; set; }
public DateTime Item73CreatedAt { get; set; }
public DateTime? Item73UpdatedAt { get; set; }
public string Item73CreatedBy { get; set; }
public bool IsItem73Active { get; set; }
public int Item73SortOrder { get; set; }


public int Record47Id { get; set; }
public string Record47Name { get; set; }
public string Record47Description { get; set; }
public DateTime Record47CreatedAt { get; set; }
public DateTime? Record47UpdatedAt { get; set; }
public string Record47CreatedBy { get; set; }
public bool IsRecord47Active { get; set; }
public int Record47SortOrder { get; set; }


public int Attr92Id { get; set; }
public string Attr92Name { get; set; }
public string Attr92Description { get; set; }
public DateTime Attr92CreatedAt { get; set; }
public DateTime? Attr92UpdatedAt { get; set; }
public string Attr92CreatedBy { get; set; }
public bool IsAttr92Active { get; set; }
public int Attr92SortOrder { get; set; }


public int Record26Id { get; set; }
public string Record26Name { get; set; }
public string Record26Description { get; set; }
public DateTime Record26CreatedAt { get; set; }
public DateTime? Record26UpdatedAt { get; set; }
public string Record26CreatedBy { get; set; }
public bool IsRecord26Active { get; set; }
public int Record26SortOrder { get; set; }


public int Detail65Id { get; set; }
public string Detail65Name { get; set; }
public string Detail65Description { get; set; }
public DateTime Detail65CreatedAt { get; set; }
public DateTime? Detail65UpdatedAt { get; set; }
public string Detail65CreatedBy { get; set; }
public bool IsDetail65Active { get; set; }
public int Detail65SortOrder { get; set; }

    }

}