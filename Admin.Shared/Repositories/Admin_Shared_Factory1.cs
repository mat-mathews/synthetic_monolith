using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Shared
{
    public sealed class Admin_Shared_Factory1
    {
        public void Execute()
        {
            // Admin_Shared_Factory1 implementation
        }

/// <summary>
/// Validates the Factory1 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateFactory1(Factory1Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Factory1));
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
/// Processes the Factory1 operation asynchronously.
/// </summary>
public async Task<Factory1Result> ProcessFactory1Async(
    Factory1Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Factory1), request.Id);

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
            return new Factory1Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Factory1));
        return new Factory1Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Factory1));
        return new Factory1Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Factory1 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Factory1Dto>> GetFactory1ListAsync(
    Factory1Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Factory1Entity>().AsQueryable();

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
        .Select(x => new Factory1Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Factory1Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Factory1Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Factory1Service(
    ILogger<Factory1Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Factory1:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Factory1 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Factory1Data> GetCachedFactory1Async(string key)
{
    var cacheKey = $"Factory1_{key}";

    if (_cache.TryGetValue(cacheKey, out Factory1Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromFactory1SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Detail97Id { get; set; }
public string Detail97Name { get; set; }
public string Detail97Description { get; set; }
public DateTime Detail97CreatedAt { get; set; }
public DateTime? Detail97UpdatedAt { get; set; }
public string Detail97CreatedBy { get; set; }
public bool IsDetail97Active { get; set; }
public int Detail97SortOrder { get; set; }


public int Entry53Id { get; set; }
public string Entry53Name { get; set; }
public string Entry53Description { get; set; }
public DateTime Entry53CreatedAt { get; set; }
public DateTime? Entry53UpdatedAt { get; set; }
public string Entry53CreatedBy { get; set; }
public bool IsEntry53Active { get; set; }
public int Entry53SortOrder { get; set; }


public int Attr98Id { get; set; }
public string Attr98Name { get; set; }
public string Attr98Description { get; set; }
public DateTime Attr98CreatedAt { get; set; }
public DateTime? Attr98UpdatedAt { get; set; }
public string Attr98CreatedBy { get; set; }
public bool IsAttr98Active { get; set; }
public int Attr98SortOrder { get; set; }


public int Detail73Id { get; set; }
public string Detail73Name { get; set; }
public string Detail73Description { get; set; }
public DateTime Detail73CreatedAt { get; set; }
public DateTime? Detail73UpdatedAt { get; set; }
public string Detail73CreatedBy { get; set; }
public bool IsDetail73Active { get; set; }
public int Detail73SortOrder { get; set; }


public int Entry82Id { get; set; }
public string Entry82Name { get; set; }
public string Entry82Description { get; set; }
public DateTime Entry82CreatedAt { get; set; }
public DateTime? Entry82UpdatedAt { get; set; }
public string Entry82CreatedBy { get; set; }
public bool IsEntry82Active { get; set; }
public int Entry82SortOrder { get; set; }


public int Item49Id { get; set; }
public string Item49Name { get; set; }
public string Item49Description { get; set; }
public DateTime Item49CreatedAt { get; set; }
public DateTime? Item49UpdatedAt { get; set; }
public string Item49CreatedBy { get; set; }
public bool IsItem49Active { get; set; }
public int Item49SortOrder { get; set; }


public int Item36Id { get; set; }
public string Item36Name { get; set; }
public string Item36Description { get; set; }
public DateTime Item36CreatedAt { get; set; }
public DateTime? Item36UpdatedAt { get; set; }
public string Item36CreatedBy { get; set; }
public bool IsItem36Active { get; set; }
public int Item36SortOrder { get; set; }


public int Entry75Id { get; set; }
public string Entry75Name { get; set; }
public string Entry75Description { get; set; }
public DateTime Entry75CreatedAt { get; set; }
public DateTime? Entry75UpdatedAt { get; set; }
public string Entry75CreatedBy { get; set; }
public bool IsEntry75Active { get; set; }
public int Entry75SortOrder { get; set; }


public int Config19Id { get; set; }
public string Config19Name { get; set; }
public string Config19Description { get; set; }
public DateTime Config19CreatedAt { get; set; }
public DateTime? Config19UpdatedAt { get; set; }
public string Config19CreatedBy { get; set; }
public bool IsConfig19Active { get; set; }
public int Config19SortOrder { get; set; }


public int Entry97Id { get; set; }
public string Entry97Name { get; set; }
public string Entry97Description { get; set; }
public DateTime Entry97CreatedAt { get; set; }
public DateTime? Entry97UpdatedAt { get; set; }
public string Entry97CreatedBy { get; set; }
public bool IsEntry97Active { get; set; }
public int Entry97SortOrder { get; set; }


public int Record12Id { get; set; }
public string Record12Name { get; set; }
public string Record12Description { get; set; }
public DateTime Record12CreatedAt { get; set; }
public DateTime? Record12UpdatedAt { get; set; }
public string Record12CreatedBy { get; set; }
public bool IsRecord12Active { get; set; }
public int Record12SortOrder { get; set; }


public int Entry35Id { get; set; }
public string Entry35Name { get; set; }
public string Entry35Description { get; set; }
public DateTime Entry35CreatedAt { get; set; }
public DateTime? Entry35UpdatedAt { get; set; }
public string Entry35CreatedBy { get; set; }
public bool IsEntry35Active { get; set; }
public int Entry35SortOrder { get; set; }


public int Attr34Id { get; set; }
public string Attr34Name { get; set; }
public string Attr34Description { get; set; }
public DateTime Attr34CreatedAt { get; set; }
public DateTime? Attr34UpdatedAt { get; set; }
public string Attr34CreatedBy { get; set; }
public bool IsAttr34Active { get; set; }
public int Attr34SortOrder { get; set; }


public int Detail83Id { get; set; }
public string Detail83Name { get; set; }
public string Detail83Description { get; set; }
public DateTime Detail83CreatedAt { get; set; }
public DateTime? Detail83UpdatedAt { get; set; }
public string Detail83CreatedBy { get; set; }
public bool IsDetail83Active { get; set; }
public int Detail83SortOrder { get; set; }


public int Param7Id { get; set; }
public string Param7Name { get; set; }
public string Param7Description { get; set; }
public DateTime Param7CreatedAt { get; set; }
public DateTime? Param7UpdatedAt { get; set; }
public string Param7CreatedBy { get; set; }
public bool IsParam7Active { get; set; }
public int Param7SortOrder { get; set; }


public int Field78Id { get; set; }
public string Field78Name { get; set; }
public string Field78Description { get; set; }
public DateTime Field78CreatedAt { get; set; }
public DateTime? Field78UpdatedAt { get; set; }
public string Field78CreatedBy { get; set; }
public bool IsField78Active { get; set; }
public int Field78SortOrder { get; set; }


public int Attr70Id { get; set; }
public string Attr70Name { get; set; }
public string Attr70Description { get; set; }
public DateTime Attr70CreatedAt { get; set; }
public DateTime? Attr70UpdatedAt { get; set; }
public string Attr70CreatedBy { get; set; }
public bool IsAttr70Active { get; set; }
public int Attr70SortOrder { get; set; }


public int Entry8Id { get; set; }
public string Entry8Name { get; set; }
public string Entry8Description { get; set; }
public DateTime Entry8CreatedAt { get; set; }
public DateTime? Entry8UpdatedAt { get; set; }
public string Entry8CreatedBy { get; set; }
public bool IsEntry8Active { get; set; }
public int Entry8SortOrder { get; set; }


public int Detail65Id { get; set; }
public string Detail65Name { get; set; }
public string Detail65Description { get; set; }
public DateTime Detail65CreatedAt { get; set; }
public DateTime? Detail65UpdatedAt { get; set; }
public string Detail65CreatedBy { get; set; }
public bool IsDetail65Active { get; set; }
public int Detail65SortOrder { get; set; }


public int Attr18Id { get; set; }
public string Attr18Name { get; set; }
public string Attr18Description { get; set; }
public DateTime Attr18CreatedAt { get; set; }
public DateTime? Attr18UpdatedAt { get; set; }
public string Attr18CreatedBy { get; set; }
public bool IsAttr18Active { get; set; }
public int Attr18SortOrder { get; set; }


public int Record13Id { get; set; }
public string Record13Name { get; set; }
public string Record13Description { get; set; }
public DateTime Record13CreatedAt { get; set; }
public DateTime? Record13UpdatedAt { get; set; }
public string Record13CreatedBy { get; set; }
public bool IsRecord13Active { get; set; }
public int Record13SortOrder { get; set; }


public int Entry3Id { get; set; }
public string Entry3Name { get; set; }
public string Entry3Description { get; set; }
public DateTime Entry3CreatedAt { get; set; }
public DateTime? Entry3UpdatedAt { get; set; }
public string Entry3CreatedBy { get; set; }
public bool IsEntry3Active { get; set; }
public int Entry3SortOrder { get; set; }


public int Detail66Id { get; set; }
public string Detail66Name { get; set; }
public string Detail66Description { get; set; }
public DateTime Detail66CreatedAt { get; set; }
public DateTime? Detail66UpdatedAt { get; set; }
public string Detail66CreatedBy { get; set; }
public bool IsDetail66Active { get; set; }
public int Detail66SortOrder { get; set; }


public int Entry93Id { get; set; }
public string Entry93Name { get; set; }
public string Entry93Description { get; set; }
public DateTime Entry93CreatedAt { get; set; }
public DateTime? Entry93UpdatedAt { get; set; }
public string Entry93CreatedBy { get; set; }
public bool IsEntry93Active { get; set; }
public int Entry93SortOrder { get; set; }


public int Detail76Id { get; set; }
public string Detail76Name { get; set; }
public string Detail76Description { get; set; }
public DateTime Detail76CreatedAt { get; set; }
public DateTime? Detail76UpdatedAt { get; set; }
public string Detail76CreatedBy { get; set; }
public bool IsDetail76Active { get; set; }
public int Detail76SortOrder { get; set; }


public int Item14Id { get; set; }
public string Item14Name { get; set; }
public string Item14Description { get; set; }
public DateTime Item14CreatedAt { get; set; }
public DateTime? Item14UpdatedAt { get; set; }
public string Item14CreatedBy { get; set; }
public bool IsItem14Active { get; set; }
public int Item14SortOrder { get; set; }


public int Param1Id { get; set; }
public string Param1Name { get; set; }
public string Param1Description { get; set; }
public DateTime Param1CreatedAt { get; set; }
public DateTime? Param1UpdatedAt { get; set; }
public string Param1CreatedBy { get; set; }
public bool IsParam1Active { get; set; }
public int Param1SortOrder { get; set; }


public int Param80Id { get; set; }
public string Param80Name { get; set; }
public string Param80Description { get; set; }
public DateTime Param80CreatedAt { get; set; }
public DateTime? Param80UpdatedAt { get; set; }
public string Param80CreatedBy { get; set; }
public bool IsParam80Active { get; set; }
public int Param80SortOrder { get; set; }


public int Param39Id { get; set; }
public string Param39Name { get; set; }
public string Param39Description { get; set; }
public DateTime Param39CreatedAt { get; set; }
public DateTime? Param39UpdatedAt { get; set; }
public string Param39CreatedBy { get; set; }
public bool IsParam39Active { get; set; }
public int Param39SortOrder { get; set; }


public int Attr55Id { get; set; }
public string Attr55Name { get; set; }
public string Attr55Description { get; set; }
public DateTime Attr55CreatedAt { get; set; }
public DateTime? Attr55UpdatedAt { get; set; }
public string Attr55CreatedBy { get; set; }
public bool IsAttr55Active { get; set; }
public int Attr55SortOrder { get; set; }


public int Record56Id { get; set; }
public string Record56Name { get; set; }
public string Record56Description { get; set; }
public DateTime Record56CreatedAt { get; set; }
public DateTime? Record56UpdatedAt { get; set; }
public string Record56CreatedBy { get; set; }
public bool IsRecord56Active { get; set; }
public int Record56SortOrder { get; set; }


public int Item93Id { get; set; }
public string Item93Name { get; set; }
public string Item93Description { get; set; }
public DateTime Item93CreatedAt { get; set; }
public DateTime? Item93UpdatedAt { get; set; }
public string Item93CreatedBy { get; set; }
public bool IsItem93Active { get; set; }
public int Item93SortOrder { get; set; }


public int Field66Id { get; set; }
public string Field66Name { get; set; }
public string Field66Description { get; set; }
public DateTime Field66CreatedAt { get; set; }
public DateTime? Field66UpdatedAt { get; set; }
public string Field66CreatedBy { get; set; }
public bool IsField66Active { get; set; }
public int Field66SortOrder { get; set; }


public int Item31Id { get; set; }
public string Item31Name { get; set; }
public string Item31Description { get; set; }
public DateTime Item31CreatedAt { get; set; }
public DateTime? Item31UpdatedAt { get; set; }
public string Item31CreatedBy { get; set; }
public bool IsItem31Active { get; set; }
public int Item31SortOrder { get; set; }


public int Item40Id { get; set; }
public string Item40Name { get; set; }
public string Item40Description { get; set; }
public DateTime Item40CreatedAt { get; set; }
public DateTime? Item40UpdatedAt { get; set; }
public string Item40CreatedBy { get; set; }
public bool IsItem40Active { get; set; }
public int Item40SortOrder { get; set; }


public int Item1Id { get; set; }
public string Item1Name { get; set; }
public string Item1Description { get; set; }
public DateTime Item1CreatedAt { get; set; }
public DateTime? Item1UpdatedAt { get; set; }
public string Item1CreatedBy { get; set; }
public bool IsItem1Active { get; set; }
public int Item1SortOrder { get; set; }


public int Param88Id { get; set; }
public string Param88Name { get; set; }
public string Param88Description { get; set; }
public DateTime Param88CreatedAt { get; set; }
public DateTime? Param88UpdatedAt { get; set; }
public string Param88CreatedBy { get; set; }
public bool IsParam88Active { get; set; }
public int Param88SortOrder { get; set; }


public int Config54Id { get; set; }
public string Config54Name { get; set; }
public string Config54Description { get; set; }
public DateTime Config54CreatedAt { get; set; }
public DateTime? Config54UpdatedAt { get; set; }
public string Config54CreatedBy { get; set; }
public bool IsConfig54Active { get; set; }
public int Config54SortOrder { get; set; }


public int Item11Id { get; set; }
public string Item11Name { get; set; }
public string Item11Description { get; set; }
public DateTime Item11CreatedAt { get; set; }
public DateTime? Item11UpdatedAt { get; set; }
public string Item11CreatedBy { get; set; }
public bool IsItem11Active { get; set; }
public int Item11SortOrder { get; set; }


public int Detail16Id { get; set; }
public string Detail16Name { get; set; }
public string Detail16Description { get; set; }
public DateTime Detail16CreatedAt { get; set; }
public DateTime? Detail16UpdatedAt { get; set; }
public string Detail16CreatedBy { get; set; }
public bool IsDetail16Active { get; set; }
public int Detail16SortOrder { get; set; }


public int Config28Id { get; set; }
public string Config28Name { get; set; }
public string Config28Description { get; set; }
public DateTime Config28CreatedAt { get; set; }
public DateTime? Config28UpdatedAt { get; set; }
public string Config28CreatedBy { get; set; }
public bool IsConfig28Active { get; set; }
public int Config28SortOrder { get; set; }


public int Detail54Id { get; set; }
public string Detail54Name { get; set; }
public string Detail54Description { get; set; }
public DateTime Detail54CreatedAt { get; set; }
public DateTime? Detail54UpdatedAt { get; set; }
public string Detail54CreatedBy { get; set; }
public bool IsDetail54Active { get; set; }
public int Detail54SortOrder { get; set; }


public int Item46Id { get; set; }
public string Item46Name { get; set; }
public string Item46Description { get; set; }
public DateTime Item46CreatedAt { get; set; }
public DateTime? Item46UpdatedAt { get; set; }
public string Item46CreatedBy { get; set; }
public bool IsItem46Active { get; set; }
public int Item46SortOrder { get; set; }


public int Attr34Id { get; set; }
public string Attr34Name { get; set; }
public string Attr34Description { get; set; }
public DateTime Attr34CreatedAt { get; set; }
public DateTime? Attr34UpdatedAt { get; set; }
public string Attr34CreatedBy { get; set; }
public bool IsAttr34Active { get; set; }
public int Attr34SortOrder { get; set; }


public int Detail24Id { get; set; }
public string Detail24Name { get; set; }
public string Detail24Description { get; set; }
public DateTime Detail24CreatedAt { get; set; }
public DateTime? Detail24UpdatedAt { get; set; }
public string Detail24CreatedBy { get; set; }
public bool IsDetail24Active { get; set; }
public int Detail24SortOrder { get; set; }


public int Record95Id { get; set; }
public string Record95Name { get; set; }
public string Record95Description { get; set; }
public DateTime Record95CreatedAt { get; set; }
public DateTime? Record95UpdatedAt { get; set; }
public string Record95CreatedBy { get; set; }
public bool IsRecord95Active { get; set; }
public int Record95SortOrder { get; set; }


public int Record16Id { get; set; }
public string Record16Name { get; set; }
public string Record16Description { get; set; }
public DateTime Record16CreatedAt { get; set; }
public DateTime? Record16UpdatedAt { get; set; }
public string Record16CreatedBy { get; set; }
public bool IsRecord16Active { get; set; }
public int Record16SortOrder { get; set; }


public int Param35Id { get; set; }
public string Param35Name { get; set; }
public string Param35Description { get; set; }
public DateTime Param35CreatedAt { get; set; }
public DateTime? Param35UpdatedAt { get; set; }
public string Param35CreatedBy { get; set; }
public bool IsParam35Active { get; set; }
public int Param35SortOrder { get; set; }


public int Param80Id { get; set; }
public string Param80Name { get; set; }
public string Param80Description { get; set; }
public DateTime Param80CreatedAt { get; set; }
public DateTime? Param80UpdatedAt { get; set; }
public string Param80CreatedBy { get; set; }
public bool IsParam80Active { get; set; }
public int Param80SortOrder { get; set; }


public int Entry74Id { get; set; }
public string Entry74Name { get; set; }
public string Entry74Description { get; set; }
public DateTime Entry74CreatedAt { get; set; }
public DateTime? Entry74UpdatedAt { get; set; }
public string Entry74CreatedBy { get; set; }
public bool IsEntry74Active { get; set; }
public int Entry74SortOrder { get; set; }


public int Record98Id { get; set; }
public string Record98Name { get; set; }
public string Record98Description { get; set; }
public DateTime Record98CreatedAt { get; set; }
public DateTime? Record98UpdatedAt { get; set; }
public string Record98CreatedBy { get; set; }
public bool IsRecord98Active { get; set; }
public int Record98SortOrder { get; set; }


public int Attr77Id { get; set; }
public string Attr77Name { get; set; }
public string Attr77Description { get; set; }
public DateTime Attr77CreatedAt { get; set; }
public DateTime? Attr77UpdatedAt { get; set; }
public string Attr77CreatedBy { get; set; }
public bool IsAttr77Active { get; set; }
public int Attr77SortOrder { get; set; }


public int Record77Id { get; set; }
public string Record77Name { get; set; }
public string Record77Description { get; set; }
public DateTime Record77CreatedAt { get; set; }
public DateTime? Record77UpdatedAt { get; set; }
public string Record77CreatedBy { get; set; }
public bool IsRecord77Active { get; set; }
public int Record77SortOrder { get; set; }


public int Field80Id { get; set; }
public string Field80Name { get; set; }
public string Field80Description { get; set; }
public DateTime Field80CreatedAt { get; set; }
public DateTime? Field80UpdatedAt { get; set; }
public string Field80CreatedBy { get; set; }
public bool IsField80Active { get; set; }
public int Field80SortOrder { get; set; }


public int Item78Id { get; set; }
public string Item78Name { get; set; }
public string Item78Description { get; set; }
public DateTime Item78CreatedAt { get; set; }
public DateTime? Item78UpdatedAt { get; set; }
public string Item78CreatedBy { get; set; }
public bool IsItem78Active { get; set; }
public int Item78SortOrder { get; set; }


public int Record31Id { get; set; }
public string Record31Name { get; set; }
public string Record31Description { get; set; }
public DateTime Record31CreatedAt { get; set; }
public DateTime? Record31UpdatedAt { get; set; }
public string Record31CreatedBy { get; set; }
public bool IsRecord31Active { get; set; }
public int Record31SortOrder { get; set; }

    }

}