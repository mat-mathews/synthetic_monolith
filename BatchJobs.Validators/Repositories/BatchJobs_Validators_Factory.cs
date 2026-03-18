using Admin.Events;
using Admin.Service456;
using Admin.Validators;
using Auth.Contracts402;
using Auth.Handlers281;
using Common.Web;
using DataAccess.Api307;
using DataAccess.Data;
using DataAccess.Handlers482;
using Export.Models;
using GalaxyWorks.Events77;
using Imaging.Service;
using Import.Validators;
using Notifications.Validators252;
using Portal.Tests;
using Scheduling.Contracts425;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors;
using Workflow.Client47;

namespace BatchJobs.Validators
{
    public class BatchJobs_Validators_Factory
    {
        public void Execute()
        {
            // BatchJobs_Validators_Factory implementation
        }

/// <summary>
/// Validates the Factory before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateFactory(FactoryRequest input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Factory));
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
/// Processes the Factory operation asynchronously.
/// </summary>
public async Task<FactoryResult> ProcessFactoryAsync(
    FactoryRequest request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Factory), request.Id);

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
            return new FactoryResult { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Factory));
        return new FactoryResult { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Factory));
        return new FactoryResult { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Factory entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<FactoryDto>> GetFactoryListAsync(
    FactoryFilter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<FactoryEntity>().AsQueryable();

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
        .Select(x => new FactoryDto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<FactoryDto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<FactoryService> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public FactoryService(
    ILogger<FactoryService> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Factory:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Factory instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<FactoryData> GetCachedFactoryAsync(string key)
{
    var cacheKey = $"Factory_{key}";

    if (_cache.TryGetValue(cacheKey, out FactoryData cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromFactorySourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Item33Id { get; set; }
public string Item33Name { get; set; }
public string Item33Description { get; set; }
public DateTime Item33CreatedAt { get; set; }
public DateTime? Item33UpdatedAt { get; set; }
public string Item33CreatedBy { get; set; }
public bool IsItem33Active { get; set; }
public int Item33SortOrder { get; set; }


public int Field90Id { get; set; }
public string Field90Name { get; set; }
public string Field90Description { get; set; }
public DateTime Field90CreatedAt { get; set; }
public DateTime? Field90UpdatedAt { get; set; }
public string Field90CreatedBy { get; set; }
public bool IsField90Active { get; set; }
public int Field90SortOrder { get; set; }


public int Attr98Id { get; set; }
public string Attr98Name { get; set; }
public string Attr98Description { get; set; }
public DateTime Attr98CreatedAt { get; set; }
public DateTime? Attr98UpdatedAt { get; set; }
public string Attr98CreatedBy { get; set; }
public bool IsAttr98Active { get; set; }
public int Attr98SortOrder { get; set; }


public int Record90Id { get; set; }
public string Record90Name { get; set; }
public string Record90Description { get; set; }
public DateTime Record90CreatedAt { get; set; }
public DateTime? Record90UpdatedAt { get; set; }
public string Record90CreatedBy { get; set; }
public bool IsRecord90Active { get; set; }
public int Record90SortOrder { get; set; }


public int Field42Id { get; set; }
public string Field42Name { get; set; }
public string Field42Description { get; set; }
public DateTime Field42CreatedAt { get; set; }
public DateTime? Field42UpdatedAt { get; set; }
public string Field42CreatedBy { get; set; }
public bool IsField42Active { get; set; }
public int Field42SortOrder { get; set; }


public int Item92Id { get; set; }
public string Item92Name { get; set; }
public string Item92Description { get; set; }
public DateTime Item92CreatedAt { get; set; }
public DateTime? Item92UpdatedAt { get; set; }
public string Item92CreatedBy { get; set; }
public bool IsItem92Active { get; set; }
public int Item92SortOrder { get; set; }


public int Record23Id { get; set; }
public string Record23Name { get; set; }
public string Record23Description { get; set; }
public DateTime Record23CreatedAt { get; set; }
public DateTime? Record23UpdatedAt { get; set; }
public string Record23CreatedBy { get; set; }
public bool IsRecord23Active { get; set; }
public int Record23SortOrder { get; set; }


public int Field9Id { get; set; }
public string Field9Name { get; set; }
public string Field9Description { get; set; }
public DateTime Field9CreatedAt { get; set; }
public DateTime? Field9UpdatedAt { get; set; }
public string Field9CreatedBy { get; set; }
public bool IsField9Active { get; set; }
public int Field9SortOrder { get; set; }


public int Record40Id { get; set; }
public string Record40Name { get; set; }
public string Record40Description { get; set; }
public DateTime Record40CreatedAt { get; set; }
public DateTime? Record40UpdatedAt { get; set; }
public string Record40CreatedBy { get; set; }
public bool IsRecord40Active { get; set; }
public int Record40SortOrder { get; set; }


public int Attr80Id { get; set; }
public string Attr80Name { get; set; }
public string Attr80Description { get; set; }
public DateTime Attr80CreatedAt { get; set; }
public DateTime? Attr80UpdatedAt { get; set; }
public string Attr80CreatedBy { get; set; }
public bool IsAttr80Active { get; set; }
public int Attr80SortOrder { get; set; }


public int Field50Id { get; set; }
public string Field50Name { get; set; }
public string Field50Description { get; set; }
public DateTime Field50CreatedAt { get; set; }
public DateTime? Field50UpdatedAt { get; set; }
public string Field50CreatedBy { get; set; }
public bool IsField50Active { get; set; }
public int Field50SortOrder { get; set; }


public int Config52Id { get; set; }
public string Config52Name { get; set; }
public string Config52Description { get; set; }
public DateTime Config52CreatedAt { get; set; }
public DateTime? Config52UpdatedAt { get; set; }
public string Config52CreatedBy { get; set; }
public bool IsConfig52Active { get; set; }
public int Config52SortOrder { get; set; }


public int Config76Id { get; set; }
public string Config76Name { get; set; }
public string Config76Description { get; set; }
public DateTime Config76CreatedAt { get; set; }
public DateTime? Config76UpdatedAt { get; set; }
public string Config76CreatedBy { get; set; }
public bool IsConfig76Active { get; set; }
public int Config76SortOrder { get; set; }


public int Item81Id { get; set; }
public string Item81Name { get; set; }
public string Item81Description { get; set; }
public DateTime Item81CreatedAt { get; set; }
public DateTime? Item81UpdatedAt { get; set; }
public string Item81CreatedBy { get; set; }
public bool IsItem81Active { get; set; }
public int Item81SortOrder { get; set; }


public int Record84Id { get; set; }
public string Record84Name { get; set; }
public string Record84Description { get; set; }
public DateTime Record84CreatedAt { get; set; }
public DateTime? Record84UpdatedAt { get; set; }
public string Record84CreatedBy { get; set; }
public bool IsRecord84Active { get; set; }
public int Record84SortOrder { get; set; }


public int Item76Id { get; set; }
public string Item76Name { get; set; }
public string Item76Description { get; set; }
public DateTime Item76CreatedAt { get; set; }
public DateTime? Item76UpdatedAt { get; set; }
public string Item76CreatedBy { get; set; }
public bool IsItem76Active { get; set; }
public int Item76SortOrder { get; set; }


public int Detail81Id { get; set; }
public string Detail81Name { get; set; }
public string Detail81Description { get; set; }
public DateTime Detail81CreatedAt { get; set; }
public DateTime? Detail81UpdatedAt { get; set; }
public string Detail81CreatedBy { get; set; }
public bool IsDetail81Active { get; set; }
public int Detail81SortOrder { get; set; }


public int Detail13Id { get; set; }
public string Detail13Name { get; set; }
public string Detail13Description { get; set; }
public DateTime Detail13CreatedAt { get; set; }
public DateTime? Detail13UpdatedAt { get; set; }
public string Detail13CreatedBy { get; set; }
public bool IsDetail13Active { get; set; }
public int Detail13SortOrder { get; set; }


public int Entry10Id { get; set; }
public string Entry10Name { get; set; }
public string Entry10Description { get; set; }
public DateTime Entry10CreatedAt { get; set; }
public DateTime? Entry10UpdatedAt { get; set; }
public string Entry10CreatedBy { get; set; }
public bool IsEntry10Active { get; set; }
public int Entry10SortOrder { get; set; }


public int Attr65Id { get; set; }
public string Attr65Name { get; set; }
public string Attr65Description { get; set; }
public DateTime Attr65CreatedAt { get; set; }
public DateTime? Attr65UpdatedAt { get; set; }
public string Attr65CreatedBy { get; set; }
public bool IsAttr65Active { get; set; }
public int Attr65SortOrder { get; set; }


public int Config29Id { get; set; }
public string Config29Name { get; set; }
public string Config29Description { get; set; }
public DateTime Config29CreatedAt { get; set; }
public DateTime? Config29UpdatedAt { get; set; }
public string Config29CreatedBy { get; set; }
public bool IsConfig29Active { get; set; }
public int Config29SortOrder { get; set; }


public int Item97Id { get; set; }
public string Item97Name { get; set; }
public string Item97Description { get; set; }
public DateTime Item97CreatedAt { get; set; }
public DateTime? Item97UpdatedAt { get; set; }
public string Item97CreatedBy { get; set; }
public bool IsItem97Active { get; set; }
public int Item97SortOrder { get; set; }


public int Param33Id { get; set; }
public string Param33Name { get; set; }
public string Param33Description { get; set; }
public DateTime Param33CreatedAt { get; set; }
public DateTime? Param33UpdatedAt { get; set; }
public string Param33CreatedBy { get; set; }
public bool IsParam33Active { get; set; }
public int Param33SortOrder { get; set; }


public int Detail71Id { get; set; }
public string Detail71Name { get; set; }
public string Detail71Description { get; set; }
public DateTime Detail71CreatedAt { get; set; }
public DateTime? Detail71UpdatedAt { get; set; }
public string Detail71CreatedBy { get; set; }
public bool IsDetail71Active { get; set; }
public int Detail71SortOrder { get; set; }


public int Item7Id { get; set; }
public string Item7Name { get; set; }
public string Item7Description { get; set; }
public DateTime Item7CreatedAt { get; set; }
public DateTime? Item7UpdatedAt { get; set; }
public string Item7CreatedBy { get; set; }
public bool IsItem7Active { get; set; }
public int Item7SortOrder { get; set; }


public int Record45Id { get; set; }
public string Record45Name { get; set; }
public string Record45Description { get; set; }
public DateTime Record45CreatedAt { get; set; }
public DateTime? Record45UpdatedAt { get; set; }
public string Record45CreatedBy { get; set; }
public bool IsRecord45Active { get; set; }
public int Record45SortOrder { get; set; }


public int Entry99Id { get; set; }
public string Entry99Name { get; set; }
public string Entry99Description { get; set; }
public DateTime Entry99CreatedAt { get; set; }
public DateTime? Entry99UpdatedAt { get; set; }
public string Entry99CreatedBy { get; set; }
public bool IsEntry99Active { get; set; }
public int Entry99SortOrder { get; set; }


public int Attr6Id { get; set; }
public string Attr6Name { get; set; }
public string Attr6Description { get; set; }
public DateTime Attr6CreatedAt { get; set; }
public DateTime? Attr6UpdatedAt { get; set; }
public string Attr6CreatedBy { get; set; }
public bool IsAttr6Active { get; set; }
public int Attr6SortOrder { get; set; }


public int Entry74Id { get; set; }
public string Entry74Name { get; set; }
public string Entry74Description { get; set; }
public DateTime Entry74CreatedAt { get; set; }
public DateTime? Entry74UpdatedAt { get; set; }
public string Entry74CreatedBy { get; set; }
public bool IsEntry74Active { get; set; }
public int Entry74SortOrder { get; set; }


public int Field62Id { get; set; }
public string Field62Name { get; set; }
public string Field62Description { get; set; }
public DateTime Field62CreatedAt { get; set; }
public DateTime? Field62UpdatedAt { get; set; }
public string Field62CreatedBy { get; set; }
public bool IsField62Active { get; set; }
public int Field62SortOrder { get; set; }


public int Config15Id { get; set; }
public string Config15Name { get; set; }
public string Config15Description { get; set; }
public DateTime Config15CreatedAt { get; set; }
public DateTime? Config15UpdatedAt { get; set; }
public string Config15CreatedBy { get; set; }
public bool IsConfig15Active { get; set; }
public int Config15SortOrder { get; set; }


public int Config19Id { get; set; }
public string Config19Name { get; set; }
public string Config19Description { get; set; }
public DateTime Config19CreatedAt { get; set; }
public DateTime? Config19UpdatedAt { get; set; }
public string Config19CreatedBy { get; set; }
public bool IsConfig19Active { get; set; }
public int Config19SortOrder { get; set; }


public int Entry41Id { get; set; }
public string Entry41Name { get; set; }
public string Entry41Description { get; set; }
public DateTime Entry41CreatedAt { get; set; }
public DateTime? Entry41UpdatedAt { get; set; }
public string Entry41CreatedBy { get; set; }
public bool IsEntry41Active { get; set; }
public int Entry41SortOrder { get; set; }


public int Attr32Id { get; set; }
public string Attr32Name { get; set; }
public string Attr32Description { get; set; }
public DateTime Attr32CreatedAt { get; set; }
public DateTime? Attr32UpdatedAt { get; set; }
public string Attr32CreatedBy { get; set; }
public bool IsAttr32Active { get; set; }
public int Attr32SortOrder { get; set; }


public int Attr79Id { get; set; }
public string Attr79Name { get; set; }
public string Attr79Description { get; set; }
public DateTime Attr79CreatedAt { get; set; }
public DateTime? Attr79UpdatedAt { get; set; }
public string Attr79CreatedBy { get; set; }
public bool IsAttr79Active { get; set; }
public int Attr79SortOrder { get; set; }


public int Item26Id { get; set; }
public string Item26Name { get; set; }
public string Item26Description { get; set; }
public DateTime Item26CreatedAt { get; set; }
public DateTime? Item26UpdatedAt { get; set; }
public string Item26CreatedBy { get; set; }
public bool IsItem26Active { get; set; }
public int Item26SortOrder { get; set; }


public int Param92Id { get; set; }
public string Param92Name { get; set; }
public string Param92Description { get; set; }
public DateTime Param92CreatedAt { get; set; }
public DateTime? Param92UpdatedAt { get; set; }
public string Param92CreatedBy { get; set; }
public bool IsParam92Active { get; set; }
public int Param92SortOrder { get; set; }


public int Config4Id { get; set; }
public string Config4Name { get; set; }
public string Config4Description { get; set; }
public DateTime Config4CreatedAt { get; set; }
public DateTime? Config4UpdatedAt { get; set; }
public string Config4CreatedBy { get; set; }
public bool IsConfig4Active { get; set; }
public int Config4SortOrder { get; set; }


public int Entry20Id { get; set; }
public string Entry20Name { get; set; }
public string Entry20Description { get; set; }
public DateTime Entry20CreatedAt { get; set; }
public DateTime? Entry20UpdatedAt { get; set; }
public string Entry20CreatedBy { get; set; }
public bool IsEntry20Active { get; set; }
public int Entry20SortOrder { get; set; }


public int Entry80Id { get; set; }
public string Entry80Name { get; set; }
public string Entry80Description { get; set; }
public DateTime Entry80CreatedAt { get; set; }
public DateTime? Entry80UpdatedAt { get; set; }
public string Entry80CreatedBy { get; set; }
public bool IsEntry80Active { get; set; }
public int Entry80SortOrder { get; set; }


public int Field42Id { get; set; }
public string Field42Name { get; set; }
public string Field42Description { get; set; }
public DateTime Field42CreatedAt { get; set; }
public DateTime? Field42UpdatedAt { get; set; }
public string Field42CreatedBy { get; set; }
public bool IsField42Active { get; set; }
public int Field42SortOrder { get; set; }


public int Attr42Id { get; set; }
public string Attr42Name { get; set; }
public string Attr42Description { get; set; }
public DateTime Attr42CreatedAt { get; set; }
public DateTime? Attr42UpdatedAt { get; set; }
public string Attr42CreatedBy { get; set; }
public bool IsAttr42Active { get; set; }
public int Attr42SortOrder { get; set; }


public int Field61Id { get; set; }
public string Field61Name { get; set; }
public string Field61Description { get; set; }
public DateTime Field61CreatedAt { get; set; }
public DateTime? Field61UpdatedAt { get; set; }
public string Field61CreatedBy { get; set; }
public bool IsField61Active { get; set; }
public int Field61SortOrder { get; set; }


public int Attr89Id { get; set; }
public string Attr89Name { get; set; }
public string Attr89Description { get; set; }
public DateTime Attr89CreatedAt { get; set; }
public DateTime? Attr89UpdatedAt { get; set; }
public string Attr89CreatedBy { get; set; }
public bool IsAttr89Active { get; set; }
public int Attr89SortOrder { get; set; }


public int Detail32Id { get; set; }
public string Detail32Name { get; set; }
public string Detail32Description { get; set; }
public DateTime Detail32CreatedAt { get; set; }
public DateTime? Detail32UpdatedAt { get; set; }
public string Detail32CreatedBy { get; set; }
public bool IsDetail32Active { get; set; }
public int Detail32SortOrder { get; set; }


public int Entry31Id { get; set; }
public string Entry31Name { get; set; }
public string Entry31Description { get; set; }
public DateTime Entry31CreatedAt { get; set; }
public DateTime? Entry31UpdatedAt { get; set; }
public string Entry31CreatedBy { get; set; }
public bool IsEntry31Active { get; set; }
public int Entry31SortOrder { get; set; }


public int Config28Id { get; set; }
public string Config28Name { get; set; }
public string Config28Description { get; set; }
public DateTime Config28CreatedAt { get; set; }
public DateTime? Config28UpdatedAt { get; set; }
public string Config28CreatedBy { get; set; }
public bool IsConfig28Active { get; set; }
public int Config28SortOrder { get; set; }


public int Attr3Id { get; set; }
public string Attr3Name { get; set; }
public string Attr3Description { get; set; }
public DateTime Attr3CreatedAt { get; set; }
public DateTime? Attr3UpdatedAt { get; set; }
public string Attr3CreatedBy { get; set; }
public bool IsAttr3Active { get; set; }
public int Attr3SortOrder { get; set; }


public int Field67Id { get; set; }
public string Field67Name { get; set; }
public string Field67Description { get; set; }
public DateTime Field67CreatedAt { get; set; }
public DateTime? Field67UpdatedAt { get; set; }
public string Field67CreatedBy { get; set; }
public bool IsField67Active { get; set; }
public int Field67SortOrder { get; set; }


public int Config32Id { get; set; }
public string Config32Name { get; set; }
public string Config32Description { get; set; }
public DateTime Config32CreatedAt { get; set; }
public DateTime? Config32UpdatedAt { get; set; }
public string Config32CreatedBy { get; set; }
public bool IsConfig32Active { get; set; }
public int Config32SortOrder { get; set; }


public int Config94Id { get; set; }
public string Config94Name { get; set; }
public string Config94Description { get; set; }
public DateTime Config94CreatedAt { get; set; }
public DateTime? Config94UpdatedAt { get; set; }
public string Config94CreatedBy { get; set; }
public bool IsConfig94Active { get; set; }
public int Config94SortOrder { get; set; }


public int Entry97Id { get; set; }
public string Entry97Name { get; set; }
public string Entry97Description { get; set; }
public DateTime Entry97CreatedAt { get; set; }
public DateTime? Entry97UpdatedAt { get; set; }
public string Entry97CreatedBy { get; set; }
public bool IsEntry97Active { get; set; }
public int Entry97SortOrder { get; set; }


public int Config11Id { get; set; }
public string Config11Name { get; set; }
public string Config11Description { get; set; }
public DateTime Config11CreatedAt { get; set; }
public DateTime? Config11UpdatedAt { get; set; }
public string Config11CreatedBy { get; set; }
public bool IsConfig11Active { get; set; }
public int Config11SortOrder { get; set; }


public int Field51Id { get; set; }
public string Field51Name { get; set; }
public string Field51Description { get; set; }
public DateTime Field51CreatedAt { get; set; }
public DateTime? Field51UpdatedAt { get; set; }
public string Field51CreatedBy { get; set; }
public bool IsField51Active { get; set; }
public int Field51SortOrder { get; set; }

    }

}