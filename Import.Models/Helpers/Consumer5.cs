using Admin.Data117;
using Admin.Handlers;
using Admin.Validators;
using Auth.Core2;
using Auth.Events5;
using BatchJobs.Processors410;
using Common.Api57;
using DataAccess.Contracts203;
using Export.Processors449;
using Imaging.Client;
using Import.Events493;
using Logging.Validators;
using Notifications.Data;
using Portal.Processors389;
using Portal.Validators227;
using Scheduling.Models260;
using Scheduling.Web60;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Import.Models
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer5
    {
        private readonly Auth_Core2_Response4 _auth_Core2_Response4;
        private readonly Admin_Data117_Command6 _admin_Data117_Command6;
        private readonly IAdmin_Data117_Provider4 _iAdmin_Data117_Provider4;
        private readonly IAdmin_Data117_Factory8 _iAdmin_Data117_Factory8;
        private readonly Scheduling_Web60_Helper4 _scheduling_Web60_Helper4;
        private readonly Scheduling_Web60_Range2 _scheduling_Web60_Range2;
        private readonly Common_Api57_Helper _common_Api57_Helper;
        private readonly Portal_Validators227_Request3 _portal_Validators227_Request3;

        public Consumer5(Auth_Core2_Response4 auth_Core2_Response4, Admin_Data117_Command6 admin_Data117_Command6, IAdmin_Data117_Provider4 iAdmin_Data117_Provider4, IAdmin_Data117_Factory8 iAdmin_Data117_Factory8, Scheduling_Web60_Helper4 scheduling_Web60_Helper4, Scheduling_Web60_Range2 scheduling_Web60_Range2, Common_Api57_Helper common_Api57_Helper, Portal_Validators227_Request3 portal_Validators227_Request3)
        {
            _auth_Core2_Response4 = auth_Core2_Response4 ?? throw new ArgumentNullException(nameof(auth_Core2_Response4));
            _admin_Data117_Command6 = admin_Data117_Command6 ?? throw new ArgumentNullException(nameof(admin_Data117_Command6));
            _iAdmin_Data117_Provider4 = iAdmin_Data117_Provider4 ?? throw new ArgumentNullException(nameof(iAdmin_Data117_Provider4));
            _iAdmin_Data117_Factory8 = iAdmin_Data117_Factory8 ?? throw new ArgumentNullException(nameof(iAdmin_Data117_Factory8));
            _scheduling_Web60_Helper4 = scheduling_Web60_Helper4 ?? throw new ArgumentNullException(nameof(scheduling_Web60_Helper4));
            _scheduling_Web60_Range2 = scheduling_Web60_Range2 ?? throw new ArgumentNullException(nameof(scheduling_Web60_Range2));
            _common_Api57_Helper = common_Api57_Helper ?? throw new ArgumentNullException(nameof(common_Api57_Helper));
            _portal_Validators227_Request3 = portal_Validators227_Request3 ?? throw new ArgumentNullException(nameof(portal_Validators227_Request3));
        }

        public Auth_Core2_Response4 GetAuth_Core2_Response4() => _auth_Core2_Response4;
        public Admin_Data117_Command6 GetAdmin_Data117_Command6() => _admin_Data117_Command6;
        public IAdmin_Data117_Provider4 GetIAdmin_Data117_Provider4() => _iAdmin_Data117_Provider4;
        public IAdmin_Data117_Factory8 GetIAdmin_Data117_Factory8() => _iAdmin_Data117_Factory8;
        public Scheduling_Web60_Helper4 GetScheduling_Web60_Helper4() => _scheduling_Web60_Helper4;
        public Scheduling_Web60_Range2 GetScheduling_Web60_Range2() => _scheduling_Web60_Range2;
        public Common_Api57_Helper GetCommon_Api57_Helper() => _common_Api57_Helper;
        public Portal_Validators227_Request3 GetPortal_Validators227_Request3() => _portal_Validators227_Request3;

/// <summary>
/// Validates the Consumer5 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer5(Consumer5Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer5));
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
/// Processes the Consumer5 operation asynchronously.
/// </summary>
public async Task<Consumer5Result> ProcessConsumer5Async(
    Consumer5Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer5), request.Id);

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
            return new Consumer5Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer5));
        return new Consumer5Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer5));
        return new Consumer5Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer5 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer5Dto>> GetConsumer5ListAsync(
    Consumer5Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer5Entity>().AsQueryable();

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
        .Select(x => new Consumer5Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer5Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer5Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer5Service(
    ILogger<Consumer5Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer5:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer5 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer5Data> GetCachedConsumer5Async(string key)
{
    var cacheKey = $"Consumer5_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer5Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer5SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Config20Id { get; set; }
public string Config20Name { get; set; }
public string Config20Description { get; set; }
public DateTime Config20CreatedAt { get; set; }
public DateTime? Config20UpdatedAt { get; set; }
public string Config20CreatedBy { get; set; }
public bool IsConfig20Active { get; set; }
public int Config20SortOrder { get; set; }


public int Attr26Id { get; set; }
public string Attr26Name { get; set; }
public string Attr26Description { get; set; }
public DateTime Attr26CreatedAt { get; set; }
public DateTime? Attr26UpdatedAt { get; set; }
public string Attr26CreatedBy { get; set; }
public bool IsAttr26Active { get; set; }
public int Attr26SortOrder { get; set; }


public int Param65Id { get; set; }
public string Param65Name { get; set; }
public string Param65Description { get; set; }
public DateTime Param65CreatedAt { get; set; }
public DateTime? Param65UpdatedAt { get; set; }
public string Param65CreatedBy { get; set; }
public bool IsParam65Active { get; set; }
public int Param65SortOrder { get; set; }


public int Field19Id { get; set; }
public string Field19Name { get; set; }
public string Field19Description { get; set; }
public DateTime Field19CreatedAt { get; set; }
public DateTime? Field19UpdatedAt { get; set; }
public string Field19CreatedBy { get; set; }
public bool IsField19Active { get; set; }
public int Field19SortOrder { get; set; }


public int Record31Id { get; set; }
public string Record31Name { get; set; }
public string Record31Description { get; set; }
public DateTime Record31CreatedAt { get; set; }
public DateTime? Record31UpdatedAt { get; set; }
public string Record31CreatedBy { get; set; }
public bool IsRecord31Active { get; set; }
public int Record31SortOrder { get; set; }


public int Item99Id { get; set; }
public string Item99Name { get; set; }
public string Item99Description { get; set; }
public DateTime Item99CreatedAt { get; set; }
public DateTime? Item99UpdatedAt { get; set; }
public string Item99CreatedBy { get; set; }
public bool IsItem99Active { get; set; }
public int Item99SortOrder { get; set; }


public int Detail80Id { get; set; }
public string Detail80Name { get; set; }
public string Detail80Description { get; set; }
public DateTime Detail80CreatedAt { get; set; }
public DateTime? Detail80UpdatedAt { get; set; }
public string Detail80CreatedBy { get; set; }
public bool IsDetail80Active { get; set; }
public int Detail80SortOrder { get; set; }


public int Detail54Id { get; set; }
public string Detail54Name { get; set; }
public string Detail54Description { get; set; }
public DateTime Detail54CreatedAt { get; set; }
public DateTime? Detail54UpdatedAt { get; set; }
public string Detail54CreatedBy { get; set; }
public bool IsDetail54Active { get; set; }
public int Detail54SortOrder { get; set; }


public int Item2Id { get; set; }
public string Item2Name { get; set; }
public string Item2Description { get; set; }
public DateTime Item2CreatedAt { get; set; }
public DateTime? Item2UpdatedAt { get; set; }
public string Item2CreatedBy { get; set; }
public bool IsItem2Active { get; set; }
public int Item2SortOrder { get; set; }


public int Param86Id { get; set; }
public string Param86Name { get; set; }
public string Param86Description { get; set; }
public DateTime Param86CreatedAt { get; set; }
public DateTime? Param86UpdatedAt { get; set; }
public string Param86CreatedBy { get; set; }
public bool IsParam86Active { get; set; }
public int Param86SortOrder { get; set; }


public int Item96Id { get; set; }
public string Item96Name { get; set; }
public string Item96Description { get; set; }
public DateTime Item96CreatedAt { get; set; }
public DateTime? Item96UpdatedAt { get; set; }
public string Item96CreatedBy { get; set; }
public bool IsItem96Active { get; set; }
public int Item96SortOrder { get; set; }


public int Entry74Id { get; set; }
public string Entry74Name { get; set; }
public string Entry74Description { get; set; }
public DateTime Entry74CreatedAt { get; set; }
public DateTime? Entry74UpdatedAt { get; set; }
public string Entry74CreatedBy { get; set; }
public bool IsEntry74Active { get; set; }
public int Entry74SortOrder { get; set; }


public int Item12Id { get; set; }
public string Item12Name { get; set; }
public string Item12Description { get; set; }
public DateTime Item12CreatedAt { get; set; }
public DateTime? Item12UpdatedAt { get; set; }
public string Item12CreatedBy { get; set; }
public bool IsItem12Active { get; set; }
public int Item12SortOrder { get; set; }


public int Detail78Id { get; set; }
public string Detail78Name { get; set; }
public string Detail78Description { get; set; }
public DateTime Detail78CreatedAt { get; set; }
public DateTime? Detail78UpdatedAt { get; set; }
public string Detail78CreatedBy { get; set; }
public bool IsDetail78Active { get; set; }
public int Detail78SortOrder { get; set; }


public int Item56Id { get; set; }
public string Item56Name { get; set; }
public string Item56Description { get; set; }
public DateTime Item56CreatedAt { get; set; }
public DateTime? Item56UpdatedAt { get; set; }
public string Item56CreatedBy { get; set; }
public bool IsItem56Active { get; set; }
public int Item56SortOrder { get; set; }


public int Field50Id { get; set; }
public string Field50Name { get; set; }
public string Field50Description { get; set; }
public DateTime Field50CreatedAt { get; set; }
public DateTime? Field50UpdatedAt { get; set; }
public string Field50CreatedBy { get; set; }
public bool IsField50Active { get; set; }
public int Field50SortOrder { get; set; }


public int Attr38Id { get; set; }
public string Attr38Name { get; set; }
public string Attr38Description { get; set; }
public DateTime Attr38CreatedAt { get; set; }
public DateTime? Attr38UpdatedAt { get; set; }
public string Attr38CreatedBy { get; set; }
public bool IsAttr38Active { get; set; }
public int Attr38SortOrder { get; set; }


public int Record93Id { get; set; }
public string Record93Name { get; set; }
public string Record93Description { get; set; }
public DateTime Record93CreatedAt { get; set; }
public DateTime? Record93UpdatedAt { get; set; }
public string Record93CreatedBy { get; set; }
public bool IsRecord93Active { get; set; }
public int Record93SortOrder { get; set; }


public int Detail86Id { get; set; }
public string Detail86Name { get; set; }
public string Detail86Description { get; set; }
public DateTime Detail86CreatedAt { get; set; }
public DateTime? Detail86UpdatedAt { get; set; }
public string Detail86CreatedBy { get; set; }
public bool IsDetail86Active { get; set; }
public int Detail86SortOrder { get; set; }


public int Param83Id { get; set; }
public string Param83Name { get; set; }
public string Param83Description { get; set; }
public DateTime Param83CreatedAt { get; set; }
public DateTime? Param83UpdatedAt { get; set; }
public string Param83CreatedBy { get; set; }
public bool IsParam83Active { get; set; }
public int Param83SortOrder { get; set; }


public int Entry50Id { get; set; }
public string Entry50Name { get; set; }
public string Entry50Description { get; set; }
public DateTime Entry50CreatedAt { get; set; }
public DateTime? Entry50UpdatedAt { get; set; }
public string Entry50CreatedBy { get; set; }
public bool IsEntry50Active { get; set; }
public int Entry50SortOrder { get; set; }


public int Attr21Id { get; set; }
public string Attr21Name { get; set; }
public string Attr21Description { get; set; }
public DateTime Attr21CreatedAt { get; set; }
public DateTime? Attr21UpdatedAt { get; set; }
public string Attr21CreatedBy { get; set; }
public bool IsAttr21Active { get; set; }
public int Attr21SortOrder { get; set; }


public int Record86Id { get; set; }
public string Record86Name { get; set; }
public string Record86Description { get; set; }
public DateTime Record86CreatedAt { get; set; }
public DateTime? Record86UpdatedAt { get; set; }
public string Record86CreatedBy { get; set; }
public bool IsRecord86Active { get; set; }
public int Record86SortOrder { get; set; }


public int Record33Id { get; set; }
public string Record33Name { get; set; }
public string Record33Description { get; set; }
public DateTime Record33CreatedAt { get; set; }
public DateTime? Record33UpdatedAt { get; set; }
public string Record33CreatedBy { get; set; }
public bool IsRecord33Active { get; set; }
public int Record33SortOrder { get; set; }


public int Record95Id { get; set; }
public string Record95Name { get; set; }
public string Record95Description { get; set; }
public DateTime Record95CreatedAt { get; set; }
public DateTime? Record95UpdatedAt { get; set; }
public string Record95CreatedBy { get; set; }
public bool IsRecord95Active { get; set; }
public int Record95SortOrder { get; set; }


public int Detail67Id { get; set; }
public string Detail67Name { get; set; }
public string Detail67Description { get; set; }
public DateTime Detail67CreatedAt { get; set; }
public DateTime? Detail67UpdatedAt { get; set; }
public string Detail67CreatedBy { get; set; }
public bool IsDetail67Active { get; set; }
public int Detail67SortOrder { get; set; }


public int Param52Id { get; set; }
public string Param52Name { get; set; }
public string Param52Description { get; set; }
public DateTime Param52CreatedAt { get; set; }
public DateTime? Param52UpdatedAt { get; set; }
public string Param52CreatedBy { get; set; }
public bool IsParam52Active { get; set; }
public int Param52SortOrder { get; set; }


public int Attr4Id { get; set; }
public string Attr4Name { get; set; }
public string Attr4Description { get; set; }
public DateTime Attr4CreatedAt { get; set; }
public DateTime? Attr4UpdatedAt { get; set; }
public string Attr4CreatedBy { get; set; }
public bool IsAttr4Active { get; set; }
public int Attr4SortOrder { get; set; }


public int Param6Id { get; set; }
public string Param6Name { get; set; }
public string Param6Description { get; set; }
public DateTime Param6CreatedAt { get; set; }
public DateTime? Param6UpdatedAt { get; set; }
public string Param6CreatedBy { get; set; }
public bool IsParam6Active { get; set; }
public int Param6SortOrder { get; set; }


public int Entry69Id { get; set; }
public string Entry69Name { get; set; }
public string Entry69Description { get; set; }
public DateTime Entry69CreatedAt { get; set; }
public DateTime? Entry69UpdatedAt { get; set; }
public string Entry69CreatedBy { get; set; }
public bool IsEntry69Active { get; set; }
public int Entry69SortOrder { get; set; }


public int Detail44Id { get; set; }
public string Detail44Name { get; set; }
public string Detail44Description { get; set; }
public DateTime Detail44CreatedAt { get; set; }
public DateTime? Detail44UpdatedAt { get; set; }
public string Detail44CreatedBy { get; set; }
public bool IsDetail44Active { get; set; }
public int Detail44SortOrder { get; set; }


public int Entry56Id { get; set; }
public string Entry56Name { get; set; }
public string Entry56Description { get; set; }
public DateTime Entry56CreatedAt { get; set; }
public DateTime? Entry56UpdatedAt { get; set; }
public string Entry56CreatedBy { get; set; }
public bool IsEntry56Active { get; set; }
public int Entry56SortOrder { get; set; }


public int Field97Id { get; set; }
public string Field97Name { get; set; }
public string Field97Description { get; set; }
public DateTime Field97CreatedAt { get; set; }
public DateTime? Field97UpdatedAt { get; set; }
public string Field97CreatedBy { get; set; }
public bool IsField97Active { get; set; }
public int Field97SortOrder { get; set; }


public int Attr22Id { get; set; }
public string Attr22Name { get; set; }
public string Attr22Description { get; set; }
public DateTime Attr22CreatedAt { get; set; }
public DateTime? Attr22UpdatedAt { get; set; }
public string Attr22CreatedBy { get; set; }
public bool IsAttr22Active { get; set; }
public int Attr22SortOrder { get; set; }


public int Field38Id { get; set; }
public string Field38Name { get; set; }
public string Field38Description { get; set; }
public DateTime Field38CreatedAt { get; set; }
public DateTime? Field38UpdatedAt { get; set; }
public string Field38CreatedBy { get; set; }
public bool IsField38Active { get; set; }
public int Field38SortOrder { get; set; }


public int Entry97Id { get; set; }
public string Entry97Name { get; set; }
public string Entry97Description { get; set; }
public DateTime Entry97CreatedAt { get; set; }
public DateTime? Entry97UpdatedAt { get; set; }
public string Entry97CreatedBy { get; set; }
public bool IsEntry97Active { get; set; }
public int Entry97SortOrder { get; set; }


public int Config44Id { get; set; }
public string Config44Name { get; set; }
public string Config44Description { get; set; }
public DateTime Config44CreatedAt { get; set; }
public DateTime? Config44UpdatedAt { get; set; }
public string Config44CreatedBy { get; set; }
public bool IsConfig44Active { get; set; }
public int Config44SortOrder { get; set; }


public int Item62Id { get; set; }
public string Item62Name { get; set; }
public string Item62Description { get; set; }
public DateTime Item62CreatedAt { get; set; }
public DateTime? Item62UpdatedAt { get; set; }
public string Item62CreatedBy { get; set; }
public bool IsItem62Active { get; set; }
public int Item62SortOrder { get; set; }


public int Entry26Id { get; set; }
public string Entry26Name { get; set; }
public string Entry26Description { get; set; }
public DateTime Entry26CreatedAt { get; set; }
public DateTime? Entry26UpdatedAt { get; set; }
public string Entry26CreatedBy { get; set; }
public bool IsEntry26Active { get; set; }
public int Entry26SortOrder { get; set; }


public int Entry77Id { get; set; }
public string Entry77Name { get; set; }
public string Entry77Description { get; set; }
public DateTime Entry77CreatedAt { get; set; }
public DateTime? Entry77UpdatedAt { get; set; }
public string Entry77CreatedBy { get; set; }
public bool IsEntry77Active { get; set; }
public int Entry77SortOrder { get; set; }


public int Entry85Id { get; set; }
public string Entry85Name { get; set; }
public string Entry85Description { get; set; }
public DateTime Entry85CreatedAt { get; set; }
public DateTime? Entry85UpdatedAt { get; set; }
public string Entry85CreatedBy { get; set; }
public bool IsEntry85Active { get; set; }
public int Entry85SortOrder { get; set; }


public int Item48Id { get; set; }
public string Item48Name { get; set; }
public string Item48Description { get; set; }
public DateTime Item48CreatedAt { get; set; }
public DateTime? Item48UpdatedAt { get; set; }
public string Item48CreatedBy { get; set; }
public bool IsItem48Active { get; set; }
public int Item48SortOrder { get; set; }


public int Record10Id { get; set; }
public string Record10Name { get; set; }
public string Record10Description { get; set; }
public DateTime Record10CreatedAt { get; set; }
public DateTime? Record10UpdatedAt { get; set; }
public string Record10CreatedBy { get; set; }
public bool IsRecord10Active { get; set; }
public int Record10SortOrder { get; set; }


public int Item5Id { get; set; }
public string Item5Name { get; set; }
public string Item5Description { get; set; }
public DateTime Item5CreatedAt { get; set; }
public DateTime? Item5UpdatedAt { get; set; }
public string Item5CreatedBy { get; set; }
public bool IsItem5Active { get; set; }
public int Item5SortOrder { get; set; }


public int Attr49Id { get; set; }
public string Attr49Name { get; set; }
public string Attr49Description { get; set; }
public DateTime Attr49CreatedAt { get; set; }
public DateTime? Attr49UpdatedAt { get; set; }
public string Attr49CreatedBy { get; set; }
public bool IsAttr49Active { get; set; }
public int Attr49SortOrder { get; set; }


public int Param27Id { get; set; }
public string Param27Name { get; set; }
public string Param27Description { get; set; }
public DateTime Param27CreatedAt { get; set; }
public DateTime? Param27UpdatedAt { get; set; }
public string Param27CreatedBy { get; set; }
public bool IsParam27Active { get; set; }
public int Param27SortOrder { get; set; }

    }
}