using Admin.Events306;
using Admin.Handlers447;
using Auth.Mappers178;
using Auth.Tests498;
using Billing.Mappers;
using Common.Processors142;
using Export.Core;
using Import.Events;
using Import.Models457;
using Logging.Contracts;
using Notifications.Data406;
using Portal.Tests323;
using Reporting.Web;
using Scheduling.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Service358;
using Workflow.Tests27;
using Workflow.Web;

namespace Logging.Validators359
{
    internal sealed class Logging_Validators359_Manager4
    {
        public void Execute()
        {
            // Logging_Validators359_Manager4 implementation
        }

/// <summary>
/// Validates the Manager4 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateManager4(Manager4Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Manager4));
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
/// Processes the Manager4 operation asynchronously.
/// </summary>
public async Task<Manager4Result> ProcessManager4Async(
    Manager4Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Manager4), request.Id);

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
            return new Manager4Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Manager4));
        return new Manager4Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Manager4));
        return new Manager4Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Manager4 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Manager4Dto>> GetManager4ListAsync(
    Manager4Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Manager4Entity>().AsQueryable();

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
        .Select(x => new Manager4Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Manager4Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Manager4Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Manager4Service(
    ILogger<Manager4Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Manager4:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Manager4 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Manager4Data> GetCachedManager4Async(string key)
{
    var cacheKey = $"Manager4_{key}";

    if (_cache.TryGetValue(cacheKey, out Manager4Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromManager4SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Entry81Id { get; set; }
public string Entry81Name { get; set; }
public string Entry81Description { get; set; }
public DateTime Entry81CreatedAt { get; set; }
public DateTime? Entry81UpdatedAt { get; set; }
public string Entry81CreatedBy { get; set; }
public bool IsEntry81Active { get; set; }
public int Entry81SortOrder { get; set; }


public int Field68Id { get; set; }
public string Field68Name { get; set; }
public string Field68Description { get; set; }
public DateTime Field68CreatedAt { get; set; }
public DateTime? Field68UpdatedAt { get; set; }
public string Field68CreatedBy { get; set; }
public bool IsField68Active { get; set; }
public int Field68SortOrder { get; set; }


public int Config77Id { get; set; }
public string Config77Name { get; set; }
public string Config77Description { get; set; }
public DateTime Config77CreatedAt { get; set; }
public DateTime? Config77UpdatedAt { get; set; }
public string Config77CreatedBy { get; set; }
public bool IsConfig77Active { get; set; }
public int Config77SortOrder { get; set; }


public int Record49Id { get; set; }
public string Record49Name { get; set; }
public string Record49Description { get; set; }
public DateTime Record49CreatedAt { get; set; }
public DateTime? Record49UpdatedAt { get; set; }
public string Record49CreatedBy { get; set; }
public bool IsRecord49Active { get; set; }
public int Record49SortOrder { get; set; }


public int Item44Id { get; set; }
public string Item44Name { get; set; }
public string Item44Description { get; set; }
public DateTime Item44CreatedAt { get; set; }
public DateTime? Item44UpdatedAt { get; set; }
public string Item44CreatedBy { get; set; }
public bool IsItem44Active { get; set; }
public int Item44SortOrder { get; set; }


public int Detail27Id { get; set; }
public string Detail27Name { get; set; }
public string Detail27Description { get; set; }
public DateTime Detail27CreatedAt { get; set; }
public DateTime? Detail27UpdatedAt { get; set; }
public string Detail27CreatedBy { get; set; }
public bool IsDetail27Active { get; set; }
public int Detail27SortOrder { get; set; }


public int Record59Id { get; set; }
public string Record59Name { get; set; }
public string Record59Description { get; set; }
public DateTime Record59CreatedAt { get; set; }
public DateTime? Record59UpdatedAt { get; set; }
public string Record59CreatedBy { get; set; }
public bool IsRecord59Active { get; set; }
public int Record59SortOrder { get; set; }


public int Item69Id { get; set; }
public string Item69Name { get; set; }
public string Item69Description { get; set; }
public DateTime Item69CreatedAt { get; set; }
public DateTime? Item69UpdatedAt { get; set; }
public string Item69CreatedBy { get; set; }
public bool IsItem69Active { get; set; }
public int Item69SortOrder { get; set; }


public int Item87Id { get; set; }
public string Item87Name { get; set; }
public string Item87Description { get; set; }
public DateTime Item87CreatedAt { get; set; }
public DateTime? Item87UpdatedAt { get; set; }
public string Item87CreatedBy { get; set; }
public bool IsItem87Active { get; set; }
public int Item87SortOrder { get; set; }


public int Detail76Id { get; set; }
public string Detail76Name { get; set; }
public string Detail76Description { get; set; }
public DateTime Detail76CreatedAt { get; set; }
public DateTime? Detail76UpdatedAt { get; set; }
public string Detail76CreatedBy { get; set; }
public bool IsDetail76Active { get; set; }
public int Detail76SortOrder { get; set; }


public int Param55Id { get; set; }
public string Param55Name { get; set; }
public string Param55Description { get; set; }
public DateTime Param55CreatedAt { get; set; }
public DateTime? Param55UpdatedAt { get; set; }
public string Param55CreatedBy { get; set; }
public bool IsParam55Active { get; set; }
public int Param55SortOrder { get; set; }


public int Field53Id { get; set; }
public string Field53Name { get; set; }
public string Field53Description { get; set; }
public DateTime Field53CreatedAt { get; set; }
public DateTime? Field53UpdatedAt { get; set; }
public string Field53CreatedBy { get; set; }
public bool IsField53Active { get; set; }
public int Field53SortOrder { get; set; }


public int Detail8Id { get; set; }
public string Detail8Name { get; set; }
public string Detail8Description { get; set; }
public DateTime Detail8CreatedAt { get; set; }
public DateTime? Detail8UpdatedAt { get; set; }
public string Detail8CreatedBy { get; set; }
public bool IsDetail8Active { get; set; }
public int Detail8SortOrder { get; set; }


public int Attr50Id { get; set; }
public string Attr50Name { get; set; }
public string Attr50Description { get; set; }
public DateTime Attr50CreatedAt { get; set; }
public DateTime? Attr50UpdatedAt { get; set; }
public string Attr50CreatedBy { get; set; }
public bool IsAttr50Active { get; set; }
public int Attr50SortOrder { get; set; }


public int Item59Id { get; set; }
public string Item59Name { get; set; }
public string Item59Description { get; set; }
public DateTime Item59CreatedAt { get; set; }
public DateTime? Item59UpdatedAt { get; set; }
public string Item59CreatedBy { get; set; }
public bool IsItem59Active { get; set; }
public int Item59SortOrder { get; set; }


public int Attr74Id { get; set; }
public string Attr74Name { get; set; }
public string Attr74Description { get; set; }
public DateTime Attr74CreatedAt { get; set; }
public DateTime? Attr74UpdatedAt { get; set; }
public string Attr74CreatedBy { get; set; }
public bool IsAttr74Active { get; set; }
public int Attr74SortOrder { get; set; }


public int Field7Id { get; set; }
public string Field7Name { get; set; }
public string Field7Description { get; set; }
public DateTime Field7CreatedAt { get; set; }
public DateTime? Field7UpdatedAt { get; set; }
public string Field7CreatedBy { get; set; }
public bool IsField7Active { get; set; }
public int Field7SortOrder { get; set; }


public int Attr38Id { get; set; }
public string Attr38Name { get; set; }
public string Attr38Description { get; set; }
public DateTime Attr38CreatedAt { get; set; }
public DateTime? Attr38UpdatedAt { get; set; }
public string Attr38CreatedBy { get; set; }
public bool IsAttr38Active { get; set; }
public int Attr38SortOrder { get; set; }


public int Field98Id { get; set; }
public string Field98Name { get; set; }
public string Field98Description { get; set; }
public DateTime Field98CreatedAt { get; set; }
public DateTime? Field98UpdatedAt { get; set; }
public string Field98CreatedBy { get; set; }
public bool IsField98Active { get; set; }
public int Field98SortOrder { get; set; }


public int Attr99Id { get; set; }
public string Attr99Name { get; set; }
public string Attr99Description { get; set; }
public DateTime Attr99CreatedAt { get; set; }
public DateTime? Attr99UpdatedAt { get; set; }
public string Attr99CreatedBy { get; set; }
public bool IsAttr99Active { get; set; }
public int Attr99SortOrder { get; set; }


public int Record67Id { get; set; }
public string Record67Name { get; set; }
public string Record67Description { get; set; }
public DateTime Record67CreatedAt { get; set; }
public DateTime? Record67UpdatedAt { get; set; }
public string Record67CreatedBy { get; set; }
public bool IsRecord67Active { get; set; }
public int Record67SortOrder { get; set; }


public int Record40Id { get; set; }
public string Record40Name { get; set; }
public string Record40Description { get; set; }
public DateTime Record40CreatedAt { get; set; }
public DateTime? Record40UpdatedAt { get; set; }
public string Record40CreatedBy { get; set; }
public bool IsRecord40Active { get; set; }
public int Record40SortOrder { get; set; }


public int Record82Id { get; set; }
public string Record82Name { get; set; }
public string Record82Description { get; set; }
public DateTime Record82CreatedAt { get; set; }
public DateTime? Record82UpdatedAt { get; set; }
public string Record82CreatedBy { get; set; }
public bool IsRecord82Active { get; set; }
public int Record82SortOrder { get; set; }


public int Config14Id { get; set; }
public string Config14Name { get; set; }
public string Config14Description { get; set; }
public DateTime Config14CreatedAt { get; set; }
public DateTime? Config14UpdatedAt { get; set; }
public string Config14CreatedBy { get; set; }
public bool IsConfig14Active { get; set; }
public int Config14SortOrder { get; set; }


public int Item84Id { get; set; }
public string Item84Name { get; set; }
public string Item84Description { get; set; }
public DateTime Item84CreatedAt { get; set; }
public DateTime? Item84UpdatedAt { get; set; }
public string Item84CreatedBy { get; set; }
public bool IsItem84Active { get; set; }
public int Item84SortOrder { get; set; }


public int Field5Id { get; set; }
public string Field5Name { get; set; }
public string Field5Description { get; set; }
public DateTime Field5CreatedAt { get; set; }
public DateTime? Field5UpdatedAt { get; set; }
public string Field5CreatedBy { get; set; }
public bool IsField5Active { get; set; }
public int Field5SortOrder { get; set; }


public int Detail19Id { get; set; }
public string Detail19Name { get; set; }
public string Detail19Description { get; set; }
public DateTime Detail19CreatedAt { get; set; }
public DateTime? Detail19UpdatedAt { get; set; }
public string Detail19CreatedBy { get; set; }
public bool IsDetail19Active { get; set; }
public int Detail19SortOrder { get; set; }


public int Field73Id { get; set; }
public string Field73Name { get; set; }
public string Field73Description { get; set; }
public DateTime Field73CreatedAt { get; set; }
public DateTime? Field73UpdatedAt { get; set; }
public string Field73CreatedBy { get; set; }
public bool IsField73Active { get; set; }
public int Field73SortOrder { get; set; }


public int Record4Id { get; set; }
public string Record4Name { get; set; }
public string Record4Description { get; set; }
public DateTime Record4CreatedAt { get; set; }
public DateTime? Record4UpdatedAt { get; set; }
public string Record4CreatedBy { get; set; }
public bool IsRecord4Active { get; set; }
public int Record4SortOrder { get; set; }


public int Attr73Id { get; set; }
public string Attr73Name { get; set; }
public string Attr73Description { get; set; }
public DateTime Attr73CreatedAt { get; set; }
public DateTime? Attr73UpdatedAt { get; set; }
public string Attr73CreatedBy { get; set; }
public bool IsAttr73Active { get; set; }
public int Attr73SortOrder { get; set; }


public int Attr62Id { get; set; }
public string Attr62Name { get; set; }
public string Attr62Description { get; set; }
public DateTime Attr62CreatedAt { get; set; }
public DateTime? Attr62UpdatedAt { get; set; }
public string Attr62CreatedBy { get; set; }
public bool IsAttr62Active { get; set; }
public int Attr62SortOrder { get; set; }


public int Item6Id { get; set; }
public string Item6Name { get; set; }
public string Item6Description { get; set; }
public DateTime Item6CreatedAt { get; set; }
public DateTime? Item6UpdatedAt { get; set; }
public string Item6CreatedBy { get; set; }
public bool IsItem6Active { get; set; }
public int Item6SortOrder { get; set; }


public int Attr85Id { get; set; }
public string Attr85Name { get; set; }
public string Attr85Description { get; set; }
public DateTime Attr85CreatedAt { get; set; }
public DateTime? Attr85UpdatedAt { get; set; }
public string Attr85CreatedBy { get; set; }
public bool IsAttr85Active { get; set; }
public int Attr85SortOrder { get; set; }


public int Item43Id { get; set; }
public string Item43Name { get; set; }
public string Item43Description { get; set; }
public DateTime Item43CreatedAt { get; set; }
public DateTime? Item43UpdatedAt { get; set; }
public string Item43CreatedBy { get; set; }
public bool IsItem43Active { get; set; }
public int Item43SortOrder { get; set; }


public int Record86Id { get; set; }
public string Record86Name { get; set; }
public string Record86Description { get; set; }
public DateTime Record86CreatedAt { get; set; }
public DateTime? Record86UpdatedAt { get; set; }
public string Record86CreatedBy { get; set; }
public bool IsRecord86Active { get; set; }
public int Record86SortOrder { get; set; }


public int Config73Id { get; set; }
public string Config73Name { get; set; }
public string Config73Description { get; set; }
public DateTime Config73CreatedAt { get; set; }
public DateTime? Config73UpdatedAt { get; set; }
public string Config73CreatedBy { get; set; }
public bool IsConfig73Active { get; set; }
public int Config73SortOrder { get; set; }


public int Entry88Id { get; set; }
public string Entry88Name { get; set; }
public string Entry88Description { get; set; }
public DateTime Entry88CreatedAt { get; set; }
public DateTime? Entry88UpdatedAt { get; set; }
public string Entry88CreatedBy { get; set; }
public bool IsEntry88Active { get; set; }
public int Entry88SortOrder { get; set; }


public int Param99Id { get; set; }
public string Param99Name { get; set; }
public string Param99Description { get; set; }
public DateTime Param99CreatedAt { get; set; }
public DateTime? Param99UpdatedAt { get; set; }
public string Param99CreatedBy { get; set; }
public bool IsParam99Active { get; set; }
public int Param99SortOrder { get; set; }


public int Record37Id { get; set; }
public string Record37Name { get; set; }
public string Record37Description { get; set; }
public DateTime Record37CreatedAt { get; set; }
public DateTime? Record37UpdatedAt { get; set; }
public string Record37CreatedBy { get; set; }
public bool IsRecord37Active { get; set; }
public int Record37SortOrder { get; set; }


public int Entry71Id { get; set; }
public string Entry71Name { get; set; }
public string Entry71Description { get; set; }
public DateTime Entry71CreatedAt { get; set; }
public DateTime? Entry71UpdatedAt { get; set; }
public string Entry71CreatedBy { get; set; }
public bool IsEntry71Active { get; set; }
public int Entry71SortOrder { get; set; }


public int Config32Id { get; set; }
public string Config32Name { get; set; }
public string Config32Description { get; set; }
public DateTime Config32CreatedAt { get; set; }
public DateTime? Config32UpdatedAt { get; set; }
public string Config32CreatedBy { get; set; }
public bool IsConfig32Active { get; set; }
public int Config32SortOrder { get; set; }


public int Param59Id { get; set; }
public string Param59Name { get; set; }
public string Param59Description { get; set; }
public DateTime Param59CreatedAt { get; set; }
public DateTime? Param59UpdatedAt { get; set; }
public string Param59CreatedBy { get; set; }
public bool IsParam59Active { get; set; }
public int Param59SortOrder { get; set; }


public int Attr83Id { get; set; }
public string Attr83Name { get; set; }
public string Attr83Description { get; set; }
public DateTime Attr83CreatedAt { get; set; }
public DateTime? Attr83UpdatedAt { get; set; }
public string Attr83CreatedBy { get; set; }
public bool IsAttr83Active { get; set; }
public int Attr83SortOrder { get; set; }


public int Record99Id { get; set; }
public string Record99Name { get; set; }
public string Record99Description { get; set; }
public DateTime Record99CreatedAt { get; set; }
public DateTime? Record99UpdatedAt { get; set; }
public string Record99CreatedBy { get; set; }
public bool IsRecord99Active { get; set; }
public int Record99SortOrder { get; set; }


public int Detail70Id { get; set; }
public string Detail70Name { get; set; }
public string Detail70Description { get; set; }
public DateTime Detail70CreatedAt { get; set; }
public DateTime? Detail70UpdatedAt { get; set; }
public string Detail70CreatedBy { get; set; }
public bool IsDetail70Active { get; set; }
public int Detail70SortOrder { get; set; }


public int Field71Id { get; set; }
public string Field71Name { get; set; }
public string Field71Description { get; set; }
public DateTime Field71CreatedAt { get; set; }
public DateTime? Field71UpdatedAt { get; set; }
public string Field71CreatedBy { get; set; }
public bool IsField71Active { get; set; }
public int Field71SortOrder { get; set; }


public int Attr63Id { get; set; }
public string Attr63Name { get; set; }
public string Attr63Description { get; set; }
public DateTime Attr63CreatedAt { get; set; }
public DateTime? Attr63UpdatedAt { get; set; }
public string Attr63CreatedBy { get; set; }
public bool IsAttr63Active { get; set; }
public int Attr63SortOrder { get; set; }


public int Field3Id { get; set; }
public string Field3Name { get; set; }
public string Field3Description { get; set; }
public DateTime Field3CreatedAt { get; set; }
public DateTime? Field3UpdatedAt { get; set; }
public string Field3CreatedBy { get; set; }
public bool IsField3Active { get; set; }
public int Field3SortOrder { get; set; }


public int Attr83Id { get; set; }
public string Attr83Name { get; set; }
public string Attr83Description { get; set; }
public DateTime Attr83CreatedAt { get; set; }
public DateTime? Attr83UpdatedAt { get; set; }
public string Attr83CreatedBy { get; set; }
public bool IsAttr83Active { get; set; }
public int Attr83SortOrder { get; set; }


public int Config77Id { get; set; }
public string Config77Name { get; set; }
public string Config77Description { get; set; }
public DateTime Config77CreatedAt { get; set; }
public DateTime? Config77UpdatedAt { get; set; }
public string Config77CreatedBy { get; set; }
public bool IsConfig77Active { get; set; }
public int Config77SortOrder { get; set; }


public int Entry6Id { get; set; }
public string Entry6Name { get; set; }
public string Entry6Description { get; set; }
public DateTime Entry6CreatedAt { get; set; }
public DateTime? Entry6UpdatedAt { get; set; }
public string Entry6CreatedBy { get; set; }
public bool IsEntry6Active { get; set; }
public int Entry6SortOrder { get; set; }


public int Param46Id { get; set; }
public string Param46Name { get; set; }
public string Param46Description { get; set; }
public DateTime Param46CreatedAt { get; set; }
public DateTime? Param46UpdatedAt { get; set; }
public string Param46CreatedBy { get; set; }
public bool IsParam46Active { get; set; }
public int Param46SortOrder { get; set; }


public int Entry88Id { get; set; }
public string Entry88Name { get; set; }
public string Entry88Description { get; set; }
public DateTime Entry88CreatedAt { get; set; }
public DateTime? Entry88UpdatedAt { get; set; }
public string Entry88CreatedBy { get; set; }
public bool IsEntry88Active { get; set; }
public int Entry88SortOrder { get; set; }


public int Detail52Id { get; set; }
public string Detail52Name { get; set; }
public string Detail52Description { get; set; }
public DateTime Detail52CreatedAt { get; set; }
public DateTime? Detail52UpdatedAt { get; set; }
public string Detail52CreatedBy { get; set; }
public bool IsDetail52Active { get; set; }
public int Detail52SortOrder { get; set; }

    }

}