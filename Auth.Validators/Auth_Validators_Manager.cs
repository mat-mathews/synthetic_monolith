using Admin.Validators37;
using Common.Core169;
using Common.Data21;
using Common.Mappers190;
using Common.Shared;
using DataAccess.Service464;
using GalaxyWorks.Events;
using GalaxyWorks.Handlers84;
using Imaging.Validators;
using Import.Contracts180;
using Logging.Events289;
using Notifications.Shared380;
using Portal.Tests323;
using Reporting.Client146;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Events;
using Workflow.Mappers370;

namespace Auth.Validators
{
    internal class Auth_Validators_Manager
    {
        public void Execute()
        {
            // Auth_Validators_Manager implementation
        }

/// <summary>
/// Validates the Manager before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateManager(ManagerRequest input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Manager));
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
/// Processes the Manager operation asynchronously.
/// </summary>
public async Task<ManagerResult> ProcessManagerAsync(
    ManagerRequest request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Manager), request.Id);

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
            return new ManagerResult { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Manager));
        return new ManagerResult { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Manager));
        return new ManagerResult { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Manager entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<ManagerDto>> GetManagerListAsync(
    ManagerFilter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<ManagerEntity>().AsQueryable();

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
        .Select(x => new ManagerDto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<ManagerDto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<ManagerService> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public ManagerService(
    ILogger<ManagerService> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Manager:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Manager instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<ManagerData> GetCachedManagerAsync(string key)
{
    var cacheKey = $"Manager_{key}";

    if (_cache.TryGetValue(cacheKey, out ManagerData cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromManagerSourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Record18Id { get; set; }
public string Record18Name { get; set; }
public string Record18Description { get; set; }
public DateTime Record18CreatedAt { get; set; }
public DateTime? Record18UpdatedAt { get; set; }
public string Record18CreatedBy { get; set; }
public bool IsRecord18Active { get; set; }
public int Record18SortOrder { get; set; }


public int Param56Id { get; set; }
public string Param56Name { get; set; }
public string Param56Description { get; set; }
public DateTime Param56CreatedAt { get; set; }
public DateTime? Param56UpdatedAt { get; set; }
public string Param56CreatedBy { get; set; }
public bool IsParam56Active { get; set; }
public int Param56SortOrder { get; set; }


public int Field50Id { get; set; }
public string Field50Name { get; set; }
public string Field50Description { get; set; }
public DateTime Field50CreatedAt { get; set; }
public DateTime? Field50UpdatedAt { get; set; }
public string Field50CreatedBy { get; set; }
public bool IsField50Active { get; set; }
public int Field50SortOrder { get; set; }


public int Record92Id { get; set; }
public string Record92Name { get; set; }
public string Record92Description { get; set; }
public DateTime Record92CreatedAt { get; set; }
public DateTime? Record92UpdatedAt { get; set; }
public string Record92CreatedBy { get; set; }
public bool IsRecord92Active { get; set; }
public int Record92SortOrder { get; set; }


public int Config51Id { get; set; }
public string Config51Name { get; set; }
public string Config51Description { get; set; }
public DateTime Config51CreatedAt { get; set; }
public DateTime? Config51UpdatedAt { get; set; }
public string Config51CreatedBy { get; set; }
public bool IsConfig51Active { get; set; }
public int Config51SortOrder { get; set; }


public int Param51Id { get; set; }
public string Param51Name { get; set; }
public string Param51Description { get; set; }
public DateTime Param51CreatedAt { get; set; }
public DateTime? Param51UpdatedAt { get; set; }
public string Param51CreatedBy { get; set; }
public bool IsParam51Active { get; set; }
public int Param51SortOrder { get; set; }


public int Record33Id { get; set; }
public string Record33Name { get; set; }
public string Record33Description { get; set; }
public DateTime Record33CreatedAt { get; set; }
public DateTime? Record33UpdatedAt { get; set; }
public string Record33CreatedBy { get; set; }
public bool IsRecord33Active { get; set; }
public int Record33SortOrder { get; set; }


public int Entry87Id { get; set; }
public string Entry87Name { get; set; }
public string Entry87Description { get; set; }
public DateTime Entry87CreatedAt { get; set; }
public DateTime? Entry87UpdatedAt { get; set; }
public string Entry87CreatedBy { get; set; }
public bool IsEntry87Active { get; set; }
public int Entry87SortOrder { get; set; }


public int Field54Id { get; set; }
public string Field54Name { get; set; }
public string Field54Description { get; set; }
public DateTime Field54CreatedAt { get; set; }
public DateTime? Field54UpdatedAt { get; set; }
public string Field54CreatedBy { get; set; }
public bool IsField54Active { get; set; }
public int Field54SortOrder { get; set; }


public int Item41Id { get; set; }
public string Item41Name { get; set; }
public string Item41Description { get; set; }
public DateTime Item41CreatedAt { get; set; }
public DateTime? Item41UpdatedAt { get; set; }
public string Item41CreatedBy { get; set; }
public bool IsItem41Active { get; set; }
public int Item41SortOrder { get; set; }


public int Detail25Id { get; set; }
public string Detail25Name { get; set; }
public string Detail25Description { get; set; }
public DateTime Detail25CreatedAt { get; set; }
public DateTime? Detail25UpdatedAt { get; set; }
public string Detail25CreatedBy { get; set; }
public bool IsDetail25Active { get; set; }
public int Detail25SortOrder { get; set; }


public int Entry93Id { get; set; }
public string Entry93Name { get; set; }
public string Entry93Description { get; set; }
public DateTime Entry93CreatedAt { get; set; }
public DateTime? Entry93UpdatedAt { get; set; }
public string Entry93CreatedBy { get; set; }
public bool IsEntry93Active { get; set; }
public int Entry93SortOrder { get; set; }


public int Item27Id { get; set; }
public string Item27Name { get; set; }
public string Item27Description { get; set; }
public DateTime Item27CreatedAt { get; set; }
public DateTime? Item27UpdatedAt { get; set; }
public string Item27CreatedBy { get; set; }
public bool IsItem27Active { get; set; }
public int Item27SortOrder { get; set; }


public int Detail93Id { get; set; }
public string Detail93Name { get; set; }
public string Detail93Description { get; set; }
public DateTime Detail93CreatedAt { get; set; }
public DateTime? Detail93UpdatedAt { get; set; }
public string Detail93CreatedBy { get; set; }
public bool IsDetail93Active { get; set; }
public int Detail93SortOrder { get; set; }


public int Item3Id { get; set; }
public string Item3Name { get; set; }
public string Item3Description { get; set; }
public DateTime Item3CreatedAt { get; set; }
public DateTime? Item3UpdatedAt { get; set; }
public string Item3CreatedBy { get; set; }
public bool IsItem3Active { get; set; }
public int Item3SortOrder { get; set; }


public int Detail76Id { get; set; }
public string Detail76Name { get; set; }
public string Detail76Description { get; set; }
public DateTime Detail76CreatedAt { get; set; }
public DateTime? Detail76UpdatedAt { get; set; }
public string Detail76CreatedBy { get; set; }
public bool IsDetail76Active { get; set; }
public int Detail76SortOrder { get; set; }


public int Field15Id { get; set; }
public string Field15Name { get; set; }
public string Field15Description { get; set; }
public DateTime Field15CreatedAt { get; set; }
public DateTime? Field15UpdatedAt { get; set; }
public string Field15CreatedBy { get; set; }
public bool IsField15Active { get; set; }
public int Field15SortOrder { get; set; }


public int Param63Id { get; set; }
public string Param63Name { get; set; }
public string Param63Description { get; set; }
public DateTime Param63CreatedAt { get; set; }
public DateTime? Param63UpdatedAt { get; set; }
public string Param63CreatedBy { get; set; }
public bool IsParam63Active { get; set; }
public int Param63SortOrder { get; set; }


public int Config38Id { get; set; }
public string Config38Name { get; set; }
public string Config38Description { get; set; }
public DateTime Config38CreatedAt { get; set; }
public DateTime? Config38UpdatedAt { get; set; }
public string Config38CreatedBy { get; set; }
public bool IsConfig38Active { get; set; }
public int Config38SortOrder { get; set; }


public int Detail95Id { get; set; }
public string Detail95Name { get; set; }
public string Detail95Description { get; set; }
public DateTime Detail95CreatedAt { get; set; }
public DateTime? Detail95UpdatedAt { get; set; }
public string Detail95CreatedBy { get; set; }
public bool IsDetail95Active { get; set; }
public int Detail95SortOrder { get; set; }


public int Config17Id { get; set; }
public string Config17Name { get; set; }
public string Config17Description { get; set; }
public DateTime Config17CreatedAt { get; set; }
public DateTime? Config17UpdatedAt { get; set; }
public string Config17CreatedBy { get; set; }
public bool IsConfig17Active { get; set; }
public int Config17SortOrder { get; set; }


public int Record83Id { get; set; }
public string Record83Name { get; set; }
public string Record83Description { get; set; }
public DateTime Record83CreatedAt { get; set; }
public DateTime? Record83UpdatedAt { get; set; }
public string Record83CreatedBy { get; set; }
public bool IsRecord83Active { get; set; }
public int Record83SortOrder { get; set; }


public int Record66Id { get; set; }
public string Record66Name { get; set; }
public string Record66Description { get; set; }
public DateTime Record66CreatedAt { get; set; }
public DateTime? Record66UpdatedAt { get; set; }
public string Record66CreatedBy { get; set; }
public bool IsRecord66Active { get; set; }
public int Record66SortOrder { get; set; }


public int Config52Id { get; set; }
public string Config52Name { get; set; }
public string Config52Description { get; set; }
public DateTime Config52CreatedAt { get; set; }
public DateTime? Config52UpdatedAt { get; set; }
public string Config52CreatedBy { get; set; }
public bool IsConfig52Active { get; set; }
public int Config52SortOrder { get; set; }


public int Entry75Id { get; set; }
public string Entry75Name { get; set; }
public string Entry75Description { get; set; }
public DateTime Entry75CreatedAt { get; set; }
public DateTime? Entry75UpdatedAt { get; set; }
public string Entry75CreatedBy { get; set; }
public bool IsEntry75Active { get; set; }
public int Entry75SortOrder { get; set; }


public int Entry2Id { get; set; }
public string Entry2Name { get; set; }
public string Entry2Description { get; set; }
public DateTime Entry2CreatedAt { get; set; }
public DateTime? Entry2UpdatedAt { get; set; }
public string Entry2CreatedBy { get; set; }
public bool IsEntry2Active { get; set; }
public int Entry2SortOrder { get; set; }


public int Record7Id { get; set; }
public string Record7Name { get; set; }
public string Record7Description { get; set; }
public DateTime Record7CreatedAt { get; set; }
public DateTime? Record7UpdatedAt { get; set; }
public string Record7CreatedBy { get; set; }
public bool IsRecord7Active { get; set; }
public int Record7SortOrder { get; set; }


public int Attr17Id { get; set; }
public string Attr17Name { get; set; }
public string Attr17Description { get; set; }
public DateTime Attr17CreatedAt { get; set; }
public DateTime? Attr17UpdatedAt { get; set; }
public string Attr17CreatedBy { get; set; }
public bool IsAttr17Active { get; set; }
public int Attr17SortOrder { get; set; }


public int Entry85Id { get; set; }
public string Entry85Name { get; set; }
public string Entry85Description { get; set; }
public DateTime Entry85CreatedAt { get; set; }
public DateTime? Entry85UpdatedAt { get; set; }
public string Entry85CreatedBy { get; set; }
public bool IsEntry85Active { get; set; }
public int Entry85SortOrder { get; set; }


public int Attr15Id { get; set; }
public string Attr15Name { get; set; }
public string Attr15Description { get; set; }
public DateTime Attr15CreatedAt { get; set; }
public DateTime? Attr15UpdatedAt { get; set; }
public string Attr15CreatedBy { get; set; }
public bool IsAttr15Active { get; set; }
public int Attr15SortOrder { get; set; }


public int Record53Id { get; set; }
public string Record53Name { get; set; }
public string Record53Description { get; set; }
public DateTime Record53CreatedAt { get; set; }
public DateTime? Record53UpdatedAt { get; set; }
public string Record53CreatedBy { get; set; }
public bool IsRecord53Active { get; set; }
public int Record53SortOrder { get; set; }


public int Config68Id { get; set; }
public string Config68Name { get; set; }
public string Config68Description { get; set; }
public DateTime Config68CreatedAt { get; set; }
public DateTime? Config68UpdatedAt { get; set; }
public string Config68CreatedBy { get; set; }
public bool IsConfig68Active { get; set; }
public int Config68SortOrder { get; set; }


public int Attr71Id { get; set; }
public string Attr71Name { get; set; }
public string Attr71Description { get; set; }
public DateTime Attr71CreatedAt { get; set; }
public DateTime? Attr71UpdatedAt { get; set; }
public string Attr71CreatedBy { get; set; }
public bool IsAttr71Active { get; set; }
public int Attr71SortOrder { get; set; }


public int Detail29Id { get; set; }
public string Detail29Name { get; set; }
public string Detail29Description { get; set; }
public DateTime Detail29CreatedAt { get; set; }
public DateTime? Detail29UpdatedAt { get; set; }
public string Detail29CreatedBy { get; set; }
public bool IsDetail29Active { get; set; }
public int Detail29SortOrder { get; set; }


public int Attr30Id { get; set; }
public string Attr30Name { get; set; }
public string Attr30Description { get; set; }
public DateTime Attr30CreatedAt { get; set; }
public DateTime? Attr30UpdatedAt { get; set; }
public string Attr30CreatedBy { get; set; }
public bool IsAttr30Active { get; set; }
public int Attr30SortOrder { get; set; }


public int Entry4Id { get; set; }
public string Entry4Name { get; set; }
public string Entry4Description { get; set; }
public DateTime Entry4CreatedAt { get; set; }
public DateTime? Entry4UpdatedAt { get; set; }
public string Entry4CreatedBy { get; set; }
public bool IsEntry4Active { get; set; }
public int Entry4SortOrder { get; set; }


public int Entry46Id { get; set; }
public string Entry46Name { get; set; }
public string Entry46Description { get; set; }
public DateTime Entry46CreatedAt { get; set; }
public DateTime? Entry46UpdatedAt { get; set; }
public string Entry46CreatedBy { get; set; }
public bool IsEntry46Active { get; set; }
public int Entry46SortOrder { get; set; }


public int Detail43Id { get; set; }
public string Detail43Name { get; set; }
public string Detail43Description { get; set; }
public DateTime Detail43CreatedAt { get; set; }
public DateTime? Detail43UpdatedAt { get; set; }
public string Detail43CreatedBy { get; set; }
public bool IsDetail43Active { get; set; }
public int Detail43SortOrder { get; set; }


public int Detail79Id { get; set; }
public string Detail79Name { get; set; }
public string Detail79Description { get; set; }
public DateTime Detail79CreatedAt { get; set; }
public DateTime? Detail79UpdatedAt { get; set; }
public string Detail79CreatedBy { get; set; }
public bool IsDetail79Active { get; set; }
public int Detail79SortOrder { get; set; }


public int Field41Id { get; set; }
public string Field41Name { get; set; }
public string Field41Description { get; set; }
public DateTime Field41CreatedAt { get; set; }
public DateTime? Field41UpdatedAt { get; set; }
public string Field41CreatedBy { get; set; }
public bool IsField41Active { get; set; }
public int Field41SortOrder { get; set; }


public int Config1Id { get; set; }
public string Config1Name { get; set; }
public string Config1Description { get; set; }
public DateTime Config1CreatedAt { get; set; }
public DateTime? Config1UpdatedAt { get; set; }
public string Config1CreatedBy { get; set; }
public bool IsConfig1Active { get; set; }
public int Config1SortOrder { get; set; }


public int Entry90Id { get; set; }
public string Entry90Name { get; set; }
public string Entry90Description { get; set; }
public DateTime Entry90CreatedAt { get; set; }
public DateTime? Entry90UpdatedAt { get; set; }
public string Entry90CreatedBy { get; set; }
public bool IsEntry90Active { get; set; }
public int Entry90SortOrder { get; set; }


public int Attr69Id { get; set; }
public string Attr69Name { get; set; }
public string Attr69Description { get; set; }
public DateTime Attr69CreatedAt { get; set; }
public DateTime? Attr69UpdatedAt { get; set; }
public string Attr69CreatedBy { get; set; }
public bool IsAttr69Active { get; set; }
public int Attr69SortOrder { get; set; }


public int Field43Id { get; set; }
public string Field43Name { get; set; }
public string Field43Description { get; set; }
public DateTime Field43CreatedAt { get; set; }
public DateTime? Field43UpdatedAt { get; set; }
public string Field43CreatedBy { get; set; }
public bool IsField43Active { get; set; }
public int Field43SortOrder { get; set; }


public int Field6Id { get; set; }
public string Field6Name { get; set; }
public string Field6Description { get; set; }
public DateTime Field6CreatedAt { get; set; }
public DateTime? Field6UpdatedAt { get; set; }
public string Field6CreatedBy { get; set; }
public bool IsField6Active { get; set; }
public int Field6SortOrder { get; set; }


public int Attr36Id { get; set; }
public string Attr36Name { get; set; }
public string Attr36Description { get; set; }
public DateTime Attr36CreatedAt { get; set; }
public DateTime? Attr36UpdatedAt { get; set; }
public string Attr36CreatedBy { get; set; }
public bool IsAttr36Active { get; set; }
public int Attr36SortOrder { get; set; }


public int Record54Id { get; set; }
public string Record54Name { get; set; }
public string Record54Description { get; set; }
public DateTime Record54CreatedAt { get; set; }
public DateTime? Record54UpdatedAt { get; set; }
public string Record54CreatedBy { get; set; }
public bool IsRecord54Active { get; set; }
public int Record54SortOrder { get; set; }


public int Record81Id { get; set; }
public string Record81Name { get; set; }
public string Record81Description { get; set; }
public DateTime Record81CreatedAt { get; set; }
public DateTime? Record81UpdatedAt { get; set; }
public string Record81CreatedBy { get; set; }
public bool IsRecord81Active { get; set; }
public int Record81SortOrder { get; set; }


public int Record30Id { get; set; }
public string Record30Name { get; set; }
public string Record30Description { get; set; }
public DateTime Record30CreatedAt { get; set; }
public DateTime? Record30UpdatedAt { get; set; }
public string Record30CreatedBy { get; set; }
public bool IsRecord30Active { get; set; }
public int Record30SortOrder { get; set; }


public int Config53Id { get; set; }
public string Config53Name { get; set; }
public string Config53Description { get; set; }
public DateTime Config53CreatedAt { get; set; }
public DateTime? Config53UpdatedAt { get; set; }
public string Config53CreatedBy { get; set; }
public bool IsConfig53Active { get; set; }
public int Config53SortOrder { get; set; }


public int Config12Id { get; set; }
public string Config12Name { get; set; }
public string Config12Description { get; set; }
public DateTime Config12CreatedAt { get; set; }
public DateTime? Config12UpdatedAt { get; set; }
public string Config12CreatedBy { get; set; }
public bool IsConfig12Active { get; set; }
public int Config12SortOrder { get; set; }


public int Param48Id { get; set; }
public string Param48Name { get; set; }
public string Param48Description { get; set; }
public DateTime Param48CreatedAt { get; set; }
public DateTime? Param48UpdatedAt { get; set; }
public string Param48CreatedBy { get; set; }
public bool IsParam48Active { get; set; }
public int Param48SortOrder { get; set; }


public int Detail68Id { get; set; }
public string Detail68Name { get; set; }
public string Detail68Description { get; set; }
public DateTime Detail68CreatedAt { get; set; }
public DateTime? Detail68UpdatedAt { get; set; }
public string Detail68CreatedBy { get; set; }
public bool IsDetail68Active { get; set; }
public int Detail68SortOrder { get; set; }


public int Detail13Id { get; set; }
public string Detail13Name { get; set; }
public string Detail13Description { get; set; }
public DateTime Detail13CreatedAt { get; set; }
public DateTime? Detail13UpdatedAt { get; set; }
public string Detail13CreatedBy { get; set; }
public bool IsDetail13Active { get; set; }
public int Detail13SortOrder { get; set; }

    }

}