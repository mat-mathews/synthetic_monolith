using Admin.Data117;
using Admin.Events306;
using Admin.Service364;
using Auth.Mappers28;
using Auth.Tests;
using Billing.Client22;
using Billing.Contracts44;
using Billing.Mappers;
using Documents.Data;
using Documents.Data68;
using Export.Service30;
using Export.Web;
using GalaxyWorks.Processors16;
using Logging.Contracts373;
using Notifications.Tests;
using Portal.Tests323;
using Reporting.Api287;
using Scheduling.Processors80;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Imaging.Contracts473
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer14
    {
        private readonly Admin_Events306_Event4 _admin_Events306_Event4;
        private readonly Auth_Mappers28_Provider7 _auth_Mappers28_Provider7;
        private readonly Auth_Mappers28_Controller5 _auth_Mappers28_Controller5;
        private readonly Admin_Service364_Range _admin_Service364_Range;
        private readonly Admin_Service364_Manager10 _admin_Service364_Manager10;
        private readonly Reporting_Api287_Helper5 _reporting_Api287_Helper5;
        private readonly Reporting_Api287_Repository1 _reporting_Api287_Repository1;
        private readonly IAuth_Tests_Service2 _iAuth_Tests_Service2;

        public Consumer14(Admin_Events306_Event4 admin_Events306_Event4, Auth_Mappers28_Provider7 auth_Mappers28_Provider7, Auth_Mappers28_Controller5 auth_Mappers28_Controller5, Admin_Service364_Range admin_Service364_Range, Admin_Service364_Manager10 admin_Service364_Manager10, Reporting_Api287_Helper5 reporting_Api287_Helper5, Reporting_Api287_Repository1 reporting_Api287_Repository1, IAuth_Tests_Service2 iAuth_Tests_Service2)
        {
            _admin_Events306_Event4 = admin_Events306_Event4 ?? throw new ArgumentNullException(nameof(admin_Events306_Event4));
            _auth_Mappers28_Provider7 = auth_Mappers28_Provider7 ?? throw new ArgumentNullException(nameof(auth_Mappers28_Provider7));
            _auth_Mappers28_Controller5 = auth_Mappers28_Controller5 ?? throw new ArgumentNullException(nameof(auth_Mappers28_Controller5));
            _admin_Service364_Range = admin_Service364_Range ?? throw new ArgumentNullException(nameof(admin_Service364_Range));
            _admin_Service364_Manager10 = admin_Service364_Manager10 ?? throw new ArgumentNullException(nameof(admin_Service364_Manager10));
            _reporting_Api287_Helper5 = reporting_Api287_Helper5 ?? throw new ArgumentNullException(nameof(reporting_Api287_Helper5));
            _reporting_Api287_Repository1 = reporting_Api287_Repository1 ?? throw new ArgumentNullException(nameof(reporting_Api287_Repository1));
            _iAuth_Tests_Service2 = iAuth_Tests_Service2 ?? throw new ArgumentNullException(nameof(iAuth_Tests_Service2));
        }

        public Admin_Events306_Event4 GetAdmin_Events306_Event4() => _admin_Events306_Event4;
        public Auth_Mappers28_Provider7 GetAuth_Mappers28_Provider7() => _auth_Mappers28_Provider7;
        public Auth_Mappers28_Controller5 GetAuth_Mappers28_Controller5() => _auth_Mappers28_Controller5;
        public Admin_Service364_Range GetAdmin_Service364_Range() => _admin_Service364_Range;
        public Admin_Service364_Manager10 GetAdmin_Service364_Manager10() => _admin_Service364_Manager10;
        public Reporting_Api287_Helper5 GetReporting_Api287_Helper5() => _reporting_Api287_Helper5;
        public Reporting_Api287_Repository1 GetReporting_Api287_Repository1() => _reporting_Api287_Repository1;
        public IAuth_Tests_Service2 GetIAuth_Tests_Service2() => _iAuth_Tests_Service2;

/// <summary>
/// Validates the Consumer14 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer14(Consumer14Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer14));
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
/// Processes the Consumer14 operation asynchronously.
/// </summary>
public async Task<Consumer14Result> ProcessConsumer14Async(
    Consumer14Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer14), request.Id);

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
            return new Consumer14Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer14));
        return new Consumer14Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer14));
        return new Consumer14Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer14 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer14Dto>> GetConsumer14ListAsync(
    Consumer14Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer14Entity>().AsQueryable();

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
        .Select(x => new Consumer14Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer14Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer14Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer14Service(
    ILogger<Consumer14Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer14:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer14 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer14Data> GetCachedConsumer14Async(string key)
{
    var cacheKey = $"Consumer14_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer14Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer14SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Item87Id { get; set; }
public string Item87Name { get; set; }
public string Item87Description { get; set; }
public DateTime Item87CreatedAt { get; set; }
public DateTime? Item87UpdatedAt { get; set; }
public string Item87CreatedBy { get; set; }
public bool IsItem87Active { get; set; }
public int Item87SortOrder { get; set; }


public int Config9Id { get; set; }
public string Config9Name { get; set; }
public string Config9Description { get; set; }
public DateTime Config9CreatedAt { get; set; }
public DateTime? Config9UpdatedAt { get; set; }
public string Config9CreatedBy { get; set; }
public bool IsConfig9Active { get; set; }
public int Config9SortOrder { get; set; }


public int Config34Id { get; set; }
public string Config34Name { get; set; }
public string Config34Description { get; set; }
public DateTime Config34CreatedAt { get; set; }
public DateTime? Config34UpdatedAt { get; set; }
public string Config34CreatedBy { get; set; }
public bool IsConfig34Active { get; set; }
public int Config34SortOrder { get; set; }


public int Field29Id { get; set; }
public string Field29Name { get; set; }
public string Field29Description { get; set; }
public DateTime Field29CreatedAt { get; set; }
public DateTime? Field29UpdatedAt { get; set; }
public string Field29CreatedBy { get; set; }
public bool IsField29Active { get; set; }
public int Field29SortOrder { get; set; }


public int Param23Id { get; set; }
public string Param23Name { get; set; }
public string Param23Description { get; set; }
public DateTime Param23CreatedAt { get; set; }
public DateTime? Param23UpdatedAt { get; set; }
public string Param23CreatedBy { get; set; }
public bool IsParam23Active { get; set; }
public int Param23SortOrder { get; set; }


public int Detail56Id { get; set; }
public string Detail56Name { get; set; }
public string Detail56Description { get; set; }
public DateTime Detail56CreatedAt { get; set; }
public DateTime? Detail56UpdatedAt { get; set; }
public string Detail56CreatedBy { get; set; }
public bool IsDetail56Active { get; set; }
public int Detail56SortOrder { get; set; }


public int Detail10Id { get; set; }
public string Detail10Name { get; set; }
public string Detail10Description { get; set; }
public DateTime Detail10CreatedAt { get; set; }
public DateTime? Detail10UpdatedAt { get; set; }
public string Detail10CreatedBy { get; set; }
public bool IsDetail10Active { get; set; }
public int Detail10SortOrder { get; set; }


public int Item61Id { get; set; }
public string Item61Name { get; set; }
public string Item61Description { get; set; }
public DateTime Item61CreatedAt { get; set; }
public DateTime? Item61UpdatedAt { get; set; }
public string Item61CreatedBy { get; set; }
public bool IsItem61Active { get; set; }
public int Item61SortOrder { get; set; }


public int Entry58Id { get; set; }
public string Entry58Name { get; set; }
public string Entry58Description { get; set; }
public DateTime Entry58CreatedAt { get; set; }
public DateTime? Entry58UpdatedAt { get; set; }
public string Entry58CreatedBy { get; set; }
public bool IsEntry58Active { get; set; }
public int Entry58SortOrder { get; set; }


public int Attr27Id { get; set; }
public string Attr27Name { get; set; }
public string Attr27Description { get; set; }
public DateTime Attr27CreatedAt { get; set; }
public DateTime? Attr27UpdatedAt { get; set; }
public string Attr27CreatedBy { get; set; }
public bool IsAttr27Active { get; set; }
public int Attr27SortOrder { get; set; }


public int Param5Id { get; set; }
public string Param5Name { get; set; }
public string Param5Description { get; set; }
public DateTime Param5CreatedAt { get; set; }
public DateTime? Param5UpdatedAt { get; set; }
public string Param5CreatedBy { get; set; }
public bool IsParam5Active { get; set; }
public int Param5SortOrder { get; set; }


public int Config92Id { get; set; }
public string Config92Name { get; set; }
public string Config92Description { get; set; }
public DateTime Config92CreatedAt { get; set; }
public DateTime? Config92UpdatedAt { get; set; }
public string Config92CreatedBy { get; set; }
public bool IsConfig92Active { get; set; }
public int Config92SortOrder { get; set; }


public int Config8Id { get; set; }
public string Config8Name { get; set; }
public string Config8Description { get; set; }
public DateTime Config8CreatedAt { get; set; }
public DateTime? Config8UpdatedAt { get; set; }
public string Config8CreatedBy { get; set; }
public bool IsConfig8Active { get; set; }
public int Config8SortOrder { get; set; }


public int Field41Id { get; set; }
public string Field41Name { get; set; }
public string Field41Description { get; set; }
public DateTime Field41CreatedAt { get; set; }
public DateTime? Field41UpdatedAt { get; set; }
public string Field41CreatedBy { get; set; }
public bool IsField41Active { get; set; }
public int Field41SortOrder { get; set; }


public int Field38Id { get; set; }
public string Field38Name { get; set; }
public string Field38Description { get; set; }
public DateTime Field38CreatedAt { get; set; }
public DateTime? Field38UpdatedAt { get; set; }
public string Field38CreatedBy { get; set; }
public bool IsField38Active { get; set; }
public int Field38SortOrder { get; set; }


public int Detail10Id { get; set; }
public string Detail10Name { get; set; }
public string Detail10Description { get; set; }
public DateTime Detail10CreatedAt { get; set; }
public DateTime? Detail10UpdatedAt { get; set; }
public string Detail10CreatedBy { get; set; }
public bool IsDetail10Active { get; set; }
public int Detail10SortOrder { get; set; }


public int Item1Id { get; set; }
public string Item1Name { get; set; }
public string Item1Description { get; set; }
public DateTime Item1CreatedAt { get; set; }
public DateTime? Item1UpdatedAt { get; set; }
public string Item1CreatedBy { get; set; }
public bool IsItem1Active { get; set; }
public int Item1SortOrder { get; set; }


public int Detail27Id { get; set; }
public string Detail27Name { get; set; }
public string Detail27Description { get; set; }
public DateTime Detail27CreatedAt { get; set; }
public DateTime? Detail27UpdatedAt { get; set; }
public string Detail27CreatedBy { get; set; }
public bool IsDetail27Active { get; set; }
public int Detail27SortOrder { get; set; }


public int Entry24Id { get; set; }
public string Entry24Name { get; set; }
public string Entry24Description { get; set; }
public DateTime Entry24CreatedAt { get; set; }
public DateTime? Entry24UpdatedAt { get; set; }
public string Entry24CreatedBy { get; set; }
public bool IsEntry24Active { get; set; }
public int Entry24SortOrder { get; set; }


public int Attr36Id { get; set; }
public string Attr36Name { get; set; }
public string Attr36Description { get; set; }
public DateTime Attr36CreatedAt { get; set; }
public DateTime? Attr36UpdatedAt { get; set; }
public string Attr36CreatedBy { get; set; }
public bool IsAttr36Active { get; set; }
public int Attr36SortOrder { get; set; }


public int Detail52Id { get; set; }
public string Detail52Name { get; set; }
public string Detail52Description { get; set; }
public DateTime Detail52CreatedAt { get; set; }
public DateTime? Detail52UpdatedAt { get; set; }
public string Detail52CreatedBy { get; set; }
public bool IsDetail52Active { get; set; }
public int Detail52SortOrder { get; set; }


public int Record31Id { get; set; }
public string Record31Name { get; set; }
public string Record31Description { get; set; }
public DateTime Record31CreatedAt { get; set; }
public DateTime? Record31UpdatedAt { get; set; }
public string Record31CreatedBy { get; set; }
public bool IsRecord31Active { get; set; }
public int Record31SortOrder { get; set; }


public int Config77Id { get; set; }
public string Config77Name { get; set; }
public string Config77Description { get; set; }
public DateTime Config77CreatedAt { get; set; }
public DateTime? Config77UpdatedAt { get; set; }
public string Config77CreatedBy { get; set; }
public bool IsConfig77Active { get; set; }
public int Config77SortOrder { get; set; }


public int Item54Id { get; set; }
public string Item54Name { get; set; }
public string Item54Description { get; set; }
public DateTime Item54CreatedAt { get; set; }
public DateTime? Item54UpdatedAt { get; set; }
public string Item54CreatedBy { get; set; }
public bool IsItem54Active { get; set; }
public int Item54SortOrder { get; set; }


public int Attr96Id { get; set; }
public string Attr96Name { get; set; }
public string Attr96Description { get; set; }
public DateTime Attr96CreatedAt { get; set; }
public DateTime? Attr96UpdatedAt { get; set; }
public string Attr96CreatedBy { get; set; }
public bool IsAttr96Active { get; set; }
public int Attr96SortOrder { get; set; }


public int Detail65Id { get; set; }
public string Detail65Name { get; set; }
public string Detail65Description { get; set; }
public DateTime Detail65CreatedAt { get; set; }
public DateTime? Detail65UpdatedAt { get; set; }
public string Detail65CreatedBy { get; set; }
public bool IsDetail65Active { get; set; }
public int Detail65SortOrder { get; set; }


public int Config57Id { get; set; }
public string Config57Name { get; set; }
public string Config57Description { get; set; }
public DateTime Config57CreatedAt { get; set; }
public DateTime? Config57UpdatedAt { get; set; }
public string Config57CreatedBy { get; set; }
public bool IsConfig57Active { get; set; }
public int Config57SortOrder { get; set; }


public int Param94Id { get; set; }
public string Param94Name { get; set; }
public string Param94Description { get; set; }
public DateTime Param94CreatedAt { get; set; }
public DateTime? Param94UpdatedAt { get; set; }
public string Param94CreatedBy { get; set; }
public bool IsParam94Active { get; set; }
public int Param94SortOrder { get; set; }


public int Entry85Id { get; set; }
public string Entry85Name { get; set; }
public string Entry85Description { get; set; }
public DateTime Entry85CreatedAt { get; set; }
public DateTime? Entry85UpdatedAt { get; set; }
public string Entry85CreatedBy { get; set; }
public bool IsEntry85Active { get; set; }
public int Entry85SortOrder { get; set; }


public int Item35Id { get; set; }
public string Item35Name { get; set; }
public string Item35Description { get; set; }
public DateTime Item35CreatedAt { get; set; }
public DateTime? Item35UpdatedAt { get; set; }
public string Item35CreatedBy { get; set; }
public bool IsItem35Active { get; set; }
public int Item35SortOrder { get; set; }


public int Entry31Id { get; set; }
public string Entry31Name { get; set; }
public string Entry31Description { get; set; }
public DateTime Entry31CreatedAt { get; set; }
public DateTime? Entry31UpdatedAt { get; set; }
public string Entry31CreatedBy { get; set; }
public bool IsEntry31Active { get; set; }
public int Entry31SortOrder { get; set; }


public int Entry59Id { get; set; }
public string Entry59Name { get; set; }
public string Entry59Description { get; set; }
public DateTime Entry59CreatedAt { get; set; }
public DateTime? Entry59UpdatedAt { get; set; }
public string Entry59CreatedBy { get; set; }
public bool IsEntry59Active { get; set; }
public int Entry59SortOrder { get; set; }


public int Config58Id { get; set; }
public string Config58Name { get; set; }
public string Config58Description { get; set; }
public DateTime Config58CreatedAt { get; set; }
public DateTime? Config58UpdatedAt { get; set; }
public string Config58CreatedBy { get; set; }
public bool IsConfig58Active { get; set; }
public int Config58SortOrder { get; set; }


public int Entry68Id { get; set; }
public string Entry68Name { get; set; }
public string Entry68Description { get; set; }
public DateTime Entry68CreatedAt { get; set; }
public DateTime? Entry68UpdatedAt { get; set; }
public string Entry68CreatedBy { get; set; }
public bool IsEntry68Active { get; set; }
public int Entry68SortOrder { get; set; }


public int Record98Id { get; set; }
public string Record98Name { get; set; }
public string Record98Description { get; set; }
public DateTime Record98CreatedAt { get; set; }
public DateTime? Record98UpdatedAt { get; set; }
public string Record98CreatedBy { get; set; }
public bool IsRecord98Active { get; set; }
public int Record98SortOrder { get; set; }


public int Field73Id { get; set; }
public string Field73Name { get; set; }
public string Field73Description { get; set; }
public DateTime Field73CreatedAt { get; set; }
public DateTime? Field73UpdatedAt { get; set; }
public string Field73CreatedBy { get; set; }
public bool IsField73Active { get; set; }
public int Field73SortOrder { get; set; }


public int Field74Id { get; set; }
public string Field74Name { get; set; }
public string Field74Description { get; set; }
public DateTime Field74CreatedAt { get; set; }
public DateTime? Field74UpdatedAt { get; set; }
public string Field74CreatedBy { get; set; }
public bool IsField74Active { get; set; }
public int Field74SortOrder { get; set; }


public int Item93Id { get; set; }
public string Item93Name { get; set; }
public string Item93Description { get; set; }
public DateTime Item93CreatedAt { get; set; }
public DateTime? Item93UpdatedAt { get; set; }
public string Item93CreatedBy { get; set; }
public bool IsItem93Active { get; set; }
public int Item93SortOrder { get; set; }


public int Record53Id { get; set; }
public string Record53Name { get; set; }
public string Record53Description { get; set; }
public DateTime Record53CreatedAt { get; set; }
public DateTime? Record53UpdatedAt { get; set; }
public string Record53CreatedBy { get; set; }
public bool IsRecord53Active { get; set; }
public int Record53SortOrder { get; set; }


public int Config67Id { get; set; }
public string Config67Name { get; set; }
public string Config67Description { get; set; }
public DateTime Config67CreatedAt { get; set; }
public DateTime? Config67UpdatedAt { get; set; }
public string Config67CreatedBy { get; set; }
public bool IsConfig67Active { get; set; }
public int Config67SortOrder { get; set; }


public int Attr99Id { get; set; }
public string Attr99Name { get; set; }
public string Attr99Description { get; set; }
public DateTime Attr99CreatedAt { get; set; }
public DateTime? Attr99UpdatedAt { get; set; }
public string Attr99CreatedBy { get; set; }
public bool IsAttr99Active { get; set; }
public int Attr99SortOrder { get; set; }


public int Attr11Id { get; set; }
public string Attr11Name { get; set; }
public string Attr11Description { get; set; }
public DateTime Attr11CreatedAt { get; set; }
public DateTime? Attr11UpdatedAt { get; set; }
public string Attr11CreatedBy { get; set; }
public bool IsAttr11Active { get; set; }
public int Attr11SortOrder { get; set; }


public int Param44Id { get; set; }
public string Param44Name { get; set; }
public string Param44Description { get; set; }
public DateTime Param44CreatedAt { get; set; }
public DateTime? Param44UpdatedAt { get; set; }
public string Param44CreatedBy { get; set; }
public bool IsParam44Active { get; set; }
public int Param44SortOrder { get; set; }


public int Attr47Id { get; set; }
public string Attr47Name { get; set; }
public string Attr47Description { get; set; }
public DateTime Attr47CreatedAt { get; set; }
public DateTime? Attr47UpdatedAt { get; set; }
public string Attr47CreatedBy { get; set; }
public bool IsAttr47Active { get; set; }
public int Attr47SortOrder { get; set; }


public int Detail6Id { get; set; }
public string Detail6Name { get; set; }
public string Detail6Description { get; set; }
public DateTime Detail6CreatedAt { get; set; }
public DateTime? Detail6UpdatedAt { get; set; }
public string Detail6CreatedBy { get; set; }
public bool IsDetail6Active { get; set; }
public int Detail6SortOrder { get; set; }


public int Detail92Id { get; set; }
public string Detail92Name { get; set; }
public string Detail92Description { get; set; }
public DateTime Detail92CreatedAt { get; set; }
public DateTime? Detail92UpdatedAt { get; set; }
public string Detail92CreatedBy { get; set; }
public bool IsDetail92Active { get; set; }
public int Detail92SortOrder { get; set; }

    }
}