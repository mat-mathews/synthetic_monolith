using Admin.Api;
using Admin.Handlers;
using Auth.Data135;
using Billing.Events;
using Billing.Models;
using Common.Contracts279;
using Documents.Api156;
using Export.Api;
using GalaxyWorks.Data224;
using GalaxyWorks.Processors16;
using Imaging.Client261;
using Import.Contracts180;
using Notifications.Events42;
using Notifications.Service;
using Portal.Events151;
using Portal.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Shared298;
using Workflow.Web377;

namespace BatchJobs.Client
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer25
    {
        private readonly IAdmin_Handlers_Handler11 _iAdmin_Handlers_Handler11;
        private readonly Auth_Data135_Builder5 _auth_Data135_Builder5;
        private readonly IAuth_Data135_Service6 _iAuth_Data135_Service6;
        private readonly IAdmin_Api_Repository3 _iAdmin_Api_Repository3;
        private readonly Admin_Api_Service11 _admin_Api_Service11;
        private readonly Admin_Api_Controller8 _admin_Api_Controller8;
        private readonly Export_Api_ViewModel4 _export_Api_ViewModel4;
        private readonly Export_Api_Provider9 _export_Api_Provider9;

        public Consumer25(IAdmin_Handlers_Handler11 iAdmin_Handlers_Handler11, Auth_Data135_Builder5 auth_Data135_Builder5, IAuth_Data135_Service6 iAuth_Data135_Service6, IAdmin_Api_Repository3 iAdmin_Api_Repository3, Admin_Api_Service11 admin_Api_Service11, Admin_Api_Controller8 admin_Api_Controller8, Export_Api_ViewModel4 export_Api_ViewModel4, Export_Api_Provider9 export_Api_Provider9)
        {
            _iAdmin_Handlers_Handler11 = iAdmin_Handlers_Handler11 ?? throw new ArgumentNullException(nameof(iAdmin_Handlers_Handler11));
            _auth_Data135_Builder5 = auth_Data135_Builder5 ?? throw new ArgumentNullException(nameof(auth_Data135_Builder5));
            _iAuth_Data135_Service6 = iAuth_Data135_Service6 ?? throw new ArgumentNullException(nameof(iAuth_Data135_Service6));
            _iAdmin_Api_Repository3 = iAdmin_Api_Repository3 ?? throw new ArgumentNullException(nameof(iAdmin_Api_Repository3));
            _admin_Api_Service11 = admin_Api_Service11 ?? throw new ArgumentNullException(nameof(admin_Api_Service11));
            _admin_Api_Controller8 = admin_Api_Controller8 ?? throw new ArgumentNullException(nameof(admin_Api_Controller8));
            _export_Api_ViewModel4 = export_Api_ViewModel4 ?? throw new ArgumentNullException(nameof(export_Api_ViewModel4));
            _export_Api_Provider9 = export_Api_Provider9 ?? throw new ArgumentNullException(nameof(export_Api_Provider9));
        }

        public IAdmin_Handlers_Handler11 GetIAdmin_Handlers_Handler11() => _iAdmin_Handlers_Handler11;
        public Auth_Data135_Builder5 GetAuth_Data135_Builder5() => _auth_Data135_Builder5;
        public IAuth_Data135_Service6 GetIAuth_Data135_Service6() => _iAuth_Data135_Service6;
        public IAdmin_Api_Repository3 GetIAdmin_Api_Repository3() => _iAdmin_Api_Repository3;
        public Admin_Api_Service11 GetAdmin_Api_Service11() => _admin_Api_Service11;
        public Admin_Api_Controller8 GetAdmin_Api_Controller8() => _admin_Api_Controller8;
        public Export_Api_ViewModel4 GetExport_Api_ViewModel4() => _export_Api_ViewModel4;
        public Export_Api_Provider9 GetExport_Api_Provider9() => _export_Api_Provider9;

/// <summary>
/// Validates the Consumer25 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer25(Consumer25Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer25));
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
/// Processes the Consumer25 operation asynchronously.
/// </summary>
public async Task<Consumer25Result> ProcessConsumer25Async(
    Consumer25Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer25), request.Id);

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
            return new Consumer25Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer25));
        return new Consumer25Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer25));
        return new Consumer25Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer25 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer25Dto>> GetConsumer25ListAsync(
    Consumer25Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer25Entity>().AsQueryable();

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
        .Select(x => new Consumer25Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer25Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer25Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer25Service(
    ILogger<Consumer25Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer25:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer25 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer25Data> GetCachedConsumer25Async(string key)
{
    var cacheKey = $"Consumer25_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer25Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer25SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Attr37Id { get; set; }
public string Attr37Name { get; set; }
public string Attr37Description { get; set; }
public DateTime Attr37CreatedAt { get; set; }
public DateTime? Attr37UpdatedAt { get; set; }
public string Attr37CreatedBy { get; set; }
public bool IsAttr37Active { get; set; }
public int Attr37SortOrder { get; set; }


public int Field44Id { get; set; }
public string Field44Name { get; set; }
public string Field44Description { get; set; }
public DateTime Field44CreatedAt { get; set; }
public DateTime? Field44UpdatedAt { get; set; }
public string Field44CreatedBy { get; set; }
public bool IsField44Active { get; set; }
public int Field44SortOrder { get; set; }


public int Attr71Id { get; set; }
public string Attr71Name { get; set; }
public string Attr71Description { get; set; }
public DateTime Attr71CreatedAt { get; set; }
public DateTime? Attr71UpdatedAt { get; set; }
public string Attr71CreatedBy { get; set; }
public bool IsAttr71Active { get; set; }
public int Attr71SortOrder { get; set; }


public int Record50Id { get; set; }
public string Record50Name { get; set; }
public string Record50Description { get; set; }
public DateTime Record50CreatedAt { get; set; }
public DateTime? Record50UpdatedAt { get; set; }
public string Record50CreatedBy { get; set; }
public bool IsRecord50Active { get; set; }
public int Record50SortOrder { get; set; }


public int Entry8Id { get; set; }
public string Entry8Name { get; set; }
public string Entry8Description { get; set; }
public DateTime Entry8CreatedAt { get; set; }
public DateTime? Entry8UpdatedAt { get; set; }
public string Entry8CreatedBy { get; set; }
public bool IsEntry8Active { get; set; }
public int Entry8SortOrder { get; set; }


public int Param98Id { get; set; }
public string Param98Name { get; set; }
public string Param98Description { get; set; }
public DateTime Param98CreatedAt { get; set; }
public DateTime? Param98UpdatedAt { get; set; }
public string Param98CreatedBy { get; set; }
public bool IsParam98Active { get; set; }
public int Param98SortOrder { get; set; }


public int Config28Id { get; set; }
public string Config28Name { get; set; }
public string Config28Description { get; set; }
public DateTime Config28CreatedAt { get; set; }
public DateTime? Config28UpdatedAt { get; set; }
public string Config28CreatedBy { get; set; }
public bool IsConfig28Active { get; set; }
public int Config28SortOrder { get; set; }


public int Field20Id { get; set; }
public string Field20Name { get; set; }
public string Field20Description { get; set; }
public DateTime Field20CreatedAt { get; set; }
public DateTime? Field20UpdatedAt { get; set; }
public string Field20CreatedBy { get; set; }
public bool IsField20Active { get; set; }
public int Field20SortOrder { get; set; }


public int Item47Id { get; set; }
public string Item47Name { get; set; }
public string Item47Description { get; set; }
public DateTime Item47CreatedAt { get; set; }
public DateTime? Item47UpdatedAt { get; set; }
public string Item47CreatedBy { get; set; }
public bool IsItem47Active { get; set; }
public int Item47SortOrder { get; set; }


public int Item14Id { get; set; }
public string Item14Name { get; set; }
public string Item14Description { get; set; }
public DateTime Item14CreatedAt { get; set; }
public DateTime? Item14UpdatedAt { get; set; }
public string Item14CreatedBy { get; set; }
public bool IsItem14Active { get; set; }
public int Item14SortOrder { get; set; }


public int Item86Id { get; set; }
public string Item86Name { get; set; }
public string Item86Description { get; set; }
public DateTime Item86CreatedAt { get; set; }
public DateTime? Item86UpdatedAt { get; set; }
public string Item86CreatedBy { get; set; }
public bool IsItem86Active { get; set; }
public int Item86SortOrder { get; set; }


public int Record84Id { get; set; }
public string Record84Name { get; set; }
public string Record84Description { get; set; }
public DateTime Record84CreatedAt { get; set; }
public DateTime? Record84UpdatedAt { get; set; }
public string Record84CreatedBy { get; set; }
public bool IsRecord84Active { get; set; }
public int Record84SortOrder { get; set; }


public int Detail68Id { get; set; }
public string Detail68Name { get; set; }
public string Detail68Description { get; set; }
public DateTime Detail68CreatedAt { get; set; }
public DateTime? Detail68UpdatedAt { get; set; }
public string Detail68CreatedBy { get; set; }
public bool IsDetail68Active { get; set; }
public int Detail68SortOrder { get; set; }


public int Field29Id { get; set; }
public string Field29Name { get; set; }
public string Field29Description { get; set; }
public DateTime Field29CreatedAt { get; set; }
public DateTime? Field29UpdatedAt { get; set; }
public string Field29CreatedBy { get; set; }
public bool IsField29Active { get; set; }
public int Field29SortOrder { get; set; }


public int Item2Id { get; set; }
public string Item2Name { get; set; }
public string Item2Description { get; set; }
public DateTime Item2CreatedAt { get; set; }
public DateTime? Item2UpdatedAt { get; set; }
public string Item2CreatedBy { get; set; }
public bool IsItem2Active { get; set; }
public int Item2SortOrder { get; set; }


public int Field41Id { get; set; }
public string Field41Name { get; set; }
public string Field41Description { get; set; }
public DateTime Field41CreatedAt { get; set; }
public DateTime? Field41UpdatedAt { get; set; }
public string Field41CreatedBy { get; set; }
public bool IsField41Active { get; set; }
public int Field41SortOrder { get; set; }


public int Record95Id { get; set; }
public string Record95Name { get; set; }
public string Record95Description { get; set; }
public DateTime Record95CreatedAt { get; set; }
public DateTime? Record95UpdatedAt { get; set; }
public string Record95CreatedBy { get; set; }
public bool IsRecord95Active { get; set; }
public int Record95SortOrder { get; set; }


public int Entry37Id { get; set; }
public string Entry37Name { get; set; }
public string Entry37Description { get; set; }
public DateTime Entry37CreatedAt { get; set; }
public DateTime? Entry37UpdatedAt { get; set; }
public string Entry37CreatedBy { get; set; }
public bool IsEntry37Active { get; set; }
public int Entry37SortOrder { get; set; }


public int Attr81Id { get; set; }
public string Attr81Name { get; set; }
public string Attr81Description { get; set; }
public DateTime Attr81CreatedAt { get; set; }
public DateTime? Attr81UpdatedAt { get; set; }
public string Attr81CreatedBy { get; set; }
public bool IsAttr81Active { get; set; }
public int Attr81SortOrder { get; set; }


public int Param32Id { get; set; }
public string Param32Name { get; set; }
public string Param32Description { get; set; }
public DateTime Param32CreatedAt { get; set; }
public DateTime? Param32UpdatedAt { get; set; }
public string Param32CreatedBy { get; set; }
public bool IsParam32Active { get; set; }
public int Param32SortOrder { get; set; }


public int Attr22Id { get; set; }
public string Attr22Name { get; set; }
public string Attr22Description { get; set; }
public DateTime Attr22CreatedAt { get; set; }
public DateTime? Attr22UpdatedAt { get; set; }
public string Attr22CreatedBy { get; set; }
public bool IsAttr22Active { get; set; }
public int Attr22SortOrder { get; set; }


public int Config75Id { get; set; }
public string Config75Name { get; set; }
public string Config75Description { get; set; }
public DateTime Config75CreatedAt { get; set; }
public DateTime? Config75UpdatedAt { get; set; }
public string Config75CreatedBy { get; set; }
public bool IsConfig75Active { get; set; }
public int Config75SortOrder { get; set; }


public int Entry68Id { get; set; }
public string Entry68Name { get; set; }
public string Entry68Description { get; set; }
public DateTime Entry68CreatedAt { get; set; }
public DateTime? Entry68UpdatedAt { get; set; }
public string Entry68CreatedBy { get; set; }
public bool IsEntry68Active { get; set; }
public int Entry68SortOrder { get; set; }


public int Param9Id { get; set; }
public string Param9Name { get; set; }
public string Param9Description { get; set; }
public DateTime Param9CreatedAt { get; set; }
public DateTime? Param9UpdatedAt { get; set; }
public string Param9CreatedBy { get; set; }
public bool IsParam9Active { get; set; }
public int Param9SortOrder { get; set; }


public int Record14Id { get; set; }
public string Record14Name { get; set; }
public string Record14Description { get; set; }
public DateTime Record14CreatedAt { get; set; }
public DateTime? Record14UpdatedAt { get; set; }
public string Record14CreatedBy { get; set; }
public bool IsRecord14Active { get; set; }
public int Record14SortOrder { get; set; }


public int Attr96Id { get; set; }
public string Attr96Name { get; set; }
public string Attr96Description { get; set; }
public DateTime Attr96CreatedAt { get; set; }
public DateTime? Attr96UpdatedAt { get; set; }
public string Attr96CreatedBy { get; set; }
public bool IsAttr96Active { get; set; }
public int Attr96SortOrder { get; set; }


public int Record5Id { get; set; }
public string Record5Name { get; set; }
public string Record5Description { get; set; }
public DateTime Record5CreatedAt { get; set; }
public DateTime? Record5UpdatedAt { get; set; }
public string Record5CreatedBy { get; set; }
public bool IsRecord5Active { get; set; }
public int Record5SortOrder { get; set; }


public int Record24Id { get; set; }
public string Record24Name { get; set; }
public string Record24Description { get; set; }
public DateTime Record24CreatedAt { get; set; }
public DateTime? Record24UpdatedAt { get; set; }
public string Record24CreatedBy { get; set; }
public bool IsRecord24Active { get; set; }
public int Record24SortOrder { get; set; }


public int Detail51Id { get; set; }
public string Detail51Name { get; set; }
public string Detail51Description { get; set; }
public DateTime Detail51CreatedAt { get; set; }
public DateTime? Detail51UpdatedAt { get; set; }
public string Detail51CreatedBy { get; set; }
public bool IsDetail51Active { get; set; }
public int Detail51SortOrder { get; set; }


public int Record53Id { get; set; }
public string Record53Name { get; set; }
public string Record53Description { get; set; }
public DateTime Record53CreatedAt { get; set; }
public DateTime? Record53UpdatedAt { get; set; }
public string Record53CreatedBy { get; set; }
public bool IsRecord53Active { get; set; }
public int Record53SortOrder { get; set; }


public int Detail35Id { get; set; }
public string Detail35Name { get; set; }
public string Detail35Description { get; set; }
public DateTime Detail35CreatedAt { get; set; }
public DateTime? Detail35UpdatedAt { get; set; }
public string Detail35CreatedBy { get; set; }
public bool IsDetail35Active { get; set; }
public int Detail35SortOrder { get; set; }


public int Item56Id { get; set; }
public string Item56Name { get; set; }
public string Item56Description { get; set; }
public DateTime Item56CreatedAt { get; set; }
public DateTime? Item56UpdatedAt { get; set; }
public string Item56CreatedBy { get; set; }
public bool IsItem56Active { get; set; }
public int Item56SortOrder { get; set; }


public int Field97Id { get; set; }
public string Field97Name { get; set; }
public string Field97Description { get; set; }
public DateTime Field97CreatedAt { get; set; }
public DateTime? Field97UpdatedAt { get; set; }
public string Field97CreatedBy { get; set; }
public bool IsField97Active { get; set; }
public int Field97SortOrder { get; set; }


public int Record58Id { get; set; }
public string Record58Name { get; set; }
public string Record58Description { get; set; }
public DateTime Record58CreatedAt { get; set; }
public DateTime? Record58UpdatedAt { get; set; }
public string Record58CreatedBy { get; set; }
public bool IsRecord58Active { get; set; }
public int Record58SortOrder { get; set; }


public int Field15Id { get; set; }
public string Field15Name { get; set; }
public string Field15Description { get; set; }
public DateTime Field15CreatedAt { get; set; }
public DateTime? Field15UpdatedAt { get; set; }
public string Field15CreatedBy { get; set; }
public bool IsField15Active { get; set; }
public int Field15SortOrder { get; set; }


public int Entry15Id { get; set; }
public string Entry15Name { get; set; }
public string Entry15Description { get; set; }
public DateTime Entry15CreatedAt { get; set; }
public DateTime? Entry15UpdatedAt { get; set; }
public string Entry15CreatedBy { get; set; }
public bool IsEntry15Active { get; set; }
public int Entry15SortOrder { get; set; }


public int Config89Id { get; set; }
public string Config89Name { get; set; }
public string Config89Description { get; set; }
public DateTime Config89CreatedAt { get; set; }
public DateTime? Config89UpdatedAt { get; set; }
public string Config89CreatedBy { get; set; }
public bool IsConfig89Active { get; set; }
public int Config89SortOrder { get; set; }


public int Param85Id { get; set; }
public string Param85Name { get; set; }
public string Param85Description { get; set; }
public DateTime Param85CreatedAt { get; set; }
public DateTime? Param85UpdatedAt { get; set; }
public string Param85CreatedBy { get; set; }
public bool IsParam85Active { get; set; }
public int Param85SortOrder { get; set; }


public int Item35Id { get; set; }
public string Item35Name { get; set; }
public string Item35Description { get; set; }
public DateTime Item35CreatedAt { get; set; }
public DateTime? Item35UpdatedAt { get; set; }
public string Item35CreatedBy { get; set; }
public bool IsItem35Active { get; set; }
public int Item35SortOrder { get; set; }


public int Detail80Id { get; set; }
public string Detail80Name { get; set; }
public string Detail80Description { get; set; }
public DateTime Detail80CreatedAt { get; set; }
public DateTime? Detail80UpdatedAt { get; set; }
public string Detail80CreatedBy { get; set; }
public bool IsDetail80Active { get; set; }
public int Detail80SortOrder { get; set; }


public int Param36Id { get; set; }
public string Param36Name { get; set; }
public string Param36Description { get; set; }
public DateTime Param36CreatedAt { get; set; }
public DateTime? Param36UpdatedAt { get; set; }
public string Param36CreatedBy { get; set; }
public bool IsParam36Active { get; set; }
public int Param36SortOrder { get; set; }


public int Param37Id { get; set; }
public string Param37Name { get; set; }
public string Param37Description { get; set; }
public DateTime Param37CreatedAt { get; set; }
public DateTime? Param37UpdatedAt { get; set; }
public string Param37CreatedBy { get; set; }
public bool IsParam37Active { get; set; }
public int Param37SortOrder { get; set; }


public int Record51Id { get; set; }
public string Record51Name { get; set; }
public string Record51Description { get; set; }
public DateTime Record51CreatedAt { get; set; }
public DateTime? Record51UpdatedAt { get; set; }
public string Record51CreatedBy { get; set; }
public bool IsRecord51Active { get; set; }
public int Record51SortOrder { get; set; }


public int Detail17Id { get; set; }
public string Detail17Name { get; set; }
public string Detail17Description { get; set; }
public DateTime Detail17CreatedAt { get; set; }
public DateTime? Detail17UpdatedAt { get; set; }
public string Detail17CreatedBy { get; set; }
public bool IsDetail17Active { get; set; }
public int Detail17SortOrder { get; set; }


public int Detail99Id { get; set; }
public string Detail99Name { get; set; }
public string Detail99Description { get; set; }
public DateTime Detail99CreatedAt { get; set; }
public DateTime? Detail99UpdatedAt { get; set; }
public string Detail99CreatedBy { get; set; }
public bool IsDetail99Active { get; set; }
public int Detail99SortOrder { get; set; }


public int Entry34Id { get; set; }
public string Entry34Name { get; set; }
public string Entry34Description { get; set; }
public DateTime Entry34CreatedAt { get; set; }
public DateTime? Entry34UpdatedAt { get; set; }
public string Entry34CreatedBy { get; set; }
public bool IsEntry34Active { get; set; }
public int Entry34SortOrder { get; set; }

    }
}