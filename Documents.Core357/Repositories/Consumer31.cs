using Admin.Processors;
using Admin.Validators431;
using Admin.Web46;
using Auth.Handlers467;
using Documents.Client58;
using Documents.Web164;
using Imaging.Events416;
using Imaging.Shared115;
using Imaging.Tests328;
using Import.Api272;
using Import.Validators;
using Integration.Contracts290;
using Logging.Client405;
using Notifications.Api;
using Portal.Processors;
using Reporting.Events188;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Models;
using Workflow.Web59;

namespace Documents.Core357
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer31
    {
        private readonly IAdmin_Validators431_Handler4 _iAdmin_Validators431_Handler4;
        private readonly Admin_Validators431_Provider6 _admin_Validators431_Provider6;
        private readonly IAdmin_Processors_Provider1 _iAdmin_Processors_Provider1;
        private readonly Admin_Processors_Handler _admin_Processors_Handler;
        private readonly Admin_Web46_Response2 _admin_Web46_Response2;
        private readonly Admin_Web46_Controller4 _admin_Web46_Controller4;
        private readonly IDocuments_Client58_Service _iDocuments_Client58_Service;
        private readonly Documents_Client58_Controller11 _documents_Client58_Controller11;

        public Consumer31(IAdmin_Validators431_Handler4 iAdmin_Validators431_Handler4, Admin_Validators431_Provider6 admin_Validators431_Provider6, IAdmin_Processors_Provider1 iAdmin_Processors_Provider1, Admin_Processors_Handler admin_Processors_Handler, Admin_Web46_Response2 admin_Web46_Response2, Admin_Web46_Controller4 admin_Web46_Controller4, IDocuments_Client58_Service iDocuments_Client58_Service, Documents_Client58_Controller11 documents_Client58_Controller11)
        {
            _iAdmin_Validators431_Handler4 = iAdmin_Validators431_Handler4 ?? throw new ArgumentNullException(nameof(iAdmin_Validators431_Handler4));
            _admin_Validators431_Provider6 = admin_Validators431_Provider6 ?? throw new ArgumentNullException(nameof(admin_Validators431_Provider6));
            _iAdmin_Processors_Provider1 = iAdmin_Processors_Provider1 ?? throw new ArgumentNullException(nameof(iAdmin_Processors_Provider1));
            _admin_Processors_Handler = admin_Processors_Handler ?? throw new ArgumentNullException(nameof(admin_Processors_Handler));
            _admin_Web46_Response2 = admin_Web46_Response2 ?? throw new ArgumentNullException(nameof(admin_Web46_Response2));
            _admin_Web46_Controller4 = admin_Web46_Controller4 ?? throw new ArgumentNullException(nameof(admin_Web46_Controller4));
            _iDocuments_Client58_Service = iDocuments_Client58_Service ?? throw new ArgumentNullException(nameof(iDocuments_Client58_Service));
            _documents_Client58_Controller11 = documents_Client58_Controller11 ?? throw new ArgumentNullException(nameof(documents_Client58_Controller11));
        }

        public IAdmin_Validators431_Handler4 GetIAdmin_Validators431_Handler4() => _iAdmin_Validators431_Handler4;
        public Admin_Validators431_Provider6 GetAdmin_Validators431_Provider6() => _admin_Validators431_Provider6;
        public IAdmin_Processors_Provider1 GetIAdmin_Processors_Provider1() => _iAdmin_Processors_Provider1;
        public Admin_Processors_Handler GetAdmin_Processors_Handler() => _admin_Processors_Handler;
        public Admin_Web46_Response2 GetAdmin_Web46_Response2() => _admin_Web46_Response2;
        public Admin_Web46_Controller4 GetAdmin_Web46_Controller4() => _admin_Web46_Controller4;
        public IDocuments_Client58_Service GetIDocuments_Client58_Service() => _iDocuments_Client58_Service;
        public Documents_Client58_Controller11 GetDocuments_Client58_Controller11() => _documents_Client58_Controller11;

/// <summary>
/// Validates the Consumer31 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer31(Consumer31Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer31));
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
/// Processes the Consumer31 operation asynchronously.
/// </summary>
public async Task<Consumer31Result> ProcessConsumer31Async(
    Consumer31Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer31), request.Id);

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
            return new Consumer31Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer31));
        return new Consumer31Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer31));
        return new Consumer31Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer31 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer31Dto>> GetConsumer31ListAsync(
    Consumer31Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer31Entity>().AsQueryable();

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
        .Select(x => new Consumer31Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer31Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer31Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer31Service(
    ILogger<Consumer31Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer31:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer31 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer31Data> GetCachedConsumer31Async(string key)
{
    var cacheKey = $"Consumer31_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer31Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer31SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Param15Id { get; set; }
public string Param15Name { get; set; }
public string Param15Description { get; set; }
public DateTime Param15CreatedAt { get; set; }
public DateTime? Param15UpdatedAt { get; set; }
public string Param15CreatedBy { get; set; }
public bool IsParam15Active { get; set; }
public int Param15SortOrder { get; set; }


public int Config38Id { get; set; }
public string Config38Name { get; set; }
public string Config38Description { get; set; }
public DateTime Config38CreatedAt { get; set; }
public DateTime? Config38UpdatedAt { get; set; }
public string Config38CreatedBy { get; set; }
public bool IsConfig38Active { get; set; }
public int Config38SortOrder { get; set; }


public int Field39Id { get; set; }
public string Field39Name { get; set; }
public string Field39Description { get; set; }
public DateTime Field39CreatedAt { get; set; }
public DateTime? Field39UpdatedAt { get; set; }
public string Field39CreatedBy { get; set; }
public bool IsField39Active { get; set; }
public int Field39SortOrder { get; set; }


public int Field96Id { get; set; }
public string Field96Name { get; set; }
public string Field96Description { get; set; }
public DateTime Field96CreatedAt { get; set; }
public DateTime? Field96UpdatedAt { get; set; }
public string Field96CreatedBy { get; set; }
public bool IsField96Active { get; set; }
public int Field96SortOrder { get; set; }


public int Config54Id { get; set; }
public string Config54Name { get; set; }
public string Config54Description { get; set; }
public DateTime Config54CreatedAt { get; set; }
public DateTime? Config54UpdatedAt { get; set; }
public string Config54CreatedBy { get; set; }
public bool IsConfig54Active { get; set; }
public int Config54SortOrder { get; set; }


public int Attr96Id { get; set; }
public string Attr96Name { get; set; }
public string Attr96Description { get; set; }
public DateTime Attr96CreatedAt { get; set; }
public DateTime? Attr96UpdatedAt { get; set; }
public string Attr96CreatedBy { get; set; }
public bool IsAttr96Active { get; set; }
public int Attr96SortOrder { get; set; }


public int Param20Id { get; set; }
public string Param20Name { get; set; }
public string Param20Description { get; set; }
public DateTime Param20CreatedAt { get; set; }
public DateTime? Param20UpdatedAt { get; set; }
public string Param20CreatedBy { get; set; }
public bool IsParam20Active { get; set; }
public int Param20SortOrder { get; set; }


public int Param48Id { get; set; }
public string Param48Name { get; set; }
public string Param48Description { get; set; }
public DateTime Param48CreatedAt { get; set; }
public DateTime? Param48UpdatedAt { get; set; }
public string Param48CreatedBy { get; set; }
public bool IsParam48Active { get; set; }
public int Param48SortOrder { get; set; }


public int Item17Id { get; set; }
public string Item17Name { get; set; }
public string Item17Description { get; set; }
public DateTime Item17CreatedAt { get; set; }
public DateTime? Item17UpdatedAt { get; set; }
public string Item17CreatedBy { get; set; }
public bool IsItem17Active { get; set; }
public int Item17SortOrder { get; set; }


public int Detail50Id { get; set; }
public string Detail50Name { get; set; }
public string Detail50Description { get; set; }
public DateTime Detail50CreatedAt { get; set; }
public DateTime? Detail50UpdatedAt { get; set; }
public string Detail50CreatedBy { get; set; }
public bool IsDetail50Active { get; set; }
public int Detail50SortOrder { get; set; }


public int Entry92Id { get; set; }
public string Entry92Name { get; set; }
public string Entry92Description { get; set; }
public DateTime Entry92CreatedAt { get; set; }
public DateTime? Entry92UpdatedAt { get; set; }
public string Entry92CreatedBy { get; set; }
public bool IsEntry92Active { get; set; }
public int Entry92SortOrder { get; set; }


public int Detail79Id { get; set; }
public string Detail79Name { get; set; }
public string Detail79Description { get; set; }
public DateTime Detail79CreatedAt { get; set; }
public DateTime? Detail79UpdatedAt { get; set; }
public string Detail79CreatedBy { get; set; }
public bool IsDetail79Active { get; set; }
public int Detail79SortOrder { get; set; }


public int Detail70Id { get; set; }
public string Detail70Name { get; set; }
public string Detail70Description { get; set; }
public DateTime Detail70CreatedAt { get; set; }
public DateTime? Detail70UpdatedAt { get; set; }
public string Detail70CreatedBy { get; set; }
public bool IsDetail70Active { get; set; }
public int Detail70SortOrder { get; set; }


public int Record14Id { get; set; }
public string Record14Name { get; set; }
public string Record14Description { get; set; }
public DateTime Record14CreatedAt { get; set; }
public DateTime? Record14UpdatedAt { get; set; }
public string Record14CreatedBy { get; set; }
public bool IsRecord14Active { get; set; }
public int Record14SortOrder { get; set; }


public int Detail94Id { get; set; }
public string Detail94Name { get; set; }
public string Detail94Description { get; set; }
public DateTime Detail94CreatedAt { get; set; }
public DateTime? Detail94UpdatedAt { get; set; }
public string Detail94CreatedBy { get; set; }
public bool IsDetail94Active { get; set; }
public int Detail94SortOrder { get; set; }


public int Item5Id { get; set; }
public string Item5Name { get; set; }
public string Item5Description { get; set; }
public DateTime Item5CreatedAt { get; set; }
public DateTime? Item5UpdatedAt { get; set; }
public string Item5CreatedBy { get; set; }
public bool IsItem5Active { get; set; }
public int Item5SortOrder { get; set; }


public int Item92Id { get; set; }
public string Item92Name { get; set; }
public string Item92Description { get; set; }
public DateTime Item92CreatedAt { get; set; }
public DateTime? Item92UpdatedAt { get; set; }
public string Item92CreatedBy { get; set; }
public bool IsItem92Active { get; set; }
public int Item92SortOrder { get; set; }


public int Detail78Id { get; set; }
public string Detail78Name { get; set; }
public string Detail78Description { get; set; }
public DateTime Detail78CreatedAt { get; set; }
public DateTime? Detail78UpdatedAt { get; set; }
public string Detail78CreatedBy { get; set; }
public bool IsDetail78Active { get; set; }
public int Detail78SortOrder { get; set; }


public int Item64Id { get; set; }
public string Item64Name { get; set; }
public string Item64Description { get; set; }
public DateTime Item64CreatedAt { get; set; }
public DateTime? Item64UpdatedAt { get; set; }
public string Item64CreatedBy { get; set; }
public bool IsItem64Active { get; set; }
public int Item64SortOrder { get; set; }


public int Entry74Id { get; set; }
public string Entry74Name { get; set; }
public string Entry74Description { get; set; }
public DateTime Entry74CreatedAt { get; set; }
public DateTime? Entry74UpdatedAt { get; set; }
public string Entry74CreatedBy { get; set; }
public bool IsEntry74Active { get; set; }
public int Entry74SortOrder { get; set; }


public int Item37Id { get; set; }
public string Item37Name { get; set; }
public string Item37Description { get; set; }
public DateTime Item37CreatedAt { get; set; }
public DateTime? Item37UpdatedAt { get; set; }
public string Item37CreatedBy { get; set; }
public bool IsItem37Active { get; set; }
public int Item37SortOrder { get; set; }


public int Record61Id { get; set; }
public string Record61Name { get; set; }
public string Record61Description { get; set; }
public DateTime Record61CreatedAt { get; set; }
public DateTime? Record61UpdatedAt { get; set; }
public string Record61CreatedBy { get; set; }
public bool IsRecord61Active { get; set; }
public int Record61SortOrder { get; set; }


public int Attr19Id { get; set; }
public string Attr19Name { get; set; }
public string Attr19Description { get; set; }
public DateTime Attr19CreatedAt { get; set; }
public DateTime? Attr19UpdatedAt { get; set; }
public string Attr19CreatedBy { get; set; }
public bool IsAttr19Active { get; set; }
public int Attr19SortOrder { get; set; }


public int Detail87Id { get; set; }
public string Detail87Name { get; set; }
public string Detail87Description { get; set; }
public DateTime Detail87CreatedAt { get; set; }
public DateTime? Detail87UpdatedAt { get; set; }
public string Detail87CreatedBy { get; set; }
public bool IsDetail87Active { get; set; }
public int Detail87SortOrder { get; set; }


public int Item45Id { get; set; }
public string Item45Name { get; set; }
public string Item45Description { get; set; }
public DateTime Item45CreatedAt { get; set; }
public DateTime? Item45UpdatedAt { get; set; }
public string Item45CreatedBy { get; set; }
public bool IsItem45Active { get; set; }
public int Item45SortOrder { get; set; }


public int Item73Id { get; set; }
public string Item73Name { get; set; }
public string Item73Description { get; set; }
public DateTime Item73CreatedAt { get; set; }
public DateTime? Item73UpdatedAt { get; set; }
public string Item73CreatedBy { get; set; }
public bool IsItem73Active { get; set; }
public int Item73SortOrder { get; set; }


public int Detail49Id { get; set; }
public string Detail49Name { get; set; }
public string Detail49Description { get; set; }
public DateTime Detail49CreatedAt { get; set; }
public DateTime? Detail49UpdatedAt { get; set; }
public string Detail49CreatedBy { get; set; }
public bool IsDetail49Active { get; set; }
public int Detail49SortOrder { get; set; }


public int Detail11Id { get; set; }
public string Detail11Name { get; set; }
public string Detail11Description { get; set; }
public DateTime Detail11CreatedAt { get; set; }
public DateTime? Detail11UpdatedAt { get; set; }
public string Detail11CreatedBy { get; set; }
public bool IsDetail11Active { get; set; }
public int Detail11SortOrder { get; set; }


public int Config7Id { get; set; }
public string Config7Name { get; set; }
public string Config7Description { get; set; }
public DateTime Config7CreatedAt { get; set; }
public DateTime? Config7UpdatedAt { get; set; }
public string Config7CreatedBy { get; set; }
public bool IsConfig7Active { get; set; }
public int Config7SortOrder { get; set; }


public int Config42Id { get; set; }
public string Config42Name { get; set; }
public string Config42Description { get; set; }
public DateTime Config42CreatedAt { get; set; }
public DateTime? Config42UpdatedAt { get; set; }
public string Config42CreatedBy { get; set; }
public bool IsConfig42Active { get; set; }
public int Config42SortOrder { get; set; }


public int Field88Id { get; set; }
public string Field88Name { get; set; }
public string Field88Description { get; set; }
public DateTime Field88CreatedAt { get; set; }
public DateTime? Field88UpdatedAt { get; set; }
public string Field88CreatedBy { get; set; }
public bool IsField88Active { get; set; }
public int Field88SortOrder { get; set; }


public int Config50Id { get; set; }
public string Config50Name { get; set; }
public string Config50Description { get; set; }
public DateTime Config50CreatedAt { get; set; }
public DateTime? Config50UpdatedAt { get; set; }
public string Config50CreatedBy { get; set; }
public bool IsConfig50Active { get; set; }
public int Config50SortOrder { get; set; }


public int Item68Id { get; set; }
public string Item68Name { get; set; }
public string Item68Description { get; set; }
public DateTime Item68CreatedAt { get; set; }
public DateTime? Item68UpdatedAt { get; set; }
public string Item68CreatedBy { get; set; }
public bool IsItem68Active { get; set; }
public int Item68SortOrder { get; set; }


public int Detail62Id { get; set; }
public string Detail62Name { get; set; }
public string Detail62Description { get; set; }
public DateTime Detail62CreatedAt { get; set; }
public DateTime? Detail62UpdatedAt { get; set; }
public string Detail62CreatedBy { get; set; }
public bool IsDetail62Active { get; set; }
public int Detail62SortOrder { get; set; }


public int Config18Id { get; set; }
public string Config18Name { get; set; }
public string Config18Description { get; set; }
public DateTime Config18CreatedAt { get; set; }
public DateTime? Config18UpdatedAt { get; set; }
public string Config18CreatedBy { get; set; }
public bool IsConfig18Active { get; set; }
public int Config18SortOrder { get; set; }


public int Field69Id { get; set; }
public string Field69Name { get; set; }
public string Field69Description { get; set; }
public DateTime Field69CreatedAt { get; set; }
public DateTime? Field69UpdatedAt { get; set; }
public string Field69CreatedBy { get; set; }
public bool IsField69Active { get; set; }
public int Field69SortOrder { get; set; }


public int Item87Id { get; set; }
public string Item87Name { get; set; }
public string Item87Description { get; set; }
public DateTime Item87CreatedAt { get; set; }
public DateTime? Item87UpdatedAt { get; set; }
public string Item87CreatedBy { get; set; }
public bool IsItem87Active { get; set; }
public int Item87SortOrder { get; set; }


public int Field23Id { get; set; }
public string Field23Name { get; set; }
public string Field23Description { get; set; }
public DateTime Field23CreatedAt { get; set; }
public DateTime? Field23UpdatedAt { get; set; }
public string Field23CreatedBy { get; set; }
public bool IsField23Active { get; set; }
public int Field23SortOrder { get; set; }


public int Attr23Id { get; set; }
public string Attr23Name { get; set; }
public string Attr23Description { get; set; }
public DateTime Attr23CreatedAt { get; set; }
public DateTime? Attr23UpdatedAt { get; set; }
public string Attr23CreatedBy { get; set; }
public bool IsAttr23Active { get; set; }
public int Attr23SortOrder { get; set; }


public int Item78Id { get; set; }
public string Item78Name { get; set; }
public string Item78Description { get; set; }
public DateTime Item78CreatedAt { get; set; }
public DateTime? Item78UpdatedAt { get; set; }
public string Item78CreatedBy { get; set; }
public bool IsItem78Active { get; set; }
public int Item78SortOrder { get; set; }


public int Record74Id { get; set; }
public string Record74Name { get; set; }
public string Record74Description { get; set; }
public DateTime Record74CreatedAt { get; set; }
public DateTime? Record74UpdatedAt { get; set; }
public string Record74CreatedBy { get; set; }
public bool IsRecord74Active { get; set; }
public int Record74SortOrder { get; set; }


public int Detail85Id { get; set; }
public string Detail85Name { get; set; }
public string Detail85Description { get; set; }
public DateTime Detail85CreatedAt { get; set; }
public DateTime? Detail85UpdatedAt { get; set; }
public string Detail85CreatedBy { get; set; }
public bool IsDetail85Active { get; set; }
public int Detail85SortOrder { get; set; }


public int Config62Id { get; set; }
public string Config62Name { get; set; }
public string Config62Description { get; set; }
public DateTime Config62CreatedAt { get; set; }
public DateTime? Config62UpdatedAt { get; set; }
public string Config62CreatedBy { get; set; }
public bool IsConfig62Active { get; set; }
public int Config62SortOrder { get; set; }


public int Attr53Id { get; set; }
public string Attr53Name { get; set; }
public string Attr53Description { get; set; }
public DateTime Attr53CreatedAt { get; set; }
public DateTime? Attr53UpdatedAt { get; set; }
public string Attr53CreatedBy { get; set; }
public bool IsAttr53Active { get; set; }
public int Attr53SortOrder { get; set; }


public int Item38Id { get; set; }
public string Item38Name { get; set; }
public string Item38Description { get; set; }
public DateTime Item38CreatedAt { get; set; }
public DateTime? Item38UpdatedAt { get; set; }
public string Item38CreatedBy { get; set; }
public bool IsItem38Active { get; set; }
public int Item38SortOrder { get; set; }

    }
}