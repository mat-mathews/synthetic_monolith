using Admin.Client177;
using Admin.Core121;
using Admin.Validators336;
using Billing.Api;
using Billing.Events;
using Billing.Service432;
using Common.Contracts279;
using Common.Validators50;
using Export.Events163;
using Export.Web229;
using Integration.Client;
using Integration.Events;
using Notifications.Service475;
using Reporting.Contracts371;
using Scheduling.Models;
using Scheduling.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Service463;

namespace Security.Mappers313
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer22
    {
        private readonly Admin_Client177_Factory13 _admin_Client177_Factory13;
        private readonly Admin_Validators336_Info _admin_Validators336_Info;
        private readonly Common_Validators50_Range12 _common_Validators50_Range12;
        private readonly Common_Validators50_Processor7 _common_Validators50_Processor7;
        private readonly Export_Web229_Helper1 _export_Web229_Helper1;
        private readonly Export_Web229_Builder4 _export_Web229_Builder4;
        private readonly Integration_Events_Command5 _integration_Events_Command5;
        private readonly Billing_Service432_Helper14 _billing_Service432_Helper14;

        public Consumer22(Admin_Client177_Factory13 admin_Client177_Factory13, Admin_Validators336_Info admin_Validators336_Info, Common_Validators50_Range12 common_Validators50_Range12, Common_Validators50_Processor7 common_Validators50_Processor7, Export_Web229_Helper1 export_Web229_Helper1, Export_Web229_Builder4 export_Web229_Builder4, Integration_Events_Command5 integration_Events_Command5, Billing_Service432_Helper14 billing_Service432_Helper14)
        {
            _admin_Client177_Factory13 = admin_Client177_Factory13 ?? throw new ArgumentNullException(nameof(admin_Client177_Factory13));
            _admin_Validators336_Info = admin_Validators336_Info ?? throw new ArgumentNullException(nameof(admin_Validators336_Info));
            _common_Validators50_Range12 = common_Validators50_Range12 ?? throw new ArgumentNullException(nameof(common_Validators50_Range12));
            _common_Validators50_Processor7 = common_Validators50_Processor7 ?? throw new ArgumentNullException(nameof(common_Validators50_Processor7));
            _export_Web229_Helper1 = export_Web229_Helper1 ?? throw new ArgumentNullException(nameof(export_Web229_Helper1));
            _export_Web229_Builder4 = export_Web229_Builder4 ?? throw new ArgumentNullException(nameof(export_Web229_Builder4));
            _integration_Events_Command5 = integration_Events_Command5 ?? throw new ArgumentNullException(nameof(integration_Events_Command5));
            _billing_Service432_Helper14 = billing_Service432_Helper14 ?? throw new ArgumentNullException(nameof(billing_Service432_Helper14));
        }

        public Admin_Client177_Factory13 GetAdmin_Client177_Factory13() => _admin_Client177_Factory13;
        public Admin_Validators336_Info GetAdmin_Validators336_Info() => _admin_Validators336_Info;
        public Common_Validators50_Range12 GetCommon_Validators50_Range12() => _common_Validators50_Range12;
        public Common_Validators50_Processor7 GetCommon_Validators50_Processor7() => _common_Validators50_Processor7;
        public Export_Web229_Helper1 GetExport_Web229_Helper1() => _export_Web229_Helper1;
        public Export_Web229_Builder4 GetExport_Web229_Builder4() => _export_Web229_Builder4;
        public Integration_Events_Command5 GetIntegration_Events_Command5() => _integration_Events_Command5;
        public Billing_Service432_Helper14 GetBilling_Service432_Helper14() => _billing_Service432_Helper14;

/// <summary>
/// Validates the Consumer22 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer22(Consumer22Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer22));
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
/// Processes the Consumer22 operation asynchronously.
/// </summary>
public async Task<Consumer22Result> ProcessConsumer22Async(
    Consumer22Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer22), request.Id);

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
            return new Consumer22Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer22));
        return new Consumer22Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer22));
        return new Consumer22Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer22 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer22Dto>> GetConsumer22ListAsync(
    Consumer22Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer22Entity>().AsQueryable();

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
        .Select(x => new Consumer22Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer22Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer22Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer22Service(
    ILogger<Consumer22Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer22:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer22 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer22Data> GetCachedConsumer22Async(string key)
{
    var cacheKey = $"Consumer22_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer22Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer22SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Field38Id { get; set; }
public string Field38Name { get; set; }
public string Field38Description { get; set; }
public DateTime Field38CreatedAt { get; set; }
public DateTime? Field38UpdatedAt { get; set; }
public string Field38CreatedBy { get; set; }
public bool IsField38Active { get; set; }
public int Field38SortOrder { get; set; }


public int Item10Id { get; set; }
public string Item10Name { get; set; }
public string Item10Description { get; set; }
public DateTime Item10CreatedAt { get; set; }
public DateTime? Item10UpdatedAt { get; set; }
public string Item10CreatedBy { get; set; }
public bool IsItem10Active { get; set; }
public int Item10SortOrder { get; set; }


public int Attr92Id { get; set; }
public string Attr92Name { get; set; }
public string Attr92Description { get; set; }
public DateTime Attr92CreatedAt { get; set; }
public DateTime? Attr92UpdatedAt { get; set; }
public string Attr92CreatedBy { get; set; }
public bool IsAttr92Active { get; set; }
public int Attr92SortOrder { get; set; }


public int Record70Id { get; set; }
public string Record70Name { get; set; }
public string Record70Description { get; set; }
public DateTime Record70CreatedAt { get; set; }
public DateTime? Record70UpdatedAt { get; set; }
public string Record70CreatedBy { get; set; }
public bool IsRecord70Active { get; set; }
public int Record70SortOrder { get; set; }


public int Item9Id { get; set; }
public string Item9Name { get; set; }
public string Item9Description { get; set; }
public DateTime Item9CreatedAt { get; set; }
public DateTime? Item9UpdatedAt { get; set; }
public string Item9CreatedBy { get; set; }
public bool IsItem9Active { get; set; }
public int Item9SortOrder { get; set; }


public int Attr64Id { get; set; }
public string Attr64Name { get; set; }
public string Attr64Description { get; set; }
public DateTime Attr64CreatedAt { get; set; }
public DateTime? Attr64UpdatedAt { get; set; }
public string Attr64CreatedBy { get; set; }
public bool IsAttr64Active { get; set; }
public int Attr64SortOrder { get; set; }


public int Field27Id { get; set; }
public string Field27Name { get; set; }
public string Field27Description { get; set; }
public DateTime Field27CreatedAt { get; set; }
public DateTime? Field27UpdatedAt { get; set; }
public string Field27CreatedBy { get; set; }
public bool IsField27Active { get; set; }
public int Field27SortOrder { get; set; }


public int Entry9Id { get; set; }
public string Entry9Name { get; set; }
public string Entry9Description { get; set; }
public DateTime Entry9CreatedAt { get; set; }
public DateTime? Entry9UpdatedAt { get; set; }
public string Entry9CreatedBy { get; set; }
public bool IsEntry9Active { get; set; }
public int Entry9SortOrder { get; set; }


public int Detail24Id { get; set; }
public string Detail24Name { get; set; }
public string Detail24Description { get; set; }
public DateTime Detail24CreatedAt { get; set; }
public DateTime? Detail24UpdatedAt { get; set; }
public string Detail24CreatedBy { get; set; }
public bool IsDetail24Active { get; set; }
public int Detail24SortOrder { get; set; }


public int Record85Id { get; set; }
public string Record85Name { get; set; }
public string Record85Description { get; set; }
public DateTime Record85CreatedAt { get; set; }
public DateTime? Record85UpdatedAt { get; set; }
public string Record85CreatedBy { get; set; }
public bool IsRecord85Active { get; set; }
public int Record85SortOrder { get; set; }


public int Record93Id { get; set; }
public string Record93Name { get; set; }
public string Record93Description { get; set; }
public DateTime Record93CreatedAt { get; set; }
public DateTime? Record93UpdatedAt { get; set; }
public string Record93CreatedBy { get; set; }
public bool IsRecord93Active { get; set; }
public int Record93SortOrder { get; set; }


public int Record48Id { get; set; }
public string Record48Name { get; set; }
public string Record48Description { get; set; }
public DateTime Record48CreatedAt { get; set; }
public DateTime? Record48UpdatedAt { get; set; }
public string Record48CreatedBy { get; set; }
public bool IsRecord48Active { get; set; }
public int Record48SortOrder { get; set; }


public int Entry27Id { get; set; }
public string Entry27Name { get; set; }
public string Entry27Description { get; set; }
public DateTime Entry27CreatedAt { get; set; }
public DateTime? Entry27UpdatedAt { get; set; }
public string Entry27CreatedBy { get; set; }
public bool IsEntry27Active { get; set; }
public int Entry27SortOrder { get; set; }


public int Config55Id { get; set; }
public string Config55Name { get; set; }
public string Config55Description { get; set; }
public DateTime Config55CreatedAt { get; set; }
public DateTime? Config55UpdatedAt { get; set; }
public string Config55CreatedBy { get; set; }
public bool IsConfig55Active { get; set; }
public int Config55SortOrder { get; set; }


public int Config63Id { get; set; }
public string Config63Name { get; set; }
public string Config63Description { get; set; }
public DateTime Config63CreatedAt { get; set; }
public DateTime? Config63UpdatedAt { get; set; }
public string Config63CreatedBy { get; set; }
public bool IsConfig63Active { get; set; }
public int Config63SortOrder { get; set; }


public int Detail76Id { get; set; }
public string Detail76Name { get; set; }
public string Detail76Description { get; set; }
public DateTime Detail76CreatedAt { get; set; }
public DateTime? Detail76UpdatedAt { get; set; }
public string Detail76CreatedBy { get; set; }
public bool IsDetail76Active { get; set; }
public int Detail76SortOrder { get; set; }


public int Param10Id { get; set; }
public string Param10Name { get; set; }
public string Param10Description { get; set; }
public DateTime Param10CreatedAt { get; set; }
public DateTime? Param10UpdatedAt { get; set; }
public string Param10CreatedBy { get; set; }
public bool IsParam10Active { get; set; }
public int Param10SortOrder { get; set; }


public int Entry33Id { get; set; }
public string Entry33Name { get; set; }
public string Entry33Description { get; set; }
public DateTime Entry33CreatedAt { get; set; }
public DateTime? Entry33UpdatedAt { get; set; }
public string Entry33CreatedBy { get; set; }
public bool IsEntry33Active { get; set; }
public int Entry33SortOrder { get; set; }


public int Param6Id { get; set; }
public string Param6Name { get; set; }
public string Param6Description { get; set; }
public DateTime Param6CreatedAt { get; set; }
public DateTime? Param6UpdatedAt { get; set; }
public string Param6CreatedBy { get; set; }
public bool IsParam6Active { get; set; }
public int Param6SortOrder { get; set; }


public int Detail64Id { get; set; }
public string Detail64Name { get; set; }
public string Detail64Description { get; set; }
public DateTime Detail64CreatedAt { get; set; }
public DateTime? Detail64UpdatedAt { get; set; }
public string Detail64CreatedBy { get; set; }
public bool IsDetail64Active { get; set; }
public int Detail64SortOrder { get; set; }


public int Record28Id { get; set; }
public string Record28Name { get; set; }
public string Record28Description { get; set; }
public DateTime Record28CreatedAt { get; set; }
public DateTime? Record28UpdatedAt { get; set; }
public string Record28CreatedBy { get; set; }
public bool IsRecord28Active { get; set; }
public int Record28SortOrder { get; set; }


public int Record74Id { get; set; }
public string Record74Name { get; set; }
public string Record74Description { get; set; }
public DateTime Record74CreatedAt { get; set; }
public DateTime? Record74UpdatedAt { get; set; }
public string Record74CreatedBy { get; set; }
public bool IsRecord74Active { get; set; }
public int Record74SortOrder { get; set; }


public int Param37Id { get; set; }
public string Param37Name { get; set; }
public string Param37Description { get; set; }
public DateTime Param37CreatedAt { get; set; }
public DateTime? Param37UpdatedAt { get; set; }
public string Param37CreatedBy { get; set; }
public bool IsParam37Active { get; set; }
public int Param37SortOrder { get; set; }


public int Record38Id { get; set; }
public string Record38Name { get; set; }
public string Record38Description { get; set; }
public DateTime Record38CreatedAt { get; set; }
public DateTime? Record38UpdatedAt { get; set; }
public string Record38CreatedBy { get; set; }
public bool IsRecord38Active { get; set; }
public int Record38SortOrder { get; set; }


public int Detail28Id { get; set; }
public string Detail28Name { get; set; }
public string Detail28Description { get; set; }
public DateTime Detail28CreatedAt { get; set; }
public DateTime? Detail28UpdatedAt { get; set; }
public string Detail28CreatedBy { get; set; }
public bool IsDetail28Active { get; set; }
public int Detail28SortOrder { get; set; }


public int Field83Id { get; set; }
public string Field83Name { get; set; }
public string Field83Description { get; set; }
public DateTime Field83CreatedAt { get; set; }
public DateTime? Field83UpdatedAt { get; set; }
public string Field83CreatedBy { get; set; }
public bool IsField83Active { get; set; }
public int Field83SortOrder { get; set; }


public int Param7Id { get; set; }
public string Param7Name { get; set; }
public string Param7Description { get; set; }
public DateTime Param7CreatedAt { get; set; }
public DateTime? Param7UpdatedAt { get; set; }
public string Param7CreatedBy { get; set; }
public bool IsParam7Active { get; set; }
public int Param7SortOrder { get; set; }


public int Attr94Id { get; set; }
public string Attr94Name { get; set; }
public string Attr94Description { get; set; }
public DateTime Attr94CreatedAt { get; set; }
public DateTime? Attr94UpdatedAt { get; set; }
public string Attr94CreatedBy { get; set; }
public bool IsAttr94Active { get; set; }
public int Attr94SortOrder { get; set; }


public int Param38Id { get; set; }
public string Param38Name { get; set; }
public string Param38Description { get; set; }
public DateTime Param38CreatedAt { get; set; }
public DateTime? Param38UpdatedAt { get; set; }
public string Param38CreatedBy { get; set; }
public bool IsParam38Active { get; set; }
public int Param38SortOrder { get; set; }


public int Item92Id { get; set; }
public string Item92Name { get; set; }
public string Item92Description { get; set; }
public DateTime Item92CreatedAt { get; set; }
public DateTime? Item92UpdatedAt { get; set; }
public string Item92CreatedBy { get; set; }
public bool IsItem92Active { get; set; }
public int Item92SortOrder { get; set; }


public int Record84Id { get; set; }
public string Record84Name { get; set; }
public string Record84Description { get; set; }
public DateTime Record84CreatedAt { get; set; }
public DateTime? Record84UpdatedAt { get; set; }
public string Record84CreatedBy { get; set; }
public bool IsRecord84Active { get; set; }
public int Record84SortOrder { get; set; }


public int Detail3Id { get; set; }
public string Detail3Name { get; set; }
public string Detail3Description { get; set; }
public DateTime Detail3CreatedAt { get; set; }
public DateTime? Detail3UpdatedAt { get; set; }
public string Detail3CreatedBy { get; set; }
public bool IsDetail3Active { get; set; }
public int Detail3SortOrder { get; set; }


public int Param14Id { get; set; }
public string Param14Name { get; set; }
public string Param14Description { get; set; }
public DateTime Param14CreatedAt { get; set; }
public DateTime? Param14UpdatedAt { get; set; }
public string Param14CreatedBy { get; set; }
public bool IsParam14Active { get; set; }
public int Param14SortOrder { get; set; }


public int Attr74Id { get; set; }
public string Attr74Name { get; set; }
public string Attr74Description { get; set; }
public DateTime Attr74CreatedAt { get; set; }
public DateTime? Attr74UpdatedAt { get; set; }
public string Attr74CreatedBy { get; set; }
public bool IsAttr74Active { get; set; }
public int Attr74SortOrder { get; set; }


public int Attr47Id { get; set; }
public string Attr47Name { get; set; }
public string Attr47Description { get; set; }
public DateTime Attr47CreatedAt { get; set; }
public DateTime? Attr47UpdatedAt { get; set; }
public string Attr47CreatedBy { get; set; }
public bool IsAttr47Active { get; set; }
public int Attr47SortOrder { get; set; }


public int Config51Id { get; set; }
public string Config51Name { get; set; }
public string Config51Description { get; set; }
public DateTime Config51CreatedAt { get; set; }
public DateTime? Config51UpdatedAt { get; set; }
public string Config51CreatedBy { get; set; }
public bool IsConfig51Active { get; set; }
public int Config51SortOrder { get; set; }


public int Field57Id { get; set; }
public string Field57Name { get; set; }
public string Field57Description { get; set; }
public DateTime Field57CreatedAt { get; set; }
public DateTime? Field57UpdatedAt { get; set; }
public string Field57CreatedBy { get; set; }
public bool IsField57Active { get; set; }
public int Field57SortOrder { get; set; }


public int Entry81Id { get; set; }
public string Entry81Name { get; set; }
public string Entry81Description { get; set; }
public DateTime Entry81CreatedAt { get; set; }
public DateTime? Entry81UpdatedAt { get; set; }
public string Entry81CreatedBy { get; set; }
public bool IsEntry81Active { get; set; }
public int Entry81SortOrder { get; set; }


public int Item34Id { get; set; }
public string Item34Name { get; set; }
public string Item34Description { get; set; }
public DateTime Item34CreatedAt { get; set; }
public DateTime? Item34UpdatedAt { get; set; }
public string Item34CreatedBy { get; set; }
public bool IsItem34Active { get; set; }
public int Item34SortOrder { get; set; }


public int Item12Id { get; set; }
public string Item12Name { get; set; }
public string Item12Description { get; set; }
public DateTime Item12CreatedAt { get; set; }
public DateTime? Item12UpdatedAt { get; set; }
public string Item12CreatedBy { get; set; }
public bool IsItem12Active { get; set; }
public int Item12SortOrder { get; set; }


public int Entry43Id { get; set; }
public string Entry43Name { get; set; }
public string Entry43Description { get; set; }
public DateTime Entry43CreatedAt { get; set; }
public DateTime? Entry43UpdatedAt { get; set; }
public string Entry43CreatedBy { get; set; }
public bool IsEntry43Active { get; set; }
public int Entry43SortOrder { get; set; }


public int Param65Id { get; set; }
public string Param65Name { get; set; }
public string Param65Description { get; set; }
public DateTime Param65CreatedAt { get; set; }
public DateTime? Param65UpdatedAt { get; set; }
public string Param65CreatedBy { get; set; }
public bool IsParam65Active { get; set; }
public int Param65SortOrder { get; set; }


public int Attr28Id { get; set; }
public string Attr28Name { get; set; }
public string Attr28Description { get; set; }
public DateTime Attr28CreatedAt { get; set; }
public DateTime? Attr28UpdatedAt { get; set; }
public string Attr28CreatedBy { get; set; }
public bool IsAttr28Active { get; set; }
public int Attr28SortOrder { get; set; }


public int Config71Id { get; set; }
public string Config71Name { get; set; }
public string Config71Description { get; set; }
public DateTime Config71CreatedAt { get; set; }
public DateTime? Config71UpdatedAt { get; set; }
public string Config71CreatedBy { get; set; }
public bool IsConfig71Active { get; set; }
public int Config71SortOrder { get; set; }


public int Item1Id { get; set; }
public string Item1Name { get; set; }
public string Item1Description { get; set; }
public DateTime Item1CreatedAt { get; set; }
public DateTime? Item1UpdatedAt { get; set; }
public string Item1CreatedBy { get; set; }
public bool IsItem1Active { get; set; }
public int Item1SortOrder { get; set; }

    }
}