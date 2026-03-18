using Admin.Client177;
using Admin.Validators431;
using Admin.Web;
using Admin.Web46;
using Auth.Mappers178;
using BatchJobs.Events;
using BatchJobs.Processors;
using Common.Web438;
using DataAccess.Client82;
using DataAccess.Shared486;
using DataAccess.Tests;
using Export.Api;
using Notifications.Tests299;
using Notifications.Web;
using Portal.Tests323;
using Scheduling.Tests85;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Mappers;
using Workflow.Models;

namespace Export.Tests62
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer6
    {
        private readonly IAdmin_Client177_Provider14 _iAdmin_Client177_Provider14;
        private readonly Admin_Client177_Factory8 _admin_Client177_Factory8;
        private readonly Admin_Client177_Provider4 _admin_Client177_Provider4;
        private readonly IAuth_Mappers178_Provider _iAuth_Mappers178_Provider;
        private readonly Auth_Mappers178_Controller6 _auth_Mappers178_Controller6;
        private readonly Auth_Mappers178_Builder4 _auth_Mappers178_Builder4;
        private readonly Admin_Web_Response2 _admin_Web_Response2;
        private readonly IBatchJobs_Events_Validator5 _iBatchJobs_Events_Validator5;

        public Consumer6(IAdmin_Client177_Provider14 iAdmin_Client177_Provider14, Admin_Client177_Factory8 admin_Client177_Factory8, Admin_Client177_Provider4 admin_Client177_Provider4, IAuth_Mappers178_Provider iAuth_Mappers178_Provider, Auth_Mappers178_Controller6 auth_Mappers178_Controller6, Auth_Mappers178_Builder4 auth_Mappers178_Builder4, Admin_Web_Response2 admin_Web_Response2, IBatchJobs_Events_Validator5 iBatchJobs_Events_Validator5)
        {
            _iAdmin_Client177_Provider14 = iAdmin_Client177_Provider14 ?? throw new ArgumentNullException(nameof(iAdmin_Client177_Provider14));
            _admin_Client177_Factory8 = admin_Client177_Factory8 ?? throw new ArgumentNullException(nameof(admin_Client177_Factory8));
            _admin_Client177_Provider4 = admin_Client177_Provider4 ?? throw new ArgumentNullException(nameof(admin_Client177_Provider4));
            _iAuth_Mappers178_Provider = iAuth_Mappers178_Provider ?? throw new ArgumentNullException(nameof(iAuth_Mappers178_Provider));
            _auth_Mappers178_Controller6 = auth_Mappers178_Controller6 ?? throw new ArgumentNullException(nameof(auth_Mappers178_Controller6));
            _auth_Mappers178_Builder4 = auth_Mappers178_Builder4 ?? throw new ArgumentNullException(nameof(auth_Mappers178_Builder4));
            _admin_Web_Response2 = admin_Web_Response2 ?? throw new ArgumentNullException(nameof(admin_Web_Response2));
            _iBatchJobs_Events_Validator5 = iBatchJobs_Events_Validator5 ?? throw new ArgumentNullException(nameof(iBatchJobs_Events_Validator5));
        }

        public IAdmin_Client177_Provider14 GetIAdmin_Client177_Provider14() => _iAdmin_Client177_Provider14;
        public Admin_Client177_Factory8 GetAdmin_Client177_Factory8() => _admin_Client177_Factory8;
        public Admin_Client177_Provider4 GetAdmin_Client177_Provider4() => _admin_Client177_Provider4;
        public IAuth_Mappers178_Provider GetIAuth_Mappers178_Provider() => _iAuth_Mappers178_Provider;
        public Auth_Mappers178_Controller6 GetAuth_Mappers178_Controller6() => _auth_Mappers178_Controller6;
        public Auth_Mappers178_Builder4 GetAuth_Mappers178_Builder4() => _auth_Mappers178_Builder4;
        public Admin_Web_Response2 GetAdmin_Web_Response2() => _admin_Web_Response2;
        public IBatchJobs_Events_Validator5 GetIBatchJobs_Events_Validator5() => _iBatchJobs_Events_Validator5;

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

public int Entry29Id { get; set; }
public string Entry29Name { get; set; }
public string Entry29Description { get; set; }
public DateTime Entry29CreatedAt { get; set; }
public DateTime? Entry29UpdatedAt { get; set; }
public string Entry29CreatedBy { get; set; }
public bool IsEntry29Active { get; set; }
public int Entry29SortOrder { get; set; }


public int Config90Id { get; set; }
public string Config90Name { get; set; }
public string Config90Description { get; set; }
public DateTime Config90CreatedAt { get; set; }
public DateTime? Config90UpdatedAt { get; set; }
public string Config90CreatedBy { get; set; }
public bool IsConfig90Active { get; set; }
public int Config90SortOrder { get; set; }


public int Field48Id { get; set; }
public string Field48Name { get; set; }
public string Field48Description { get; set; }
public DateTime Field48CreatedAt { get; set; }
public DateTime? Field48UpdatedAt { get; set; }
public string Field48CreatedBy { get; set; }
public bool IsField48Active { get; set; }
public int Field48SortOrder { get; set; }


public int Item91Id { get; set; }
public string Item91Name { get; set; }
public string Item91Description { get; set; }
public DateTime Item91CreatedAt { get; set; }
public DateTime? Item91UpdatedAt { get; set; }
public string Item91CreatedBy { get; set; }
public bool IsItem91Active { get; set; }
public int Item91SortOrder { get; set; }


public int Param79Id { get; set; }
public string Param79Name { get; set; }
public string Param79Description { get; set; }
public DateTime Param79CreatedAt { get; set; }
public DateTime? Param79UpdatedAt { get; set; }
public string Param79CreatedBy { get; set; }
public bool IsParam79Active { get; set; }
public int Param79SortOrder { get; set; }


public int Param44Id { get; set; }
public string Param44Name { get; set; }
public string Param44Description { get; set; }
public DateTime Param44CreatedAt { get; set; }
public DateTime? Param44UpdatedAt { get; set; }
public string Param44CreatedBy { get; set; }
public bool IsParam44Active { get; set; }
public int Param44SortOrder { get; set; }


public int Detail22Id { get; set; }
public string Detail22Name { get; set; }
public string Detail22Description { get; set; }
public DateTime Detail22CreatedAt { get; set; }
public DateTime? Detail22UpdatedAt { get; set; }
public string Detail22CreatedBy { get; set; }
public bool IsDetail22Active { get; set; }
public int Detail22SortOrder { get; set; }


public int Item36Id { get; set; }
public string Item36Name { get; set; }
public string Item36Description { get; set; }
public DateTime Item36CreatedAt { get; set; }
public DateTime? Item36UpdatedAt { get; set; }
public string Item36CreatedBy { get; set; }
public bool IsItem36Active { get; set; }
public int Item36SortOrder { get; set; }


public int Record15Id { get; set; }
public string Record15Name { get; set; }
public string Record15Description { get; set; }
public DateTime Record15CreatedAt { get; set; }
public DateTime? Record15UpdatedAt { get; set; }
public string Record15CreatedBy { get; set; }
public bool IsRecord15Active { get; set; }
public int Record15SortOrder { get; set; }


public int Config27Id { get; set; }
public string Config27Name { get; set; }
public string Config27Description { get; set; }
public DateTime Config27CreatedAt { get; set; }
public DateTime? Config27UpdatedAt { get; set; }
public string Config27CreatedBy { get; set; }
public bool IsConfig27Active { get; set; }
public int Config27SortOrder { get; set; }


public int Config24Id { get; set; }
public string Config24Name { get; set; }
public string Config24Description { get; set; }
public DateTime Config24CreatedAt { get; set; }
public DateTime? Config24UpdatedAt { get; set; }
public string Config24CreatedBy { get; set; }
public bool IsConfig24Active { get; set; }
public int Config24SortOrder { get; set; }


public int Field97Id { get; set; }
public string Field97Name { get; set; }
public string Field97Description { get; set; }
public DateTime Field97CreatedAt { get; set; }
public DateTime? Field97UpdatedAt { get; set; }
public string Field97CreatedBy { get; set; }
public bool IsField97Active { get; set; }
public int Field97SortOrder { get; set; }


public int Param23Id { get; set; }
public string Param23Name { get; set; }
public string Param23Description { get; set; }
public DateTime Param23CreatedAt { get; set; }
public DateTime? Param23UpdatedAt { get; set; }
public string Param23CreatedBy { get; set; }
public bool IsParam23Active { get; set; }
public int Param23SortOrder { get; set; }


public int Param28Id { get; set; }
public string Param28Name { get; set; }
public string Param28Description { get; set; }
public DateTime Param28CreatedAt { get; set; }
public DateTime? Param28UpdatedAt { get; set; }
public string Param28CreatedBy { get; set; }
public bool IsParam28Active { get; set; }
public int Param28SortOrder { get; set; }


public int Field75Id { get; set; }
public string Field75Name { get; set; }
public string Field75Description { get; set; }
public DateTime Field75CreatedAt { get; set; }
public DateTime? Field75UpdatedAt { get; set; }
public string Field75CreatedBy { get; set; }
public bool IsField75Active { get; set; }
public int Field75SortOrder { get; set; }


public int Record62Id { get; set; }
public string Record62Name { get; set; }
public string Record62Description { get; set; }
public DateTime Record62CreatedAt { get; set; }
public DateTime? Record62UpdatedAt { get; set; }
public string Record62CreatedBy { get; set; }
public bool IsRecord62Active { get; set; }
public int Record62SortOrder { get; set; }


public int Attr33Id { get; set; }
public string Attr33Name { get; set; }
public string Attr33Description { get; set; }
public DateTime Attr33CreatedAt { get; set; }
public DateTime? Attr33UpdatedAt { get; set; }
public string Attr33CreatedBy { get; set; }
public bool IsAttr33Active { get; set; }
public int Attr33SortOrder { get; set; }


public int Config51Id { get; set; }
public string Config51Name { get; set; }
public string Config51Description { get; set; }
public DateTime Config51CreatedAt { get; set; }
public DateTime? Config51UpdatedAt { get; set; }
public string Config51CreatedBy { get; set; }
public bool IsConfig51Active { get; set; }
public int Config51SortOrder { get; set; }


public int Item10Id { get; set; }
public string Item10Name { get; set; }
public string Item10Description { get; set; }
public DateTime Item10CreatedAt { get; set; }
public DateTime? Item10UpdatedAt { get; set; }
public string Item10CreatedBy { get; set; }
public bool IsItem10Active { get; set; }
public int Item10SortOrder { get; set; }


public int Record99Id { get; set; }
public string Record99Name { get; set; }
public string Record99Description { get; set; }
public DateTime Record99CreatedAt { get; set; }
public DateTime? Record99UpdatedAt { get; set; }
public string Record99CreatedBy { get; set; }
public bool IsRecord99Active { get; set; }
public int Record99SortOrder { get; set; }


public int Record88Id { get; set; }
public string Record88Name { get; set; }
public string Record88Description { get; set; }
public DateTime Record88CreatedAt { get; set; }
public DateTime? Record88UpdatedAt { get; set; }
public string Record88CreatedBy { get; set; }
public bool IsRecord88Active { get; set; }
public int Record88SortOrder { get; set; }


public int Entry65Id { get; set; }
public string Entry65Name { get; set; }
public string Entry65Description { get; set; }
public DateTime Entry65CreatedAt { get; set; }
public DateTime? Entry65UpdatedAt { get; set; }
public string Entry65CreatedBy { get; set; }
public bool IsEntry65Active { get; set; }
public int Entry65SortOrder { get; set; }


public int Entry90Id { get; set; }
public string Entry90Name { get; set; }
public string Entry90Description { get; set; }
public DateTime Entry90CreatedAt { get; set; }
public DateTime? Entry90UpdatedAt { get; set; }
public string Entry90CreatedBy { get; set; }
public bool IsEntry90Active { get; set; }
public int Entry90SortOrder { get; set; }


public int Config66Id { get; set; }
public string Config66Name { get; set; }
public string Config66Description { get; set; }
public DateTime Config66CreatedAt { get; set; }
public DateTime? Config66UpdatedAt { get; set; }
public string Config66CreatedBy { get; set; }
public bool IsConfig66Active { get; set; }
public int Config66SortOrder { get; set; }


public int Param70Id { get; set; }
public string Param70Name { get; set; }
public string Param70Description { get; set; }
public DateTime Param70CreatedAt { get; set; }
public DateTime? Param70UpdatedAt { get; set; }
public string Param70CreatedBy { get; set; }
public bool IsParam70Active { get; set; }
public int Param70SortOrder { get; set; }


public int Config42Id { get; set; }
public string Config42Name { get; set; }
public string Config42Description { get; set; }
public DateTime Config42CreatedAt { get; set; }
public DateTime? Config42UpdatedAt { get; set; }
public string Config42CreatedBy { get; set; }
public bool IsConfig42Active { get; set; }
public int Config42SortOrder { get; set; }


public int Attr12Id { get; set; }
public string Attr12Name { get; set; }
public string Attr12Description { get; set; }
public DateTime Attr12CreatedAt { get; set; }
public DateTime? Attr12UpdatedAt { get; set; }
public string Attr12CreatedBy { get; set; }
public bool IsAttr12Active { get; set; }
public int Attr12SortOrder { get; set; }


public int Param52Id { get; set; }
public string Param52Name { get; set; }
public string Param52Description { get; set; }
public DateTime Param52CreatedAt { get; set; }
public DateTime? Param52UpdatedAt { get; set; }
public string Param52CreatedBy { get; set; }
public bool IsParam52Active { get; set; }
public int Param52SortOrder { get; set; }


public int Detail98Id { get; set; }
public string Detail98Name { get; set; }
public string Detail98Description { get; set; }
public DateTime Detail98CreatedAt { get; set; }
public DateTime? Detail98UpdatedAt { get; set; }
public string Detail98CreatedBy { get; set; }
public bool IsDetail98Active { get; set; }
public int Detail98SortOrder { get; set; }


public int Param47Id { get; set; }
public string Param47Name { get; set; }
public string Param47Description { get; set; }
public DateTime Param47CreatedAt { get; set; }
public DateTime? Param47UpdatedAt { get; set; }
public string Param47CreatedBy { get; set; }
public bool IsParam47Active { get; set; }
public int Param47SortOrder { get; set; }


public int Record99Id { get; set; }
public string Record99Name { get; set; }
public string Record99Description { get; set; }
public DateTime Record99CreatedAt { get; set; }
public DateTime? Record99UpdatedAt { get; set; }
public string Record99CreatedBy { get; set; }
public bool IsRecord99Active { get; set; }
public int Record99SortOrder { get; set; }


public int Record45Id { get; set; }
public string Record45Name { get; set; }
public string Record45Description { get; set; }
public DateTime Record45CreatedAt { get; set; }
public DateTime? Record45UpdatedAt { get; set; }
public string Record45CreatedBy { get; set; }
public bool IsRecord45Active { get; set; }
public int Record45SortOrder { get; set; }


public int Field42Id { get; set; }
public string Field42Name { get; set; }
public string Field42Description { get; set; }
public DateTime Field42CreatedAt { get; set; }
public DateTime? Field42UpdatedAt { get; set; }
public string Field42CreatedBy { get; set; }
public bool IsField42Active { get; set; }
public int Field42SortOrder { get; set; }


public int Detail25Id { get; set; }
public string Detail25Name { get; set; }
public string Detail25Description { get; set; }
public DateTime Detail25CreatedAt { get; set; }
public DateTime? Detail25UpdatedAt { get; set; }
public string Detail25CreatedBy { get; set; }
public bool IsDetail25Active { get; set; }
public int Detail25SortOrder { get; set; }


public int Param37Id { get; set; }
public string Param37Name { get; set; }
public string Param37Description { get; set; }
public DateTime Param37CreatedAt { get; set; }
public DateTime? Param37UpdatedAt { get; set; }
public string Param37CreatedBy { get; set; }
public bool IsParam37Active { get; set; }
public int Param37SortOrder { get; set; }


public int Detail28Id { get; set; }
public string Detail28Name { get; set; }
public string Detail28Description { get; set; }
public DateTime Detail28CreatedAt { get; set; }
public DateTime? Detail28UpdatedAt { get; set; }
public string Detail28CreatedBy { get; set; }
public bool IsDetail28Active { get; set; }
public int Detail28SortOrder { get; set; }


public int Attr83Id { get; set; }
public string Attr83Name { get; set; }
public string Attr83Description { get; set; }
public DateTime Attr83CreatedAt { get; set; }
public DateTime? Attr83UpdatedAt { get; set; }
public string Attr83CreatedBy { get; set; }
public bool IsAttr83Active { get; set; }
public int Attr83SortOrder { get; set; }


public int Entry41Id { get; set; }
public string Entry41Name { get; set; }
public string Entry41Description { get; set; }
public DateTime Entry41CreatedAt { get; set; }
public DateTime? Entry41UpdatedAt { get; set; }
public string Entry41CreatedBy { get; set; }
public bool IsEntry41Active { get; set; }
public int Entry41SortOrder { get; set; }


public int Item87Id { get; set; }
public string Item87Name { get; set; }
public string Item87Description { get; set; }
public DateTime Item87CreatedAt { get; set; }
public DateTime? Item87UpdatedAt { get; set; }
public string Item87CreatedBy { get; set; }
public bool IsItem87Active { get; set; }
public int Item87SortOrder { get; set; }


public int Detail52Id { get; set; }
public string Detail52Name { get; set; }
public string Detail52Description { get; set; }
public DateTime Detail52CreatedAt { get; set; }
public DateTime? Detail52UpdatedAt { get; set; }
public string Detail52CreatedBy { get; set; }
public bool IsDetail52Active { get; set; }
public int Detail52SortOrder { get; set; }


public int Detail15Id { get; set; }
public string Detail15Name { get; set; }
public string Detail15Description { get; set; }
public DateTime Detail15CreatedAt { get; set; }
public DateTime? Detail15UpdatedAt { get; set; }
public string Detail15CreatedBy { get; set; }
public bool IsDetail15Active { get; set; }
public int Detail15SortOrder { get; set; }


public int Config2Id { get; set; }
public string Config2Name { get; set; }
public string Config2Description { get; set; }
public DateTime Config2CreatedAt { get; set; }
public DateTime? Config2UpdatedAt { get; set; }
public string Config2CreatedBy { get; set; }
public bool IsConfig2Active { get; set; }
public int Config2SortOrder { get; set; }


public int Attr82Id { get; set; }
public string Attr82Name { get; set; }
public string Attr82Description { get; set; }
public DateTime Attr82CreatedAt { get; set; }
public DateTime? Attr82UpdatedAt { get; set; }
public string Attr82CreatedBy { get; set; }
public bool IsAttr82Active { get; set; }
public int Attr82SortOrder { get; set; }


public int Detail73Id { get; set; }
public string Detail73Name { get; set; }
public string Detail73Description { get; set; }
public DateTime Detail73CreatedAt { get; set; }
public DateTime? Detail73UpdatedAt { get; set; }
public string Detail73CreatedBy { get; set; }
public bool IsDetail73Active { get; set; }
public int Detail73SortOrder { get; set; }


public int Entry38Id { get; set; }
public string Entry38Name { get; set; }
public string Entry38Description { get; set; }
public DateTime Entry38CreatedAt { get; set; }
public DateTime? Entry38UpdatedAt { get; set; }
public string Entry38CreatedBy { get; set; }
public bool IsEntry38Active { get; set; }
public int Entry38SortOrder { get; set; }

    }
}