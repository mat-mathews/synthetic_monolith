using Admin.Events306;
using Admin.Models;
using Admin.Processors35;
using Auth.Api;
using Auth.Client271;
using Auth.Handlers209;
using Billing.Api;
using Billing.Client22;
using Billing.Shared;
using Common.Core417;
using Common.Handlers;
using Common.Shared;
using DataAccess.Events283;
using DataAccess.Web;
using Notifications.Handlers;
using Portal.Events151;
using Portal.Validators227;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Api66;

namespace Common.Mappers343
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer19
    {
        private readonly Admin_Processors35_Helper11 _admin_Processors35_Helper11;
        private readonly IAdmin_Processors35_Repository3 _iAdmin_Processors35_Repository3;
        private readonly Auth_Handlers209_Options _auth_Handlers209_Options;
        private readonly Auth_Client271_Helper3 _auth_Client271_Helper3;
        private readonly Auth_Client271_Manager _auth_Client271_Manager;
        private readonly Utilities_Api66_Manager4 _utilities_Api66_Manager4;
        private readonly Portal_Validators227_Result _portal_Validators227_Result;
        private readonly Portal_Validators227_Range4 _portal_Validators227_Range4;

        public Consumer19(Admin_Processors35_Helper11 admin_Processors35_Helper11, IAdmin_Processors35_Repository3 iAdmin_Processors35_Repository3, Auth_Handlers209_Options auth_Handlers209_Options, Auth_Client271_Helper3 auth_Client271_Helper3, Auth_Client271_Manager auth_Client271_Manager, Utilities_Api66_Manager4 utilities_Api66_Manager4, Portal_Validators227_Result portal_Validators227_Result, Portal_Validators227_Range4 portal_Validators227_Range4)
        {
            _admin_Processors35_Helper11 = admin_Processors35_Helper11 ?? throw new ArgumentNullException(nameof(admin_Processors35_Helper11));
            _iAdmin_Processors35_Repository3 = iAdmin_Processors35_Repository3 ?? throw new ArgumentNullException(nameof(iAdmin_Processors35_Repository3));
            _auth_Handlers209_Options = auth_Handlers209_Options ?? throw new ArgumentNullException(nameof(auth_Handlers209_Options));
            _auth_Client271_Helper3 = auth_Client271_Helper3 ?? throw new ArgumentNullException(nameof(auth_Client271_Helper3));
            _auth_Client271_Manager = auth_Client271_Manager ?? throw new ArgumentNullException(nameof(auth_Client271_Manager));
            _utilities_Api66_Manager4 = utilities_Api66_Manager4 ?? throw new ArgumentNullException(nameof(utilities_Api66_Manager4));
            _portal_Validators227_Result = portal_Validators227_Result ?? throw new ArgumentNullException(nameof(portal_Validators227_Result));
            _portal_Validators227_Range4 = portal_Validators227_Range4 ?? throw new ArgumentNullException(nameof(portal_Validators227_Range4));
        }

        public Admin_Processors35_Helper11 GetAdmin_Processors35_Helper11() => _admin_Processors35_Helper11;
        public IAdmin_Processors35_Repository3 GetIAdmin_Processors35_Repository3() => _iAdmin_Processors35_Repository3;
        public Auth_Handlers209_Options GetAuth_Handlers209_Options() => _auth_Handlers209_Options;
        public Auth_Client271_Helper3 GetAuth_Client271_Helper3() => _auth_Client271_Helper3;
        public Auth_Client271_Manager GetAuth_Client271_Manager() => _auth_Client271_Manager;
        public Utilities_Api66_Manager4 GetUtilities_Api66_Manager4() => _utilities_Api66_Manager4;
        public Portal_Validators227_Result GetPortal_Validators227_Result() => _portal_Validators227_Result;
        public Portal_Validators227_Range4 GetPortal_Validators227_Range4() => _portal_Validators227_Range4;

/// <summary>
/// Validates the Consumer19 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer19(Consumer19Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer19));
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
/// Processes the Consumer19 operation asynchronously.
/// </summary>
public async Task<Consumer19Result> ProcessConsumer19Async(
    Consumer19Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer19), request.Id);

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
            return new Consumer19Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer19));
        return new Consumer19Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer19));
        return new Consumer19Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer19 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer19Dto>> GetConsumer19ListAsync(
    Consumer19Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer19Entity>().AsQueryable();

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
        .Select(x => new Consumer19Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer19Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer19Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer19Service(
    ILogger<Consumer19Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer19:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer19 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer19Data> GetCachedConsumer19Async(string key)
{
    var cacheKey = $"Consumer19_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer19Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer19SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Record46Id { get; set; }
public string Record46Name { get; set; }
public string Record46Description { get; set; }
public DateTime Record46CreatedAt { get; set; }
public DateTime? Record46UpdatedAt { get; set; }
public string Record46CreatedBy { get; set; }
public bool IsRecord46Active { get; set; }
public int Record46SortOrder { get; set; }


public int Attr97Id { get; set; }
public string Attr97Name { get; set; }
public string Attr97Description { get; set; }
public DateTime Attr97CreatedAt { get; set; }
public DateTime? Attr97UpdatedAt { get; set; }
public string Attr97CreatedBy { get; set; }
public bool IsAttr97Active { get; set; }
public int Attr97SortOrder { get; set; }


public int Config29Id { get; set; }
public string Config29Name { get; set; }
public string Config29Description { get; set; }
public DateTime Config29CreatedAt { get; set; }
public DateTime? Config29UpdatedAt { get; set; }
public string Config29CreatedBy { get; set; }
public bool IsConfig29Active { get; set; }
public int Config29SortOrder { get; set; }


public int Field63Id { get; set; }
public string Field63Name { get; set; }
public string Field63Description { get; set; }
public DateTime Field63CreatedAt { get; set; }
public DateTime? Field63UpdatedAt { get; set; }
public string Field63CreatedBy { get; set; }
public bool IsField63Active { get; set; }
public int Field63SortOrder { get; set; }


public int Entry98Id { get; set; }
public string Entry98Name { get; set; }
public string Entry98Description { get; set; }
public DateTime Entry98CreatedAt { get; set; }
public DateTime? Entry98UpdatedAt { get; set; }
public string Entry98CreatedBy { get; set; }
public bool IsEntry98Active { get; set; }
public int Entry98SortOrder { get; set; }


public int Entry27Id { get; set; }
public string Entry27Name { get; set; }
public string Entry27Description { get; set; }
public DateTime Entry27CreatedAt { get; set; }
public DateTime? Entry27UpdatedAt { get; set; }
public string Entry27CreatedBy { get; set; }
public bool IsEntry27Active { get; set; }
public int Entry27SortOrder { get; set; }


public int Detail94Id { get; set; }
public string Detail94Name { get; set; }
public string Detail94Description { get; set; }
public DateTime Detail94CreatedAt { get; set; }
public DateTime? Detail94UpdatedAt { get; set; }
public string Detail94CreatedBy { get; set; }
public bool IsDetail94Active { get; set; }
public int Detail94SortOrder { get; set; }


public int Config85Id { get; set; }
public string Config85Name { get; set; }
public string Config85Description { get; set; }
public DateTime Config85CreatedAt { get; set; }
public DateTime? Config85UpdatedAt { get; set; }
public string Config85CreatedBy { get; set; }
public bool IsConfig85Active { get; set; }
public int Config85SortOrder { get; set; }


public int Param61Id { get; set; }
public string Param61Name { get; set; }
public string Param61Description { get; set; }
public DateTime Param61CreatedAt { get; set; }
public DateTime? Param61UpdatedAt { get; set; }
public string Param61CreatedBy { get; set; }
public bool IsParam61Active { get; set; }
public int Param61SortOrder { get; set; }


public int Item90Id { get; set; }
public string Item90Name { get; set; }
public string Item90Description { get; set; }
public DateTime Item90CreatedAt { get; set; }
public DateTime? Item90UpdatedAt { get; set; }
public string Item90CreatedBy { get; set; }
public bool IsItem90Active { get; set; }
public int Item90SortOrder { get; set; }


public int Field64Id { get; set; }
public string Field64Name { get; set; }
public string Field64Description { get; set; }
public DateTime Field64CreatedAt { get; set; }
public DateTime? Field64UpdatedAt { get; set; }
public string Field64CreatedBy { get; set; }
public bool IsField64Active { get; set; }
public int Field64SortOrder { get; set; }


public int Config58Id { get; set; }
public string Config58Name { get; set; }
public string Config58Description { get; set; }
public DateTime Config58CreatedAt { get; set; }
public DateTime? Config58UpdatedAt { get; set; }
public string Config58CreatedBy { get; set; }
public bool IsConfig58Active { get; set; }
public int Config58SortOrder { get; set; }


public int Config29Id { get; set; }
public string Config29Name { get; set; }
public string Config29Description { get; set; }
public DateTime Config29CreatedAt { get; set; }
public DateTime? Config29UpdatedAt { get; set; }
public string Config29CreatedBy { get; set; }
public bool IsConfig29Active { get; set; }
public int Config29SortOrder { get; set; }


public int Attr42Id { get; set; }
public string Attr42Name { get; set; }
public string Attr42Description { get; set; }
public DateTime Attr42CreatedAt { get; set; }
public DateTime? Attr42UpdatedAt { get; set; }
public string Attr42CreatedBy { get; set; }
public bool IsAttr42Active { get; set; }
public int Attr42SortOrder { get; set; }


public int Item85Id { get; set; }
public string Item85Name { get; set; }
public string Item85Description { get; set; }
public DateTime Item85CreatedAt { get; set; }
public DateTime? Item85UpdatedAt { get; set; }
public string Item85CreatedBy { get; set; }
public bool IsItem85Active { get; set; }
public int Item85SortOrder { get; set; }


public int Attr66Id { get; set; }
public string Attr66Name { get; set; }
public string Attr66Description { get; set; }
public DateTime Attr66CreatedAt { get; set; }
public DateTime? Attr66UpdatedAt { get; set; }
public string Attr66CreatedBy { get; set; }
public bool IsAttr66Active { get; set; }
public int Attr66SortOrder { get; set; }


public int Record34Id { get; set; }
public string Record34Name { get; set; }
public string Record34Description { get; set; }
public DateTime Record34CreatedAt { get; set; }
public DateTime? Record34UpdatedAt { get; set; }
public string Record34CreatedBy { get; set; }
public bool IsRecord34Active { get; set; }
public int Record34SortOrder { get; set; }


public int Param84Id { get; set; }
public string Param84Name { get; set; }
public string Param84Description { get; set; }
public DateTime Param84CreatedAt { get; set; }
public DateTime? Param84UpdatedAt { get; set; }
public string Param84CreatedBy { get; set; }
public bool IsParam84Active { get; set; }
public int Param84SortOrder { get; set; }


public int Attr21Id { get; set; }
public string Attr21Name { get; set; }
public string Attr21Description { get; set; }
public DateTime Attr21CreatedAt { get; set; }
public DateTime? Attr21UpdatedAt { get; set; }
public string Attr21CreatedBy { get; set; }
public bool IsAttr21Active { get; set; }
public int Attr21SortOrder { get; set; }


public int Field59Id { get; set; }
public string Field59Name { get; set; }
public string Field59Description { get; set; }
public DateTime Field59CreatedAt { get; set; }
public DateTime? Field59UpdatedAt { get; set; }
public string Field59CreatedBy { get; set; }
public bool IsField59Active { get; set; }
public int Field59SortOrder { get; set; }


public int Config59Id { get; set; }
public string Config59Name { get; set; }
public string Config59Description { get; set; }
public DateTime Config59CreatedAt { get; set; }
public DateTime? Config59UpdatedAt { get; set; }
public string Config59CreatedBy { get; set; }
public bool IsConfig59Active { get; set; }
public int Config59SortOrder { get; set; }


public int Record50Id { get; set; }
public string Record50Name { get; set; }
public string Record50Description { get; set; }
public DateTime Record50CreatedAt { get; set; }
public DateTime? Record50UpdatedAt { get; set; }
public string Record50CreatedBy { get; set; }
public bool IsRecord50Active { get; set; }
public int Record50SortOrder { get; set; }


public int Item39Id { get; set; }
public string Item39Name { get; set; }
public string Item39Description { get; set; }
public DateTime Item39CreatedAt { get; set; }
public DateTime? Item39UpdatedAt { get; set; }
public string Item39CreatedBy { get; set; }
public bool IsItem39Active { get; set; }
public int Item39SortOrder { get; set; }


public int Field28Id { get; set; }
public string Field28Name { get; set; }
public string Field28Description { get; set; }
public DateTime Field28CreatedAt { get; set; }
public DateTime? Field28UpdatedAt { get; set; }
public string Field28CreatedBy { get; set; }
public bool IsField28Active { get; set; }
public int Field28SortOrder { get; set; }


public int Detail6Id { get; set; }
public string Detail6Name { get; set; }
public string Detail6Description { get; set; }
public DateTime Detail6CreatedAt { get; set; }
public DateTime? Detail6UpdatedAt { get; set; }
public string Detail6CreatedBy { get; set; }
public bool IsDetail6Active { get; set; }
public int Detail6SortOrder { get; set; }


public int Item91Id { get; set; }
public string Item91Name { get; set; }
public string Item91Description { get; set; }
public DateTime Item91CreatedAt { get; set; }
public DateTime? Item91UpdatedAt { get; set; }
public string Item91CreatedBy { get; set; }
public bool IsItem91Active { get; set; }
public int Item91SortOrder { get; set; }


public int Param99Id { get; set; }
public string Param99Name { get; set; }
public string Param99Description { get; set; }
public DateTime Param99CreatedAt { get; set; }
public DateTime? Param99UpdatedAt { get; set; }
public string Param99CreatedBy { get; set; }
public bool IsParam99Active { get; set; }
public int Param99SortOrder { get; set; }


public int Entry16Id { get; set; }
public string Entry16Name { get; set; }
public string Entry16Description { get; set; }
public DateTime Entry16CreatedAt { get; set; }
public DateTime? Entry16UpdatedAt { get; set; }
public string Entry16CreatedBy { get; set; }
public bool IsEntry16Active { get; set; }
public int Entry16SortOrder { get; set; }


public int Config93Id { get; set; }
public string Config93Name { get; set; }
public string Config93Description { get; set; }
public DateTime Config93CreatedAt { get; set; }
public DateTime? Config93UpdatedAt { get; set; }
public string Config93CreatedBy { get; set; }
public bool IsConfig93Active { get; set; }
public int Config93SortOrder { get; set; }


public int Attr93Id { get; set; }
public string Attr93Name { get; set; }
public string Attr93Description { get; set; }
public DateTime Attr93CreatedAt { get; set; }
public DateTime? Attr93UpdatedAt { get; set; }
public string Attr93CreatedBy { get; set; }
public bool IsAttr93Active { get; set; }
public int Attr93SortOrder { get; set; }


public int Attr80Id { get; set; }
public string Attr80Name { get; set; }
public string Attr80Description { get; set; }
public DateTime Attr80CreatedAt { get; set; }
public DateTime? Attr80UpdatedAt { get; set; }
public string Attr80CreatedBy { get; set; }
public bool IsAttr80Active { get; set; }
public int Attr80SortOrder { get; set; }


public int Item75Id { get; set; }
public string Item75Name { get; set; }
public string Item75Description { get; set; }
public DateTime Item75CreatedAt { get; set; }
public DateTime? Item75UpdatedAt { get; set; }
public string Item75CreatedBy { get; set; }
public bool IsItem75Active { get; set; }
public int Item75SortOrder { get; set; }


public int Detail97Id { get; set; }
public string Detail97Name { get; set; }
public string Detail97Description { get; set; }
public DateTime Detail97CreatedAt { get; set; }
public DateTime? Detail97UpdatedAt { get; set; }
public string Detail97CreatedBy { get; set; }
public bool IsDetail97Active { get; set; }
public int Detail97SortOrder { get; set; }


public int Attr6Id { get; set; }
public string Attr6Name { get; set; }
public string Attr6Description { get; set; }
public DateTime Attr6CreatedAt { get; set; }
public DateTime? Attr6UpdatedAt { get; set; }
public string Attr6CreatedBy { get; set; }
public bool IsAttr6Active { get; set; }
public int Attr6SortOrder { get; set; }


public int Config50Id { get; set; }
public string Config50Name { get; set; }
public string Config50Description { get; set; }
public DateTime Config50CreatedAt { get; set; }
public DateTime? Config50UpdatedAt { get; set; }
public string Config50CreatedBy { get; set; }
public bool IsConfig50Active { get; set; }
public int Config50SortOrder { get; set; }


public int Field28Id { get; set; }
public string Field28Name { get; set; }
public string Field28Description { get; set; }
public DateTime Field28CreatedAt { get; set; }
public DateTime? Field28UpdatedAt { get; set; }
public string Field28CreatedBy { get; set; }
public bool IsField28Active { get; set; }
public int Field28SortOrder { get; set; }


public int Entry60Id { get; set; }
public string Entry60Name { get; set; }
public string Entry60Description { get; set; }
public DateTime Entry60CreatedAt { get; set; }
public DateTime? Entry60UpdatedAt { get; set; }
public string Entry60CreatedBy { get; set; }
public bool IsEntry60Active { get; set; }
public int Entry60SortOrder { get; set; }


public int Attr74Id { get; set; }
public string Attr74Name { get; set; }
public string Attr74Description { get; set; }
public DateTime Attr74CreatedAt { get; set; }
public DateTime? Attr74UpdatedAt { get; set; }
public string Attr74CreatedBy { get; set; }
public bool IsAttr74Active { get; set; }
public int Attr74SortOrder { get; set; }


public int Param87Id { get; set; }
public string Param87Name { get; set; }
public string Param87Description { get; set; }
public DateTime Param87CreatedAt { get; set; }
public DateTime? Param87UpdatedAt { get; set; }
public string Param87CreatedBy { get; set; }
public bool IsParam87Active { get; set; }
public int Param87SortOrder { get; set; }


public int Config99Id { get; set; }
public string Config99Name { get; set; }
public string Config99Description { get; set; }
public DateTime Config99CreatedAt { get; set; }
public DateTime? Config99UpdatedAt { get; set; }
public string Config99CreatedBy { get; set; }
public bool IsConfig99Active { get; set; }
public int Config99SortOrder { get; set; }


public int Field28Id { get; set; }
public string Field28Name { get; set; }
public string Field28Description { get; set; }
public DateTime Field28CreatedAt { get; set; }
public DateTime? Field28UpdatedAt { get; set; }
public string Field28CreatedBy { get; set; }
public bool IsField28Active { get; set; }
public int Field28SortOrder { get; set; }


public int Entry55Id { get; set; }
public string Entry55Name { get; set; }
public string Entry55Description { get; set; }
public DateTime Entry55CreatedAt { get; set; }
public DateTime? Entry55UpdatedAt { get; set; }
public string Entry55CreatedBy { get; set; }
public bool IsEntry55Active { get; set; }
public int Entry55SortOrder { get; set; }


public int Detail25Id { get; set; }
public string Detail25Name { get; set; }
public string Detail25Description { get; set; }
public DateTime Detail25CreatedAt { get; set; }
public DateTime? Detail25UpdatedAt { get; set; }
public string Detail25CreatedBy { get; set; }
public bool IsDetail25Active { get; set; }
public int Detail25SortOrder { get; set; }


public int Record4Id { get; set; }
public string Record4Name { get; set; }
public string Record4Description { get; set; }
public DateTime Record4CreatedAt { get; set; }
public DateTime? Record4UpdatedAt { get; set; }
public string Record4CreatedBy { get; set; }
public bool IsRecord4Active { get; set; }
public int Record4SortOrder { get; set; }


public int Param58Id { get; set; }
public string Param58Name { get; set; }
public string Param58Description { get; set; }
public DateTime Param58CreatedAt { get; set; }
public DateTime? Param58UpdatedAt { get; set; }
public string Param58CreatedBy { get; set; }
public bool IsParam58Active { get; set; }
public int Param58SortOrder { get; set; }

    }
}