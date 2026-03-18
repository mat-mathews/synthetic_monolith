using Admin.Core121;
using Auth.Contracts395;
using Auth.Core140;
using BatchJobs.Client;
using BatchJobs.Validators311;
using Billing.Api497;
using Billing.Processors259;
using Documents.Data419;
using GalaxyWorks.Api390;
using Imaging.Contracts;
using Import.Core;
using Portal.Validators125;
using Scheduling.Api3;
using Security.Models420;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Shared;
using Workflow.Contracts;

namespace Integration.Api469
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer6
    {
        private readonly Admin_Core121_Options4 _admin_Core121_Options4;
        private readonly Auth_Contracts395_Provider2 _auth_Contracts395_Provider2;
        private readonly IAuth_Contracts395_Validator1 _iAuth_Contracts395_Validator1;
        private readonly Auth_Contracts395_Handler8 _auth_Contracts395_Handler8;
        private readonly Scheduling_Api3_Response _scheduling_Api3_Response;
        private readonly Scheduling_Api3_Request1 _scheduling_Api3_Request1;
        private readonly Scheduling_Api3_ViewModel3 _scheduling_Api3_ViewModel3;
        private readonly Security_Models420_Handler2 _security_Models420_Handler2;

        public Consumer6(Admin_Core121_Options4 admin_Core121_Options4, Auth_Contracts395_Provider2 auth_Contracts395_Provider2, IAuth_Contracts395_Validator1 iAuth_Contracts395_Validator1, Auth_Contracts395_Handler8 auth_Contracts395_Handler8, Scheduling_Api3_Response scheduling_Api3_Response, Scheduling_Api3_Request1 scheduling_Api3_Request1, Scheduling_Api3_ViewModel3 scheduling_Api3_ViewModel3, Security_Models420_Handler2 security_Models420_Handler2)
        {
            _admin_Core121_Options4 = admin_Core121_Options4 ?? throw new ArgumentNullException(nameof(admin_Core121_Options4));
            _auth_Contracts395_Provider2 = auth_Contracts395_Provider2 ?? throw new ArgumentNullException(nameof(auth_Contracts395_Provider2));
            _iAuth_Contracts395_Validator1 = iAuth_Contracts395_Validator1 ?? throw new ArgumentNullException(nameof(iAuth_Contracts395_Validator1));
            _auth_Contracts395_Handler8 = auth_Contracts395_Handler8 ?? throw new ArgumentNullException(nameof(auth_Contracts395_Handler8));
            _scheduling_Api3_Response = scheduling_Api3_Response ?? throw new ArgumentNullException(nameof(scheduling_Api3_Response));
            _scheduling_Api3_Request1 = scheduling_Api3_Request1 ?? throw new ArgumentNullException(nameof(scheduling_Api3_Request1));
            _scheduling_Api3_ViewModel3 = scheduling_Api3_ViewModel3 ?? throw new ArgumentNullException(nameof(scheduling_Api3_ViewModel3));
            _security_Models420_Handler2 = security_Models420_Handler2 ?? throw new ArgumentNullException(nameof(security_Models420_Handler2));
        }

        public Admin_Core121_Options4 GetAdmin_Core121_Options4() => _admin_Core121_Options4;
        public Auth_Contracts395_Provider2 GetAuth_Contracts395_Provider2() => _auth_Contracts395_Provider2;
        public IAuth_Contracts395_Validator1 GetIAuth_Contracts395_Validator1() => _iAuth_Contracts395_Validator1;
        public Auth_Contracts395_Handler8 GetAuth_Contracts395_Handler8() => _auth_Contracts395_Handler8;
        public Scheduling_Api3_Response GetScheduling_Api3_Response() => _scheduling_Api3_Response;
        public Scheduling_Api3_Request1 GetScheduling_Api3_Request1() => _scheduling_Api3_Request1;
        public Scheduling_Api3_ViewModel3 GetScheduling_Api3_ViewModel3() => _scheduling_Api3_ViewModel3;
        public Security_Models420_Handler2 GetSecurity_Models420_Handler2() => _security_Models420_Handler2;

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

public int Config65Id { get; set; }
public string Config65Name { get; set; }
public string Config65Description { get; set; }
public DateTime Config65CreatedAt { get; set; }
public DateTime? Config65UpdatedAt { get; set; }
public string Config65CreatedBy { get; set; }
public bool IsConfig65Active { get; set; }
public int Config65SortOrder { get; set; }


public int Field4Id { get; set; }
public string Field4Name { get; set; }
public string Field4Description { get; set; }
public DateTime Field4CreatedAt { get; set; }
public DateTime? Field4UpdatedAt { get; set; }
public string Field4CreatedBy { get; set; }
public bool IsField4Active { get; set; }
public int Field4SortOrder { get; set; }


public int Param69Id { get; set; }
public string Param69Name { get; set; }
public string Param69Description { get; set; }
public DateTime Param69CreatedAt { get; set; }
public DateTime? Param69UpdatedAt { get; set; }
public string Param69CreatedBy { get; set; }
public bool IsParam69Active { get; set; }
public int Param69SortOrder { get; set; }


public int Config74Id { get; set; }
public string Config74Name { get; set; }
public string Config74Description { get; set; }
public DateTime Config74CreatedAt { get; set; }
public DateTime? Config74UpdatedAt { get; set; }
public string Config74CreatedBy { get; set; }
public bool IsConfig74Active { get; set; }
public int Config74SortOrder { get; set; }


public int Param88Id { get; set; }
public string Param88Name { get; set; }
public string Param88Description { get; set; }
public DateTime Param88CreatedAt { get; set; }
public DateTime? Param88UpdatedAt { get; set; }
public string Param88CreatedBy { get; set; }
public bool IsParam88Active { get; set; }
public int Param88SortOrder { get; set; }


public int Entry77Id { get; set; }
public string Entry77Name { get; set; }
public string Entry77Description { get; set; }
public DateTime Entry77CreatedAt { get; set; }
public DateTime? Entry77UpdatedAt { get; set; }
public string Entry77CreatedBy { get; set; }
public bool IsEntry77Active { get; set; }
public int Entry77SortOrder { get; set; }


public int Field26Id { get; set; }
public string Field26Name { get; set; }
public string Field26Description { get; set; }
public DateTime Field26CreatedAt { get; set; }
public DateTime? Field26UpdatedAt { get; set; }
public string Field26CreatedBy { get; set; }
public bool IsField26Active { get; set; }
public int Field26SortOrder { get; set; }


public int Record67Id { get; set; }
public string Record67Name { get; set; }
public string Record67Description { get; set; }
public DateTime Record67CreatedAt { get; set; }
public DateTime? Record67UpdatedAt { get; set; }
public string Record67CreatedBy { get; set; }
public bool IsRecord67Active { get; set; }
public int Record67SortOrder { get; set; }


public int Field57Id { get; set; }
public string Field57Name { get; set; }
public string Field57Description { get; set; }
public DateTime Field57CreatedAt { get; set; }
public DateTime? Field57UpdatedAt { get; set; }
public string Field57CreatedBy { get; set; }
public bool IsField57Active { get; set; }
public int Field57SortOrder { get; set; }


public int Param29Id { get; set; }
public string Param29Name { get; set; }
public string Param29Description { get; set; }
public DateTime Param29CreatedAt { get; set; }
public DateTime? Param29UpdatedAt { get; set; }
public string Param29CreatedBy { get; set; }
public bool IsParam29Active { get; set; }
public int Param29SortOrder { get; set; }


public int Item44Id { get; set; }
public string Item44Name { get; set; }
public string Item44Description { get; set; }
public DateTime Item44CreatedAt { get; set; }
public DateTime? Item44UpdatedAt { get; set; }
public string Item44CreatedBy { get; set; }
public bool IsItem44Active { get; set; }
public int Item44SortOrder { get; set; }


public int Config9Id { get; set; }
public string Config9Name { get; set; }
public string Config9Description { get; set; }
public DateTime Config9CreatedAt { get; set; }
public DateTime? Config9UpdatedAt { get; set; }
public string Config9CreatedBy { get; set; }
public bool IsConfig9Active { get; set; }
public int Config9SortOrder { get; set; }


public int Record72Id { get; set; }
public string Record72Name { get; set; }
public string Record72Description { get; set; }
public DateTime Record72CreatedAt { get; set; }
public DateTime? Record72UpdatedAt { get; set; }
public string Record72CreatedBy { get; set; }
public bool IsRecord72Active { get; set; }
public int Record72SortOrder { get; set; }


public int Field48Id { get; set; }
public string Field48Name { get; set; }
public string Field48Description { get; set; }
public DateTime Field48CreatedAt { get; set; }
public DateTime? Field48UpdatedAt { get; set; }
public string Field48CreatedBy { get; set; }
public bool IsField48Active { get; set; }
public int Field48SortOrder { get; set; }


public int Config5Id { get; set; }
public string Config5Name { get; set; }
public string Config5Description { get; set; }
public DateTime Config5CreatedAt { get; set; }
public DateTime? Config5UpdatedAt { get; set; }
public string Config5CreatedBy { get; set; }
public bool IsConfig5Active { get; set; }
public int Config5SortOrder { get; set; }


public int Field28Id { get; set; }
public string Field28Name { get; set; }
public string Field28Description { get; set; }
public DateTime Field28CreatedAt { get; set; }
public DateTime? Field28UpdatedAt { get; set; }
public string Field28CreatedBy { get; set; }
public bool IsField28Active { get; set; }
public int Field28SortOrder { get; set; }


public int Config81Id { get; set; }
public string Config81Name { get; set; }
public string Config81Description { get; set; }
public DateTime Config81CreatedAt { get; set; }
public DateTime? Config81UpdatedAt { get; set; }
public string Config81CreatedBy { get; set; }
public bool IsConfig81Active { get; set; }
public int Config81SortOrder { get; set; }


public int Config83Id { get; set; }
public string Config83Name { get; set; }
public string Config83Description { get; set; }
public DateTime Config83CreatedAt { get; set; }
public DateTime? Config83UpdatedAt { get; set; }
public string Config83CreatedBy { get; set; }
public bool IsConfig83Active { get; set; }
public int Config83SortOrder { get; set; }


public int Detail12Id { get; set; }
public string Detail12Name { get; set; }
public string Detail12Description { get; set; }
public DateTime Detail12CreatedAt { get; set; }
public DateTime? Detail12UpdatedAt { get; set; }
public string Detail12CreatedBy { get; set; }
public bool IsDetail12Active { get; set; }
public int Detail12SortOrder { get; set; }


public int Field81Id { get; set; }
public string Field81Name { get; set; }
public string Field81Description { get; set; }
public DateTime Field81CreatedAt { get; set; }
public DateTime? Field81UpdatedAt { get; set; }
public string Field81CreatedBy { get; set; }
public bool IsField81Active { get; set; }
public int Field81SortOrder { get; set; }


public int Config9Id { get; set; }
public string Config9Name { get; set; }
public string Config9Description { get; set; }
public DateTime Config9CreatedAt { get; set; }
public DateTime? Config9UpdatedAt { get; set; }
public string Config9CreatedBy { get; set; }
public bool IsConfig9Active { get; set; }
public int Config9SortOrder { get; set; }


public int Entry30Id { get; set; }
public string Entry30Name { get; set; }
public string Entry30Description { get; set; }
public DateTime Entry30CreatedAt { get; set; }
public DateTime? Entry30UpdatedAt { get; set; }
public string Entry30CreatedBy { get; set; }
public bool IsEntry30Active { get; set; }
public int Entry30SortOrder { get; set; }


public int Item22Id { get; set; }
public string Item22Name { get; set; }
public string Item22Description { get; set; }
public DateTime Item22CreatedAt { get; set; }
public DateTime? Item22UpdatedAt { get; set; }
public string Item22CreatedBy { get; set; }
public bool IsItem22Active { get; set; }
public int Item22SortOrder { get; set; }


public int Entry74Id { get; set; }
public string Entry74Name { get; set; }
public string Entry74Description { get; set; }
public DateTime Entry74CreatedAt { get; set; }
public DateTime? Entry74UpdatedAt { get; set; }
public string Entry74CreatedBy { get; set; }
public bool IsEntry74Active { get; set; }
public int Entry74SortOrder { get; set; }


public int Detail17Id { get; set; }
public string Detail17Name { get; set; }
public string Detail17Description { get; set; }
public DateTime Detail17CreatedAt { get; set; }
public DateTime? Detail17UpdatedAt { get; set; }
public string Detail17CreatedBy { get; set; }
public bool IsDetail17Active { get; set; }
public int Detail17SortOrder { get; set; }


public int Record64Id { get; set; }
public string Record64Name { get; set; }
public string Record64Description { get; set; }
public DateTime Record64CreatedAt { get; set; }
public DateTime? Record64UpdatedAt { get; set; }
public string Record64CreatedBy { get; set; }
public bool IsRecord64Active { get; set; }
public int Record64SortOrder { get; set; }


public int Param42Id { get; set; }
public string Param42Name { get; set; }
public string Param42Description { get; set; }
public DateTime Param42CreatedAt { get; set; }
public DateTime? Param42UpdatedAt { get; set; }
public string Param42CreatedBy { get; set; }
public bool IsParam42Active { get; set; }
public int Param42SortOrder { get; set; }


public int Field60Id { get; set; }
public string Field60Name { get; set; }
public string Field60Description { get; set; }
public DateTime Field60CreatedAt { get; set; }
public DateTime? Field60UpdatedAt { get; set; }
public string Field60CreatedBy { get; set; }
public bool IsField60Active { get; set; }
public int Field60SortOrder { get; set; }


public int Attr57Id { get; set; }
public string Attr57Name { get; set; }
public string Attr57Description { get; set; }
public DateTime Attr57CreatedAt { get; set; }
public DateTime? Attr57UpdatedAt { get; set; }
public string Attr57CreatedBy { get; set; }
public bool IsAttr57Active { get; set; }
public int Attr57SortOrder { get; set; }


public int Param16Id { get; set; }
public string Param16Name { get; set; }
public string Param16Description { get; set; }
public DateTime Param16CreatedAt { get; set; }
public DateTime? Param16UpdatedAt { get; set; }
public string Param16CreatedBy { get; set; }
public bool IsParam16Active { get; set; }
public int Param16SortOrder { get; set; }


public int Config53Id { get; set; }
public string Config53Name { get; set; }
public string Config53Description { get; set; }
public DateTime Config53CreatedAt { get; set; }
public DateTime? Config53UpdatedAt { get; set; }
public string Config53CreatedBy { get; set; }
public bool IsConfig53Active { get; set; }
public int Config53SortOrder { get; set; }


public int Config65Id { get; set; }
public string Config65Name { get; set; }
public string Config65Description { get; set; }
public DateTime Config65CreatedAt { get; set; }
public DateTime? Config65UpdatedAt { get; set; }
public string Config65CreatedBy { get; set; }
public bool IsConfig65Active { get; set; }
public int Config65SortOrder { get; set; }


public int Record88Id { get; set; }
public string Record88Name { get; set; }
public string Record88Description { get; set; }
public DateTime Record88CreatedAt { get; set; }
public DateTime? Record88UpdatedAt { get; set; }
public string Record88CreatedBy { get; set; }
public bool IsRecord88Active { get; set; }
public int Record88SortOrder { get; set; }


public int Item98Id { get; set; }
public string Item98Name { get; set; }
public string Item98Description { get; set; }
public DateTime Item98CreatedAt { get; set; }
public DateTime? Item98UpdatedAt { get; set; }
public string Item98CreatedBy { get; set; }
public bool IsItem98Active { get; set; }
public int Item98SortOrder { get; set; }


public int Record14Id { get; set; }
public string Record14Name { get; set; }
public string Record14Description { get; set; }
public DateTime Record14CreatedAt { get; set; }
public DateTime? Record14UpdatedAt { get; set; }
public string Record14CreatedBy { get; set; }
public bool IsRecord14Active { get; set; }
public int Record14SortOrder { get; set; }


public int Item16Id { get; set; }
public string Item16Name { get; set; }
public string Item16Description { get; set; }
public DateTime Item16CreatedAt { get; set; }
public DateTime? Item16UpdatedAt { get; set; }
public string Item16CreatedBy { get; set; }
public bool IsItem16Active { get; set; }
public int Item16SortOrder { get; set; }


public int Config35Id { get; set; }
public string Config35Name { get; set; }
public string Config35Description { get; set; }
public DateTime Config35CreatedAt { get; set; }
public DateTime? Config35UpdatedAt { get; set; }
public string Config35CreatedBy { get; set; }
public bool IsConfig35Active { get; set; }
public int Config35SortOrder { get; set; }


public int Field11Id { get; set; }
public string Field11Name { get; set; }
public string Field11Description { get; set; }
public DateTime Field11CreatedAt { get; set; }
public DateTime? Field11UpdatedAt { get; set; }
public string Field11CreatedBy { get; set; }
public bool IsField11Active { get; set; }
public int Field11SortOrder { get; set; }


public int Attr89Id { get; set; }
public string Attr89Name { get; set; }
public string Attr89Description { get; set; }
public DateTime Attr89CreatedAt { get; set; }
public DateTime? Attr89UpdatedAt { get; set; }
public string Attr89CreatedBy { get; set; }
public bool IsAttr89Active { get; set; }
public int Attr89SortOrder { get; set; }


public int Entry14Id { get; set; }
public string Entry14Name { get; set; }
public string Entry14Description { get; set; }
public DateTime Entry14CreatedAt { get; set; }
public DateTime? Entry14UpdatedAt { get; set; }
public string Entry14CreatedBy { get; set; }
public bool IsEntry14Active { get; set; }
public int Entry14SortOrder { get; set; }


public int Attr45Id { get; set; }
public string Attr45Name { get; set; }
public string Attr45Description { get; set; }
public DateTime Attr45CreatedAt { get; set; }
public DateTime? Attr45UpdatedAt { get; set; }
public string Attr45CreatedBy { get; set; }
public bool IsAttr45Active { get; set; }
public int Attr45SortOrder { get; set; }


public int Item21Id { get; set; }
public string Item21Name { get; set; }
public string Item21Description { get; set; }
public DateTime Item21CreatedAt { get; set; }
public DateTime? Item21UpdatedAt { get; set; }
public string Item21CreatedBy { get; set; }
public bool IsItem21Active { get; set; }
public int Item21SortOrder { get; set; }


public int Record51Id { get; set; }
public string Record51Name { get; set; }
public string Record51Description { get; set; }
public DateTime Record51CreatedAt { get; set; }
public DateTime? Record51UpdatedAt { get; set; }
public string Record51CreatedBy { get; set; }
public bool IsRecord51Active { get; set; }
public int Record51SortOrder { get; set; }


public int Record92Id { get; set; }
public string Record92Name { get; set; }
public string Record92Description { get; set; }
public DateTime Record92CreatedAt { get; set; }
public DateTime? Record92UpdatedAt { get; set; }
public string Record92CreatedBy { get; set; }
public bool IsRecord92Active { get; set; }
public int Record92SortOrder { get; set; }


public int Attr64Id { get; set; }
public string Attr64Name { get; set; }
public string Attr64Description { get; set; }
public DateTime Attr64CreatedAt { get; set; }
public DateTime? Attr64UpdatedAt { get; set; }
public string Attr64CreatedBy { get; set; }
public bool IsAttr64Active { get; set; }
public int Attr64SortOrder { get; set; }

    }
}