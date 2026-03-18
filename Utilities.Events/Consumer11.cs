using Admin.Handlers447;
using Admin.Processors;
using Auth.Api;
using Auth.Contracts395;
using Auth.Core2;
using BatchJobs.Core;
using Billing.Api;
using Billing.Mappers;
using DataAccess.Client113;
using DataAccess.Validators88;
using Export.Handlers202;
using Integration.Service147;
using Notifications.Mappers;
using Notifications.Service475;
using Reporting.Tests;
using Scheduling.Shared;
using Scheduling.Tests85;
using Security.Shared365;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities.Events
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer11
    {
        private readonly Auth_Core2_Request6 _auth_Core2_Request6;
        private readonly Auth_Core2_Service _auth_Core2_Service;
        private readonly Admin_Handlers447_Event _admin_Handlers447_Event;
        private readonly Admin_Handlers447_Command4 _admin_Handlers447_Command4;
        private readonly Auth_Api_Service3 _auth_Api_Service3;
        private readonly Auth_Api_Handler5 _auth_Api_Handler5;
        private readonly Billing_Api_Service10 _billing_Api_Service10;
        private readonly Billing_Api_Service3 _billing_Api_Service3;

        public Consumer11(Auth_Core2_Request6 auth_Core2_Request6, Auth_Core2_Service auth_Core2_Service, Admin_Handlers447_Event admin_Handlers447_Event, Admin_Handlers447_Command4 admin_Handlers447_Command4, Auth_Api_Service3 auth_Api_Service3, Auth_Api_Handler5 auth_Api_Handler5, Billing_Api_Service10 billing_Api_Service10, Billing_Api_Service3 billing_Api_Service3)
        {
            _auth_Core2_Request6 = auth_Core2_Request6 ?? throw new ArgumentNullException(nameof(auth_Core2_Request6));
            _auth_Core2_Service = auth_Core2_Service ?? throw new ArgumentNullException(nameof(auth_Core2_Service));
            _admin_Handlers447_Event = admin_Handlers447_Event ?? throw new ArgumentNullException(nameof(admin_Handlers447_Event));
            _admin_Handlers447_Command4 = admin_Handlers447_Command4 ?? throw new ArgumentNullException(nameof(admin_Handlers447_Command4));
            _auth_Api_Service3 = auth_Api_Service3 ?? throw new ArgumentNullException(nameof(auth_Api_Service3));
            _auth_Api_Handler5 = auth_Api_Handler5 ?? throw new ArgumentNullException(nameof(auth_Api_Handler5));
            _billing_Api_Service10 = billing_Api_Service10 ?? throw new ArgumentNullException(nameof(billing_Api_Service10));
            _billing_Api_Service3 = billing_Api_Service3 ?? throw new ArgumentNullException(nameof(billing_Api_Service3));
        }

        public Auth_Core2_Request6 GetAuth_Core2_Request6() => _auth_Core2_Request6;
        public Auth_Core2_Service GetAuth_Core2_Service() => _auth_Core2_Service;
        public Admin_Handlers447_Event GetAdmin_Handlers447_Event() => _admin_Handlers447_Event;
        public Admin_Handlers447_Command4 GetAdmin_Handlers447_Command4() => _admin_Handlers447_Command4;
        public Auth_Api_Service3 GetAuth_Api_Service3() => _auth_Api_Service3;
        public Auth_Api_Handler5 GetAuth_Api_Handler5() => _auth_Api_Handler5;
        public Billing_Api_Service10 GetBilling_Api_Service10() => _billing_Api_Service10;
        public Billing_Api_Service3 GetBilling_Api_Service3() => _billing_Api_Service3;

/// <summary>
/// Validates the Consumer11 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer11(Consumer11Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer11));
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
/// Processes the Consumer11 operation asynchronously.
/// </summary>
public async Task<Consumer11Result> ProcessConsumer11Async(
    Consumer11Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer11), request.Id);

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
            return new Consumer11Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer11));
        return new Consumer11Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer11));
        return new Consumer11Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer11 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer11Dto>> GetConsumer11ListAsync(
    Consumer11Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer11Entity>().AsQueryable();

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
        .Select(x => new Consumer11Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer11Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer11Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer11Service(
    ILogger<Consumer11Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer11:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer11 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer11Data> GetCachedConsumer11Async(string key)
{
    var cacheKey = $"Consumer11_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer11Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer11SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Item85Id { get; set; }
public string Item85Name { get; set; }
public string Item85Description { get; set; }
public DateTime Item85CreatedAt { get; set; }
public DateTime? Item85UpdatedAt { get; set; }
public string Item85CreatedBy { get; set; }
public bool IsItem85Active { get; set; }
public int Item85SortOrder { get; set; }


public int Field80Id { get; set; }
public string Field80Name { get; set; }
public string Field80Description { get; set; }
public DateTime Field80CreatedAt { get; set; }
public DateTime? Field80UpdatedAt { get; set; }
public string Field80CreatedBy { get; set; }
public bool IsField80Active { get; set; }
public int Field80SortOrder { get; set; }


public int Attr29Id { get; set; }
public string Attr29Name { get; set; }
public string Attr29Description { get; set; }
public DateTime Attr29CreatedAt { get; set; }
public DateTime? Attr29UpdatedAt { get; set; }
public string Attr29CreatedBy { get; set; }
public bool IsAttr29Active { get; set; }
public int Attr29SortOrder { get; set; }


public int Config93Id { get; set; }
public string Config93Name { get; set; }
public string Config93Description { get; set; }
public DateTime Config93CreatedAt { get; set; }
public DateTime? Config93UpdatedAt { get; set; }
public string Config93CreatedBy { get; set; }
public bool IsConfig93Active { get; set; }
public int Config93SortOrder { get; set; }


public int Record8Id { get; set; }
public string Record8Name { get; set; }
public string Record8Description { get; set; }
public DateTime Record8CreatedAt { get; set; }
public DateTime? Record8UpdatedAt { get; set; }
public string Record8CreatedBy { get; set; }
public bool IsRecord8Active { get; set; }
public int Record8SortOrder { get; set; }


public int Item4Id { get; set; }
public string Item4Name { get; set; }
public string Item4Description { get; set; }
public DateTime Item4CreatedAt { get; set; }
public DateTime? Item4UpdatedAt { get; set; }
public string Item4CreatedBy { get; set; }
public bool IsItem4Active { get; set; }
public int Item4SortOrder { get; set; }


public int Config97Id { get; set; }
public string Config97Name { get; set; }
public string Config97Description { get; set; }
public DateTime Config97CreatedAt { get; set; }
public DateTime? Config97UpdatedAt { get; set; }
public string Config97CreatedBy { get; set; }
public bool IsConfig97Active { get; set; }
public int Config97SortOrder { get; set; }


public int Param77Id { get; set; }
public string Param77Name { get; set; }
public string Param77Description { get; set; }
public DateTime Param77CreatedAt { get; set; }
public DateTime? Param77UpdatedAt { get; set; }
public string Param77CreatedBy { get; set; }
public bool IsParam77Active { get; set; }
public int Param77SortOrder { get; set; }


public int Detail85Id { get; set; }
public string Detail85Name { get; set; }
public string Detail85Description { get; set; }
public DateTime Detail85CreatedAt { get; set; }
public DateTime? Detail85UpdatedAt { get; set; }
public string Detail85CreatedBy { get; set; }
public bool IsDetail85Active { get; set; }
public int Detail85SortOrder { get; set; }


public int Detail93Id { get; set; }
public string Detail93Name { get; set; }
public string Detail93Description { get; set; }
public DateTime Detail93CreatedAt { get; set; }
public DateTime? Detail93UpdatedAt { get; set; }
public string Detail93CreatedBy { get; set; }
public bool IsDetail93Active { get; set; }
public int Detail93SortOrder { get; set; }


public int Item35Id { get; set; }
public string Item35Name { get; set; }
public string Item35Description { get; set; }
public DateTime Item35CreatedAt { get; set; }
public DateTime? Item35UpdatedAt { get; set; }
public string Item35CreatedBy { get; set; }
public bool IsItem35Active { get; set; }
public int Item35SortOrder { get; set; }


public int Attr68Id { get; set; }
public string Attr68Name { get; set; }
public string Attr68Description { get; set; }
public DateTime Attr68CreatedAt { get; set; }
public DateTime? Attr68UpdatedAt { get; set; }
public string Attr68CreatedBy { get; set; }
public bool IsAttr68Active { get; set; }
public int Attr68SortOrder { get; set; }


public int Field94Id { get; set; }
public string Field94Name { get; set; }
public string Field94Description { get; set; }
public DateTime Field94CreatedAt { get; set; }
public DateTime? Field94UpdatedAt { get; set; }
public string Field94CreatedBy { get; set; }
public bool IsField94Active { get; set; }
public int Field94SortOrder { get; set; }


public int Entry94Id { get; set; }
public string Entry94Name { get; set; }
public string Entry94Description { get; set; }
public DateTime Entry94CreatedAt { get; set; }
public DateTime? Entry94UpdatedAt { get; set; }
public string Entry94CreatedBy { get; set; }
public bool IsEntry94Active { get; set; }
public int Entry94SortOrder { get; set; }


public int Entry18Id { get; set; }
public string Entry18Name { get; set; }
public string Entry18Description { get; set; }
public DateTime Entry18CreatedAt { get; set; }
public DateTime? Entry18UpdatedAt { get; set; }
public string Entry18CreatedBy { get; set; }
public bool IsEntry18Active { get; set; }
public int Entry18SortOrder { get; set; }


public int Detail75Id { get; set; }
public string Detail75Name { get; set; }
public string Detail75Description { get; set; }
public DateTime Detail75CreatedAt { get; set; }
public DateTime? Detail75UpdatedAt { get; set; }
public string Detail75CreatedBy { get; set; }
public bool IsDetail75Active { get; set; }
public int Detail75SortOrder { get; set; }


public int Field94Id { get; set; }
public string Field94Name { get; set; }
public string Field94Description { get; set; }
public DateTime Field94CreatedAt { get; set; }
public DateTime? Field94UpdatedAt { get; set; }
public string Field94CreatedBy { get; set; }
public bool IsField94Active { get; set; }
public int Field94SortOrder { get; set; }


public int Item11Id { get; set; }
public string Item11Name { get; set; }
public string Item11Description { get; set; }
public DateTime Item11CreatedAt { get; set; }
public DateTime? Item11UpdatedAt { get; set; }
public string Item11CreatedBy { get; set; }
public bool IsItem11Active { get; set; }
public int Item11SortOrder { get; set; }


public int Attr12Id { get; set; }
public string Attr12Name { get; set; }
public string Attr12Description { get; set; }
public DateTime Attr12CreatedAt { get; set; }
public DateTime? Attr12UpdatedAt { get; set; }
public string Attr12CreatedBy { get; set; }
public bool IsAttr12Active { get; set; }
public int Attr12SortOrder { get; set; }


public int Item12Id { get; set; }
public string Item12Name { get; set; }
public string Item12Description { get; set; }
public DateTime Item12CreatedAt { get; set; }
public DateTime? Item12UpdatedAt { get; set; }
public string Item12CreatedBy { get; set; }
public bool IsItem12Active { get; set; }
public int Item12SortOrder { get; set; }


public int Config88Id { get; set; }
public string Config88Name { get; set; }
public string Config88Description { get; set; }
public DateTime Config88CreatedAt { get; set; }
public DateTime? Config88UpdatedAt { get; set; }
public string Config88CreatedBy { get; set; }
public bool IsConfig88Active { get; set; }
public int Config88SortOrder { get; set; }


public int Record77Id { get; set; }
public string Record77Name { get; set; }
public string Record77Description { get; set; }
public DateTime Record77CreatedAt { get; set; }
public DateTime? Record77UpdatedAt { get; set; }
public string Record77CreatedBy { get; set; }
public bool IsRecord77Active { get; set; }
public int Record77SortOrder { get; set; }


public int Field84Id { get; set; }
public string Field84Name { get; set; }
public string Field84Description { get; set; }
public DateTime Field84CreatedAt { get; set; }
public DateTime? Field84UpdatedAt { get; set; }
public string Field84CreatedBy { get; set; }
public bool IsField84Active { get; set; }
public int Field84SortOrder { get; set; }


public int Item41Id { get; set; }
public string Item41Name { get; set; }
public string Item41Description { get; set; }
public DateTime Item41CreatedAt { get; set; }
public DateTime? Item41UpdatedAt { get; set; }
public string Item41CreatedBy { get; set; }
public bool IsItem41Active { get; set; }
public int Item41SortOrder { get; set; }


public int Entry84Id { get; set; }
public string Entry84Name { get; set; }
public string Entry84Description { get; set; }
public DateTime Entry84CreatedAt { get; set; }
public DateTime? Entry84UpdatedAt { get; set; }
public string Entry84CreatedBy { get; set; }
public bool IsEntry84Active { get; set; }
public int Entry84SortOrder { get; set; }


public int Param81Id { get; set; }
public string Param81Name { get; set; }
public string Param81Description { get; set; }
public DateTime Param81CreatedAt { get; set; }
public DateTime? Param81UpdatedAt { get; set; }
public string Param81CreatedBy { get; set; }
public bool IsParam81Active { get; set; }
public int Param81SortOrder { get; set; }


public int Entry52Id { get; set; }
public string Entry52Name { get; set; }
public string Entry52Description { get; set; }
public DateTime Entry52CreatedAt { get; set; }
public DateTime? Entry52UpdatedAt { get; set; }
public string Entry52CreatedBy { get; set; }
public bool IsEntry52Active { get; set; }
public int Entry52SortOrder { get; set; }


public int Detail68Id { get; set; }
public string Detail68Name { get; set; }
public string Detail68Description { get; set; }
public DateTime Detail68CreatedAt { get; set; }
public DateTime? Detail68UpdatedAt { get; set; }
public string Detail68CreatedBy { get; set; }
public bool IsDetail68Active { get; set; }
public int Detail68SortOrder { get; set; }


public int Record27Id { get; set; }
public string Record27Name { get; set; }
public string Record27Description { get; set; }
public DateTime Record27CreatedAt { get; set; }
public DateTime? Record27UpdatedAt { get; set; }
public string Record27CreatedBy { get; set; }
public bool IsRecord27Active { get; set; }
public int Record27SortOrder { get; set; }


public int Config75Id { get; set; }
public string Config75Name { get; set; }
public string Config75Description { get; set; }
public DateTime Config75CreatedAt { get; set; }
public DateTime? Config75UpdatedAt { get; set; }
public string Config75CreatedBy { get; set; }
public bool IsConfig75Active { get; set; }
public int Config75SortOrder { get; set; }


public int Detail89Id { get; set; }
public string Detail89Name { get; set; }
public string Detail89Description { get; set; }
public DateTime Detail89CreatedAt { get; set; }
public DateTime? Detail89UpdatedAt { get; set; }
public string Detail89CreatedBy { get; set; }
public bool IsDetail89Active { get; set; }
public int Detail89SortOrder { get; set; }


public int Attr79Id { get; set; }
public string Attr79Name { get; set; }
public string Attr79Description { get; set; }
public DateTime Attr79CreatedAt { get; set; }
public DateTime? Attr79UpdatedAt { get; set; }
public string Attr79CreatedBy { get; set; }
public bool IsAttr79Active { get; set; }
public int Attr79SortOrder { get; set; }


public int Item50Id { get; set; }
public string Item50Name { get; set; }
public string Item50Description { get; set; }
public DateTime Item50CreatedAt { get; set; }
public DateTime? Item50UpdatedAt { get; set; }
public string Item50CreatedBy { get; set; }
public bool IsItem50Active { get; set; }
public int Item50SortOrder { get; set; }


public int Record86Id { get; set; }
public string Record86Name { get; set; }
public string Record86Description { get; set; }
public DateTime Record86CreatedAt { get; set; }
public DateTime? Record86UpdatedAt { get; set; }
public string Record86CreatedBy { get; set; }
public bool IsRecord86Active { get; set; }
public int Record86SortOrder { get; set; }


public int Item60Id { get; set; }
public string Item60Name { get; set; }
public string Item60Description { get; set; }
public DateTime Item60CreatedAt { get; set; }
public DateTime? Item60UpdatedAt { get; set; }
public string Item60CreatedBy { get; set; }
public bool IsItem60Active { get; set; }
public int Item60SortOrder { get; set; }


public int Config68Id { get; set; }
public string Config68Name { get; set; }
public string Config68Description { get; set; }
public DateTime Config68CreatedAt { get; set; }
public DateTime? Config68UpdatedAt { get; set; }
public string Config68CreatedBy { get; set; }
public bool IsConfig68Active { get; set; }
public int Config68SortOrder { get; set; }


public int Config89Id { get; set; }
public string Config89Name { get; set; }
public string Config89Description { get; set; }
public DateTime Config89CreatedAt { get; set; }
public DateTime? Config89UpdatedAt { get; set; }
public string Config89CreatedBy { get; set; }
public bool IsConfig89Active { get; set; }
public int Config89SortOrder { get; set; }


public int Entry82Id { get; set; }
public string Entry82Name { get; set; }
public string Entry82Description { get; set; }
public DateTime Entry82CreatedAt { get; set; }
public DateTime? Entry82UpdatedAt { get; set; }
public string Entry82CreatedBy { get; set; }
public bool IsEntry82Active { get; set; }
public int Entry82SortOrder { get; set; }


public int Param79Id { get; set; }
public string Param79Name { get; set; }
public string Param79Description { get; set; }
public DateTime Param79CreatedAt { get; set; }
public DateTime? Param79UpdatedAt { get; set; }
public string Param79CreatedBy { get; set; }
public bool IsParam79Active { get; set; }
public int Param79SortOrder { get; set; }


public int Entry3Id { get; set; }
public string Entry3Name { get; set; }
public string Entry3Description { get; set; }
public DateTime Entry3CreatedAt { get; set; }
public DateTime? Entry3UpdatedAt { get; set; }
public string Entry3CreatedBy { get; set; }
public bool IsEntry3Active { get; set; }
public int Entry3SortOrder { get; set; }


public int Item97Id { get; set; }
public string Item97Name { get; set; }
public string Item97Description { get; set; }
public DateTime Item97CreatedAt { get; set; }
public DateTime? Item97UpdatedAt { get; set; }
public string Item97CreatedBy { get; set; }
public bool IsItem97Active { get; set; }
public int Item97SortOrder { get; set; }


public int Entry7Id { get; set; }
public string Entry7Name { get; set; }
public string Entry7Description { get; set; }
public DateTime Entry7CreatedAt { get; set; }
public DateTime? Entry7UpdatedAt { get; set; }
public string Entry7CreatedBy { get; set; }
public bool IsEntry7Active { get; set; }
public int Entry7SortOrder { get; set; }


public int Field75Id { get; set; }
public string Field75Name { get; set; }
public string Field75Description { get; set; }
public DateTime Field75CreatedAt { get; set; }
public DateTime? Field75UpdatedAt { get; set; }
public string Field75CreatedBy { get; set; }
public bool IsField75Active { get; set; }
public int Field75SortOrder { get; set; }


public int Attr62Id { get; set; }
public string Attr62Name { get; set; }
public string Attr62Description { get; set; }
public DateTime Attr62CreatedAt { get; set; }
public DateTime? Attr62UpdatedAt { get; set; }
public string Attr62CreatedBy { get; set; }
public bool IsAttr62Active { get; set; }
public int Attr62SortOrder { get; set; }


public int Attr18Id { get; set; }
public string Attr18Name { get; set; }
public string Attr18Description { get; set; }
public DateTime Attr18CreatedAt { get; set; }
public DateTime? Attr18UpdatedAt { get; set; }
public string Attr18CreatedBy { get; set; }
public bool IsAttr18Active { get; set; }
public int Attr18SortOrder { get; set; }


public int Record15Id { get; set; }
public string Record15Name { get; set; }
public string Record15Description { get; set; }
public DateTime Record15CreatedAt { get; set; }
public DateTime? Record15UpdatedAt { get; set; }
public string Record15CreatedBy { get; set; }
public bool IsRecord15Active { get; set; }
public int Record15SortOrder { get; set; }


public int Record66Id { get; set; }
public string Record66Name { get; set; }
public string Record66Description { get; set; }
public DateTime Record66CreatedAt { get; set; }
public DateTime? Record66UpdatedAt { get; set; }
public string Record66CreatedBy { get; set; }
public bool IsRecord66Active { get; set; }
public int Record66SortOrder { get; set; }

    }
}