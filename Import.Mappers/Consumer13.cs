using Admin.Client177;
using Auth.Client271;
using Auth.Handlers467;
using BatchJobs.Handlers443;
using Billing.Contracts44;
using Common.Contracts;
using Common.Data;
using Common.Processors142;
using Export.Web210;
using Import.Api179;
using Integration.Processors241;
using Integration.Service147;
using Notifications.Core166;
using Security.Client349;
using Security.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Contracts192;
using Workflow.Handlers;

namespace Import.Mappers
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer13
    {
        private readonly Auth_Client271_Repository5 _auth_Client271_Repository5;
        private readonly Auth_Client271_Controller2 _auth_Client271_Controller2;
        private readonly Auth_Handlers467_Service9 _auth_Handlers467_Service9;
        private readonly ICommon_Data_Factory4 _iCommon_Data_Factory4;
        private readonly Common_Data_Provider1 _common_Data_Provider1;
        private readonly Common_Contracts_Repository _common_Contracts_Repository;
        private readonly Export_Web210_Handler4 _export_Web210_Handler4;
        private readonly Export_Web210_Result2 _export_Web210_Result2;

        public Consumer13(Auth_Client271_Repository5 auth_Client271_Repository5, Auth_Client271_Controller2 auth_Client271_Controller2, Auth_Handlers467_Service9 auth_Handlers467_Service9, ICommon_Data_Factory4 iCommon_Data_Factory4, Common_Data_Provider1 common_Data_Provider1, Common_Contracts_Repository common_Contracts_Repository, Export_Web210_Handler4 export_Web210_Handler4, Export_Web210_Result2 export_Web210_Result2)
        {
            _auth_Client271_Repository5 = auth_Client271_Repository5 ?? throw new ArgumentNullException(nameof(auth_Client271_Repository5));
            _auth_Client271_Controller2 = auth_Client271_Controller2 ?? throw new ArgumentNullException(nameof(auth_Client271_Controller2));
            _auth_Handlers467_Service9 = auth_Handlers467_Service9 ?? throw new ArgumentNullException(nameof(auth_Handlers467_Service9));
            _iCommon_Data_Factory4 = iCommon_Data_Factory4 ?? throw new ArgumentNullException(nameof(iCommon_Data_Factory4));
            _common_Data_Provider1 = common_Data_Provider1 ?? throw new ArgumentNullException(nameof(common_Data_Provider1));
            _common_Contracts_Repository = common_Contracts_Repository ?? throw new ArgumentNullException(nameof(common_Contracts_Repository));
            _export_Web210_Handler4 = export_Web210_Handler4 ?? throw new ArgumentNullException(nameof(export_Web210_Handler4));
            _export_Web210_Result2 = export_Web210_Result2 ?? throw new ArgumentNullException(nameof(export_Web210_Result2));
        }

        public Auth_Client271_Repository5 GetAuth_Client271_Repository5() => _auth_Client271_Repository5;
        public Auth_Client271_Controller2 GetAuth_Client271_Controller2() => _auth_Client271_Controller2;
        public Auth_Handlers467_Service9 GetAuth_Handlers467_Service9() => _auth_Handlers467_Service9;
        public ICommon_Data_Factory4 GetICommon_Data_Factory4() => _iCommon_Data_Factory4;
        public Common_Data_Provider1 GetCommon_Data_Provider1() => _common_Data_Provider1;
        public Common_Contracts_Repository GetCommon_Contracts_Repository() => _common_Contracts_Repository;
        public Export_Web210_Handler4 GetExport_Web210_Handler4() => _export_Web210_Handler4;
        public Export_Web210_Result2 GetExport_Web210_Result2() => _export_Web210_Result2;

/// <summary>
/// Validates the Consumer13 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer13(Consumer13Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer13));
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
/// Processes the Consumer13 operation asynchronously.
/// </summary>
public async Task<Consumer13Result> ProcessConsumer13Async(
    Consumer13Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer13), request.Id);

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
            return new Consumer13Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer13));
        return new Consumer13Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer13));
        return new Consumer13Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer13 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer13Dto>> GetConsumer13ListAsync(
    Consumer13Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer13Entity>().AsQueryable();

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
        .Select(x => new Consumer13Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer13Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer13Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer13Service(
    ILogger<Consumer13Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer13:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer13 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer13Data> GetCachedConsumer13Async(string key)
{
    var cacheKey = $"Consumer13_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer13Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer13SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Field55Id { get; set; }
public string Field55Name { get; set; }
public string Field55Description { get; set; }
public DateTime Field55CreatedAt { get; set; }
public DateTime? Field55UpdatedAt { get; set; }
public string Field55CreatedBy { get; set; }
public bool IsField55Active { get; set; }
public int Field55SortOrder { get; set; }


public int Field44Id { get; set; }
public string Field44Name { get; set; }
public string Field44Description { get; set; }
public DateTime Field44CreatedAt { get; set; }
public DateTime? Field44UpdatedAt { get; set; }
public string Field44CreatedBy { get; set; }
public bool IsField44Active { get; set; }
public int Field44SortOrder { get; set; }


public int Attr4Id { get; set; }
public string Attr4Name { get; set; }
public string Attr4Description { get; set; }
public DateTime Attr4CreatedAt { get; set; }
public DateTime? Attr4UpdatedAt { get; set; }
public string Attr4CreatedBy { get; set; }
public bool IsAttr4Active { get; set; }
public int Attr4SortOrder { get; set; }


public int Item4Id { get; set; }
public string Item4Name { get; set; }
public string Item4Description { get; set; }
public DateTime Item4CreatedAt { get; set; }
public DateTime? Item4UpdatedAt { get; set; }
public string Item4CreatedBy { get; set; }
public bool IsItem4Active { get; set; }
public int Item4SortOrder { get; set; }


public int Param16Id { get; set; }
public string Param16Name { get; set; }
public string Param16Description { get; set; }
public DateTime Param16CreatedAt { get; set; }
public DateTime? Param16UpdatedAt { get; set; }
public string Param16CreatedBy { get; set; }
public bool IsParam16Active { get; set; }
public int Param16SortOrder { get; set; }


public int Attr33Id { get; set; }
public string Attr33Name { get; set; }
public string Attr33Description { get; set; }
public DateTime Attr33CreatedAt { get; set; }
public DateTime? Attr33UpdatedAt { get; set; }
public string Attr33CreatedBy { get; set; }
public bool IsAttr33Active { get; set; }
public int Attr33SortOrder { get; set; }


public int Item73Id { get; set; }
public string Item73Name { get; set; }
public string Item73Description { get; set; }
public DateTime Item73CreatedAt { get; set; }
public DateTime? Item73UpdatedAt { get; set; }
public string Item73CreatedBy { get; set; }
public bool IsItem73Active { get; set; }
public int Item73SortOrder { get; set; }


public int Param92Id { get; set; }
public string Param92Name { get; set; }
public string Param92Description { get; set; }
public DateTime Param92CreatedAt { get; set; }
public DateTime? Param92UpdatedAt { get; set; }
public string Param92CreatedBy { get; set; }
public bool IsParam92Active { get; set; }
public int Param92SortOrder { get; set; }


public int Field77Id { get; set; }
public string Field77Name { get; set; }
public string Field77Description { get; set; }
public DateTime Field77CreatedAt { get; set; }
public DateTime? Field77UpdatedAt { get; set; }
public string Field77CreatedBy { get; set; }
public bool IsField77Active { get; set; }
public int Field77SortOrder { get; set; }


public int Attr1Id { get; set; }
public string Attr1Name { get; set; }
public string Attr1Description { get; set; }
public DateTime Attr1CreatedAt { get; set; }
public DateTime? Attr1UpdatedAt { get; set; }
public string Attr1CreatedBy { get; set; }
public bool IsAttr1Active { get; set; }
public int Attr1SortOrder { get; set; }


public int Field41Id { get; set; }
public string Field41Name { get; set; }
public string Field41Description { get; set; }
public DateTime Field41CreatedAt { get; set; }
public DateTime? Field41UpdatedAt { get; set; }
public string Field41CreatedBy { get; set; }
public bool IsField41Active { get; set; }
public int Field41SortOrder { get; set; }


public int Param7Id { get; set; }
public string Param7Name { get; set; }
public string Param7Description { get; set; }
public DateTime Param7CreatedAt { get; set; }
public DateTime? Param7UpdatedAt { get; set; }
public string Param7CreatedBy { get; set; }
public bool IsParam7Active { get; set; }
public int Param7SortOrder { get; set; }


public int Field54Id { get; set; }
public string Field54Name { get; set; }
public string Field54Description { get; set; }
public DateTime Field54CreatedAt { get; set; }
public DateTime? Field54UpdatedAt { get; set; }
public string Field54CreatedBy { get; set; }
public bool IsField54Active { get; set; }
public int Field54SortOrder { get; set; }


public int Param66Id { get; set; }
public string Param66Name { get; set; }
public string Param66Description { get; set; }
public DateTime Param66CreatedAt { get; set; }
public DateTime? Param66UpdatedAt { get; set; }
public string Param66CreatedBy { get; set; }
public bool IsParam66Active { get; set; }
public int Param66SortOrder { get; set; }


public int Param23Id { get; set; }
public string Param23Name { get; set; }
public string Param23Description { get; set; }
public DateTime Param23CreatedAt { get; set; }
public DateTime? Param23UpdatedAt { get; set; }
public string Param23CreatedBy { get; set; }
public bool IsParam23Active { get; set; }
public int Param23SortOrder { get; set; }


public int Item75Id { get; set; }
public string Item75Name { get; set; }
public string Item75Description { get; set; }
public DateTime Item75CreatedAt { get; set; }
public DateTime? Item75UpdatedAt { get; set; }
public string Item75CreatedBy { get; set; }
public bool IsItem75Active { get; set; }
public int Item75SortOrder { get; set; }


public int Field65Id { get; set; }
public string Field65Name { get; set; }
public string Field65Description { get; set; }
public DateTime Field65CreatedAt { get; set; }
public DateTime? Field65UpdatedAt { get; set; }
public string Field65CreatedBy { get; set; }
public bool IsField65Active { get; set; }
public int Field65SortOrder { get; set; }


public int Param44Id { get; set; }
public string Param44Name { get; set; }
public string Param44Description { get; set; }
public DateTime Param44CreatedAt { get; set; }
public DateTime? Param44UpdatedAt { get; set; }
public string Param44CreatedBy { get; set; }
public bool IsParam44Active { get; set; }
public int Param44SortOrder { get; set; }


public int Param51Id { get; set; }
public string Param51Name { get; set; }
public string Param51Description { get; set; }
public DateTime Param51CreatedAt { get; set; }
public DateTime? Param51UpdatedAt { get; set; }
public string Param51CreatedBy { get; set; }
public bool IsParam51Active { get; set; }
public int Param51SortOrder { get; set; }


public int Attr93Id { get; set; }
public string Attr93Name { get; set; }
public string Attr93Description { get; set; }
public DateTime Attr93CreatedAt { get; set; }
public DateTime? Attr93UpdatedAt { get; set; }
public string Attr93CreatedBy { get; set; }
public bool IsAttr93Active { get; set; }
public int Attr93SortOrder { get; set; }


public int Record10Id { get; set; }
public string Record10Name { get; set; }
public string Record10Description { get; set; }
public DateTime Record10CreatedAt { get; set; }
public DateTime? Record10UpdatedAt { get; set; }
public string Record10CreatedBy { get; set; }
public bool IsRecord10Active { get; set; }
public int Record10SortOrder { get; set; }


public int Item79Id { get; set; }
public string Item79Name { get; set; }
public string Item79Description { get; set; }
public DateTime Item79CreatedAt { get; set; }
public DateTime? Item79UpdatedAt { get; set; }
public string Item79CreatedBy { get; set; }
public bool IsItem79Active { get; set; }
public int Item79SortOrder { get; set; }


public int Config67Id { get; set; }
public string Config67Name { get; set; }
public string Config67Description { get; set; }
public DateTime Config67CreatedAt { get; set; }
public DateTime? Config67UpdatedAt { get; set; }
public string Config67CreatedBy { get; set; }
public bool IsConfig67Active { get; set; }
public int Config67SortOrder { get; set; }


public int Attr14Id { get; set; }
public string Attr14Name { get; set; }
public string Attr14Description { get; set; }
public DateTime Attr14CreatedAt { get; set; }
public DateTime? Attr14UpdatedAt { get; set; }
public string Attr14CreatedBy { get; set; }
public bool IsAttr14Active { get; set; }
public int Attr14SortOrder { get; set; }


public int Attr77Id { get; set; }
public string Attr77Name { get; set; }
public string Attr77Description { get; set; }
public DateTime Attr77CreatedAt { get; set; }
public DateTime? Attr77UpdatedAt { get; set; }
public string Attr77CreatedBy { get; set; }
public bool IsAttr77Active { get; set; }
public int Attr77SortOrder { get; set; }


public int Entry68Id { get; set; }
public string Entry68Name { get; set; }
public string Entry68Description { get; set; }
public DateTime Entry68CreatedAt { get; set; }
public DateTime? Entry68UpdatedAt { get; set; }
public string Entry68CreatedBy { get; set; }
public bool IsEntry68Active { get; set; }
public int Entry68SortOrder { get; set; }


public int Item68Id { get; set; }
public string Item68Name { get; set; }
public string Item68Description { get; set; }
public DateTime Item68CreatedAt { get; set; }
public DateTime? Item68UpdatedAt { get; set; }
public string Item68CreatedBy { get; set; }
public bool IsItem68Active { get; set; }
public int Item68SortOrder { get; set; }


public int Entry2Id { get; set; }
public string Entry2Name { get; set; }
public string Entry2Description { get; set; }
public DateTime Entry2CreatedAt { get; set; }
public DateTime? Entry2UpdatedAt { get; set; }
public string Entry2CreatedBy { get; set; }
public bool IsEntry2Active { get; set; }
public int Entry2SortOrder { get; set; }


public int Config90Id { get; set; }
public string Config90Name { get; set; }
public string Config90Description { get; set; }
public DateTime Config90CreatedAt { get; set; }
public DateTime? Config90UpdatedAt { get; set; }
public string Config90CreatedBy { get; set; }
public bool IsConfig90Active { get; set; }
public int Config90SortOrder { get; set; }


public int Attr16Id { get; set; }
public string Attr16Name { get; set; }
public string Attr16Description { get; set; }
public DateTime Attr16CreatedAt { get; set; }
public DateTime? Attr16UpdatedAt { get; set; }
public string Attr16CreatedBy { get; set; }
public bool IsAttr16Active { get; set; }
public int Attr16SortOrder { get; set; }


public int Record15Id { get; set; }
public string Record15Name { get; set; }
public string Record15Description { get; set; }
public DateTime Record15CreatedAt { get; set; }
public DateTime? Record15UpdatedAt { get; set; }
public string Record15CreatedBy { get; set; }
public bool IsRecord15Active { get; set; }
public int Record15SortOrder { get; set; }


public int Item43Id { get; set; }
public string Item43Name { get; set; }
public string Item43Description { get; set; }
public DateTime Item43CreatedAt { get; set; }
public DateTime? Item43UpdatedAt { get; set; }
public string Item43CreatedBy { get; set; }
public bool IsItem43Active { get; set; }
public int Item43SortOrder { get; set; }


public int Entry29Id { get; set; }
public string Entry29Name { get; set; }
public string Entry29Description { get; set; }
public DateTime Entry29CreatedAt { get; set; }
public DateTime? Entry29UpdatedAt { get; set; }
public string Entry29CreatedBy { get; set; }
public bool IsEntry29Active { get; set; }
public int Entry29SortOrder { get; set; }


public int Item90Id { get; set; }
public string Item90Name { get; set; }
public string Item90Description { get; set; }
public DateTime Item90CreatedAt { get; set; }
public DateTime? Item90UpdatedAt { get; set; }
public string Item90CreatedBy { get; set; }
public bool IsItem90Active { get; set; }
public int Item90SortOrder { get; set; }


public int Record36Id { get; set; }
public string Record36Name { get; set; }
public string Record36Description { get; set; }
public DateTime Record36CreatedAt { get; set; }
public DateTime? Record36UpdatedAt { get; set; }
public string Record36CreatedBy { get; set; }
public bool IsRecord36Active { get; set; }
public int Record36SortOrder { get; set; }


public int Detail41Id { get; set; }
public string Detail41Name { get; set; }
public string Detail41Description { get; set; }
public DateTime Detail41CreatedAt { get; set; }
public DateTime? Detail41UpdatedAt { get; set; }
public string Detail41CreatedBy { get; set; }
public bool IsDetail41Active { get; set; }
public int Detail41SortOrder { get; set; }


public int Detail55Id { get; set; }
public string Detail55Name { get; set; }
public string Detail55Description { get; set; }
public DateTime Detail55CreatedAt { get; set; }
public DateTime? Detail55UpdatedAt { get; set; }
public string Detail55CreatedBy { get; set; }
public bool IsDetail55Active { get; set; }
public int Detail55SortOrder { get; set; }


public int Entry21Id { get; set; }
public string Entry21Name { get; set; }
public string Entry21Description { get; set; }
public DateTime Entry21CreatedAt { get; set; }
public DateTime? Entry21UpdatedAt { get; set; }
public string Entry21CreatedBy { get; set; }
public bool IsEntry21Active { get; set; }
public int Entry21SortOrder { get; set; }


public int Field3Id { get; set; }
public string Field3Name { get; set; }
public string Field3Description { get; set; }
public DateTime Field3CreatedAt { get; set; }
public DateTime? Field3UpdatedAt { get; set; }
public string Field3CreatedBy { get; set; }
public bool IsField3Active { get; set; }
public int Field3SortOrder { get; set; }


public int Record93Id { get; set; }
public string Record93Name { get; set; }
public string Record93Description { get; set; }
public DateTime Record93CreatedAt { get; set; }
public DateTime? Record93UpdatedAt { get; set; }
public string Record93CreatedBy { get; set; }
public bool IsRecord93Active { get; set; }
public int Record93SortOrder { get; set; }


public int Entry64Id { get; set; }
public string Entry64Name { get; set; }
public string Entry64Description { get; set; }
public DateTime Entry64CreatedAt { get; set; }
public DateTime? Entry64UpdatedAt { get; set; }
public string Entry64CreatedBy { get; set; }
public bool IsEntry64Active { get; set; }
public int Entry64SortOrder { get; set; }


public int Entry21Id { get; set; }
public string Entry21Name { get; set; }
public string Entry21Description { get; set; }
public DateTime Entry21CreatedAt { get; set; }
public DateTime? Entry21UpdatedAt { get; set; }
public string Entry21CreatedBy { get; set; }
public bool IsEntry21Active { get; set; }
public int Entry21SortOrder { get; set; }


public int Record88Id { get; set; }
public string Record88Name { get; set; }
public string Record88Description { get; set; }
public DateTime Record88CreatedAt { get; set; }
public DateTime? Record88UpdatedAt { get; set; }
public string Record88CreatedBy { get; set; }
public bool IsRecord88Active { get; set; }
public int Record88SortOrder { get; set; }


public int Entry11Id { get; set; }
public string Entry11Name { get; set; }
public string Entry11Description { get; set; }
public DateTime Entry11CreatedAt { get; set; }
public DateTime? Entry11UpdatedAt { get; set; }
public string Entry11CreatedBy { get; set; }
public bool IsEntry11Active { get; set; }
public int Entry11SortOrder { get; set; }


public int Field66Id { get; set; }
public string Field66Name { get; set; }
public string Field66Description { get; set; }
public DateTime Field66CreatedAt { get; set; }
public DateTime? Field66UpdatedAt { get; set; }
public string Field66CreatedBy { get; set; }
public bool IsField66Active { get; set; }
public int Field66SortOrder { get; set; }


public int Entry98Id { get; set; }
public string Entry98Name { get; set; }
public string Entry98Description { get; set; }
public DateTime Entry98CreatedAt { get; set; }
public DateTime? Entry98UpdatedAt { get; set; }
public string Entry98CreatedBy { get; set; }
public bool IsEntry98Active { get; set; }
public int Entry98SortOrder { get; set; }

    }
}