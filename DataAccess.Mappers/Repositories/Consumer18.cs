using Admin.Core121;
using Admin.Data408;
using Admin.Validators431;
using Auth.Models23;
using Billing.Core34;
using Common.Api57;
using DataAccess.Data36;
using DataAccess.Models;
using Documents.Processors;
using Export.Tests62;
using GalaxyWorks.Contracts94;
using GalaxyWorks.Models219;
using Imaging.Models184;
using Imaging.Web;
using Logging.Processors;
using Scheduling.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Mappers
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer18
    {
        private readonly Admin_Validators431_Provider6 _admin_Validators431_Provider6;
        private readonly Admin_Validators431_Key8 _admin_Validators431_Key8;
        private readonly GalaxyWorks_Contracts94_Service6 _galaxyWorks_Contracts94_Service6;
        private readonly Admin_Core121_Repository _admin_Core121_Repository;
        private readonly IDataAccess_Models_Provider _iDataAccess_Models_Provider;
        private readonly Common_Api57_Helper _common_Api57_Helper;
        private readonly Common_Api57_Request8 _common_Api57_Request8;
        private readonly Common_Api57_Controller9 _common_Api57_Controller9;

        public Consumer18(Admin_Validators431_Provider6 admin_Validators431_Provider6, Admin_Validators431_Key8 admin_Validators431_Key8, GalaxyWorks_Contracts94_Service6 galaxyWorks_Contracts94_Service6, Admin_Core121_Repository admin_Core121_Repository, IDataAccess_Models_Provider iDataAccess_Models_Provider, Common_Api57_Helper common_Api57_Helper, Common_Api57_Request8 common_Api57_Request8, Common_Api57_Controller9 common_Api57_Controller9)
        {
            _admin_Validators431_Provider6 = admin_Validators431_Provider6 ?? throw new ArgumentNullException(nameof(admin_Validators431_Provider6));
            _admin_Validators431_Key8 = admin_Validators431_Key8 ?? throw new ArgumentNullException(nameof(admin_Validators431_Key8));
            _galaxyWorks_Contracts94_Service6 = galaxyWorks_Contracts94_Service6 ?? throw new ArgumentNullException(nameof(galaxyWorks_Contracts94_Service6));
            _admin_Core121_Repository = admin_Core121_Repository ?? throw new ArgumentNullException(nameof(admin_Core121_Repository));
            _iDataAccess_Models_Provider = iDataAccess_Models_Provider ?? throw new ArgumentNullException(nameof(iDataAccess_Models_Provider));
            _common_Api57_Helper = common_Api57_Helper ?? throw new ArgumentNullException(nameof(common_Api57_Helper));
            _common_Api57_Request8 = common_Api57_Request8 ?? throw new ArgumentNullException(nameof(common_Api57_Request8));
            _common_Api57_Controller9 = common_Api57_Controller9 ?? throw new ArgumentNullException(nameof(common_Api57_Controller9));
        }

        public Admin_Validators431_Provider6 GetAdmin_Validators431_Provider6() => _admin_Validators431_Provider6;
        public Admin_Validators431_Key8 GetAdmin_Validators431_Key8() => _admin_Validators431_Key8;
        public GalaxyWorks_Contracts94_Service6 GetGalaxyWorks_Contracts94_Service6() => _galaxyWorks_Contracts94_Service6;
        public Admin_Core121_Repository GetAdmin_Core121_Repository() => _admin_Core121_Repository;
        public IDataAccess_Models_Provider GetIDataAccess_Models_Provider() => _iDataAccess_Models_Provider;
        public Common_Api57_Helper GetCommon_Api57_Helper() => _common_Api57_Helper;
        public Common_Api57_Request8 GetCommon_Api57_Request8() => _common_Api57_Request8;
        public Common_Api57_Controller9 GetCommon_Api57_Controller9() => _common_Api57_Controller9;

/// <summary>
/// Validates the Consumer18 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer18(Consumer18Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer18));
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
/// Processes the Consumer18 operation asynchronously.
/// </summary>
public async Task<Consumer18Result> ProcessConsumer18Async(
    Consumer18Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer18), request.Id);

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
            return new Consumer18Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer18));
        return new Consumer18Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer18));
        return new Consumer18Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer18 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer18Dto>> GetConsumer18ListAsync(
    Consumer18Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer18Entity>().AsQueryable();

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
        .Select(x => new Consumer18Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer18Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer18Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer18Service(
    ILogger<Consumer18Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer18:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer18 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer18Data> GetCachedConsumer18Async(string key)
{
    var cacheKey = $"Consumer18_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer18Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer18SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Field57Id { get; set; }
public string Field57Name { get; set; }
public string Field57Description { get; set; }
public DateTime Field57CreatedAt { get; set; }
public DateTime? Field57UpdatedAt { get; set; }
public string Field57CreatedBy { get; set; }
public bool IsField57Active { get; set; }
public int Field57SortOrder { get; set; }


public int Attr84Id { get; set; }
public string Attr84Name { get; set; }
public string Attr84Description { get; set; }
public DateTime Attr84CreatedAt { get; set; }
public DateTime? Attr84UpdatedAt { get; set; }
public string Attr84CreatedBy { get; set; }
public bool IsAttr84Active { get; set; }
public int Attr84SortOrder { get; set; }


public int Field42Id { get; set; }
public string Field42Name { get; set; }
public string Field42Description { get; set; }
public DateTime Field42CreatedAt { get; set; }
public DateTime? Field42UpdatedAt { get; set; }
public string Field42CreatedBy { get; set; }
public bool IsField42Active { get; set; }
public int Field42SortOrder { get; set; }


public int Param52Id { get; set; }
public string Param52Name { get; set; }
public string Param52Description { get; set; }
public DateTime Param52CreatedAt { get; set; }
public DateTime? Param52UpdatedAt { get; set; }
public string Param52CreatedBy { get; set; }
public bool IsParam52Active { get; set; }
public int Param52SortOrder { get; set; }


public int Attr69Id { get; set; }
public string Attr69Name { get; set; }
public string Attr69Description { get; set; }
public DateTime Attr69CreatedAt { get; set; }
public DateTime? Attr69UpdatedAt { get; set; }
public string Attr69CreatedBy { get; set; }
public bool IsAttr69Active { get; set; }
public int Attr69SortOrder { get; set; }


public int Param8Id { get; set; }
public string Param8Name { get; set; }
public string Param8Description { get; set; }
public DateTime Param8CreatedAt { get; set; }
public DateTime? Param8UpdatedAt { get; set; }
public string Param8CreatedBy { get; set; }
public bool IsParam8Active { get; set; }
public int Param8SortOrder { get; set; }


public int Config5Id { get; set; }
public string Config5Name { get; set; }
public string Config5Description { get; set; }
public DateTime Config5CreatedAt { get; set; }
public DateTime? Config5UpdatedAt { get; set; }
public string Config5CreatedBy { get; set; }
public bool IsConfig5Active { get; set; }
public int Config5SortOrder { get; set; }


public int Field48Id { get; set; }
public string Field48Name { get; set; }
public string Field48Description { get; set; }
public DateTime Field48CreatedAt { get; set; }
public DateTime? Field48UpdatedAt { get; set; }
public string Field48CreatedBy { get; set; }
public bool IsField48Active { get; set; }
public int Field48SortOrder { get; set; }


public int Attr18Id { get; set; }
public string Attr18Name { get; set; }
public string Attr18Description { get; set; }
public DateTime Attr18CreatedAt { get; set; }
public DateTime? Attr18UpdatedAt { get; set; }
public string Attr18CreatedBy { get; set; }
public bool IsAttr18Active { get; set; }
public int Attr18SortOrder { get; set; }


public int Detail86Id { get; set; }
public string Detail86Name { get; set; }
public string Detail86Description { get; set; }
public DateTime Detail86CreatedAt { get; set; }
public DateTime? Detail86UpdatedAt { get; set; }
public string Detail86CreatedBy { get; set; }
public bool IsDetail86Active { get; set; }
public int Detail86SortOrder { get; set; }


public int Entry32Id { get; set; }
public string Entry32Name { get; set; }
public string Entry32Description { get; set; }
public DateTime Entry32CreatedAt { get; set; }
public DateTime? Entry32UpdatedAt { get; set; }
public string Entry32CreatedBy { get; set; }
public bool IsEntry32Active { get; set; }
public int Entry32SortOrder { get; set; }


public int Param66Id { get; set; }
public string Param66Name { get; set; }
public string Param66Description { get; set; }
public DateTime Param66CreatedAt { get; set; }
public DateTime? Param66UpdatedAt { get; set; }
public string Param66CreatedBy { get; set; }
public bool IsParam66Active { get; set; }
public int Param66SortOrder { get; set; }


public int Detail6Id { get; set; }
public string Detail6Name { get; set; }
public string Detail6Description { get; set; }
public DateTime Detail6CreatedAt { get; set; }
public DateTime? Detail6UpdatedAt { get; set; }
public string Detail6CreatedBy { get; set; }
public bool IsDetail6Active { get; set; }
public int Detail6SortOrder { get; set; }


public int Field48Id { get; set; }
public string Field48Name { get; set; }
public string Field48Description { get; set; }
public DateTime Field48CreatedAt { get; set; }
public DateTime? Field48UpdatedAt { get; set; }
public string Field48CreatedBy { get; set; }
public bool IsField48Active { get; set; }
public int Field48SortOrder { get; set; }


public int Item1Id { get; set; }
public string Item1Name { get; set; }
public string Item1Description { get; set; }
public DateTime Item1CreatedAt { get; set; }
public DateTime? Item1UpdatedAt { get; set; }
public string Item1CreatedBy { get; set; }
public bool IsItem1Active { get; set; }
public int Item1SortOrder { get; set; }


public int Entry7Id { get; set; }
public string Entry7Name { get; set; }
public string Entry7Description { get; set; }
public DateTime Entry7CreatedAt { get; set; }
public DateTime? Entry7UpdatedAt { get; set; }
public string Entry7CreatedBy { get; set; }
public bool IsEntry7Active { get; set; }
public int Entry7SortOrder { get; set; }


public int Detail50Id { get; set; }
public string Detail50Name { get; set; }
public string Detail50Description { get; set; }
public DateTime Detail50CreatedAt { get; set; }
public DateTime? Detail50UpdatedAt { get; set; }
public string Detail50CreatedBy { get; set; }
public bool IsDetail50Active { get; set; }
public int Detail50SortOrder { get; set; }


public int Attr5Id { get; set; }
public string Attr5Name { get; set; }
public string Attr5Description { get; set; }
public DateTime Attr5CreatedAt { get; set; }
public DateTime? Attr5UpdatedAt { get; set; }
public string Attr5CreatedBy { get; set; }
public bool IsAttr5Active { get; set; }
public int Attr5SortOrder { get; set; }


public int Entry97Id { get; set; }
public string Entry97Name { get; set; }
public string Entry97Description { get; set; }
public DateTime Entry97CreatedAt { get; set; }
public DateTime? Entry97UpdatedAt { get; set; }
public string Entry97CreatedBy { get; set; }
public bool IsEntry97Active { get; set; }
public int Entry97SortOrder { get; set; }


public int Detail42Id { get; set; }
public string Detail42Name { get; set; }
public string Detail42Description { get; set; }
public DateTime Detail42CreatedAt { get; set; }
public DateTime? Detail42UpdatedAt { get; set; }
public string Detail42CreatedBy { get; set; }
public bool IsDetail42Active { get; set; }
public int Detail42SortOrder { get; set; }


public int Entry79Id { get; set; }
public string Entry79Name { get; set; }
public string Entry79Description { get; set; }
public DateTime Entry79CreatedAt { get; set; }
public DateTime? Entry79UpdatedAt { get; set; }
public string Entry79CreatedBy { get; set; }
public bool IsEntry79Active { get; set; }
public int Entry79SortOrder { get; set; }


public int Field82Id { get; set; }
public string Field82Name { get; set; }
public string Field82Description { get; set; }
public DateTime Field82CreatedAt { get; set; }
public DateTime? Field82UpdatedAt { get; set; }
public string Field82CreatedBy { get; set; }
public bool IsField82Active { get; set; }
public int Field82SortOrder { get; set; }


public int Record6Id { get; set; }
public string Record6Name { get; set; }
public string Record6Description { get; set; }
public DateTime Record6CreatedAt { get; set; }
public DateTime? Record6UpdatedAt { get; set; }
public string Record6CreatedBy { get; set; }
public bool IsRecord6Active { get; set; }
public int Record6SortOrder { get; set; }


public int Param42Id { get; set; }
public string Param42Name { get; set; }
public string Param42Description { get; set; }
public DateTime Param42CreatedAt { get; set; }
public DateTime? Param42UpdatedAt { get; set; }
public string Param42CreatedBy { get; set; }
public bool IsParam42Active { get; set; }
public int Param42SortOrder { get; set; }


public int Param35Id { get; set; }
public string Param35Name { get; set; }
public string Param35Description { get; set; }
public DateTime Param35CreatedAt { get; set; }
public DateTime? Param35UpdatedAt { get; set; }
public string Param35CreatedBy { get; set; }
public bool IsParam35Active { get; set; }
public int Param35SortOrder { get; set; }


public int Config53Id { get; set; }
public string Config53Name { get; set; }
public string Config53Description { get; set; }
public DateTime Config53CreatedAt { get; set; }
public DateTime? Config53UpdatedAt { get; set; }
public string Config53CreatedBy { get; set; }
public bool IsConfig53Active { get; set; }
public int Config53SortOrder { get; set; }


public int Param53Id { get; set; }
public string Param53Name { get; set; }
public string Param53Description { get; set; }
public DateTime Param53CreatedAt { get; set; }
public DateTime? Param53UpdatedAt { get; set; }
public string Param53CreatedBy { get; set; }
public bool IsParam53Active { get; set; }
public int Param53SortOrder { get; set; }


public int Attr57Id { get; set; }
public string Attr57Name { get; set; }
public string Attr57Description { get; set; }
public DateTime Attr57CreatedAt { get; set; }
public DateTime? Attr57UpdatedAt { get; set; }
public string Attr57CreatedBy { get; set; }
public bool IsAttr57Active { get; set; }
public int Attr57SortOrder { get; set; }


public int Detail60Id { get; set; }
public string Detail60Name { get; set; }
public string Detail60Description { get; set; }
public DateTime Detail60CreatedAt { get; set; }
public DateTime? Detail60UpdatedAt { get; set; }
public string Detail60CreatedBy { get; set; }
public bool IsDetail60Active { get; set; }
public int Detail60SortOrder { get; set; }


public int Record13Id { get; set; }
public string Record13Name { get; set; }
public string Record13Description { get; set; }
public DateTime Record13CreatedAt { get; set; }
public DateTime? Record13UpdatedAt { get; set; }
public string Record13CreatedBy { get; set; }
public bool IsRecord13Active { get; set; }
public int Record13SortOrder { get; set; }


public int Item14Id { get; set; }
public string Item14Name { get; set; }
public string Item14Description { get; set; }
public DateTime Item14CreatedAt { get; set; }
public DateTime? Item14UpdatedAt { get; set; }
public string Item14CreatedBy { get; set; }
public bool IsItem14Active { get; set; }
public int Item14SortOrder { get; set; }


public int Record6Id { get; set; }
public string Record6Name { get; set; }
public string Record6Description { get; set; }
public DateTime Record6CreatedAt { get; set; }
public DateTime? Record6UpdatedAt { get; set; }
public string Record6CreatedBy { get; set; }
public bool IsRecord6Active { get; set; }
public int Record6SortOrder { get; set; }


public int Item62Id { get; set; }
public string Item62Name { get; set; }
public string Item62Description { get; set; }
public DateTime Item62CreatedAt { get; set; }
public DateTime? Item62UpdatedAt { get; set; }
public string Item62CreatedBy { get; set; }
public bool IsItem62Active { get; set; }
public int Item62SortOrder { get; set; }


public int Field56Id { get; set; }
public string Field56Name { get; set; }
public string Field56Description { get; set; }
public DateTime Field56CreatedAt { get; set; }
public DateTime? Field56UpdatedAt { get; set; }
public string Field56CreatedBy { get; set; }
public bool IsField56Active { get; set; }
public int Field56SortOrder { get; set; }


public int Config17Id { get; set; }
public string Config17Name { get; set; }
public string Config17Description { get; set; }
public DateTime Config17CreatedAt { get; set; }
public DateTime? Config17UpdatedAt { get; set; }
public string Config17CreatedBy { get; set; }
public bool IsConfig17Active { get; set; }
public int Config17SortOrder { get; set; }


public int Detail87Id { get; set; }
public string Detail87Name { get; set; }
public string Detail87Description { get; set; }
public DateTime Detail87CreatedAt { get; set; }
public DateTime? Detail87UpdatedAt { get; set; }
public string Detail87CreatedBy { get; set; }
public bool IsDetail87Active { get; set; }
public int Detail87SortOrder { get; set; }


public int Entry70Id { get; set; }
public string Entry70Name { get; set; }
public string Entry70Description { get; set; }
public DateTime Entry70CreatedAt { get; set; }
public DateTime? Entry70UpdatedAt { get; set; }
public string Entry70CreatedBy { get; set; }
public bool IsEntry70Active { get; set; }
public int Entry70SortOrder { get; set; }


public int Entry79Id { get; set; }
public string Entry79Name { get; set; }
public string Entry79Description { get; set; }
public DateTime Entry79CreatedAt { get; set; }
public DateTime? Entry79UpdatedAt { get; set; }
public string Entry79CreatedBy { get; set; }
public bool IsEntry79Active { get; set; }
public int Entry79SortOrder { get; set; }


public int Config45Id { get; set; }
public string Config45Name { get; set; }
public string Config45Description { get; set; }
public DateTime Config45CreatedAt { get; set; }
public DateTime? Config45UpdatedAt { get; set; }
public string Config45CreatedBy { get; set; }
public bool IsConfig45Active { get; set; }
public int Config45SortOrder { get; set; }


public int Record54Id { get; set; }
public string Record54Name { get; set; }
public string Record54Description { get; set; }
public DateTime Record54CreatedAt { get; set; }
public DateTime? Record54UpdatedAt { get; set; }
public string Record54CreatedBy { get; set; }
public bool IsRecord54Active { get; set; }
public int Record54SortOrder { get; set; }


public int Detail40Id { get; set; }
public string Detail40Name { get; set; }
public string Detail40Description { get; set; }
public DateTime Detail40CreatedAt { get; set; }
public DateTime? Detail40UpdatedAt { get; set; }
public string Detail40CreatedBy { get; set; }
public bool IsDetail40Active { get; set; }
public int Detail40SortOrder { get; set; }


public int Attr71Id { get; set; }
public string Attr71Name { get; set; }
public string Attr71Description { get; set; }
public DateTime Attr71CreatedAt { get; set; }
public DateTime? Attr71UpdatedAt { get; set; }
public string Attr71CreatedBy { get; set; }
public bool IsAttr71Active { get; set; }
public int Attr71SortOrder { get; set; }


public int Attr69Id { get; set; }
public string Attr69Name { get; set; }
public string Attr69Description { get; set; }
public DateTime Attr69CreatedAt { get; set; }
public DateTime? Attr69UpdatedAt { get; set; }
public string Attr69CreatedBy { get; set; }
public bool IsAttr69Active { get; set; }
public int Attr69SortOrder { get; set; }


public int Record27Id { get; set; }
public string Record27Name { get; set; }
public string Record27Description { get; set; }
public DateTime Record27CreatedAt { get; set; }
public DateTime? Record27UpdatedAt { get; set; }
public string Record27CreatedBy { get; set; }
public bool IsRecord27Active { get; set; }
public int Record27SortOrder { get; set; }


public int Config89Id { get; set; }
public string Config89Name { get; set; }
public string Config89Description { get; set; }
public DateTime Config89CreatedAt { get; set; }
public DateTime? Config89UpdatedAt { get; set; }
public string Config89CreatedBy { get; set; }
public bool IsConfig89Active { get; set; }
public int Config89SortOrder { get; set; }


public int Item26Id { get; set; }
public string Item26Name { get; set; }
public string Item26Description { get; set; }
public DateTime Item26CreatedAt { get; set; }
public DateTime? Item26UpdatedAt { get; set; }
public string Item26CreatedBy { get; set; }
public bool IsItem26Active { get; set; }
public int Item26SortOrder { get; set; }

    }
}