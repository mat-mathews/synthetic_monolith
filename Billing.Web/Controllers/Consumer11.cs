using Admin.Data;
using Admin.Events235;
using Auth.Handlers;
using Auth.Shared;
using DataAccess.Contracts404;
using DataAccess.Validators;
using Import.Api314;
using Import.Processors412;
using Import.Processors472;
using Logging.Contracts;
using Notifications.Validators252;
using Portal.Data266;
using Reporting.Events220;
using Security.Handlers460;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Mappers97;
using Workflow.Core;
using Workflow.Tests27;

namespace Billing.Web
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer11
    {
        private readonly Admin_Events235_Request3 _admin_Events235_Request3;
        private readonly Admin_Data_Service5 _admin_Data_Service5;
        private readonly Admin_Data_Helper _admin_Data_Helper;
        private readonly Logging_Contracts_Builder5 _logging_Contracts_Builder5;
        private readonly Auth_Shared_Manager6 _auth_Shared_Manager6;
        private readonly Auth_Shared_Repository7 _auth_Shared_Repository7;
        private readonly Auth_Shared_Repository4 _auth_Shared_Repository4;
        private readonly Import_Processors472_Service _import_Processors472_Service;

        public Consumer11(Admin_Events235_Request3 admin_Events235_Request3, Admin_Data_Service5 admin_Data_Service5, Admin_Data_Helper admin_Data_Helper, Logging_Contracts_Builder5 logging_Contracts_Builder5, Auth_Shared_Manager6 auth_Shared_Manager6, Auth_Shared_Repository7 auth_Shared_Repository7, Auth_Shared_Repository4 auth_Shared_Repository4, Import_Processors472_Service import_Processors472_Service)
        {
            _admin_Events235_Request3 = admin_Events235_Request3 ?? throw new ArgumentNullException(nameof(admin_Events235_Request3));
            _admin_Data_Service5 = admin_Data_Service5 ?? throw new ArgumentNullException(nameof(admin_Data_Service5));
            _admin_Data_Helper = admin_Data_Helper ?? throw new ArgumentNullException(nameof(admin_Data_Helper));
            _logging_Contracts_Builder5 = logging_Contracts_Builder5 ?? throw new ArgumentNullException(nameof(logging_Contracts_Builder5));
            _auth_Shared_Manager6 = auth_Shared_Manager6 ?? throw new ArgumentNullException(nameof(auth_Shared_Manager6));
            _auth_Shared_Repository7 = auth_Shared_Repository7 ?? throw new ArgumentNullException(nameof(auth_Shared_Repository7));
            _auth_Shared_Repository4 = auth_Shared_Repository4 ?? throw new ArgumentNullException(nameof(auth_Shared_Repository4));
            _import_Processors472_Service = import_Processors472_Service ?? throw new ArgumentNullException(nameof(import_Processors472_Service));
        }

        public Admin_Events235_Request3 GetAdmin_Events235_Request3() => _admin_Events235_Request3;
        public Admin_Data_Service5 GetAdmin_Data_Service5() => _admin_Data_Service5;
        public Admin_Data_Helper GetAdmin_Data_Helper() => _admin_Data_Helper;
        public Logging_Contracts_Builder5 GetLogging_Contracts_Builder5() => _logging_Contracts_Builder5;
        public Auth_Shared_Manager6 GetAuth_Shared_Manager6() => _auth_Shared_Manager6;
        public Auth_Shared_Repository7 GetAuth_Shared_Repository7() => _auth_Shared_Repository7;
        public Auth_Shared_Repository4 GetAuth_Shared_Repository4() => _auth_Shared_Repository4;
        public Import_Processors472_Service GetImport_Processors472_Service() => _import_Processors472_Service;

/// <summary>
/// Validates the Consumer11 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer11(Consumer11Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer11));
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
/// Processes the Consumer11 operation asynchronously.
/// </summary>
public async Task<Consumer11Result> ProcessConsumer11Async(
    Consumer11Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer11), request.Id);

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
            return new Consumer11Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer11));
        return new Consumer11Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer11));
        return new Consumer11Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer11 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer11Dto>> GetConsumer11ListAsync(
    Consumer11Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer11Entity>().AsQueryable();

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
        .Select(x => new Consumer11Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer11Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer11Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer11Service(
    ILogger<Consumer11Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer11:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer11 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer11Data> GetCachedConsumer11Async(string key)
{
    var cacheKey = $"Consumer11_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer11Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer11SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Entry90Id { get; set; }
public string Entry90Name { get; set; }
public string Entry90Description { get; set; }
public DateTime Entry90CreatedAt { get; set; }
public DateTime? Entry90UpdatedAt { get; set; }
public string Entry90CreatedBy { get; set; }
public bool IsEntry90Active { get; set; }
public int Entry90SortOrder { get; set; }


public int Entry1Id { get; set; }
public string Entry1Name { get; set; }
public string Entry1Description { get; set; }
public DateTime Entry1CreatedAt { get; set; }
public DateTime? Entry1UpdatedAt { get; set; }
public string Entry1CreatedBy { get; set; }
public bool IsEntry1Active { get; set; }
public int Entry1SortOrder { get; set; }


public int Record45Id { get; set; }
public string Record45Name { get; set; }
public string Record45Description { get; set; }
public DateTime Record45CreatedAt { get; set; }
public DateTime? Record45UpdatedAt { get; set; }
public string Record45CreatedBy { get; set; }
public bool IsRecord45Active { get; set; }
public int Record45SortOrder { get; set; }


public int Attr22Id { get; set; }
public string Attr22Name { get; set; }
public string Attr22Description { get; set; }
public DateTime Attr22CreatedAt { get; set; }
public DateTime? Attr22UpdatedAt { get; set; }
public string Attr22CreatedBy { get; set; }
public bool IsAttr22Active { get; set; }
public int Attr22SortOrder { get; set; }


public int Entry63Id { get; set; }
public string Entry63Name { get; set; }
public string Entry63Description { get; set; }
public DateTime Entry63CreatedAt { get; set; }
public DateTime? Entry63UpdatedAt { get; set; }
public string Entry63CreatedBy { get; set; }
public bool IsEntry63Active { get; set; }
public int Entry63SortOrder { get; set; }


public int Config69Id { get; set; }
public string Config69Name { get; set; }
public string Config69Description { get; set; }
public DateTime Config69CreatedAt { get; set; }
public DateTime? Config69UpdatedAt { get; set; }
public string Config69CreatedBy { get; set; }
public bool IsConfig69Active { get; set; }
public int Config69SortOrder { get; set; }


public int Attr91Id { get; set; }
public string Attr91Name { get; set; }
public string Attr91Description { get; set; }
public DateTime Attr91CreatedAt { get; set; }
public DateTime? Attr91UpdatedAt { get; set; }
public string Attr91CreatedBy { get; set; }
public bool IsAttr91Active { get; set; }
public int Attr91SortOrder { get; set; }


public int Attr37Id { get; set; }
public string Attr37Name { get; set; }
public string Attr37Description { get; set; }
public DateTime Attr37CreatedAt { get; set; }
public DateTime? Attr37UpdatedAt { get; set; }
public string Attr37CreatedBy { get; set; }
public bool IsAttr37Active { get; set; }
public int Attr37SortOrder { get; set; }


public int Entry44Id { get; set; }
public string Entry44Name { get; set; }
public string Entry44Description { get; set; }
public DateTime Entry44CreatedAt { get; set; }
public DateTime? Entry44UpdatedAt { get; set; }
public string Entry44CreatedBy { get; set; }
public bool IsEntry44Active { get; set; }
public int Entry44SortOrder { get; set; }


public int Detail18Id { get; set; }
public string Detail18Name { get; set; }
public string Detail18Description { get; set; }
public DateTime Detail18CreatedAt { get; set; }
public DateTime? Detail18UpdatedAt { get; set; }
public string Detail18CreatedBy { get; set; }
public bool IsDetail18Active { get; set; }
public int Detail18SortOrder { get; set; }


public int Detail58Id { get; set; }
public string Detail58Name { get; set; }
public string Detail58Description { get; set; }
public DateTime Detail58CreatedAt { get; set; }
public DateTime? Detail58UpdatedAt { get; set; }
public string Detail58CreatedBy { get; set; }
public bool IsDetail58Active { get; set; }
public int Detail58SortOrder { get; set; }


public int Field71Id { get; set; }
public string Field71Name { get; set; }
public string Field71Description { get; set; }
public DateTime Field71CreatedAt { get; set; }
public DateTime? Field71UpdatedAt { get; set; }
public string Field71CreatedBy { get; set; }
public bool IsField71Active { get; set; }
public int Field71SortOrder { get; set; }


public int Record65Id { get; set; }
public string Record65Name { get; set; }
public string Record65Description { get; set; }
public DateTime Record65CreatedAt { get; set; }
public DateTime? Record65UpdatedAt { get; set; }
public string Record65CreatedBy { get; set; }
public bool IsRecord65Active { get; set; }
public int Record65SortOrder { get; set; }


public int Attr78Id { get; set; }
public string Attr78Name { get; set; }
public string Attr78Description { get; set; }
public DateTime Attr78CreatedAt { get; set; }
public DateTime? Attr78UpdatedAt { get; set; }
public string Attr78CreatedBy { get; set; }
public bool IsAttr78Active { get; set; }
public int Attr78SortOrder { get; set; }


public int Item83Id { get; set; }
public string Item83Name { get; set; }
public string Item83Description { get; set; }
public DateTime Item83CreatedAt { get; set; }
public DateTime? Item83UpdatedAt { get; set; }
public string Item83CreatedBy { get; set; }
public bool IsItem83Active { get; set; }
public int Item83SortOrder { get; set; }


public int Attr35Id { get; set; }
public string Attr35Name { get; set; }
public string Attr35Description { get; set; }
public DateTime Attr35CreatedAt { get; set; }
public DateTime? Attr35UpdatedAt { get; set; }
public string Attr35CreatedBy { get; set; }
public bool IsAttr35Active { get; set; }
public int Attr35SortOrder { get; set; }


public int Field92Id { get; set; }
public string Field92Name { get; set; }
public string Field92Description { get; set; }
public DateTime Field92CreatedAt { get; set; }
public DateTime? Field92UpdatedAt { get; set; }
public string Field92CreatedBy { get; set; }
public bool IsField92Active { get; set; }
public int Field92SortOrder { get; set; }


public int Item38Id { get; set; }
public string Item38Name { get; set; }
public string Item38Description { get; set; }
public DateTime Item38CreatedAt { get; set; }
public DateTime? Item38UpdatedAt { get; set; }
public string Item38CreatedBy { get; set; }
public bool IsItem38Active { get; set; }
public int Item38SortOrder { get; set; }


public int Record66Id { get; set; }
public string Record66Name { get; set; }
public string Record66Description { get; set; }
public DateTime Record66CreatedAt { get; set; }
public DateTime? Record66UpdatedAt { get; set; }
public string Record66CreatedBy { get; set; }
public bool IsRecord66Active { get; set; }
public int Record66SortOrder { get; set; }


public int Field35Id { get; set; }
public string Field35Name { get; set; }
public string Field35Description { get; set; }
public DateTime Field35CreatedAt { get; set; }
public DateTime? Field35UpdatedAt { get; set; }
public string Field35CreatedBy { get; set; }
public bool IsField35Active { get; set; }
public int Field35SortOrder { get; set; }


public int Item51Id { get; set; }
public string Item51Name { get; set; }
public string Item51Description { get; set; }
public DateTime Item51CreatedAt { get; set; }
public DateTime? Item51UpdatedAt { get; set; }
public string Item51CreatedBy { get; set; }
public bool IsItem51Active { get; set; }
public int Item51SortOrder { get; set; }


public int Detail99Id { get; set; }
public string Detail99Name { get; set; }
public string Detail99Description { get; set; }
public DateTime Detail99CreatedAt { get; set; }
public DateTime? Detail99UpdatedAt { get; set; }
public string Detail99CreatedBy { get; set; }
public bool IsDetail99Active { get; set; }
public int Detail99SortOrder { get; set; }


public int Record94Id { get; set; }
public string Record94Name { get; set; }
public string Record94Description { get; set; }
public DateTime Record94CreatedAt { get; set; }
public DateTime? Record94UpdatedAt { get; set; }
public string Record94CreatedBy { get; set; }
public bool IsRecord94Active { get; set; }
public int Record94SortOrder { get; set; }


public int Param28Id { get; set; }
public string Param28Name { get; set; }
public string Param28Description { get; set; }
public DateTime Param28CreatedAt { get; set; }
public DateTime? Param28UpdatedAt { get; set; }
public string Param28CreatedBy { get; set; }
public bool IsParam28Active { get; set; }
public int Param28SortOrder { get; set; }


public int Attr13Id { get; set; }
public string Attr13Name { get; set; }
public string Attr13Description { get; set; }
public DateTime Attr13CreatedAt { get; set; }
public DateTime? Attr13UpdatedAt { get; set; }
public string Attr13CreatedBy { get; set; }
public bool IsAttr13Active { get; set; }
public int Attr13SortOrder { get; set; }


public int Attr65Id { get; set; }
public string Attr65Name { get; set; }
public string Attr65Description { get; set; }
public DateTime Attr65CreatedAt { get; set; }
public DateTime? Attr65UpdatedAt { get; set; }
public string Attr65CreatedBy { get; set; }
public bool IsAttr65Active { get; set; }
public int Attr65SortOrder { get; set; }


public int Field8Id { get; set; }
public string Field8Name { get; set; }
public string Field8Description { get; set; }
public DateTime Field8CreatedAt { get; set; }
public DateTime? Field8UpdatedAt { get; set; }
public string Field8CreatedBy { get; set; }
public bool IsField8Active { get; set; }
public int Field8SortOrder { get; set; }


public int Entry78Id { get; set; }
public string Entry78Name { get; set; }
public string Entry78Description { get; set; }
public DateTime Entry78CreatedAt { get; set; }
public DateTime? Entry78UpdatedAt { get; set; }
public string Entry78CreatedBy { get; set; }
public bool IsEntry78Active { get; set; }
public int Entry78SortOrder { get; set; }


public int Entry52Id { get; set; }
public string Entry52Name { get; set; }
public string Entry52Description { get; set; }
public DateTime Entry52CreatedAt { get; set; }
public DateTime? Entry52UpdatedAt { get; set; }
public string Entry52CreatedBy { get; set; }
public bool IsEntry52Active { get; set; }
public int Entry52SortOrder { get; set; }


public int Record8Id { get; set; }
public string Record8Name { get; set; }
public string Record8Description { get; set; }
public DateTime Record8CreatedAt { get; set; }
public DateTime? Record8UpdatedAt { get; set; }
public string Record8CreatedBy { get; set; }
public bool IsRecord8Active { get; set; }
public int Record8SortOrder { get; set; }


public int Field87Id { get; set; }
public string Field87Name { get; set; }
public string Field87Description { get; set; }
public DateTime Field87CreatedAt { get; set; }
public DateTime? Field87UpdatedAt { get; set; }
public string Field87CreatedBy { get; set; }
public bool IsField87Active { get; set; }
public int Field87SortOrder { get; set; }


public int Config25Id { get; set; }
public string Config25Name { get; set; }
public string Config25Description { get; set; }
public DateTime Config25CreatedAt { get; set; }
public DateTime? Config25UpdatedAt { get; set; }
public string Config25CreatedBy { get; set; }
public bool IsConfig25Active { get; set; }
public int Config25SortOrder { get; set; }


public int Param78Id { get; set; }
public string Param78Name { get; set; }
public string Param78Description { get; set; }
public DateTime Param78CreatedAt { get; set; }
public DateTime? Param78UpdatedAt { get; set; }
public string Param78CreatedBy { get; set; }
public bool IsParam78Active { get; set; }
public int Param78SortOrder { get; set; }


public int Field62Id { get; set; }
public string Field62Name { get; set; }
public string Field62Description { get; set; }
public DateTime Field62CreatedAt { get; set; }
public DateTime? Field62UpdatedAt { get; set; }
public string Field62CreatedBy { get; set; }
public bool IsField62Active { get; set; }
public int Field62SortOrder { get; set; }


public int Detail74Id { get; set; }
public string Detail74Name { get; set; }
public string Detail74Description { get; set; }
public DateTime Detail74CreatedAt { get; set; }
public DateTime? Detail74UpdatedAt { get; set; }
public string Detail74CreatedBy { get; set; }
public bool IsDetail74Active { get; set; }
public int Detail74SortOrder { get; set; }


public int Param65Id { get; set; }
public string Param65Name { get; set; }
public string Param65Description { get; set; }
public DateTime Param65CreatedAt { get; set; }
public DateTime? Param65UpdatedAt { get; set; }
public string Param65CreatedBy { get; set; }
public bool IsParam65Active { get; set; }
public int Param65SortOrder { get; set; }


public int Detail61Id { get; set; }
public string Detail61Name { get; set; }
public string Detail61Description { get; set; }
public DateTime Detail61CreatedAt { get; set; }
public DateTime? Detail61UpdatedAt { get; set; }
public string Detail61CreatedBy { get; set; }
public bool IsDetail61Active { get; set; }
public int Detail61SortOrder { get; set; }


public int Field66Id { get; set; }
public string Field66Name { get; set; }
public string Field66Description { get; set; }
public DateTime Field66CreatedAt { get; set; }
public DateTime? Field66UpdatedAt { get; set; }
public string Field66CreatedBy { get; set; }
public bool IsField66Active { get; set; }
public int Field66SortOrder { get; set; }


public int Item60Id { get; set; }
public string Item60Name { get; set; }
public string Item60Description { get; set; }
public DateTime Item60CreatedAt { get; set; }
public DateTime? Item60UpdatedAt { get; set; }
public string Item60CreatedBy { get; set; }
public bool IsItem60Active { get; set; }
public int Item60SortOrder { get; set; }


public int Item90Id { get; set; }
public string Item90Name { get; set; }
public string Item90Description { get; set; }
public DateTime Item90CreatedAt { get; set; }
public DateTime? Item90UpdatedAt { get; set; }
public string Item90CreatedBy { get; set; }
public bool IsItem90Active { get; set; }
public int Item90SortOrder { get; set; }


public int Item43Id { get; set; }
public string Item43Name { get; set; }
public string Item43Description { get; set; }
public DateTime Item43CreatedAt { get; set; }
public DateTime? Item43UpdatedAt { get; set; }
public string Item43CreatedBy { get; set; }
public bool IsItem43Active { get; set; }
public int Item43SortOrder { get; set; }


public int Config92Id { get; set; }
public string Config92Name { get; set; }
public string Config92Description { get; set; }
public DateTime Config92CreatedAt { get; set; }
public DateTime? Config92UpdatedAt { get; set; }
public string Config92CreatedBy { get; set; }
public bool IsConfig92Active { get; set; }
public int Config92SortOrder { get; set; }


public int Record50Id { get; set; }
public string Record50Name { get; set; }
public string Record50Description { get; set; }
public DateTime Record50CreatedAt { get; set; }
public DateTime? Record50UpdatedAt { get; set; }
public string Record50CreatedBy { get; set; }
public bool IsRecord50Active { get; set; }
public int Record50SortOrder { get; set; }


public int Param5Id { get; set; }
public string Param5Name { get; set; }
public string Param5Description { get; set; }
public DateTime Param5CreatedAt { get; set; }
public DateTime? Param5UpdatedAt { get; set; }
public string Param5CreatedBy { get; set; }
public bool IsParam5Active { get; set; }
public int Param5SortOrder { get; set; }


public int Config26Id { get; set; }
public string Config26Name { get; set; }
public string Config26Description { get; set; }
public DateTime Config26CreatedAt { get; set; }
public DateTime? Config26UpdatedAt { get; set; }
public string Config26CreatedBy { get; set; }
public bool IsConfig26Active { get; set; }
public int Config26SortOrder { get; set; }


public int Field38Id { get; set; }
public string Field38Name { get; set; }
public string Field38Description { get; set; }
public DateTime Field38CreatedAt { get; set; }
public DateTime? Field38UpdatedAt { get; set; }
public string Field38CreatedBy { get; set; }
public bool IsField38Active { get; set; }
public int Field38SortOrder { get; set; }

    }
}