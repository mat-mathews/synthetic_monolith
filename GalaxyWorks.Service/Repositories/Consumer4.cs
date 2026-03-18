using Admin.Events306;
using Admin.Validators;
using Admin.Web4;
using DataAccess.Api307;
using DataAccess.Client;
using DataAccess.Validators88;
using Documents.Service471;
using Export.Events163;
using Export.Processors111;
using GalaxyWorks.Data263;
using Integration.Service401;
using Logging.Mappers157;
using Notifications.Data;
using Portal.Service489;
using Portal.Validators69;
using Reporting.Models;
using Security.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyWorks.Service
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer4
    {
        private readonly Admin_Events306_Event4 _admin_Events306_Event4;
        private readonly IAdmin_Events306_Provider3 _iAdmin_Events306_Provider3;
        private readonly IAdmin_Events306_Factory _iAdmin_Events306_Factory;
        private readonly Admin_Web4_Provider1 _admin_Web4_Provider1;
        private readonly Portal_Validators69_Processor _portal_Validators69_Processor;
        private readonly Portal_Validators69_Handler5 _portal_Validators69_Handler5;
        private readonly Security_Validators_Provider5 _security_Validators_Provider5;
        private readonly Portal_Service489_Builder1 _portal_Service489_Builder1;

        public Consumer4(Admin_Events306_Event4 admin_Events306_Event4, IAdmin_Events306_Provider3 iAdmin_Events306_Provider3, IAdmin_Events306_Factory iAdmin_Events306_Factory, Admin_Web4_Provider1 admin_Web4_Provider1, Portal_Validators69_Processor portal_Validators69_Processor, Portal_Validators69_Handler5 portal_Validators69_Handler5, Security_Validators_Provider5 security_Validators_Provider5, Portal_Service489_Builder1 portal_Service489_Builder1)
        {
            _admin_Events306_Event4 = admin_Events306_Event4 ?? throw new ArgumentNullException(nameof(admin_Events306_Event4));
            _iAdmin_Events306_Provider3 = iAdmin_Events306_Provider3 ?? throw new ArgumentNullException(nameof(iAdmin_Events306_Provider3));
            _iAdmin_Events306_Factory = iAdmin_Events306_Factory ?? throw new ArgumentNullException(nameof(iAdmin_Events306_Factory));
            _admin_Web4_Provider1 = admin_Web4_Provider1 ?? throw new ArgumentNullException(nameof(admin_Web4_Provider1));
            _portal_Validators69_Processor = portal_Validators69_Processor ?? throw new ArgumentNullException(nameof(portal_Validators69_Processor));
            _portal_Validators69_Handler5 = portal_Validators69_Handler5 ?? throw new ArgumentNullException(nameof(portal_Validators69_Handler5));
            _security_Validators_Provider5 = security_Validators_Provider5 ?? throw new ArgumentNullException(nameof(security_Validators_Provider5));
            _portal_Service489_Builder1 = portal_Service489_Builder1 ?? throw new ArgumentNullException(nameof(portal_Service489_Builder1));
        }

        public Admin_Events306_Event4 GetAdmin_Events306_Event4() => _admin_Events306_Event4;
        public IAdmin_Events306_Provider3 GetIAdmin_Events306_Provider3() => _iAdmin_Events306_Provider3;
        public IAdmin_Events306_Factory GetIAdmin_Events306_Factory() => _iAdmin_Events306_Factory;
        public Admin_Web4_Provider1 GetAdmin_Web4_Provider1() => _admin_Web4_Provider1;
        public Portal_Validators69_Processor GetPortal_Validators69_Processor() => _portal_Validators69_Processor;
        public Portal_Validators69_Handler5 GetPortal_Validators69_Handler5() => _portal_Validators69_Handler5;
        public Security_Validators_Provider5 GetSecurity_Validators_Provider5() => _security_Validators_Provider5;
        public Portal_Service489_Builder1 GetPortal_Service489_Builder1() => _portal_Service489_Builder1;

/// <summary>
/// Validates the Consumer4 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer4(Consumer4Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer4));
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
/// Processes the Consumer4 operation asynchronously.
/// </summary>
public async Task<Consumer4Result> ProcessConsumer4Async(
    Consumer4Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer4), request.Id);

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
            return new Consumer4Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer4));
        return new Consumer4Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer4));
        return new Consumer4Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer4 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer4Dto>> GetConsumer4ListAsync(
    Consumer4Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer4Entity>().AsQueryable();

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
        .Select(x => new Consumer4Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer4Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer4Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer4Service(
    ILogger<Consumer4Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer4:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer4 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer4Data> GetCachedConsumer4Async(string key)
{
    var cacheKey = $"Consumer4_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer4Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer4SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Param39Id { get; set; }
public string Param39Name { get; set; }
public string Param39Description { get; set; }
public DateTime Param39CreatedAt { get; set; }
public DateTime? Param39UpdatedAt { get; set; }
public string Param39CreatedBy { get; set; }
public bool IsParam39Active { get; set; }
public int Param39SortOrder { get; set; }


public int Config82Id { get; set; }
public string Config82Name { get; set; }
public string Config82Description { get; set; }
public DateTime Config82CreatedAt { get; set; }
public DateTime? Config82UpdatedAt { get; set; }
public string Config82CreatedBy { get; set; }
public bool IsConfig82Active { get; set; }
public int Config82SortOrder { get; set; }


public int Entry48Id { get; set; }
public string Entry48Name { get; set; }
public string Entry48Description { get; set; }
public DateTime Entry48CreatedAt { get; set; }
public DateTime? Entry48UpdatedAt { get; set; }
public string Entry48CreatedBy { get; set; }
public bool IsEntry48Active { get; set; }
public int Entry48SortOrder { get; set; }


public int Param94Id { get; set; }
public string Param94Name { get; set; }
public string Param94Description { get; set; }
public DateTime Param94CreatedAt { get; set; }
public DateTime? Param94UpdatedAt { get; set; }
public string Param94CreatedBy { get; set; }
public bool IsParam94Active { get; set; }
public int Param94SortOrder { get; set; }


public int Entry88Id { get; set; }
public string Entry88Name { get; set; }
public string Entry88Description { get; set; }
public DateTime Entry88CreatedAt { get; set; }
public DateTime? Entry88UpdatedAt { get; set; }
public string Entry88CreatedBy { get; set; }
public bool IsEntry88Active { get; set; }
public int Entry88SortOrder { get; set; }


public int Item92Id { get; set; }
public string Item92Name { get; set; }
public string Item92Description { get; set; }
public DateTime Item92CreatedAt { get; set; }
public DateTime? Item92UpdatedAt { get; set; }
public string Item92CreatedBy { get; set; }
public bool IsItem92Active { get; set; }
public int Item92SortOrder { get; set; }


public int Detail90Id { get; set; }
public string Detail90Name { get; set; }
public string Detail90Description { get; set; }
public DateTime Detail90CreatedAt { get; set; }
public DateTime? Detail90UpdatedAt { get; set; }
public string Detail90CreatedBy { get; set; }
public bool IsDetail90Active { get; set; }
public int Detail90SortOrder { get; set; }


public int Config64Id { get; set; }
public string Config64Name { get; set; }
public string Config64Description { get; set; }
public DateTime Config64CreatedAt { get; set; }
public DateTime? Config64UpdatedAt { get; set; }
public string Config64CreatedBy { get; set; }
public bool IsConfig64Active { get; set; }
public int Config64SortOrder { get; set; }


public int Detail8Id { get; set; }
public string Detail8Name { get; set; }
public string Detail8Description { get; set; }
public DateTime Detail8CreatedAt { get; set; }
public DateTime? Detail8UpdatedAt { get; set; }
public string Detail8CreatedBy { get; set; }
public bool IsDetail8Active { get; set; }
public int Detail8SortOrder { get; set; }


public int Item21Id { get; set; }
public string Item21Name { get; set; }
public string Item21Description { get; set; }
public DateTime Item21CreatedAt { get; set; }
public DateTime? Item21UpdatedAt { get; set; }
public string Item21CreatedBy { get; set; }
public bool IsItem21Active { get; set; }
public int Item21SortOrder { get; set; }


public int Record27Id { get; set; }
public string Record27Name { get; set; }
public string Record27Description { get; set; }
public DateTime Record27CreatedAt { get; set; }
public DateTime? Record27UpdatedAt { get; set; }
public string Record27CreatedBy { get; set; }
public bool IsRecord27Active { get; set; }
public int Record27SortOrder { get; set; }


public int Attr9Id { get; set; }
public string Attr9Name { get; set; }
public string Attr9Description { get; set; }
public DateTime Attr9CreatedAt { get; set; }
public DateTime? Attr9UpdatedAt { get; set; }
public string Attr9CreatedBy { get; set; }
public bool IsAttr9Active { get; set; }
public int Attr9SortOrder { get; set; }


public int Attr76Id { get; set; }
public string Attr76Name { get; set; }
public string Attr76Description { get; set; }
public DateTime Attr76CreatedAt { get; set; }
public DateTime? Attr76UpdatedAt { get; set; }
public string Attr76CreatedBy { get; set; }
public bool IsAttr76Active { get; set; }
public int Attr76SortOrder { get; set; }


public int Detail70Id { get; set; }
public string Detail70Name { get; set; }
public string Detail70Description { get; set; }
public DateTime Detail70CreatedAt { get; set; }
public DateTime? Detail70UpdatedAt { get; set; }
public string Detail70CreatedBy { get; set; }
public bool IsDetail70Active { get; set; }
public int Detail70SortOrder { get; set; }


public int Config70Id { get; set; }
public string Config70Name { get; set; }
public string Config70Description { get; set; }
public DateTime Config70CreatedAt { get; set; }
public DateTime? Config70UpdatedAt { get; set; }
public string Config70CreatedBy { get; set; }
public bool IsConfig70Active { get; set; }
public int Config70SortOrder { get; set; }


public int Attr99Id { get; set; }
public string Attr99Name { get; set; }
public string Attr99Description { get; set; }
public DateTime Attr99CreatedAt { get; set; }
public DateTime? Attr99UpdatedAt { get; set; }
public string Attr99CreatedBy { get; set; }
public bool IsAttr99Active { get; set; }
public int Attr99SortOrder { get; set; }


public int Config97Id { get; set; }
public string Config97Name { get; set; }
public string Config97Description { get; set; }
public DateTime Config97CreatedAt { get; set; }
public DateTime? Config97UpdatedAt { get; set; }
public string Config97CreatedBy { get; set; }
public bool IsConfig97Active { get; set; }
public int Config97SortOrder { get; set; }


public int Detail70Id { get; set; }
public string Detail70Name { get; set; }
public string Detail70Description { get; set; }
public DateTime Detail70CreatedAt { get; set; }
public DateTime? Detail70UpdatedAt { get; set; }
public string Detail70CreatedBy { get; set; }
public bool IsDetail70Active { get; set; }
public int Detail70SortOrder { get; set; }


public int Attr38Id { get; set; }
public string Attr38Name { get; set; }
public string Attr38Description { get; set; }
public DateTime Attr38CreatedAt { get; set; }
public DateTime? Attr38UpdatedAt { get; set; }
public string Attr38CreatedBy { get; set; }
public bool IsAttr38Active { get; set; }
public int Attr38SortOrder { get; set; }


public int Attr73Id { get; set; }
public string Attr73Name { get; set; }
public string Attr73Description { get; set; }
public DateTime Attr73CreatedAt { get; set; }
public DateTime? Attr73UpdatedAt { get; set; }
public string Attr73CreatedBy { get; set; }
public bool IsAttr73Active { get; set; }
public int Attr73SortOrder { get; set; }


public int Attr67Id { get; set; }
public string Attr67Name { get; set; }
public string Attr67Description { get; set; }
public DateTime Attr67CreatedAt { get; set; }
public DateTime? Attr67UpdatedAt { get; set; }
public string Attr67CreatedBy { get; set; }
public bool IsAttr67Active { get; set; }
public int Attr67SortOrder { get; set; }


public int Detail83Id { get; set; }
public string Detail83Name { get; set; }
public string Detail83Description { get; set; }
public DateTime Detail83CreatedAt { get; set; }
public DateTime? Detail83UpdatedAt { get; set; }
public string Detail83CreatedBy { get; set; }
public bool IsDetail83Active { get; set; }
public int Detail83SortOrder { get; set; }


public int Field53Id { get; set; }
public string Field53Name { get; set; }
public string Field53Description { get; set; }
public DateTime Field53CreatedAt { get; set; }
public DateTime? Field53UpdatedAt { get; set; }
public string Field53CreatedBy { get; set; }
public bool IsField53Active { get; set; }
public int Field53SortOrder { get; set; }


public int Field40Id { get; set; }
public string Field40Name { get; set; }
public string Field40Description { get; set; }
public DateTime Field40CreatedAt { get; set; }
public DateTime? Field40UpdatedAt { get; set; }
public string Field40CreatedBy { get; set; }
public bool IsField40Active { get; set; }
public int Field40SortOrder { get; set; }


public int Detail24Id { get; set; }
public string Detail24Name { get; set; }
public string Detail24Description { get; set; }
public DateTime Detail24CreatedAt { get; set; }
public DateTime? Detail24UpdatedAt { get; set; }
public string Detail24CreatedBy { get; set; }
public bool IsDetail24Active { get; set; }
public int Detail24SortOrder { get; set; }


public int Param80Id { get; set; }
public string Param80Name { get; set; }
public string Param80Description { get; set; }
public DateTime Param80CreatedAt { get; set; }
public DateTime? Param80UpdatedAt { get; set; }
public string Param80CreatedBy { get; set; }
public bool IsParam80Active { get; set; }
public int Param80SortOrder { get; set; }


public int Entry21Id { get; set; }
public string Entry21Name { get; set; }
public string Entry21Description { get; set; }
public DateTime Entry21CreatedAt { get; set; }
public DateTime? Entry21UpdatedAt { get; set; }
public string Entry21CreatedBy { get; set; }
public bool IsEntry21Active { get; set; }
public int Entry21SortOrder { get; set; }


public int Param78Id { get; set; }
public string Param78Name { get; set; }
public string Param78Description { get; set; }
public DateTime Param78CreatedAt { get; set; }
public DateTime? Param78UpdatedAt { get; set; }
public string Param78CreatedBy { get; set; }
public bool IsParam78Active { get; set; }
public int Param78SortOrder { get; set; }


public int Detail60Id { get; set; }
public string Detail60Name { get; set; }
public string Detail60Description { get; set; }
public DateTime Detail60CreatedAt { get; set; }
public DateTime? Detail60UpdatedAt { get; set; }
public string Detail60CreatedBy { get; set; }
public bool IsDetail60Active { get; set; }
public int Detail60SortOrder { get; set; }


public int Attr65Id { get; set; }
public string Attr65Name { get; set; }
public string Attr65Description { get; set; }
public DateTime Attr65CreatedAt { get; set; }
public DateTime? Attr65UpdatedAt { get; set; }
public string Attr65CreatedBy { get; set; }
public bool IsAttr65Active { get; set; }
public int Attr65SortOrder { get; set; }


public int Attr95Id { get; set; }
public string Attr95Name { get; set; }
public string Attr95Description { get; set; }
public DateTime Attr95CreatedAt { get; set; }
public DateTime? Attr95UpdatedAt { get; set; }
public string Attr95CreatedBy { get; set; }
public bool IsAttr95Active { get; set; }
public int Attr95SortOrder { get; set; }


public int Detail74Id { get; set; }
public string Detail74Name { get; set; }
public string Detail74Description { get; set; }
public DateTime Detail74CreatedAt { get; set; }
public DateTime? Detail74UpdatedAt { get; set; }
public string Detail74CreatedBy { get; set; }
public bool IsDetail74Active { get; set; }
public int Detail74SortOrder { get; set; }


public int Param12Id { get; set; }
public string Param12Name { get; set; }
public string Param12Description { get; set; }
public DateTime Param12CreatedAt { get; set; }
public DateTime? Param12UpdatedAt { get; set; }
public string Param12CreatedBy { get; set; }
public bool IsParam12Active { get; set; }
public int Param12SortOrder { get; set; }


public int Config39Id { get; set; }
public string Config39Name { get; set; }
public string Config39Description { get; set; }
public DateTime Config39CreatedAt { get; set; }
public DateTime? Config39UpdatedAt { get; set; }
public string Config39CreatedBy { get; set; }
public bool IsConfig39Active { get; set; }
public int Config39SortOrder { get; set; }


public int Config24Id { get; set; }
public string Config24Name { get; set; }
public string Config24Description { get; set; }
public DateTime Config24CreatedAt { get; set; }
public DateTime? Config24UpdatedAt { get; set; }
public string Config24CreatedBy { get; set; }
public bool IsConfig24Active { get; set; }
public int Config24SortOrder { get; set; }


public int Field62Id { get; set; }
public string Field62Name { get; set; }
public string Field62Description { get; set; }
public DateTime Field62CreatedAt { get; set; }
public DateTime? Field62UpdatedAt { get; set; }
public string Field62CreatedBy { get; set; }
public bool IsField62Active { get; set; }
public int Field62SortOrder { get; set; }


public int Config12Id { get; set; }
public string Config12Name { get; set; }
public string Config12Description { get; set; }
public DateTime Config12CreatedAt { get; set; }
public DateTime? Config12UpdatedAt { get; set; }
public string Config12CreatedBy { get; set; }
public bool IsConfig12Active { get; set; }
public int Config12SortOrder { get; set; }


public int Detail61Id { get; set; }
public string Detail61Name { get; set; }
public string Detail61Description { get; set; }
public DateTime Detail61CreatedAt { get; set; }
public DateTime? Detail61UpdatedAt { get; set; }
public string Detail61CreatedBy { get; set; }
public bool IsDetail61Active { get; set; }
public int Detail61SortOrder { get; set; }


public int Config89Id { get; set; }
public string Config89Name { get; set; }
public string Config89Description { get; set; }
public DateTime Config89CreatedAt { get; set; }
public DateTime? Config89UpdatedAt { get; set; }
public string Config89CreatedBy { get; set; }
public bool IsConfig89Active { get; set; }
public int Config89SortOrder { get; set; }


public int Detail91Id { get; set; }
public string Detail91Name { get; set; }
public string Detail91Description { get; set; }
public DateTime Detail91CreatedAt { get; set; }
public DateTime? Detail91UpdatedAt { get; set; }
public string Detail91CreatedBy { get; set; }
public bool IsDetail91Active { get; set; }
public int Detail91SortOrder { get; set; }


public int Entry50Id { get; set; }
public string Entry50Name { get; set; }
public string Entry50Description { get; set; }
public DateTime Entry50CreatedAt { get; set; }
public DateTime? Entry50UpdatedAt { get; set; }
public string Entry50CreatedBy { get; set; }
public bool IsEntry50Active { get; set; }
public int Entry50SortOrder { get; set; }


public int Config8Id { get; set; }
public string Config8Name { get; set; }
public string Config8Description { get; set; }
public DateTime Config8CreatedAt { get; set; }
public DateTime? Config8UpdatedAt { get; set; }
public string Config8CreatedBy { get; set; }
public bool IsConfig8Active { get; set; }
public int Config8SortOrder { get; set; }


public int Item72Id { get; set; }
public string Item72Name { get; set; }
public string Item72Description { get; set; }
public DateTime Item72CreatedAt { get; set; }
public DateTime? Item72UpdatedAt { get; set; }
public string Item72CreatedBy { get; set; }
public bool IsItem72Active { get; set; }
public int Item72SortOrder { get; set; }


public int Record96Id { get; set; }
public string Record96Name { get; set; }
public string Record96Description { get; set; }
public DateTime Record96CreatedAt { get; set; }
public DateTime? Record96UpdatedAt { get; set; }
public string Record96CreatedBy { get; set; }
public bool IsRecord96Active { get; set; }
public int Record96SortOrder { get; set; }


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