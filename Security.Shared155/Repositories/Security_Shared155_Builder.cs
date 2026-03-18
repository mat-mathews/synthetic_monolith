using Admin.Service339;
using Admin.Service456;
using Admin.Web;
using BatchJobs.Processors;
using Common.Events280;
using Export.Core168;
using Export.Validators152;
using GalaxyWorks.Contracts94;
using GalaxyWorks.Events256;
using Imaging.Shared115;
using Import.Client356;
using Integration.Service107;
using Logging.Shared315;
using Notifications.Tests;
using Portal.Mappers233;
using Portal.Web494;
using Reporting.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Shared155
{
    internal class Security_Shared155_Builder
    {
        public void Execute()
        {
            // Security_Shared155_Builder implementation
        }

/// <summary>
/// Validates the Builder before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateBuilder(BuilderRequest input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Builder));
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
/// Processes the Builder operation asynchronously.
/// </summary>
public async Task<BuilderResult> ProcessBuilderAsync(
    BuilderRequest request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Builder), request.Id);

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
            return new BuilderResult { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Builder));
        return new BuilderResult { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Builder));
        return new BuilderResult { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Builder entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<BuilderDto>> GetBuilderListAsync(
    BuilderFilter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<BuilderEntity>().AsQueryable();

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
        .Select(x => new BuilderDto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<BuilderDto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<BuilderService> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public BuilderService(
    ILogger<BuilderService> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Builder:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Builder instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<BuilderData> GetCachedBuilderAsync(string key)
{
    var cacheKey = $"Builder_{key}";

    if (_cache.TryGetValue(cacheKey, out BuilderData cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromBuilderSourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Field24Id { get; set; }
public string Field24Name { get; set; }
public string Field24Description { get; set; }
public DateTime Field24CreatedAt { get; set; }
public DateTime? Field24UpdatedAt { get; set; }
public string Field24CreatedBy { get; set; }
public bool IsField24Active { get; set; }
public int Field24SortOrder { get; set; }


public int Param80Id { get; set; }
public string Param80Name { get; set; }
public string Param80Description { get; set; }
public DateTime Param80CreatedAt { get; set; }
public DateTime? Param80UpdatedAt { get; set; }
public string Param80CreatedBy { get; set; }
public bool IsParam80Active { get; set; }
public int Param80SortOrder { get; set; }


public int Config86Id { get; set; }
public string Config86Name { get; set; }
public string Config86Description { get; set; }
public DateTime Config86CreatedAt { get; set; }
public DateTime? Config86UpdatedAt { get; set; }
public string Config86CreatedBy { get; set; }
public bool IsConfig86Active { get; set; }
public int Config86SortOrder { get; set; }


public int Item71Id { get; set; }
public string Item71Name { get; set; }
public string Item71Description { get; set; }
public DateTime Item71CreatedAt { get; set; }
public DateTime? Item71UpdatedAt { get; set; }
public string Item71CreatedBy { get; set; }
public bool IsItem71Active { get; set; }
public int Item71SortOrder { get; set; }


public int Entry64Id { get; set; }
public string Entry64Name { get; set; }
public string Entry64Description { get; set; }
public DateTime Entry64CreatedAt { get; set; }
public DateTime? Entry64UpdatedAt { get; set; }
public string Entry64CreatedBy { get; set; }
public bool IsEntry64Active { get; set; }
public int Entry64SortOrder { get; set; }


public int Param78Id { get; set; }
public string Param78Name { get; set; }
public string Param78Description { get; set; }
public DateTime Param78CreatedAt { get; set; }
public DateTime? Param78UpdatedAt { get; set; }
public string Param78CreatedBy { get; set; }
public bool IsParam78Active { get; set; }
public int Param78SortOrder { get; set; }


public int Attr79Id { get; set; }
public string Attr79Name { get; set; }
public string Attr79Description { get; set; }
public DateTime Attr79CreatedAt { get; set; }
public DateTime? Attr79UpdatedAt { get; set; }
public string Attr79CreatedBy { get; set; }
public bool IsAttr79Active { get; set; }
public int Attr79SortOrder { get; set; }


public int Param48Id { get; set; }
public string Param48Name { get; set; }
public string Param48Description { get; set; }
public DateTime Param48CreatedAt { get; set; }
public DateTime? Param48UpdatedAt { get; set; }
public string Param48CreatedBy { get; set; }
public bool IsParam48Active { get; set; }
public int Param48SortOrder { get; set; }


public int Record31Id { get; set; }
public string Record31Name { get; set; }
public string Record31Description { get; set; }
public DateTime Record31CreatedAt { get; set; }
public DateTime? Record31UpdatedAt { get; set; }
public string Record31CreatedBy { get; set; }
public bool IsRecord31Active { get; set; }
public int Record31SortOrder { get; set; }


public int Item14Id { get; set; }
public string Item14Name { get; set; }
public string Item14Description { get; set; }
public DateTime Item14CreatedAt { get; set; }
public DateTime? Item14UpdatedAt { get; set; }
public string Item14CreatedBy { get; set; }
public bool IsItem14Active { get; set; }
public int Item14SortOrder { get; set; }


public int Param5Id { get; set; }
public string Param5Name { get; set; }
public string Param5Description { get; set; }
public DateTime Param5CreatedAt { get; set; }
public DateTime? Param5UpdatedAt { get; set; }
public string Param5CreatedBy { get; set; }
public bool IsParam5Active { get; set; }
public int Param5SortOrder { get; set; }


public int Record96Id { get; set; }
public string Record96Name { get; set; }
public string Record96Description { get; set; }
public DateTime Record96CreatedAt { get; set; }
public DateTime? Record96UpdatedAt { get; set; }
public string Record96CreatedBy { get; set; }
public bool IsRecord96Active { get; set; }
public int Record96SortOrder { get; set; }


public int Record93Id { get; set; }
public string Record93Name { get; set; }
public string Record93Description { get; set; }
public DateTime Record93CreatedAt { get; set; }
public DateTime? Record93UpdatedAt { get; set; }
public string Record93CreatedBy { get; set; }
public bool IsRecord93Active { get; set; }
public int Record93SortOrder { get; set; }


public int Record44Id { get; set; }
public string Record44Name { get; set; }
public string Record44Description { get; set; }
public DateTime Record44CreatedAt { get; set; }
public DateTime? Record44UpdatedAt { get; set; }
public string Record44CreatedBy { get; set; }
public bool IsRecord44Active { get; set; }
public int Record44SortOrder { get; set; }


public int Config86Id { get; set; }
public string Config86Name { get; set; }
public string Config86Description { get; set; }
public DateTime Config86CreatedAt { get; set; }
public DateTime? Config86UpdatedAt { get; set; }
public string Config86CreatedBy { get; set; }
public bool IsConfig86Active { get; set; }
public int Config86SortOrder { get; set; }


public int Param18Id { get; set; }
public string Param18Name { get; set; }
public string Param18Description { get; set; }
public DateTime Param18CreatedAt { get; set; }
public DateTime? Param18UpdatedAt { get; set; }
public string Param18CreatedBy { get; set; }
public bool IsParam18Active { get; set; }
public int Param18SortOrder { get; set; }


public int Detail53Id { get; set; }
public string Detail53Name { get; set; }
public string Detail53Description { get; set; }
public DateTime Detail53CreatedAt { get; set; }
public DateTime? Detail53UpdatedAt { get; set; }
public string Detail53CreatedBy { get; set; }
public bool IsDetail53Active { get; set; }
public int Detail53SortOrder { get; set; }


public int Config71Id { get; set; }
public string Config71Name { get; set; }
public string Config71Description { get; set; }
public DateTime Config71CreatedAt { get; set; }
public DateTime? Config71UpdatedAt { get; set; }
public string Config71CreatedBy { get; set; }
public bool IsConfig71Active { get; set; }
public int Config71SortOrder { get; set; }


public int Attr30Id { get; set; }
public string Attr30Name { get; set; }
public string Attr30Description { get; set; }
public DateTime Attr30CreatedAt { get; set; }
public DateTime? Attr30UpdatedAt { get; set; }
public string Attr30CreatedBy { get; set; }
public bool IsAttr30Active { get; set; }
public int Attr30SortOrder { get; set; }


public int Item20Id { get; set; }
public string Item20Name { get; set; }
public string Item20Description { get; set; }
public DateTime Item20CreatedAt { get; set; }
public DateTime? Item20UpdatedAt { get; set; }
public string Item20CreatedBy { get; set; }
public bool IsItem20Active { get; set; }
public int Item20SortOrder { get; set; }


public int Entry19Id { get; set; }
public string Entry19Name { get; set; }
public string Entry19Description { get; set; }
public DateTime Entry19CreatedAt { get; set; }
public DateTime? Entry19UpdatedAt { get; set; }
public string Entry19CreatedBy { get; set; }
public bool IsEntry19Active { get; set; }
public int Entry19SortOrder { get; set; }


public int Item53Id { get; set; }
public string Item53Name { get; set; }
public string Item53Description { get; set; }
public DateTime Item53CreatedAt { get; set; }
public DateTime? Item53UpdatedAt { get; set; }
public string Item53CreatedBy { get; set; }
public bool IsItem53Active { get; set; }
public int Item53SortOrder { get; set; }


public int Config87Id { get; set; }
public string Config87Name { get; set; }
public string Config87Description { get; set; }
public DateTime Config87CreatedAt { get; set; }
public DateTime? Config87UpdatedAt { get; set; }
public string Config87CreatedBy { get; set; }
public bool IsConfig87Active { get; set; }
public int Config87SortOrder { get; set; }


public int Item75Id { get; set; }
public string Item75Name { get; set; }
public string Item75Description { get; set; }
public DateTime Item75CreatedAt { get; set; }
public DateTime? Item75UpdatedAt { get; set; }
public string Item75CreatedBy { get; set; }
public bool IsItem75Active { get; set; }
public int Item75SortOrder { get; set; }


public int Detail8Id { get; set; }
public string Detail8Name { get; set; }
public string Detail8Description { get; set; }
public DateTime Detail8CreatedAt { get; set; }
public DateTime? Detail8UpdatedAt { get; set; }
public string Detail8CreatedBy { get; set; }
public bool IsDetail8Active { get; set; }
public int Detail8SortOrder { get; set; }


public int Field5Id { get; set; }
public string Field5Name { get; set; }
public string Field5Description { get; set; }
public DateTime Field5CreatedAt { get; set; }
public DateTime? Field5UpdatedAt { get; set; }
public string Field5CreatedBy { get; set; }
public bool IsField5Active { get; set; }
public int Field5SortOrder { get; set; }


public int Entry89Id { get; set; }
public string Entry89Name { get; set; }
public string Entry89Description { get; set; }
public DateTime Entry89CreatedAt { get; set; }
public DateTime? Entry89UpdatedAt { get; set; }
public string Entry89CreatedBy { get; set; }
public bool IsEntry89Active { get; set; }
public int Entry89SortOrder { get; set; }


public int Item5Id { get; set; }
public string Item5Name { get; set; }
public string Item5Description { get; set; }
public DateTime Item5CreatedAt { get; set; }
public DateTime? Item5UpdatedAt { get; set; }
public string Item5CreatedBy { get; set; }
public bool IsItem5Active { get; set; }
public int Item5SortOrder { get; set; }


public int Config9Id { get; set; }
public string Config9Name { get; set; }
public string Config9Description { get; set; }
public DateTime Config9CreatedAt { get; set; }
public DateTime? Config9UpdatedAt { get; set; }
public string Config9CreatedBy { get; set; }
public bool IsConfig9Active { get; set; }
public int Config9SortOrder { get; set; }


public int Config30Id { get; set; }
public string Config30Name { get; set; }
public string Config30Description { get; set; }
public DateTime Config30CreatedAt { get; set; }
public DateTime? Config30UpdatedAt { get; set; }
public string Config30CreatedBy { get; set; }
public bool IsConfig30Active { get; set; }
public int Config30SortOrder { get; set; }


public int Item67Id { get; set; }
public string Item67Name { get; set; }
public string Item67Description { get; set; }
public DateTime Item67CreatedAt { get; set; }
public DateTime? Item67UpdatedAt { get; set; }
public string Item67CreatedBy { get; set; }
public bool IsItem67Active { get; set; }
public int Item67SortOrder { get; set; }


public int Record86Id { get; set; }
public string Record86Name { get; set; }
public string Record86Description { get; set; }
public DateTime Record86CreatedAt { get; set; }
public DateTime? Record86UpdatedAt { get; set; }
public string Record86CreatedBy { get; set; }
public bool IsRecord86Active { get; set; }
public int Record86SortOrder { get; set; }


public int Config78Id { get; set; }
public string Config78Name { get; set; }
public string Config78Description { get; set; }
public DateTime Config78CreatedAt { get; set; }
public DateTime? Config78UpdatedAt { get; set; }
public string Config78CreatedBy { get; set; }
public bool IsConfig78Active { get; set; }
public int Config78SortOrder { get; set; }


public int Entry35Id { get; set; }
public string Entry35Name { get; set; }
public string Entry35Description { get; set; }
public DateTime Entry35CreatedAt { get; set; }
public DateTime? Entry35UpdatedAt { get; set; }
public string Entry35CreatedBy { get; set; }
public bool IsEntry35Active { get; set; }
public int Entry35SortOrder { get; set; }


public int Config80Id { get; set; }
public string Config80Name { get; set; }
public string Config80Description { get; set; }
public DateTime Config80CreatedAt { get; set; }
public DateTime? Config80UpdatedAt { get; set; }
public string Config80CreatedBy { get; set; }
public bool IsConfig80Active { get; set; }
public int Config80SortOrder { get; set; }


public int Detail66Id { get; set; }
public string Detail66Name { get; set; }
public string Detail66Description { get; set; }
public DateTime Detail66CreatedAt { get; set; }
public DateTime? Detail66UpdatedAt { get; set; }
public string Detail66CreatedBy { get; set; }
public bool IsDetail66Active { get; set; }
public int Detail66SortOrder { get; set; }


public int Item17Id { get; set; }
public string Item17Name { get; set; }
public string Item17Description { get; set; }
public DateTime Item17CreatedAt { get; set; }
public DateTime? Item17UpdatedAt { get; set; }
public string Item17CreatedBy { get; set; }
public bool IsItem17Active { get; set; }
public int Item17SortOrder { get; set; }


public int Config75Id { get; set; }
public string Config75Name { get; set; }
public string Config75Description { get; set; }
public DateTime Config75CreatedAt { get; set; }
public DateTime? Config75UpdatedAt { get; set; }
public string Config75CreatedBy { get; set; }
public bool IsConfig75Active { get; set; }
public int Config75SortOrder { get; set; }


public int Param83Id { get; set; }
public string Param83Name { get; set; }
public string Param83Description { get; set; }
public DateTime Param83CreatedAt { get; set; }
public DateTime? Param83UpdatedAt { get; set; }
public string Param83CreatedBy { get; set; }
public bool IsParam83Active { get; set; }
public int Param83SortOrder { get; set; }


public int Param54Id { get; set; }
public string Param54Name { get; set; }
public string Param54Description { get; set; }
public DateTime Param54CreatedAt { get; set; }
public DateTime? Param54UpdatedAt { get; set; }
public string Param54CreatedBy { get; set; }
public bool IsParam54Active { get; set; }
public int Param54SortOrder { get; set; }


public int Attr29Id { get; set; }
public string Attr29Name { get; set; }
public string Attr29Description { get; set; }
public DateTime Attr29CreatedAt { get; set; }
public DateTime? Attr29UpdatedAt { get; set; }
public string Attr29CreatedBy { get; set; }
public bool IsAttr29Active { get; set; }
public int Attr29SortOrder { get; set; }


public int Entry75Id { get; set; }
public string Entry75Name { get; set; }
public string Entry75Description { get; set; }
public DateTime Entry75CreatedAt { get; set; }
public DateTime? Entry75UpdatedAt { get; set; }
public string Entry75CreatedBy { get; set; }
public bool IsEntry75Active { get; set; }
public int Entry75SortOrder { get; set; }


public int Record45Id { get; set; }
public string Record45Name { get; set; }
public string Record45Description { get; set; }
public DateTime Record45CreatedAt { get; set; }
public DateTime? Record45UpdatedAt { get; set; }
public string Record45CreatedBy { get; set; }
public bool IsRecord45Active { get; set; }
public int Record45SortOrder { get; set; }


public int Param44Id { get; set; }
public string Param44Name { get; set; }
public string Param44Description { get; set; }
public DateTime Param44CreatedAt { get; set; }
public DateTime? Param44UpdatedAt { get; set; }
public string Param44CreatedBy { get; set; }
public bool IsParam44Active { get; set; }
public int Param44SortOrder { get; set; }


public int Record54Id { get; set; }
public string Record54Name { get; set; }
public string Record54Description { get; set; }
public DateTime Record54CreatedAt { get; set; }
public DateTime? Record54UpdatedAt { get; set; }
public string Record54CreatedBy { get; set; }
public bool IsRecord54Active { get; set; }
public int Record54SortOrder { get; set; }


public int Field63Id { get; set; }
public string Field63Name { get; set; }
public string Field63Description { get; set; }
public DateTime Field63CreatedAt { get; set; }
public DateTime? Field63UpdatedAt { get; set; }
public string Field63CreatedBy { get; set; }
public bool IsField63Active { get; set; }
public int Field63SortOrder { get; set; }


public int Record36Id { get; set; }
public string Record36Name { get; set; }
public string Record36Description { get; set; }
public DateTime Record36CreatedAt { get; set; }
public DateTime? Record36UpdatedAt { get; set; }
public string Record36CreatedBy { get; set; }
public bool IsRecord36Active { get; set; }
public int Record36SortOrder { get; set; }


public int Attr12Id { get; set; }
public string Attr12Name { get; set; }
public string Attr12Description { get; set; }
public DateTime Attr12CreatedAt { get; set; }
public DateTime? Attr12UpdatedAt { get; set; }
public string Attr12CreatedBy { get; set; }
public bool IsAttr12Active { get; set; }
public int Attr12SortOrder { get; set; }


public int Entry95Id { get; set; }
public string Entry95Name { get; set; }
public string Entry95Description { get; set; }
public DateTime Entry95CreatedAt { get; set; }
public DateTime? Entry95UpdatedAt { get; set; }
public string Entry95CreatedBy { get; set; }
public bool IsEntry95Active { get; set; }
public int Entry95SortOrder { get; set; }


public int Attr38Id { get; set; }
public string Attr38Name { get; set; }
public string Attr38Description { get; set; }
public DateTime Attr38CreatedAt { get; set; }
public DateTime? Attr38UpdatedAt { get; set; }
public string Attr38CreatedBy { get; set; }
public bool IsAttr38Active { get; set; }
public int Attr38SortOrder { get; set; }


public int Record12Id { get; set; }
public string Record12Name { get; set; }
public string Record12Description { get; set; }
public DateTime Record12CreatedAt { get; set; }
public DateTime? Record12UpdatedAt { get; set; }
public string Record12CreatedBy { get; set; }
public bool IsRecord12Active { get; set; }
public int Record12SortOrder { get; set; }


public int Field99Id { get; set; }
public string Field99Name { get; set; }
public string Field99Description { get; set; }
public DateTime Field99CreatedAt { get; set; }
public DateTime? Field99UpdatedAt { get; set; }
public string Field99CreatedBy { get; set; }
public bool IsField99Active { get; set; }
public int Field99SortOrder { get; set; }


public int Field14Id { get; set; }
public string Field14Name { get; set; }
public string Field14Description { get; set; }
public DateTime Field14CreatedAt { get; set; }
public DateTime? Field14UpdatedAt { get; set; }
public string Field14CreatedBy { get; set; }
public bool IsField14Active { get; set; }
public int Field14SortOrder { get; set; }


public int Item6Id { get; set; }
public string Item6Name { get; set; }
public string Item6Description { get; set; }
public DateTime Item6CreatedAt { get; set; }
public DateTime? Item6UpdatedAt { get; set; }
public string Item6CreatedBy { get; set; }
public bool IsItem6Active { get; set; }
public int Item6SortOrder { get; set; }

    }

}