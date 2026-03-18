using Admin.Core121;
using Auth.Core2;
using Auth.Events5;
using Billing.Events;
using Billing.Tests194;
using Billing.Web;
using GalaxyWorks.Api390;
using Imaging.Shared338;
using Integration.Contracts;
using Logging.Service;
using Logging.Tests;
using Notifications.Client257;
using Notifications.Shared396;
using Portal.Api;
using Portal.Tests481;
using Reporting.Tests226;
using Scheduling.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Data;

namespace Auth.Service
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer22
    {
        private readonly Auth_Core2_Command7 _auth_Core2_Command7;
        private readonly Auth_Core2_Service _auth_Core2_Service;
        private readonly Auth_Events5_Range8 _auth_Events5_Range8;
        private readonly Auth_Events5_Controller14 _auth_Events5_Controller14;
        private readonly IReporting_Tests226_Factory2 _iReporting_Tests226_Factory2;
        private readonly Notifications_Shared396_Factory4 _notifications_Shared396_Factory4;
        private readonly Notifications_Shared396_Service2 _notifications_Shared396_Service2;
        private readonly INotifications_Shared396_Provider1 _iNotifications_Shared396_Provider1;

        public Consumer22(Auth_Core2_Command7 auth_Core2_Command7, Auth_Core2_Service auth_Core2_Service, Auth_Events5_Range8 auth_Events5_Range8, Auth_Events5_Controller14 auth_Events5_Controller14, IReporting_Tests226_Factory2 iReporting_Tests226_Factory2, Notifications_Shared396_Factory4 notifications_Shared396_Factory4, Notifications_Shared396_Service2 notifications_Shared396_Service2, INotifications_Shared396_Provider1 iNotifications_Shared396_Provider1)
        {
            _auth_Core2_Command7 = auth_Core2_Command7 ?? throw new ArgumentNullException(nameof(auth_Core2_Command7));
            _auth_Core2_Service = auth_Core2_Service ?? throw new ArgumentNullException(nameof(auth_Core2_Service));
            _auth_Events5_Range8 = auth_Events5_Range8 ?? throw new ArgumentNullException(nameof(auth_Events5_Range8));
            _auth_Events5_Controller14 = auth_Events5_Controller14 ?? throw new ArgumentNullException(nameof(auth_Events5_Controller14));
            _iReporting_Tests226_Factory2 = iReporting_Tests226_Factory2 ?? throw new ArgumentNullException(nameof(iReporting_Tests226_Factory2));
            _notifications_Shared396_Factory4 = notifications_Shared396_Factory4 ?? throw new ArgumentNullException(nameof(notifications_Shared396_Factory4));
            _notifications_Shared396_Service2 = notifications_Shared396_Service2 ?? throw new ArgumentNullException(nameof(notifications_Shared396_Service2));
            _iNotifications_Shared396_Provider1 = iNotifications_Shared396_Provider1 ?? throw new ArgumentNullException(nameof(iNotifications_Shared396_Provider1));
        }

        public Auth_Core2_Command7 GetAuth_Core2_Command7() => _auth_Core2_Command7;
        public Auth_Core2_Service GetAuth_Core2_Service() => _auth_Core2_Service;
        public Auth_Events5_Range8 GetAuth_Events5_Range8() => _auth_Events5_Range8;
        public Auth_Events5_Controller14 GetAuth_Events5_Controller14() => _auth_Events5_Controller14;
        public IReporting_Tests226_Factory2 GetIReporting_Tests226_Factory2() => _iReporting_Tests226_Factory2;
        public Notifications_Shared396_Factory4 GetNotifications_Shared396_Factory4() => _notifications_Shared396_Factory4;
        public Notifications_Shared396_Service2 GetNotifications_Shared396_Service2() => _notifications_Shared396_Service2;
        public INotifications_Shared396_Provider1 GetINotifications_Shared396_Provider1() => _iNotifications_Shared396_Provider1;

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

public int Detail50Id { get; set; }
public string Detail50Name { get; set; }
public string Detail50Description { get; set; }
public DateTime Detail50CreatedAt { get; set; }
public DateTime? Detail50UpdatedAt { get; set; }
public string Detail50CreatedBy { get; set; }
public bool IsDetail50Active { get; set; }
public int Detail50SortOrder { get; set; }


public int Record89Id { get; set; }
public string Record89Name { get; set; }
public string Record89Description { get; set; }
public DateTime Record89CreatedAt { get; set; }
public DateTime? Record89UpdatedAt { get; set; }
public string Record89CreatedBy { get; set; }
public bool IsRecord89Active { get; set; }
public int Record89SortOrder { get; set; }


public int Entry93Id { get; set; }
public string Entry93Name { get; set; }
public string Entry93Description { get; set; }
public DateTime Entry93CreatedAt { get; set; }
public DateTime? Entry93UpdatedAt { get; set; }
public string Entry93CreatedBy { get; set; }
public bool IsEntry93Active { get; set; }
public int Entry93SortOrder { get; set; }


public int Config5Id { get; set; }
public string Config5Name { get; set; }
public string Config5Description { get; set; }
public DateTime Config5CreatedAt { get; set; }
public DateTime? Config5UpdatedAt { get; set; }
public string Config5CreatedBy { get; set; }
public bool IsConfig5Active { get; set; }
public int Config5SortOrder { get; set; }


public int Detail55Id { get; set; }
public string Detail55Name { get; set; }
public string Detail55Description { get; set; }
public DateTime Detail55CreatedAt { get; set; }
public DateTime? Detail55UpdatedAt { get; set; }
public string Detail55CreatedBy { get; set; }
public bool IsDetail55Active { get; set; }
public int Detail55SortOrder { get; set; }


public int Item16Id { get; set; }
public string Item16Name { get; set; }
public string Item16Description { get; set; }
public DateTime Item16CreatedAt { get; set; }
public DateTime? Item16UpdatedAt { get; set; }
public string Item16CreatedBy { get; set; }
public bool IsItem16Active { get; set; }
public int Item16SortOrder { get; set; }


public int Entry61Id { get; set; }
public string Entry61Name { get; set; }
public string Entry61Description { get; set; }
public DateTime Entry61CreatedAt { get; set; }
public DateTime? Entry61UpdatedAt { get; set; }
public string Entry61CreatedBy { get; set; }
public bool IsEntry61Active { get; set; }
public int Entry61SortOrder { get; set; }


public int Entry59Id { get; set; }
public string Entry59Name { get; set; }
public string Entry59Description { get; set; }
public DateTime Entry59CreatedAt { get; set; }
public DateTime? Entry59UpdatedAt { get; set; }
public string Entry59CreatedBy { get; set; }
public bool IsEntry59Active { get; set; }
public int Entry59SortOrder { get; set; }


public int Item77Id { get; set; }
public string Item77Name { get; set; }
public string Item77Description { get; set; }
public DateTime Item77CreatedAt { get; set; }
public DateTime? Item77UpdatedAt { get; set; }
public string Item77CreatedBy { get; set; }
public bool IsItem77Active { get; set; }
public int Item77SortOrder { get; set; }


public int Record63Id { get; set; }
public string Record63Name { get; set; }
public string Record63Description { get; set; }
public DateTime Record63CreatedAt { get; set; }
public DateTime? Record63UpdatedAt { get; set; }
public string Record63CreatedBy { get; set; }
public bool IsRecord63Active { get; set; }
public int Record63SortOrder { get; set; }


public int Field6Id { get; set; }
public string Field6Name { get; set; }
public string Field6Description { get; set; }
public DateTime Field6CreatedAt { get; set; }
public DateTime? Field6UpdatedAt { get; set; }
public string Field6CreatedBy { get; set; }
public bool IsField6Active { get; set; }
public int Field6SortOrder { get; set; }


public int Entry88Id { get; set; }
public string Entry88Name { get; set; }
public string Entry88Description { get; set; }
public DateTime Entry88CreatedAt { get; set; }
public DateTime? Entry88UpdatedAt { get; set; }
public string Entry88CreatedBy { get; set; }
public bool IsEntry88Active { get; set; }
public int Entry88SortOrder { get; set; }


public int Config2Id { get; set; }
public string Config2Name { get; set; }
public string Config2Description { get; set; }
public DateTime Config2CreatedAt { get; set; }
public DateTime? Config2UpdatedAt { get; set; }
public string Config2CreatedBy { get; set; }
public bool IsConfig2Active { get; set; }
public int Config2SortOrder { get; set; }


public int Entry89Id { get; set; }
public string Entry89Name { get; set; }
public string Entry89Description { get; set; }
public DateTime Entry89CreatedAt { get; set; }
public DateTime? Entry89UpdatedAt { get; set; }
public string Entry89CreatedBy { get; set; }
public bool IsEntry89Active { get; set; }
public int Entry89SortOrder { get; set; }


public int Field31Id { get; set; }
public string Field31Name { get; set; }
public string Field31Description { get; set; }
public DateTime Field31CreatedAt { get; set; }
public DateTime? Field31UpdatedAt { get; set; }
public string Field31CreatedBy { get; set; }
public bool IsField31Active { get; set; }
public int Field31SortOrder { get; set; }


public int Param99Id { get; set; }
public string Param99Name { get; set; }
public string Param99Description { get; set; }
public DateTime Param99CreatedAt { get; set; }
public DateTime? Param99UpdatedAt { get; set; }
public string Param99CreatedBy { get; set; }
public bool IsParam99Active { get; set; }
public int Param99SortOrder { get; set; }


public int Field71Id { get; set; }
public string Field71Name { get; set; }
public string Field71Description { get; set; }
public DateTime Field71CreatedAt { get; set; }
public DateTime? Field71UpdatedAt { get; set; }
public string Field71CreatedBy { get; set; }
public bool IsField71Active { get; set; }
public int Field71SortOrder { get; set; }


public int Attr76Id { get; set; }
public string Attr76Name { get; set; }
public string Attr76Description { get; set; }
public DateTime Attr76CreatedAt { get; set; }
public DateTime? Attr76UpdatedAt { get; set; }
public string Attr76CreatedBy { get; set; }
public bool IsAttr76Active { get; set; }
public int Attr76SortOrder { get; set; }


public int Param44Id { get; set; }
public string Param44Name { get; set; }
public string Param44Description { get; set; }
public DateTime Param44CreatedAt { get; set; }
public DateTime? Param44UpdatedAt { get; set; }
public string Param44CreatedBy { get; set; }
public bool IsParam44Active { get; set; }
public int Param44SortOrder { get; set; }


public int Entry74Id { get; set; }
public string Entry74Name { get; set; }
public string Entry74Description { get; set; }
public DateTime Entry74CreatedAt { get; set; }
public DateTime? Entry74UpdatedAt { get; set; }
public string Entry74CreatedBy { get; set; }
public bool IsEntry74Active { get; set; }
public int Entry74SortOrder { get; set; }


public int Record5Id { get; set; }
public string Record5Name { get; set; }
public string Record5Description { get; set; }
public DateTime Record5CreatedAt { get; set; }
public DateTime? Record5UpdatedAt { get; set; }
public string Record5CreatedBy { get; set; }
public bool IsRecord5Active { get; set; }
public int Record5SortOrder { get; set; }


public int Item52Id { get; set; }
public string Item52Name { get; set; }
public string Item52Description { get; set; }
public DateTime Item52CreatedAt { get; set; }
public DateTime? Item52UpdatedAt { get; set; }
public string Item52CreatedBy { get; set; }
public bool IsItem52Active { get; set; }
public int Item52SortOrder { get; set; }


public int Entry77Id { get; set; }
public string Entry77Name { get; set; }
public string Entry77Description { get; set; }
public DateTime Entry77CreatedAt { get; set; }
public DateTime? Entry77UpdatedAt { get; set; }
public string Entry77CreatedBy { get; set; }
public bool IsEntry77Active { get; set; }
public int Entry77SortOrder { get; set; }


public int Record55Id { get; set; }
public string Record55Name { get; set; }
public string Record55Description { get; set; }
public DateTime Record55CreatedAt { get; set; }
public DateTime? Record55UpdatedAt { get; set; }
public string Record55CreatedBy { get; set; }
public bool IsRecord55Active { get; set; }
public int Record55SortOrder { get; set; }


public int Field62Id { get; set; }
public string Field62Name { get; set; }
public string Field62Description { get; set; }
public DateTime Field62CreatedAt { get; set; }
public DateTime? Field62UpdatedAt { get; set; }
public string Field62CreatedBy { get; set; }
public bool IsField62Active { get; set; }
public int Field62SortOrder { get; set; }


public int Item69Id { get; set; }
public string Item69Name { get; set; }
public string Item69Description { get; set; }
public DateTime Item69CreatedAt { get; set; }
public DateTime? Item69UpdatedAt { get; set; }
public string Item69CreatedBy { get; set; }
public bool IsItem69Active { get; set; }
public int Item69SortOrder { get; set; }


public int Detail19Id { get; set; }
public string Detail19Name { get; set; }
public string Detail19Description { get; set; }
public DateTime Detail19CreatedAt { get; set; }
public DateTime? Detail19UpdatedAt { get; set; }
public string Detail19CreatedBy { get; set; }
public bool IsDetail19Active { get; set; }
public int Detail19SortOrder { get; set; }


public int Detail70Id { get; set; }
public string Detail70Name { get; set; }
public string Detail70Description { get; set; }
public DateTime Detail70CreatedAt { get; set; }
public DateTime? Detail70UpdatedAt { get; set; }
public string Detail70CreatedBy { get; set; }
public bool IsDetail70Active { get; set; }
public int Detail70SortOrder { get; set; }


public int Attr71Id { get; set; }
public string Attr71Name { get; set; }
public string Attr71Description { get; set; }
public DateTime Attr71CreatedAt { get; set; }
public DateTime? Attr71UpdatedAt { get; set; }
public string Attr71CreatedBy { get; set; }
public bool IsAttr71Active { get; set; }
public int Attr71SortOrder { get; set; }


public int Entry46Id { get; set; }
public string Entry46Name { get; set; }
public string Entry46Description { get; set; }
public DateTime Entry46CreatedAt { get; set; }
public DateTime? Entry46UpdatedAt { get; set; }
public string Entry46CreatedBy { get; set; }
public bool IsEntry46Active { get; set; }
public int Entry46SortOrder { get; set; }


public int Item71Id { get; set; }
public string Item71Name { get; set; }
public string Item71Description { get; set; }
public DateTime Item71CreatedAt { get; set; }
public DateTime? Item71UpdatedAt { get; set; }
public string Item71CreatedBy { get; set; }
public bool IsItem71Active { get; set; }
public int Item71SortOrder { get; set; }


public int Detail87Id { get; set; }
public string Detail87Name { get; set; }
public string Detail87Description { get; set; }
public DateTime Detail87CreatedAt { get; set; }
public DateTime? Detail87UpdatedAt { get; set; }
public string Detail87CreatedBy { get; set; }
public bool IsDetail87Active { get; set; }
public int Detail87SortOrder { get; set; }


public int Config5Id { get; set; }
public string Config5Name { get; set; }
public string Config5Description { get; set; }
public DateTime Config5CreatedAt { get; set; }
public DateTime? Config5UpdatedAt { get; set; }
public string Config5CreatedBy { get; set; }
public bool IsConfig5Active { get; set; }
public int Config5SortOrder { get; set; }


public int Item11Id { get; set; }
public string Item11Name { get; set; }
public string Item11Description { get; set; }
public DateTime Item11CreatedAt { get; set; }
public DateTime? Item11UpdatedAt { get; set; }
public string Item11CreatedBy { get; set; }
public bool IsItem11Active { get; set; }
public int Item11SortOrder { get; set; }


public int Attr6Id { get; set; }
public string Attr6Name { get; set; }
public string Attr6Description { get; set; }
public DateTime Attr6CreatedAt { get; set; }
public DateTime? Attr6UpdatedAt { get; set; }
public string Attr6CreatedBy { get; set; }
public bool IsAttr6Active { get; set; }
public int Attr6SortOrder { get; set; }


public int Config58Id { get; set; }
public string Config58Name { get; set; }
public string Config58Description { get; set; }
public DateTime Config58CreatedAt { get; set; }
public DateTime? Config58UpdatedAt { get; set; }
public string Config58CreatedBy { get; set; }
public bool IsConfig58Active { get; set; }
public int Config58SortOrder { get; set; }


public int Field37Id { get; set; }
public string Field37Name { get; set; }
public string Field37Description { get; set; }
public DateTime Field37CreatedAt { get; set; }
public DateTime? Field37UpdatedAt { get; set; }
public string Field37CreatedBy { get; set; }
public bool IsField37Active { get; set; }
public int Field37SortOrder { get; set; }


public int Item2Id { get; set; }
public string Item2Name { get; set; }
public string Item2Description { get; set; }
public DateTime Item2CreatedAt { get; set; }
public DateTime? Item2UpdatedAt { get; set; }
public string Item2CreatedBy { get; set; }
public bool IsItem2Active { get; set; }
public int Item2SortOrder { get; set; }


public int Detail84Id { get; set; }
public string Detail84Name { get; set; }
public string Detail84Description { get; set; }
public DateTime Detail84CreatedAt { get; set; }
public DateTime? Detail84UpdatedAt { get; set; }
public string Detail84CreatedBy { get; set; }
public bool IsDetail84Active { get; set; }
public int Detail84SortOrder { get; set; }


public int Record49Id { get; set; }
public string Record49Name { get; set; }
public string Record49Description { get; set; }
public DateTime Record49CreatedAt { get; set; }
public DateTime? Record49UpdatedAt { get; set; }
public string Record49CreatedBy { get; set; }
public bool IsRecord49Active { get; set; }
public int Record49SortOrder { get; set; }


public int Item49Id { get; set; }
public string Item49Name { get; set; }
public string Item49Description { get; set; }
public DateTime Item49CreatedAt { get; set; }
public DateTime? Item49UpdatedAt { get; set; }
public string Item49CreatedBy { get; set; }
public bool IsItem49Active { get; set; }
public int Item49SortOrder { get; set; }


public int Item25Id { get; set; }
public string Item25Name { get; set; }
public string Item25Description { get; set; }
public DateTime Item25CreatedAt { get; set; }
public DateTime? Item25UpdatedAt { get; set; }
public string Item25CreatedBy { get; set; }
public bool IsItem25Active { get; set; }
public int Item25SortOrder { get; set; }


public int Entry53Id { get; set; }
public string Entry53Name { get; set; }
public string Entry53Description { get; set; }
public DateTime Entry53CreatedAt { get; set; }
public DateTime? Entry53UpdatedAt { get; set; }
public string Entry53CreatedBy { get; set; }
public bool IsEntry53Active { get; set; }
public int Entry53SortOrder { get; set; }


public int Record24Id { get; set; }
public string Record24Name { get; set; }
public string Record24Description { get; set; }
public DateTime Record24CreatedAt { get; set; }
public DateTime? Record24UpdatedAt { get; set; }
public string Record24CreatedBy { get; set; }
public bool IsRecord24Active { get; set; }
public int Record24SortOrder { get; set; }


public int Config34Id { get; set; }
public string Config34Name { get; set; }
public string Config34Description { get; set; }
public DateTime Config34CreatedAt { get; set; }
public DateTime? Config34UpdatedAt { get; set; }
public string Config34CreatedBy { get; set; }
public bool IsConfig34Active { get; set; }
public int Config34SortOrder { get; set; }

    }
}