using Admin.Client;
using Admin.Web46;
using Auth.Client;
using Auth.Events;
using Auth.Mappers28;
using Auth.Processors319;
using Documents.Core357;
using Documents.Shared487;
using Imaging.Validators;
using Import.Shared;
using Integration.Data;
using Logging.Core159;
using Logging.Data29;
using Logging.Validators359;
using Portal.Client;
using Portal.Contracts;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;

namespace DataAccess.Handlers
{
    internal class DataAccess_Handlers_Handler1
    {
        public void Execute()
        {
            // DataAccess_Handlers_Handler1 implementation
        }

/// <summary>
/// Validates the Handler1 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateHandler1(Handler1Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Handler1));
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
/// Processes the Handler1 operation asynchronously.
/// </summary>
public async Task<Handler1Result> ProcessHandler1Async(
    Handler1Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Handler1), request.Id);

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
            return new Handler1Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Handler1));
        return new Handler1Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Handler1));
        return new Handler1Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Handler1 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Handler1Dto>> GetHandler1ListAsync(
    Handler1Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Handler1Entity>().AsQueryable();

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
        .Select(x => new Handler1Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Handler1Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Handler1Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Handler1Service(
    ILogger<Handler1Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Handler1:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Handler1 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Handler1Data> GetCachedHandler1Async(string key)
{
    var cacheKey = $"Handler1_{key}";

    if (_cache.TryGetValue(cacheKey, out Handler1Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromHandler1SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Attr38Id { get; set; }
public string Attr38Name { get; set; }
public string Attr38Description { get; set; }
public DateTime Attr38CreatedAt { get; set; }
public DateTime? Attr38UpdatedAt { get; set; }
public string Attr38CreatedBy { get; set; }
public bool IsAttr38Active { get; set; }
public int Attr38SortOrder { get; set; }


public int Attr20Id { get; set; }
public string Attr20Name { get; set; }
public string Attr20Description { get; set; }
public DateTime Attr20CreatedAt { get; set; }
public DateTime? Attr20UpdatedAt { get; set; }
public string Attr20CreatedBy { get; set; }
public bool IsAttr20Active { get; set; }
public int Attr20SortOrder { get; set; }


public int Detail26Id { get; set; }
public string Detail26Name { get; set; }
public string Detail26Description { get; set; }
public DateTime Detail26CreatedAt { get; set; }
public DateTime? Detail26UpdatedAt { get; set; }
public string Detail26CreatedBy { get; set; }
public bool IsDetail26Active { get; set; }
public int Detail26SortOrder { get; set; }


public int Entry83Id { get; set; }
public string Entry83Name { get; set; }
public string Entry83Description { get; set; }
public DateTime Entry83CreatedAt { get; set; }
public DateTime? Entry83UpdatedAt { get; set; }
public string Entry83CreatedBy { get; set; }
public bool IsEntry83Active { get; set; }
public int Entry83SortOrder { get; set; }


public int Config20Id { get; set; }
public string Config20Name { get; set; }
public string Config20Description { get; set; }
public DateTime Config20CreatedAt { get; set; }
public DateTime? Config20UpdatedAt { get; set; }
public string Config20CreatedBy { get; set; }
public bool IsConfig20Active { get; set; }
public int Config20SortOrder { get; set; }


public int Record45Id { get; set; }
public string Record45Name { get; set; }
public string Record45Description { get; set; }
public DateTime Record45CreatedAt { get; set; }
public DateTime? Record45UpdatedAt { get; set; }
public string Record45CreatedBy { get; set; }
public bool IsRecord45Active { get; set; }
public int Record45SortOrder { get; set; }


public int Detail53Id { get; set; }
public string Detail53Name { get; set; }
public string Detail53Description { get; set; }
public DateTime Detail53CreatedAt { get; set; }
public DateTime? Detail53UpdatedAt { get; set; }
public string Detail53CreatedBy { get; set; }
public bool IsDetail53Active { get; set; }
public int Detail53SortOrder { get; set; }


public int Config78Id { get; set; }
public string Config78Name { get; set; }
public string Config78Description { get; set; }
public DateTime Config78CreatedAt { get; set; }
public DateTime? Config78UpdatedAt { get; set; }
public string Config78CreatedBy { get; set; }
public bool IsConfig78Active { get; set; }
public int Config78SortOrder { get; set; }


public int Entry51Id { get; set; }
public string Entry51Name { get; set; }
public string Entry51Description { get; set; }
public DateTime Entry51CreatedAt { get; set; }
public DateTime? Entry51UpdatedAt { get; set; }
public string Entry51CreatedBy { get; set; }
public bool IsEntry51Active { get; set; }
public int Entry51SortOrder { get; set; }


public int Attr27Id { get; set; }
public string Attr27Name { get; set; }
public string Attr27Description { get; set; }
public DateTime Attr27CreatedAt { get; set; }
public DateTime? Attr27UpdatedAt { get; set; }
public string Attr27CreatedBy { get; set; }
public bool IsAttr27Active { get; set; }
public int Attr27SortOrder { get; set; }


public int Param18Id { get; set; }
public string Param18Name { get; set; }
public string Param18Description { get; set; }
public DateTime Param18CreatedAt { get; set; }
public DateTime? Param18UpdatedAt { get; set; }
public string Param18CreatedBy { get; set; }
public bool IsParam18Active { get; set; }
public int Param18SortOrder { get; set; }


public int Detail2Id { get; set; }
public string Detail2Name { get; set; }
public string Detail2Description { get; set; }
public DateTime Detail2CreatedAt { get; set; }
public DateTime? Detail2UpdatedAt { get; set; }
public string Detail2CreatedBy { get; set; }
public bool IsDetail2Active { get; set; }
public int Detail2SortOrder { get; set; }


public int Attr78Id { get; set; }
public string Attr78Name { get; set; }
public string Attr78Description { get; set; }
public DateTime Attr78CreatedAt { get; set; }
public DateTime? Attr78UpdatedAt { get; set; }
public string Attr78CreatedBy { get; set; }
public bool IsAttr78Active { get; set; }
public int Attr78SortOrder { get; set; }


public int Record32Id { get; set; }
public string Record32Name { get; set; }
public string Record32Description { get; set; }
public DateTime Record32CreatedAt { get; set; }
public DateTime? Record32UpdatedAt { get; set; }
public string Record32CreatedBy { get; set; }
public bool IsRecord32Active { get; set; }
public int Record32SortOrder { get; set; }


public int Record46Id { get; set; }
public string Record46Name { get; set; }
public string Record46Description { get; set; }
public DateTime Record46CreatedAt { get; set; }
public DateTime? Record46UpdatedAt { get; set; }
public string Record46CreatedBy { get; set; }
public bool IsRecord46Active { get; set; }
public int Record46SortOrder { get; set; }


public int Attr61Id { get; set; }
public string Attr61Name { get; set; }
public string Attr61Description { get; set; }
public DateTime Attr61CreatedAt { get; set; }
public DateTime? Attr61UpdatedAt { get; set; }
public string Attr61CreatedBy { get; set; }
public bool IsAttr61Active { get; set; }
public int Attr61SortOrder { get; set; }


public int Item17Id { get; set; }
public string Item17Name { get; set; }
public string Item17Description { get; set; }
public DateTime Item17CreatedAt { get; set; }
public DateTime? Item17UpdatedAt { get; set; }
public string Item17CreatedBy { get; set; }
public bool IsItem17Active { get; set; }
public int Item17SortOrder { get; set; }


public int Item2Id { get; set; }
public string Item2Name { get; set; }
public string Item2Description { get; set; }
public DateTime Item2CreatedAt { get; set; }
public DateTime? Item2UpdatedAt { get; set; }
public string Item2CreatedBy { get; set; }
public bool IsItem2Active { get; set; }
public int Item2SortOrder { get; set; }


public int Param70Id { get; set; }
public string Param70Name { get; set; }
public string Param70Description { get; set; }
public DateTime Param70CreatedAt { get; set; }
public DateTime? Param70UpdatedAt { get; set; }
public string Param70CreatedBy { get; set; }
public bool IsParam70Active { get; set; }
public int Param70SortOrder { get; set; }


public int Entry51Id { get; set; }
public string Entry51Name { get; set; }
public string Entry51Description { get; set; }
public DateTime Entry51CreatedAt { get; set; }
public DateTime? Entry51UpdatedAt { get; set; }
public string Entry51CreatedBy { get; set; }
public bool IsEntry51Active { get; set; }
public int Entry51SortOrder { get; set; }


public int Field11Id { get; set; }
public string Field11Name { get; set; }
public string Field11Description { get; set; }
public DateTime Field11CreatedAt { get; set; }
public DateTime? Field11UpdatedAt { get; set; }
public string Field11CreatedBy { get; set; }
public bool IsField11Active { get; set; }
public int Field11SortOrder { get; set; }


public int Field43Id { get; set; }
public string Field43Name { get; set; }
public string Field43Description { get; set; }
public DateTime Field43CreatedAt { get; set; }
public DateTime? Field43UpdatedAt { get; set; }
public string Field43CreatedBy { get; set; }
public bool IsField43Active { get; set; }
public int Field43SortOrder { get; set; }


public int Entry75Id { get; set; }
public string Entry75Name { get; set; }
public string Entry75Description { get; set; }
public DateTime Entry75CreatedAt { get; set; }
public DateTime? Entry75UpdatedAt { get; set; }
public string Entry75CreatedBy { get; set; }
public bool IsEntry75Active { get; set; }
public int Entry75SortOrder { get; set; }


public int Detail78Id { get; set; }
public string Detail78Name { get; set; }
public string Detail78Description { get; set; }
public DateTime Detail78CreatedAt { get; set; }
public DateTime? Detail78UpdatedAt { get; set; }
public string Detail78CreatedBy { get; set; }
public bool IsDetail78Active { get; set; }
public int Detail78SortOrder { get; set; }


public int Param67Id { get; set; }
public string Param67Name { get; set; }
public string Param67Description { get; set; }
public DateTime Param67CreatedAt { get; set; }
public DateTime? Param67UpdatedAt { get; set; }
public string Param67CreatedBy { get; set; }
public bool IsParam67Active { get; set; }
public int Param67SortOrder { get; set; }


public int Attr75Id { get; set; }
public string Attr75Name { get; set; }
public string Attr75Description { get; set; }
public DateTime Attr75CreatedAt { get; set; }
public DateTime? Attr75UpdatedAt { get; set; }
public string Attr75CreatedBy { get; set; }
public bool IsAttr75Active { get; set; }
public int Attr75SortOrder { get; set; }


public int Attr94Id { get; set; }
public string Attr94Name { get; set; }
public string Attr94Description { get; set; }
public DateTime Attr94CreatedAt { get; set; }
public DateTime? Attr94UpdatedAt { get; set; }
public string Attr94CreatedBy { get; set; }
public bool IsAttr94Active { get; set; }
public int Attr94SortOrder { get; set; }


public int Field44Id { get; set; }
public string Field44Name { get; set; }
public string Field44Description { get; set; }
public DateTime Field44CreatedAt { get; set; }
public DateTime? Field44UpdatedAt { get; set; }
public string Field44CreatedBy { get; set; }
public bool IsField44Active { get; set; }
public int Field44SortOrder { get; set; }


public int Config8Id { get; set; }
public string Config8Name { get; set; }
public string Config8Description { get; set; }
public DateTime Config8CreatedAt { get; set; }
public DateTime? Config8UpdatedAt { get; set; }
public string Config8CreatedBy { get; set; }
public bool IsConfig8Active { get; set; }
public int Config8SortOrder { get; set; }


public int Field69Id { get; set; }
public string Field69Name { get; set; }
public string Field69Description { get; set; }
public DateTime Field69CreatedAt { get; set; }
public DateTime? Field69UpdatedAt { get; set; }
public string Field69CreatedBy { get; set; }
public bool IsField69Active { get; set; }
public int Field69SortOrder { get; set; }


public int Param32Id { get; set; }
public string Param32Name { get; set; }
public string Param32Description { get; set; }
public DateTime Param32CreatedAt { get; set; }
public DateTime? Param32UpdatedAt { get; set; }
public string Param32CreatedBy { get; set; }
public bool IsParam32Active { get; set; }
public int Param32SortOrder { get; set; }


public int Config64Id { get; set; }
public string Config64Name { get; set; }
public string Config64Description { get; set; }
public DateTime Config64CreatedAt { get; set; }
public DateTime? Config64UpdatedAt { get; set; }
public string Config64CreatedBy { get; set; }
public bool IsConfig64Active { get; set; }
public int Config64SortOrder { get; set; }


public int Entry23Id { get; set; }
public string Entry23Name { get; set; }
public string Entry23Description { get; set; }
public DateTime Entry23CreatedAt { get; set; }
public DateTime? Entry23UpdatedAt { get; set; }
public string Entry23CreatedBy { get; set; }
public bool IsEntry23Active { get; set; }
public int Entry23SortOrder { get; set; }


public int Item32Id { get; set; }
public string Item32Name { get; set; }
public string Item32Description { get; set; }
public DateTime Item32CreatedAt { get; set; }
public DateTime? Item32UpdatedAt { get; set; }
public string Item32CreatedBy { get; set; }
public bool IsItem32Active { get; set; }
public int Item32SortOrder { get; set; }


public int Entry46Id { get; set; }
public string Entry46Name { get; set; }
public string Entry46Description { get; set; }
public DateTime Entry46CreatedAt { get; set; }
public DateTime? Entry46UpdatedAt { get; set; }
public string Entry46CreatedBy { get; set; }
public bool IsEntry46Active { get; set; }
public int Entry46SortOrder { get; set; }


public int Record10Id { get; set; }
public string Record10Name { get; set; }
public string Record10Description { get; set; }
public DateTime Record10CreatedAt { get; set; }
public DateTime? Record10UpdatedAt { get; set; }
public string Record10CreatedBy { get; set; }
public bool IsRecord10Active { get; set; }
public int Record10SortOrder { get; set; }


public int Field45Id { get; set; }
public string Field45Name { get; set; }
public string Field45Description { get; set; }
public DateTime Field45CreatedAt { get; set; }
public DateTime? Field45UpdatedAt { get; set; }
public string Field45CreatedBy { get; set; }
public bool IsField45Active { get; set; }
public int Field45SortOrder { get; set; }


public int Config88Id { get; set; }
public string Config88Name { get; set; }
public string Config88Description { get; set; }
public DateTime Config88CreatedAt { get; set; }
public DateTime? Config88UpdatedAt { get; set; }
public string Config88CreatedBy { get; set; }
public bool IsConfig88Active { get; set; }
public int Config88SortOrder { get; set; }


public int Config32Id { get; set; }
public string Config32Name { get; set; }
public string Config32Description { get; set; }
public DateTime Config32CreatedAt { get; set; }
public DateTime? Config32UpdatedAt { get; set; }
public string Config32CreatedBy { get; set; }
public bool IsConfig32Active { get; set; }
public int Config32SortOrder { get; set; }


public int Record4Id { get; set; }
public string Record4Name { get; set; }
public string Record4Description { get; set; }
public DateTime Record4CreatedAt { get; set; }
public DateTime? Record4UpdatedAt { get; set; }
public string Record4CreatedBy { get; set; }
public bool IsRecord4Active { get; set; }
public int Record4SortOrder { get; set; }


public int Detail31Id { get; set; }
public string Detail31Name { get; set; }
public string Detail31Description { get; set; }
public DateTime Detail31CreatedAt { get; set; }
public DateTime? Detail31UpdatedAt { get; set; }
public string Detail31CreatedBy { get; set; }
public bool IsDetail31Active { get; set; }
public int Detail31SortOrder { get; set; }


public int Detail68Id { get; set; }
public string Detail68Name { get; set; }
public string Detail68Description { get; set; }
public DateTime Detail68CreatedAt { get; set; }
public DateTime? Detail68UpdatedAt { get; set; }
public string Detail68CreatedBy { get; set; }
public bool IsDetail68Active { get; set; }
public int Detail68SortOrder { get; set; }


public int Config10Id { get; set; }
public string Config10Name { get; set; }
public string Config10Description { get; set; }
public DateTime Config10CreatedAt { get; set; }
public DateTime? Config10UpdatedAt { get; set; }
public string Config10CreatedBy { get; set; }
public bool IsConfig10Active { get; set; }
public int Config10SortOrder { get; set; }


public int Detail8Id { get; set; }
public string Detail8Name { get; set; }
public string Detail8Description { get; set; }
public DateTime Detail8CreatedAt { get; set; }
public DateTime? Detail8UpdatedAt { get; set; }
public string Detail8CreatedBy { get; set; }
public bool IsDetail8Active { get; set; }
public int Detail8SortOrder { get; set; }


public int Record74Id { get; set; }
public string Record74Name { get; set; }
public string Record74Description { get; set; }
public DateTime Record74CreatedAt { get; set; }
public DateTime? Record74UpdatedAt { get; set; }
public string Record74CreatedBy { get; set; }
public bool IsRecord74Active { get; set; }
public int Record74SortOrder { get; set; }


public int Attr23Id { get; set; }
public string Attr23Name { get; set; }
public string Attr23Description { get; set; }
public DateTime Attr23CreatedAt { get; set; }
public DateTime? Attr23UpdatedAt { get; set; }
public string Attr23CreatedBy { get; set; }
public bool IsAttr23Active { get; set; }
public int Attr23SortOrder { get; set; }


public int Entry66Id { get; set; }
public string Entry66Name { get; set; }
public string Entry66Description { get; set; }
public DateTime Entry66CreatedAt { get; set; }
public DateTime? Entry66UpdatedAt { get; set; }
public string Entry66CreatedBy { get; set; }
public bool IsEntry66Active { get; set; }
public int Entry66SortOrder { get; set; }


public int Detail75Id { get; set; }
public string Detail75Name { get; set; }
public string Detail75Description { get; set; }
public DateTime Detail75CreatedAt { get; set; }
public DateTime? Detail75UpdatedAt { get; set; }
public string Detail75CreatedBy { get; set; }
public bool IsDetail75Active { get; set; }
public int Detail75SortOrder { get; set; }


public int Detail70Id { get; set; }
public string Detail70Name { get; set; }
public string Detail70Description { get; set; }
public DateTime Detail70CreatedAt { get; set; }
public DateTime? Detail70UpdatedAt { get; set; }
public string Detail70CreatedBy { get; set; }
public bool IsDetail70Active { get; set; }
public int Detail70SortOrder { get; set; }


public int Record61Id { get; set; }
public string Record61Name { get; set; }
public string Record61Description { get; set; }
public DateTime Record61CreatedAt { get; set; }
public DateTime? Record61UpdatedAt { get; set; }
public string Record61CreatedBy { get; set; }
public bool IsRecord61Active { get; set; }
public int Record61SortOrder { get; set; }


public int Entry54Id { get; set; }
public string Entry54Name { get; set; }
public string Entry54Description { get; set; }
public DateTime Entry54CreatedAt { get; set; }
public DateTime? Entry54UpdatedAt { get; set; }
public string Entry54CreatedBy { get; set; }
public bool IsEntry54Active { get; set; }
public int Entry54SortOrder { get; set; }


public int Item52Id { get; set; }
public string Item52Name { get; set; }
public string Item52Description { get; set; }
public DateTime Item52CreatedAt { get; set; }
public DateTime? Item52UpdatedAt { get; set; }
public string Item52CreatedBy { get; set; }
public bool IsItem52Active { get; set; }
public int Item52SortOrder { get; set; }


public int Attr72Id { get; set; }
public string Attr72Name { get; set; }
public string Attr72Description { get; set; }
public DateTime Attr72CreatedAt { get; set; }
public DateTime? Attr72UpdatedAt { get; set; }
public string Attr72CreatedBy { get; set; }
public bool IsAttr72Active { get; set; }
public int Attr72SortOrder { get; set; }


public int Config70Id { get; set; }
public string Config70Name { get; set; }
public string Config70Description { get; set; }
public DateTime Config70CreatedAt { get; set; }
public DateTime? Config70UpdatedAt { get; set; }
public string Config70CreatedBy { get; set; }
public bool IsConfig70Active { get; set; }
public int Config70SortOrder { get; set; }

    }

}