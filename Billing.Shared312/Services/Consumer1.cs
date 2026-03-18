using Admin.Api;
using Admin.Mappers;
using Admin.Processors35;
using Admin.Web46;
using Auth.Models236;
using BatchJobs.Processors410;
using Common.Shared95;
using DataAccess.Handlers;
using Documents.Api129;
using Documents.Events;
using Documents.Processors133;
using GalaxyWorks.Client;
using GalaxyWorks.Handlers84;
using Import.Data193;
using Logging.Contracts74;
using Portal.Events139;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Contracts228;
using Utilities.Data415;

namespace Billing.Shared312
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer1
    {
        private readonly Auth_Models236_Processor1 _auth_Models236_Processor1;
        private readonly Admin_Mappers_Helper5 _admin_Mappers_Helper5;
        private readonly Admin_Processors35_Provider7 _admin_Processors35_Provider7;
        private readonly Admin_Processors35_Helper4 _admin_Processors35_Helper4;
        private readonly Admin_Processors35_Factory _admin_Processors35_Factory;
        private readonly Import_Data193_Builder2 _import_Data193_Builder2;
        private readonly Import_Data193_Helper9 _import_Data193_Helper9;
        private readonly Import_Data193_Factory8 _import_Data193_Factory8;

        public Consumer1(Auth_Models236_Processor1 auth_Models236_Processor1, Admin_Mappers_Helper5 admin_Mappers_Helper5, Admin_Processors35_Provider7 admin_Processors35_Provider7, Admin_Processors35_Helper4 admin_Processors35_Helper4, Admin_Processors35_Factory admin_Processors35_Factory, Import_Data193_Builder2 import_Data193_Builder2, Import_Data193_Helper9 import_Data193_Helper9, Import_Data193_Factory8 import_Data193_Factory8)
        {
            _auth_Models236_Processor1 = auth_Models236_Processor1 ?? throw new ArgumentNullException(nameof(auth_Models236_Processor1));
            _admin_Mappers_Helper5 = admin_Mappers_Helper5 ?? throw new ArgumentNullException(nameof(admin_Mappers_Helper5));
            _admin_Processors35_Provider7 = admin_Processors35_Provider7 ?? throw new ArgumentNullException(nameof(admin_Processors35_Provider7));
            _admin_Processors35_Helper4 = admin_Processors35_Helper4 ?? throw new ArgumentNullException(nameof(admin_Processors35_Helper4));
            _admin_Processors35_Factory = admin_Processors35_Factory ?? throw new ArgumentNullException(nameof(admin_Processors35_Factory));
            _import_Data193_Builder2 = import_Data193_Builder2 ?? throw new ArgumentNullException(nameof(import_Data193_Builder2));
            _import_Data193_Helper9 = import_Data193_Helper9 ?? throw new ArgumentNullException(nameof(import_Data193_Helper9));
            _import_Data193_Factory8 = import_Data193_Factory8 ?? throw new ArgumentNullException(nameof(import_Data193_Factory8));
        }

        public Auth_Models236_Processor1 GetAuth_Models236_Processor1() => _auth_Models236_Processor1;
        public Admin_Mappers_Helper5 GetAdmin_Mappers_Helper5() => _admin_Mappers_Helper5;
        public Admin_Processors35_Provider7 GetAdmin_Processors35_Provider7() => _admin_Processors35_Provider7;
        public Admin_Processors35_Helper4 GetAdmin_Processors35_Helper4() => _admin_Processors35_Helper4;
        public Admin_Processors35_Factory GetAdmin_Processors35_Factory() => _admin_Processors35_Factory;
        public Import_Data193_Builder2 GetImport_Data193_Builder2() => _import_Data193_Builder2;
        public Import_Data193_Helper9 GetImport_Data193_Helper9() => _import_Data193_Helper9;
        public Import_Data193_Factory8 GetImport_Data193_Factory8() => _import_Data193_Factory8;

/// <summary>
/// Validates the Consumer1 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer1(Consumer1Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer1));
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
/// Processes the Consumer1 operation asynchronously.
/// </summary>
public async Task<Consumer1Result> ProcessConsumer1Async(
    Consumer1Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer1), request.Id);

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
            return new Consumer1Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer1));
        return new Consumer1Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer1));
        return new Consumer1Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer1 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer1Dto>> GetConsumer1ListAsync(
    Consumer1Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer1Entity>().AsQueryable();

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
        .Select(x => new Consumer1Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer1Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer1Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer1Service(
    ILogger<Consumer1Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer1:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer1 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer1Data> GetCachedConsumer1Async(string key)
{
    var cacheKey = $"Consumer1_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer1Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer1SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Record98Id { get; set; }
public string Record98Name { get; set; }
public string Record98Description { get; set; }
public DateTime Record98CreatedAt { get; set; }
public DateTime? Record98UpdatedAt { get; set; }
public string Record98CreatedBy { get; set; }
public bool IsRecord98Active { get; set; }
public int Record98SortOrder { get; set; }


public int Entry53Id { get; set; }
public string Entry53Name { get; set; }
public string Entry53Description { get; set; }
public DateTime Entry53CreatedAt { get; set; }
public DateTime? Entry53UpdatedAt { get; set; }
public string Entry53CreatedBy { get; set; }
public bool IsEntry53Active { get; set; }
public int Entry53SortOrder { get; set; }


public int Field40Id { get; set; }
public string Field40Name { get; set; }
public string Field40Description { get; set; }
public DateTime Field40CreatedAt { get; set; }
public DateTime? Field40UpdatedAt { get; set; }
public string Field40CreatedBy { get; set; }
public bool IsField40Active { get; set; }
public int Field40SortOrder { get; set; }


public int Field61Id { get; set; }
public string Field61Name { get; set; }
public string Field61Description { get; set; }
public DateTime Field61CreatedAt { get; set; }
public DateTime? Field61UpdatedAt { get; set; }
public string Field61CreatedBy { get; set; }
public bool IsField61Active { get; set; }
public int Field61SortOrder { get; set; }


public int Record79Id { get; set; }
public string Record79Name { get; set; }
public string Record79Description { get; set; }
public DateTime Record79CreatedAt { get; set; }
public DateTime? Record79UpdatedAt { get; set; }
public string Record79CreatedBy { get; set; }
public bool IsRecord79Active { get; set; }
public int Record79SortOrder { get; set; }


public int Attr1Id { get; set; }
public string Attr1Name { get; set; }
public string Attr1Description { get; set; }
public DateTime Attr1CreatedAt { get; set; }
public DateTime? Attr1UpdatedAt { get; set; }
public string Attr1CreatedBy { get; set; }
public bool IsAttr1Active { get; set; }
public int Attr1SortOrder { get; set; }


public int Param57Id { get; set; }
public string Param57Name { get; set; }
public string Param57Description { get; set; }
public DateTime Param57CreatedAt { get; set; }
public DateTime? Param57UpdatedAt { get; set; }
public string Param57CreatedBy { get; set; }
public bool IsParam57Active { get; set; }
public int Param57SortOrder { get; set; }


public int Entry90Id { get; set; }
public string Entry90Name { get; set; }
public string Entry90Description { get; set; }
public DateTime Entry90CreatedAt { get; set; }
public DateTime? Entry90UpdatedAt { get; set; }
public string Entry90CreatedBy { get; set; }
public bool IsEntry90Active { get; set; }
public int Entry90SortOrder { get; set; }


public int Field28Id { get; set; }
public string Field28Name { get; set; }
public string Field28Description { get; set; }
public DateTime Field28CreatedAt { get; set; }
public DateTime? Field28UpdatedAt { get; set; }
public string Field28CreatedBy { get; set; }
public bool IsField28Active { get; set; }
public int Field28SortOrder { get; set; }


public int Config8Id { get; set; }
public string Config8Name { get; set; }
public string Config8Description { get; set; }
public DateTime Config8CreatedAt { get; set; }
public DateTime? Config8UpdatedAt { get; set; }
public string Config8CreatedBy { get; set; }
public bool IsConfig8Active { get; set; }
public int Config8SortOrder { get; set; }


public int Entry54Id { get; set; }
public string Entry54Name { get; set; }
public string Entry54Description { get; set; }
public DateTime Entry54CreatedAt { get; set; }
public DateTime? Entry54UpdatedAt { get; set; }
public string Entry54CreatedBy { get; set; }
public bool IsEntry54Active { get; set; }
public int Entry54SortOrder { get; set; }


public int Field79Id { get; set; }
public string Field79Name { get; set; }
public string Field79Description { get; set; }
public DateTime Field79CreatedAt { get; set; }
public DateTime? Field79UpdatedAt { get; set; }
public string Field79CreatedBy { get; set; }
public bool IsField79Active { get; set; }
public int Field79SortOrder { get; set; }


public int Entry82Id { get; set; }
public string Entry82Name { get; set; }
public string Entry82Description { get; set; }
public DateTime Entry82CreatedAt { get; set; }
public DateTime? Entry82UpdatedAt { get; set; }
public string Entry82CreatedBy { get; set; }
public bool IsEntry82Active { get; set; }
public int Entry82SortOrder { get; set; }


public int Param15Id { get; set; }
public string Param15Name { get; set; }
public string Param15Description { get; set; }
public DateTime Param15CreatedAt { get; set; }
public DateTime? Param15UpdatedAt { get; set; }
public string Param15CreatedBy { get; set; }
public bool IsParam15Active { get; set; }
public int Param15SortOrder { get; set; }


public int Param5Id { get; set; }
public string Param5Name { get; set; }
public string Param5Description { get; set; }
public DateTime Param5CreatedAt { get; set; }
public DateTime? Param5UpdatedAt { get; set; }
public string Param5CreatedBy { get; set; }
public bool IsParam5Active { get; set; }
public int Param5SortOrder { get; set; }


public int Field41Id { get; set; }
public string Field41Name { get; set; }
public string Field41Description { get; set; }
public DateTime Field41CreatedAt { get; set; }
public DateTime? Field41UpdatedAt { get; set; }
public string Field41CreatedBy { get; set; }
public bool IsField41Active { get; set; }
public int Field41SortOrder { get; set; }


public int Param52Id { get; set; }
public string Param52Name { get; set; }
public string Param52Description { get; set; }
public DateTime Param52CreatedAt { get; set; }
public DateTime? Param52UpdatedAt { get; set; }
public string Param52CreatedBy { get; set; }
public bool IsParam52Active { get; set; }
public int Param52SortOrder { get; set; }


public int Attr43Id { get; set; }
public string Attr43Name { get; set; }
public string Attr43Description { get; set; }
public DateTime Attr43CreatedAt { get; set; }
public DateTime? Attr43UpdatedAt { get; set; }
public string Attr43CreatedBy { get; set; }
public bool IsAttr43Active { get; set; }
public int Attr43SortOrder { get; set; }


public int Item15Id { get; set; }
public string Item15Name { get; set; }
public string Item15Description { get; set; }
public DateTime Item15CreatedAt { get; set; }
public DateTime? Item15UpdatedAt { get; set; }
public string Item15CreatedBy { get; set; }
public bool IsItem15Active { get; set; }
public int Item15SortOrder { get; set; }


public int Detail5Id { get; set; }
public string Detail5Name { get; set; }
public string Detail5Description { get; set; }
public DateTime Detail5CreatedAt { get; set; }
public DateTime? Detail5UpdatedAt { get; set; }
public string Detail5CreatedBy { get; set; }
public bool IsDetail5Active { get; set; }
public int Detail5SortOrder { get; set; }


public int Entry96Id { get; set; }
public string Entry96Name { get; set; }
public string Entry96Description { get; set; }
public DateTime Entry96CreatedAt { get; set; }
public DateTime? Entry96UpdatedAt { get; set; }
public string Entry96CreatedBy { get; set; }
public bool IsEntry96Active { get; set; }
public int Entry96SortOrder { get; set; }


public int Detail44Id { get; set; }
public string Detail44Name { get; set; }
public string Detail44Description { get; set; }
public DateTime Detail44CreatedAt { get; set; }
public DateTime? Detail44UpdatedAt { get; set; }
public string Detail44CreatedBy { get; set; }
public bool IsDetail44Active { get; set; }
public int Detail44SortOrder { get; set; }


public int Entry16Id { get; set; }
public string Entry16Name { get; set; }
public string Entry16Description { get; set; }
public DateTime Entry16CreatedAt { get; set; }
public DateTime? Entry16UpdatedAt { get; set; }
public string Entry16CreatedBy { get; set; }
public bool IsEntry16Active { get; set; }
public int Entry16SortOrder { get; set; }


public int Attr22Id { get; set; }
public string Attr22Name { get; set; }
public string Attr22Description { get; set; }
public DateTime Attr22CreatedAt { get; set; }
public DateTime? Attr22UpdatedAt { get; set; }
public string Attr22CreatedBy { get; set; }
public bool IsAttr22Active { get; set; }
public int Attr22SortOrder { get; set; }


public int Config89Id { get; set; }
public string Config89Name { get; set; }
public string Config89Description { get; set; }
public DateTime Config89CreatedAt { get; set; }
public DateTime? Config89UpdatedAt { get; set; }
public string Config89CreatedBy { get; set; }
public bool IsConfig89Active { get; set; }
public int Config89SortOrder { get; set; }


public int Record60Id { get; set; }
public string Record60Name { get; set; }
public string Record60Description { get; set; }
public DateTime Record60CreatedAt { get; set; }
public DateTime? Record60UpdatedAt { get; set; }
public string Record60CreatedBy { get; set; }
public bool IsRecord60Active { get; set; }
public int Record60SortOrder { get; set; }


public int Field89Id { get; set; }
public string Field89Name { get; set; }
public string Field89Description { get; set; }
public DateTime Field89CreatedAt { get; set; }
public DateTime? Field89UpdatedAt { get; set; }
public string Field89CreatedBy { get; set; }
public bool IsField89Active { get; set; }
public int Field89SortOrder { get; set; }


public int Field36Id { get; set; }
public string Field36Name { get; set; }
public string Field36Description { get; set; }
public DateTime Field36CreatedAt { get; set; }
public DateTime? Field36UpdatedAt { get; set; }
public string Field36CreatedBy { get; set; }
public bool IsField36Active { get; set; }
public int Field36SortOrder { get; set; }


public int Item42Id { get; set; }
public string Item42Name { get; set; }
public string Item42Description { get; set; }
public DateTime Item42CreatedAt { get; set; }
public DateTime? Item42UpdatedAt { get; set; }
public string Item42CreatedBy { get; set; }
public bool IsItem42Active { get; set; }
public int Item42SortOrder { get; set; }


public int Field24Id { get; set; }
public string Field24Name { get; set; }
public string Field24Description { get; set; }
public DateTime Field24CreatedAt { get; set; }
public DateTime? Field24UpdatedAt { get; set; }
public string Field24CreatedBy { get; set; }
public bool IsField24Active { get; set; }
public int Field24SortOrder { get; set; }


public int Detail18Id { get; set; }
public string Detail18Name { get; set; }
public string Detail18Description { get; set; }
public DateTime Detail18CreatedAt { get; set; }
public DateTime? Detail18UpdatedAt { get; set; }
public string Detail18CreatedBy { get; set; }
public bool IsDetail18Active { get; set; }
public int Detail18SortOrder { get; set; }


public int Param10Id { get; set; }
public string Param10Name { get; set; }
public string Param10Description { get; set; }
public DateTime Param10CreatedAt { get; set; }
public DateTime? Param10UpdatedAt { get; set; }
public string Param10CreatedBy { get; set; }
public bool IsParam10Active { get; set; }
public int Param10SortOrder { get; set; }


public int Record71Id { get; set; }
public string Record71Name { get; set; }
public string Record71Description { get; set; }
public DateTime Record71CreatedAt { get; set; }
public DateTime? Record71UpdatedAt { get; set; }
public string Record71CreatedBy { get; set; }
public bool IsRecord71Active { get; set; }
public int Record71SortOrder { get; set; }


public int Item13Id { get; set; }
public string Item13Name { get; set; }
public string Item13Description { get; set; }
public DateTime Item13CreatedAt { get; set; }
public DateTime? Item13UpdatedAt { get; set; }
public string Item13CreatedBy { get; set; }
public bool IsItem13Active { get; set; }
public int Item13SortOrder { get; set; }


public int Record8Id { get; set; }
public string Record8Name { get; set; }
public string Record8Description { get; set; }
public DateTime Record8CreatedAt { get; set; }
public DateTime? Record8UpdatedAt { get; set; }
public string Record8CreatedBy { get; set; }
public bool IsRecord8Active { get; set; }
public int Record8SortOrder { get; set; }


public int Config8Id { get; set; }
public string Config8Name { get; set; }
public string Config8Description { get; set; }
public DateTime Config8CreatedAt { get; set; }
public DateTime? Config8UpdatedAt { get; set; }
public string Config8CreatedBy { get; set; }
public bool IsConfig8Active { get; set; }
public int Config8SortOrder { get; set; }


public int Param91Id { get; set; }
public string Param91Name { get; set; }
public string Param91Description { get; set; }
public DateTime Param91CreatedAt { get; set; }
public DateTime? Param91UpdatedAt { get; set; }
public string Param91CreatedBy { get; set; }
public bool IsParam91Active { get; set; }
public int Param91SortOrder { get; set; }


public int Field76Id { get; set; }
public string Field76Name { get; set; }
public string Field76Description { get; set; }
public DateTime Field76CreatedAt { get; set; }
public DateTime? Field76UpdatedAt { get; set; }
public string Field76CreatedBy { get; set; }
public bool IsField76Active { get; set; }
public int Field76SortOrder { get; set; }


public int Entry49Id { get; set; }
public string Entry49Name { get; set; }
public string Entry49Description { get; set; }
public DateTime Entry49CreatedAt { get; set; }
public DateTime? Entry49UpdatedAt { get; set; }
public string Entry49CreatedBy { get; set; }
public bool IsEntry49Active { get; set; }
public int Entry49SortOrder { get; set; }


public int Param70Id { get; set; }
public string Param70Name { get; set; }
public string Param70Description { get; set; }
public DateTime Param70CreatedAt { get; set; }
public DateTime? Param70UpdatedAt { get; set; }
public string Param70CreatedBy { get; set; }
public bool IsParam70Active { get; set; }
public int Param70SortOrder { get; set; }


public int Field19Id { get; set; }
public string Field19Name { get; set; }
public string Field19Description { get; set; }
public DateTime Field19CreatedAt { get; set; }
public DateTime? Field19UpdatedAt { get; set; }
public string Field19CreatedBy { get; set; }
public bool IsField19Active { get; set; }
public int Field19SortOrder { get; set; }


public int Config88Id { get; set; }
public string Config88Name { get; set; }
public string Config88Description { get; set; }
public DateTime Config88CreatedAt { get; set; }
public DateTime? Config88UpdatedAt { get; set; }
public string Config88CreatedBy { get; set; }
public bool IsConfig88Active { get; set; }
public int Config88SortOrder { get; set; }


public int Entry73Id { get; set; }
public string Entry73Name { get; set; }
public string Entry73Description { get; set; }
public DateTime Entry73CreatedAt { get; set; }
public DateTime? Entry73UpdatedAt { get; set; }
public string Entry73CreatedBy { get; set; }
public bool IsEntry73Active { get; set; }
public int Entry73SortOrder { get; set; }


public int Item14Id { get; set; }
public string Item14Name { get; set; }
public string Item14Description { get; set; }
public DateTime Item14CreatedAt { get; set; }
public DateTime? Item14UpdatedAt { get; set; }
public string Item14CreatedBy { get; set; }
public bool IsItem14Active { get; set; }
public int Item14SortOrder { get; set; }


public int Detail98Id { get; set; }
public string Detail98Name { get; set; }
public string Detail98Description { get; set; }
public DateTime Detail98CreatedAt { get; set; }
public DateTime? Detail98UpdatedAt { get; set; }
public string Detail98CreatedBy { get; set; }
public bool IsDetail98Active { get; set; }
public int Detail98SortOrder { get; set; }


public int Attr93Id { get; set; }
public string Attr93Name { get; set; }
public string Attr93Description { get; set; }
public DateTime Attr93CreatedAt { get; set; }
public DateTime? Attr93UpdatedAt { get; set; }
public string Attr93CreatedBy { get; set; }
public bool IsAttr93Active { get; set; }
public int Attr93SortOrder { get; set; }

    }
}