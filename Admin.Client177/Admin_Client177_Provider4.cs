using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Client177
{
    internal static class Admin_Client177_Provider4 : IDisposable
    {
        public void Execute()
        {
            // Admin_Client177_Provider4 implementation
        }

/// <summary>
/// Validates the Provider4 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateProvider4(Provider4Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Provider4));
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
/// Processes the Provider4 operation asynchronously.
/// </summary>
public async Task<Provider4Result> ProcessProvider4Async(
    Provider4Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Provider4), request.Id);

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
            return new Provider4Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Provider4));
        return new Provider4Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Provider4));
        return new Provider4Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Provider4 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Provider4Dto>> GetProvider4ListAsync(
    Provider4Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Provider4Entity>().AsQueryable();

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
        .Select(x => new Provider4Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Provider4Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Provider4Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Provider4Service(
    ILogger<Provider4Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Provider4:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Provider4 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Provider4Data> GetCachedProvider4Async(string key)
{
    var cacheKey = $"Provider4_{key}";

    if (_cache.TryGetValue(cacheKey, out Provider4Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromProvider4SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Field9Id { get; set; }
public string Field9Name { get; set; }
public string Field9Description { get; set; }
public DateTime Field9CreatedAt { get; set; }
public DateTime? Field9UpdatedAt { get; set; }
public string Field9CreatedBy { get; set; }
public bool IsField9Active { get; set; }
public int Field9SortOrder { get; set; }


public int Detail4Id { get; set; }
public string Detail4Name { get; set; }
public string Detail4Description { get; set; }
public DateTime Detail4CreatedAt { get; set; }
public DateTime? Detail4UpdatedAt { get; set; }
public string Detail4CreatedBy { get; set; }
public bool IsDetail4Active { get; set; }
public int Detail4SortOrder { get; set; }


public int Entry25Id { get; set; }
public string Entry25Name { get; set; }
public string Entry25Description { get; set; }
public DateTime Entry25CreatedAt { get; set; }
public DateTime? Entry25UpdatedAt { get; set; }
public string Entry25CreatedBy { get; set; }
public bool IsEntry25Active { get; set; }
public int Entry25SortOrder { get; set; }


public int Field34Id { get; set; }
public string Field34Name { get; set; }
public string Field34Description { get; set; }
public DateTime Field34CreatedAt { get; set; }
public DateTime? Field34UpdatedAt { get; set; }
public string Field34CreatedBy { get; set; }
public bool IsField34Active { get; set; }
public int Field34SortOrder { get; set; }


public int Record89Id { get; set; }
public string Record89Name { get; set; }
public string Record89Description { get; set; }
public DateTime Record89CreatedAt { get; set; }
public DateTime? Record89UpdatedAt { get; set; }
public string Record89CreatedBy { get; set; }
public bool IsRecord89Active { get; set; }
public int Record89SortOrder { get; set; }


public int Field78Id { get; set; }
public string Field78Name { get; set; }
public string Field78Description { get; set; }
public DateTime Field78CreatedAt { get; set; }
public DateTime? Field78UpdatedAt { get; set; }
public string Field78CreatedBy { get; set; }
public bool IsField78Active { get; set; }
public int Field78SortOrder { get; set; }


public int Detail55Id { get; set; }
public string Detail55Name { get; set; }
public string Detail55Description { get; set; }
public DateTime Detail55CreatedAt { get; set; }
public DateTime? Detail55UpdatedAt { get; set; }
public string Detail55CreatedBy { get; set; }
public bool IsDetail55Active { get; set; }
public int Detail55SortOrder { get; set; }


public int Detail41Id { get; set; }
public string Detail41Name { get; set; }
public string Detail41Description { get; set; }
public DateTime Detail41CreatedAt { get; set; }
public DateTime? Detail41UpdatedAt { get; set; }
public string Detail41CreatedBy { get; set; }
public bool IsDetail41Active { get; set; }
public int Detail41SortOrder { get; set; }


public int Record53Id { get; set; }
public string Record53Name { get; set; }
public string Record53Description { get; set; }
public DateTime Record53CreatedAt { get; set; }
public DateTime? Record53UpdatedAt { get; set; }
public string Record53CreatedBy { get; set; }
public bool IsRecord53Active { get; set; }
public int Record53SortOrder { get; set; }


public int Attr56Id { get; set; }
public string Attr56Name { get; set; }
public string Attr56Description { get; set; }
public DateTime Attr56CreatedAt { get; set; }
public DateTime? Attr56UpdatedAt { get; set; }
public string Attr56CreatedBy { get; set; }
public bool IsAttr56Active { get; set; }
public int Attr56SortOrder { get; set; }


public int Config2Id { get; set; }
public string Config2Name { get; set; }
public string Config2Description { get; set; }
public DateTime Config2CreatedAt { get; set; }
public DateTime? Config2UpdatedAt { get; set; }
public string Config2CreatedBy { get; set; }
public bool IsConfig2Active { get; set; }
public int Config2SortOrder { get; set; }


public int Detail19Id { get; set; }
public string Detail19Name { get; set; }
public string Detail19Description { get; set; }
public DateTime Detail19CreatedAt { get; set; }
public DateTime? Detail19UpdatedAt { get; set; }
public string Detail19CreatedBy { get; set; }
public bool IsDetail19Active { get; set; }
public int Detail19SortOrder { get; set; }


public int Detail74Id { get; set; }
public string Detail74Name { get; set; }
public string Detail74Description { get; set; }
public DateTime Detail74CreatedAt { get; set; }
public DateTime? Detail74UpdatedAt { get; set; }
public string Detail74CreatedBy { get; set; }
public bool IsDetail74Active { get; set; }
public int Detail74SortOrder { get; set; }


public int Record92Id { get; set; }
public string Record92Name { get; set; }
public string Record92Description { get; set; }
public DateTime Record92CreatedAt { get; set; }
public DateTime? Record92UpdatedAt { get; set; }
public string Record92CreatedBy { get; set; }
public bool IsRecord92Active { get; set; }
public int Record92SortOrder { get; set; }


public int Detail85Id { get; set; }
public string Detail85Name { get; set; }
public string Detail85Description { get; set; }
public DateTime Detail85CreatedAt { get; set; }
public DateTime? Detail85UpdatedAt { get; set; }
public string Detail85CreatedBy { get; set; }
public bool IsDetail85Active { get; set; }
public int Detail85SortOrder { get; set; }


public int Entry44Id { get; set; }
public string Entry44Name { get; set; }
public string Entry44Description { get; set; }
public DateTime Entry44CreatedAt { get; set; }
public DateTime? Entry44UpdatedAt { get; set; }
public string Entry44CreatedBy { get; set; }
public bool IsEntry44Active { get; set; }
public int Entry44SortOrder { get; set; }


public int Entry69Id { get; set; }
public string Entry69Name { get; set; }
public string Entry69Description { get; set; }
public DateTime Entry69CreatedAt { get; set; }
public DateTime? Entry69UpdatedAt { get; set; }
public string Entry69CreatedBy { get; set; }
public bool IsEntry69Active { get; set; }
public int Entry69SortOrder { get; set; }


public int Entry82Id { get; set; }
public string Entry82Name { get; set; }
public string Entry82Description { get; set; }
public DateTime Entry82CreatedAt { get; set; }
public DateTime? Entry82UpdatedAt { get; set; }
public string Entry82CreatedBy { get; set; }
public bool IsEntry82Active { get; set; }
public int Entry82SortOrder { get; set; }


public int Field59Id { get; set; }
public string Field59Name { get; set; }
public string Field59Description { get; set; }
public DateTime Field59CreatedAt { get; set; }
public DateTime? Field59UpdatedAt { get; set; }
public string Field59CreatedBy { get; set; }
public bool IsField59Active { get; set; }
public int Field59SortOrder { get; set; }


public int Record23Id { get; set; }
public string Record23Name { get; set; }
public string Record23Description { get; set; }
public DateTime Record23CreatedAt { get; set; }
public DateTime? Record23UpdatedAt { get; set; }
public string Record23CreatedBy { get; set; }
public bool IsRecord23Active { get; set; }
public int Record23SortOrder { get; set; }


public int Field78Id { get; set; }
public string Field78Name { get; set; }
public string Field78Description { get; set; }
public DateTime Field78CreatedAt { get; set; }
public DateTime? Field78UpdatedAt { get; set; }
public string Field78CreatedBy { get; set; }
public bool IsField78Active { get; set; }
public int Field78SortOrder { get; set; }


public int Detail60Id { get; set; }
public string Detail60Name { get; set; }
public string Detail60Description { get; set; }
public DateTime Detail60CreatedAt { get; set; }
public DateTime? Detail60UpdatedAt { get; set; }
public string Detail60CreatedBy { get; set; }
public bool IsDetail60Active { get; set; }
public int Detail60SortOrder { get; set; }


public int Config78Id { get; set; }
public string Config78Name { get; set; }
public string Config78Description { get; set; }
public DateTime Config78CreatedAt { get; set; }
public DateTime? Config78UpdatedAt { get; set; }
public string Config78CreatedBy { get; set; }
public bool IsConfig78Active { get; set; }
public int Config78SortOrder { get; set; }


public int Param22Id { get; set; }
public string Param22Name { get; set; }
public string Param22Description { get; set; }
public DateTime Param22CreatedAt { get; set; }
public DateTime? Param22UpdatedAt { get; set; }
public string Param22CreatedBy { get; set; }
public bool IsParam22Active { get; set; }
public int Param22SortOrder { get; set; }


public int Entry41Id { get; set; }
public string Entry41Name { get; set; }
public string Entry41Description { get; set; }
public DateTime Entry41CreatedAt { get; set; }
public DateTime? Entry41UpdatedAt { get; set; }
public string Entry41CreatedBy { get; set; }
public bool IsEntry41Active { get; set; }
public int Entry41SortOrder { get; set; }


public int Entry79Id { get; set; }
public string Entry79Name { get; set; }
public string Entry79Description { get; set; }
public DateTime Entry79CreatedAt { get; set; }
public DateTime? Entry79UpdatedAt { get; set; }
public string Entry79CreatedBy { get; set; }
public bool IsEntry79Active { get; set; }
public int Entry79SortOrder { get; set; }


public int Field98Id { get; set; }
public string Field98Name { get; set; }
public string Field98Description { get; set; }
public DateTime Field98CreatedAt { get; set; }
public DateTime? Field98UpdatedAt { get; set; }
public string Field98CreatedBy { get; set; }
public bool IsField98Active { get; set; }
public int Field98SortOrder { get; set; }


public int Config34Id { get; set; }
public string Config34Name { get; set; }
public string Config34Description { get; set; }
public DateTime Config34CreatedAt { get; set; }
public DateTime? Config34UpdatedAt { get; set; }
public string Config34CreatedBy { get; set; }
public bool IsConfig34Active { get; set; }
public int Config34SortOrder { get; set; }


public int Config88Id { get; set; }
public string Config88Name { get; set; }
public string Config88Description { get; set; }
public DateTime Config88CreatedAt { get; set; }
public DateTime? Config88UpdatedAt { get; set; }
public string Config88CreatedBy { get; set; }
public bool IsConfig88Active { get; set; }
public int Config88SortOrder { get; set; }


public int Config98Id { get; set; }
public string Config98Name { get; set; }
public string Config98Description { get; set; }
public DateTime Config98CreatedAt { get; set; }
public DateTime? Config98UpdatedAt { get; set; }
public string Config98CreatedBy { get; set; }
public bool IsConfig98Active { get; set; }
public int Config98SortOrder { get; set; }


public int Detail96Id { get; set; }
public string Detail96Name { get; set; }
public string Detail96Description { get; set; }
public DateTime Detail96CreatedAt { get; set; }
public DateTime? Detail96UpdatedAt { get; set; }
public string Detail96CreatedBy { get; set; }
public bool IsDetail96Active { get; set; }
public int Detail96SortOrder { get; set; }


public int Field99Id { get; set; }
public string Field99Name { get; set; }
public string Field99Description { get; set; }
public DateTime Field99CreatedAt { get; set; }
public DateTime? Field99UpdatedAt { get; set; }
public string Field99CreatedBy { get; set; }
public bool IsField99Active { get; set; }
public int Field99SortOrder { get; set; }


public int Field65Id { get; set; }
public string Field65Name { get; set; }
public string Field65Description { get; set; }
public DateTime Field65CreatedAt { get; set; }
public DateTime? Field65UpdatedAt { get; set; }
public string Field65CreatedBy { get; set; }
public bool IsField65Active { get; set; }
public int Field65SortOrder { get; set; }


public int Record15Id { get; set; }
public string Record15Name { get; set; }
public string Record15Description { get; set; }
public DateTime Record15CreatedAt { get; set; }
public DateTime? Record15UpdatedAt { get; set; }
public string Record15CreatedBy { get; set; }
public bool IsRecord15Active { get; set; }
public int Record15SortOrder { get; set; }


public int Record40Id { get; set; }
public string Record40Name { get; set; }
public string Record40Description { get; set; }
public DateTime Record40CreatedAt { get; set; }
public DateTime? Record40UpdatedAt { get; set; }
public string Record40CreatedBy { get; set; }
public bool IsRecord40Active { get; set; }
public int Record40SortOrder { get; set; }


public int Detail29Id { get; set; }
public string Detail29Name { get; set; }
public string Detail29Description { get; set; }
public DateTime Detail29CreatedAt { get; set; }
public DateTime? Detail29UpdatedAt { get; set; }
public string Detail29CreatedBy { get; set; }
public bool IsDetail29Active { get; set; }
public int Detail29SortOrder { get; set; }


public int Item55Id { get; set; }
public string Item55Name { get; set; }
public string Item55Description { get; set; }
public DateTime Item55CreatedAt { get; set; }
public DateTime? Item55UpdatedAt { get; set; }
public string Item55CreatedBy { get; set; }
public bool IsItem55Active { get; set; }
public int Item55SortOrder { get; set; }


public int Config4Id { get; set; }
public string Config4Name { get; set; }
public string Config4Description { get; set; }
public DateTime Config4CreatedAt { get; set; }
public DateTime? Config4UpdatedAt { get; set; }
public string Config4CreatedBy { get; set; }
public bool IsConfig4Active { get; set; }
public int Config4SortOrder { get; set; }


public int Item42Id { get; set; }
public string Item42Name { get; set; }
public string Item42Description { get; set; }
public DateTime Item42CreatedAt { get; set; }
public DateTime? Item42UpdatedAt { get; set; }
public string Item42CreatedBy { get; set; }
public bool IsItem42Active { get; set; }
public int Item42SortOrder { get; set; }


public int Attr62Id { get; set; }
public string Attr62Name { get; set; }
public string Attr62Description { get; set; }
public DateTime Attr62CreatedAt { get; set; }
public DateTime? Attr62UpdatedAt { get; set; }
public string Attr62CreatedBy { get; set; }
public bool IsAttr62Active { get; set; }
public int Attr62SortOrder { get; set; }


public int Record43Id { get; set; }
public string Record43Name { get; set; }
public string Record43Description { get; set; }
public DateTime Record43CreatedAt { get; set; }
public DateTime? Record43UpdatedAt { get; set; }
public string Record43CreatedBy { get; set; }
public bool IsRecord43Active { get; set; }
public int Record43SortOrder { get; set; }


public int Param90Id { get; set; }
public string Param90Name { get; set; }
public string Param90Description { get; set; }
public DateTime Param90CreatedAt { get; set; }
public DateTime? Param90UpdatedAt { get; set; }
public string Param90CreatedBy { get; set; }
public bool IsParam90Active { get; set; }
public int Param90SortOrder { get; set; }


public int Param77Id { get; set; }
public string Param77Name { get; set; }
public string Param77Description { get; set; }
public DateTime Param77CreatedAt { get; set; }
public DateTime? Param77UpdatedAt { get; set; }
public string Param77CreatedBy { get; set; }
public bool IsParam77Active { get; set; }
public int Param77SortOrder { get; set; }


public int Item99Id { get; set; }
public string Item99Name { get; set; }
public string Item99Description { get; set; }
public DateTime Item99CreatedAt { get; set; }
public DateTime? Item99UpdatedAt { get; set; }
public string Item99CreatedBy { get; set; }
public bool IsItem99Active { get; set; }
public int Item99SortOrder { get; set; }


public int Field90Id { get; set; }
public string Field90Name { get; set; }
public string Field90Description { get; set; }
public DateTime Field90CreatedAt { get; set; }
public DateTime? Field90UpdatedAt { get; set; }
public string Field90CreatedBy { get; set; }
public bool IsField90Active { get; set; }
public int Field90SortOrder { get; set; }


public int Entry62Id { get; set; }
public string Entry62Name { get; set; }
public string Entry62Description { get; set; }
public DateTime Entry62CreatedAt { get; set; }
public DateTime? Entry62UpdatedAt { get; set; }
public string Entry62CreatedBy { get; set; }
public bool IsEntry62Active { get; set; }
public int Entry62SortOrder { get; set; }


public int Attr79Id { get; set; }
public string Attr79Name { get; set; }
public string Attr79Description { get; set; }
public DateTime Attr79CreatedAt { get; set; }
public DateTime? Attr79UpdatedAt { get; set; }
public string Attr79CreatedBy { get; set; }
public bool IsAttr79Active { get; set; }
public int Attr79SortOrder { get; set; }


public int Item22Id { get; set; }
public string Item22Name { get; set; }
public string Item22Description { get; set; }
public DateTime Item22CreatedAt { get; set; }
public DateTime? Item22UpdatedAt { get; set; }
public string Item22CreatedBy { get; set; }
public bool IsItem22Active { get; set; }
public int Item22SortOrder { get; set; }


public int Param74Id { get; set; }
public string Param74Name { get; set; }
public string Param74Description { get; set; }
public DateTime Param74CreatedAt { get; set; }
public DateTime? Param74UpdatedAt { get; set; }
public string Param74CreatedBy { get; set; }
public bool IsParam74Active { get; set; }
public int Param74SortOrder { get; set; }


public int Record89Id { get; set; }
public string Record89Name { get; set; }
public string Record89Description { get; set; }
public DateTime Record89CreatedAt { get; set; }
public DateTime? Record89UpdatedAt { get; set; }
public string Record89CreatedBy { get; set; }
public bool IsRecord89Active { get; set; }
public int Record89SortOrder { get; set; }


public int Entry3Id { get; set; }
public string Entry3Name { get; set; }
public string Entry3Description { get; set; }
public DateTime Entry3CreatedAt { get; set; }
public DateTime? Entry3UpdatedAt { get; set; }
public string Entry3CreatedBy { get; set; }
public bool IsEntry3Active { get; set; }
public int Entry3SortOrder { get; set; }


public int Config50Id { get; set; }
public string Config50Name { get; set; }
public string Config50Description { get; set; }
public DateTime Config50CreatedAt { get; set; }
public DateTime? Config50UpdatedAt { get; set; }
public string Config50CreatedBy { get; set; }
public bool IsConfig50Active { get; set; }
public int Config50SortOrder { get; set; }


public int Detail60Id { get; set; }
public string Detail60Name { get; set; }
public string Detail60Description { get; set; }
public DateTime Detail60CreatedAt { get; set; }
public DateTime? Detail60UpdatedAt { get; set; }
public string Detail60CreatedBy { get; set; }
public bool IsDetail60Active { get; set; }
public int Detail60SortOrder { get; set; }


public int Entry15Id { get; set; }
public string Entry15Name { get; set; }
public string Entry15Description { get; set; }
public DateTime Entry15CreatedAt { get; set; }
public DateTime? Entry15UpdatedAt { get; set; }
public string Entry15CreatedBy { get; set; }
public bool IsEntry15Active { get; set; }
public int Entry15SortOrder { get; set; }


public int Field23Id { get; set; }
public string Field23Name { get; set; }
public string Field23Description { get; set; }
public DateTime Field23CreatedAt { get; set; }
public DateTime? Field23UpdatedAt { get; set; }
public string Field23CreatedBy { get; set; }
public bool IsField23Active { get; set; }
public int Field23SortOrder { get; set; }

    }

}