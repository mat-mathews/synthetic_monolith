using Admin.Events235;
using Admin.Service339;
using Admin.Web154;
using Admin.Web46;
using Auth.Api;
using Auth.Client38;
using Billing.Handlers122;
using Common.Shared297;
using GalaxyWorks.Processors16;
using Import.Api;
using Import.Tests;
using Integration.Tests;
using Logging.Processors;
using Notifications.Tests;
using Portal.Tests481;
using Scheduling.Core;
using Scheduling.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts32;

namespace Portal.Events151
{
    public class Portal_Events151_Manager3
    {
        public void Execute()
        {
            // Portal_Events151_Manager3 implementation
        }

/// <summary>
/// Validates the Manager3 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateManager3(Manager3Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Manager3));
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
/// Processes the Manager3 operation asynchronously.
/// </summary>
public async Task<Manager3Result> ProcessManager3Async(
    Manager3Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Manager3), request.Id);

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
            return new Manager3Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Manager3));
        return new Manager3Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Manager3));
        return new Manager3Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Manager3 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Manager3Dto>> GetManager3ListAsync(
    Manager3Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Manager3Entity>().AsQueryable();

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
        .Select(x => new Manager3Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Manager3Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Manager3Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Manager3Service(
    ILogger<Manager3Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Manager3:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Manager3 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Manager3Data> GetCachedManager3Async(string key)
{
    var cacheKey = $"Manager3_{key}";

    if (_cache.TryGetValue(cacheKey, out Manager3Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromManager3SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Field84Id { get; set; }
public string Field84Name { get; set; }
public string Field84Description { get; set; }
public DateTime Field84CreatedAt { get; set; }
public DateTime? Field84UpdatedAt { get; set; }
public string Field84CreatedBy { get; set; }
public bool IsField84Active { get; set; }
public int Field84SortOrder { get; set; }


public int Attr26Id { get; set; }
public string Attr26Name { get; set; }
public string Attr26Description { get; set; }
public DateTime Attr26CreatedAt { get; set; }
public DateTime? Attr26UpdatedAt { get; set; }
public string Attr26CreatedBy { get; set; }
public bool IsAttr26Active { get; set; }
public int Attr26SortOrder { get; set; }


public int Entry92Id { get; set; }
public string Entry92Name { get; set; }
public string Entry92Description { get; set; }
public DateTime Entry92CreatedAt { get; set; }
public DateTime? Entry92UpdatedAt { get; set; }
public string Entry92CreatedBy { get; set; }
public bool IsEntry92Active { get; set; }
public int Entry92SortOrder { get; set; }


public int Param2Id { get; set; }
public string Param2Name { get; set; }
public string Param2Description { get; set; }
public DateTime Param2CreatedAt { get; set; }
public DateTime? Param2UpdatedAt { get; set; }
public string Param2CreatedBy { get; set; }
public bool IsParam2Active { get; set; }
public int Param2SortOrder { get; set; }


public int Entry83Id { get; set; }
public string Entry83Name { get; set; }
public string Entry83Description { get; set; }
public DateTime Entry83CreatedAt { get; set; }
public DateTime? Entry83UpdatedAt { get; set; }
public string Entry83CreatedBy { get; set; }
public bool IsEntry83Active { get; set; }
public int Entry83SortOrder { get; set; }


public int Config17Id { get; set; }
public string Config17Name { get; set; }
public string Config17Description { get; set; }
public DateTime Config17CreatedAt { get; set; }
public DateTime? Config17UpdatedAt { get; set; }
public string Config17CreatedBy { get; set; }
public bool IsConfig17Active { get; set; }
public int Config17SortOrder { get; set; }


public int Entry28Id { get; set; }
public string Entry28Name { get; set; }
public string Entry28Description { get; set; }
public DateTime Entry28CreatedAt { get; set; }
public DateTime? Entry28UpdatedAt { get; set; }
public string Entry28CreatedBy { get; set; }
public bool IsEntry28Active { get; set; }
public int Entry28SortOrder { get; set; }


public int Record62Id { get; set; }
public string Record62Name { get; set; }
public string Record62Description { get; set; }
public DateTime Record62CreatedAt { get; set; }
public DateTime? Record62UpdatedAt { get; set; }
public string Record62CreatedBy { get; set; }
public bool IsRecord62Active { get; set; }
public int Record62SortOrder { get; set; }


public int Record46Id { get; set; }
public string Record46Name { get; set; }
public string Record46Description { get; set; }
public DateTime Record46CreatedAt { get; set; }
public DateTime? Record46UpdatedAt { get; set; }
public string Record46CreatedBy { get; set; }
public bool IsRecord46Active { get; set; }
public int Record46SortOrder { get; set; }


public int Attr52Id { get; set; }
public string Attr52Name { get; set; }
public string Attr52Description { get; set; }
public DateTime Attr52CreatedAt { get; set; }
public DateTime? Attr52UpdatedAt { get; set; }
public string Attr52CreatedBy { get; set; }
public bool IsAttr52Active { get; set; }
public int Attr52SortOrder { get; set; }


public int Item88Id { get; set; }
public string Item88Name { get; set; }
public string Item88Description { get; set; }
public DateTime Item88CreatedAt { get; set; }
public DateTime? Item88UpdatedAt { get; set; }
public string Item88CreatedBy { get; set; }
public bool IsItem88Active { get; set; }
public int Item88SortOrder { get; set; }


public int Config93Id { get; set; }
public string Config93Name { get; set; }
public string Config93Description { get; set; }
public DateTime Config93CreatedAt { get; set; }
public DateTime? Config93UpdatedAt { get; set; }
public string Config93CreatedBy { get; set; }
public bool IsConfig93Active { get; set; }
public int Config93SortOrder { get; set; }


public int Config16Id { get; set; }
public string Config16Name { get; set; }
public string Config16Description { get; set; }
public DateTime Config16CreatedAt { get; set; }
public DateTime? Config16UpdatedAt { get; set; }
public string Config16CreatedBy { get; set; }
public bool IsConfig16Active { get; set; }
public int Config16SortOrder { get; set; }


public int Attr45Id { get; set; }
public string Attr45Name { get; set; }
public string Attr45Description { get; set; }
public DateTime Attr45CreatedAt { get; set; }
public DateTime? Attr45UpdatedAt { get; set; }
public string Attr45CreatedBy { get; set; }
public bool IsAttr45Active { get; set; }
public int Attr45SortOrder { get; set; }


public int Detail37Id { get; set; }
public string Detail37Name { get; set; }
public string Detail37Description { get; set; }
public DateTime Detail37CreatedAt { get; set; }
public DateTime? Detail37UpdatedAt { get; set; }
public string Detail37CreatedBy { get; set; }
public bool IsDetail37Active { get; set; }
public int Detail37SortOrder { get; set; }


public int Item7Id { get; set; }
public string Item7Name { get; set; }
public string Item7Description { get; set; }
public DateTime Item7CreatedAt { get; set; }
public DateTime? Item7UpdatedAt { get; set; }
public string Item7CreatedBy { get; set; }
public bool IsItem7Active { get; set; }
public int Item7SortOrder { get; set; }


public int Param19Id { get; set; }
public string Param19Name { get; set; }
public string Param19Description { get; set; }
public DateTime Param19CreatedAt { get; set; }
public DateTime? Param19UpdatedAt { get; set; }
public string Param19CreatedBy { get; set; }
public bool IsParam19Active { get; set; }
public int Param19SortOrder { get; set; }


public int Field80Id { get; set; }
public string Field80Name { get; set; }
public string Field80Description { get; set; }
public DateTime Field80CreatedAt { get; set; }
public DateTime? Field80UpdatedAt { get; set; }
public string Field80CreatedBy { get; set; }
public bool IsField80Active { get; set; }
public int Field80SortOrder { get; set; }


public int Detail77Id { get; set; }
public string Detail77Name { get; set; }
public string Detail77Description { get; set; }
public DateTime Detail77CreatedAt { get; set; }
public DateTime? Detail77UpdatedAt { get; set; }
public string Detail77CreatedBy { get; set; }
public bool IsDetail77Active { get; set; }
public int Detail77SortOrder { get; set; }


public int Item76Id { get; set; }
public string Item76Name { get; set; }
public string Item76Description { get; set; }
public DateTime Item76CreatedAt { get; set; }
public DateTime? Item76UpdatedAt { get; set; }
public string Item76CreatedBy { get; set; }
public bool IsItem76Active { get; set; }
public int Item76SortOrder { get; set; }


public int Record79Id { get; set; }
public string Record79Name { get; set; }
public string Record79Description { get; set; }
public DateTime Record79CreatedAt { get; set; }
public DateTime? Record79UpdatedAt { get; set; }
public string Record79CreatedBy { get; set; }
public bool IsRecord79Active { get; set; }
public int Record79SortOrder { get; set; }


public int Entry75Id { get; set; }
public string Entry75Name { get; set; }
public string Entry75Description { get; set; }
public DateTime Entry75CreatedAt { get; set; }
public DateTime? Entry75UpdatedAt { get; set; }
public string Entry75CreatedBy { get; set; }
public bool IsEntry75Active { get; set; }
public int Entry75SortOrder { get; set; }


public int Item68Id { get; set; }
public string Item68Name { get; set; }
public string Item68Description { get; set; }
public DateTime Item68CreatedAt { get; set; }
public DateTime? Item68UpdatedAt { get; set; }
public string Item68CreatedBy { get; set; }
public bool IsItem68Active { get; set; }
public int Item68SortOrder { get; set; }


public int Item63Id { get; set; }
public string Item63Name { get; set; }
public string Item63Description { get; set; }
public DateTime Item63CreatedAt { get; set; }
public DateTime? Item63UpdatedAt { get; set; }
public string Item63CreatedBy { get; set; }
public bool IsItem63Active { get; set; }
public int Item63SortOrder { get; set; }


public int Entry6Id { get; set; }
public string Entry6Name { get; set; }
public string Entry6Description { get; set; }
public DateTime Entry6CreatedAt { get; set; }
public DateTime? Entry6UpdatedAt { get; set; }
public string Entry6CreatedBy { get; set; }
public bool IsEntry6Active { get; set; }
public int Entry6SortOrder { get; set; }


public int Param80Id { get; set; }
public string Param80Name { get; set; }
public string Param80Description { get; set; }
public DateTime Param80CreatedAt { get; set; }
public DateTime? Param80UpdatedAt { get; set; }
public string Param80CreatedBy { get; set; }
public bool IsParam80Active { get; set; }
public int Param80SortOrder { get; set; }


public int Detail49Id { get; set; }
public string Detail49Name { get; set; }
public string Detail49Description { get; set; }
public DateTime Detail49CreatedAt { get; set; }
public DateTime? Detail49UpdatedAt { get; set; }
public string Detail49CreatedBy { get; set; }
public bool IsDetail49Active { get; set; }
public int Detail49SortOrder { get; set; }


public int Field86Id { get; set; }
public string Field86Name { get; set; }
public string Field86Description { get; set; }
public DateTime Field86CreatedAt { get; set; }
public DateTime? Field86UpdatedAt { get; set; }
public string Field86CreatedBy { get; set; }
public bool IsField86Active { get; set; }
public int Field86SortOrder { get; set; }


public int Record35Id { get; set; }
public string Record35Name { get; set; }
public string Record35Description { get; set; }
public DateTime Record35CreatedAt { get; set; }
public DateTime? Record35UpdatedAt { get; set; }
public string Record35CreatedBy { get; set; }
public bool IsRecord35Active { get; set; }
public int Record35SortOrder { get; set; }


public int Entry4Id { get; set; }
public string Entry4Name { get; set; }
public string Entry4Description { get; set; }
public DateTime Entry4CreatedAt { get; set; }
public DateTime? Entry4UpdatedAt { get; set; }
public string Entry4CreatedBy { get; set; }
public bool IsEntry4Active { get; set; }
public int Entry4SortOrder { get; set; }


public int Param30Id { get; set; }
public string Param30Name { get; set; }
public string Param30Description { get; set; }
public DateTime Param30CreatedAt { get; set; }
public DateTime? Param30UpdatedAt { get; set; }
public string Param30CreatedBy { get; set; }
public bool IsParam30Active { get; set; }
public int Param30SortOrder { get; set; }


public int Record85Id { get; set; }
public string Record85Name { get; set; }
public string Record85Description { get; set; }
public DateTime Record85CreatedAt { get; set; }
public DateTime? Record85UpdatedAt { get; set; }
public string Record85CreatedBy { get; set; }
public bool IsRecord85Active { get; set; }
public int Record85SortOrder { get; set; }


public int Field74Id { get; set; }
public string Field74Name { get; set; }
public string Field74Description { get; set; }
public DateTime Field74CreatedAt { get; set; }
public DateTime? Field74UpdatedAt { get; set; }
public string Field74CreatedBy { get; set; }
public bool IsField74Active { get; set; }
public int Field74SortOrder { get; set; }


public int Detail25Id { get; set; }
public string Detail25Name { get; set; }
public string Detail25Description { get; set; }
public DateTime Detail25CreatedAt { get; set; }
public DateTime? Detail25UpdatedAt { get; set; }
public string Detail25CreatedBy { get; set; }
public bool IsDetail25Active { get; set; }
public int Detail25SortOrder { get; set; }


public int Detail83Id { get; set; }
public string Detail83Name { get; set; }
public string Detail83Description { get; set; }
public DateTime Detail83CreatedAt { get; set; }
public DateTime? Detail83UpdatedAt { get; set; }
public string Detail83CreatedBy { get; set; }
public bool IsDetail83Active { get; set; }
public int Detail83SortOrder { get; set; }


public int Config60Id { get; set; }
public string Config60Name { get; set; }
public string Config60Description { get; set; }
public DateTime Config60CreatedAt { get; set; }
public DateTime? Config60UpdatedAt { get; set; }
public string Config60CreatedBy { get; set; }
public bool IsConfig60Active { get; set; }
public int Config60SortOrder { get; set; }


public int Record67Id { get; set; }
public string Record67Name { get; set; }
public string Record67Description { get; set; }
public DateTime Record67CreatedAt { get; set; }
public DateTime? Record67UpdatedAt { get; set; }
public string Record67CreatedBy { get; set; }
public bool IsRecord67Active { get; set; }
public int Record67SortOrder { get; set; }


public int Field73Id { get; set; }
public string Field73Name { get; set; }
public string Field73Description { get; set; }
public DateTime Field73CreatedAt { get; set; }
public DateTime? Field73UpdatedAt { get; set; }
public string Field73CreatedBy { get; set; }
public bool IsField73Active { get; set; }
public int Field73SortOrder { get; set; }


public int Field12Id { get; set; }
public string Field12Name { get; set; }
public string Field12Description { get; set; }
public DateTime Field12CreatedAt { get; set; }
public DateTime? Field12UpdatedAt { get; set; }
public string Field12CreatedBy { get; set; }
public bool IsField12Active { get; set; }
public int Field12SortOrder { get; set; }


public int Config71Id { get; set; }
public string Config71Name { get; set; }
public string Config71Description { get; set; }
public DateTime Config71CreatedAt { get; set; }
public DateTime? Config71UpdatedAt { get; set; }
public string Config71CreatedBy { get; set; }
public bool IsConfig71Active { get; set; }
public int Config71SortOrder { get; set; }


public int Detail9Id { get; set; }
public string Detail9Name { get; set; }
public string Detail9Description { get; set; }
public DateTime Detail9CreatedAt { get; set; }
public DateTime? Detail9UpdatedAt { get; set; }
public string Detail9CreatedBy { get; set; }
public bool IsDetail9Active { get; set; }
public int Detail9SortOrder { get; set; }


public int Entry96Id { get; set; }
public string Entry96Name { get; set; }
public string Entry96Description { get; set; }
public DateTime Entry96CreatedAt { get; set; }
public DateTime? Entry96UpdatedAt { get; set; }
public string Entry96CreatedBy { get; set; }
public bool IsEntry96Active { get; set; }
public int Entry96SortOrder { get; set; }


public int Detail67Id { get; set; }
public string Detail67Name { get; set; }
public string Detail67Description { get; set; }
public DateTime Detail67CreatedAt { get; set; }
public DateTime? Detail67UpdatedAt { get; set; }
public string Detail67CreatedBy { get; set; }
public bool IsDetail67Active { get; set; }
public int Detail67SortOrder { get; set; }


public int Record92Id { get; set; }
public string Record92Name { get; set; }
public string Record92Description { get; set; }
public DateTime Record92CreatedAt { get; set; }
public DateTime? Record92UpdatedAt { get; set; }
public string Record92CreatedBy { get; set; }
public bool IsRecord92Active { get; set; }
public int Record92SortOrder { get; set; }


public int Config75Id { get; set; }
public string Config75Name { get; set; }
public string Config75Description { get; set; }
public DateTime Config75CreatedAt { get; set; }
public DateTime? Config75UpdatedAt { get; set; }
public string Config75CreatedBy { get; set; }
public bool IsConfig75Active { get; set; }
public int Config75SortOrder { get; set; }


public int Param79Id { get; set; }
public string Param79Name { get; set; }
public string Param79Description { get; set; }
public DateTime Param79CreatedAt { get; set; }
public DateTime? Param79UpdatedAt { get; set; }
public string Param79CreatedBy { get; set; }
public bool IsParam79Active { get; set; }
public int Param79SortOrder { get; set; }


public int Config86Id { get; set; }
public string Config86Name { get; set; }
public string Config86Description { get; set; }
public DateTime Config86CreatedAt { get; set; }
public DateTime? Config86UpdatedAt { get; set; }
public string Config86CreatedBy { get; set; }
public bool IsConfig86Active { get; set; }
public int Config86SortOrder { get; set; }


public int Config59Id { get; set; }
public string Config59Name { get; set; }
public string Config59Description { get; set; }
public DateTime Config59CreatedAt { get; set; }
public DateTime? Config59UpdatedAt { get; set; }
public string Config59CreatedBy { get; set; }
public bool IsConfig59Active { get; set; }
public int Config59SortOrder { get; set; }


public int Entry45Id { get; set; }
public string Entry45Name { get; set; }
public string Entry45Description { get; set; }
public DateTime Entry45CreatedAt { get; set; }
public DateTime? Entry45UpdatedAt { get; set; }
public string Entry45CreatedBy { get; set; }
public bool IsEntry45Active { get; set; }
public int Entry45SortOrder { get; set; }


public int Item75Id { get; set; }
public string Item75Name { get; set; }
public string Item75Description { get; set; }
public DateTime Item75CreatedAt { get; set; }
public DateTime? Item75UpdatedAt { get; set; }
public string Item75CreatedBy { get; set; }
public bool IsItem75Active { get; set; }
public int Item75SortOrder { get; set; }


public int Item63Id { get; set; }
public string Item63Name { get; set; }
public string Item63Description { get; set; }
public DateTime Item63CreatedAt { get; set; }
public DateTime? Item63UpdatedAt { get; set; }
public string Item63CreatedBy { get; set; }
public bool IsItem63Active { get; set; }
public int Item63SortOrder { get; set; }


public int Config71Id { get; set; }
public string Config71Name { get; set; }
public string Config71Description { get; set; }
public DateTime Config71CreatedAt { get; set; }
public DateTime? Config71UpdatedAt { get; set; }
public string Config71CreatedBy { get; set; }
public bool IsConfig71Active { get; set; }
public int Config71SortOrder { get; set; }


public int Record76Id { get; set; }
public string Record76Name { get; set; }
public string Record76Description { get; set; }
public DateTime Record76CreatedAt { get; set; }
public DateTime? Record76UpdatedAt { get; set; }
public string Record76CreatedBy { get; set; }
public bool IsRecord76Active { get; set; }
public int Record76SortOrder { get; set; }


public int Field20Id { get; set; }
public string Field20Name { get; set; }
public string Field20Description { get; set; }
public DateTime Field20CreatedAt { get; set; }
public DateTime? Field20UpdatedAt { get; set; }
public string Field20CreatedBy { get; set; }
public bool IsField20Active { get; set; }
public int Field20SortOrder { get; set; }

    }

}