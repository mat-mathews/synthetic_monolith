using Auth.Mappers208;
using BatchJobs.Api212;
using BatchJobs.Client;
using Common.Client53;
using Common.Events280;
using DataAccess.Tests282;
using Export.Processors104;
using Export.Processors449;
using GalaxyWorks.Data;
using Imaging.Core;
using Imaging.Handlers;
using Portal.Events139;
using Scheduling.Models441;
using Scheduling.Web221;
using Security.Validators418;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Shared;

namespace Scheduling.Contracts425
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer22
    {
        private readonly Auth_Mappers208_Request6 _auth_Mappers208_Request6;
        private readonly IBatchJobs_Api212_Validator7 _iBatchJobs_Api212_Validator7;
        private readonly BatchJobs_Api212_Handler9 _batchJobs_Api212_Handler9;
        private readonly GalaxyWorks_Data_Service _galaxyWorks_Data_Service;
        private readonly IGalaxyWorks_Data_Provider3 _iGalaxyWorks_Data_Provider3;
        private readonly GalaxyWorks_Data_Factory4 _galaxyWorks_Data_Factory4;
        private readonly IPortal_Events139_Factory9 _iPortal_Events139_Factory9;
        private readonly Portal_Events139_Helper8 _portal_Events139_Helper8;

        public Consumer22(Auth_Mappers208_Request6 auth_Mappers208_Request6, IBatchJobs_Api212_Validator7 iBatchJobs_Api212_Validator7, BatchJobs_Api212_Handler9 batchJobs_Api212_Handler9, GalaxyWorks_Data_Service galaxyWorks_Data_Service, IGalaxyWorks_Data_Provider3 iGalaxyWorks_Data_Provider3, GalaxyWorks_Data_Factory4 galaxyWorks_Data_Factory4, IPortal_Events139_Factory9 iPortal_Events139_Factory9, Portal_Events139_Helper8 portal_Events139_Helper8)
        {
            _auth_Mappers208_Request6 = auth_Mappers208_Request6 ?? throw new ArgumentNullException(nameof(auth_Mappers208_Request6));
            _iBatchJobs_Api212_Validator7 = iBatchJobs_Api212_Validator7 ?? throw new ArgumentNullException(nameof(iBatchJobs_Api212_Validator7));
            _batchJobs_Api212_Handler9 = batchJobs_Api212_Handler9 ?? throw new ArgumentNullException(nameof(batchJobs_Api212_Handler9));
            _galaxyWorks_Data_Service = galaxyWorks_Data_Service ?? throw new ArgumentNullException(nameof(galaxyWorks_Data_Service));
            _iGalaxyWorks_Data_Provider3 = iGalaxyWorks_Data_Provider3 ?? throw new ArgumentNullException(nameof(iGalaxyWorks_Data_Provider3));
            _galaxyWorks_Data_Factory4 = galaxyWorks_Data_Factory4 ?? throw new ArgumentNullException(nameof(galaxyWorks_Data_Factory4));
            _iPortal_Events139_Factory9 = iPortal_Events139_Factory9 ?? throw new ArgumentNullException(nameof(iPortal_Events139_Factory9));
            _portal_Events139_Helper8 = portal_Events139_Helper8 ?? throw new ArgumentNullException(nameof(portal_Events139_Helper8));
        }

        public Auth_Mappers208_Request6 GetAuth_Mappers208_Request6() => _auth_Mappers208_Request6;
        public IBatchJobs_Api212_Validator7 GetIBatchJobs_Api212_Validator7() => _iBatchJobs_Api212_Validator7;
        public BatchJobs_Api212_Handler9 GetBatchJobs_Api212_Handler9() => _batchJobs_Api212_Handler9;
        public GalaxyWorks_Data_Service GetGalaxyWorks_Data_Service() => _galaxyWorks_Data_Service;
        public IGalaxyWorks_Data_Provider3 GetIGalaxyWorks_Data_Provider3() => _iGalaxyWorks_Data_Provider3;
        public GalaxyWorks_Data_Factory4 GetGalaxyWorks_Data_Factory4() => _galaxyWorks_Data_Factory4;
        public IPortal_Events139_Factory9 GetIPortal_Events139_Factory9() => _iPortal_Events139_Factory9;
        public Portal_Events139_Helper8 GetPortal_Events139_Helper8() => _portal_Events139_Helper8;

/// <summary>
/// Validates the Consumer22 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer22(Consumer22Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer22));
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
/// Processes the Consumer22 operation asynchronously.
/// </summary>
public async Task<Consumer22Result> ProcessConsumer22Async(
    Consumer22Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer22), request.Id);

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
            return new Consumer22Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer22));
        return new Consumer22Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer22));
        return new Consumer22Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer22 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer22Dto>> GetConsumer22ListAsync(
    Consumer22Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer22Entity>().AsQueryable();

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
        .Select(x => new Consumer22Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer22Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer22Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer22Service(
    ILogger<Consumer22Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer22:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer22 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer22Data> GetCachedConsumer22Async(string key)
{
    var cacheKey = $"Consumer22_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer22Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer22SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Detail3Id { get; set; }
public string Detail3Name { get; set; }
public string Detail3Description { get; set; }
public DateTime Detail3CreatedAt { get; set; }
public DateTime? Detail3UpdatedAt { get; set; }
public string Detail3CreatedBy { get; set; }
public bool IsDetail3Active { get; set; }
public int Detail3SortOrder { get; set; }


public int Attr10Id { get; set; }
public string Attr10Name { get; set; }
public string Attr10Description { get; set; }
public DateTime Attr10CreatedAt { get; set; }
public DateTime? Attr10UpdatedAt { get; set; }
public string Attr10CreatedBy { get; set; }
public bool IsAttr10Active { get; set; }
public int Attr10SortOrder { get; set; }


public int Attr97Id { get; set; }
public string Attr97Name { get; set; }
public string Attr97Description { get; set; }
public DateTime Attr97CreatedAt { get; set; }
public DateTime? Attr97UpdatedAt { get; set; }
public string Attr97CreatedBy { get; set; }
public bool IsAttr97Active { get; set; }
public int Attr97SortOrder { get; set; }


public int Param39Id { get; set; }
public string Param39Name { get; set; }
public string Param39Description { get; set; }
public DateTime Param39CreatedAt { get; set; }
public DateTime? Param39UpdatedAt { get; set; }
public string Param39CreatedBy { get; set; }
public bool IsParam39Active { get; set; }
public int Param39SortOrder { get; set; }


public int Item11Id { get; set; }
public string Item11Name { get; set; }
public string Item11Description { get; set; }
public DateTime Item11CreatedAt { get; set; }
public DateTime? Item11UpdatedAt { get; set; }
public string Item11CreatedBy { get; set; }
public bool IsItem11Active { get; set; }
public int Item11SortOrder { get; set; }


public int Attr55Id { get; set; }
public string Attr55Name { get; set; }
public string Attr55Description { get; set; }
public DateTime Attr55CreatedAt { get; set; }
public DateTime? Attr55UpdatedAt { get; set; }
public string Attr55CreatedBy { get; set; }
public bool IsAttr55Active { get; set; }
public int Attr55SortOrder { get; set; }


public int Detail57Id { get; set; }
public string Detail57Name { get; set; }
public string Detail57Description { get; set; }
public DateTime Detail57CreatedAt { get; set; }
public DateTime? Detail57UpdatedAt { get; set; }
public string Detail57CreatedBy { get; set; }
public bool IsDetail57Active { get; set; }
public int Detail57SortOrder { get; set; }


public int Item36Id { get; set; }
public string Item36Name { get; set; }
public string Item36Description { get; set; }
public DateTime Item36CreatedAt { get; set; }
public DateTime? Item36UpdatedAt { get; set; }
public string Item36CreatedBy { get; set; }
public bool IsItem36Active { get; set; }
public int Item36SortOrder { get; set; }


public int Entry44Id { get; set; }
public string Entry44Name { get; set; }
public string Entry44Description { get; set; }
public DateTime Entry44CreatedAt { get; set; }
public DateTime? Entry44UpdatedAt { get; set; }
public string Entry44CreatedBy { get; set; }
public bool IsEntry44Active { get; set; }
public int Entry44SortOrder { get; set; }


public int Param67Id { get; set; }
public string Param67Name { get; set; }
public string Param67Description { get; set; }
public DateTime Param67CreatedAt { get; set; }
public DateTime? Param67UpdatedAt { get; set; }
public string Param67CreatedBy { get; set; }
public bool IsParam67Active { get; set; }
public int Param67SortOrder { get; set; }


public int Config5Id { get; set; }
public string Config5Name { get; set; }
public string Config5Description { get; set; }
public DateTime Config5CreatedAt { get; set; }
public DateTime? Config5UpdatedAt { get; set; }
public string Config5CreatedBy { get; set; }
public bool IsConfig5Active { get; set; }
public int Config5SortOrder { get; set; }


public int Attr10Id { get; set; }
public string Attr10Name { get; set; }
public string Attr10Description { get; set; }
public DateTime Attr10CreatedAt { get; set; }
public DateTime? Attr10UpdatedAt { get; set; }
public string Attr10CreatedBy { get; set; }
public bool IsAttr10Active { get; set; }
public int Attr10SortOrder { get; set; }


public int Item18Id { get; set; }
public string Item18Name { get; set; }
public string Item18Description { get; set; }
public DateTime Item18CreatedAt { get; set; }
public DateTime? Item18UpdatedAt { get; set; }
public string Item18CreatedBy { get; set; }
public bool IsItem18Active { get; set; }
public int Item18SortOrder { get; set; }


public int Detail47Id { get; set; }
public string Detail47Name { get; set; }
public string Detail47Description { get; set; }
public DateTime Detail47CreatedAt { get; set; }
public DateTime? Detail47UpdatedAt { get; set; }
public string Detail47CreatedBy { get; set; }
public bool IsDetail47Active { get; set; }
public int Detail47SortOrder { get; set; }


public int Record87Id { get; set; }
public string Record87Name { get; set; }
public string Record87Description { get; set; }
public DateTime Record87CreatedAt { get; set; }
public DateTime? Record87UpdatedAt { get; set; }
public string Record87CreatedBy { get; set; }
public bool IsRecord87Active { get; set; }
public int Record87SortOrder { get; set; }


public int Detail32Id { get; set; }
public string Detail32Name { get; set; }
public string Detail32Description { get; set; }
public DateTime Detail32CreatedAt { get; set; }
public DateTime? Detail32UpdatedAt { get; set; }
public string Detail32CreatedBy { get; set; }
public bool IsDetail32Active { get; set; }
public int Detail32SortOrder { get; set; }


public int Attr24Id { get; set; }
public string Attr24Name { get; set; }
public string Attr24Description { get; set; }
public DateTime Attr24CreatedAt { get; set; }
public DateTime? Attr24UpdatedAt { get; set; }
public string Attr24CreatedBy { get; set; }
public bool IsAttr24Active { get; set; }
public int Attr24SortOrder { get; set; }


public int Config84Id { get; set; }
public string Config84Name { get; set; }
public string Config84Description { get; set; }
public DateTime Config84CreatedAt { get; set; }
public DateTime? Config84UpdatedAt { get; set; }
public string Config84CreatedBy { get; set; }
public bool IsConfig84Active { get; set; }
public int Config84SortOrder { get; set; }


public int Entry60Id { get; set; }
public string Entry60Name { get; set; }
public string Entry60Description { get; set; }
public DateTime Entry60CreatedAt { get; set; }
public DateTime? Entry60UpdatedAt { get; set; }
public string Entry60CreatedBy { get; set; }
public bool IsEntry60Active { get; set; }
public int Entry60SortOrder { get; set; }


public int Param55Id { get; set; }
public string Param55Name { get; set; }
public string Param55Description { get; set; }
public DateTime Param55CreatedAt { get; set; }
public DateTime? Param55UpdatedAt { get; set; }
public string Param55CreatedBy { get; set; }
public bool IsParam55Active { get; set; }
public int Param55SortOrder { get; set; }


public int Attr59Id { get; set; }
public string Attr59Name { get; set; }
public string Attr59Description { get; set; }
public DateTime Attr59CreatedAt { get; set; }
public DateTime? Attr59UpdatedAt { get; set; }
public string Attr59CreatedBy { get; set; }
public bool IsAttr59Active { get; set; }
public int Attr59SortOrder { get; set; }


public int Attr87Id { get; set; }
public string Attr87Name { get; set; }
public string Attr87Description { get; set; }
public DateTime Attr87CreatedAt { get; set; }
public DateTime? Attr87UpdatedAt { get; set; }
public string Attr87CreatedBy { get; set; }
public bool IsAttr87Active { get; set; }
public int Attr87SortOrder { get; set; }


public int Record49Id { get; set; }
public string Record49Name { get; set; }
public string Record49Description { get; set; }
public DateTime Record49CreatedAt { get; set; }
public DateTime? Record49UpdatedAt { get; set; }
public string Record49CreatedBy { get; set; }
public bool IsRecord49Active { get; set; }
public int Record49SortOrder { get; set; }


public int Param21Id { get; set; }
public string Param21Name { get; set; }
public string Param21Description { get; set; }
public DateTime Param21CreatedAt { get; set; }
public DateTime? Param21UpdatedAt { get; set; }
public string Param21CreatedBy { get; set; }
public bool IsParam21Active { get; set; }
public int Param21SortOrder { get; set; }


public int Record97Id { get; set; }
public string Record97Name { get; set; }
public string Record97Description { get; set; }
public DateTime Record97CreatedAt { get; set; }
public DateTime? Record97UpdatedAt { get; set; }
public string Record97CreatedBy { get; set; }
public bool IsRecord97Active { get; set; }
public int Record97SortOrder { get; set; }


public int Detail72Id { get; set; }
public string Detail72Name { get; set; }
public string Detail72Description { get; set; }
public DateTime Detail72CreatedAt { get; set; }
public DateTime? Detail72UpdatedAt { get; set; }
public string Detail72CreatedBy { get; set; }
public bool IsDetail72Active { get; set; }
public int Detail72SortOrder { get; set; }


public int Detail91Id { get; set; }
public string Detail91Name { get; set; }
public string Detail91Description { get; set; }
public DateTime Detail91CreatedAt { get; set; }
public DateTime? Detail91UpdatedAt { get; set; }
public string Detail91CreatedBy { get; set; }
public bool IsDetail91Active { get; set; }
public int Detail91SortOrder { get; set; }


public int Config69Id { get; set; }
public string Config69Name { get; set; }
public string Config69Description { get; set; }
public DateTime Config69CreatedAt { get; set; }
public DateTime? Config69UpdatedAt { get; set; }
public string Config69CreatedBy { get; set; }
public bool IsConfig69Active { get; set; }
public int Config69SortOrder { get; set; }


public int Attr10Id { get; set; }
public string Attr10Name { get; set; }
public string Attr10Description { get; set; }
public DateTime Attr10CreatedAt { get; set; }
public DateTime? Attr10UpdatedAt { get; set; }
public string Attr10CreatedBy { get; set; }
public bool IsAttr10Active { get; set; }
public int Attr10SortOrder { get; set; }


public int Record46Id { get; set; }
public string Record46Name { get; set; }
public string Record46Description { get; set; }
public DateTime Record46CreatedAt { get; set; }
public DateTime? Record46UpdatedAt { get; set; }
public string Record46CreatedBy { get; set; }
public bool IsRecord46Active { get; set; }
public int Record46SortOrder { get; set; }


public int Entry27Id { get; set; }
public string Entry27Name { get; set; }
public string Entry27Description { get; set; }
public DateTime Entry27CreatedAt { get; set; }
public DateTime? Entry27UpdatedAt { get; set; }
public string Entry27CreatedBy { get; set; }
public bool IsEntry27Active { get; set; }
public int Entry27SortOrder { get; set; }


public int Entry8Id { get; set; }
public string Entry8Name { get; set; }
public string Entry8Description { get; set; }
public DateTime Entry8CreatedAt { get; set; }
public DateTime? Entry8UpdatedAt { get; set; }
public string Entry8CreatedBy { get; set; }
public bool IsEntry8Active { get; set; }
public int Entry8SortOrder { get; set; }


public int Config88Id { get; set; }
public string Config88Name { get; set; }
public string Config88Description { get; set; }
public DateTime Config88CreatedAt { get; set; }
public DateTime? Config88UpdatedAt { get; set; }
public string Config88CreatedBy { get; set; }
public bool IsConfig88Active { get; set; }
public int Config88SortOrder { get; set; }


public int Item25Id { get; set; }
public string Item25Name { get; set; }
public string Item25Description { get; set; }
public DateTime Item25CreatedAt { get; set; }
public DateTime? Item25UpdatedAt { get; set; }
public string Item25CreatedBy { get; set; }
public bool IsItem25Active { get; set; }
public int Item25SortOrder { get; set; }


public int Entry89Id { get; set; }
public string Entry89Name { get; set; }
public string Entry89Description { get; set; }
public DateTime Entry89CreatedAt { get; set; }
public DateTime? Entry89UpdatedAt { get; set; }
public string Entry89CreatedBy { get; set; }
public bool IsEntry89Active { get; set; }
public int Entry89SortOrder { get; set; }


public int Item15Id { get; set; }
public string Item15Name { get; set; }
public string Item15Description { get; set; }
public DateTime Item15CreatedAt { get; set; }
public DateTime? Item15UpdatedAt { get; set; }
public string Item15CreatedBy { get; set; }
public bool IsItem15Active { get; set; }
public int Item15SortOrder { get; set; }


public int Record16Id { get; set; }
public string Record16Name { get; set; }
public string Record16Description { get; set; }
public DateTime Record16CreatedAt { get; set; }
public DateTime? Record16UpdatedAt { get; set; }
public string Record16CreatedBy { get; set; }
public bool IsRecord16Active { get; set; }
public int Record16SortOrder { get; set; }


public int Detail20Id { get; set; }
public string Detail20Name { get; set; }
public string Detail20Description { get; set; }
public DateTime Detail20CreatedAt { get; set; }
public DateTime? Detail20UpdatedAt { get; set; }
public string Detail20CreatedBy { get; set; }
public bool IsDetail20Active { get; set; }
public int Detail20SortOrder { get; set; }


public int Record68Id { get; set; }
public string Record68Name { get; set; }
public string Record68Description { get; set; }
public DateTime Record68CreatedAt { get; set; }
public DateTime? Record68UpdatedAt { get; set; }
public string Record68CreatedBy { get; set; }
public bool IsRecord68Active { get; set; }
public int Record68SortOrder { get; set; }


public int Entry64Id { get; set; }
public string Entry64Name { get; set; }
public string Entry64Description { get; set; }
public DateTime Entry64CreatedAt { get; set; }
public DateTime? Entry64UpdatedAt { get; set; }
public string Entry64CreatedBy { get; set; }
public bool IsEntry64Active { get; set; }
public int Entry64SortOrder { get; set; }


public int Config90Id { get; set; }
public string Config90Name { get; set; }
public string Config90Description { get; set; }
public DateTime Config90CreatedAt { get; set; }
public DateTime? Config90UpdatedAt { get; set; }
public string Config90CreatedBy { get; set; }
public bool IsConfig90Active { get; set; }
public int Config90SortOrder { get; set; }


public int Config88Id { get; set; }
public string Config88Name { get; set; }
public string Config88Description { get; set; }
public DateTime Config88CreatedAt { get; set; }
public DateTime? Config88UpdatedAt { get; set; }
public string Config88CreatedBy { get; set; }
public bool IsConfig88Active { get; set; }
public int Config88SortOrder { get; set; }


public int Detail18Id { get; set; }
public string Detail18Name { get; set; }
public string Detail18Description { get; set; }
public DateTime Detail18CreatedAt { get; set; }
public DateTime? Detail18UpdatedAt { get; set; }
public string Detail18CreatedBy { get; set; }
public bool IsDetail18Active { get; set; }
public int Detail18SortOrder { get; set; }


public int Item87Id { get; set; }
public string Item87Name { get; set; }
public string Item87Description { get; set; }
public DateTime Item87CreatedAt { get; set; }
public DateTime? Item87UpdatedAt { get; set; }
public string Item87CreatedBy { get; set; }
public bool IsItem87Active { get; set; }
public int Item87SortOrder { get; set; }


public int Item4Id { get; set; }
public string Item4Name { get; set; }
public string Item4Description { get; set; }
public DateTime Item4CreatedAt { get; set; }
public DateTime? Item4UpdatedAt { get; set; }
public string Item4CreatedBy { get; set; }
public bool IsItem4Active { get; set; }
public int Item4SortOrder { get; set; }

    }
}