using Admin.Core121;
using Admin.Data408;
using Admin.Handlers447;
using Auth.Service;
using BatchJobs.Data176;
using BatchJobs.Mappers362;
using Common.Data126;
using DataAccess.Validators254;
using Documents.Events;
using Import.Events493;
using Import.Validators;
using Integration.Processors71;
using Logging.Data29;
using Logging.Handlers285;
using Notifications.Tests;
using Portal.Client;
using Scheduling.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Models441
{
    public class Scheduling_Models441_Handler4
    {
        private readonly string _sql = "SELECT * FROM AuditLogs WHERE Id = @Id";
        private readonly string _connStr = "Data Source=server.db;Database=MyDB";
        public void Execute()
        {
            // Scheduling_Models441_Handler4 implementation
        }

/// <summary>
/// Validates the Handler4 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateHandler4(Handler4Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Handler4));
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
/// Processes the Handler4 operation asynchronously.
/// </summary>
public async Task<Handler4Result> ProcessHandler4Async(
    Handler4Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Handler4), request.Id);

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
            return new Handler4Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Handler4));
        return new Handler4Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Handler4));
        return new Handler4Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Handler4 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Handler4Dto>> GetHandler4ListAsync(
    Handler4Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Handler4Entity>().AsQueryable();

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
        .Select(x => new Handler4Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Handler4Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Handler4Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Handler4Service(
    ILogger<Handler4Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Handler4:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Handler4 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Handler4Data> GetCachedHandler4Async(string key)
{
    var cacheKey = $"Handler4_{key}";

    if (_cache.TryGetValue(cacheKey, out Handler4Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromHandler4SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Entry4Id { get; set; }
public string Entry4Name { get; set; }
public string Entry4Description { get; set; }
public DateTime Entry4CreatedAt { get; set; }
public DateTime? Entry4UpdatedAt { get; set; }
public string Entry4CreatedBy { get; set; }
public bool IsEntry4Active { get; set; }
public int Entry4SortOrder { get; set; }


public int Item4Id { get; set; }
public string Item4Name { get; set; }
public string Item4Description { get; set; }
public DateTime Item4CreatedAt { get; set; }
public DateTime? Item4UpdatedAt { get; set; }
public string Item4CreatedBy { get; set; }
public bool IsItem4Active { get; set; }
public int Item4SortOrder { get; set; }


public int Detail41Id { get; set; }
public string Detail41Name { get; set; }
public string Detail41Description { get; set; }
public DateTime Detail41CreatedAt { get; set; }
public DateTime? Detail41UpdatedAt { get; set; }
public string Detail41CreatedBy { get; set; }
public bool IsDetail41Active { get; set; }
public int Detail41SortOrder { get; set; }


public int Record56Id { get; set; }
public string Record56Name { get; set; }
public string Record56Description { get; set; }
public DateTime Record56CreatedAt { get; set; }
public DateTime? Record56UpdatedAt { get; set; }
public string Record56CreatedBy { get; set; }
public bool IsRecord56Active { get; set; }
public int Record56SortOrder { get; set; }


public int Param80Id { get; set; }
public string Param80Name { get; set; }
public string Param80Description { get; set; }
public DateTime Param80CreatedAt { get; set; }
public DateTime? Param80UpdatedAt { get; set; }
public string Param80CreatedBy { get; set; }
public bool IsParam80Active { get; set; }
public int Param80SortOrder { get; set; }


public int Attr65Id { get; set; }
public string Attr65Name { get; set; }
public string Attr65Description { get; set; }
public DateTime Attr65CreatedAt { get; set; }
public DateTime? Attr65UpdatedAt { get; set; }
public string Attr65CreatedBy { get; set; }
public bool IsAttr65Active { get; set; }
public int Attr65SortOrder { get; set; }


public int Record18Id { get; set; }
public string Record18Name { get; set; }
public string Record18Description { get; set; }
public DateTime Record18CreatedAt { get; set; }
public DateTime? Record18UpdatedAt { get; set; }
public string Record18CreatedBy { get; set; }
public bool IsRecord18Active { get; set; }
public int Record18SortOrder { get; set; }


public int Attr97Id { get; set; }
public string Attr97Name { get; set; }
public string Attr97Description { get; set; }
public DateTime Attr97CreatedAt { get; set; }
public DateTime? Attr97UpdatedAt { get; set; }
public string Attr97CreatedBy { get; set; }
public bool IsAttr97Active { get; set; }
public int Attr97SortOrder { get; set; }


public int Item90Id { get; set; }
public string Item90Name { get; set; }
public string Item90Description { get; set; }
public DateTime Item90CreatedAt { get; set; }
public DateTime? Item90UpdatedAt { get; set; }
public string Item90CreatedBy { get; set; }
public bool IsItem90Active { get; set; }
public int Item90SortOrder { get; set; }


public int Item64Id { get; set; }
public string Item64Name { get; set; }
public string Item64Description { get; set; }
public DateTime Item64CreatedAt { get; set; }
public DateTime? Item64UpdatedAt { get; set; }
public string Item64CreatedBy { get; set; }
public bool IsItem64Active { get; set; }
public int Item64SortOrder { get; set; }


public int Record95Id { get; set; }
public string Record95Name { get; set; }
public string Record95Description { get; set; }
public DateTime Record95CreatedAt { get; set; }
public DateTime? Record95UpdatedAt { get; set; }
public string Record95CreatedBy { get; set; }
public bool IsRecord95Active { get; set; }
public int Record95SortOrder { get; set; }


public int Config52Id { get; set; }
public string Config52Name { get; set; }
public string Config52Description { get; set; }
public DateTime Config52CreatedAt { get; set; }
public DateTime? Config52UpdatedAt { get; set; }
public string Config52CreatedBy { get; set; }
public bool IsConfig52Active { get; set; }
public int Config52SortOrder { get; set; }


public int Config14Id { get; set; }
public string Config14Name { get; set; }
public string Config14Description { get; set; }
public DateTime Config14CreatedAt { get; set; }
public DateTime? Config14UpdatedAt { get; set; }
public string Config14CreatedBy { get; set; }
public bool IsConfig14Active { get; set; }
public int Config14SortOrder { get; set; }


public int Item15Id { get; set; }
public string Item15Name { get; set; }
public string Item15Description { get; set; }
public DateTime Item15CreatedAt { get; set; }
public DateTime? Item15UpdatedAt { get; set; }
public string Item15CreatedBy { get; set; }
public bool IsItem15Active { get; set; }
public int Item15SortOrder { get; set; }


public int Field7Id { get; set; }
public string Field7Name { get; set; }
public string Field7Description { get; set; }
public DateTime Field7CreatedAt { get; set; }
public DateTime? Field7UpdatedAt { get; set; }
public string Field7CreatedBy { get; set; }
public bool IsField7Active { get; set; }
public int Field7SortOrder { get; set; }


public int Detail38Id { get; set; }
public string Detail38Name { get; set; }
public string Detail38Description { get; set; }
public DateTime Detail38CreatedAt { get; set; }
public DateTime? Detail38UpdatedAt { get; set; }
public string Detail38CreatedBy { get; set; }
public bool IsDetail38Active { get; set; }
public int Detail38SortOrder { get; set; }


public int Item63Id { get; set; }
public string Item63Name { get; set; }
public string Item63Description { get; set; }
public DateTime Item63CreatedAt { get; set; }
public DateTime? Item63UpdatedAt { get; set; }
public string Item63CreatedBy { get; set; }
public bool IsItem63Active { get; set; }
public int Item63SortOrder { get; set; }


public int Param85Id { get; set; }
public string Param85Name { get; set; }
public string Param85Description { get; set; }
public DateTime Param85CreatedAt { get; set; }
public DateTime? Param85UpdatedAt { get; set; }
public string Param85CreatedBy { get; set; }
public bool IsParam85Active { get; set; }
public int Param85SortOrder { get; set; }


public int Detail45Id { get; set; }
public string Detail45Name { get; set; }
public string Detail45Description { get; set; }
public DateTime Detail45CreatedAt { get; set; }
public DateTime? Detail45UpdatedAt { get; set; }
public string Detail45CreatedBy { get; set; }
public bool IsDetail45Active { get; set; }
public int Detail45SortOrder { get; set; }


public int Attr27Id { get; set; }
public string Attr27Name { get; set; }
public string Attr27Description { get; set; }
public DateTime Attr27CreatedAt { get; set; }
public DateTime? Attr27UpdatedAt { get; set; }
public string Attr27CreatedBy { get; set; }
public bool IsAttr27Active { get; set; }
public int Attr27SortOrder { get; set; }


public int Field53Id { get; set; }
public string Field53Name { get; set; }
public string Field53Description { get; set; }
public DateTime Field53CreatedAt { get; set; }
public DateTime? Field53UpdatedAt { get; set; }
public string Field53CreatedBy { get; set; }
public bool IsField53Active { get; set; }
public int Field53SortOrder { get; set; }


public int Entry47Id { get; set; }
public string Entry47Name { get; set; }
public string Entry47Description { get; set; }
public DateTime Entry47CreatedAt { get; set; }
public DateTime? Entry47UpdatedAt { get; set; }
public string Entry47CreatedBy { get; set; }
public bool IsEntry47Active { get; set; }
public int Entry47SortOrder { get; set; }


public int Item17Id { get; set; }
public string Item17Name { get; set; }
public string Item17Description { get; set; }
public DateTime Item17CreatedAt { get; set; }
public DateTime? Item17UpdatedAt { get; set; }
public string Item17CreatedBy { get; set; }
public bool IsItem17Active { get; set; }
public int Item17SortOrder { get; set; }


public int Config49Id { get; set; }
public string Config49Name { get; set; }
public string Config49Description { get; set; }
public DateTime Config49CreatedAt { get; set; }
public DateTime? Config49UpdatedAt { get; set; }
public string Config49CreatedBy { get; set; }
public bool IsConfig49Active { get; set; }
public int Config49SortOrder { get; set; }


public int Detail19Id { get; set; }
public string Detail19Name { get; set; }
public string Detail19Description { get; set; }
public DateTime Detail19CreatedAt { get; set; }
public DateTime? Detail19UpdatedAt { get; set; }
public string Detail19CreatedBy { get; set; }
public bool IsDetail19Active { get; set; }
public int Detail19SortOrder { get; set; }


public int Detail87Id { get; set; }
public string Detail87Name { get; set; }
public string Detail87Description { get; set; }
public DateTime Detail87CreatedAt { get; set; }
public DateTime? Detail87UpdatedAt { get; set; }
public string Detail87CreatedBy { get; set; }
public bool IsDetail87Active { get; set; }
public int Detail87SortOrder { get; set; }


public int Item10Id { get; set; }
public string Item10Name { get; set; }
public string Item10Description { get; set; }
public DateTime Item10CreatedAt { get; set; }
public DateTime? Item10UpdatedAt { get; set; }
public string Item10CreatedBy { get; set; }
public bool IsItem10Active { get; set; }
public int Item10SortOrder { get; set; }


public int Item30Id { get; set; }
public string Item30Name { get; set; }
public string Item30Description { get; set; }
public DateTime Item30CreatedAt { get; set; }
public DateTime? Item30UpdatedAt { get; set; }
public string Item30CreatedBy { get; set; }
public bool IsItem30Active { get; set; }
public int Item30SortOrder { get; set; }


public int Item16Id { get; set; }
public string Item16Name { get; set; }
public string Item16Description { get; set; }
public DateTime Item16CreatedAt { get; set; }
public DateTime? Item16UpdatedAt { get; set; }
public string Item16CreatedBy { get; set; }
public bool IsItem16Active { get; set; }
public int Item16SortOrder { get; set; }


public int Detail6Id { get; set; }
public string Detail6Name { get; set; }
public string Detail6Description { get; set; }
public DateTime Detail6CreatedAt { get; set; }
public DateTime? Detail6UpdatedAt { get; set; }
public string Detail6CreatedBy { get; set; }
public bool IsDetail6Active { get; set; }
public int Detail6SortOrder { get; set; }


public int Record79Id { get; set; }
public string Record79Name { get; set; }
public string Record79Description { get; set; }
public DateTime Record79CreatedAt { get; set; }
public DateTime? Record79UpdatedAt { get; set; }
public string Record79CreatedBy { get; set; }
public bool IsRecord79Active { get; set; }
public int Record79SortOrder { get; set; }


public int Config9Id { get; set; }
public string Config9Name { get; set; }
public string Config9Description { get; set; }
public DateTime Config9CreatedAt { get; set; }
public DateTime? Config9UpdatedAt { get; set; }
public string Config9CreatedBy { get; set; }
public bool IsConfig9Active { get; set; }
public int Config9SortOrder { get; set; }


public int Attr14Id { get; set; }
public string Attr14Name { get; set; }
public string Attr14Description { get; set; }
public DateTime Attr14CreatedAt { get; set; }
public DateTime? Attr14UpdatedAt { get; set; }
public string Attr14CreatedBy { get; set; }
public bool IsAttr14Active { get; set; }
public int Attr14SortOrder { get; set; }


public int Record76Id { get; set; }
public string Record76Name { get; set; }
public string Record76Description { get; set; }
public DateTime Record76CreatedAt { get; set; }
public DateTime? Record76UpdatedAt { get; set; }
public string Record76CreatedBy { get; set; }
public bool IsRecord76Active { get; set; }
public int Record76SortOrder { get; set; }


public int Item46Id { get; set; }
public string Item46Name { get; set; }
public string Item46Description { get; set; }
public DateTime Item46CreatedAt { get; set; }
public DateTime? Item46UpdatedAt { get; set; }
public string Item46CreatedBy { get; set; }
public bool IsItem46Active { get; set; }
public int Item46SortOrder { get; set; }


public int Param71Id { get; set; }
public string Param71Name { get; set; }
public string Param71Description { get; set; }
public DateTime Param71CreatedAt { get; set; }
public DateTime? Param71UpdatedAt { get; set; }
public string Param71CreatedBy { get; set; }
public bool IsParam71Active { get; set; }
public int Param71SortOrder { get; set; }


public int Record25Id { get; set; }
public string Record25Name { get; set; }
public string Record25Description { get; set; }
public DateTime Record25CreatedAt { get; set; }
public DateTime? Record25UpdatedAt { get; set; }
public string Record25CreatedBy { get; set; }
public bool IsRecord25Active { get; set; }
public int Record25SortOrder { get; set; }


public int Config52Id { get; set; }
public string Config52Name { get; set; }
public string Config52Description { get; set; }
public DateTime Config52CreatedAt { get; set; }
public DateTime? Config52UpdatedAt { get; set; }
public string Config52CreatedBy { get; set; }
public bool IsConfig52Active { get; set; }
public int Config52SortOrder { get; set; }


public int Field16Id { get; set; }
public string Field16Name { get; set; }
public string Field16Description { get; set; }
public DateTime Field16CreatedAt { get; set; }
public DateTime? Field16UpdatedAt { get; set; }
public string Field16CreatedBy { get; set; }
public bool IsField16Active { get; set; }
public int Field16SortOrder { get; set; }


public int Config62Id { get; set; }
public string Config62Name { get; set; }
public string Config62Description { get; set; }
public DateTime Config62CreatedAt { get; set; }
public DateTime? Config62UpdatedAt { get; set; }
public string Config62CreatedBy { get; set; }
public bool IsConfig62Active { get; set; }
public int Config62SortOrder { get; set; }


public int Config38Id { get; set; }
public string Config38Name { get; set; }
public string Config38Description { get; set; }
public DateTime Config38CreatedAt { get; set; }
public DateTime? Config38UpdatedAt { get; set; }
public string Config38CreatedBy { get; set; }
public bool IsConfig38Active { get; set; }
public int Config38SortOrder { get; set; }


public int Entry96Id { get; set; }
public string Entry96Name { get; set; }
public string Entry96Description { get; set; }
public DateTime Entry96CreatedAt { get; set; }
public DateTime? Entry96UpdatedAt { get; set; }
public string Entry96CreatedBy { get; set; }
public bool IsEntry96Active { get; set; }
public int Entry96SortOrder { get; set; }


public int Entry7Id { get; set; }
public string Entry7Name { get; set; }
public string Entry7Description { get; set; }
public DateTime Entry7CreatedAt { get; set; }
public DateTime? Entry7UpdatedAt { get; set; }
public string Entry7CreatedBy { get; set; }
public bool IsEntry7Active { get; set; }
public int Entry7SortOrder { get; set; }


public int Config98Id { get; set; }
public string Config98Name { get; set; }
public string Config98Description { get; set; }
public DateTime Config98CreatedAt { get; set; }
public DateTime? Config98UpdatedAt { get; set; }
public string Config98CreatedBy { get; set; }
public bool IsConfig98Active { get; set; }
public int Config98SortOrder { get; set; }


public int Param77Id { get; set; }
public string Param77Name { get; set; }
public string Param77Description { get; set; }
public DateTime Param77CreatedAt { get; set; }
public DateTime? Param77UpdatedAt { get; set; }
public string Param77CreatedBy { get; set; }
public bool IsParam77Active { get; set; }
public int Param77SortOrder { get; set; }


public int Field38Id { get; set; }
public string Field38Name { get; set; }
public string Field38Description { get; set; }
public DateTime Field38CreatedAt { get; set; }
public DateTime? Field38UpdatedAt { get; set; }
public string Field38CreatedBy { get; set; }
public bool IsField38Active { get; set; }
public int Field38SortOrder { get; set; }


public int Field56Id { get; set; }
public string Field56Name { get; set; }
public string Field56Description { get; set; }
public DateTime Field56CreatedAt { get; set; }
public DateTime? Field56UpdatedAt { get; set; }
public string Field56CreatedBy { get; set; }
public bool IsField56Active { get; set; }
public int Field56SortOrder { get; set; }


public int Attr9Id { get; set; }
public string Attr9Name { get; set; }
public string Attr9Description { get; set; }
public DateTime Attr9CreatedAt { get; set; }
public DateTime? Attr9UpdatedAt { get; set; }
public string Attr9CreatedBy { get; set; }
public bool IsAttr9Active { get; set; }
public int Attr9SortOrder { get; set; }


public int Config71Id { get; set; }
public string Config71Name { get; set; }
public string Config71Description { get; set; }
public DateTime Config71CreatedAt { get; set; }
public DateTime? Config71UpdatedAt { get; set; }
public string Config71CreatedBy { get; set; }
public bool IsConfig71Active { get; set; }
public int Config71SortOrder { get; set; }


public int Param40Id { get; set; }
public string Param40Name { get; set; }
public string Param40Description { get; set; }
public DateTime Param40CreatedAt { get; set; }
public DateTime? Param40UpdatedAt { get; set; }
public string Param40CreatedBy { get; set; }
public bool IsParam40Active { get; set; }
public int Param40SortOrder { get; set; }


public int Entry99Id { get; set; }
public string Entry99Name { get; set; }
public string Entry99Description { get; set; }
public DateTime Entry99CreatedAt { get; set; }
public DateTime? Entry99UpdatedAt { get; set; }
public string Entry99CreatedBy { get; set; }
public bool IsEntry99Active { get; set; }
public int Entry99SortOrder { get; set; }


public int Field14Id { get; set; }
public string Field14Name { get; set; }
public string Field14Description { get; set; }
public DateTime Field14CreatedAt { get; set; }
public DateTime? Field14UpdatedAt { get; set; }
public string Field14CreatedBy { get; set; }
public bool IsField14Active { get; set; }
public int Field14SortOrder { get; set; }


public int Detail58Id { get; set; }
public string Detail58Name { get; set; }
public string Detail58Description { get; set; }
public DateTime Detail58CreatedAt { get; set; }
public DateTime? Detail58UpdatedAt { get; set; }
public string Detail58CreatedBy { get; set; }
public bool IsDetail58Active { get; set; }
public int Detail58SortOrder { get; set; }


public int Detail69Id { get; set; }
public string Detail69Name { get; set; }
public string Detail69Description { get; set; }
public DateTime Detail69CreatedAt { get; set; }
public DateTime? Detail69UpdatedAt { get; set; }
public string Detail69CreatedBy { get; set; }
public bool IsDetail69Active { get; set; }
public int Detail69SortOrder { get; set; }

    }

}