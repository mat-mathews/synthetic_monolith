using Auth.Client;
using Auth.Events5;
using Auth.Handlers467;
using Auth.Models236;
using Billing.Client182;
using DataAccess.Api341;
using DataAccess.Tests282;
using Imaging.Shared115;
using Import.Handlers407;
using Integration.Data;
using Integration.Tests45;
using Logging.Service;
using Notifications.Service475;
using Reporting.Contracts371;
using Reporting.Service;
using Scheduling.Models342;
using Scheduling.Service211;
using Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Billing.Handlers101
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer23
    {
        private readonly Auth_Models236_Point _auth_Models236_Point;
        private readonly Auth_Events5_Controller14 _auth_Events5_Controller14;
        private readonly Auth_Events5_Options12 _auth_Events5_Options12;
        private readonly Auth_Events5_Manager4 _auth_Events5_Manager4;
        private readonly Auth_Client_Result12 _auth_Client_Result12;
        private readonly Auth_Client_Response2 _auth_Client_Response2;
        private readonly IReporting_Service_Factory _iReporting_Service_Factory;
        private readonly Reporting_Service_Handler2 _reporting_Service_Handler2;

        public Consumer23(Auth_Models236_Point auth_Models236_Point, Auth_Events5_Controller14 auth_Events5_Controller14, Auth_Events5_Options12 auth_Events5_Options12, Auth_Events5_Manager4 auth_Events5_Manager4, Auth_Client_Result12 auth_Client_Result12, Auth_Client_Response2 auth_Client_Response2, IReporting_Service_Factory iReporting_Service_Factory, Reporting_Service_Handler2 reporting_Service_Handler2)
        {
            _auth_Models236_Point = auth_Models236_Point ?? throw new ArgumentNullException(nameof(auth_Models236_Point));
            _auth_Events5_Controller14 = auth_Events5_Controller14 ?? throw new ArgumentNullException(nameof(auth_Events5_Controller14));
            _auth_Events5_Options12 = auth_Events5_Options12 ?? throw new ArgumentNullException(nameof(auth_Events5_Options12));
            _auth_Events5_Manager4 = auth_Events5_Manager4 ?? throw new ArgumentNullException(nameof(auth_Events5_Manager4));
            _auth_Client_Result12 = auth_Client_Result12 ?? throw new ArgumentNullException(nameof(auth_Client_Result12));
            _auth_Client_Response2 = auth_Client_Response2 ?? throw new ArgumentNullException(nameof(auth_Client_Response2));
            _iReporting_Service_Factory = iReporting_Service_Factory ?? throw new ArgumentNullException(nameof(iReporting_Service_Factory));
            _reporting_Service_Handler2 = reporting_Service_Handler2 ?? throw new ArgumentNullException(nameof(reporting_Service_Handler2));
        }

        public Auth_Models236_Point GetAuth_Models236_Point() => _auth_Models236_Point;
        public Auth_Events5_Controller14 GetAuth_Events5_Controller14() => _auth_Events5_Controller14;
        public Auth_Events5_Options12 GetAuth_Events5_Options12() => _auth_Events5_Options12;
        public Auth_Events5_Manager4 GetAuth_Events5_Manager4() => _auth_Events5_Manager4;
        public Auth_Client_Result12 GetAuth_Client_Result12() => _auth_Client_Result12;
        public Auth_Client_Response2 GetAuth_Client_Response2() => _auth_Client_Response2;
        public IReporting_Service_Factory GetIReporting_Service_Factory() => _iReporting_Service_Factory;
        public Reporting_Service_Handler2 GetReporting_Service_Handler2() => _reporting_Service_Handler2;

/// <summary>
/// Validates the Consumer23 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer23(Consumer23Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer23));
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
/// Processes the Consumer23 operation asynchronously.
/// </summary>
public async Task<Consumer23Result> ProcessConsumer23Async(
    Consumer23Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer23), request.Id);

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
            return new Consumer23Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer23));
        return new Consumer23Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer23));
        return new Consumer23Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer23 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer23Dto>> GetConsumer23ListAsync(
    Consumer23Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer23Entity>().AsQueryable();

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
        .Select(x => new Consumer23Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer23Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer23Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer23Service(
    ILogger<Consumer23Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer23:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer23 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer23Data> GetCachedConsumer23Async(string key)
{
    var cacheKey = $"Consumer23_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer23Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer23SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Param46Id { get; set; }
public string Param46Name { get; set; }
public string Param46Description { get; set; }
public DateTime Param46CreatedAt { get; set; }
public DateTime? Param46UpdatedAt { get; set; }
public string Param46CreatedBy { get; set; }
public bool IsParam46Active { get; set; }
public int Param46SortOrder { get; set; }


public int Record92Id { get; set; }
public string Record92Name { get; set; }
public string Record92Description { get; set; }
public DateTime Record92CreatedAt { get; set; }
public DateTime? Record92UpdatedAt { get; set; }
public string Record92CreatedBy { get; set; }
public bool IsRecord92Active { get; set; }
public int Record92SortOrder { get; set; }


public int Detail63Id { get; set; }
public string Detail63Name { get; set; }
public string Detail63Description { get; set; }
public DateTime Detail63CreatedAt { get; set; }
public DateTime? Detail63UpdatedAt { get; set; }
public string Detail63CreatedBy { get; set; }
public bool IsDetail63Active { get; set; }
public int Detail63SortOrder { get; set; }


public int Record39Id { get; set; }
public string Record39Name { get; set; }
public string Record39Description { get; set; }
public DateTime Record39CreatedAt { get; set; }
public DateTime? Record39UpdatedAt { get; set; }
public string Record39CreatedBy { get; set; }
public bool IsRecord39Active { get; set; }
public int Record39SortOrder { get; set; }


public int Attr97Id { get; set; }
public string Attr97Name { get; set; }
public string Attr97Description { get; set; }
public DateTime Attr97CreatedAt { get; set; }
public DateTime? Attr97UpdatedAt { get; set; }
public string Attr97CreatedBy { get; set; }
public bool IsAttr97Active { get; set; }
public int Attr97SortOrder { get; set; }


public int Field32Id { get; set; }
public string Field32Name { get; set; }
public string Field32Description { get; set; }
public DateTime Field32CreatedAt { get; set; }
public DateTime? Field32UpdatedAt { get; set; }
public string Field32CreatedBy { get; set; }
public bool IsField32Active { get; set; }
public int Field32SortOrder { get; set; }


public int Param82Id { get; set; }
public string Param82Name { get; set; }
public string Param82Description { get; set; }
public DateTime Param82CreatedAt { get; set; }
public DateTime? Param82UpdatedAt { get; set; }
public string Param82CreatedBy { get; set; }
public bool IsParam82Active { get; set; }
public int Param82SortOrder { get; set; }


public int Field25Id { get; set; }
public string Field25Name { get; set; }
public string Field25Description { get; set; }
public DateTime Field25CreatedAt { get; set; }
public DateTime? Field25UpdatedAt { get; set; }
public string Field25CreatedBy { get; set; }
public bool IsField25Active { get; set; }
public int Field25SortOrder { get; set; }


public int Attr49Id { get; set; }
public string Attr49Name { get; set; }
public string Attr49Description { get; set; }
public DateTime Attr49CreatedAt { get; set; }
public DateTime? Attr49UpdatedAt { get; set; }
public string Attr49CreatedBy { get; set; }
public bool IsAttr49Active { get; set; }
public int Attr49SortOrder { get; set; }


public int Attr77Id { get; set; }
public string Attr77Name { get; set; }
public string Attr77Description { get; set; }
public DateTime Attr77CreatedAt { get; set; }
public DateTime? Attr77UpdatedAt { get; set; }
public string Attr77CreatedBy { get; set; }
public bool IsAttr77Active { get; set; }
public int Attr77SortOrder { get; set; }


public int Item78Id { get; set; }
public string Item78Name { get; set; }
public string Item78Description { get; set; }
public DateTime Item78CreatedAt { get; set; }
public DateTime? Item78UpdatedAt { get; set; }
public string Item78CreatedBy { get; set; }
public bool IsItem78Active { get; set; }
public int Item78SortOrder { get; set; }


public int Attr6Id { get; set; }
public string Attr6Name { get; set; }
public string Attr6Description { get; set; }
public DateTime Attr6CreatedAt { get; set; }
public DateTime? Attr6UpdatedAt { get; set; }
public string Attr6CreatedBy { get; set; }
public bool IsAttr6Active { get; set; }
public int Attr6SortOrder { get; set; }


public int Attr24Id { get; set; }
public string Attr24Name { get; set; }
public string Attr24Description { get; set; }
public DateTime Attr24CreatedAt { get; set; }
public DateTime? Attr24UpdatedAt { get; set; }
public string Attr24CreatedBy { get; set; }
public bool IsAttr24Active { get; set; }
public int Attr24SortOrder { get; set; }


public int Entry50Id { get; set; }
public string Entry50Name { get; set; }
public string Entry50Description { get; set; }
public DateTime Entry50CreatedAt { get; set; }
public DateTime? Entry50UpdatedAt { get; set; }
public string Entry50CreatedBy { get; set; }
public bool IsEntry50Active { get; set; }
public int Entry50SortOrder { get; set; }


public int Item92Id { get; set; }
public string Item92Name { get; set; }
public string Item92Description { get; set; }
public DateTime Item92CreatedAt { get; set; }
public DateTime? Item92UpdatedAt { get; set; }
public string Item92CreatedBy { get; set; }
public bool IsItem92Active { get; set; }
public int Item92SortOrder { get; set; }


public int Config92Id { get; set; }
public string Config92Name { get; set; }
public string Config92Description { get; set; }
public DateTime Config92CreatedAt { get; set; }
public DateTime? Config92UpdatedAt { get; set; }
public string Config92CreatedBy { get; set; }
public bool IsConfig92Active { get; set; }
public int Config92SortOrder { get; set; }


public int Item18Id { get; set; }
public string Item18Name { get; set; }
public string Item18Description { get; set; }
public DateTime Item18CreatedAt { get; set; }
public DateTime? Item18UpdatedAt { get; set; }
public string Item18CreatedBy { get; set; }
public bool IsItem18Active { get; set; }
public int Item18SortOrder { get; set; }


public int Record6Id { get; set; }
public string Record6Name { get; set; }
public string Record6Description { get; set; }
public DateTime Record6CreatedAt { get; set; }
public DateTime? Record6UpdatedAt { get; set; }
public string Record6CreatedBy { get; set; }
public bool IsRecord6Active { get; set; }
public int Record6SortOrder { get; set; }


public int Config47Id { get; set; }
public string Config47Name { get; set; }
public string Config47Description { get; set; }
public DateTime Config47CreatedAt { get; set; }
public DateTime? Config47UpdatedAt { get; set; }
public string Config47CreatedBy { get; set; }
public bool IsConfig47Active { get; set; }
public int Config47SortOrder { get; set; }


public int Item45Id { get; set; }
public string Item45Name { get; set; }
public string Item45Description { get; set; }
public DateTime Item45CreatedAt { get; set; }
public DateTime? Item45UpdatedAt { get; set; }
public string Item45CreatedBy { get; set; }
public bool IsItem45Active { get; set; }
public int Item45SortOrder { get; set; }


public int Param31Id { get; set; }
public string Param31Name { get; set; }
public string Param31Description { get; set; }
public DateTime Param31CreatedAt { get; set; }
public DateTime? Param31UpdatedAt { get; set; }
public string Param31CreatedBy { get; set; }
public bool IsParam31Active { get; set; }
public int Param31SortOrder { get; set; }


public int Field91Id { get; set; }
public string Field91Name { get; set; }
public string Field91Description { get; set; }
public DateTime Field91CreatedAt { get; set; }
public DateTime? Field91UpdatedAt { get; set; }
public string Field91CreatedBy { get; set; }
public bool IsField91Active { get; set; }
public int Field91SortOrder { get; set; }


public int Config55Id { get; set; }
public string Config55Name { get; set; }
public string Config55Description { get; set; }
public DateTime Config55CreatedAt { get; set; }
public DateTime? Config55UpdatedAt { get; set; }
public string Config55CreatedBy { get; set; }
public bool IsConfig55Active { get; set; }
public int Config55SortOrder { get; set; }


public int Param92Id { get; set; }
public string Param92Name { get; set; }
public string Param92Description { get; set; }
public DateTime Param92CreatedAt { get; set; }
public DateTime? Param92UpdatedAt { get; set; }
public string Param92CreatedBy { get; set; }
public bool IsParam92Active { get; set; }
public int Param92SortOrder { get; set; }


public int Entry25Id { get; set; }
public string Entry25Name { get; set; }
public string Entry25Description { get; set; }
public DateTime Entry25CreatedAt { get; set; }
public DateTime? Entry25UpdatedAt { get; set; }
public string Entry25CreatedBy { get; set; }
public bool IsEntry25Active { get; set; }
public int Entry25SortOrder { get; set; }


public int Entry68Id { get; set; }
public string Entry68Name { get; set; }
public string Entry68Description { get; set; }
public DateTime Entry68CreatedAt { get; set; }
public DateTime? Entry68UpdatedAt { get; set; }
public string Entry68CreatedBy { get; set; }
public bool IsEntry68Active { get; set; }
public int Entry68SortOrder { get; set; }


public int Config71Id { get; set; }
public string Config71Name { get; set; }
public string Config71Description { get; set; }
public DateTime Config71CreatedAt { get; set; }
public DateTime? Config71UpdatedAt { get; set; }
public string Config71CreatedBy { get; set; }
public bool IsConfig71Active { get; set; }
public int Config71SortOrder { get; set; }


public int Record94Id { get; set; }
public string Record94Name { get; set; }
public string Record94Description { get; set; }
public DateTime Record94CreatedAt { get; set; }
public DateTime? Record94UpdatedAt { get; set; }
public string Record94CreatedBy { get; set; }
public bool IsRecord94Active { get; set; }
public int Record94SortOrder { get; set; }


public int Attr78Id { get; set; }
public string Attr78Name { get; set; }
public string Attr78Description { get; set; }
public DateTime Attr78CreatedAt { get; set; }
public DateTime? Attr78UpdatedAt { get; set; }
public string Attr78CreatedBy { get; set; }
public bool IsAttr78Active { get; set; }
public int Attr78SortOrder { get; set; }


public int Entry53Id { get; set; }
public string Entry53Name { get; set; }
public string Entry53Description { get; set; }
public DateTime Entry53CreatedAt { get; set; }
public DateTime? Entry53UpdatedAt { get; set; }
public string Entry53CreatedBy { get; set; }
public bool IsEntry53Active { get; set; }
public int Entry53SortOrder { get; set; }


public int Detail57Id { get; set; }
public string Detail57Name { get; set; }
public string Detail57Description { get; set; }
public DateTime Detail57CreatedAt { get; set; }
public DateTime? Detail57UpdatedAt { get; set; }
public string Detail57CreatedBy { get; set; }
public bool IsDetail57Active { get; set; }
public int Detail57SortOrder { get; set; }


public int Config24Id { get; set; }
public string Config24Name { get; set; }
public string Config24Description { get; set; }
public DateTime Config24CreatedAt { get; set; }
public DateTime? Config24UpdatedAt { get; set; }
public string Config24CreatedBy { get; set; }
public bool IsConfig24Active { get; set; }
public int Config24SortOrder { get; set; }


public int Attr64Id { get; set; }
public string Attr64Name { get; set; }
public string Attr64Description { get; set; }
public DateTime Attr64CreatedAt { get; set; }
public DateTime? Attr64UpdatedAt { get; set; }
public string Attr64CreatedBy { get; set; }
public bool IsAttr64Active { get; set; }
public int Attr64SortOrder { get; set; }


public int Attr52Id { get; set; }
public string Attr52Name { get; set; }
public string Attr52Description { get; set; }
public DateTime Attr52CreatedAt { get; set; }
public DateTime? Attr52UpdatedAt { get; set; }
public string Attr52CreatedBy { get; set; }
public bool IsAttr52Active { get; set; }
public int Attr52SortOrder { get; set; }


public int Detail48Id { get; set; }
public string Detail48Name { get; set; }
public string Detail48Description { get; set; }
public DateTime Detail48CreatedAt { get; set; }
public DateTime? Detail48UpdatedAt { get; set; }
public string Detail48CreatedBy { get; set; }
public bool IsDetail48Active { get; set; }
public int Detail48SortOrder { get; set; }


public int Item95Id { get; set; }
public string Item95Name { get; set; }
public string Item95Description { get; set; }
public DateTime Item95CreatedAt { get; set; }
public DateTime? Item95UpdatedAt { get; set; }
public string Item95CreatedBy { get; set; }
public bool IsItem95Active { get; set; }
public int Item95SortOrder { get; set; }


public int Attr58Id { get; set; }
public string Attr58Name { get; set; }
public string Attr58Description { get; set; }
public DateTime Attr58CreatedAt { get; set; }
public DateTime? Attr58UpdatedAt { get; set; }
public string Attr58CreatedBy { get; set; }
public bool IsAttr58Active { get; set; }
public int Attr58SortOrder { get; set; }


public int Param34Id { get; set; }
public string Param34Name { get; set; }
public string Param34Description { get; set; }
public DateTime Param34CreatedAt { get; set; }
public DateTime? Param34UpdatedAt { get; set; }
public string Param34CreatedBy { get; set; }
public bool IsParam34Active { get; set; }
public int Param34SortOrder { get; set; }


public int Field70Id { get; set; }
public string Field70Name { get; set; }
public string Field70Description { get; set; }
public DateTime Field70CreatedAt { get; set; }
public DateTime? Field70UpdatedAt { get; set; }
public string Field70CreatedBy { get; set; }
public bool IsField70Active { get; set; }
public int Field70SortOrder { get; set; }


public int Field76Id { get; set; }
public string Field76Name { get; set; }
public string Field76Description { get; set; }
public DateTime Field76CreatedAt { get; set; }
public DateTime? Field76UpdatedAt { get; set; }
public string Field76CreatedBy { get; set; }
public bool IsField76Active { get; set; }
public int Field76SortOrder { get; set; }


public int Config55Id { get; set; }
public string Config55Name { get; set; }
public string Config55Description { get; set; }
public DateTime Config55CreatedAt { get; set; }
public DateTime? Config55UpdatedAt { get; set; }
public string Config55CreatedBy { get; set; }
public bool IsConfig55Active { get; set; }
public int Config55SortOrder { get; set; }


public int Field17Id { get; set; }
public string Field17Name { get; set; }
public string Field17Description { get; set; }
public DateTime Field17CreatedAt { get; set; }
public DateTime? Field17UpdatedAt { get; set; }
public string Field17CreatedBy { get; set; }
public bool IsField17Active { get; set; }
public int Field17SortOrder { get; set; }


public int Config48Id { get; set; }
public string Config48Name { get; set; }
public string Config48Description { get; set; }
public DateTime Config48CreatedAt { get; set; }
public DateTime? Config48UpdatedAt { get; set; }
public string Config48CreatedBy { get; set; }
public bool IsConfig48Active { get; set; }
public int Config48SortOrder { get; set; }


public int Attr49Id { get; set; }
public string Attr49Name { get; set; }
public string Attr49Description { get; set; }
public DateTime Attr49CreatedAt { get; set; }
public DateTime? Attr49UpdatedAt { get; set; }
public string Attr49CreatedBy { get; set; }
public bool IsAttr49Active { get; set; }
public int Attr49SortOrder { get; set; }


public int Param88Id { get; set; }
public string Param88Name { get; set; }
public string Param88Description { get; set; }
public DateTime Param88CreatedAt { get; set; }
public DateTime? Param88UpdatedAt { get; set; }
public string Param88CreatedBy { get; set; }
public bool IsParam88Active { get; set; }
public int Param88SortOrder { get; set; }


public int Record81Id { get; set; }
public string Record81Name { get; set; }
public string Record81Description { get; set; }
public DateTime Record81CreatedAt { get; set; }
public DateTime? Record81UpdatedAt { get; set; }
public string Record81CreatedBy { get; set; }
public bool IsRecord81Active { get; set; }
public int Record81SortOrder { get; set; }

    }
}