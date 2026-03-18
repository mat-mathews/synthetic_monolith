using Admin.Events306;
using Billing.Contracts44;
using Billing.Tests;
using Common.Web488;
using Documents.Data490;
using Export.Api49;
using GalaxyWorks.Service;
using Imaging.Core204;
using Import.Client64;
using Import.Data193;
using Integration.Mappers242;
using Logging.Shared;
using Notifications.Handlers;
using Portal.Service231;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Api387;
using Utilities.Contracts24;

namespace Notifications.Models
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer15
    {
        private readonly IAdmin_Events306_Factory _iAdmin_Events306_Factory;
        private readonly Admin_Events306_Helper1 _admin_Events306_Helper1;
        private readonly Admin_Events306_Event4 _admin_Events306_Event4;
        private readonly GalaxyWorks_Service_Controller3 _galaxyWorks_Service_Controller3;
        private readonly Utilities_Contracts24_Manager _utilities_Contracts24_Manager;
        private readonly Utilities_Contracts24_Repository7 _utilities_Contracts24_Repository7;
        private readonly IPortal_Service231_Service3 _iPortal_Service231_Service3;
        private readonly Integration_Mappers242_Processor _integration_Mappers242_Processor;

        public Consumer15(IAdmin_Events306_Factory iAdmin_Events306_Factory, Admin_Events306_Helper1 admin_Events306_Helper1, Admin_Events306_Event4 admin_Events306_Event4, GalaxyWorks_Service_Controller3 galaxyWorks_Service_Controller3, Utilities_Contracts24_Manager utilities_Contracts24_Manager, Utilities_Contracts24_Repository7 utilities_Contracts24_Repository7, IPortal_Service231_Service3 iPortal_Service231_Service3, Integration_Mappers242_Processor integration_Mappers242_Processor)
        {
            _iAdmin_Events306_Factory = iAdmin_Events306_Factory ?? throw new ArgumentNullException(nameof(iAdmin_Events306_Factory));
            _admin_Events306_Helper1 = admin_Events306_Helper1 ?? throw new ArgumentNullException(nameof(admin_Events306_Helper1));
            _admin_Events306_Event4 = admin_Events306_Event4 ?? throw new ArgumentNullException(nameof(admin_Events306_Event4));
            _galaxyWorks_Service_Controller3 = galaxyWorks_Service_Controller3 ?? throw new ArgumentNullException(nameof(galaxyWorks_Service_Controller3));
            _utilities_Contracts24_Manager = utilities_Contracts24_Manager ?? throw new ArgumentNullException(nameof(utilities_Contracts24_Manager));
            _utilities_Contracts24_Repository7 = utilities_Contracts24_Repository7 ?? throw new ArgumentNullException(nameof(utilities_Contracts24_Repository7));
            _iPortal_Service231_Service3 = iPortal_Service231_Service3 ?? throw new ArgumentNullException(nameof(iPortal_Service231_Service3));
            _integration_Mappers242_Processor = integration_Mappers242_Processor ?? throw new ArgumentNullException(nameof(integration_Mappers242_Processor));
        }

        public IAdmin_Events306_Factory GetIAdmin_Events306_Factory() => _iAdmin_Events306_Factory;
        public Admin_Events306_Helper1 GetAdmin_Events306_Helper1() => _admin_Events306_Helper1;
        public Admin_Events306_Event4 GetAdmin_Events306_Event4() => _admin_Events306_Event4;
        public GalaxyWorks_Service_Controller3 GetGalaxyWorks_Service_Controller3() => _galaxyWorks_Service_Controller3;
        public Utilities_Contracts24_Manager GetUtilities_Contracts24_Manager() => _utilities_Contracts24_Manager;
        public Utilities_Contracts24_Repository7 GetUtilities_Contracts24_Repository7() => _utilities_Contracts24_Repository7;
        public IPortal_Service231_Service3 GetIPortal_Service231_Service3() => _iPortal_Service231_Service3;
        public Integration_Mappers242_Processor GetIntegration_Mappers242_Processor() => _integration_Mappers242_Processor;

/// <summary>
/// Validates the Consumer15 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer15(Consumer15Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer15));
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
/// Processes the Consumer15 operation asynchronously.
/// </summary>
public async Task<Consumer15Result> ProcessConsumer15Async(
    Consumer15Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer15), request.Id);

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
            return new Consumer15Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer15));
        return new Consumer15Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer15));
        return new Consumer15Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer15 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer15Dto>> GetConsumer15ListAsync(
    Consumer15Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer15Entity>().AsQueryable();

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
        .Select(x => new Consumer15Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer15Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer15Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer15Service(
    ILogger<Consumer15Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer15:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer15 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer15Data> GetCachedConsumer15Async(string key)
{
    var cacheKey = $"Consumer15_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer15Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer15SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Entry84Id { get; set; }
public string Entry84Name { get; set; }
public string Entry84Description { get; set; }
public DateTime Entry84CreatedAt { get; set; }
public DateTime? Entry84UpdatedAt { get; set; }
public string Entry84CreatedBy { get; set; }
public bool IsEntry84Active { get; set; }
public int Entry84SortOrder { get; set; }


public int Field35Id { get; set; }
public string Field35Name { get; set; }
public string Field35Description { get; set; }
public DateTime Field35CreatedAt { get; set; }
public DateTime? Field35UpdatedAt { get; set; }
public string Field35CreatedBy { get; set; }
public bool IsField35Active { get; set; }
public int Field35SortOrder { get; set; }


public int Entry48Id { get; set; }
public string Entry48Name { get; set; }
public string Entry48Description { get; set; }
public DateTime Entry48CreatedAt { get; set; }
public DateTime? Entry48UpdatedAt { get; set; }
public string Entry48CreatedBy { get; set; }
public bool IsEntry48Active { get; set; }
public int Entry48SortOrder { get; set; }


public int Field23Id { get; set; }
public string Field23Name { get; set; }
public string Field23Description { get; set; }
public DateTime Field23CreatedAt { get; set; }
public DateTime? Field23UpdatedAt { get; set; }
public string Field23CreatedBy { get; set; }
public bool IsField23Active { get; set; }
public int Field23SortOrder { get; set; }


public int Detail45Id { get; set; }
public string Detail45Name { get; set; }
public string Detail45Description { get; set; }
public DateTime Detail45CreatedAt { get; set; }
public DateTime? Detail45UpdatedAt { get; set; }
public string Detail45CreatedBy { get; set; }
public bool IsDetail45Active { get; set; }
public int Detail45SortOrder { get; set; }


public int Attr89Id { get; set; }
public string Attr89Name { get; set; }
public string Attr89Description { get; set; }
public DateTime Attr89CreatedAt { get; set; }
public DateTime? Attr89UpdatedAt { get; set; }
public string Attr89CreatedBy { get; set; }
public bool IsAttr89Active { get; set; }
public int Attr89SortOrder { get; set; }


public int Config85Id { get; set; }
public string Config85Name { get; set; }
public string Config85Description { get; set; }
public DateTime Config85CreatedAt { get; set; }
public DateTime? Config85UpdatedAt { get; set; }
public string Config85CreatedBy { get; set; }
public bool IsConfig85Active { get; set; }
public int Config85SortOrder { get; set; }


public int Item55Id { get; set; }
public string Item55Name { get; set; }
public string Item55Description { get; set; }
public DateTime Item55CreatedAt { get; set; }
public DateTime? Item55UpdatedAt { get; set; }
public string Item55CreatedBy { get; set; }
public bool IsItem55Active { get; set; }
public int Item55SortOrder { get; set; }


public int Attr6Id { get; set; }
public string Attr6Name { get; set; }
public string Attr6Description { get; set; }
public DateTime Attr6CreatedAt { get; set; }
public DateTime? Attr6UpdatedAt { get; set; }
public string Attr6CreatedBy { get; set; }
public bool IsAttr6Active { get; set; }
public int Attr6SortOrder { get; set; }


public int Detail69Id { get; set; }
public string Detail69Name { get; set; }
public string Detail69Description { get; set; }
public DateTime Detail69CreatedAt { get; set; }
public DateTime? Detail69UpdatedAt { get; set; }
public string Detail69CreatedBy { get; set; }
public bool IsDetail69Active { get; set; }
public int Detail69SortOrder { get; set; }


public int Entry74Id { get; set; }
public string Entry74Name { get; set; }
public string Entry74Description { get; set; }
public DateTime Entry74CreatedAt { get; set; }
public DateTime? Entry74UpdatedAt { get; set; }
public string Entry74CreatedBy { get; set; }
public bool IsEntry74Active { get; set; }
public int Entry74SortOrder { get; set; }


public int Entry27Id { get; set; }
public string Entry27Name { get; set; }
public string Entry27Description { get; set; }
public DateTime Entry27CreatedAt { get; set; }
public DateTime? Entry27UpdatedAt { get; set; }
public string Entry27CreatedBy { get; set; }
public bool IsEntry27Active { get; set; }
public int Entry27SortOrder { get; set; }


public int Attr99Id { get; set; }
public string Attr99Name { get; set; }
public string Attr99Description { get; set; }
public DateTime Attr99CreatedAt { get; set; }
public DateTime? Attr99UpdatedAt { get; set; }
public string Attr99CreatedBy { get; set; }
public bool IsAttr99Active { get; set; }
public int Attr99SortOrder { get; set; }


public int Record27Id { get; set; }
public string Record27Name { get; set; }
public string Record27Description { get; set; }
public DateTime Record27CreatedAt { get; set; }
public DateTime? Record27UpdatedAt { get; set; }
public string Record27CreatedBy { get; set; }
public bool IsRecord27Active { get; set; }
public int Record27SortOrder { get; set; }


public int Detail31Id { get; set; }
public string Detail31Name { get; set; }
public string Detail31Description { get; set; }
public DateTime Detail31CreatedAt { get; set; }
public DateTime? Detail31UpdatedAt { get; set; }
public string Detail31CreatedBy { get; set; }
public bool IsDetail31Active { get; set; }
public int Detail31SortOrder { get; set; }


public int Field41Id { get; set; }
public string Field41Name { get; set; }
public string Field41Description { get; set; }
public DateTime Field41CreatedAt { get; set; }
public DateTime? Field41UpdatedAt { get; set; }
public string Field41CreatedBy { get; set; }
public bool IsField41Active { get; set; }
public int Field41SortOrder { get; set; }


public int Item51Id { get; set; }
public string Item51Name { get; set; }
public string Item51Description { get; set; }
public DateTime Item51CreatedAt { get; set; }
public DateTime? Item51UpdatedAt { get; set; }
public string Item51CreatedBy { get; set; }
public bool IsItem51Active { get; set; }
public int Item51SortOrder { get; set; }


public int Detail84Id { get; set; }
public string Detail84Name { get; set; }
public string Detail84Description { get; set; }
public DateTime Detail84CreatedAt { get; set; }
public DateTime? Detail84UpdatedAt { get; set; }
public string Detail84CreatedBy { get; set; }
public bool IsDetail84Active { get; set; }
public int Detail84SortOrder { get; set; }


public int Param85Id { get; set; }
public string Param85Name { get; set; }
public string Param85Description { get; set; }
public DateTime Param85CreatedAt { get; set; }
public DateTime? Param85UpdatedAt { get; set; }
public string Param85CreatedBy { get; set; }
public bool IsParam85Active { get; set; }
public int Param85SortOrder { get; set; }


public int Record72Id { get; set; }
public string Record72Name { get; set; }
public string Record72Description { get; set; }
public DateTime Record72CreatedAt { get; set; }
public DateTime? Record72UpdatedAt { get; set; }
public string Record72CreatedBy { get; set; }
public bool IsRecord72Active { get; set; }
public int Record72SortOrder { get; set; }


public int Field46Id { get; set; }
public string Field46Name { get; set; }
public string Field46Description { get; set; }
public DateTime Field46CreatedAt { get; set; }
public DateTime? Field46UpdatedAt { get; set; }
public string Field46CreatedBy { get; set; }
public bool IsField46Active { get; set; }
public int Field46SortOrder { get; set; }


public int Entry60Id { get; set; }
public string Entry60Name { get; set; }
public string Entry60Description { get; set; }
public DateTime Entry60CreatedAt { get; set; }
public DateTime? Entry60UpdatedAt { get; set; }
public string Entry60CreatedBy { get; set; }
public bool IsEntry60Active { get; set; }
public int Entry60SortOrder { get; set; }


public int Field93Id { get; set; }
public string Field93Name { get; set; }
public string Field93Description { get; set; }
public DateTime Field93CreatedAt { get; set; }
public DateTime? Field93UpdatedAt { get; set; }
public string Field93CreatedBy { get; set; }
public bool IsField93Active { get; set; }
public int Field93SortOrder { get; set; }


public int Detail33Id { get; set; }
public string Detail33Name { get; set; }
public string Detail33Description { get; set; }
public DateTime Detail33CreatedAt { get; set; }
public DateTime? Detail33UpdatedAt { get; set; }
public string Detail33CreatedBy { get; set; }
public bool IsDetail33Active { get; set; }
public int Detail33SortOrder { get; set; }


public int Param77Id { get; set; }
public string Param77Name { get; set; }
public string Param77Description { get; set; }
public DateTime Param77CreatedAt { get; set; }
public DateTime? Param77UpdatedAt { get; set; }
public string Param77CreatedBy { get; set; }
public bool IsParam77Active { get; set; }
public int Param77SortOrder { get; set; }


public int Item77Id { get; set; }
public string Item77Name { get; set; }
public string Item77Description { get; set; }
public DateTime Item77CreatedAt { get; set; }
public DateTime? Item77UpdatedAt { get; set; }
public string Item77CreatedBy { get; set; }
public bool IsItem77Active { get; set; }
public int Item77SortOrder { get; set; }


public int Record64Id { get; set; }
public string Record64Name { get; set; }
public string Record64Description { get; set; }
public DateTime Record64CreatedAt { get; set; }
public DateTime? Record64UpdatedAt { get; set; }
public string Record64CreatedBy { get; set; }
public bool IsRecord64Active { get; set; }
public int Record64SortOrder { get; set; }


public int Attr41Id { get; set; }
public string Attr41Name { get; set; }
public string Attr41Description { get; set; }
public DateTime Attr41CreatedAt { get; set; }
public DateTime? Attr41UpdatedAt { get; set; }
public string Attr41CreatedBy { get; set; }
public bool IsAttr41Active { get; set; }
public int Attr41SortOrder { get; set; }


public int Entry58Id { get; set; }
public string Entry58Name { get; set; }
public string Entry58Description { get; set; }
public DateTime Entry58CreatedAt { get; set; }
public DateTime? Entry58UpdatedAt { get; set; }
public string Entry58CreatedBy { get; set; }
public bool IsEntry58Active { get; set; }
public int Entry58SortOrder { get; set; }


public int Config30Id { get; set; }
public string Config30Name { get; set; }
public string Config30Description { get; set; }
public DateTime Config30CreatedAt { get; set; }
public DateTime? Config30UpdatedAt { get; set; }
public string Config30CreatedBy { get; set; }
public bool IsConfig30Active { get; set; }
public int Config30SortOrder { get; set; }


public int Item91Id { get; set; }
public string Item91Name { get; set; }
public string Item91Description { get; set; }
public DateTime Item91CreatedAt { get; set; }
public DateTime? Item91UpdatedAt { get; set; }
public string Item91CreatedBy { get; set; }
public bool IsItem91Active { get; set; }
public int Item91SortOrder { get; set; }


public int Config23Id { get; set; }
public string Config23Name { get; set; }
public string Config23Description { get; set; }
public DateTime Config23CreatedAt { get; set; }
public DateTime? Config23UpdatedAt { get; set; }
public string Config23CreatedBy { get; set; }
public bool IsConfig23Active { get; set; }
public int Config23SortOrder { get; set; }


public int Param87Id { get; set; }
public string Param87Name { get; set; }
public string Param87Description { get; set; }
public DateTime Param87CreatedAt { get; set; }
public DateTime? Param87UpdatedAt { get; set; }
public string Param87CreatedBy { get; set; }
public bool IsParam87Active { get; set; }
public int Param87SortOrder { get; set; }


public int Field61Id { get; set; }
public string Field61Name { get; set; }
public string Field61Description { get; set; }
public DateTime Field61CreatedAt { get; set; }
public DateTime? Field61UpdatedAt { get; set; }
public string Field61CreatedBy { get; set; }
public bool IsField61Active { get; set; }
public int Field61SortOrder { get; set; }


public int Detail31Id { get; set; }
public string Detail31Name { get; set; }
public string Detail31Description { get; set; }
public DateTime Detail31CreatedAt { get; set; }
public DateTime? Detail31UpdatedAt { get; set; }
public string Detail31CreatedBy { get; set; }
public bool IsDetail31Active { get; set; }
public int Detail31SortOrder { get; set; }


public int Record91Id { get; set; }
public string Record91Name { get; set; }
public string Record91Description { get; set; }
public DateTime Record91CreatedAt { get; set; }
public DateTime? Record91UpdatedAt { get; set; }
public string Record91CreatedBy { get; set; }
public bool IsRecord91Active { get; set; }
public int Record91SortOrder { get; set; }


public int Field15Id { get; set; }
public string Field15Name { get; set; }
public string Field15Description { get; set; }
public DateTime Field15CreatedAt { get; set; }
public DateTime? Field15UpdatedAt { get; set; }
public string Field15CreatedBy { get; set; }
public bool IsField15Active { get; set; }
public int Field15SortOrder { get; set; }


public int Detail50Id { get; set; }
public string Detail50Name { get; set; }
public string Detail50Description { get; set; }
public DateTime Detail50CreatedAt { get; set; }
public DateTime? Detail50UpdatedAt { get; set; }
public string Detail50CreatedBy { get; set; }
public bool IsDetail50Active { get; set; }
public int Detail50SortOrder { get; set; }


public int Entry22Id { get; set; }
public string Entry22Name { get; set; }
public string Entry22Description { get; set; }
public DateTime Entry22CreatedAt { get; set; }
public DateTime? Entry22UpdatedAt { get; set; }
public string Entry22CreatedBy { get; set; }
public bool IsEntry22Active { get; set; }
public int Entry22SortOrder { get; set; }


public int Attr29Id { get; set; }
public string Attr29Name { get; set; }
public string Attr29Description { get; set; }
public DateTime Attr29CreatedAt { get; set; }
public DateTime? Attr29UpdatedAt { get; set; }
public string Attr29CreatedBy { get; set; }
public bool IsAttr29Active { get; set; }
public int Attr29SortOrder { get; set; }


public int Param71Id { get; set; }
public string Param71Name { get; set; }
public string Param71Description { get; set; }
public DateTime Param71CreatedAt { get; set; }
public DateTime? Param71UpdatedAt { get; set; }
public string Param71CreatedBy { get; set; }
public bool IsParam71Active { get; set; }
public int Param71SortOrder { get; set; }


public int Attr27Id { get; set; }
public string Attr27Name { get; set; }
public string Attr27Description { get; set; }
public DateTime Attr27CreatedAt { get; set; }
public DateTime? Attr27UpdatedAt { get; set; }
public string Attr27CreatedBy { get; set; }
public bool IsAttr27Active { get; set; }
public int Attr27SortOrder { get; set; }


public int Attr73Id { get; set; }
public string Attr73Name { get; set; }
public string Attr73Description { get; set; }
public DateTime Attr73CreatedAt { get; set; }
public DateTime? Attr73UpdatedAt { get; set; }
public string Attr73CreatedBy { get; set; }
public bool IsAttr73Active { get; set; }
public int Attr73SortOrder { get; set; }


public int Item18Id { get; set; }
public string Item18Name { get; set; }
public string Item18Description { get; set; }
public DateTime Item18CreatedAt { get; set; }
public DateTime? Item18UpdatedAt { get; set; }
public string Item18CreatedBy { get; set; }
public bool IsItem18Active { get; set; }
public int Item18SortOrder { get; set; }


public int Record26Id { get; set; }
public string Record26Name { get; set; }
public string Record26Description { get; set; }
public DateTime Record26CreatedAt { get; set; }
public DateTime? Record26UpdatedAt { get; set; }
public string Record26CreatedBy { get; set; }
public bool IsRecord26Active { get; set; }
public int Record26SortOrder { get; set; }

    }
}