using Admin.Shared310;
using Admin.Web;
using Billing.Mappers124;
using Billing.Tests;
using DataAccess.Validators;
using Documents.Service;
using Import.Api272;
using Import.Client65;
using Integration.Api469;
using Logging.Data;
using Logging.Validators;
using Notifications.Shared380;
using Notifications.Tests;
using Reporting.Tests67;
using Security.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Contracts434;

namespace Billing.Shared
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer2
    {
        private readonly Admin_Shared310_Processor8 _admin_Shared310_Processor8;
        private readonly Notifications_Tests_Repository2 _notifications_Tests_Repository2;
        private readonly Notifications_Tests_Processor8 _notifications_Tests_Processor8;
        private readonly Notifications_Tests_Info6 _notifications_Tests_Info6;
        private readonly Import_Client65_Result6 _import_Client65_Result6;
        private readonly Import_Client65_Repository8 _import_Client65_Repository8;
        private readonly Import_Client65_Manager1 _import_Client65_Manager1;
        private readonly Notifications_Shared380_Dto _notifications_Shared380_Dto;

        public Consumer2(Admin_Shared310_Processor8 admin_Shared310_Processor8, Notifications_Tests_Repository2 notifications_Tests_Repository2, Notifications_Tests_Processor8 notifications_Tests_Processor8, Notifications_Tests_Info6 notifications_Tests_Info6, Import_Client65_Result6 import_Client65_Result6, Import_Client65_Repository8 import_Client65_Repository8, Import_Client65_Manager1 import_Client65_Manager1, Notifications_Shared380_Dto notifications_Shared380_Dto)
        {
            _admin_Shared310_Processor8 = admin_Shared310_Processor8 ?? throw new ArgumentNullException(nameof(admin_Shared310_Processor8));
            _notifications_Tests_Repository2 = notifications_Tests_Repository2 ?? throw new ArgumentNullException(nameof(notifications_Tests_Repository2));
            _notifications_Tests_Processor8 = notifications_Tests_Processor8 ?? throw new ArgumentNullException(nameof(notifications_Tests_Processor8));
            _notifications_Tests_Info6 = notifications_Tests_Info6 ?? throw new ArgumentNullException(nameof(notifications_Tests_Info6));
            _import_Client65_Result6 = import_Client65_Result6 ?? throw new ArgumentNullException(nameof(import_Client65_Result6));
            _import_Client65_Repository8 = import_Client65_Repository8 ?? throw new ArgumentNullException(nameof(import_Client65_Repository8));
            _import_Client65_Manager1 = import_Client65_Manager1 ?? throw new ArgumentNullException(nameof(import_Client65_Manager1));
            _notifications_Shared380_Dto = notifications_Shared380_Dto ?? throw new ArgumentNullException(nameof(notifications_Shared380_Dto));
        }

        public Admin_Shared310_Processor8 GetAdmin_Shared310_Processor8() => _admin_Shared310_Processor8;
        public Notifications_Tests_Repository2 GetNotifications_Tests_Repository2() => _notifications_Tests_Repository2;
        public Notifications_Tests_Processor8 GetNotifications_Tests_Processor8() => _notifications_Tests_Processor8;
        public Notifications_Tests_Info6 GetNotifications_Tests_Info6() => _notifications_Tests_Info6;
        public Import_Client65_Result6 GetImport_Client65_Result6() => _import_Client65_Result6;
        public Import_Client65_Repository8 GetImport_Client65_Repository8() => _import_Client65_Repository8;
        public Import_Client65_Manager1 GetImport_Client65_Manager1() => _import_Client65_Manager1;
        public Notifications_Shared380_Dto GetNotifications_Shared380_Dto() => _notifications_Shared380_Dto;

/// <summary>
/// Validates the Consumer2 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer2(Consumer2Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer2));
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
/// Processes the Consumer2 operation asynchronously.
/// </summary>
public async Task<Consumer2Result> ProcessConsumer2Async(
    Consumer2Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer2), request.Id);

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
            return new Consumer2Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer2));
        return new Consumer2Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer2));
        return new Consumer2Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer2 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer2Dto>> GetConsumer2ListAsync(
    Consumer2Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer2Entity>().AsQueryable();

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
        .Select(x => new Consumer2Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer2Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer2Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer2Service(
    ILogger<Consumer2Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer2:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer2 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer2Data> GetCachedConsumer2Async(string key)
{
    var cacheKey = $"Consumer2_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer2Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer2SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Attr64Id { get; set; }
public string Attr64Name { get; set; }
public string Attr64Description { get; set; }
public DateTime Attr64CreatedAt { get; set; }
public DateTime? Attr64UpdatedAt { get; set; }
public string Attr64CreatedBy { get; set; }
public bool IsAttr64Active { get; set; }
public int Attr64SortOrder { get; set; }


public int Record20Id { get; set; }
public string Record20Name { get; set; }
public string Record20Description { get; set; }
public DateTime Record20CreatedAt { get; set; }
public DateTime? Record20UpdatedAt { get; set; }
public string Record20CreatedBy { get; set; }
public bool IsRecord20Active { get; set; }
public int Record20SortOrder { get; set; }


public int Detail50Id { get; set; }
public string Detail50Name { get; set; }
public string Detail50Description { get; set; }
public DateTime Detail50CreatedAt { get; set; }
public DateTime? Detail50UpdatedAt { get; set; }
public string Detail50CreatedBy { get; set; }
public bool IsDetail50Active { get; set; }
public int Detail50SortOrder { get; set; }


public int Attr76Id { get; set; }
public string Attr76Name { get; set; }
public string Attr76Description { get; set; }
public DateTime Attr76CreatedAt { get; set; }
public DateTime? Attr76UpdatedAt { get; set; }
public string Attr76CreatedBy { get; set; }
public bool IsAttr76Active { get; set; }
public int Attr76SortOrder { get; set; }


public int Entry39Id { get; set; }
public string Entry39Name { get; set; }
public string Entry39Description { get; set; }
public DateTime Entry39CreatedAt { get; set; }
public DateTime? Entry39UpdatedAt { get; set; }
public string Entry39CreatedBy { get; set; }
public bool IsEntry39Active { get; set; }
public int Entry39SortOrder { get; set; }


public int Item94Id { get; set; }
public string Item94Name { get; set; }
public string Item94Description { get; set; }
public DateTime Item94CreatedAt { get; set; }
public DateTime? Item94UpdatedAt { get; set; }
public string Item94CreatedBy { get; set; }
public bool IsItem94Active { get; set; }
public int Item94SortOrder { get; set; }


public int Config73Id { get; set; }
public string Config73Name { get; set; }
public string Config73Description { get; set; }
public DateTime Config73CreatedAt { get; set; }
public DateTime? Config73UpdatedAt { get; set; }
public string Config73CreatedBy { get; set; }
public bool IsConfig73Active { get; set; }
public int Config73SortOrder { get; set; }


public int Config47Id { get; set; }
public string Config47Name { get; set; }
public string Config47Description { get; set; }
public DateTime Config47CreatedAt { get; set; }
public DateTime? Config47UpdatedAt { get; set; }
public string Config47CreatedBy { get; set; }
public bool IsConfig47Active { get; set; }
public int Config47SortOrder { get; set; }


public int Entry6Id { get; set; }
public string Entry6Name { get; set; }
public string Entry6Description { get; set; }
public DateTime Entry6CreatedAt { get; set; }
public DateTime? Entry6UpdatedAt { get; set; }
public string Entry6CreatedBy { get; set; }
public bool IsEntry6Active { get; set; }
public int Entry6SortOrder { get; set; }


public int Field46Id { get; set; }
public string Field46Name { get; set; }
public string Field46Description { get; set; }
public DateTime Field46CreatedAt { get; set; }
public DateTime? Field46UpdatedAt { get; set; }
public string Field46CreatedBy { get; set; }
public bool IsField46Active { get; set; }
public int Field46SortOrder { get; set; }


public int Field21Id { get; set; }
public string Field21Name { get; set; }
public string Field21Description { get; set; }
public DateTime Field21CreatedAt { get; set; }
public DateTime? Field21UpdatedAt { get; set; }
public string Field21CreatedBy { get; set; }
public bool IsField21Active { get; set; }
public int Field21SortOrder { get; set; }


public int Record52Id { get; set; }
public string Record52Name { get; set; }
public string Record52Description { get; set; }
public DateTime Record52CreatedAt { get; set; }
public DateTime? Record52UpdatedAt { get; set; }
public string Record52CreatedBy { get; set; }
public bool IsRecord52Active { get; set; }
public int Record52SortOrder { get; set; }


public int Config66Id { get; set; }
public string Config66Name { get; set; }
public string Config66Description { get; set; }
public DateTime Config66CreatedAt { get; set; }
public DateTime? Config66UpdatedAt { get; set; }
public string Config66CreatedBy { get; set; }
public bool IsConfig66Active { get; set; }
public int Config66SortOrder { get; set; }


public int Attr25Id { get; set; }
public string Attr25Name { get; set; }
public string Attr25Description { get; set; }
public DateTime Attr25CreatedAt { get; set; }
public DateTime? Attr25UpdatedAt { get; set; }
public string Attr25CreatedBy { get; set; }
public bool IsAttr25Active { get; set; }
public int Attr25SortOrder { get; set; }


public int Param29Id { get; set; }
public string Param29Name { get; set; }
public string Param29Description { get; set; }
public DateTime Param29CreatedAt { get; set; }
public DateTime? Param29UpdatedAt { get; set; }
public string Param29CreatedBy { get; set; }
public bool IsParam29Active { get; set; }
public int Param29SortOrder { get; set; }


public int Config80Id { get; set; }
public string Config80Name { get; set; }
public string Config80Description { get; set; }
public DateTime Config80CreatedAt { get; set; }
public DateTime? Config80UpdatedAt { get; set; }
public string Config80CreatedBy { get; set; }
public bool IsConfig80Active { get; set; }
public int Config80SortOrder { get; set; }


public int Config4Id { get; set; }
public string Config4Name { get; set; }
public string Config4Description { get; set; }
public DateTime Config4CreatedAt { get; set; }
public DateTime? Config4UpdatedAt { get; set; }
public string Config4CreatedBy { get; set; }
public bool IsConfig4Active { get; set; }
public int Config4SortOrder { get; set; }


public int Param78Id { get; set; }
public string Param78Name { get; set; }
public string Param78Description { get; set; }
public DateTime Param78CreatedAt { get; set; }
public DateTime? Param78UpdatedAt { get; set; }
public string Param78CreatedBy { get; set; }
public bool IsParam78Active { get; set; }
public int Param78SortOrder { get; set; }


public int Detail73Id { get; set; }
public string Detail73Name { get; set; }
public string Detail73Description { get; set; }
public DateTime Detail73CreatedAt { get; set; }
public DateTime? Detail73UpdatedAt { get; set; }
public string Detail73CreatedBy { get; set; }
public bool IsDetail73Active { get; set; }
public int Detail73SortOrder { get; set; }


public int Param46Id { get; set; }
public string Param46Name { get; set; }
public string Param46Description { get; set; }
public DateTime Param46CreatedAt { get; set; }
public DateTime? Param46UpdatedAt { get; set; }
public string Param46CreatedBy { get; set; }
public bool IsParam46Active { get; set; }
public int Param46SortOrder { get; set; }


public int Param58Id { get; set; }
public string Param58Name { get; set; }
public string Param58Description { get; set; }
public DateTime Param58CreatedAt { get; set; }
public DateTime? Param58UpdatedAt { get; set; }
public string Param58CreatedBy { get; set; }
public bool IsParam58Active { get; set; }
public int Param58SortOrder { get; set; }


public int Config67Id { get; set; }
public string Config67Name { get; set; }
public string Config67Description { get; set; }
public DateTime Config67CreatedAt { get; set; }
public DateTime? Config67UpdatedAt { get; set; }
public string Config67CreatedBy { get; set; }
public bool IsConfig67Active { get; set; }
public int Config67SortOrder { get; set; }


public int Field98Id { get; set; }
public string Field98Name { get; set; }
public string Field98Description { get; set; }
public DateTime Field98CreatedAt { get; set; }
public DateTime? Field98UpdatedAt { get; set; }
public string Field98CreatedBy { get; set; }
public bool IsField98Active { get; set; }
public int Field98SortOrder { get; set; }


public int Record34Id { get; set; }
public string Record34Name { get; set; }
public string Record34Description { get; set; }
public DateTime Record34CreatedAt { get; set; }
public DateTime? Record34UpdatedAt { get; set; }
public string Record34CreatedBy { get; set; }
public bool IsRecord34Active { get; set; }
public int Record34SortOrder { get; set; }


public int Config68Id { get; set; }
public string Config68Name { get; set; }
public string Config68Description { get; set; }
public DateTime Config68CreatedAt { get; set; }
public DateTime? Config68UpdatedAt { get; set; }
public string Config68CreatedBy { get; set; }
public bool IsConfig68Active { get; set; }
public int Config68SortOrder { get; set; }


public int Config95Id { get; set; }
public string Config95Name { get; set; }
public string Config95Description { get; set; }
public DateTime Config95CreatedAt { get; set; }
public DateTime? Config95UpdatedAt { get; set; }
public string Config95CreatedBy { get; set; }
public bool IsConfig95Active { get; set; }
public int Config95SortOrder { get; set; }


public int Record9Id { get; set; }
public string Record9Name { get; set; }
public string Record9Description { get; set; }
public DateTime Record9CreatedAt { get; set; }
public DateTime? Record9UpdatedAt { get; set; }
public string Record9CreatedBy { get; set; }
public bool IsRecord9Active { get; set; }
public int Record9SortOrder { get; set; }


public int Config4Id { get; set; }
public string Config4Name { get; set; }
public string Config4Description { get; set; }
public DateTime Config4CreatedAt { get; set; }
public DateTime? Config4UpdatedAt { get; set; }
public string Config4CreatedBy { get; set; }
public bool IsConfig4Active { get; set; }
public int Config4SortOrder { get; set; }


public int Attr46Id { get; set; }
public string Attr46Name { get; set; }
public string Attr46Description { get; set; }
public DateTime Attr46CreatedAt { get; set; }
public DateTime? Attr46UpdatedAt { get; set; }
public string Attr46CreatedBy { get; set; }
public bool IsAttr46Active { get; set; }
public int Attr46SortOrder { get; set; }


public int Detail57Id { get; set; }
public string Detail57Name { get; set; }
public string Detail57Description { get; set; }
public DateTime Detail57CreatedAt { get; set; }
public DateTime? Detail57UpdatedAt { get; set; }
public string Detail57CreatedBy { get; set; }
public bool IsDetail57Active { get; set; }
public int Detail57SortOrder { get; set; }


public int Entry30Id { get; set; }
public string Entry30Name { get; set; }
public string Entry30Description { get; set; }
public DateTime Entry30CreatedAt { get; set; }
public DateTime? Entry30UpdatedAt { get; set; }
public string Entry30CreatedBy { get; set; }
public bool IsEntry30Active { get; set; }
public int Entry30SortOrder { get; set; }


public int Entry18Id { get; set; }
public string Entry18Name { get; set; }
public string Entry18Description { get; set; }
public DateTime Entry18CreatedAt { get; set; }
public DateTime? Entry18UpdatedAt { get; set; }
public string Entry18CreatedBy { get; set; }
public bool IsEntry18Active { get; set; }
public int Entry18SortOrder { get; set; }


public int Entry21Id { get; set; }
public string Entry21Name { get; set; }
public string Entry21Description { get; set; }
public DateTime Entry21CreatedAt { get; set; }
public DateTime? Entry21UpdatedAt { get; set; }
public string Entry21CreatedBy { get; set; }
public bool IsEntry21Active { get; set; }
public int Entry21SortOrder { get; set; }


public int Detail26Id { get; set; }
public string Detail26Name { get; set; }
public string Detail26Description { get; set; }
public DateTime Detail26CreatedAt { get; set; }
public DateTime? Detail26UpdatedAt { get; set; }
public string Detail26CreatedBy { get; set; }
public bool IsDetail26Active { get; set; }
public int Detail26SortOrder { get; set; }


public int Item16Id { get; set; }
public string Item16Name { get; set; }
public string Item16Description { get; set; }
public DateTime Item16CreatedAt { get; set; }
public DateTime? Item16UpdatedAt { get; set; }
public string Item16CreatedBy { get; set; }
public bool IsItem16Active { get; set; }
public int Item16SortOrder { get; set; }


public int Param66Id { get; set; }
public string Param66Name { get; set; }
public string Param66Description { get; set; }
public DateTime Param66CreatedAt { get; set; }
public DateTime? Param66UpdatedAt { get; set; }
public string Param66CreatedBy { get; set; }
public bool IsParam66Active { get; set; }
public int Param66SortOrder { get; set; }


public int Attr65Id { get; set; }
public string Attr65Name { get; set; }
public string Attr65Description { get; set; }
public DateTime Attr65CreatedAt { get; set; }
public DateTime? Attr65UpdatedAt { get; set; }
public string Attr65CreatedBy { get; set; }
public bool IsAttr65Active { get; set; }
public int Attr65SortOrder { get; set; }


public int Field33Id { get; set; }
public string Field33Name { get; set; }
public string Field33Description { get; set; }
public DateTime Field33CreatedAt { get; set; }
public DateTime? Field33UpdatedAt { get; set; }
public string Field33CreatedBy { get; set; }
public bool IsField33Active { get; set; }
public int Field33SortOrder { get; set; }


public int Entry34Id { get; set; }
public string Entry34Name { get; set; }
public string Entry34Description { get; set; }
public DateTime Entry34CreatedAt { get; set; }
public DateTime? Entry34UpdatedAt { get; set; }
public string Entry34CreatedBy { get; set; }
public bool IsEntry34Active { get; set; }
public int Entry34SortOrder { get; set; }


public int Field29Id { get; set; }
public string Field29Name { get; set; }
public string Field29Description { get; set; }
public DateTime Field29CreatedAt { get; set; }
public DateTime? Field29UpdatedAt { get; set; }
public string Field29CreatedBy { get; set; }
public bool IsField29Active { get; set; }
public int Field29SortOrder { get; set; }


public int Param80Id { get; set; }
public string Param80Name { get; set; }
public string Param80Description { get; set; }
public DateTime Param80CreatedAt { get; set; }
public DateTime? Param80UpdatedAt { get; set; }
public string Param80CreatedBy { get; set; }
public bool IsParam80Active { get; set; }
public int Param80SortOrder { get; set; }


public int Detail34Id { get; set; }
public string Detail34Name { get; set; }
public string Detail34Description { get; set; }
public DateTime Detail34CreatedAt { get; set; }
public DateTime? Detail34UpdatedAt { get; set; }
public string Detail34CreatedBy { get; set; }
public bool IsDetail34Active { get; set; }
public int Detail34SortOrder { get; set; }


public int Record91Id { get; set; }
public string Record91Name { get; set; }
public string Record91Description { get; set; }
public DateTime Record91CreatedAt { get; set; }
public DateTime? Record91UpdatedAt { get; set; }
public string Record91CreatedBy { get; set; }
public bool IsRecord91Active { get; set; }
public int Record91SortOrder { get; set; }


public int Field76Id { get; set; }
public string Field76Name { get; set; }
public string Field76Description { get; set; }
public DateTime Field76CreatedAt { get; set; }
public DateTime? Field76UpdatedAt { get; set; }
public string Field76CreatedBy { get; set; }
public bool IsField76Active { get; set; }
public int Field76SortOrder { get; set; }


public int Config89Id { get; set; }
public string Config89Name { get; set; }
public string Config89Description { get; set; }
public DateTime Config89CreatedAt { get; set; }
public DateTime? Config89UpdatedAt { get; set; }
public string Config89CreatedBy { get; set; }
public bool IsConfig89Active { get; set; }
public int Config89SortOrder { get; set; }

    }
}