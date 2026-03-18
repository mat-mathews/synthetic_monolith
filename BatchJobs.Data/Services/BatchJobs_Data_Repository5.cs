using Auth.Api;
using Auth.Handlers;
using Auth.Mappers208;
using BatchJobs.Models304;
using Billing.Contracts44;
using Billing.Handlers101;
using Common.Events;
using Common.Tests;
using DataAccess.Api307;
using DataAccess.Core;
using DataAccess.Models;
using Export.Data6;
using Notifications.Models466;
using Portal.Api;
using Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared;

namespace BatchJobs.Data
{
    internal class BatchJobs_Data_Repository5
    {
        public void Execute()
        {
            // BatchJobs_Data_Repository5 implementation
        }

/// <summary>
/// Validates the Repository5 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateRepository5(Repository5Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Repository5));
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
/// Processes the Repository5 operation asynchronously.
/// </summary>
public async Task<Repository5Result> ProcessRepository5Async(
    Repository5Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Repository5), request.Id);

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
            return new Repository5Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Repository5));
        return new Repository5Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Repository5));
        return new Repository5Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Repository5 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Repository5Dto>> GetRepository5ListAsync(
    Repository5Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Repository5Entity>().AsQueryable();

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
        .Select(x => new Repository5Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Repository5Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Repository5Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Repository5Service(
    ILogger<Repository5Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Repository5:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Repository5 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Repository5Data> GetCachedRepository5Async(string key)
{
    var cacheKey = $"Repository5_{key}";

    if (_cache.TryGetValue(cacheKey, out Repository5Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromRepository5SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Config75Id { get; set; }
public string Config75Name { get; set; }
public string Config75Description { get; set; }
public DateTime Config75CreatedAt { get; set; }
public DateTime? Config75UpdatedAt { get; set; }
public string Config75CreatedBy { get; set; }
public bool IsConfig75Active { get; set; }
public int Config75SortOrder { get; set; }


public int Record6Id { get; set; }
public string Record6Name { get; set; }
public string Record6Description { get; set; }
public DateTime Record6CreatedAt { get; set; }
public DateTime? Record6UpdatedAt { get; set; }
public string Record6CreatedBy { get; set; }
public bool IsRecord6Active { get; set; }
public int Record6SortOrder { get; set; }


public int Entry10Id { get; set; }
public string Entry10Name { get; set; }
public string Entry10Description { get; set; }
public DateTime Entry10CreatedAt { get; set; }
public DateTime? Entry10UpdatedAt { get; set; }
public string Entry10CreatedBy { get; set; }
public bool IsEntry10Active { get; set; }
public int Entry10SortOrder { get; set; }


public int Attr91Id { get; set; }
public string Attr91Name { get; set; }
public string Attr91Description { get; set; }
public DateTime Attr91CreatedAt { get; set; }
public DateTime? Attr91UpdatedAt { get; set; }
public string Attr91CreatedBy { get; set; }
public bool IsAttr91Active { get; set; }
public int Attr91SortOrder { get; set; }


public int Field47Id { get; set; }
public string Field47Name { get; set; }
public string Field47Description { get; set; }
public DateTime Field47CreatedAt { get; set; }
public DateTime? Field47UpdatedAt { get; set; }
public string Field47CreatedBy { get; set; }
public bool IsField47Active { get; set; }
public int Field47SortOrder { get; set; }


public int Record69Id { get; set; }
public string Record69Name { get; set; }
public string Record69Description { get; set; }
public DateTime Record69CreatedAt { get; set; }
public DateTime? Record69UpdatedAt { get; set; }
public string Record69CreatedBy { get; set; }
public bool IsRecord69Active { get; set; }
public int Record69SortOrder { get; set; }


public int Item51Id { get; set; }
public string Item51Name { get; set; }
public string Item51Description { get; set; }
public DateTime Item51CreatedAt { get; set; }
public DateTime? Item51UpdatedAt { get; set; }
public string Item51CreatedBy { get; set; }
public bool IsItem51Active { get; set; }
public int Item51SortOrder { get; set; }


public int Param74Id { get; set; }
public string Param74Name { get; set; }
public string Param74Description { get; set; }
public DateTime Param74CreatedAt { get; set; }
public DateTime? Param74UpdatedAt { get; set; }
public string Param74CreatedBy { get; set; }
public bool IsParam74Active { get; set; }
public int Param74SortOrder { get; set; }


public int Config78Id { get; set; }
public string Config78Name { get; set; }
public string Config78Description { get; set; }
public DateTime Config78CreatedAt { get; set; }
public DateTime? Config78UpdatedAt { get; set; }
public string Config78CreatedBy { get; set; }
public bool IsConfig78Active { get; set; }
public int Config78SortOrder { get; set; }


public int Param40Id { get; set; }
public string Param40Name { get; set; }
public string Param40Description { get; set; }
public DateTime Param40CreatedAt { get; set; }
public DateTime? Param40UpdatedAt { get; set; }
public string Param40CreatedBy { get; set; }
public bool IsParam40Active { get; set; }
public int Param40SortOrder { get; set; }


public int Item20Id { get; set; }
public string Item20Name { get; set; }
public string Item20Description { get; set; }
public DateTime Item20CreatedAt { get; set; }
public DateTime? Item20UpdatedAt { get; set; }
public string Item20CreatedBy { get; set; }
public bool IsItem20Active { get; set; }
public int Item20SortOrder { get; set; }


public int Record93Id { get; set; }
public string Record93Name { get; set; }
public string Record93Description { get; set; }
public DateTime Record93CreatedAt { get; set; }
public DateTime? Record93UpdatedAt { get; set; }
public string Record93CreatedBy { get; set; }
public bool IsRecord93Active { get; set; }
public int Record93SortOrder { get; set; }


public int Param58Id { get; set; }
public string Param58Name { get; set; }
public string Param58Description { get; set; }
public DateTime Param58CreatedAt { get; set; }
public DateTime? Param58UpdatedAt { get; set; }
public string Param58CreatedBy { get; set; }
public bool IsParam58Active { get; set; }
public int Param58SortOrder { get; set; }


public int Param29Id { get; set; }
public string Param29Name { get; set; }
public string Param29Description { get; set; }
public DateTime Param29CreatedAt { get; set; }
public DateTime? Param29UpdatedAt { get; set; }
public string Param29CreatedBy { get; set; }
public bool IsParam29Active { get; set; }
public int Param29SortOrder { get; set; }


public int Config59Id { get; set; }
public string Config59Name { get; set; }
public string Config59Description { get; set; }
public DateTime Config59CreatedAt { get; set; }
public DateTime? Config59UpdatedAt { get; set; }
public string Config59CreatedBy { get; set; }
public bool IsConfig59Active { get; set; }
public int Config59SortOrder { get; set; }


public int Item94Id { get; set; }
public string Item94Name { get; set; }
public string Item94Description { get; set; }
public DateTime Item94CreatedAt { get; set; }
public DateTime? Item94UpdatedAt { get; set; }
public string Item94CreatedBy { get; set; }
public bool IsItem94Active { get; set; }
public int Item94SortOrder { get; set; }


public int Entry81Id { get; set; }
public string Entry81Name { get; set; }
public string Entry81Description { get; set; }
public DateTime Entry81CreatedAt { get; set; }
public DateTime? Entry81UpdatedAt { get; set; }
public string Entry81CreatedBy { get; set; }
public bool IsEntry81Active { get; set; }
public int Entry81SortOrder { get; set; }


public int Item42Id { get; set; }
public string Item42Name { get; set; }
public string Item42Description { get; set; }
public DateTime Item42CreatedAt { get; set; }
public DateTime? Item42UpdatedAt { get; set; }
public string Item42CreatedBy { get; set; }
public bool IsItem42Active { get; set; }
public int Item42SortOrder { get; set; }


public int Config75Id { get; set; }
public string Config75Name { get; set; }
public string Config75Description { get; set; }
public DateTime Config75CreatedAt { get; set; }
public DateTime? Config75UpdatedAt { get; set; }
public string Config75CreatedBy { get; set; }
public bool IsConfig75Active { get; set; }
public int Config75SortOrder { get; set; }


public int Attr90Id { get; set; }
public string Attr90Name { get; set; }
public string Attr90Description { get; set; }
public DateTime Attr90CreatedAt { get; set; }
public DateTime? Attr90UpdatedAt { get; set; }
public string Attr90CreatedBy { get; set; }
public bool IsAttr90Active { get; set; }
public int Attr90SortOrder { get; set; }


public int Config77Id { get; set; }
public string Config77Name { get; set; }
public string Config77Description { get; set; }
public DateTime Config77CreatedAt { get; set; }
public DateTime? Config77UpdatedAt { get; set; }
public string Config77CreatedBy { get; set; }
public bool IsConfig77Active { get; set; }
public int Config77SortOrder { get; set; }


public int Param38Id { get; set; }
public string Param38Name { get; set; }
public string Param38Description { get; set; }
public DateTime Param38CreatedAt { get; set; }
public DateTime? Param38UpdatedAt { get; set; }
public string Param38CreatedBy { get; set; }
public bool IsParam38Active { get; set; }
public int Param38SortOrder { get; set; }


public int Attr87Id { get; set; }
public string Attr87Name { get; set; }
public string Attr87Description { get; set; }
public DateTime Attr87CreatedAt { get; set; }
public DateTime? Attr87UpdatedAt { get; set; }
public string Attr87CreatedBy { get; set; }
public bool IsAttr87Active { get; set; }
public int Attr87SortOrder { get; set; }


public int Field57Id { get; set; }
public string Field57Name { get; set; }
public string Field57Description { get; set; }
public DateTime Field57CreatedAt { get; set; }
public DateTime? Field57UpdatedAt { get; set; }
public string Field57CreatedBy { get; set; }
public bool IsField57Active { get; set; }
public int Field57SortOrder { get; set; }


public int Field42Id { get; set; }
public string Field42Name { get; set; }
public string Field42Description { get; set; }
public DateTime Field42CreatedAt { get; set; }
public DateTime? Field42UpdatedAt { get; set; }
public string Field42CreatedBy { get; set; }
public bool IsField42Active { get; set; }
public int Field42SortOrder { get; set; }


public int Item47Id { get; set; }
public string Item47Name { get; set; }
public string Item47Description { get; set; }
public DateTime Item47CreatedAt { get; set; }
public DateTime? Item47UpdatedAt { get; set; }
public string Item47CreatedBy { get; set; }
public bool IsItem47Active { get; set; }
public int Item47SortOrder { get; set; }


public int Detail73Id { get; set; }
public string Detail73Name { get; set; }
public string Detail73Description { get; set; }
public DateTime Detail73CreatedAt { get; set; }
public DateTime? Detail73UpdatedAt { get; set; }
public string Detail73CreatedBy { get; set; }
public bool IsDetail73Active { get; set; }
public int Detail73SortOrder { get; set; }


public int Record66Id { get; set; }
public string Record66Name { get; set; }
public string Record66Description { get; set; }
public DateTime Record66CreatedAt { get; set; }
public DateTime? Record66UpdatedAt { get; set; }
public string Record66CreatedBy { get; set; }
public bool IsRecord66Active { get; set; }
public int Record66SortOrder { get; set; }


public int Param46Id { get; set; }
public string Param46Name { get; set; }
public string Param46Description { get; set; }
public DateTime Param46CreatedAt { get; set; }
public DateTime? Param46UpdatedAt { get; set; }
public string Param46CreatedBy { get; set; }
public bool IsParam46Active { get; set; }
public int Param46SortOrder { get; set; }


public int Attr38Id { get; set; }
public string Attr38Name { get; set; }
public string Attr38Description { get; set; }
public DateTime Attr38CreatedAt { get; set; }
public DateTime? Attr38UpdatedAt { get; set; }
public string Attr38CreatedBy { get; set; }
public bool IsAttr38Active { get; set; }
public int Attr38SortOrder { get; set; }


public int Detail66Id { get; set; }
public string Detail66Name { get; set; }
public string Detail66Description { get; set; }
public DateTime Detail66CreatedAt { get; set; }
public DateTime? Detail66UpdatedAt { get; set; }
public string Detail66CreatedBy { get; set; }
public bool IsDetail66Active { get; set; }
public int Detail66SortOrder { get; set; }


public int Entry85Id { get; set; }
public string Entry85Name { get; set; }
public string Entry85Description { get; set; }
public DateTime Entry85CreatedAt { get; set; }
public DateTime? Entry85UpdatedAt { get; set; }
public string Entry85CreatedBy { get; set; }
public bool IsEntry85Active { get; set; }
public int Entry85SortOrder { get; set; }


public int Attr86Id { get; set; }
public string Attr86Name { get; set; }
public string Attr86Description { get; set; }
public DateTime Attr86CreatedAt { get; set; }
public DateTime? Attr86UpdatedAt { get; set; }
public string Attr86CreatedBy { get; set; }
public bool IsAttr86Active { get; set; }
public int Attr86SortOrder { get; set; }


public int Detail39Id { get; set; }
public string Detail39Name { get; set; }
public string Detail39Description { get; set; }
public DateTime Detail39CreatedAt { get; set; }
public DateTime? Detail39UpdatedAt { get; set; }
public string Detail39CreatedBy { get; set; }
public bool IsDetail39Active { get; set; }
public int Detail39SortOrder { get; set; }


public int Config21Id { get; set; }
public string Config21Name { get; set; }
public string Config21Description { get; set; }
public DateTime Config21CreatedAt { get; set; }
public DateTime? Config21UpdatedAt { get; set; }
public string Config21CreatedBy { get; set; }
public bool IsConfig21Active { get; set; }
public int Config21SortOrder { get; set; }


public int Config95Id { get; set; }
public string Config95Name { get; set; }
public string Config95Description { get; set; }
public DateTime Config95CreatedAt { get; set; }
public DateTime? Config95UpdatedAt { get; set; }
public string Config95CreatedBy { get; set; }
public bool IsConfig95Active { get; set; }
public int Config95SortOrder { get; set; }


public int Detail10Id { get; set; }
public string Detail10Name { get; set; }
public string Detail10Description { get; set; }
public DateTime Detail10CreatedAt { get; set; }
public DateTime? Detail10UpdatedAt { get; set; }
public string Detail10CreatedBy { get; set; }
public bool IsDetail10Active { get; set; }
public int Detail10SortOrder { get; set; }


public int Detail95Id { get; set; }
public string Detail95Name { get; set; }
public string Detail95Description { get; set; }
public DateTime Detail95CreatedAt { get; set; }
public DateTime? Detail95UpdatedAt { get; set; }
public string Detail95CreatedBy { get; set; }
public bool IsDetail95Active { get; set; }
public int Detail95SortOrder { get; set; }


public int Attr10Id { get; set; }
public string Attr10Name { get; set; }
public string Attr10Description { get; set; }
public DateTime Attr10CreatedAt { get; set; }
public DateTime? Attr10UpdatedAt { get; set; }
public string Attr10CreatedBy { get; set; }
public bool IsAttr10Active { get; set; }
public int Attr10SortOrder { get; set; }


public int Field75Id { get; set; }
public string Field75Name { get; set; }
public string Field75Description { get; set; }
public DateTime Field75CreatedAt { get; set; }
public DateTime? Field75UpdatedAt { get; set; }
public string Field75CreatedBy { get; set; }
public bool IsField75Active { get; set; }
public int Field75SortOrder { get; set; }


public int Item62Id { get; set; }
public string Item62Name { get; set; }
public string Item62Description { get; set; }
public DateTime Item62CreatedAt { get; set; }
public DateTime? Item62UpdatedAt { get; set; }
public string Item62CreatedBy { get; set; }
public bool IsItem62Active { get; set; }
public int Item62SortOrder { get; set; }


public int Config10Id { get; set; }
public string Config10Name { get; set; }
public string Config10Description { get; set; }
public DateTime Config10CreatedAt { get; set; }
public DateTime? Config10UpdatedAt { get; set; }
public string Config10CreatedBy { get; set; }
public bool IsConfig10Active { get; set; }
public int Config10SortOrder { get; set; }


public int Field59Id { get; set; }
public string Field59Name { get; set; }
public string Field59Description { get; set; }
public DateTime Field59CreatedAt { get; set; }
public DateTime? Field59UpdatedAt { get; set; }
public string Field59CreatedBy { get; set; }
public bool IsField59Active { get; set; }
public int Field59SortOrder { get; set; }


public int Param23Id { get; set; }
public string Param23Name { get; set; }
public string Param23Description { get; set; }
public DateTime Param23CreatedAt { get; set; }
public DateTime? Param23UpdatedAt { get; set; }
public string Param23CreatedBy { get; set; }
public bool IsParam23Active { get; set; }
public int Param23SortOrder { get; set; }


public int Entry49Id { get; set; }
public string Entry49Name { get; set; }
public string Entry49Description { get; set; }
public DateTime Entry49CreatedAt { get; set; }
public DateTime? Entry49UpdatedAt { get; set; }
public string Entry49CreatedBy { get; set; }
public bool IsEntry49Active { get; set; }
public int Entry49SortOrder { get; set; }


public int Field18Id { get; set; }
public string Field18Name { get; set; }
public string Field18Description { get; set; }
public DateTime Field18CreatedAt { get; set; }
public DateTime? Field18UpdatedAt { get; set; }
public string Field18CreatedBy { get; set; }
public bool IsField18Active { get; set; }
public int Field18SortOrder { get; set; }


public int Field61Id { get; set; }
public string Field61Name { get; set; }
public string Field61Description { get; set; }
public DateTime Field61CreatedAt { get; set; }
public DateTime? Field61UpdatedAt { get; set; }
public string Field61CreatedBy { get; set; }
public bool IsField61Active { get; set; }
public int Field61SortOrder { get; set; }


public int Param73Id { get; set; }
public string Param73Name { get; set; }
public string Param73Description { get; set; }
public DateTime Param73CreatedAt { get; set; }
public DateTime? Param73UpdatedAt { get; set; }
public string Param73CreatedBy { get; set; }
public bool IsParam73Active { get; set; }
public int Param73SortOrder { get; set; }


public int Field37Id { get; set; }
public string Field37Name { get; set; }
public string Field37Description { get; set; }
public DateTime Field37CreatedAt { get; set; }
public DateTime? Field37UpdatedAt { get; set; }
public string Field37CreatedBy { get; set; }
public bool IsField37Active { get; set; }
public int Field37SortOrder { get; set; }


public int Detail97Id { get; set; }
public string Detail97Name { get; set; }
public string Detail97Description { get; set; }
public DateTime Detail97CreatedAt { get; set; }
public DateTime? Detail97UpdatedAt { get; set; }
public string Detail97CreatedBy { get; set; }
public bool IsDetail97Active { get; set; }
public int Detail97SortOrder { get; set; }


public int Config74Id { get; set; }
public string Config74Name { get; set; }
public string Config74Description { get; set; }
public DateTime Config74CreatedAt { get; set; }
public DateTime? Config74UpdatedAt { get; set; }
public string Config74CreatedBy { get; set; }
public bool IsConfig74Active { get; set; }
public int Config74SortOrder { get; set; }


public int Detail32Id { get; set; }
public string Detail32Name { get; set; }
public string Detail32Description { get; set; }
public DateTime Detail32CreatedAt { get; set; }
public DateTime? Detail32UpdatedAt { get; set; }
public string Detail32CreatedBy { get; set; }
public bool IsDetail32Active { get; set; }
public int Detail32SortOrder { get; set; }


public int Param39Id { get; set; }
public string Param39Name { get; set; }
public string Param39Description { get; set; }
public DateTime Param39CreatedAt { get; set; }
public DateTime? Param39UpdatedAt { get; set; }
public string Param39CreatedBy { get; set; }
public bool IsParam39Active { get; set; }
public int Param39SortOrder { get; set; }


public int Item87Id { get; set; }
public string Item87Name { get; set; }
public string Item87Description { get; set; }
public DateTime Item87CreatedAt { get; set; }
public DateTime? Item87UpdatedAt { get; set; }
public string Item87CreatedBy { get; set; }
public bool IsItem87Active { get; set; }
public int Item87SortOrder { get; set; }

    }

}