using Admin.Data117;
using Admin.Processors35;
using Admin.Service339;
using Admin.Web;
using Auth.Client249;
using BatchJobs.Processors;
using Documents.Tests;
using Export.Events276;
using Export.Mappers;
using Export.Web130;
using Imaging.Service;
using Notifications.Tests195;
using Notifications.Validators252;
using Portal.Web158;
using Reporting.Api287;
using Reporting.Processors495;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Service;
using Workflow.Web59;

namespace GalaxyWorks.Data375
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer6
    {
        private readonly Admin_Web_Handler1 _admin_Web_Handler1;
        private readonly Admin_Processors35_Helper4 _admin_Processors35_Helper4;
        private readonly Admin_Processors35_Range2 _admin_Processors35_Range2;
        private readonly Admin_Processors35_Provider7 _admin_Processors35_Provider7;
        private readonly Auth_Client249_Manager9 _auth_Client249_Manager9;
        private readonly Utilities_Service_Manager _utilities_Service_Manager;
        private readonly Portal_Web158_Service1 _portal_Web158_Service1;
        private readonly Notifications_Validators252_Service2 _notifications_Validators252_Service2;

        public Consumer6(Admin_Web_Handler1 admin_Web_Handler1, Admin_Processors35_Helper4 admin_Processors35_Helper4, Admin_Processors35_Range2 admin_Processors35_Range2, Admin_Processors35_Provider7 admin_Processors35_Provider7, Auth_Client249_Manager9 auth_Client249_Manager9, Utilities_Service_Manager utilities_Service_Manager, Portal_Web158_Service1 portal_Web158_Service1, Notifications_Validators252_Service2 notifications_Validators252_Service2)
        {
            _admin_Web_Handler1 = admin_Web_Handler1 ?? throw new ArgumentNullException(nameof(admin_Web_Handler1));
            _admin_Processors35_Helper4 = admin_Processors35_Helper4 ?? throw new ArgumentNullException(nameof(admin_Processors35_Helper4));
            _admin_Processors35_Range2 = admin_Processors35_Range2 ?? throw new ArgumentNullException(nameof(admin_Processors35_Range2));
            _admin_Processors35_Provider7 = admin_Processors35_Provider7 ?? throw new ArgumentNullException(nameof(admin_Processors35_Provider7));
            _auth_Client249_Manager9 = auth_Client249_Manager9 ?? throw new ArgumentNullException(nameof(auth_Client249_Manager9));
            _utilities_Service_Manager = utilities_Service_Manager ?? throw new ArgumentNullException(nameof(utilities_Service_Manager));
            _portal_Web158_Service1 = portal_Web158_Service1 ?? throw new ArgumentNullException(nameof(portal_Web158_Service1));
            _notifications_Validators252_Service2 = notifications_Validators252_Service2 ?? throw new ArgumentNullException(nameof(notifications_Validators252_Service2));
        }

        public Admin_Web_Handler1 GetAdmin_Web_Handler1() => _admin_Web_Handler1;
        public Admin_Processors35_Helper4 GetAdmin_Processors35_Helper4() => _admin_Processors35_Helper4;
        public Admin_Processors35_Range2 GetAdmin_Processors35_Range2() => _admin_Processors35_Range2;
        public Admin_Processors35_Provider7 GetAdmin_Processors35_Provider7() => _admin_Processors35_Provider7;
        public Auth_Client249_Manager9 GetAuth_Client249_Manager9() => _auth_Client249_Manager9;
        public Utilities_Service_Manager GetUtilities_Service_Manager() => _utilities_Service_Manager;
        public Portal_Web158_Service1 GetPortal_Web158_Service1() => _portal_Web158_Service1;
        public Notifications_Validators252_Service2 GetNotifications_Validators252_Service2() => _notifications_Validators252_Service2;

/// <summary>
/// Validates the Consumer6 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer6(Consumer6Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer6));
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
/// Processes the Consumer6 operation asynchronously.
/// </summary>
public async Task<Consumer6Result> ProcessConsumer6Async(
    Consumer6Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer6), request.Id);

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
            return new Consumer6Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer6));
        return new Consumer6Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer6));
        return new Consumer6Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer6 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer6Dto>> GetConsumer6ListAsync(
    Consumer6Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer6Entity>().AsQueryable();

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
        .Select(x => new Consumer6Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer6Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer6Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer6Service(
    ILogger<Consumer6Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer6:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer6 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer6Data> GetCachedConsumer6Async(string key)
{
    var cacheKey = $"Consumer6_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer6Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer6SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Param48Id { get; set; }
public string Param48Name { get; set; }
public string Param48Description { get; set; }
public DateTime Param48CreatedAt { get; set; }
public DateTime? Param48UpdatedAt { get; set; }
public string Param48CreatedBy { get; set; }
public bool IsParam48Active { get; set; }
public int Param48SortOrder { get; set; }


public int Param39Id { get; set; }
public string Param39Name { get; set; }
public string Param39Description { get; set; }
public DateTime Param39CreatedAt { get; set; }
public DateTime? Param39UpdatedAt { get; set; }
public string Param39CreatedBy { get; set; }
public bool IsParam39Active { get; set; }
public int Param39SortOrder { get; set; }


public int Item74Id { get; set; }
public string Item74Name { get; set; }
public string Item74Description { get; set; }
public DateTime Item74CreatedAt { get; set; }
public DateTime? Item74UpdatedAt { get; set; }
public string Item74CreatedBy { get; set; }
public bool IsItem74Active { get; set; }
public int Item74SortOrder { get; set; }


public int Item33Id { get; set; }
public string Item33Name { get; set; }
public string Item33Description { get; set; }
public DateTime Item33CreatedAt { get; set; }
public DateTime? Item33UpdatedAt { get; set; }
public string Item33CreatedBy { get; set; }
public bool IsItem33Active { get; set; }
public int Item33SortOrder { get; set; }


public int Field10Id { get; set; }
public string Field10Name { get; set; }
public string Field10Description { get; set; }
public DateTime Field10CreatedAt { get; set; }
public DateTime? Field10UpdatedAt { get; set; }
public string Field10CreatedBy { get; set; }
public bool IsField10Active { get; set; }
public int Field10SortOrder { get; set; }


public int Attr21Id { get; set; }
public string Attr21Name { get; set; }
public string Attr21Description { get; set; }
public DateTime Attr21CreatedAt { get; set; }
public DateTime? Attr21UpdatedAt { get; set; }
public string Attr21CreatedBy { get; set; }
public bool IsAttr21Active { get; set; }
public int Attr21SortOrder { get; set; }


public int Param20Id { get; set; }
public string Param20Name { get; set; }
public string Param20Description { get; set; }
public DateTime Param20CreatedAt { get; set; }
public DateTime? Param20UpdatedAt { get; set; }
public string Param20CreatedBy { get; set; }
public bool IsParam20Active { get; set; }
public int Param20SortOrder { get; set; }


public int Config23Id { get; set; }
public string Config23Name { get; set; }
public string Config23Description { get; set; }
public DateTime Config23CreatedAt { get; set; }
public DateTime? Config23UpdatedAt { get; set; }
public string Config23CreatedBy { get; set; }
public bool IsConfig23Active { get; set; }
public int Config23SortOrder { get; set; }


public int Param93Id { get; set; }
public string Param93Name { get; set; }
public string Param93Description { get; set; }
public DateTime Param93CreatedAt { get; set; }
public DateTime? Param93UpdatedAt { get; set; }
public string Param93CreatedBy { get; set; }
public bool IsParam93Active { get; set; }
public int Param93SortOrder { get; set; }


public int Entry2Id { get; set; }
public string Entry2Name { get; set; }
public string Entry2Description { get; set; }
public DateTime Entry2CreatedAt { get; set; }
public DateTime? Entry2UpdatedAt { get; set; }
public string Entry2CreatedBy { get; set; }
public bool IsEntry2Active { get; set; }
public int Entry2SortOrder { get; set; }


public int Detail23Id { get; set; }
public string Detail23Name { get; set; }
public string Detail23Description { get; set; }
public DateTime Detail23CreatedAt { get; set; }
public DateTime? Detail23UpdatedAt { get; set; }
public string Detail23CreatedBy { get; set; }
public bool IsDetail23Active { get; set; }
public int Detail23SortOrder { get; set; }


public int Detail97Id { get; set; }
public string Detail97Name { get; set; }
public string Detail97Description { get; set; }
public DateTime Detail97CreatedAt { get; set; }
public DateTime? Detail97UpdatedAt { get; set; }
public string Detail97CreatedBy { get; set; }
public bool IsDetail97Active { get; set; }
public int Detail97SortOrder { get; set; }


public int Config98Id { get; set; }
public string Config98Name { get; set; }
public string Config98Description { get; set; }
public DateTime Config98CreatedAt { get; set; }
public DateTime? Config98UpdatedAt { get; set; }
public string Config98CreatedBy { get; set; }
public bool IsConfig98Active { get; set; }
public int Config98SortOrder { get; set; }


public int Entry78Id { get; set; }
public string Entry78Name { get; set; }
public string Entry78Description { get; set; }
public DateTime Entry78CreatedAt { get; set; }
public DateTime? Entry78UpdatedAt { get; set; }
public string Entry78CreatedBy { get; set; }
public bool IsEntry78Active { get; set; }
public int Entry78SortOrder { get; set; }


public int Item87Id { get; set; }
public string Item87Name { get; set; }
public string Item87Description { get; set; }
public DateTime Item87CreatedAt { get; set; }
public DateTime? Item87UpdatedAt { get; set; }
public string Item87CreatedBy { get; set; }
public bool IsItem87Active { get; set; }
public int Item87SortOrder { get; set; }


public int Entry6Id { get; set; }
public string Entry6Name { get; set; }
public string Entry6Description { get; set; }
public DateTime Entry6CreatedAt { get; set; }
public DateTime? Entry6UpdatedAt { get; set; }
public string Entry6CreatedBy { get; set; }
public bool IsEntry6Active { get; set; }
public int Entry6SortOrder { get; set; }


public int Entry53Id { get; set; }
public string Entry53Name { get; set; }
public string Entry53Description { get; set; }
public DateTime Entry53CreatedAt { get; set; }
public DateTime? Entry53UpdatedAt { get; set; }
public string Entry53CreatedBy { get; set; }
public bool IsEntry53Active { get; set; }
public int Entry53SortOrder { get; set; }


public int Item68Id { get; set; }
public string Item68Name { get; set; }
public string Item68Description { get; set; }
public DateTime Item68CreatedAt { get; set; }
public DateTime? Item68UpdatedAt { get; set; }
public string Item68CreatedBy { get; set; }
public bool IsItem68Active { get; set; }
public int Item68SortOrder { get; set; }


public int Detail22Id { get; set; }
public string Detail22Name { get; set; }
public string Detail22Description { get; set; }
public DateTime Detail22CreatedAt { get; set; }
public DateTime? Detail22UpdatedAt { get; set; }
public string Detail22CreatedBy { get; set; }
public bool IsDetail22Active { get; set; }
public int Detail22SortOrder { get; set; }


public int Field65Id { get; set; }
public string Field65Name { get; set; }
public string Field65Description { get; set; }
public DateTime Field65CreatedAt { get; set; }
public DateTime? Field65UpdatedAt { get; set; }
public string Field65CreatedBy { get; set; }
public bool IsField65Active { get; set; }
public int Field65SortOrder { get; set; }


public int Attr72Id { get; set; }
public string Attr72Name { get; set; }
public string Attr72Description { get; set; }
public DateTime Attr72CreatedAt { get; set; }
public DateTime? Attr72UpdatedAt { get; set; }
public string Attr72CreatedBy { get; set; }
public bool IsAttr72Active { get; set; }
public int Attr72SortOrder { get; set; }


public int Config3Id { get; set; }
public string Config3Name { get; set; }
public string Config3Description { get; set; }
public DateTime Config3CreatedAt { get; set; }
public DateTime? Config3UpdatedAt { get; set; }
public string Config3CreatedBy { get; set; }
public bool IsConfig3Active { get; set; }
public int Config3SortOrder { get; set; }


public int Record16Id { get; set; }
public string Record16Name { get; set; }
public string Record16Description { get; set; }
public DateTime Record16CreatedAt { get; set; }
public DateTime? Record16UpdatedAt { get; set; }
public string Record16CreatedBy { get; set; }
public bool IsRecord16Active { get; set; }
public int Record16SortOrder { get; set; }


public int Record12Id { get; set; }
public string Record12Name { get; set; }
public string Record12Description { get; set; }
public DateTime Record12CreatedAt { get; set; }
public DateTime? Record12UpdatedAt { get; set; }
public string Record12CreatedBy { get; set; }
public bool IsRecord12Active { get; set; }
public int Record12SortOrder { get; set; }


public int Attr74Id { get; set; }
public string Attr74Name { get; set; }
public string Attr74Description { get; set; }
public DateTime Attr74CreatedAt { get; set; }
public DateTime? Attr74UpdatedAt { get; set; }
public string Attr74CreatedBy { get; set; }
public bool IsAttr74Active { get; set; }
public int Attr74SortOrder { get; set; }


public int Attr86Id { get; set; }
public string Attr86Name { get; set; }
public string Attr86Description { get; set; }
public DateTime Attr86CreatedAt { get; set; }
public DateTime? Attr86UpdatedAt { get; set; }
public string Attr86CreatedBy { get; set; }
public bool IsAttr86Active { get; set; }
public int Attr86SortOrder { get; set; }


public int Record59Id { get; set; }
public string Record59Name { get; set; }
public string Record59Description { get; set; }
public DateTime Record59CreatedAt { get; set; }
public DateTime? Record59UpdatedAt { get; set; }
public string Record59CreatedBy { get; set; }
public bool IsRecord59Active { get; set; }
public int Record59SortOrder { get; set; }


public int Item38Id { get; set; }
public string Item38Name { get; set; }
public string Item38Description { get; set; }
public DateTime Item38CreatedAt { get; set; }
public DateTime? Item38UpdatedAt { get; set; }
public string Item38CreatedBy { get; set; }
public bool IsItem38Active { get; set; }
public int Item38SortOrder { get; set; }


public int Item47Id { get; set; }
public string Item47Name { get; set; }
public string Item47Description { get; set; }
public DateTime Item47CreatedAt { get; set; }
public DateTime? Item47UpdatedAt { get; set; }
public string Item47CreatedBy { get; set; }
public bool IsItem47Active { get; set; }
public int Item47SortOrder { get; set; }


public int Field59Id { get; set; }
public string Field59Name { get; set; }
public string Field59Description { get; set; }
public DateTime Field59CreatedAt { get; set; }
public DateTime? Field59UpdatedAt { get; set; }
public string Field59CreatedBy { get; set; }
public bool IsField59Active { get; set; }
public int Field59SortOrder { get; set; }


public int Record32Id { get; set; }
public string Record32Name { get; set; }
public string Record32Description { get; set; }
public DateTime Record32CreatedAt { get; set; }
public DateTime? Record32UpdatedAt { get; set; }
public string Record32CreatedBy { get; set; }
public bool IsRecord32Active { get; set; }
public int Record32SortOrder { get; set; }


public int Config26Id { get; set; }
public string Config26Name { get; set; }
public string Config26Description { get; set; }
public DateTime Config26CreatedAt { get; set; }
public DateTime? Config26UpdatedAt { get; set; }
public string Config26CreatedBy { get; set; }
public bool IsConfig26Active { get; set; }
public int Config26SortOrder { get; set; }


public int Param28Id { get; set; }
public string Param28Name { get; set; }
public string Param28Description { get; set; }
public DateTime Param28CreatedAt { get; set; }
public DateTime? Param28UpdatedAt { get; set; }
public string Param28CreatedBy { get; set; }
public bool IsParam28Active { get; set; }
public int Param28SortOrder { get; set; }


public int Field24Id { get; set; }
public string Field24Name { get; set; }
public string Field24Description { get; set; }
public DateTime Field24CreatedAt { get; set; }
public DateTime? Field24UpdatedAt { get; set; }
public string Field24CreatedBy { get; set; }
public bool IsField24Active { get; set; }
public int Field24SortOrder { get; set; }


public int Entry23Id { get; set; }
public string Entry23Name { get; set; }
public string Entry23Description { get; set; }
public DateTime Entry23CreatedAt { get; set; }
public DateTime? Entry23UpdatedAt { get; set; }
public string Entry23CreatedBy { get; set; }
public bool IsEntry23Active { get; set; }
public int Entry23SortOrder { get; set; }


public int Config91Id { get; set; }
public string Config91Name { get; set; }
public string Config91Description { get; set; }
public DateTime Config91CreatedAt { get; set; }
public DateTime? Config91UpdatedAt { get; set; }
public string Config91CreatedBy { get; set; }
public bool IsConfig91Active { get; set; }
public int Config91SortOrder { get; set; }


public int Param20Id { get; set; }
public string Param20Name { get; set; }
public string Param20Description { get; set; }
public DateTime Param20CreatedAt { get; set; }
public DateTime? Param20UpdatedAt { get; set; }
public string Param20CreatedBy { get; set; }
public bool IsParam20Active { get; set; }
public int Param20SortOrder { get; set; }


public int Entry76Id { get; set; }
public string Entry76Name { get; set; }
public string Entry76Description { get; set; }
public DateTime Entry76CreatedAt { get; set; }
public DateTime? Entry76UpdatedAt { get; set; }
public string Entry76CreatedBy { get; set; }
public bool IsEntry76Active { get; set; }
public int Entry76SortOrder { get; set; }


public int Item68Id { get; set; }
public string Item68Name { get; set; }
public string Item68Description { get; set; }
public DateTime Item68CreatedAt { get; set; }
public DateTime? Item68UpdatedAt { get; set; }
public string Item68CreatedBy { get; set; }
public bool IsItem68Active { get; set; }
public int Item68SortOrder { get; set; }


public int Entry53Id { get; set; }
public string Entry53Name { get; set; }
public string Entry53Description { get; set; }
public DateTime Entry53CreatedAt { get; set; }
public DateTime? Entry53UpdatedAt { get; set; }
public string Entry53CreatedBy { get; set; }
public bool IsEntry53Active { get; set; }
public int Entry53SortOrder { get; set; }


public int Field93Id { get; set; }
public string Field93Name { get; set; }
public string Field93Description { get; set; }
public DateTime Field93CreatedAt { get; set; }
public DateTime? Field93UpdatedAt { get; set; }
public string Field93CreatedBy { get; set; }
public bool IsField93Active { get; set; }
public int Field93SortOrder { get; set; }


public int Entry42Id { get; set; }
public string Entry42Name { get; set; }
public string Entry42Description { get; set; }
public DateTime Entry42CreatedAt { get; set; }
public DateTime? Entry42UpdatedAt { get; set; }
public string Entry42CreatedBy { get; set; }
public bool IsEntry42Active { get; set; }
public int Entry42SortOrder { get; set; }


public int Config55Id { get; set; }
public string Config55Name { get; set; }
public string Config55Description { get; set; }
public DateTime Config55CreatedAt { get; set; }
public DateTime? Config55UpdatedAt { get; set; }
public string Config55CreatedBy { get; set; }
public bool IsConfig55Active { get; set; }
public int Config55SortOrder { get; set; }


public int Field72Id { get; set; }
public string Field72Name { get; set; }
public string Field72Description { get; set; }
public DateTime Field72CreatedAt { get; set; }
public DateTime? Field72UpdatedAt { get; set; }
public string Field72CreatedBy { get; set; }
public bool IsField72Active { get; set; }
public int Field72SortOrder { get; set; }


public int Record98Id { get; set; }
public string Record98Name { get; set; }
public string Record98Description { get; set; }
public DateTime Record98CreatedAt { get; set; }
public DateTime? Record98UpdatedAt { get; set; }
public string Record98CreatedBy { get; set; }
public bool IsRecord98Active { get; set; }
public int Record98SortOrder { get; set; }

    }
}