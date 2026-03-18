using Admin.Client346;
using Admin.Handlers447;
using Auth.Client249;
using DataAccess.Client113;
using DataAccess.Core;
using DataAccess.Service464;
using Documents.Shared334;
using Export.Web479;
using GalaxyWorks.Events;
using GalaxyWorks.Processors16;
using Integration.Processors71;
using Integration.Validators369;
using Portal.Events;
using Portal.Handlers26;
using Portal.Shared;
using Reporting.Events483;
using Security.Client353;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Contracts32;

namespace Workflow.Client47
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer10
    {
        private readonly Admin_Client346_Provider3 _admin_Client346_Provider3;
        private readonly Admin_Client346_Builder7 _admin_Client346_Builder7;
        private readonly Admin_Client346_Manager11 _admin_Client346_Manager11;
        private readonly Admin_Handlers447_Command4 _admin_Handlers447_Command4;
        private readonly Auth_Client249_Builder11 _auth_Client249_Builder11;
        private readonly Auth_Client249_Provider6 _auth_Client249_Provider6;
        private readonly Auth_Client249_Dto2 _auth_Client249_Dto2;
        private readonly GalaxyWorks_Processors16_Helper2 _galaxyWorks_Processors16_Helper2;

        public Consumer10(Admin_Client346_Provider3 admin_Client346_Provider3, Admin_Client346_Builder7 admin_Client346_Builder7, Admin_Client346_Manager11 admin_Client346_Manager11, Admin_Handlers447_Command4 admin_Handlers447_Command4, Auth_Client249_Builder11 auth_Client249_Builder11, Auth_Client249_Provider6 auth_Client249_Provider6, Auth_Client249_Dto2 auth_Client249_Dto2, GalaxyWorks_Processors16_Helper2 galaxyWorks_Processors16_Helper2)
        {
            _admin_Client346_Provider3 = admin_Client346_Provider3 ?? throw new ArgumentNullException(nameof(admin_Client346_Provider3));
            _admin_Client346_Builder7 = admin_Client346_Builder7 ?? throw new ArgumentNullException(nameof(admin_Client346_Builder7));
            _admin_Client346_Manager11 = admin_Client346_Manager11 ?? throw new ArgumentNullException(nameof(admin_Client346_Manager11));
            _admin_Handlers447_Command4 = admin_Handlers447_Command4 ?? throw new ArgumentNullException(nameof(admin_Handlers447_Command4));
            _auth_Client249_Builder11 = auth_Client249_Builder11 ?? throw new ArgumentNullException(nameof(auth_Client249_Builder11));
            _auth_Client249_Provider6 = auth_Client249_Provider6 ?? throw new ArgumentNullException(nameof(auth_Client249_Provider6));
            _auth_Client249_Dto2 = auth_Client249_Dto2 ?? throw new ArgumentNullException(nameof(auth_Client249_Dto2));
            _galaxyWorks_Processors16_Helper2 = galaxyWorks_Processors16_Helper2 ?? throw new ArgumentNullException(nameof(galaxyWorks_Processors16_Helper2));
        }

        public Admin_Client346_Provider3 GetAdmin_Client346_Provider3() => _admin_Client346_Provider3;
        public Admin_Client346_Builder7 GetAdmin_Client346_Builder7() => _admin_Client346_Builder7;
        public Admin_Client346_Manager11 GetAdmin_Client346_Manager11() => _admin_Client346_Manager11;
        public Admin_Handlers447_Command4 GetAdmin_Handlers447_Command4() => _admin_Handlers447_Command4;
        public Auth_Client249_Builder11 GetAuth_Client249_Builder11() => _auth_Client249_Builder11;
        public Auth_Client249_Provider6 GetAuth_Client249_Provider6() => _auth_Client249_Provider6;
        public Auth_Client249_Dto2 GetAuth_Client249_Dto2() => _auth_Client249_Dto2;
        public GalaxyWorks_Processors16_Helper2 GetGalaxyWorks_Processors16_Helper2() => _galaxyWorks_Processors16_Helper2;

/// <summary>
/// Validates the Consumer10 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer10(Consumer10Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer10));
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
/// Processes the Consumer10 operation asynchronously.
/// </summary>
public async Task<Consumer10Result> ProcessConsumer10Async(
    Consumer10Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer10), request.Id);

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
            return new Consumer10Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer10));
        return new Consumer10Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer10));
        return new Consumer10Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer10 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer10Dto>> GetConsumer10ListAsync(
    Consumer10Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer10Entity>().AsQueryable();

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
        .Select(x => new Consumer10Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer10Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer10Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer10Service(
    ILogger<Consumer10Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer10:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer10 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer10Data> GetCachedConsumer10Async(string key)
{
    var cacheKey = $"Consumer10_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer10Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer10SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Config73Id { get; set; }
public string Config73Name { get; set; }
public string Config73Description { get; set; }
public DateTime Config73CreatedAt { get; set; }
public DateTime? Config73UpdatedAt { get; set; }
public string Config73CreatedBy { get; set; }
public bool IsConfig73Active { get; set; }
public int Config73SortOrder { get; set; }


public int Record3Id { get; set; }
public string Record3Name { get; set; }
public string Record3Description { get; set; }
public DateTime Record3CreatedAt { get; set; }
public DateTime? Record3UpdatedAt { get; set; }
public string Record3CreatedBy { get; set; }
public bool IsRecord3Active { get; set; }
public int Record3SortOrder { get; set; }


public int Param67Id { get; set; }
public string Param67Name { get; set; }
public string Param67Description { get; set; }
public DateTime Param67CreatedAt { get; set; }
public DateTime? Param67UpdatedAt { get; set; }
public string Param67CreatedBy { get; set; }
public bool IsParam67Active { get; set; }
public int Param67SortOrder { get; set; }


public int Attr1Id { get; set; }
public string Attr1Name { get; set; }
public string Attr1Description { get; set; }
public DateTime Attr1CreatedAt { get; set; }
public DateTime? Attr1UpdatedAt { get; set; }
public string Attr1CreatedBy { get; set; }
public bool IsAttr1Active { get; set; }
public int Attr1SortOrder { get; set; }


public int Item96Id { get; set; }
public string Item96Name { get; set; }
public string Item96Description { get; set; }
public DateTime Item96CreatedAt { get; set; }
public DateTime? Item96UpdatedAt { get; set; }
public string Item96CreatedBy { get; set; }
public bool IsItem96Active { get; set; }
public int Item96SortOrder { get; set; }


public int Field98Id { get; set; }
public string Field98Name { get; set; }
public string Field98Description { get; set; }
public DateTime Field98CreatedAt { get; set; }
public DateTime? Field98UpdatedAt { get; set; }
public string Field98CreatedBy { get; set; }
public bool IsField98Active { get; set; }
public int Field98SortOrder { get; set; }


public int Attr87Id { get; set; }
public string Attr87Name { get; set; }
public string Attr87Description { get; set; }
public DateTime Attr87CreatedAt { get; set; }
public DateTime? Attr87UpdatedAt { get; set; }
public string Attr87CreatedBy { get; set; }
public bool IsAttr87Active { get; set; }
public int Attr87SortOrder { get; set; }


public int Field39Id { get; set; }
public string Field39Name { get; set; }
public string Field39Description { get; set; }
public DateTime Field39CreatedAt { get; set; }
public DateTime? Field39UpdatedAt { get; set; }
public string Field39CreatedBy { get; set; }
public bool IsField39Active { get; set; }
public int Field39SortOrder { get; set; }


public int Entry2Id { get; set; }
public string Entry2Name { get; set; }
public string Entry2Description { get; set; }
public DateTime Entry2CreatedAt { get; set; }
public DateTime? Entry2UpdatedAt { get; set; }
public string Entry2CreatedBy { get; set; }
public bool IsEntry2Active { get; set; }
public int Entry2SortOrder { get; set; }


public int Record96Id { get; set; }
public string Record96Name { get; set; }
public string Record96Description { get; set; }
public DateTime Record96CreatedAt { get; set; }
public DateTime? Record96UpdatedAt { get; set; }
public string Record96CreatedBy { get; set; }
public bool IsRecord96Active { get; set; }
public int Record96SortOrder { get; set; }


public int Detail70Id { get; set; }
public string Detail70Name { get; set; }
public string Detail70Description { get; set; }
public DateTime Detail70CreatedAt { get; set; }
public DateTime? Detail70UpdatedAt { get; set; }
public string Detail70CreatedBy { get; set; }
public bool IsDetail70Active { get; set; }
public int Detail70SortOrder { get; set; }


public int Attr48Id { get; set; }
public string Attr48Name { get; set; }
public string Attr48Description { get; set; }
public DateTime Attr48CreatedAt { get; set; }
public DateTime? Attr48UpdatedAt { get; set; }
public string Attr48CreatedBy { get; set; }
public bool IsAttr48Active { get; set; }
public int Attr48SortOrder { get; set; }


public int Param8Id { get; set; }
public string Param8Name { get; set; }
public string Param8Description { get; set; }
public DateTime Param8CreatedAt { get; set; }
public DateTime? Param8UpdatedAt { get; set; }
public string Param8CreatedBy { get; set; }
public bool IsParam8Active { get; set; }
public int Param8SortOrder { get; set; }


public int Entry10Id { get; set; }
public string Entry10Name { get; set; }
public string Entry10Description { get; set; }
public DateTime Entry10CreatedAt { get; set; }
public DateTime? Entry10UpdatedAt { get; set; }
public string Entry10CreatedBy { get; set; }
public bool IsEntry10Active { get; set; }
public int Entry10SortOrder { get; set; }


public int Field77Id { get; set; }
public string Field77Name { get; set; }
public string Field77Description { get; set; }
public DateTime Field77CreatedAt { get; set; }
public DateTime? Field77UpdatedAt { get; set; }
public string Field77CreatedBy { get; set; }
public bool IsField77Active { get; set; }
public int Field77SortOrder { get; set; }


public int Field85Id { get; set; }
public string Field85Name { get; set; }
public string Field85Description { get; set; }
public DateTime Field85CreatedAt { get; set; }
public DateTime? Field85UpdatedAt { get; set; }
public string Field85CreatedBy { get; set; }
public bool IsField85Active { get; set; }
public int Field85SortOrder { get; set; }


public int Param77Id { get; set; }
public string Param77Name { get; set; }
public string Param77Description { get; set; }
public DateTime Param77CreatedAt { get; set; }
public DateTime? Param77UpdatedAt { get; set; }
public string Param77CreatedBy { get; set; }
public bool IsParam77Active { get; set; }
public int Param77SortOrder { get; set; }


public int Config52Id { get; set; }
public string Config52Name { get; set; }
public string Config52Description { get; set; }
public DateTime Config52CreatedAt { get; set; }
public DateTime? Config52UpdatedAt { get; set; }
public string Config52CreatedBy { get; set; }
public bool IsConfig52Active { get; set; }
public int Config52SortOrder { get; set; }


public int Record76Id { get; set; }
public string Record76Name { get; set; }
public string Record76Description { get; set; }
public DateTime Record76CreatedAt { get; set; }
public DateTime? Record76UpdatedAt { get; set; }
public string Record76CreatedBy { get; set; }
public bool IsRecord76Active { get; set; }
public int Record76SortOrder { get; set; }


public int Detail9Id { get; set; }
public string Detail9Name { get; set; }
public string Detail9Description { get; set; }
public DateTime Detail9CreatedAt { get; set; }
public DateTime? Detail9UpdatedAt { get; set; }
public string Detail9CreatedBy { get; set; }
public bool IsDetail9Active { get; set; }
public int Detail9SortOrder { get; set; }


public int Detail16Id { get; set; }
public string Detail16Name { get; set; }
public string Detail16Description { get; set; }
public DateTime Detail16CreatedAt { get; set; }
public DateTime? Detail16UpdatedAt { get; set; }
public string Detail16CreatedBy { get; set; }
public bool IsDetail16Active { get; set; }
public int Detail16SortOrder { get; set; }


public int Item70Id { get; set; }
public string Item70Name { get; set; }
public string Item70Description { get; set; }
public DateTime Item70CreatedAt { get; set; }
public DateTime? Item70UpdatedAt { get; set; }
public string Item70CreatedBy { get; set; }
public bool IsItem70Active { get; set; }
public int Item70SortOrder { get; set; }


public int Attr95Id { get; set; }
public string Attr95Name { get; set; }
public string Attr95Description { get; set; }
public DateTime Attr95CreatedAt { get; set; }
public DateTime? Attr95UpdatedAt { get; set; }
public string Attr95CreatedBy { get; set; }
public bool IsAttr95Active { get; set; }
public int Attr95SortOrder { get; set; }


public int Field83Id { get; set; }
public string Field83Name { get; set; }
public string Field83Description { get; set; }
public DateTime Field83CreatedAt { get; set; }
public DateTime? Field83UpdatedAt { get; set; }
public string Field83CreatedBy { get; set; }
public bool IsField83Active { get; set; }
public int Field83SortOrder { get; set; }


public int Record86Id { get; set; }
public string Record86Name { get; set; }
public string Record86Description { get; set; }
public DateTime Record86CreatedAt { get; set; }
public DateTime? Record86UpdatedAt { get; set; }
public string Record86CreatedBy { get; set; }
public bool IsRecord86Active { get; set; }
public int Record86SortOrder { get; set; }


public int Attr85Id { get; set; }
public string Attr85Name { get; set; }
public string Attr85Description { get; set; }
public DateTime Attr85CreatedAt { get; set; }
public DateTime? Attr85UpdatedAt { get; set; }
public string Attr85CreatedBy { get; set; }
public bool IsAttr85Active { get; set; }
public int Attr85SortOrder { get; set; }


public int Item99Id { get; set; }
public string Item99Name { get; set; }
public string Item99Description { get; set; }
public DateTime Item99CreatedAt { get; set; }
public DateTime? Item99UpdatedAt { get; set; }
public string Item99CreatedBy { get; set; }
public bool IsItem99Active { get; set; }
public int Item99SortOrder { get; set; }


public int Record27Id { get; set; }
public string Record27Name { get; set; }
public string Record27Description { get; set; }
public DateTime Record27CreatedAt { get; set; }
public DateTime? Record27UpdatedAt { get; set; }
public string Record27CreatedBy { get; set; }
public bool IsRecord27Active { get; set; }
public int Record27SortOrder { get; set; }


public int Config68Id { get; set; }
public string Config68Name { get; set; }
public string Config68Description { get; set; }
public DateTime Config68CreatedAt { get; set; }
public DateTime? Config68UpdatedAt { get; set; }
public string Config68CreatedBy { get; set; }
public bool IsConfig68Active { get; set; }
public int Config68SortOrder { get; set; }


public int Field51Id { get; set; }
public string Field51Name { get; set; }
public string Field51Description { get; set; }
public DateTime Field51CreatedAt { get; set; }
public DateTime? Field51UpdatedAt { get; set; }
public string Field51CreatedBy { get; set; }
public bool IsField51Active { get; set; }
public int Field51SortOrder { get; set; }


public int Param55Id { get; set; }
public string Param55Name { get; set; }
public string Param55Description { get; set; }
public DateTime Param55CreatedAt { get; set; }
public DateTime? Param55UpdatedAt { get; set; }
public string Param55CreatedBy { get; set; }
public bool IsParam55Active { get; set; }
public int Param55SortOrder { get; set; }


public int Attr76Id { get; set; }
public string Attr76Name { get; set; }
public string Attr76Description { get; set; }
public DateTime Attr76CreatedAt { get; set; }
public DateTime? Attr76UpdatedAt { get; set; }
public string Attr76CreatedBy { get; set; }
public bool IsAttr76Active { get; set; }
public int Attr76SortOrder { get; set; }


public int Param63Id { get; set; }
public string Param63Name { get; set; }
public string Param63Description { get; set; }
public DateTime Param63CreatedAt { get; set; }
public DateTime? Param63UpdatedAt { get; set; }
public string Param63CreatedBy { get; set; }
public bool IsParam63Active { get; set; }
public int Param63SortOrder { get; set; }


public int Field29Id { get; set; }
public string Field29Name { get; set; }
public string Field29Description { get; set; }
public DateTime Field29CreatedAt { get; set; }
public DateTime? Field29UpdatedAt { get; set; }
public string Field29CreatedBy { get; set; }
public bool IsField29Active { get; set; }
public int Field29SortOrder { get; set; }


public int Record18Id { get; set; }
public string Record18Name { get; set; }
public string Record18Description { get; set; }
public DateTime Record18CreatedAt { get; set; }
public DateTime? Record18UpdatedAt { get; set; }
public string Record18CreatedBy { get; set; }
public bool IsRecord18Active { get; set; }
public int Record18SortOrder { get; set; }


public int Attr34Id { get; set; }
public string Attr34Name { get; set; }
public string Attr34Description { get; set; }
public DateTime Attr34CreatedAt { get; set; }
public DateTime? Attr34UpdatedAt { get; set; }
public string Attr34CreatedBy { get; set; }
public bool IsAttr34Active { get; set; }
public int Attr34SortOrder { get; set; }


public int Detail30Id { get; set; }
public string Detail30Name { get; set; }
public string Detail30Description { get; set; }
public DateTime Detail30CreatedAt { get; set; }
public DateTime? Detail30UpdatedAt { get; set; }
public string Detail30CreatedBy { get; set; }
public bool IsDetail30Active { get; set; }
public int Detail30SortOrder { get; set; }


public int Param59Id { get; set; }
public string Param59Name { get; set; }
public string Param59Description { get; set; }
public DateTime Param59CreatedAt { get; set; }
public DateTime? Param59UpdatedAt { get; set; }
public string Param59CreatedBy { get; set; }
public bool IsParam59Active { get; set; }
public int Param59SortOrder { get; set; }


public int Item14Id { get; set; }
public string Item14Name { get; set; }
public string Item14Description { get; set; }
public DateTime Item14CreatedAt { get; set; }
public DateTime? Item14UpdatedAt { get; set; }
public string Item14CreatedBy { get; set; }
public bool IsItem14Active { get; set; }
public int Item14SortOrder { get; set; }


public int Item24Id { get; set; }
public string Item24Name { get; set; }
public string Item24Description { get; set; }
public DateTime Item24CreatedAt { get; set; }
public DateTime? Item24UpdatedAt { get; set; }
public string Item24CreatedBy { get; set; }
public bool IsItem24Active { get; set; }
public int Item24SortOrder { get; set; }


public int Record21Id { get; set; }
public string Record21Name { get; set; }
public string Record21Description { get; set; }
public DateTime Record21CreatedAt { get; set; }
public DateTime? Record21UpdatedAt { get; set; }
public string Record21CreatedBy { get; set; }
public bool IsRecord21Active { get; set; }
public int Record21SortOrder { get; set; }


public int Config89Id { get; set; }
public string Config89Name { get; set; }
public string Config89Description { get; set; }
public DateTime Config89CreatedAt { get; set; }
public DateTime? Config89UpdatedAt { get; set; }
public string Config89CreatedBy { get; set; }
public bool IsConfig89Active { get; set; }
public int Config89SortOrder { get; set; }


public int Field94Id { get; set; }
public string Field94Name { get; set; }
public string Field94Description { get; set; }
public DateTime Field94CreatedAt { get; set; }
public DateTime? Field94UpdatedAt { get; set; }
public string Field94CreatedBy { get; set; }
public bool IsField94Active { get; set; }
public int Field94SortOrder { get; set; }


public int Detail38Id { get; set; }
public string Detail38Name { get; set; }
public string Detail38Description { get; set; }
public DateTime Detail38CreatedAt { get; set; }
public DateTime? Detail38UpdatedAt { get; set; }
public string Detail38CreatedBy { get; set; }
public bool IsDetail38Active { get; set; }
public int Detail38SortOrder { get; set; }


public int Attr47Id { get; set; }
public string Attr47Name { get; set; }
public string Attr47Description { get; set; }
public DateTime Attr47CreatedAt { get; set; }
public DateTime? Attr47UpdatedAt { get; set; }
public string Attr47CreatedBy { get; set; }
public bool IsAttr47Active { get; set; }
public int Attr47SortOrder { get; set; }

    }
}