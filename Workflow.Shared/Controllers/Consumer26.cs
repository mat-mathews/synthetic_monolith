using Admin.Client346;
using Admin.Data117;
using Admin.Events235;
using Admin.Validators431;
using Admin.Web46;
using Auth.Core2;
using Common.Processors245;
using Documents.Shared334;
using Documents.Validators;
using Export.Service30;
using Imaging.Api127;
using Import.Service429;
using Notifications.Models466;
using Reporting.Mappers239;
using Scheduling.Shared39;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Contracts32;
using Workflow.Validators138;

namespace Workflow.Shared
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer26
    {
        private readonly Admin_Data117_Builder7 _admin_Data117_Builder7;
        private readonly Admin_Data117_Command6 _admin_Data117_Command6;
        private readonly Admin_Events235_Request3 _admin_Events235_Request3;
        private readonly Admin_Events235_Manager1 _admin_Events235_Manager1;
        private readonly Export_Service30_Provider9 _export_Service30_Provider9;
        private readonly INotifications_Models466_Service3 _iNotifications_Models466_Service3;
        private readonly IImport_Service429_Repository8 _iImport_Service429_Repository8;
        private readonly Import_Service429_Controller _import_Service429_Controller;

        public Consumer26(Admin_Data117_Builder7 admin_Data117_Builder7, Admin_Data117_Command6 admin_Data117_Command6, Admin_Events235_Request3 admin_Events235_Request3, Admin_Events235_Manager1 admin_Events235_Manager1, Export_Service30_Provider9 export_Service30_Provider9, INotifications_Models466_Service3 iNotifications_Models466_Service3, IImport_Service429_Repository8 iImport_Service429_Repository8, Import_Service429_Controller import_Service429_Controller)
        {
            _admin_Data117_Builder7 = admin_Data117_Builder7 ?? throw new ArgumentNullException(nameof(admin_Data117_Builder7));
            _admin_Data117_Command6 = admin_Data117_Command6 ?? throw new ArgumentNullException(nameof(admin_Data117_Command6));
            _admin_Events235_Request3 = admin_Events235_Request3 ?? throw new ArgumentNullException(nameof(admin_Events235_Request3));
            _admin_Events235_Manager1 = admin_Events235_Manager1 ?? throw new ArgumentNullException(nameof(admin_Events235_Manager1));
            _export_Service30_Provider9 = export_Service30_Provider9 ?? throw new ArgumentNullException(nameof(export_Service30_Provider9));
            _iNotifications_Models466_Service3 = iNotifications_Models466_Service3 ?? throw new ArgumentNullException(nameof(iNotifications_Models466_Service3));
            _iImport_Service429_Repository8 = iImport_Service429_Repository8 ?? throw new ArgumentNullException(nameof(iImport_Service429_Repository8));
            _import_Service429_Controller = import_Service429_Controller ?? throw new ArgumentNullException(nameof(import_Service429_Controller));
        }

        public Admin_Data117_Builder7 GetAdmin_Data117_Builder7() => _admin_Data117_Builder7;
        public Admin_Data117_Command6 GetAdmin_Data117_Command6() => _admin_Data117_Command6;
        public Admin_Events235_Request3 GetAdmin_Events235_Request3() => _admin_Events235_Request3;
        public Admin_Events235_Manager1 GetAdmin_Events235_Manager1() => _admin_Events235_Manager1;
        public Export_Service30_Provider9 GetExport_Service30_Provider9() => _export_Service30_Provider9;
        public INotifications_Models466_Service3 GetINotifications_Models466_Service3() => _iNotifications_Models466_Service3;
        public IImport_Service429_Repository8 GetIImport_Service429_Repository8() => _iImport_Service429_Repository8;
        public Import_Service429_Controller GetImport_Service429_Controller() => _import_Service429_Controller;

/// <summary>
/// Validates the Consumer26 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer26(Consumer26Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer26));
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
/// Processes the Consumer26 operation asynchronously.
/// </summary>
public async Task<Consumer26Result> ProcessConsumer26Async(
    Consumer26Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer26), request.Id);

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
            return new Consumer26Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer26));
        return new Consumer26Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer26));
        return new Consumer26Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer26 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer26Dto>> GetConsumer26ListAsync(
    Consumer26Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer26Entity>().AsQueryable();

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
        .Select(x => new Consumer26Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer26Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer26Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer26Service(
    ILogger<Consumer26Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer26:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer26 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer26Data> GetCachedConsumer26Async(string key)
{
    var cacheKey = $"Consumer26_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer26Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer26SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Entry53Id { get; set; }
public string Entry53Name { get; set; }
public string Entry53Description { get; set; }
public DateTime Entry53CreatedAt { get; set; }
public DateTime? Entry53UpdatedAt { get; set; }
public string Entry53CreatedBy { get; set; }
public bool IsEntry53Active { get; set; }
public int Entry53SortOrder { get; set; }


public int Detail58Id { get; set; }
public string Detail58Name { get; set; }
public string Detail58Description { get; set; }
public DateTime Detail58CreatedAt { get; set; }
public DateTime? Detail58UpdatedAt { get; set; }
public string Detail58CreatedBy { get; set; }
public bool IsDetail58Active { get; set; }
public int Detail58SortOrder { get; set; }


public int Record39Id { get; set; }
public string Record39Name { get; set; }
public string Record39Description { get; set; }
public DateTime Record39CreatedAt { get; set; }
public DateTime? Record39UpdatedAt { get; set; }
public string Record39CreatedBy { get; set; }
public bool IsRecord39Active { get; set; }
public int Record39SortOrder { get; set; }


public int Record50Id { get; set; }
public string Record50Name { get; set; }
public string Record50Description { get; set; }
public DateTime Record50CreatedAt { get; set; }
public DateTime? Record50UpdatedAt { get; set; }
public string Record50CreatedBy { get; set; }
public bool IsRecord50Active { get; set; }
public int Record50SortOrder { get; set; }


public int Record70Id { get; set; }
public string Record70Name { get; set; }
public string Record70Description { get; set; }
public DateTime Record70CreatedAt { get; set; }
public DateTime? Record70UpdatedAt { get; set; }
public string Record70CreatedBy { get; set; }
public bool IsRecord70Active { get; set; }
public int Record70SortOrder { get; set; }


public int Param57Id { get; set; }
public string Param57Name { get; set; }
public string Param57Description { get; set; }
public DateTime Param57CreatedAt { get; set; }
public DateTime? Param57UpdatedAt { get; set; }
public string Param57CreatedBy { get; set; }
public bool IsParam57Active { get; set; }
public int Param57SortOrder { get; set; }


public int Field52Id { get; set; }
public string Field52Name { get; set; }
public string Field52Description { get; set; }
public DateTime Field52CreatedAt { get; set; }
public DateTime? Field52UpdatedAt { get; set; }
public string Field52CreatedBy { get; set; }
public bool IsField52Active { get; set; }
public int Field52SortOrder { get; set; }


public int Record19Id { get; set; }
public string Record19Name { get; set; }
public string Record19Description { get; set; }
public DateTime Record19CreatedAt { get; set; }
public DateTime? Record19UpdatedAt { get; set; }
public string Record19CreatedBy { get; set; }
public bool IsRecord19Active { get; set; }
public int Record19SortOrder { get; set; }


public int Param12Id { get; set; }
public string Param12Name { get; set; }
public string Param12Description { get; set; }
public DateTime Param12CreatedAt { get; set; }
public DateTime? Param12UpdatedAt { get; set; }
public string Param12CreatedBy { get; set; }
public bool IsParam12Active { get; set; }
public int Param12SortOrder { get; set; }


public int Record57Id { get; set; }
public string Record57Name { get; set; }
public string Record57Description { get; set; }
public DateTime Record57CreatedAt { get; set; }
public DateTime? Record57UpdatedAt { get; set; }
public string Record57CreatedBy { get; set; }
public bool IsRecord57Active { get; set; }
public int Record57SortOrder { get; set; }


public int Attr43Id { get; set; }
public string Attr43Name { get; set; }
public string Attr43Description { get; set; }
public DateTime Attr43CreatedAt { get; set; }
public DateTime? Attr43UpdatedAt { get; set; }
public string Attr43CreatedBy { get; set; }
public bool IsAttr43Active { get; set; }
public int Attr43SortOrder { get; set; }


public int Detail4Id { get; set; }
public string Detail4Name { get; set; }
public string Detail4Description { get; set; }
public DateTime Detail4CreatedAt { get; set; }
public DateTime? Detail4UpdatedAt { get; set; }
public string Detail4CreatedBy { get; set; }
public bool IsDetail4Active { get; set; }
public int Detail4SortOrder { get; set; }


public int Param93Id { get; set; }
public string Param93Name { get; set; }
public string Param93Description { get; set; }
public DateTime Param93CreatedAt { get; set; }
public DateTime? Param93UpdatedAt { get; set; }
public string Param93CreatedBy { get; set; }
public bool IsParam93Active { get; set; }
public int Param93SortOrder { get; set; }


public int Field43Id { get; set; }
public string Field43Name { get; set; }
public string Field43Description { get; set; }
public DateTime Field43CreatedAt { get; set; }
public DateTime? Field43UpdatedAt { get; set; }
public string Field43CreatedBy { get; set; }
public bool IsField43Active { get; set; }
public int Field43SortOrder { get; set; }


public int Config77Id { get; set; }
public string Config77Name { get; set; }
public string Config77Description { get; set; }
public DateTime Config77CreatedAt { get; set; }
public DateTime? Config77UpdatedAt { get; set; }
public string Config77CreatedBy { get; set; }
public bool IsConfig77Active { get; set; }
public int Config77SortOrder { get; set; }


public int Record13Id { get; set; }
public string Record13Name { get; set; }
public string Record13Description { get; set; }
public DateTime Record13CreatedAt { get; set; }
public DateTime? Record13UpdatedAt { get; set; }
public string Record13CreatedBy { get; set; }
public bool IsRecord13Active { get; set; }
public int Record13SortOrder { get; set; }


public int Field2Id { get; set; }
public string Field2Name { get; set; }
public string Field2Description { get; set; }
public DateTime Field2CreatedAt { get; set; }
public DateTime? Field2UpdatedAt { get; set; }
public string Field2CreatedBy { get; set; }
public bool IsField2Active { get; set; }
public int Field2SortOrder { get; set; }


public int Item75Id { get; set; }
public string Item75Name { get; set; }
public string Item75Description { get; set; }
public DateTime Item75CreatedAt { get; set; }
public DateTime? Item75UpdatedAt { get; set; }
public string Item75CreatedBy { get; set; }
public bool IsItem75Active { get; set; }
public int Item75SortOrder { get; set; }


public int Item85Id { get; set; }
public string Item85Name { get; set; }
public string Item85Description { get; set; }
public DateTime Item85CreatedAt { get; set; }
public DateTime? Item85UpdatedAt { get; set; }
public string Item85CreatedBy { get; set; }
public bool IsItem85Active { get; set; }
public int Item85SortOrder { get; set; }


public int Param37Id { get; set; }
public string Param37Name { get; set; }
public string Param37Description { get; set; }
public DateTime Param37CreatedAt { get; set; }
public DateTime? Param37UpdatedAt { get; set; }
public string Param37CreatedBy { get; set; }
public bool IsParam37Active { get; set; }
public int Param37SortOrder { get; set; }


public int Attr53Id { get; set; }
public string Attr53Name { get; set; }
public string Attr53Description { get; set; }
public DateTime Attr53CreatedAt { get; set; }
public DateTime? Attr53UpdatedAt { get; set; }
public string Attr53CreatedBy { get; set; }
public bool IsAttr53Active { get; set; }
public int Attr53SortOrder { get; set; }


public int Attr31Id { get; set; }
public string Attr31Name { get; set; }
public string Attr31Description { get; set; }
public DateTime Attr31CreatedAt { get; set; }
public DateTime? Attr31UpdatedAt { get; set; }
public string Attr31CreatedBy { get; set; }
public bool IsAttr31Active { get; set; }
public int Attr31SortOrder { get; set; }


public int Config5Id { get; set; }
public string Config5Name { get; set; }
public string Config5Description { get; set; }
public DateTime Config5CreatedAt { get; set; }
public DateTime? Config5UpdatedAt { get; set; }
public string Config5CreatedBy { get; set; }
public bool IsConfig5Active { get; set; }
public int Config5SortOrder { get; set; }


public int Param83Id { get; set; }
public string Param83Name { get; set; }
public string Param83Description { get; set; }
public DateTime Param83CreatedAt { get; set; }
public DateTime? Param83UpdatedAt { get; set; }
public string Param83CreatedBy { get; set; }
public bool IsParam83Active { get; set; }
public int Param83SortOrder { get; set; }


public int Field47Id { get; set; }
public string Field47Name { get; set; }
public string Field47Description { get; set; }
public DateTime Field47CreatedAt { get; set; }
public DateTime? Field47UpdatedAt { get; set; }
public string Field47CreatedBy { get; set; }
public bool IsField47Active { get; set; }
public int Field47SortOrder { get; set; }


public int Config33Id { get; set; }
public string Config33Name { get; set; }
public string Config33Description { get; set; }
public DateTime Config33CreatedAt { get; set; }
public DateTime? Config33UpdatedAt { get; set; }
public string Config33CreatedBy { get; set; }
public bool IsConfig33Active { get; set; }
public int Config33SortOrder { get; set; }


public int Param46Id { get; set; }
public string Param46Name { get; set; }
public string Param46Description { get; set; }
public DateTime Param46CreatedAt { get; set; }
public DateTime? Param46UpdatedAt { get; set; }
public string Param46CreatedBy { get; set; }
public bool IsParam46Active { get; set; }
public int Param46SortOrder { get; set; }


public int Detail54Id { get; set; }
public string Detail54Name { get; set; }
public string Detail54Description { get; set; }
public DateTime Detail54CreatedAt { get; set; }
public DateTime? Detail54UpdatedAt { get; set; }
public string Detail54CreatedBy { get; set; }
public bool IsDetail54Active { get; set; }
public int Detail54SortOrder { get; set; }


public int Record11Id { get; set; }
public string Record11Name { get; set; }
public string Record11Description { get; set; }
public DateTime Record11CreatedAt { get; set; }
public DateTime? Record11UpdatedAt { get; set; }
public string Record11CreatedBy { get; set; }
public bool IsRecord11Active { get; set; }
public int Record11SortOrder { get; set; }


public int Param64Id { get; set; }
public string Param64Name { get; set; }
public string Param64Description { get; set; }
public DateTime Param64CreatedAt { get; set; }
public DateTime? Param64UpdatedAt { get; set; }
public string Param64CreatedBy { get; set; }
public bool IsParam64Active { get; set; }
public int Param64SortOrder { get; set; }


public int Item3Id { get; set; }
public string Item3Name { get; set; }
public string Item3Description { get; set; }
public DateTime Item3CreatedAt { get; set; }
public DateTime? Item3UpdatedAt { get; set; }
public string Item3CreatedBy { get; set; }
public bool IsItem3Active { get; set; }
public int Item3SortOrder { get; set; }


public int Item35Id { get; set; }
public string Item35Name { get; set; }
public string Item35Description { get; set; }
public DateTime Item35CreatedAt { get; set; }
public DateTime? Item35UpdatedAt { get; set; }
public string Item35CreatedBy { get; set; }
public bool IsItem35Active { get; set; }
public int Item35SortOrder { get; set; }


public int Attr19Id { get; set; }
public string Attr19Name { get; set; }
public string Attr19Description { get; set; }
public DateTime Attr19CreatedAt { get; set; }
public DateTime? Attr19UpdatedAt { get; set; }
public string Attr19CreatedBy { get; set; }
public bool IsAttr19Active { get; set; }
public int Attr19SortOrder { get; set; }


public int Detail56Id { get; set; }
public string Detail56Name { get; set; }
public string Detail56Description { get; set; }
public DateTime Detail56CreatedAt { get; set; }
public DateTime? Detail56UpdatedAt { get; set; }
public string Detail56CreatedBy { get; set; }
public bool IsDetail56Active { get; set; }
public int Detail56SortOrder { get; set; }


public int Record51Id { get; set; }
public string Record51Name { get; set; }
public string Record51Description { get; set; }
public DateTime Record51CreatedAt { get; set; }
public DateTime? Record51UpdatedAt { get; set; }
public string Record51CreatedBy { get; set; }
public bool IsRecord51Active { get; set; }
public int Record51SortOrder { get; set; }


public int Config95Id { get; set; }
public string Config95Name { get; set; }
public string Config95Description { get; set; }
public DateTime Config95CreatedAt { get; set; }
public DateTime? Config95UpdatedAt { get; set; }
public string Config95CreatedBy { get; set; }
public bool IsConfig95Active { get; set; }
public int Config95SortOrder { get; set; }


public int Param8Id { get; set; }
public string Param8Name { get; set; }
public string Param8Description { get; set; }
public DateTime Param8CreatedAt { get; set; }
public DateTime? Param8UpdatedAt { get; set; }
public string Param8CreatedBy { get; set; }
public bool IsParam8Active { get; set; }
public int Param8SortOrder { get; set; }


public int Item79Id { get; set; }
public string Item79Name { get; set; }
public string Item79Description { get; set; }
public DateTime Item79CreatedAt { get; set; }
public DateTime? Item79UpdatedAt { get; set; }
public string Item79CreatedBy { get; set; }
public bool IsItem79Active { get; set; }
public int Item79SortOrder { get; set; }


public int Field31Id { get; set; }
public string Field31Name { get; set; }
public string Field31Description { get; set; }
public DateTime Field31CreatedAt { get; set; }
public DateTime? Field31UpdatedAt { get; set; }
public string Field31CreatedBy { get; set; }
public bool IsField31Active { get; set; }
public int Field31SortOrder { get; set; }


public int Config34Id { get; set; }
public string Config34Name { get; set; }
public string Config34Description { get; set; }
public DateTime Config34CreatedAt { get; set; }
public DateTime? Config34UpdatedAt { get; set; }
public string Config34CreatedBy { get; set; }
public bool IsConfig34Active { get; set; }
public int Config34SortOrder { get; set; }


public int Param25Id { get; set; }
public string Param25Name { get; set; }
public string Param25Description { get; set; }
public DateTime Param25CreatedAt { get; set; }
public DateTime? Param25UpdatedAt { get; set; }
public string Param25CreatedBy { get; set; }
public bool IsParam25Active { get; set; }
public int Param25SortOrder { get; set; }


public int Item73Id { get; set; }
public string Item73Name { get; set; }
public string Item73Description { get; set; }
public DateTime Item73CreatedAt { get; set; }
public DateTime? Item73UpdatedAt { get; set; }
public string Item73CreatedBy { get; set; }
public bool IsItem73Active { get; set; }
public int Item73SortOrder { get; set; }


public int Param42Id { get; set; }
public string Param42Name { get; set; }
public string Param42Description { get; set; }
public DateTime Param42CreatedAt { get; set; }
public DateTime? Param42UpdatedAt { get; set; }
public string Param42CreatedBy { get; set; }
public bool IsParam42Active { get; set; }
public int Param42SortOrder { get; set; }


public int Param6Id { get; set; }
public string Param6Name { get; set; }
public string Param6Description { get; set; }
public DateTime Param6CreatedAt { get; set; }
public DateTime? Param6UpdatedAt { get; set; }
public string Param6CreatedBy { get; set; }
public bool IsParam6Active { get; set; }
public int Param6SortOrder { get; set; }


public int Entry92Id { get; set; }
public string Entry92Name { get; set; }
public string Entry92Description { get; set; }
public DateTime Entry92CreatedAt { get; set; }
public DateTime? Entry92UpdatedAt { get; set; }
public string Entry92CreatedBy { get; set; }
public bool IsEntry92Active { get; set; }
public int Entry92SortOrder { get; set; }

    }
}