using Admin.Core121;
using Admin.Data408;
using Admin.Validators431;
using Auth.Models23;
using Billing.Core34;
using Common.Api57;
using DataAccess.Data36;
using DataAccess.Models;
using Documents.Processors;
using Export.Tests62;
using GalaxyWorks.Contracts94;
using GalaxyWorks.Models219;
using Imaging.Models184;
using Imaging.Web;
using Logging.Processors;
using Scheduling.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Mappers
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer13
    {
        private readonly Admin_Validators431_Service7 _admin_Validators431_Service7;
        private readonly GalaxyWorks_Contracts94_Point11 _galaxyWorks_Contracts94_Point11;
        private readonly Admin_Core121_Repository3 _admin_Core121_Repository3;
        private readonly Admin_Core121_Options4 _admin_Core121_Options4;
        private readonly IDataAccess_Models_Provider _iDataAccess_Models_Provider;
        private readonly DataAccess_Models_Factory2 _dataAccess_Models_Factory2;
        private readonly Common_Api57_ViewModel6 _common_Api57_ViewModel6;
        private readonly Common_Api57_Helper4 _common_Api57_Helper4;

        public Consumer13(Admin_Validators431_Service7 admin_Validators431_Service7, GalaxyWorks_Contracts94_Point11 galaxyWorks_Contracts94_Point11, Admin_Core121_Repository3 admin_Core121_Repository3, Admin_Core121_Options4 admin_Core121_Options4, IDataAccess_Models_Provider iDataAccess_Models_Provider, DataAccess_Models_Factory2 dataAccess_Models_Factory2, Common_Api57_ViewModel6 common_Api57_ViewModel6, Common_Api57_Helper4 common_Api57_Helper4)
        {
            _admin_Validators431_Service7 = admin_Validators431_Service7 ?? throw new ArgumentNullException(nameof(admin_Validators431_Service7));
            _galaxyWorks_Contracts94_Point11 = galaxyWorks_Contracts94_Point11 ?? throw new ArgumentNullException(nameof(galaxyWorks_Contracts94_Point11));
            _admin_Core121_Repository3 = admin_Core121_Repository3 ?? throw new ArgumentNullException(nameof(admin_Core121_Repository3));
            _admin_Core121_Options4 = admin_Core121_Options4 ?? throw new ArgumentNullException(nameof(admin_Core121_Options4));
            _iDataAccess_Models_Provider = iDataAccess_Models_Provider ?? throw new ArgumentNullException(nameof(iDataAccess_Models_Provider));
            _dataAccess_Models_Factory2 = dataAccess_Models_Factory2 ?? throw new ArgumentNullException(nameof(dataAccess_Models_Factory2));
            _common_Api57_ViewModel6 = common_Api57_ViewModel6 ?? throw new ArgumentNullException(nameof(common_Api57_ViewModel6));
            _common_Api57_Helper4 = common_Api57_Helper4 ?? throw new ArgumentNullException(nameof(common_Api57_Helper4));
        }

        public Admin_Validators431_Service7 GetAdmin_Validators431_Service7() => _admin_Validators431_Service7;
        public GalaxyWorks_Contracts94_Point11 GetGalaxyWorks_Contracts94_Point11() => _galaxyWorks_Contracts94_Point11;
        public Admin_Core121_Repository3 GetAdmin_Core121_Repository3() => _admin_Core121_Repository3;
        public Admin_Core121_Options4 GetAdmin_Core121_Options4() => _admin_Core121_Options4;
        public IDataAccess_Models_Provider GetIDataAccess_Models_Provider() => _iDataAccess_Models_Provider;
        public DataAccess_Models_Factory2 GetDataAccess_Models_Factory2() => _dataAccess_Models_Factory2;
        public Common_Api57_ViewModel6 GetCommon_Api57_ViewModel6() => _common_Api57_ViewModel6;
        public Common_Api57_Helper4 GetCommon_Api57_Helper4() => _common_Api57_Helper4;

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

public int Detail25Id { get; set; }
public string Detail25Name { get; set; }
public string Detail25Description { get; set; }
public DateTime Detail25CreatedAt { get; set; }
public DateTime? Detail25UpdatedAt { get; set; }
public string Detail25CreatedBy { get; set; }
public bool IsDetail25Active { get; set; }
public int Detail25SortOrder { get; set; }


public int Record83Id { get; set; }
public string Record83Name { get; set; }
public string Record83Description { get; set; }
public DateTime Record83CreatedAt { get; set; }
public DateTime? Record83UpdatedAt { get; set; }
public string Record83CreatedBy { get; set; }
public bool IsRecord83Active { get; set; }
public int Record83SortOrder { get; set; }


public int Config90Id { get; set; }
public string Config90Name { get; set; }
public string Config90Description { get; set; }
public DateTime Config90CreatedAt { get; set; }
public DateTime? Config90UpdatedAt { get; set; }
public string Config90CreatedBy { get; set; }
public bool IsConfig90Active { get; set; }
public int Config90SortOrder { get; set; }


public int Item5Id { get; set; }
public string Item5Name { get; set; }
public string Item5Description { get; set; }
public DateTime Item5CreatedAt { get; set; }
public DateTime? Item5UpdatedAt { get; set; }
public string Item5CreatedBy { get; set; }
public bool IsItem5Active { get; set; }
public int Item5SortOrder { get; set; }


public int Item17Id { get; set; }
public string Item17Name { get; set; }
public string Item17Description { get; set; }
public DateTime Item17CreatedAt { get; set; }
public DateTime? Item17UpdatedAt { get; set; }
public string Item17CreatedBy { get; set; }
public bool IsItem17Active { get; set; }
public int Item17SortOrder { get; set; }


public int Record69Id { get; set; }
public string Record69Name { get; set; }
public string Record69Description { get; set; }
public DateTime Record69CreatedAt { get; set; }
public DateTime? Record69UpdatedAt { get; set; }
public string Record69CreatedBy { get; set; }
public bool IsRecord69Active { get; set; }
public int Record69SortOrder { get; set; }


public int Detail39Id { get; set; }
public string Detail39Name { get; set; }
public string Detail39Description { get; set; }
public DateTime Detail39CreatedAt { get; set; }
public DateTime? Detail39UpdatedAt { get; set; }
public string Detail39CreatedBy { get; set; }
public bool IsDetail39Active { get; set; }
public int Detail39SortOrder { get; set; }


public int Attr25Id { get; set; }
public string Attr25Name { get; set; }
public string Attr25Description { get; set; }
public DateTime Attr25CreatedAt { get; set; }
public DateTime? Attr25UpdatedAt { get; set; }
public string Attr25CreatedBy { get; set; }
public bool IsAttr25Active { get; set; }
public int Attr25SortOrder { get; set; }


public int Detail78Id { get; set; }
public string Detail78Name { get; set; }
public string Detail78Description { get; set; }
public DateTime Detail78CreatedAt { get; set; }
public DateTime? Detail78UpdatedAt { get; set; }
public string Detail78CreatedBy { get; set; }
public bool IsDetail78Active { get; set; }
public int Detail78SortOrder { get; set; }


public int Item94Id { get; set; }
public string Item94Name { get; set; }
public string Item94Description { get; set; }
public DateTime Item94CreatedAt { get; set; }
public DateTime? Item94UpdatedAt { get; set; }
public string Item94CreatedBy { get; set; }
public bool IsItem94Active { get; set; }
public int Item94SortOrder { get; set; }


public int Entry39Id { get; set; }
public string Entry39Name { get; set; }
public string Entry39Description { get; set; }
public DateTime Entry39CreatedAt { get; set; }
public DateTime? Entry39UpdatedAt { get; set; }
public string Entry39CreatedBy { get; set; }
public bool IsEntry39Active { get; set; }
public int Entry39SortOrder { get; set; }


public int Entry99Id { get; set; }
public string Entry99Name { get; set; }
public string Entry99Description { get; set; }
public DateTime Entry99CreatedAt { get; set; }
public DateTime? Entry99UpdatedAt { get; set; }
public string Entry99CreatedBy { get; set; }
public bool IsEntry99Active { get; set; }
public int Entry99SortOrder { get; set; }


public int Config80Id { get; set; }
public string Config80Name { get; set; }
public string Config80Description { get; set; }
public DateTime Config80CreatedAt { get; set; }
public DateTime? Config80UpdatedAt { get; set; }
public string Config80CreatedBy { get; set; }
public bool IsConfig80Active { get; set; }
public int Config80SortOrder { get; set; }


public int Record21Id { get; set; }
public string Record21Name { get; set; }
public string Record21Description { get; set; }
public DateTime Record21CreatedAt { get; set; }
public DateTime? Record21UpdatedAt { get; set; }
public string Record21CreatedBy { get; set; }
public bool IsRecord21Active { get; set; }
public int Record21SortOrder { get; set; }


public int Entry51Id { get; set; }
public string Entry51Name { get; set; }
public string Entry51Description { get; set; }
public DateTime Entry51CreatedAt { get; set; }
public DateTime? Entry51UpdatedAt { get; set; }
public string Entry51CreatedBy { get; set; }
public bool IsEntry51Active { get; set; }
public int Entry51SortOrder { get; set; }


public int Item29Id { get; set; }
public string Item29Name { get; set; }
public string Item29Description { get; set; }
public DateTime Item29CreatedAt { get; set; }
public DateTime? Item29UpdatedAt { get; set; }
public string Item29CreatedBy { get; set; }
public bool IsItem29Active { get; set; }
public int Item29SortOrder { get; set; }


public int Item78Id { get; set; }
public string Item78Name { get; set; }
public string Item78Description { get; set; }
public DateTime Item78CreatedAt { get; set; }
public DateTime? Item78UpdatedAt { get; set; }
public string Item78CreatedBy { get; set; }
public bool IsItem78Active { get; set; }
public int Item78SortOrder { get; set; }


public int Config83Id { get; set; }
public string Config83Name { get; set; }
public string Config83Description { get; set; }
public DateTime Config83CreatedAt { get; set; }
public DateTime? Config83UpdatedAt { get; set; }
public string Config83CreatedBy { get; set; }
public bool IsConfig83Active { get; set; }
public int Config83SortOrder { get; set; }


public int Entry20Id { get; set; }
public string Entry20Name { get; set; }
public string Entry20Description { get; set; }
public DateTime Entry20CreatedAt { get; set; }
public DateTime? Entry20UpdatedAt { get; set; }
public string Entry20CreatedBy { get; set; }
public bool IsEntry20Active { get; set; }
public int Entry20SortOrder { get; set; }


public int Detail76Id { get; set; }
public string Detail76Name { get; set; }
public string Detail76Description { get; set; }
public DateTime Detail76CreatedAt { get; set; }
public DateTime? Detail76UpdatedAt { get; set; }
public string Detail76CreatedBy { get; set; }
public bool IsDetail76Active { get; set; }
public int Detail76SortOrder { get; set; }


public int Item83Id { get; set; }
public string Item83Name { get; set; }
public string Item83Description { get; set; }
public DateTime Item83CreatedAt { get; set; }
public DateTime? Item83UpdatedAt { get; set; }
public string Item83CreatedBy { get; set; }
public bool IsItem83Active { get; set; }
public int Item83SortOrder { get; set; }


public int Item59Id { get; set; }
public string Item59Name { get; set; }
public string Item59Description { get; set; }
public DateTime Item59CreatedAt { get; set; }
public DateTime? Item59UpdatedAt { get; set; }
public string Item59CreatedBy { get; set; }
public bool IsItem59Active { get; set; }
public int Item59SortOrder { get; set; }


public int Param49Id { get; set; }
public string Param49Name { get; set; }
public string Param49Description { get; set; }
public DateTime Param49CreatedAt { get; set; }
public DateTime? Param49UpdatedAt { get; set; }
public string Param49CreatedBy { get; set; }
public bool IsParam49Active { get; set; }
public int Param49SortOrder { get; set; }


public int Detail28Id { get; set; }
public string Detail28Name { get; set; }
public string Detail28Description { get; set; }
public DateTime Detail28CreatedAt { get; set; }
public DateTime? Detail28UpdatedAt { get; set; }
public string Detail28CreatedBy { get; set; }
public bool IsDetail28Active { get; set; }
public int Detail28SortOrder { get; set; }


public int Detail42Id { get; set; }
public string Detail42Name { get; set; }
public string Detail42Description { get; set; }
public DateTime Detail42CreatedAt { get; set; }
public DateTime? Detail42UpdatedAt { get; set; }
public string Detail42CreatedBy { get; set; }
public bool IsDetail42Active { get; set; }
public int Detail42SortOrder { get; set; }


public int Config58Id { get; set; }
public string Config58Name { get; set; }
public string Config58Description { get; set; }
public DateTime Config58CreatedAt { get; set; }
public DateTime? Config58UpdatedAt { get; set; }
public string Config58CreatedBy { get; set; }
public bool IsConfig58Active { get; set; }
public int Config58SortOrder { get; set; }


public int Detail40Id { get; set; }
public string Detail40Name { get; set; }
public string Detail40Description { get; set; }
public DateTime Detail40CreatedAt { get; set; }
public DateTime? Detail40UpdatedAt { get; set; }
public string Detail40CreatedBy { get; set; }
public bool IsDetail40Active { get; set; }
public int Detail40SortOrder { get; set; }


public int Item19Id { get; set; }
public string Item19Name { get; set; }
public string Item19Description { get; set; }
public DateTime Item19CreatedAt { get; set; }
public DateTime? Item19UpdatedAt { get; set; }
public string Item19CreatedBy { get; set; }
public bool IsItem19Active { get; set; }
public int Item19SortOrder { get; set; }


public int Detail8Id { get; set; }
public string Detail8Name { get; set; }
public string Detail8Description { get; set; }
public DateTime Detail8CreatedAt { get; set; }
public DateTime? Detail8UpdatedAt { get; set; }
public string Detail8CreatedBy { get; set; }
public bool IsDetail8Active { get; set; }
public int Detail8SortOrder { get; set; }


public int Detail30Id { get; set; }
public string Detail30Name { get; set; }
public string Detail30Description { get; set; }
public DateTime Detail30CreatedAt { get; set; }
public DateTime? Detail30UpdatedAt { get; set; }
public string Detail30CreatedBy { get; set; }
public bool IsDetail30Active { get; set; }
public int Detail30SortOrder { get; set; }


public int Detail65Id { get; set; }
public string Detail65Name { get; set; }
public string Detail65Description { get; set; }
public DateTime Detail65CreatedAt { get; set; }
public DateTime? Detail65UpdatedAt { get; set; }
public string Detail65CreatedBy { get; set; }
public bool IsDetail65Active { get; set; }
public int Detail65SortOrder { get; set; }


public int Detail2Id { get; set; }
public string Detail2Name { get; set; }
public string Detail2Description { get; set; }
public DateTime Detail2CreatedAt { get; set; }
public DateTime? Detail2UpdatedAt { get; set; }
public string Detail2CreatedBy { get; set; }
public bool IsDetail2Active { get; set; }
public int Detail2SortOrder { get; set; }


public int Entry34Id { get; set; }
public string Entry34Name { get; set; }
public string Entry34Description { get; set; }
public DateTime Entry34CreatedAt { get; set; }
public DateTime? Entry34UpdatedAt { get; set; }
public string Entry34CreatedBy { get; set; }
public bool IsEntry34Active { get; set; }
public int Entry34SortOrder { get; set; }


public int Entry74Id { get; set; }
public string Entry74Name { get; set; }
public string Entry74Description { get; set; }
public DateTime Entry74CreatedAt { get; set; }
public DateTime? Entry74UpdatedAt { get; set; }
public string Entry74CreatedBy { get; set; }
public bool IsEntry74Active { get; set; }
public int Entry74SortOrder { get; set; }


public int Entry41Id { get; set; }
public string Entry41Name { get; set; }
public string Entry41Description { get; set; }
public DateTime Entry41CreatedAt { get; set; }
public DateTime? Entry41UpdatedAt { get; set; }
public string Entry41CreatedBy { get; set; }
public bool IsEntry41Active { get; set; }
public int Entry41SortOrder { get; set; }


public int Field69Id { get; set; }
public string Field69Name { get; set; }
public string Field69Description { get; set; }
public DateTime Field69CreatedAt { get; set; }
public DateTime? Field69UpdatedAt { get; set; }
public string Field69CreatedBy { get; set; }
public bool IsField69Active { get; set; }
public int Field69SortOrder { get; set; }


public int Param47Id { get; set; }
public string Param47Name { get; set; }
public string Param47Description { get; set; }
public DateTime Param47CreatedAt { get; set; }
public DateTime? Param47UpdatedAt { get; set; }
public string Param47CreatedBy { get; set; }
public bool IsParam47Active { get; set; }
public int Param47SortOrder { get; set; }


public int Item69Id { get; set; }
public string Item69Name { get; set; }
public string Item69Description { get; set; }
public DateTime Item69CreatedAt { get; set; }
public DateTime? Item69UpdatedAt { get; set; }
public string Item69CreatedBy { get; set; }
public bool IsItem69Active { get; set; }
public int Item69SortOrder { get; set; }


public int Record60Id { get; set; }
public string Record60Name { get; set; }
public string Record60Description { get; set; }
public DateTime Record60CreatedAt { get; set; }
public DateTime? Record60UpdatedAt { get; set; }
public string Record60CreatedBy { get; set; }
public bool IsRecord60Active { get; set; }
public int Record60SortOrder { get; set; }


public int Entry11Id { get; set; }
public string Entry11Name { get; set; }
public string Entry11Description { get; set; }
public DateTime Entry11CreatedAt { get; set; }
public DateTime? Entry11UpdatedAt { get; set; }
public string Entry11CreatedBy { get; set; }
public bool IsEntry11Active { get; set; }
public int Entry11SortOrder { get; set; }


public int Field92Id { get; set; }
public string Field92Name { get; set; }
public string Field92Description { get; set; }
public DateTime Field92CreatedAt { get; set; }
public DateTime? Field92UpdatedAt { get; set; }
public string Field92CreatedBy { get; set; }
public bool IsField92Active { get; set; }
public int Field92SortOrder { get; set; }


public int Entry12Id { get; set; }
public string Entry12Name { get; set; }
public string Entry12Description { get; set; }
public DateTime Entry12CreatedAt { get; set; }
public DateTime? Entry12UpdatedAt { get; set; }
public string Entry12CreatedBy { get; set; }
public bool IsEntry12Active { get; set; }
public int Entry12SortOrder { get; set; }


public int Item92Id { get; set; }
public string Item92Name { get; set; }
public string Item92Description { get; set; }
public DateTime Item92CreatedAt { get; set; }
public DateTime? Item92UpdatedAt { get; set; }
public string Item92CreatedBy { get; set; }
public bool IsItem92Active { get; set; }
public int Item92SortOrder { get; set; }


public int Param9Id { get; set; }
public string Param9Name { get; set; }
public string Param9Description { get; set; }
public DateTime Param9CreatedAt { get; set; }
public DateTime? Param9UpdatedAt { get; set; }
public string Param9CreatedBy { get; set; }
public bool IsParam9Active { get; set; }
public int Param9SortOrder { get; set; }


public int Item10Id { get; set; }
public string Item10Name { get; set; }
public string Item10Description { get; set; }
public DateTime Item10CreatedAt { get; set; }
public DateTime? Item10UpdatedAt { get; set; }
public string Item10CreatedBy { get; set; }
public bool IsItem10Active { get; set; }
public int Item10SortOrder { get; set; }

    }
}