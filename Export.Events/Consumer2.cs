using Admin.Service247;
using Auth.Api143;
using Auth.Client249;
using Auth.Models236;
using Auth.Web;
using Common.Api186;
using Common.Processors142;
using Common.Tests350;
using DataAccess.Client113;
using DataAccess.Shared189;
using Export.Models461;
using Imaging.Events303;
using Import.Data100;
using Portal.Api;
using Portal.Contracts181;
using Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Web398;

namespace Export.Events
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer2
    {
        private readonly IAuth_Api143_Factory _iAuth_Api143_Factory;
        private readonly Auth_Api143_Builder4 _auth_Api143_Builder4;
        private readonly Admin_Service247_Point3 _admin_Service247_Point3;
        private readonly IAuth_Web_Repository5 _iAuth_Web_Repository5;
        private readonly Auth_Models236_Point _auth_Models236_Point;
        private readonly Auth_Models236_Handler2 _auth_Models236_Handler2;
        private readonly DataAccess_Shared189_Point8 _dataAccess_Shared189_Point8;
        private readonly IDataAccess_Shared189_Repository1 _iDataAccess_Shared189_Repository1;

        public Consumer2(IAuth_Api143_Factory iAuth_Api143_Factory, Auth_Api143_Builder4 auth_Api143_Builder4, Admin_Service247_Point3 admin_Service247_Point3, IAuth_Web_Repository5 iAuth_Web_Repository5, Auth_Models236_Point auth_Models236_Point, Auth_Models236_Handler2 auth_Models236_Handler2, DataAccess_Shared189_Point8 dataAccess_Shared189_Point8, IDataAccess_Shared189_Repository1 iDataAccess_Shared189_Repository1)
        {
            _iAuth_Api143_Factory = iAuth_Api143_Factory ?? throw new ArgumentNullException(nameof(iAuth_Api143_Factory));
            _auth_Api143_Builder4 = auth_Api143_Builder4 ?? throw new ArgumentNullException(nameof(auth_Api143_Builder4));
            _admin_Service247_Point3 = admin_Service247_Point3 ?? throw new ArgumentNullException(nameof(admin_Service247_Point3));
            _iAuth_Web_Repository5 = iAuth_Web_Repository5 ?? throw new ArgumentNullException(nameof(iAuth_Web_Repository5));
            _auth_Models236_Point = auth_Models236_Point ?? throw new ArgumentNullException(nameof(auth_Models236_Point));
            _auth_Models236_Handler2 = auth_Models236_Handler2 ?? throw new ArgumentNullException(nameof(auth_Models236_Handler2));
            _dataAccess_Shared189_Point8 = dataAccess_Shared189_Point8 ?? throw new ArgumentNullException(nameof(dataAccess_Shared189_Point8));
            _iDataAccess_Shared189_Repository1 = iDataAccess_Shared189_Repository1 ?? throw new ArgumentNullException(nameof(iDataAccess_Shared189_Repository1));
        }

        public IAuth_Api143_Factory GetIAuth_Api143_Factory() => _iAuth_Api143_Factory;
        public Auth_Api143_Builder4 GetAuth_Api143_Builder4() => _auth_Api143_Builder4;
        public Admin_Service247_Point3 GetAdmin_Service247_Point3() => _admin_Service247_Point3;
        public IAuth_Web_Repository5 GetIAuth_Web_Repository5() => _iAuth_Web_Repository5;
        public Auth_Models236_Point GetAuth_Models236_Point() => _auth_Models236_Point;
        public Auth_Models236_Handler2 GetAuth_Models236_Handler2() => _auth_Models236_Handler2;
        public DataAccess_Shared189_Point8 GetDataAccess_Shared189_Point8() => _dataAccess_Shared189_Point8;
        public IDataAccess_Shared189_Repository1 GetIDataAccess_Shared189_Repository1() => _iDataAccess_Shared189_Repository1;

/// <summary>
/// Validates the Consumer2 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer2(Consumer2Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer2));
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
/// Processes the Consumer2 operation asynchronously.
/// </summary>
public async Task<Consumer2Result> ProcessConsumer2Async(
    Consumer2Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer2), request.Id);

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
            return new Consumer2Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer2));
        return new Consumer2Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer2));
        return new Consumer2Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer2 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer2Dto>> GetConsumer2ListAsync(
    Consumer2Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer2Entity>().AsQueryable();

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
        .Select(x => new Consumer2Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer2Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer2Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer2Service(
    ILogger<Consumer2Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer2:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer2 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer2Data> GetCachedConsumer2Async(string key)
{
    var cacheKey = $"Consumer2_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer2Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer2SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Record35Id { get; set; }
public string Record35Name { get; set; }
public string Record35Description { get; set; }
public DateTime Record35CreatedAt { get; set; }
public DateTime? Record35UpdatedAt { get; set; }
public string Record35CreatedBy { get; set; }
public bool IsRecord35Active { get; set; }
public int Record35SortOrder { get; set; }


public int Record92Id { get; set; }
public string Record92Name { get; set; }
public string Record92Description { get; set; }
public DateTime Record92CreatedAt { get; set; }
public DateTime? Record92UpdatedAt { get; set; }
public string Record92CreatedBy { get; set; }
public bool IsRecord92Active { get; set; }
public int Record92SortOrder { get; set; }


public int Config47Id { get; set; }
public string Config47Name { get; set; }
public string Config47Description { get; set; }
public DateTime Config47CreatedAt { get; set; }
public DateTime? Config47UpdatedAt { get; set; }
public string Config47CreatedBy { get; set; }
public bool IsConfig47Active { get; set; }
public int Config47SortOrder { get; set; }


public int Param62Id { get; set; }
public string Param62Name { get; set; }
public string Param62Description { get; set; }
public DateTime Param62CreatedAt { get; set; }
public DateTime? Param62UpdatedAt { get; set; }
public string Param62CreatedBy { get; set; }
public bool IsParam62Active { get; set; }
public int Param62SortOrder { get; set; }


public int Item6Id { get; set; }
public string Item6Name { get; set; }
public string Item6Description { get; set; }
public DateTime Item6CreatedAt { get; set; }
public DateTime? Item6UpdatedAt { get; set; }
public string Item6CreatedBy { get; set; }
public bool IsItem6Active { get; set; }
public int Item6SortOrder { get; set; }


public int Entry92Id { get; set; }
public string Entry92Name { get; set; }
public string Entry92Description { get; set; }
public DateTime Entry92CreatedAt { get; set; }
public DateTime? Entry92UpdatedAt { get; set; }
public string Entry92CreatedBy { get; set; }
public bool IsEntry92Active { get; set; }
public int Entry92SortOrder { get; set; }


public int Detail66Id { get; set; }
public string Detail66Name { get; set; }
public string Detail66Description { get; set; }
public DateTime Detail66CreatedAt { get; set; }
public DateTime? Detail66UpdatedAt { get; set; }
public string Detail66CreatedBy { get; set; }
public bool IsDetail66Active { get; set; }
public int Detail66SortOrder { get; set; }


public int Entry50Id { get; set; }
public string Entry50Name { get; set; }
public string Entry50Description { get; set; }
public DateTime Entry50CreatedAt { get; set; }
public DateTime? Entry50UpdatedAt { get; set; }
public string Entry50CreatedBy { get; set; }
public bool IsEntry50Active { get; set; }
public int Entry50SortOrder { get; set; }


public int Config88Id { get; set; }
public string Config88Name { get; set; }
public string Config88Description { get; set; }
public DateTime Config88CreatedAt { get; set; }
public DateTime? Config88UpdatedAt { get; set; }
public string Config88CreatedBy { get; set; }
public bool IsConfig88Active { get; set; }
public int Config88SortOrder { get; set; }


public int Attr97Id { get; set; }
public string Attr97Name { get; set; }
public string Attr97Description { get; set; }
public DateTime Attr97CreatedAt { get; set; }
public DateTime? Attr97UpdatedAt { get; set; }
public string Attr97CreatedBy { get; set; }
public bool IsAttr97Active { get; set; }
public int Attr97SortOrder { get; set; }


public int Entry17Id { get; set; }
public string Entry17Name { get; set; }
public string Entry17Description { get; set; }
public DateTime Entry17CreatedAt { get; set; }
public DateTime? Entry17UpdatedAt { get; set; }
public string Entry17CreatedBy { get; set; }
public bool IsEntry17Active { get; set; }
public int Entry17SortOrder { get; set; }


public int Entry42Id { get; set; }
public string Entry42Name { get; set; }
public string Entry42Description { get; set; }
public DateTime Entry42CreatedAt { get; set; }
public DateTime? Entry42UpdatedAt { get; set; }
public string Entry42CreatedBy { get; set; }
public bool IsEntry42Active { get; set; }
public int Entry42SortOrder { get; set; }


public int Item86Id { get; set; }
public string Item86Name { get; set; }
public string Item86Description { get; set; }
public DateTime Item86CreatedAt { get; set; }
public DateTime? Item86UpdatedAt { get; set; }
public string Item86CreatedBy { get; set; }
public bool IsItem86Active { get; set; }
public int Item86SortOrder { get; set; }


public int Record38Id { get; set; }
public string Record38Name { get; set; }
public string Record38Description { get; set; }
public DateTime Record38CreatedAt { get; set; }
public DateTime? Record38UpdatedAt { get; set; }
public string Record38CreatedBy { get; set; }
public bool IsRecord38Active { get; set; }
public int Record38SortOrder { get; set; }


public int Attr36Id { get; set; }
public string Attr36Name { get; set; }
public string Attr36Description { get; set; }
public DateTime Attr36CreatedAt { get; set; }
public DateTime? Attr36UpdatedAt { get; set; }
public string Attr36CreatedBy { get; set; }
public bool IsAttr36Active { get; set; }
public int Attr36SortOrder { get; set; }


public int Record2Id { get; set; }
public string Record2Name { get; set; }
public string Record2Description { get; set; }
public DateTime Record2CreatedAt { get; set; }
public DateTime? Record2UpdatedAt { get; set; }
public string Record2CreatedBy { get; set; }
public bool IsRecord2Active { get; set; }
public int Record2SortOrder { get; set; }


public int Field96Id { get; set; }
public string Field96Name { get; set; }
public string Field96Description { get; set; }
public DateTime Field96CreatedAt { get; set; }
public DateTime? Field96UpdatedAt { get; set; }
public string Field96CreatedBy { get; set; }
public bool IsField96Active { get; set; }
public int Field96SortOrder { get; set; }


public int Entry68Id { get; set; }
public string Entry68Name { get; set; }
public string Entry68Description { get; set; }
public DateTime Entry68CreatedAt { get; set; }
public DateTime? Entry68UpdatedAt { get; set; }
public string Entry68CreatedBy { get; set; }
public bool IsEntry68Active { get; set; }
public int Entry68SortOrder { get; set; }


public int Entry44Id { get; set; }
public string Entry44Name { get; set; }
public string Entry44Description { get; set; }
public DateTime Entry44CreatedAt { get; set; }
public DateTime? Entry44UpdatedAt { get; set; }
public string Entry44CreatedBy { get; set; }
public bool IsEntry44Active { get; set; }
public int Entry44SortOrder { get; set; }


public int Detail98Id { get; set; }
public string Detail98Name { get; set; }
public string Detail98Description { get; set; }
public DateTime Detail98CreatedAt { get; set; }
public DateTime? Detail98UpdatedAt { get; set; }
public string Detail98CreatedBy { get; set; }
public bool IsDetail98Active { get; set; }
public int Detail98SortOrder { get; set; }


public int Entry83Id { get; set; }
public string Entry83Name { get; set; }
public string Entry83Description { get; set; }
public DateTime Entry83CreatedAt { get; set; }
public DateTime? Entry83UpdatedAt { get; set; }
public string Entry83CreatedBy { get; set; }
public bool IsEntry83Active { get; set; }
public int Entry83SortOrder { get; set; }


public int Field14Id { get; set; }
public string Field14Name { get; set; }
public string Field14Description { get; set; }
public DateTime Field14CreatedAt { get; set; }
public DateTime? Field14UpdatedAt { get; set; }
public string Field14CreatedBy { get; set; }
public bool IsField14Active { get; set; }
public int Field14SortOrder { get; set; }


public int Param97Id { get; set; }
public string Param97Name { get; set; }
public string Param97Description { get; set; }
public DateTime Param97CreatedAt { get; set; }
public DateTime? Param97UpdatedAt { get; set; }
public string Param97CreatedBy { get; set; }
public bool IsParam97Active { get; set; }
public int Param97SortOrder { get; set; }


public int Record33Id { get; set; }
public string Record33Name { get; set; }
public string Record33Description { get; set; }
public DateTime Record33CreatedAt { get; set; }
public DateTime? Record33UpdatedAt { get; set; }
public string Record33CreatedBy { get; set; }
public bool IsRecord33Active { get; set; }
public int Record33SortOrder { get; set; }


public int Item34Id { get; set; }
public string Item34Name { get; set; }
public string Item34Description { get; set; }
public DateTime Item34CreatedAt { get; set; }
public DateTime? Item34UpdatedAt { get; set; }
public string Item34CreatedBy { get; set; }
public bool IsItem34Active { get; set; }
public int Item34SortOrder { get; set; }


public int Field11Id { get; set; }
public string Field11Name { get; set; }
public string Field11Description { get; set; }
public DateTime Field11CreatedAt { get; set; }
public DateTime? Field11UpdatedAt { get; set; }
public string Field11CreatedBy { get; set; }
public bool IsField11Active { get; set; }
public int Field11SortOrder { get; set; }


public int Param37Id { get; set; }
public string Param37Name { get; set; }
public string Param37Description { get; set; }
public DateTime Param37CreatedAt { get; set; }
public DateTime? Param37UpdatedAt { get; set; }
public string Param37CreatedBy { get; set; }
public bool IsParam37Active { get; set; }
public int Param37SortOrder { get; set; }


public int Attr36Id { get; set; }
public string Attr36Name { get; set; }
public string Attr36Description { get; set; }
public DateTime Attr36CreatedAt { get; set; }
public DateTime? Attr36UpdatedAt { get; set; }
public string Attr36CreatedBy { get; set; }
public bool IsAttr36Active { get; set; }
public int Attr36SortOrder { get; set; }


public int Field76Id { get; set; }
public string Field76Name { get; set; }
public string Field76Description { get; set; }
public DateTime Field76CreatedAt { get; set; }
public DateTime? Field76UpdatedAt { get; set; }
public string Field76CreatedBy { get; set; }
public bool IsField76Active { get; set; }
public int Field76SortOrder { get; set; }


public int Attr61Id { get; set; }
public string Attr61Name { get; set; }
public string Attr61Description { get; set; }
public DateTime Attr61CreatedAt { get; set; }
public DateTime? Attr61UpdatedAt { get; set; }
public string Attr61CreatedBy { get; set; }
public bool IsAttr61Active { get; set; }
public int Attr61SortOrder { get; set; }


public int Config53Id { get; set; }
public string Config53Name { get; set; }
public string Config53Description { get; set; }
public DateTime Config53CreatedAt { get; set; }
public DateTime? Config53UpdatedAt { get; set; }
public string Config53CreatedBy { get; set; }
public bool IsConfig53Active { get; set; }
public int Config53SortOrder { get; set; }


public int Field3Id { get; set; }
public string Field3Name { get; set; }
public string Field3Description { get; set; }
public DateTime Field3CreatedAt { get; set; }
public DateTime? Field3UpdatedAt { get; set; }
public string Field3CreatedBy { get; set; }
public bool IsField3Active { get; set; }
public int Field3SortOrder { get; set; }


public int Detail82Id { get; set; }
public string Detail82Name { get; set; }
public string Detail82Description { get; set; }
public DateTime Detail82CreatedAt { get; set; }
public DateTime? Detail82UpdatedAt { get; set; }
public string Detail82CreatedBy { get; set; }
public bool IsDetail82Active { get; set; }
public int Detail82SortOrder { get; set; }


public int Attr15Id { get; set; }
public string Attr15Name { get; set; }
public string Attr15Description { get; set; }
public DateTime Attr15CreatedAt { get; set; }
public DateTime? Attr15UpdatedAt { get; set; }
public string Attr15CreatedBy { get; set; }
public bool IsAttr15Active { get; set; }
public int Attr15SortOrder { get; set; }


public int Entry97Id { get; set; }
public string Entry97Name { get; set; }
public string Entry97Description { get; set; }
public DateTime Entry97CreatedAt { get; set; }
public DateTime? Entry97UpdatedAt { get; set; }
public string Entry97CreatedBy { get; set; }
public bool IsEntry97Active { get; set; }
public int Entry97SortOrder { get; set; }


public int Entry24Id { get; set; }
public string Entry24Name { get; set; }
public string Entry24Description { get; set; }
public DateTime Entry24CreatedAt { get; set; }
public DateTime? Entry24UpdatedAt { get; set; }
public string Entry24CreatedBy { get; set; }
public bool IsEntry24Active { get; set; }
public int Entry24SortOrder { get; set; }


public int Entry67Id { get; set; }
public string Entry67Name { get; set; }
public string Entry67Description { get; set; }
public DateTime Entry67CreatedAt { get; set; }
public DateTime? Entry67UpdatedAt { get; set; }
public string Entry67CreatedBy { get; set; }
public bool IsEntry67Active { get; set; }
public int Entry67SortOrder { get; set; }


public int Attr33Id { get; set; }
public string Attr33Name { get; set; }
public string Attr33Description { get; set; }
public DateTime Attr33CreatedAt { get; set; }
public DateTime? Attr33UpdatedAt { get; set; }
public string Attr33CreatedBy { get; set; }
public bool IsAttr33Active { get; set; }
public int Attr33SortOrder { get; set; }


public int Detail20Id { get; set; }
public string Detail20Name { get; set; }
public string Detail20Description { get; set; }
public DateTime Detail20CreatedAt { get; set; }
public DateTime? Detail20UpdatedAt { get; set; }
public string Detail20CreatedBy { get; set; }
public bool IsDetail20Active { get; set; }
public int Detail20SortOrder { get; set; }


public int Config4Id { get; set; }
public string Config4Name { get; set; }
public string Config4Description { get; set; }
public DateTime Config4CreatedAt { get; set; }
public DateTime? Config4UpdatedAt { get; set; }
public string Config4CreatedBy { get; set; }
public bool IsConfig4Active { get; set; }
public int Config4SortOrder { get; set; }


public int Param72Id { get; set; }
public string Param72Name { get; set; }
public string Param72Description { get; set; }
public DateTime Param72CreatedAt { get; set; }
public DateTime? Param72UpdatedAt { get; set; }
public string Param72CreatedBy { get; set; }
public bool IsParam72Active { get; set; }
public int Param72SortOrder { get; set; }


public int Param46Id { get; set; }
public string Param46Name { get; set; }
public string Param46Description { get; set; }
public DateTime Param46CreatedAt { get; set; }
public DateTime? Param46UpdatedAt { get; set; }
public string Param46CreatedBy { get; set; }
public bool IsParam46Active { get; set; }
public int Param46SortOrder { get; set; }


public int Attr44Id { get; set; }
public string Attr44Name { get; set; }
public string Attr44Description { get; set; }
public DateTime Attr44CreatedAt { get; set; }
public DateTime? Attr44UpdatedAt { get; set; }
public string Attr44CreatedBy { get; set; }
public bool IsAttr44Active { get; set; }
public int Attr44SortOrder { get; set; }


public int Entry98Id { get; set; }
public string Entry98Name { get; set; }
public string Entry98Description { get; set; }
public DateTime Entry98CreatedAt { get; set; }
public DateTime? Entry98UpdatedAt { get; set; }
public string Entry98CreatedBy { get; set; }
public bool IsEntry98Active { get; set; }
public int Entry98SortOrder { get; set; }


public int Item90Id { get; set; }
public string Item90Name { get; set; }
public string Item90Description { get; set; }
public DateTime Item90CreatedAt { get; set; }
public DateTime? Item90UpdatedAt { get; set; }
public string Item90CreatedBy { get; set; }
public bool IsItem90Active { get; set; }
public int Item90SortOrder { get; set; }


public int Entry73Id { get; set; }
public string Entry73Name { get; set; }
public string Entry73Description { get; set; }
public DateTime Entry73CreatedAt { get; set; }
public DateTime? Entry73UpdatedAt { get; set; }
public string Entry73CreatedBy { get; set; }
public bool IsEntry73Active { get; set; }
public int Entry73SortOrder { get; set; }

    }
}