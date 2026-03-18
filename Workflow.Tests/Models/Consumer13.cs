using Admin.Events;
using Admin.Events235;
using Admin.Tests10;
using Auth.Handlers209;
using Billing.Shared312;
using Common.Data126;
using Export.Api;
using GalaxyWorks.Events77;
using Imaging.Validators108;
using Logging.Models436;
using Notifications.Client;
using Portal.Service378;
using Scheduling.Contracts425;
using Scheduling.Events128;
using Scheduling.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Models;

namespace Workflow.Tests
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer13
    {
        private readonly Admin_Events_Builder5 _admin_Events_Builder5;
        private readonly Utilities_Models_Manager4 _utilities_Models_Manager4;
        private readonly Utilities_Models_Range2 _utilities_Models_Range2;
        private readonly Billing_Shared312_Repository9 _billing_Shared312_Repository9;
        private readonly GalaxyWorks_Events77_Builder13 _galaxyWorks_Events77_Builder13;
        private readonly Scheduling_Events128_Processor10 _scheduling_Events128_Processor10;
        private readonly Admin_Events235_Request3 _admin_Events235_Request3;
        private readonly IAdmin_Events235_Validator2 _iAdmin_Events235_Validator2;

        public Consumer13(Admin_Events_Builder5 admin_Events_Builder5, Utilities_Models_Manager4 utilities_Models_Manager4, Utilities_Models_Range2 utilities_Models_Range2, Billing_Shared312_Repository9 billing_Shared312_Repository9, GalaxyWorks_Events77_Builder13 galaxyWorks_Events77_Builder13, Scheduling_Events128_Processor10 scheduling_Events128_Processor10, Admin_Events235_Request3 admin_Events235_Request3, IAdmin_Events235_Validator2 iAdmin_Events235_Validator2)
        {
            _admin_Events_Builder5 = admin_Events_Builder5 ?? throw new ArgumentNullException(nameof(admin_Events_Builder5));
            _utilities_Models_Manager4 = utilities_Models_Manager4 ?? throw new ArgumentNullException(nameof(utilities_Models_Manager4));
            _utilities_Models_Range2 = utilities_Models_Range2 ?? throw new ArgumentNullException(nameof(utilities_Models_Range2));
            _billing_Shared312_Repository9 = billing_Shared312_Repository9 ?? throw new ArgumentNullException(nameof(billing_Shared312_Repository9));
            _galaxyWorks_Events77_Builder13 = galaxyWorks_Events77_Builder13 ?? throw new ArgumentNullException(nameof(galaxyWorks_Events77_Builder13));
            _scheduling_Events128_Processor10 = scheduling_Events128_Processor10 ?? throw new ArgumentNullException(nameof(scheduling_Events128_Processor10));
            _admin_Events235_Request3 = admin_Events235_Request3 ?? throw new ArgumentNullException(nameof(admin_Events235_Request3));
            _iAdmin_Events235_Validator2 = iAdmin_Events235_Validator2 ?? throw new ArgumentNullException(nameof(iAdmin_Events235_Validator2));
        }

        public Admin_Events_Builder5 GetAdmin_Events_Builder5() => _admin_Events_Builder5;
        public Utilities_Models_Manager4 GetUtilities_Models_Manager4() => _utilities_Models_Manager4;
        public Utilities_Models_Range2 GetUtilities_Models_Range2() => _utilities_Models_Range2;
        public Billing_Shared312_Repository9 GetBilling_Shared312_Repository9() => _billing_Shared312_Repository9;
        public GalaxyWorks_Events77_Builder13 GetGalaxyWorks_Events77_Builder13() => _galaxyWorks_Events77_Builder13;
        public Scheduling_Events128_Processor10 GetScheduling_Events128_Processor10() => _scheduling_Events128_Processor10;
        public Admin_Events235_Request3 GetAdmin_Events235_Request3() => _admin_Events235_Request3;
        public IAdmin_Events235_Validator2 GetIAdmin_Events235_Validator2() => _iAdmin_Events235_Validator2;

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

public int Record86Id { get; set; }
public string Record86Name { get; set; }
public string Record86Description { get; set; }
public DateTime Record86CreatedAt { get; set; }
public DateTime? Record86UpdatedAt { get; set; }
public string Record86CreatedBy { get; set; }
public bool IsRecord86Active { get; set; }
public int Record86SortOrder { get; set; }


public int Config56Id { get; set; }
public string Config56Name { get; set; }
public string Config56Description { get; set; }
public DateTime Config56CreatedAt { get; set; }
public DateTime? Config56UpdatedAt { get; set; }
public string Config56CreatedBy { get; set; }
public bool IsConfig56Active { get; set; }
public int Config56SortOrder { get; set; }


public int Detail92Id { get; set; }
public string Detail92Name { get; set; }
public string Detail92Description { get; set; }
public DateTime Detail92CreatedAt { get; set; }
public DateTime? Detail92UpdatedAt { get; set; }
public string Detail92CreatedBy { get; set; }
public bool IsDetail92Active { get; set; }
public int Detail92SortOrder { get; set; }


public int Item70Id { get; set; }
public string Item70Name { get; set; }
public string Item70Description { get; set; }
public DateTime Item70CreatedAt { get; set; }
public DateTime? Item70UpdatedAt { get; set; }
public string Item70CreatedBy { get; set; }
public bool IsItem70Active { get; set; }
public int Item70SortOrder { get; set; }


public int Param30Id { get; set; }
public string Param30Name { get; set; }
public string Param30Description { get; set; }
public DateTime Param30CreatedAt { get; set; }
public DateTime? Param30UpdatedAt { get; set; }
public string Param30CreatedBy { get; set; }
public bool IsParam30Active { get; set; }
public int Param30SortOrder { get; set; }


public int Field39Id { get; set; }
public string Field39Name { get; set; }
public string Field39Description { get; set; }
public DateTime Field39CreatedAt { get; set; }
public DateTime? Field39UpdatedAt { get; set; }
public string Field39CreatedBy { get; set; }
public bool IsField39Active { get; set; }
public int Field39SortOrder { get; set; }


public int Record69Id { get; set; }
public string Record69Name { get; set; }
public string Record69Description { get; set; }
public DateTime Record69CreatedAt { get; set; }
public DateTime? Record69UpdatedAt { get; set; }
public string Record69CreatedBy { get; set; }
public bool IsRecord69Active { get; set; }
public int Record69SortOrder { get; set; }


public int Detail9Id { get; set; }
public string Detail9Name { get; set; }
public string Detail9Description { get; set; }
public DateTime Detail9CreatedAt { get; set; }
public DateTime? Detail9UpdatedAt { get; set; }
public string Detail9CreatedBy { get; set; }
public bool IsDetail9Active { get; set; }
public int Detail9SortOrder { get; set; }


public int Entry91Id { get; set; }
public string Entry91Name { get; set; }
public string Entry91Description { get; set; }
public DateTime Entry91CreatedAt { get; set; }
public DateTime? Entry91UpdatedAt { get; set; }
public string Entry91CreatedBy { get; set; }
public bool IsEntry91Active { get; set; }
public int Entry91SortOrder { get; set; }


public int Config68Id { get; set; }
public string Config68Name { get; set; }
public string Config68Description { get; set; }
public DateTime Config68CreatedAt { get; set; }
public DateTime? Config68UpdatedAt { get; set; }
public string Config68CreatedBy { get; set; }
public bool IsConfig68Active { get; set; }
public int Config68SortOrder { get; set; }


public int Item89Id { get; set; }
public string Item89Name { get; set; }
public string Item89Description { get; set; }
public DateTime Item89CreatedAt { get; set; }
public DateTime? Item89UpdatedAt { get; set; }
public string Item89CreatedBy { get; set; }
public bool IsItem89Active { get; set; }
public int Item89SortOrder { get; set; }


public int Item30Id { get; set; }
public string Item30Name { get; set; }
public string Item30Description { get; set; }
public DateTime Item30CreatedAt { get; set; }
public DateTime? Item30UpdatedAt { get; set; }
public string Item30CreatedBy { get; set; }
public bool IsItem30Active { get; set; }
public int Item30SortOrder { get; set; }


public int Record12Id { get; set; }
public string Record12Name { get; set; }
public string Record12Description { get; set; }
public DateTime Record12CreatedAt { get; set; }
public DateTime? Record12UpdatedAt { get; set; }
public string Record12CreatedBy { get; set; }
public bool IsRecord12Active { get; set; }
public int Record12SortOrder { get; set; }


public int Field48Id { get; set; }
public string Field48Name { get; set; }
public string Field48Description { get; set; }
public DateTime Field48CreatedAt { get; set; }
public DateTime? Field48UpdatedAt { get; set; }
public string Field48CreatedBy { get; set; }
public bool IsField48Active { get; set; }
public int Field48SortOrder { get; set; }


public int Param7Id { get; set; }
public string Param7Name { get; set; }
public string Param7Description { get; set; }
public DateTime Param7CreatedAt { get; set; }
public DateTime? Param7UpdatedAt { get; set; }
public string Param7CreatedBy { get; set; }
public bool IsParam7Active { get; set; }
public int Param7SortOrder { get; set; }


public int Item42Id { get; set; }
public string Item42Name { get; set; }
public string Item42Description { get; set; }
public DateTime Item42CreatedAt { get; set; }
public DateTime? Item42UpdatedAt { get; set; }
public string Item42CreatedBy { get; set; }
public bool IsItem42Active { get; set; }
public int Item42SortOrder { get; set; }


public int Detail51Id { get; set; }
public string Detail51Name { get; set; }
public string Detail51Description { get; set; }
public DateTime Detail51CreatedAt { get; set; }
public DateTime? Detail51UpdatedAt { get; set; }
public string Detail51CreatedBy { get; set; }
public bool IsDetail51Active { get; set; }
public int Detail51SortOrder { get; set; }


public int Item57Id { get; set; }
public string Item57Name { get; set; }
public string Item57Description { get; set; }
public DateTime Item57CreatedAt { get; set; }
public DateTime? Item57UpdatedAt { get; set; }
public string Item57CreatedBy { get; set; }
public bool IsItem57Active { get; set; }
public int Item57SortOrder { get; set; }


public int Field99Id { get; set; }
public string Field99Name { get; set; }
public string Field99Description { get; set; }
public DateTime Field99CreatedAt { get; set; }
public DateTime? Field99UpdatedAt { get; set; }
public string Field99CreatedBy { get; set; }
public bool IsField99Active { get; set; }
public int Field99SortOrder { get; set; }


public int Detail38Id { get; set; }
public string Detail38Name { get; set; }
public string Detail38Description { get; set; }
public DateTime Detail38CreatedAt { get; set; }
public DateTime? Detail38UpdatedAt { get; set; }
public string Detail38CreatedBy { get; set; }
public bool IsDetail38Active { get; set; }
public int Detail38SortOrder { get; set; }


public int Field8Id { get; set; }
public string Field8Name { get; set; }
public string Field8Description { get; set; }
public DateTime Field8CreatedAt { get; set; }
public DateTime? Field8UpdatedAt { get; set; }
public string Field8CreatedBy { get; set; }
public bool IsField8Active { get; set; }
public int Field8SortOrder { get; set; }


public int Param87Id { get; set; }
public string Param87Name { get; set; }
public string Param87Description { get; set; }
public DateTime Param87CreatedAt { get; set; }
public DateTime? Param87UpdatedAt { get; set; }
public string Param87CreatedBy { get; set; }
public bool IsParam87Active { get; set; }
public int Param87SortOrder { get; set; }


public int Entry85Id { get; set; }
public string Entry85Name { get; set; }
public string Entry85Description { get; set; }
public DateTime Entry85CreatedAt { get; set; }
public DateTime? Entry85UpdatedAt { get; set; }
public string Entry85CreatedBy { get; set; }
public bool IsEntry85Active { get; set; }
public int Entry85SortOrder { get; set; }


public int Param83Id { get; set; }
public string Param83Name { get; set; }
public string Param83Description { get; set; }
public DateTime Param83CreatedAt { get; set; }
public DateTime? Param83UpdatedAt { get; set; }
public string Param83CreatedBy { get; set; }
public bool IsParam83Active { get; set; }
public int Param83SortOrder { get; set; }


public int Detail61Id { get; set; }
public string Detail61Name { get; set; }
public string Detail61Description { get; set; }
public DateTime Detail61CreatedAt { get; set; }
public DateTime? Detail61UpdatedAt { get; set; }
public string Detail61CreatedBy { get; set; }
public bool IsDetail61Active { get; set; }
public int Detail61SortOrder { get; set; }


public int Param74Id { get; set; }
public string Param74Name { get; set; }
public string Param74Description { get; set; }
public DateTime Param74CreatedAt { get; set; }
public DateTime? Param74UpdatedAt { get; set; }
public string Param74CreatedBy { get; set; }
public bool IsParam74Active { get; set; }
public int Param74SortOrder { get; set; }


public int Entry73Id { get; set; }
public string Entry73Name { get; set; }
public string Entry73Description { get; set; }
public DateTime Entry73CreatedAt { get; set; }
public DateTime? Entry73UpdatedAt { get; set; }
public string Entry73CreatedBy { get; set; }
public bool IsEntry73Active { get; set; }
public int Entry73SortOrder { get; set; }


public int Record30Id { get; set; }
public string Record30Name { get; set; }
public string Record30Description { get; set; }
public DateTime Record30CreatedAt { get; set; }
public DateTime? Record30UpdatedAt { get; set; }
public string Record30CreatedBy { get; set; }
public bool IsRecord30Active { get; set; }
public int Record30SortOrder { get; set; }


public int Config81Id { get; set; }
public string Config81Name { get; set; }
public string Config81Description { get; set; }
public DateTime Config81CreatedAt { get; set; }
public DateTime? Config81UpdatedAt { get; set; }
public string Config81CreatedBy { get; set; }
public bool IsConfig81Active { get; set; }
public int Config81SortOrder { get; set; }


public int Record12Id { get; set; }
public string Record12Name { get; set; }
public string Record12Description { get; set; }
public DateTime Record12CreatedAt { get; set; }
public DateTime? Record12UpdatedAt { get; set; }
public string Record12CreatedBy { get; set; }
public bool IsRecord12Active { get; set; }
public int Record12SortOrder { get; set; }


public int Param7Id { get; set; }
public string Param7Name { get; set; }
public string Param7Description { get; set; }
public DateTime Param7CreatedAt { get; set; }
public DateTime? Param7UpdatedAt { get; set; }
public string Param7CreatedBy { get; set; }
public bool IsParam7Active { get; set; }
public int Param7SortOrder { get; set; }


public int Record42Id { get; set; }
public string Record42Name { get; set; }
public string Record42Description { get; set; }
public DateTime Record42CreatedAt { get; set; }
public DateTime? Record42UpdatedAt { get; set; }
public string Record42CreatedBy { get; set; }
public bool IsRecord42Active { get; set; }
public int Record42SortOrder { get; set; }


public int Param10Id { get; set; }
public string Param10Name { get; set; }
public string Param10Description { get; set; }
public DateTime Param10CreatedAt { get; set; }
public DateTime? Param10UpdatedAt { get; set; }
public string Param10CreatedBy { get; set; }
public bool IsParam10Active { get; set; }
public int Param10SortOrder { get; set; }


public int Param63Id { get; set; }
public string Param63Name { get; set; }
public string Param63Description { get; set; }
public DateTime Param63CreatedAt { get; set; }
public DateTime? Param63UpdatedAt { get; set; }
public string Param63CreatedBy { get; set; }
public bool IsParam63Active { get; set; }
public int Param63SortOrder { get; set; }


public int Detail93Id { get; set; }
public string Detail93Name { get; set; }
public string Detail93Description { get; set; }
public DateTime Detail93CreatedAt { get; set; }
public DateTime? Detail93UpdatedAt { get; set; }
public string Detail93CreatedBy { get; set; }
public bool IsDetail93Active { get; set; }
public int Detail93SortOrder { get; set; }


public int Record18Id { get; set; }
public string Record18Name { get; set; }
public string Record18Description { get; set; }
public DateTime Record18CreatedAt { get; set; }
public DateTime? Record18UpdatedAt { get; set; }
public string Record18CreatedBy { get; set; }
public bool IsRecord18Active { get; set; }
public int Record18SortOrder { get; set; }


public int Field89Id { get; set; }
public string Field89Name { get; set; }
public string Field89Description { get; set; }
public DateTime Field89CreatedAt { get; set; }
public DateTime? Field89UpdatedAt { get; set; }
public string Field89CreatedBy { get; set; }
public bool IsField89Active { get; set; }
public int Field89SortOrder { get; set; }


public int Entry99Id { get; set; }
public string Entry99Name { get; set; }
public string Entry99Description { get; set; }
public DateTime Entry99CreatedAt { get; set; }
public DateTime? Entry99UpdatedAt { get; set; }
public string Entry99CreatedBy { get; set; }
public bool IsEntry99Active { get; set; }
public int Entry99SortOrder { get; set; }


public int Detail8Id { get; set; }
public string Detail8Name { get; set; }
public string Detail8Description { get; set; }
public DateTime Detail8CreatedAt { get; set; }
public DateTime? Detail8UpdatedAt { get; set; }
public string Detail8CreatedBy { get; set; }
public bool IsDetail8Active { get; set; }
public int Detail8SortOrder { get; set; }


public int Attr63Id { get; set; }
public string Attr63Name { get; set; }
public string Attr63Description { get; set; }
public DateTime Attr63CreatedAt { get; set; }
public DateTime? Attr63UpdatedAt { get; set; }
public string Attr63CreatedBy { get; set; }
public bool IsAttr63Active { get; set; }
public int Attr63SortOrder { get; set; }


public int Config42Id { get; set; }
public string Config42Name { get; set; }
public string Config42Description { get; set; }
public DateTime Config42CreatedAt { get; set; }
public DateTime? Config42UpdatedAt { get; set; }
public string Config42CreatedBy { get; set; }
public bool IsConfig42Active { get; set; }
public int Config42SortOrder { get; set; }


public int Record94Id { get; set; }
public string Record94Name { get; set; }
public string Record94Description { get; set; }
public DateTime Record94CreatedAt { get; set; }
public DateTime? Record94UpdatedAt { get; set; }
public string Record94CreatedBy { get; set; }
public bool IsRecord94Active { get; set; }
public int Record94SortOrder { get; set; }


public int Item72Id { get; set; }
public string Item72Name { get; set; }
public string Item72Description { get; set; }
public DateTime Item72CreatedAt { get; set; }
public DateTime? Item72UpdatedAt { get; set; }
public string Item72CreatedBy { get; set; }
public bool IsItem72Active { get; set; }
public int Item72SortOrder { get; set; }


public int Detail96Id { get; set; }
public string Detail96Name { get; set; }
public string Detail96Description { get; set; }
public DateTime Detail96CreatedAt { get; set; }
public DateTime? Detail96UpdatedAt { get; set; }
public string Detail96CreatedBy { get; set; }
public bool IsDetail96Active { get; set; }
public int Detail96SortOrder { get; set; }


public int Attr57Id { get; set; }
public string Attr57Name { get; set; }
public string Attr57Description { get; set; }
public DateTime Attr57CreatedAt { get; set; }
public DateTime? Attr57UpdatedAt { get; set; }
public string Attr57CreatedBy { get; set; }
public bool IsAttr57Active { get; set; }
public int Attr57SortOrder { get; set; }

    }
}