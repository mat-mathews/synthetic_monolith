using Admin.Mappers;
using Admin.Service;
using Auth.Api;
using Auth.Models;
using BatchJobs.Contracts;
using Common.Processors142;
using DataAccess.Handlers482;
using Documents.Shared427;
using Export.Processors;
using GalaxyWorks.Client366;
using Imaging.Mappers;
using Integration.Contracts290;
using Logging.Handlers285;
using Portal.Api99;
using Reporting.Service;
using Scheduling.Models260;
using Security.Mappers313;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling.Mappers
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer32
    {
        private readonly Auth_Models_Helper4 _auth_Models_Helper4;
        private readonly Auth_Models_Factory9 _auth_Models_Factory9;
        private readonly Admin_Mappers_Repository _admin_Mappers_Repository;
        private readonly Admin_Mappers_Helper5 _admin_Mappers_Helper5;
        private readonly Admin_Mappers_Repository8 _admin_Mappers_Repository8;
        private readonly IScheduling_Models260_Service8 _iScheduling_Models260_Service8;
        private readonly ICommon_Processors142_Service _iCommon_Processors142_Service;
        private readonly Common_Processors142_Helper2 _common_Processors142_Helper2;

        public Consumer32(Auth_Models_Helper4 auth_Models_Helper4, Auth_Models_Factory9 auth_Models_Factory9, Admin_Mappers_Repository admin_Mappers_Repository, Admin_Mappers_Helper5 admin_Mappers_Helper5, Admin_Mappers_Repository8 admin_Mappers_Repository8, IScheduling_Models260_Service8 iScheduling_Models260_Service8, ICommon_Processors142_Service iCommon_Processors142_Service, Common_Processors142_Helper2 common_Processors142_Helper2)
        {
            _auth_Models_Helper4 = auth_Models_Helper4 ?? throw new ArgumentNullException(nameof(auth_Models_Helper4));
            _auth_Models_Factory9 = auth_Models_Factory9 ?? throw new ArgumentNullException(nameof(auth_Models_Factory9));
            _admin_Mappers_Repository = admin_Mappers_Repository ?? throw new ArgumentNullException(nameof(admin_Mappers_Repository));
            _admin_Mappers_Helper5 = admin_Mappers_Helper5 ?? throw new ArgumentNullException(nameof(admin_Mappers_Helper5));
            _admin_Mappers_Repository8 = admin_Mappers_Repository8 ?? throw new ArgumentNullException(nameof(admin_Mappers_Repository8));
            _iScheduling_Models260_Service8 = iScheduling_Models260_Service8 ?? throw new ArgumentNullException(nameof(iScheduling_Models260_Service8));
            _iCommon_Processors142_Service = iCommon_Processors142_Service ?? throw new ArgumentNullException(nameof(iCommon_Processors142_Service));
            _common_Processors142_Helper2 = common_Processors142_Helper2 ?? throw new ArgumentNullException(nameof(common_Processors142_Helper2));
        }

        public Auth_Models_Helper4 GetAuth_Models_Helper4() => _auth_Models_Helper4;
        public Auth_Models_Factory9 GetAuth_Models_Factory9() => _auth_Models_Factory9;
        public Admin_Mappers_Repository GetAdmin_Mappers_Repository() => _admin_Mappers_Repository;
        public Admin_Mappers_Helper5 GetAdmin_Mappers_Helper5() => _admin_Mappers_Helper5;
        public Admin_Mappers_Repository8 GetAdmin_Mappers_Repository8() => _admin_Mappers_Repository8;
        public IScheduling_Models260_Service8 GetIScheduling_Models260_Service8() => _iScheduling_Models260_Service8;
        public ICommon_Processors142_Service GetICommon_Processors142_Service() => _iCommon_Processors142_Service;
        public Common_Processors142_Helper2 GetCommon_Processors142_Helper2() => _common_Processors142_Helper2;

/// <summary>
/// Validates the Consumer32 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer32(Consumer32Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer32));
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
/// Processes the Consumer32 operation asynchronously.
/// </summary>
public async Task<Consumer32Result> ProcessConsumer32Async(
    Consumer32Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer32), request.Id);

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
            return new Consumer32Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer32));
        return new Consumer32Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer32));
        return new Consumer32Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer32 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer32Dto>> GetConsumer32ListAsync(
    Consumer32Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer32Entity>().AsQueryable();

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
        .Select(x => new Consumer32Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer32Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer32Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer32Service(
    ILogger<Consumer32Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer32:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer32 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer32Data> GetCachedConsumer32Async(string key)
{
    var cacheKey = $"Consumer32_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer32Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer32SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Config38Id { get; set; }
public string Config38Name { get; set; }
public string Config38Description { get; set; }
public DateTime Config38CreatedAt { get; set; }
public DateTime? Config38UpdatedAt { get; set; }
public string Config38CreatedBy { get; set; }
public bool IsConfig38Active { get; set; }
public int Config38SortOrder { get; set; }


public int Entry90Id { get; set; }
public string Entry90Name { get; set; }
public string Entry90Description { get; set; }
public DateTime Entry90CreatedAt { get; set; }
public DateTime? Entry90UpdatedAt { get; set; }
public string Entry90CreatedBy { get; set; }
public bool IsEntry90Active { get; set; }
public int Entry90SortOrder { get; set; }


public int Detail74Id { get; set; }
public string Detail74Name { get; set; }
public string Detail74Description { get; set; }
public DateTime Detail74CreatedAt { get; set; }
public DateTime? Detail74UpdatedAt { get; set; }
public string Detail74CreatedBy { get; set; }
public bool IsDetail74Active { get; set; }
public int Detail74SortOrder { get; set; }


public int Attr22Id { get; set; }
public string Attr22Name { get; set; }
public string Attr22Description { get; set; }
public DateTime Attr22CreatedAt { get; set; }
public DateTime? Attr22UpdatedAt { get; set; }
public string Attr22CreatedBy { get; set; }
public bool IsAttr22Active { get; set; }
public int Attr22SortOrder { get; set; }


public int Field93Id { get; set; }
public string Field93Name { get; set; }
public string Field93Description { get; set; }
public DateTime Field93CreatedAt { get; set; }
public DateTime? Field93UpdatedAt { get; set; }
public string Field93CreatedBy { get; set; }
public bool IsField93Active { get; set; }
public int Field93SortOrder { get; set; }


public int Param22Id { get; set; }
public string Param22Name { get; set; }
public string Param22Description { get; set; }
public DateTime Param22CreatedAt { get; set; }
public DateTime? Param22UpdatedAt { get; set; }
public string Param22CreatedBy { get; set; }
public bool IsParam22Active { get; set; }
public int Param22SortOrder { get; set; }


public int Entry8Id { get; set; }
public string Entry8Name { get; set; }
public string Entry8Description { get; set; }
public DateTime Entry8CreatedAt { get; set; }
public DateTime? Entry8UpdatedAt { get; set; }
public string Entry8CreatedBy { get; set; }
public bool IsEntry8Active { get; set; }
public int Entry8SortOrder { get; set; }


public int Attr21Id { get; set; }
public string Attr21Name { get; set; }
public string Attr21Description { get; set; }
public DateTime Attr21CreatedAt { get; set; }
public DateTime? Attr21UpdatedAt { get; set; }
public string Attr21CreatedBy { get; set; }
public bool IsAttr21Active { get; set; }
public int Attr21SortOrder { get; set; }


public int Param96Id { get; set; }
public string Param96Name { get; set; }
public string Param96Description { get; set; }
public DateTime Param96CreatedAt { get; set; }
public DateTime? Param96UpdatedAt { get; set; }
public string Param96CreatedBy { get; set; }
public bool IsParam96Active { get; set; }
public int Param96SortOrder { get; set; }


public int Record42Id { get; set; }
public string Record42Name { get; set; }
public string Record42Description { get; set; }
public DateTime Record42CreatedAt { get; set; }
public DateTime? Record42UpdatedAt { get; set; }
public string Record42CreatedBy { get; set; }
public bool IsRecord42Active { get; set; }
public int Record42SortOrder { get; set; }


public int Record77Id { get; set; }
public string Record77Name { get; set; }
public string Record77Description { get; set; }
public DateTime Record77CreatedAt { get; set; }
public DateTime? Record77UpdatedAt { get; set; }
public string Record77CreatedBy { get; set; }
public bool IsRecord77Active { get; set; }
public int Record77SortOrder { get; set; }


public int Item82Id { get; set; }
public string Item82Name { get; set; }
public string Item82Description { get; set; }
public DateTime Item82CreatedAt { get; set; }
public DateTime? Item82UpdatedAt { get; set; }
public string Item82CreatedBy { get; set; }
public bool IsItem82Active { get; set; }
public int Item82SortOrder { get; set; }


public int Attr82Id { get; set; }
public string Attr82Name { get; set; }
public string Attr82Description { get; set; }
public DateTime Attr82CreatedAt { get; set; }
public DateTime? Attr82UpdatedAt { get; set; }
public string Attr82CreatedBy { get; set; }
public bool IsAttr82Active { get; set; }
public int Attr82SortOrder { get; set; }


public int Record73Id { get; set; }
public string Record73Name { get; set; }
public string Record73Description { get; set; }
public DateTime Record73CreatedAt { get; set; }
public DateTime? Record73UpdatedAt { get; set; }
public string Record73CreatedBy { get; set; }
public bool IsRecord73Active { get; set; }
public int Record73SortOrder { get; set; }


public int Field89Id { get; set; }
public string Field89Name { get; set; }
public string Field89Description { get; set; }
public DateTime Field89CreatedAt { get; set; }
public DateTime? Field89UpdatedAt { get; set; }
public string Field89CreatedBy { get; set; }
public bool IsField89Active { get; set; }
public int Field89SortOrder { get; set; }


public int Attr83Id { get; set; }
public string Attr83Name { get; set; }
public string Attr83Description { get; set; }
public DateTime Attr83CreatedAt { get; set; }
public DateTime? Attr83UpdatedAt { get; set; }
public string Attr83CreatedBy { get; set; }
public bool IsAttr83Active { get; set; }
public int Attr83SortOrder { get; set; }


public int Item62Id { get; set; }
public string Item62Name { get; set; }
public string Item62Description { get; set; }
public DateTime Item62CreatedAt { get; set; }
public DateTime? Item62UpdatedAt { get; set; }
public string Item62CreatedBy { get; set; }
public bool IsItem62Active { get; set; }
public int Item62SortOrder { get; set; }


public int Config31Id { get; set; }
public string Config31Name { get; set; }
public string Config31Description { get; set; }
public DateTime Config31CreatedAt { get; set; }
public DateTime? Config31UpdatedAt { get; set; }
public string Config31CreatedBy { get; set; }
public bool IsConfig31Active { get; set; }
public int Config31SortOrder { get; set; }


public int Attr62Id { get; set; }
public string Attr62Name { get; set; }
public string Attr62Description { get; set; }
public DateTime Attr62CreatedAt { get; set; }
public DateTime? Attr62UpdatedAt { get; set; }
public string Attr62CreatedBy { get; set; }
public bool IsAttr62Active { get; set; }
public int Attr62SortOrder { get; set; }


public int Detail48Id { get; set; }
public string Detail48Name { get; set; }
public string Detail48Description { get; set; }
public DateTime Detail48CreatedAt { get; set; }
public DateTime? Detail48UpdatedAt { get; set; }
public string Detail48CreatedBy { get; set; }
public bool IsDetail48Active { get; set; }
public int Detail48SortOrder { get; set; }


public int Record50Id { get; set; }
public string Record50Name { get; set; }
public string Record50Description { get; set; }
public DateTime Record50CreatedAt { get; set; }
public DateTime? Record50UpdatedAt { get; set; }
public string Record50CreatedBy { get; set; }
public bool IsRecord50Active { get; set; }
public int Record50SortOrder { get; set; }


public int Detail73Id { get; set; }
public string Detail73Name { get; set; }
public string Detail73Description { get; set; }
public DateTime Detail73CreatedAt { get; set; }
public DateTime? Detail73UpdatedAt { get; set; }
public string Detail73CreatedBy { get; set; }
public bool IsDetail73Active { get; set; }
public int Detail73SortOrder { get; set; }


public int Item56Id { get; set; }
public string Item56Name { get; set; }
public string Item56Description { get; set; }
public DateTime Item56CreatedAt { get; set; }
public DateTime? Item56UpdatedAt { get; set; }
public string Item56CreatedBy { get; set; }
public bool IsItem56Active { get; set; }
public int Item56SortOrder { get; set; }


public int Param60Id { get; set; }
public string Param60Name { get; set; }
public string Param60Description { get; set; }
public DateTime Param60CreatedAt { get; set; }
public DateTime? Param60UpdatedAt { get; set; }
public string Param60CreatedBy { get; set; }
public bool IsParam60Active { get; set; }
public int Param60SortOrder { get; set; }


public int Record56Id { get; set; }
public string Record56Name { get; set; }
public string Record56Description { get; set; }
public DateTime Record56CreatedAt { get; set; }
public DateTime? Record56UpdatedAt { get; set; }
public string Record56CreatedBy { get; set; }
public bool IsRecord56Active { get; set; }
public int Record56SortOrder { get; set; }


public int Entry17Id { get; set; }
public string Entry17Name { get; set; }
public string Entry17Description { get; set; }
public DateTime Entry17CreatedAt { get; set; }
public DateTime? Entry17UpdatedAt { get; set; }
public string Entry17CreatedBy { get; set; }
public bool IsEntry17Active { get; set; }
public int Entry17SortOrder { get; set; }


public int Config34Id { get; set; }
public string Config34Name { get; set; }
public string Config34Description { get; set; }
public DateTime Config34CreatedAt { get; set; }
public DateTime? Config34UpdatedAt { get; set; }
public string Config34CreatedBy { get; set; }
public bool IsConfig34Active { get; set; }
public int Config34SortOrder { get; set; }


public int Record73Id { get; set; }
public string Record73Name { get; set; }
public string Record73Description { get; set; }
public DateTime Record73CreatedAt { get; set; }
public DateTime? Record73UpdatedAt { get; set; }
public string Record73CreatedBy { get; set; }
public bool IsRecord73Active { get; set; }
public int Record73SortOrder { get; set; }


public int Detail6Id { get; set; }
public string Detail6Name { get; set; }
public string Detail6Description { get; set; }
public DateTime Detail6CreatedAt { get; set; }
public DateTime? Detail6UpdatedAt { get; set; }
public string Detail6CreatedBy { get; set; }
public bool IsDetail6Active { get; set; }
public int Detail6SortOrder { get; set; }


public int Item15Id { get; set; }
public string Item15Name { get; set; }
public string Item15Description { get; set; }
public DateTime Item15CreatedAt { get; set; }
public DateTime? Item15UpdatedAt { get; set; }
public string Item15CreatedBy { get; set; }
public bool IsItem15Active { get; set; }
public int Item15SortOrder { get; set; }


public int Item31Id { get; set; }
public string Item31Name { get; set; }
public string Item31Description { get; set; }
public DateTime Item31CreatedAt { get; set; }
public DateTime? Item31UpdatedAt { get; set; }
public string Item31CreatedBy { get; set; }
public bool IsItem31Active { get; set; }
public int Item31SortOrder { get; set; }


public int Config42Id { get; set; }
public string Config42Name { get; set; }
public string Config42Description { get; set; }
public DateTime Config42CreatedAt { get; set; }
public DateTime? Config42UpdatedAt { get; set; }
public string Config42CreatedBy { get; set; }
public bool IsConfig42Active { get; set; }
public int Config42SortOrder { get; set; }


public int Config45Id { get; set; }
public string Config45Name { get; set; }
public string Config45Description { get; set; }
public DateTime Config45CreatedAt { get; set; }
public DateTime? Config45UpdatedAt { get; set; }
public string Config45CreatedBy { get; set; }
public bool IsConfig45Active { get; set; }
public int Config45SortOrder { get; set; }


public int Detail19Id { get; set; }
public string Detail19Name { get; set; }
public string Detail19Description { get; set; }
public DateTime Detail19CreatedAt { get; set; }
public DateTime? Detail19UpdatedAt { get; set; }
public string Detail19CreatedBy { get; set; }
public bool IsDetail19Active { get; set; }
public int Detail19SortOrder { get; set; }


public int Param19Id { get; set; }
public string Param19Name { get; set; }
public string Param19Description { get; set; }
public DateTime Param19CreatedAt { get; set; }
public DateTime? Param19UpdatedAt { get; set; }
public string Param19CreatedBy { get; set; }
public bool IsParam19Active { get; set; }
public int Param19SortOrder { get; set; }


public int Item83Id { get; set; }
public string Item83Name { get; set; }
public string Item83Description { get; set; }
public DateTime Item83CreatedAt { get; set; }
public DateTime? Item83UpdatedAt { get; set; }
public string Item83CreatedBy { get; set; }
public bool IsItem83Active { get; set; }
public int Item83SortOrder { get; set; }


public int Param69Id { get; set; }
public string Param69Name { get; set; }
public string Param69Description { get; set; }
public DateTime Param69CreatedAt { get; set; }
public DateTime? Param69UpdatedAt { get; set; }
public string Param69CreatedBy { get; set; }
public bool IsParam69Active { get; set; }
public int Param69SortOrder { get; set; }


public int Detail86Id { get; set; }
public string Detail86Name { get; set; }
public string Detail86Description { get; set; }
public DateTime Detail86CreatedAt { get; set; }
public DateTime? Detail86UpdatedAt { get; set; }
public string Detail86CreatedBy { get; set; }
public bool IsDetail86Active { get; set; }
public int Detail86SortOrder { get; set; }


public int Config47Id { get; set; }
public string Config47Name { get; set; }
public string Config47Description { get; set; }
public DateTime Config47CreatedAt { get; set; }
public DateTime? Config47UpdatedAt { get; set; }
public string Config47CreatedBy { get; set; }
public bool IsConfig47Active { get; set; }
public int Config47SortOrder { get; set; }


public int Detail40Id { get; set; }
public string Detail40Name { get; set; }
public string Detail40Description { get; set; }
public DateTime Detail40CreatedAt { get; set; }
public DateTime? Detail40UpdatedAt { get; set; }
public string Detail40CreatedBy { get; set; }
public bool IsDetail40Active { get; set; }
public int Detail40SortOrder { get; set; }


public int Config10Id { get; set; }
public string Config10Name { get; set; }
public string Config10Description { get; set; }
public DateTime Config10CreatedAt { get; set; }
public DateTime? Config10UpdatedAt { get; set; }
public string Config10CreatedBy { get; set; }
public bool IsConfig10Active { get; set; }
public int Config10SortOrder { get; set; }


public int Config38Id { get; set; }
public string Config38Name { get; set; }
public string Config38Description { get; set; }
public DateTime Config38CreatedAt { get; set; }
public DateTime? Config38UpdatedAt { get; set; }
public string Config38CreatedBy { get; set; }
public bool IsConfig38Active { get; set; }
public int Config38SortOrder { get; set; }


public int Item21Id { get; set; }
public string Item21Name { get; set; }
public string Item21Description { get; set; }
public DateTime Item21CreatedAt { get; set; }
public DateTime? Item21UpdatedAt { get; set; }
public string Item21CreatedBy { get; set; }
public bool IsItem21Active { get; set; }
public int Item21SortOrder { get; set; }


public int Field52Id { get; set; }
public string Field52Name { get; set; }
public string Field52Description { get; set; }
public DateTime Field52CreatedAt { get; set; }
public DateTime? Field52UpdatedAt { get; set; }
public string Field52CreatedBy { get; set; }
public bool IsField52Active { get; set; }
public int Field52SortOrder { get; set; }


public int Record74Id { get; set; }
public string Record74Name { get; set; }
public string Record74Description { get; set; }
public DateTime Record74CreatedAt { get; set; }
public DateTime? Record74UpdatedAt { get; set; }
public string Record74CreatedBy { get; set; }
public bool IsRecord74Active { get; set; }
public int Record74SortOrder { get; set; }

    }
}