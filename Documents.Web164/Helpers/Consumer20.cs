using Admin.Service456;
using Admin.Validators240;
using Admin.Validators431;
using Auth.Api116;
using Auth.Api143;
using Billing.Client182;
using Billing.Contracts;
using Billing.Service432;
using Common.Api57;
using Common.Processors142;
using Common.Shared95;
using Documents.Api;
using GalaxyWorks.Data96;
using Notifications.Data446;
using Portal.Validators250;
using Scheduling.Models;
using Security.Contracts72;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Mappers197;

namespace Documents.Web164
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer20
    {
        private readonly Auth_Api116_Range5 _auth_Api116_Range5;
        private readonly IAuth_Api116_Repository1 _iAuth_Api116_Repository1;
        private readonly Auth_Api116_Service7 _auth_Api116_Service7;
        private readonly Admin_Validators431_Key8 _admin_Validators431_Key8;
        private readonly Admin_Validators240_Processor9 _admin_Validators240_Processor9;
        private readonly Admin_Validators240_Result2 _admin_Validators240_Result2;
        private readonly Admin_Validators240_Controller3 _admin_Validators240_Controller3;
        private readonly ICommon_Shared95_Service5 _iCommon_Shared95_Service5;

        public Consumer20(Auth_Api116_Range5 auth_Api116_Range5, IAuth_Api116_Repository1 iAuth_Api116_Repository1, Auth_Api116_Service7 auth_Api116_Service7, Admin_Validators431_Key8 admin_Validators431_Key8, Admin_Validators240_Processor9 admin_Validators240_Processor9, Admin_Validators240_Result2 admin_Validators240_Result2, Admin_Validators240_Controller3 admin_Validators240_Controller3, ICommon_Shared95_Service5 iCommon_Shared95_Service5)
        {
            _auth_Api116_Range5 = auth_Api116_Range5 ?? throw new ArgumentNullException(nameof(auth_Api116_Range5));
            _iAuth_Api116_Repository1 = iAuth_Api116_Repository1 ?? throw new ArgumentNullException(nameof(iAuth_Api116_Repository1));
            _auth_Api116_Service7 = auth_Api116_Service7 ?? throw new ArgumentNullException(nameof(auth_Api116_Service7));
            _admin_Validators431_Key8 = admin_Validators431_Key8 ?? throw new ArgumentNullException(nameof(admin_Validators431_Key8));
            _admin_Validators240_Processor9 = admin_Validators240_Processor9 ?? throw new ArgumentNullException(nameof(admin_Validators240_Processor9));
            _admin_Validators240_Result2 = admin_Validators240_Result2 ?? throw new ArgumentNullException(nameof(admin_Validators240_Result2));
            _admin_Validators240_Controller3 = admin_Validators240_Controller3 ?? throw new ArgumentNullException(nameof(admin_Validators240_Controller3));
            _iCommon_Shared95_Service5 = iCommon_Shared95_Service5 ?? throw new ArgumentNullException(nameof(iCommon_Shared95_Service5));
        }

        public Auth_Api116_Range5 GetAuth_Api116_Range5() => _auth_Api116_Range5;
        public IAuth_Api116_Repository1 GetIAuth_Api116_Repository1() => _iAuth_Api116_Repository1;
        public Auth_Api116_Service7 GetAuth_Api116_Service7() => _auth_Api116_Service7;
        public Admin_Validators431_Key8 GetAdmin_Validators431_Key8() => _admin_Validators431_Key8;
        public Admin_Validators240_Processor9 GetAdmin_Validators240_Processor9() => _admin_Validators240_Processor9;
        public Admin_Validators240_Result2 GetAdmin_Validators240_Result2() => _admin_Validators240_Result2;
        public Admin_Validators240_Controller3 GetAdmin_Validators240_Controller3() => _admin_Validators240_Controller3;
        public ICommon_Shared95_Service5 GetICommon_Shared95_Service5() => _iCommon_Shared95_Service5;

/// <summary>
/// Validates the Consumer20 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer20(Consumer20Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer20));
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
/// Processes the Consumer20 operation asynchronously.
/// </summary>
public async Task<Consumer20Result> ProcessConsumer20Async(
    Consumer20Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer20), request.Id);

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
            return new Consumer20Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer20));
        return new Consumer20Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer20));
        return new Consumer20Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer20 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer20Dto>> GetConsumer20ListAsync(
    Consumer20Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer20Entity>().AsQueryable();

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
        .Select(x => new Consumer20Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer20Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer20Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer20Service(
    ILogger<Consumer20Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer20:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer20 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer20Data> GetCachedConsumer20Async(string key)
{
    var cacheKey = $"Consumer20_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer20Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer20SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Config18Id { get; set; }
public string Config18Name { get; set; }
public string Config18Description { get; set; }
public DateTime Config18CreatedAt { get; set; }
public DateTime? Config18UpdatedAt { get; set; }
public string Config18CreatedBy { get; set; }
public bool IsConfig18Active { get; set; }
public int Config18SortOrder { get; set; }


public int Entry63Id { get; set; }
public string Entry63Name { get; set; }
public string Entry63Description { get; set; }
public DateTime Entry63CreatedAt { get; set; }
public DateTime? Entry63UpdatedAt { get; set; }
public string Entry63CreatedBy { get; set; }
public bool IsEntry63Active { get; set; }
public int Entry63SortOrder { get; set; }


public int Attr31Id { get; set; }
public string Attr31Name { get; set; }
public string Attr31Description { get; set; }
public DateTime Attr31CreatedAt { get; set; }
public DateTime? Attr31UpdatedAt { get; set; }
public string Attr31CreatedBy { get; set; }
public bool IsAttr31Active { get; set; }
public int Attr31SortOrder { get; set; }


public int Attr29Id { get; set; }
public string Attr29Name { get; set; }
public string Attr29Description { get; set; }
public DateTime Attr29CreatedAt { get; set; }
public DateTime? Attr29UpdatedAt { get; set; }
public string Attr29CreatedBy { get; set; }
public bool IsAttr29Active { get; set; }
public int Attr29SortOrder { get; set; }


public int Field9Id { get; set; }
public string Field9Name { get; set; }
public string Field9Description { get; set; }
public DateTime Field9CreatedAt { get; set; }
public DateTime? Field9UpdatedAt { get; set; }
public string Field9CreatedBy { get; set; }
public bool IsField9Active { get; set; }
public int Field9SortOrder { get; set; }


public int Attr23Id { get; set; }
public string Attr23Name { get; set; }
public string Attr23Description { get; set; }
public DateTime Attr23CreatedAt { get; set; }
public DateTime? Attr23UpdatedAt { get; set; }
public string Attr23CreatedBy { get; set; }
public bool IsAttr23Active { get; set; }
public int Attr23SortOrder { get; set; }


public int Record32Id { get; set; }
public string Record32Name { get; set; }
public string Record32Description { get; set; }
public DateTime Record32CreatedAt { get; set; }
public DateTime? Record32UpdatedAt { get; set; }
public string Record32CreatedBy { get; set; }
public bool IsRecord32Active { get; set; }
public int Record32SortOrder { get; set; }


public int Config71Id { get; set; }
public string Config71Name { get; set; }
public string Config71Description { get; set; }
public DateTime Config71CreatedAt { get; set; }
public DateTime? Config71UpdatedAt { get; set; }
public string Config71CreatedBy { get; set; }
public bool IsConfig71Active { get; set; }
public int Config71SortOrder { get; set; }


public int Record46Id { get; set; }
public string Record46Name { get; set; }
public string Record46Description { get; set; }
public DateTime Record46CreatedAt { get; set; }
public DateTime? Record46UpdatedAt { get; set; }
public string Record46CreatedBy { get; set; }
public bool IsRecord46Active { get; set; }
public int Record46SortOrder { get; set; }


public int Record63Id { get; set; }
public string Record63Name { get; set; }
public string Record63Description { get; set; }
public DateTime Record63CreatedAt { get; set; }
public DateTime? Record63UpdatedAt { get; set; }
public string Record63CreatedBy { get; set; }
public bool IsRecord63Active { get; set; }
public int Record63SortOrder { get; set; }


public int Attr75Id { get; set; }
public string Attr75Name { get; set; }
public string Attr75Description { get; set; }
public DateTime Attr75CreatedAt { get; set; }
public DateTime? Attr75UpdatedAt { get; set; }
public string Attr75CreatedBy { get; set; }
public bool IsAttr75Active { get; set; }
public int Attr75SortOrder { get; set; }


public int Item87Id { get; set; }
public string Item87Name { get; set; }
public string Item87Description { get; set; }
public DateTime Item87CreatedAt { get; set; }
public DateTime? Item87UpdatedAt { get; set; }
public string Item87CreatedBy { get; set; }
public bool IsItem87Active { get; set; }
public int Item87SortOrder { get; set; }


public int Item18Id { get; set; }
public string Item18Name { get; set; }
public string Item18Description { get; set; }
public DateTime Item18CreatedAt { get; set; }
public DateTime? Item18UpdatedAt { get; set; }
public string Item18CreatedBy { get; set; }
public bool IsItem18Active { get; set; }
public int Item18SortOrder { get; set; }


public int Record35Id { get; set; }
public string Record35Name { get; set; }
public string Record35Description { get; set; }
public DateTime Record35CreatedAt { get; set; }
public DateTime? Record35UpdatedAt { get; set; }
public string Record35CreatedBy { get; set; }
public bool IsRecord35Active { get; set; }
public int Record35SortOrder { get; set; }


public int Entry12Id { get; set; }
public string Entry12Name { get; set; }
public string Entry12Description { get; set; }
public DateTime Entry12CreatedAt { get; set; }
public DateTime? Entry12UpdatedAt { get; set; }
public string Entry12CreatedBy { get; set; }
public bool IsEntry12Active { get; set; }
public int Entry12SortOrder { get; set; }


public int Attr13Id { get; set; }
public string Attr13Name { get; set; }
public string Attr13Description { get; set; }
public DateTime Attr13CreatedAt { get; set; }
public DateTime? Attr13UpdatedAt { get; set; }
public string Attr13CreatedBy { get; set; }
public bool IsAttr13Active { get; set; }
public int Attr13SortOrder { get; set; }


public int Detail75Id { get; set; }
public string Detail75Name { get; set; }
public string Detail75Description { get; set; }
public DateTime Detail75CreatedAt { get; set; }
public DateTime? Detail75UpdatedAt { get; set; }
public string Detail75CreatedBy { get; set; }
public bool IsDetail75Active { get; set; }
public int Detail75SortOrder { get; set; }


public int Item90Id { get; set; }
public string Item90Name { get; set; }
public string Item90Description { get; set; }
public DateTime Item90CreatedAt { get; set; }
public DateTime? Item90UpdatedAt { get; set; }
public string Item90CreatedBy { get; set; }
public bool IsItem90Active { get; set; }
public int Item90SortOrder { get; set; }


public int Record86Id { get; set; }
public string Record86Name { get; set; }
public string Record86Description { get; set; }
public DateTime Record86CreatedAt { get; set; }
public DateTime? Record86UpdatedAt { get; set; }
public string Record86CreatedBy { get; set; }
public bool IsRecord86Active { get; set; }
public int Record86SortOrder { get; set; }


public int Config20Id { get; set; }
public string Config20Name { get; set; }
public string Config20Description { get; set; }
public DateTime Config20CreatedAt { get; set; }
public DateTime? Config20UpdatedAt { get; set; }
public string Config20CreatedBy { get; set; }
public bool IsConfig20Active { get; set; }
public int Config20SortOrder { get; set; }


public int Config71Id { get; set; }
public string Config71Name { get; set; }
public string Config71Description { get; set; }
public DateTime Config71CreatedAt { get; set; }
public DateTime? Config71UpdatedAt { get; set; }
public string Config71CreatedBy { get; set; }
public bool IsConfig71Active { get; set; }
public int Config71SortOrder { get; set; }


public int Entry54Id { get; set; }
public string Entry54Name { get; set; }
public string Entry54Description { get; set; }
public DateTime Entry54CreatedAt { get; set; }
public DateTime? Entry54UpdatedAt { get; set; }
public string Entry54CreatedBy { get; set; }
public bool IsEntry54Active { get; set; }
public int Entry54SortOrder { get; set; }


public int Detail53Id { get; set; }
public string Detail53Name { get; set; }
public string Detail53Description { get; set; }
public DateTime Detail53CreatedAt { get; set; }
public DateTime? Detail53UpdatedAt { get; set; }
public string Detail53CreatedBy { get; set; }
public bool IsDetail53Active { get; set; }
public int Detail53SortOrder { get; set; }


public int Entry88Id { get; set; }
public string Entry88Name { get; set; }
public string Entry88Description { get; set; }
public DateTime Entry88CreatedAt { get; set; }
public DateTime? Entry88UpdatedAt { get; set; }
public string Entry88CreatedBy { get; set; }
public bool IsEntry88Active { get; set; }
public int Entry88SortOrder { get; set; }


public int Config51Id { get; set; }
public string Config51Name { get; set; }
public string Config51Description { get; set; }
public DateTime Config51CreatedAt { get; set; }
public DateTime? Config51UpdatedAt { get; set; }
public string Config51CreatedBy { get; set; }
public bool IsConfig51Active { get; set; }
public int Config51SortOrder { get; set; }


public int Detail56Id { get; set; }
public string Detail56Name { get; set; }
public string Detail56Description { get; set; }
public DateTime Detail56CreatedAt { get; set; }
public DateTime? Detail56UpdatedAt { get; set; }
public string Detail56CreatedBy { get; set; }
public bool IsDetail56Active { get; set; }
public int Detail56SortOrder { get; set; }


public int Config61Id { get; set; }
public string Config61Name { get; set; }
public string Config61Description { get; set; }
public DateTime Config61CreatedAt { get; set; }
public DateTime? Config61UpdatedAt { get; set; }
public string Config61CreatedBy { get; set; }
public bool IsConfig61Active { get; set; }
public int Config61SortOrder { get; set; }


public int Config38Id { get; set; }
public string Config38Name { get; set; }
public string Config38Description { get; set; }
public DateTime Config38CreatedAt { get; set; }
public DateTime? Config38UpdatedAt { get; set; }
public string Config38CreatedBy { get; set; }
public bool IsConfig38Active { get; set; }
public int Config38SortOrder { get; set; }


public int Config60Id { get; set; }
public string Config60Name { get; set; }
public string Config60Description { get; set; }
public DateTime Config60CreatedAt { get; set; }
public DateTime? Config60UpdatedAt { get; set; }
public string Config60CreatedBy { get; set; }
public bool IsConfig60Active { get; set; }
public int Config60SortOrder { get; set; }


public int Param34Id { get; set; }
public string Param34Name { get; set; }
public string Param34Description { get; set; }
public DateTime Param34CreatedAt { get; set; }
public DateTime? Param34UpdatedAt { get; set; }
public string Param34CreatedBy { get; set; }
public bool IsParam34Active { get; set; }
public int Param34SortOrder { get; set; }


public int Detail15Id { get; set; }
public string Detail15Name { get; set; }
public string Detail15Description { get; set; }
public DateTime Detail15CreatedAt { get; set; }
public DateTime? Detail15UpdatedAt { get; set; }
public string Detail15CreatedBy { get; set; }
public bool IsDetail15Active { get; set; }
public int Detail15SortOrder { get; set; }


public int Item43Id { get; set; }
public string Item43Name { get; set; }
public string Item43Description { get; set; }
public DateTime Item43CreatedAt { get; set; }
public DateTime? Item43UpdatedAt { get; set; }
public string Item43CreatedBy { get; set; }
public bool IsItem43Active { get; set; }
public int Item43SortOrder { get; set; }


public int Config54Id { get; set; }
public string Config54Name { get; set; }
public string Config54Description { get; set; }
public DateTime Config54CreatedAt { get; set; }
public DateTime? Config54UpdatedAt { get; set; }
public string Config54CreatedBy { get; set; }
public bool IsConfig54Active { get; set; }
public int Config54SortOrder { get; set; }


public int Attr77Id { get; set; }
public string Attr77Name { get; set; }
public string Attr77Description { get; set; }
public DateTime Attr77CreatedAt { get; set; }
public DateTime? Attr77UpdatedAt { get; set; }
public string Attr77CreatedBy { get; set; }
public bool IsAttr77Active { get; set; }
public int Attr77SortOrder { get; set; }


public int Field78Id { get; set; }
public string Field78Name { get; set; }
public string Field78Description { get; set; }
public DateTime Field78CreatedAt { get; set; }
public DateTime? Field78UpdatedAt { get; set; }
public string Field78CreatedBy { get; set; }
public bool IsField78Active { get; set; }
public int Field78SortOrder { get; set; }


public int Param98Id { get; set; }
public string Param98Name { get; set; }
public string Param98Description { get; set; }
public DateTime Param98CreatedAt { get; set; }
public DateTime? Param98UpdatedAt { get; set; }
public string Param98CreatedBy { get; set; }
public bool IsParam98Active { get; set; }
public int Param98SortOrder { get; set; }


public int Attr17Id { get; set; }
public string Attr17Name { get; set; }
public string Attr17Description { get; set; }
public DateTime Attr17CreatedAt { get; set; }
public DateTime? Attr17UpdatedAt { get; set; }
public string Attr17CreatedBy { get; set; }
public bool IsAttr17Active { get; set; }
public int Attr17SortOrder { get; set; }


public int Field55Id { get; set; }
public string Field55Name { get; set; }
public string Field55Description { get; set; }
public DateTime Field55CreatedAt { get; set; }
public DateTime? Field55UpdatedAt { get; set; }
public string Field55CreatedBy { get; set; }
public bool IsField55Active { get; set; }
public int Field55SortOrder { get; set; }


public int Item88Id { get; set; }
public string Item88Name { get; set; }
public string Item88Description { get; set; }
public DateTime Item88CreatedAt { get; set; }
public DateTime? Item88UpdatedAt { get; set; }
public string Item88CreatedBy { get; set; }
public bool IsItem88Active { get; set; }
public int Item88SortOrder { get; set; }


public int Attr70Id { get; set; }
public string Attr70Name { get; set; }
public string Attr70Description { get; set; }
public DateTime Attr70CreatedAt { get; set; }
public DateTime? Attr70UpdatedAt { get; set; }
public string Attr70CreatedBy { get; set; }
public bool IsAttr70Active { get; set; }
public int Attr70SortOrder { get; set; }


public int Item62Id { get; set; }
public string Item62Name { get; set; }
public string Item62Description { get; set; }
public DateTime Item62CreatedAt { get; set; }
public DateTime? Item62UpdatedAt { get; set; }
public string Item62CreatedBy { get; set; }
public bool IsItem62Active { get; set; }
public int Item62SortOrder { get; set; }


public int Item41Id { get; set; }
public string Item41Name { get; set; }
public string Item41Description { get; set; }
public DateTime Item41CreatedAt { get; set; }
public DateTime? Item41UpdatedAt { get; set; }
public string Item41CreatedBy { get; set; }
public bool IsItem41Active { get; set; }
public int Item41SortOrder { get; set; }


public int Item61Id { get; set; }
public string Item61Name { get; set; }
public string Item61Description { get; set; }
public DateTime Item61CreatedAt { get; set; }
public DateTime? Item61UpdatedAt { get; set; }
public string Item61CreatedBy { get; set; }
public bool IsItem61Active { get; set; }
public int Item61SortOrder { get; set; }


public int Param75Id { get; set; }
public string Param75Name { get; set; }
public string Param75Description { get; set; }
public DateTime Param75CreatedAt { get; set; }
public DateTime? Param75UpdatedAt { get; set; }
public string Param75CreatedBy { get; set; }
public bool IsParam75Active { get; set; }
public int Param75SortOrder { get; set; }


public int Detail86Id { get; set; }
public string Detail86Name { get; set; }
public string Detail86Description { get; set; }
public DateTime Detail86CreatedAt { get; set; }
public DateTime? Detail86UpdatedAt { get; set; }
public string Detail86CreatedBy { get; set; }
public bool IsDetail86Active { get; set; }
public int Detail86SortOrder { get; set; }

    }
}