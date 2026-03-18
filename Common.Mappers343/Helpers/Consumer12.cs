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
    public class Consumer12
    {
        private readonly IAdmin_Processors35_Repository3 _iAdmin_Processors35_Repository3;
        private readonly Admin_Processors35_Repository5 _admin_Processors35_Repository5;
        private readonly Admin_Models_Factory2 _admin_Models_Factory2;
        private readonly Auth_Handlers209_Controller5 _auth_Handlers209_Controller5;
        private readonly Auth_Handlers209_Event2 _auth_Handlers209_Event2;
        private readonly Auth_Client271_Controller1 _auth_Client271_Controller1;
        private readonly Auth_Client271_Controller2 _auth_Client271_Controller2;
        private readonly Auth_Client271_Manager _auth_Client271_Manager;

        public Consumer12(IAdmin_Processors35_Repository3 iAdmin_Processors35_Repository3, Admin_Processors35_Repository5 admin_Processors35_Repository5, Admin_Models_Factory2 admin_Models_Factory2, Auth_Handlers209_Controller5 auth_Handlers209_Controller5, Auth_Handlers209_Event2 auth_Handlers209_Event2, Auth_Client271_Controller1 auth_Client271_Controller1, Auth_Client271_Controller2 auth_Client271_Controller2, Auth_Client271_Manager auth_Client271_Manager)
        {
            _iAdmin_Processors35_Repository3 = iAdmin_Processors35_Repository3 ?? throw new ArgumentNullException(nameof(iAdmin_Processors35_Repository3));
            _admin_Processors35_Repository5 = admin_Processors35_Repository5 ?? throw new ArgumentNullException(nameof(admin_Processors35_Repository5));
            _admin_Models_Factory2 = admin_Models_Factory2 ?? throw new ArgumentNullException(nameof(admin_Models_Factory2));
            _auth_Handlers209_Controller5 = auth_Handlers209_Controller5 ?? throw new ArgumentNullException(nameof(auth_Handlers209_Controller5));
            _auth_Handlers209_Event2 = auth_Handlers209_Event2 ?? throw new ArgumentNullException(nameof(auth_Handlers209_Event2));
            _auth_Client271_Controller1 = auth_Client271_Controller1 ?? throw new ArgumentNullException(nameof(auth_Client271_Controller1));
            _auth_Client271_Controller2 = auth_Client271_Controller2 ?? throw new ArgumentNullException(nameof(auth_Client271_Controller2));
            _auth_Client271_Manager = auth_Client271_Manager ?? throw new ArgumentNullException(nameof(auth_Client271_Manager));
        }

        public IAdmin_Processors35_Repository3 GetIAdmin_Processors35_Repository3() => _iAdmin_Processors35_Repository3;
        public Admin_Processors35_Repository5 GetAdmin_Processors35_Repository5() => _admin_Processors35_Repository5;
        public Admin_Models_Factory2 GetAdmin_Models_Factory2() => _admin_Models_Factory2;
        public Auth_Handlers209_Controller5 GetAuth_Handlers209_Controller5() => _auth_Handlers209_Controller5;
        public Auth_Handlers209_Event2 GetAuth_Handlers209_Event2() => _auth_Handlers209_Event2;
        public Auth_Client271_Controller1 GetAuth_Client271_Controller1() => _auth_Client271_Controller1;
        public Auth_Client271_Controller2 GetAuth_Client271_Controller2() => _auth_Client271_Controller2;
        public Auth_Client271_Manager GetAuth_Client271_Manager() => _auth_Client271_Manager;

/// <summary>
/// Validates the Consumer12 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer12(Consumer12Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer12));
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
/// Processes the Consumer12 operation asynchronously.
/// </summary>
public async Task<Consumer12Result> ProcessConsumer12Async(
    Consumer12Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer12), request.Id);

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
            return new Consumer12Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer12));
        return new Consumer12Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer12));
        return new Consumer12Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer12 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer12Dto>> GetConsumer12ListAsync(
    Consumer12Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer12Entity>().AsQueryable();

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
        .Select(x => new Consumer12Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer12Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer12Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer12Service(
    ILogger<Consumer12Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer12:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer12 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer12Data> GetCachedConsumer12Async(string key)
{
    var cacheKey = $"Consumer12_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer12Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer12SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Attr8Id { get; set; }
public string Attr8Name { get; set; }
public string Attr8Description { get; set; }
public DateTime Attr8CreatedAt { get; set; }
public DateTime? Attr8UpdatedAt { get; set; }
public string Attr8CreatedBy { get; set; }
public bool IsAttr8Active { get; set; }
public int Attr8SortOrder { get; set; }


public int Item63Id { get; set; }
public string Item63Name { get; set; }
public string Item63Description { get; set; }
public DateTime Item63CreatedAt { get; set; }
public DateTime? Item63UpdatedAt { get; set; }
public string Item63CreatedBy { get; set; }
public bool IsItem63Active { get; set; }
public int Item63SortOrder { get; set; }


public int Record16Id { get; set; }
public string Record16Name { get; set; }
public string Record16Description { get; set; }
public DateTime Record16CreatedAt { get; set; }
public DateTime? Record16UpdatedAt { get; set; }
public string Record16CreatedBy { get; set; }
public bool IsRecord16Active { get; set; }
public int Record16SortOrder { get; set; }


public int Param47Id { get; set; }
public string Param47Name { get; set; }
public string Param47Description { get; set; }
public DateTime Param47CreatedAt { get; set; }
public DateTime? Param47UpdatedAt { get; set; }
public string Param47CreatedBy { get; set; }
public bool IsParam47Active { get; set; }
public int Param47SortOrder { get; set; }


public int Record3Id { get; set; }
public string Record3Name { get; set; }
public string Record3Description { get; set; }
public DateTime Record3CreatedAt { get; set; }
public DateTime? Record3UpdatedAt { get; set; }
public string Record3CreatedBy { get; set; }
public bool IsRecord3Active { get; set; }
public int Record3SortOrder { get; set; }


public int Record34Id { get; set; }
public string Record34Name { get; set; }
public string Record34Description { get; set; }
public DateTime Record34CreatedAt { get; set; }
public DateTime? Record34UpdatedAt { get; set; }
public string Record34CreatedBy { get; set; }
public bool IsRecord34Active { get; set; }
public int Record34SortOrder { get; set; }


public int Record15Id { get; set; }
public string Record15Name { get; set; }
public string Record15Description { get; set; }
public DateTime Record15CreatedAt { get; set; }
public DateTime? Record15UpdatedAt { get; set; }
public string Record15CreatedBy { get; set; }
public bool IsRecord15Active { get; set; }
public int Record15SortOrder { get; set; }


public int Param88Id { get; set; }
public string Param88Name { get; set; }
public string Param88Description { get; set; }
public DateTime Param88CreatedAt { get; set; }
public DateTime? Param88UpdatedAt { get; set; }
public string Param88CreatedBy { get; set; }
public bool IsParam88Active { get; set; }
public int Param88SortOrder { get; set; }


public int Attr32Id { get; set; }
public string Attr32Name { get; set; }
public string Attr32Description { get; set; }
public DateTime Attr32CreatedAt { get; set; }
public DateTime? Attr32UpdatedAt { get; set; }
public string Attr32CreatedBy { get; set; }
public bool IsAttr32Active { get; set; }
public int Attr32SortOrder { get; set; }


public int Entry35Id { get; set; }
public string Entry35Name { get; set; }
public string Entry35Description { get; set; }
public DateTime Entry35CreatedAt { get; set; }
public DateTime? Entry35UpdatedAt { get; set; }
public string Entry35CreatedBy { get; set; }
public bool IsEntry35Active { get; set; }
public int Entry35SortOrder { get; set; }


public int Item44Id { get; set; }
public string Item44Name { get; set; }
public string Item44Description { get; set; }
public DateTime Item44CreatedAt { get; set; }
public DateTime? Item44UpdatedAt { get; set; }
public string Item44CreatedBy { get; set; }
public bool IsItem44Active { get; set; }
public int Item44SortOrder { get; set; }


public int Detail42Id { get; set; }
public string Detail42Name { get; set; }
public string Detail42Description { get; set; }
public DateTime Detail42CreatedAt { get; set; }
public DateTime? Detail42UpdatedAt { get; set; }
public string Detail42CreatedBy { get; set; }
public bool IsDetail42Active { get; set; }
public int Detail42SortOrder { get; set; }


public int Param28Id { get; set; }
public string Param28Name { get; set; }
public string Param28Description { get; set; }
public DateTime Param28CreatedAt { get; set; }
public DateTime? Param28UpdatedAt { get; set; }
public string Param28CreatedBy { get; set; }
public bool IsParam28Active { get; set; }
public int Param28SortOrder { get; set; }


public int Param3Id { get; set; }
public string Param3Name { get; set; }
public string Param3Description { get; set; }
public DateTime Param3CreatedAt { get; set; }
public DateTime? Param3UpdatedAt { get; set; }
public string Param3CreatedBy { get; set; }
public bool IsParam3Active { get; set; }
public int Param3SortOrder { get; set; }


public int Detail22Id { get; set; }
public string Detail22Name { get; set; }
public string Detail22Description { get; set; }
public DateTime Detail22CreatedAt { get; set; }
public DateTime? Detail22UpdatedAt { get; set; }
public string Detail22CreatedBy { get; set; }
public bool IsDetail22Active { get; set; }
public int Detail22SortOrder { get; set; }


public int Param98Id { get; set; }
public string Param98Name { get; set; }
public string Param98Description { get; set; }
public DateTime Param98CreatedAt { get; set; }
public DateTime? Param98UpdatedAt { get; set; }
public string Param98CreatedBy { get; set; }
public bool IsParam98Active { get; set; }
public int Param98SortOrder { get; set; }


public int Entry97Id { get; set; }
public string Entry97Name { get; set; }
public string Entry97Description { get; set; }
public DateTime Entry97CreatedAt { get; set; }
public DateTime? Entry97UpdatedAt { get; set; }
public string Entry97CreatedBy { get; set; }
public bool IsEntry97Active { get; set; }
public int Entry97SortOrder { get; set; }


public int Param42Id { get; set; }
public string Param42Name { get; set; }
public string Param42Description { get; set; }
public DateTime Param42CreatedAt { get; set; }
public DateTime? Param42UpdatedAt { get; set; }
public string Param42CreatedBy { get; set; }
public bool IsParam42Active { get; set; }
public int Param42SortOrder { get; set; }


public int Attr90Id { get; set; }
public string Attr90Name { get; set; }
public string Attr90Description { get; set; }
public DateTime Attr90CreatedAt { get; set; }
public DateTime? Attr90UpdatedAt { get; set; }
public string Attr90CreatedBy { get; set; }
public bool IsAttr90Active { get; set; }
public int Attr90SortOrder { get; set; }


public int Detail94Id { get; set; }
public string Detail94Name { get; set; }
public string Detail94Description { get; set; }
public DateTime Detail94CreatedAt { get; set; }
public DateTime? Detail94UpdatedAt { get; set; }
public string Detail94CreatedBy { get; set; }
public bool IsDetail94Active { get; set; }
public int Detail94SortOrder { get; set; }


public int Entry97Id { get; set; }
public string Entry97Name { get; set; }
public string Entry97Description { get; set; }
public DateTime Entry97CreatedAt { get; set; }
public DateTime? Entry97UpdatedAt { get; set; }
public string Entry97CreatedBy { get; set; }
public bool IsEntry97Active { get; set; }
public int Entry97SortOrder { get; set; }


public int Record52Id { get; set; }
public string Record52Name { get; set; }
public string Record52Description { get; set; }
public DateTime Record52CreatedAt { get; set; }
public DateTime? Record52UpdatedAt { get; set; }
public string Record52CreatedBy { get; set; }
public bool IsRecord52Active { get; set; }
public int Record52SortOrder { get; set; }


public int Item80Id { get; set; }
public string Item80Name { get; set; }
public string Item80Description { get; set; }
public DateTime Item80CreatedAt { get; set; }
public DateTime? Item80UpdatedAt { get; set; }
public string Item80CreatedBy { get; set; }
public bool IsItem80Active { get; set; }
public int Item80SortOrder { get; set; }


public int Param53Id { get; set; }
public string Param53Name { get; set; }
public string Param53Description { get; set; }
public DateTime Param53CreatedAt { get; set; }
public DateTime? Param53UpdatedAt { get; set; }
public string Param53CreatedBy { get; set; }
public bool IsParam53Active { get; set; }
public int Param53SortOrder { get; set; }


public int Detail3Id { get; set; }
public string Detail3Name { get; set; }
public string Detail3Description { get; set; }
public DateTime Detail3CreatedAt { get; set; }
public DateTime? Detail3UpdatedAt { get; set; }
public string Detail3CreatedBy { get; set; }
public bool IsDetail3Active { get; set; }
public int Detail3SortOrder { get; set; }


public int Record66Id { get; set; }
public string Record66Name { get; set; }
public string Record66Description { get; set; }
public DateTime Record66CreatedAt { get; set; }
public DateTime? Record66UpdatedAt { get; set; }
public string Record66CreatedBy { get; set; }
public bool IsRecord66Active { get; set; }
public int Record66SortOrder { get; set; }


public int Config6Id { get; set; }
public string Config6Name { get; set; }
public string Config6Description { get; set; }
public DateTime Config6CreatedAt { get; set; }
public DateTime? Config6UpdatedAt { get; set; }
public string Config6CreatedBy { get; set; }
public bool IsConfig6Active { get; set; }
public int Config6SortOrder { get; set; }


public int Field77Id { get; set; }
public string Field77Name { get; set; }
public string Field77Description { get; set; }
public DateTime Field77CreatedAt { get; set; }
public DateTime? Field77UpdatedAt { get; set; }
public string Field77CreatedBy { get; set; }
public bool IsField77Active { get; set; }
public int Field77SortOrder { get; set; }


public int Attr77Id { get; set; }
public string Attr77Name { get; set; }
public string Attr77Description { get; set; }
public DateTime Attr77CreatedAt { get; set; }
public DateTime? Attr77UpdatedAt { get; set; }
public string Attr77CreatedBy { get; set; }
public bool IsAttr77Active { get; set; }
public int Attr77SortOrder { get; set; }


public int Config60Id { get; set; }
public string Config60Name { get; set; }
public string Config60Description { get; set; }
public DateTime Config60CreatedAt { get; set; }
public DateTime? Config60UpdatedAt { get; set; }
public string Config60CreatedBy { get; set; }
public bool IsConfig60Active { get; set; }
public int Config60SortOrder { get; set; }


public int Param85Id { get; set; }
public string Param85Name { get; set; }
public string Param85Description { get; set; }
public DateTime Param85CreatedAt { get; set; }
public DateTime? Param85UpdatedAt { get; set; }
public string Param85CreatedBy { get; set; }
public bool IsParam85Active { get; set; }
public int Param85SortOrder { get; set; }


public int Entry37Id { get; set; }
public string Entry37Name { get; set; }
public string Entry37Description { get; set; }
public DateTime Entry37CreatedAt { get; set; }
public DateTime? Entry37UpdatedAt { get; set; }
public string Entry37CreatedBy { get; set; }
public bool IsEntry37Active { get; set; }
public int Entry37SortOrder { get; set; }


public int Entry67Id { get; set; }
public string Entry67Name { get; set; }
public string Entry67Description { get; set; }
public DateTime Entry67CreatedAt { get; set; }
public DateTime? Entry67UpdatedAt { get; set; }
public string Entry67CreatedBy { get; set; }
public bool IsEntry67Active { get; set; }
public int Entry67SortOrder { get; set; }


public int Param24Id { get; set; }
public string Param24Name { get; set; }
public string Param24Description { get; set; }
public DateTime Param24CreatedAt { get; set; }
public DateTime? Param24UpdatedAt { get; set; }
public string Param24CreatedBy { get; set; }
public bool IsParam24Active { get; set; }
public int Param24SortOrder { get; set; }


public int Entry64Id { get; set; }
public string Entry64Name { get; set; }
public string Entry64Description { get; set; }
public DateTime Entry64CreatedAt { get; set; }
public DateTime? Entry64UpdatedAt { get; set; }
public string Entry64CreatedBy { get; set; }
public bool IsEntry64Active { get; set; }
public int Entry64SortOrder { get; set; }


public int Detail46Id { get; set; }
public string Detail46Name { get; set; }
public string Detail46Description { get; set; }
public DateTime Detail46CreatedAt { get; set; }
public DateTime? Detail46UpdatedAt { get; set; }
public string Detail46CreatedBy { get; set; }
public bool IsDetail46Active { get; set; }
public int Detail46SortOrder { get; set; }


public int Record35Id { get; set; }
public string Record35Name { get; set; }
public string Record35Description { get; set; }
public DateTime Record35CreatedAt { get; set; }
public DateTime? Record35UpdatedAt { get; set; }
public string Record35CreatedBy { get; set; }
public bool IsRecord35Active { get; set; }
public int Record35SortOrder { get; set; }


public int Item79Id { get; set; }
public string Item79Name { get; set; }
public string Item79Description { get; set; }
public DateTime Item79CreatedAt { get; set; }
public DateTime? Item79UpdatedAt { get; set; }
public string Item79CreatedBy { get; set; }
public bool IsItem79Active { get; set; }
public int Item79SortOrder { get; set; }


public int Field66Id { get; set; }
public string Field66Name { get; set; }
public string Field66Description { get; set; }
public DateTime Field66CreatedAt { get; set; }
public DateTime? Field66UpdatedAt { get; set; }
public string Field66CreatedBy { get; set; }
public bool IsField66Active { get; set; }
public int Field66SortOrder { get; set; }


public int Param68Id { get; set; }
public string Param68Name { get; set; }
public string Param68Description { get; set; }
public DateTime Param68CreatedAt { get; set; }
public DateTime? Param68UpdatedAt { get; set; }
public string Param68CreatedBy { get; set; }
public bool IsParam68Active { get; set; }
public int Param68SortOrder { get; set; }


public int Detail18Id { get; set; }
public string Detail18Name { get; set; }
public string Detail18Description { get; set; }
public DateTime Detail18CreatedAt { get; set; }
public DateTime? Detail18UpdatedAt { get; set; }
public string Detail18CreatedBy { get; set; }
public bool IsDetail18Active { get; set; }
public int Detail18SortOrder { get; set; }


public int Attr92Id { get; set; }
public string Attr92Name { get; set; }
public string Attr92Description { get; set; }
public DateTime Attr92CreatedAt { get; set; }
public DateTime? Attr92UpdatedAt { get; set; }
public string Attr92CreatedBy { get; set; }
public bool IsAttr92Active { get; set; }
public int Attr92SortOrder { get; set; }


public int Record1Id { get; set; }
public string Record1Name { get; set; }
public string Record1Description { get; set; }
public DateTime Record1CreatedAt { get; set; }
public DateTime? Record1UpdatedAt { get; set; }
public string Record1CreatedBy { get; set; }
public bool IsRecord1Active { get; set; }
public int Record1SortOrder { get; set; }


public int Detail7Id { get; set; }
public string Detail7Name { get; set; }
public string Detail7Description { get; set; }
public DateTime Detail7CreatedAt { get; set; }
public DateTime? Detail7UpdatedAt { get; set; }
public string Detail7CreatedBy { get; set; }
public bool IsDetail7Active { get; set; }
public int Detail7SortOrder { get; set; }


public int Detail81Id { get; set; }
public string Detail81Name { get; set; }
public string Detail81Description { get; set; }
public DateTime Detail81CreatedAt { get; set; }
public DateTime? Detail81UpdatedAt { get; set; }
public string Detail81CreatedBy { get; set; }
public bool IsDetail81Active { get; set; }
public int Detail81SortOrder { get; set; }

    }
}