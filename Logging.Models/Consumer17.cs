using Admin.Web46;
using Auth.Contracts;
using Auth.Mappers208;
using BatchJobs.Events435;
using Common.Mappers343;
using DataAccess.Contracts203;
using Documents.Events;
using Export.Client;
using Export.Handlers;
using GalaxyWorks.Contracts485;
using GalaxyWorks.Events77;
using Import.Service291;
using Logging.Api316;
using Reporting.Models;
using Scheduling.Contracts;
using Security.Processors246;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logging.Models
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer17
    {
        private readonly Auth_Contracts_Dto7 _auth_Contracts_Dto7;
        private readonly Auth_Contracts_Repository6 _auth_Contracts_Repository6;
        private readonly Security_Processors246_Result4 _security_Processors246_Result4;
        private readonly DataAccess_Contracts203_Builder4 _dataAccess_Contracts203_Builder4;
        private readonly Documents_Events_Service2 _documents_Events_Service2;
        private readonly Documents_Events_Repository6 _documents_Events_Repository6;
        private readonly Reporting_Models_Processor3 _reporting_Models_Processor3;
        private readonly IReporting_Models_Repository2 _iReporting_Models_Repository2;

        public Consumer17(Auth_Contracts_Dto7 auth_Contracts_Dto7, Auth_Contracts_Repository6 auth_Contracts_Repository6, Security_Processors246_Result4 security_Processors246_Result4, DataAccess_Contracts203_Builder4 dataAccess_Contracts203_Builder4, Documents_Events_Service2 documents_Events_Service2, Documents_Events_Repository6 documents_Events_Repository6, Reporting_Models_Processor3 reporting_Models_Processor3, IReporting_Models_Repository2 iReporting_Models_Repository2)
        {
            _auth_Contracts_Dto7 = auth_Contracts_Dto7 ?? throw new ArgumentNullException(nameof(auth_Contracts_Dto7));
            _auth_Contracts_Repository6 = auth_Contracts_Repository6 ?? throw new ArgumentNullException(nameof(auth_Contracts_Repository6));
            _security_Processors246_Result4 = security_Processors246_Result4 ?? throw new ArgumentNullException(nameof(security_Processors246_Result4));
            _dataAccess_Contracts203_Builder4 = dataAccess_Contracts203_Builder4 ?? throw new ArgumentNullException(nameof(dataAccess_Contracts203_Builder4));
            _documents_Events_Service2 = documents_Events_Service2 ?? throw new ArgumentNullException(nameof(documents_Events_Service2));
            _documents_Events_Repository6 = documents_Events_Repository6 ?? throw new ArgumentNullException(nameof(documents_Events_Repository6));
            _reporting_Models_Processor3 = reporting_Models_Processor3 ?? throw new ArgumentNullException(nameof(reporting_Models_Processor3));
            _iReporting_Models_Repository2 = iReporting_Models_Repository2 ?? throw new ArgumentNullException(nameof(iReporting_Models_Repository2));
        }

        public Auth_Contracts_Dto7 GetAuth_Contracts_Dto7() => _auth_Contracts_Dto7;
        public Auth_Contracts_Repository6 GetAuth_Contracts_Repository6() => _auth_Contracts_Repository6;
        public Security_Processors246_Result4 GetSecurity_Processors246_Result4() => _security_Processors246_Result4;
        public DataAccess_Contracts203_Builder4 GetDataAccess_Contracts203_Builder4() => _dataAccess_Contracts203_Builder4;
        public Documents_Events_Service2 GetDocuments_Events_Service2() => _documents_Events_Service2;
        public Documents_Events_Repository6 GetDocuments_Events_Repository6() => _documents_Events_Repository6;
        public Reporting_Models_Processor3 GetReporting_Models_Processor3() => _reporting_Models_Processor3;
        public IReporting_Models_Repository2 GetIReporting_Models_Repository2() => _iReporting_Models_Repository2;

/// <summary>
/// Validates the Consumer17 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer17(Consumer17Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer17));
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
/// Processes the Consumer17 operation asynchronously.
/// </summary>
public async Task<Consumer17Result> ProcessConsumer17Async(
    Consumer17Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer17), request.Id);

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
            return new Consumer17Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer17));
        return new Consumer17Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer17));
        return new Consumer17Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer17 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer17Dto>> GetConsumer17ListAsync(
    Consumer17Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer17Entity>().AsQueryable();

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
        .Select(x => new Consumer17Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer17Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer17Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer17Service(
    ILogger<Consumer17Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer17:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer17 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer17Data> GetCachedConsumer17Async(string key)
{
    var cacheKey = $"Consumer17_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer17Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer17SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Item60Id { get; set; }
public string Item60Name { get; set; }
public string Item60Description { get; set; }
public DateTime Item60CreatedAt { get; set; }
public DateTime? Item60UpdatedAt { get; set; }
public string Item60CreatedBy { get; set; }
public bool IsItem60Active { get; set; }
public int Item60SortOrder { get; set; }


public int Param29Id { get; set; }
public string Param29Name { get; set; }
public string Param29Description { get; set; }
public DateTime Param29CreatedAt { get; set; }
public DateTime? Param29UpdatedAt { get; set; }
public string Param29CreatedBy { get; set; }
public bool IsParam29Active { get; set; }
public int Param29SortOrder { get; set; }


public int Item7Id { get; set; }
public string Item7Name { get; set; }
public string Item7Description { get; set; }
public DateTime Item7CreatedAt { get; set; }
public DateTime? Item7UpdatedAt { get; set; }
public string Item7CreatedBy { get; set; }
public bool IsItem7Active { get; set; }
public int Item7SortOrder { get; set; }


public int Field15Id { get; set; }
public string Field15Name { get; set; }
public string Field15Description { get; set; }
public DateTime Field15CreatedAt { get; set; }
public DateTime? Field15UpdatedAt { get; set; }
public string Field15CreatedBy { get; set; }
public bool IsField15Active { get; set; }
public int Field15SortOrder { get; set; }


public int Detail22Id { get; set; }
public string Detail22Name { get; set; }
public string Detail22Description { get; set; }
public DateTime Detail22CreatedAt { get; set; }
public DateTime? Detail22UpdatedAt { get; set; }
public string Detail22CreatedBy { get; set; }
public bool IsDetail22Active { get; set; }
public int Detail22SortOrder { get; set; }


public int Entry13Id { get; set; }
public string Entry13Name { get; set; }
public string Entry13Description { get; set; }
public DateTime Entry13CreatedAt { get; set; }
public DateTime? Entry13UpdatedAt { get; set; }
public string Entry13CreatedBy { get; set; }
public bool IsEntry13Active { get; set; }
public int Entry13SortOrder { get; set; }


public int Param74Id { get; set; }
public string Param74Name { get; set; }
public string Param74Description { get; set; }
public DateTime Param74CreatedAt { get; set; }
public DateTime? Param74UpdatedAt { get; set; }
public string Param74CreatedBy { get; set; }
public bool IsParam74Active { get; set; }
public int Param74SortOrder { get; set; }


public int Config46Id { get; set; }
public string Config46Name { get; set; }
public string Config46Description { get; set; }
public DateTime Config46CreatedAt { get; set; }
public DateTime? Config46UpdatedAt { get; set; }
public string Config46CreatedBy { get; set; }
public bool IsConfig46Active { get; set; }
public int Config46SortOrder { get; set; }


public int Config65Id { get; set; }
public string Config65Name { get; set; }
public string Config65Description { get; set; }
public DateTime Config65CreatedAt { get; set; }
public DateTime? Config65UpdatedAt { get; set; }
public string Config65CreatedBy { get; set; }
public bool IsConfig65Active { get; set; }
public int Config65SortOrder { get; set; }


public int Entry58Id { get; set; }
public string Entry58Name { get; set; }
public string Entry58Description { get; set; }
public DateTime Entry58CreatedAt { get; set; }
public DateTime? Entry58UpdatedAt { get; set; }
public string Entry58CreatedBy { get; set; }
public bool IsEntry58Active { get; set; }
public int Entry58SortOrder { get; set; }


public int Param5Id { get; set; }
public string Param5Name { get; set; }
public string Param5Description { get; set; }
public DateTime Param5CreatedAt { get; set; }
public DateTime? Param5UpdatedAt { get; set; }
public string Param5CreatedBy { get; set; }
public bool IsParam5Active { get; set; }
public int Param5SortOrder { get; set; }


public int Field56Id { get; set; }
public string Field56Name { get; set; }
public string Field56Description { get; set; }
public DateTime Field56CreatedAt { get; set; }
public DateTime? Field56UpdatedAt { get; set; }
public string Field56CreatedBy { get; set; }
public bool IsField56Active { get; set; }
public int Field56SortOrder { get; set; }


public int Entry87Id { get; set; }
public string Entry87Name { get; set; }
public string Entry87Description { get; set; }
public DateTime Entry87CreatedAt { get; set; }
public DateTime? Entry87UpdatedAt { get; set; }
public string Entry87CreatedBy { get; set; }
public bool IsEntry87Active { get; set; }
public int Entry87SortOrder { get; set; }


public int Config58Id { get; set; }
public string Config58Name { get; set; }
public string Config58Description { get; set; }
public DateTime Config58CreatedAt { get; set; }
public DateTime? Config58UpdatedAt { get; set; }
public string Config58CreatedBy { get; set; }
public bool IsConfig58Active { get; set; }
public int Config58SortOrder { get; set; }


public int Entry95Id { get; set; }
public string Entry95Name { get; set; }
public string Entry95Description { get; set; }
public DateTime Entry95CreatedAt { get; set; }
public DateTime? Entry95UpdatedAt { get; set; }
public string Entry95CreatedBy { get; set; }
public bool IsEntry95Active { get; set; }
public int Entry95SortOrder { get; set; }


public int Detail42Id { get; set; }
public string Detail42Name { get; set; }
public string Detail42Description { get; set; }
public DateTime Detail42CreatedAt { get; set; }
public DateTime? Detail42UpdatedAt { get; set; }
public string Detail42CreatedBy { get; set; }
public bool IsDetail42Active { get; set; }
public int Detail42SortOrder { get; set; }


public int Entry44Id { get; set; }
public string Entry44Name { get; set; }
public string Entry44Description { get; set; }
public DateTime Entry44CreatedAt { get; set; }
public DateTime? Entry44UpdatedAt { get; set; }
public string Entry44CreatedBy { get; set; }
public bool IsEntry44Active { get; set; }
public int Entry44SortOrder { get; set; }


public int Config12Id { get; set; }
public string Config12Name { get; set; }
public string Config12Description { get; set; }
public DateTime Config12CreatedAt { get; set; }
public DateTime? Config12UpdatedAt { get; set; }
public string Config12CreatedBy { get; set; }
public bool IsConfig12Active { get; set; }
public int Config12SortOrder { get; set; }


public int Config70Id { get; set; }
public string Config70Name { get; set; }
public string Config70Description { get; set; }
public DateTime Config70CreatedAt { get; set; }
public DateTime? Config70UpdatedAt { get; set; }
public string Config70CreatedBy { get; set; }
public bool IsConfig70Active { get; set; }
public int Config70SortOrder { get; set; }


public int Detail53Id { get; set; }
public string Detail53Name { get; set; }
public string Detail53Description { get; set; }
public DateTime Detail53CreatedAt { get; set; }
public DateTime? Detail53UpdatedAt { get; set; }
public string Detail53CreatedBy { get; set; }
public bool IsDetail53Active { get; set; }
public int Detail53SortOrder { get; set; }


public int Entry73Id { get; set; }
public string Entry73Name { get; set; }
public string Entry73Description { get; set; }
public DateTime Entry73CreatedAt { get; set; }
public DateTime? Entry73UpdatedAt { get; set; }
public string Entry73CreatedBy { get; set; }
public bool IsEntry73Active { get; set; }
public int Entry73SortOrder { get; set; }


public int Field47Id { get; set; }
public string Field47Name { get; set; }
public string Field47Description { get; set; }
public DateTime Field47CreatedAt { get; set; }
public DateTime? Field47UpdatedAt { get; set; }
public string Field47CreatedBy { get; set; }
public bool IsField47Active { get; set; }
public int Field47SortOrder { get; set; }


public int Record14Id { get; set; }
public string Record14Name { get; set; }
public string Record14Description { get; set; }
public DateTime Record14CreatedAt { get; set; }
public DateTime? Record14UpdatedAt { get; set; }
public string Record14CreatedBy { get; set; }
public bool IsRecord14Active { get; set; }
public int Record14SortOrder { get; set; }


public int Field57Id { get; set; }
public string Field57Name { get; set; }
public string Field57Description { get; set; }
public DateTime Field57CreatedAt { get; set; }
public DateTime? Field57UpdatedAt { get; set; }
public string Field57CreatedBy { get; set; }
public bool IsField57Active { get; set; }
public int Field57SortOrder { get; set; }


public int Param57Id { get; set; }
public string Param57Name { get; set; }
public string Param57Description { get; set; }
public DateTime Param57CreatedAt { get; set; }
public DateTime? Param57UpdatedAt { get; set; }
public string Param57CreatedBy { get; set; }
public bool IsParam57Active { get; set; }
public int Param57SortOrder { get; set; }


public int Field15Id { get; set; }
public string Field15Name { get; set; }
public string Field15Description { get; set; }
public DateTime Field15CreatedAt { get; set; }
public DateTime? Field15UpdatedAt { get; set; }
public string Field15CreatedBy { get; set; }
public bool IsField15Active { get; set; }
public int Field15SortOrder { get; set; }


public int Entry39Id { get; set; }
public string Entry39Name { get; set; }
public string Entry39Description { get; set; }
public DateTime Entry39CreatedAt { get; set; }
public DateTime? Entry39UpdatedAt { get; set; }
public string Entry39CreatedBy { get; set; }
public bool IsEntry39Active { get; set; }
public int Entry39SortOrder { get; set; }


public int Field36Id { get; set; }
public string Field36Name { get; set; }
public string Field36Description { get; set; }
public DateTime Field36CreatedAt { get; set; }
public DateTime? Field36UpdatedAt { get; set; }
public string Field36CreatedBy { get; set; }
public bool IsField36Active { get; set; }
public int Field36SortOrder { get; set; }


public int Detail97Id { get; set; }
public string Detail97Name { get; set; }
public string Detail97Description { get; set; }
public DateTime Detail97CreatedAt { get; set; }
public DateTime? Detail97UpdatedAt { get; set; }
public string Detail97CreatedBy { get; set; }
public bool IsDetail97Active { get; set; }
public int Detail97SortOrder { get; set; }


public int Field20Id { get; set; }
public string Field20Name { get; set; }
public string Field20Description { get; set; }
public DateTime Field20CreatedAt { get; set; }
public DateTime? Field20UpdatedAt { get; set; }
public string Field20CreatedBy { get; set; }
public bool IsField20Active { get; set; }
public int Field20SortOrder { get; set; }


public int Field26Id { get; set; }
public string Field26Name { get; set; }
public string Field26Description { get; set; }
public DateTime Field26CreatedAt { get; set; }
public DateTime? Field26UpdatedAt { get; set; }
public string Field26CreatedBy { get; set; }
public bool IsField26Active { get; set; }
public int Field26SortOrder { get; set; }


public int Field5Id { get; set; }
public string Field5Name { get; set; }
public string Field5Description { get; set; }
public DateTime Field5CreatedAt { get; set; }
public DateTime? Field5UpdatedAt { get; set; }
public string Field5CreatedBy { get; set; }
public bool IsField5Active { get; set; }
public int Field5SortOrder { get; set; }


public int Record84Id { get; set; }
public string Record84Name { get; set; }
public string Record84Description { get; set; }
public DateTime Record84CreatedAt { get; set; }
public DateTime? Record84UpdatedAt { get; set; }
public string Record84CreatedBy { get; set; }
public bool IsRecord84Active { get; set; }
public int Record84SortOrder { get; set; }


public int Config44Id { get; set; }
public string Config44Name { get; set; }
public string Config44Description { get; set; }
public DateTime Config44CreatedAt { get; set; }
public DateTime? Config44UpdatedAt { get; set; }
public string Config44CreatedBy { get; set; }
public bool IsConfig44Active { get; set; }
public int Config44SortOrder { get; set; }


public int Record36Id { get; set; }
public string Record36Name { get; set; }
public string Record36Description { get; set; }
public DateTime Record36CreatedAt { get; set; }
public DateTime? Record36UpdatedAt { get; set; }
public string Record36CreatedBy { get; set; }
public bool IsRecord36Active { get; set; }
public int Record36SortOrder { get; set; }


public int Config62Id { get; set; }
public string Config62Name { get; set; }
public string Config62Description { get; set; }
public DateTime Config62CreatedAt { get; set; }
public DateTime? Config62UpdatedAt { get; set; }
public string Config62CreatedBy { get; set; }
public bool IsConfig62Active { get; set; }
public int Config62SortOrder { get; set; }


public int Param79Id { get; set; }
public string Param79Name { get; set; }
public string Param79Description { get; set; }
public DateTime Param79CreatedAt { get; set; }
public DateTime? Param79UpdatedAt { get; set; }
public string Param79CreatedBy { get; set; }
public bool IsParam79Active { get; set; }
public int Param79SortOrder { get; set; }


public int Detail24Id { get; set; }
public string Detail24Name { get; set; }
public string Detail24Description { get; set; }
public DateTime Detail24CreatedAt { get; set; }
public DateTime? Detail24UpdatedAt { get; set; }
public string Detail24CreatedBy { get; set; }
public bool IsDetail24Active { get; set; }
public int Detail24SortOrder { get; set; }


public int Record63Id { get; set; }
public string Record63Name { get; set; }
public string Record63Description { get; set; }
public DateTime Record63CreatedAt { get; set; }
public DateTime? Record63UpdatedAt { get; set; }
public string Record63CreatedBy { get; set; }
public bool IsRecord63Active { get; set; }
public int Record63SortOrder { get; set; }


public int Detail29Id { get; set; }
public string Detail29Name { get; set; }
public string Detail29Description { get; set; }
public DateTime Detail29CreatedAt { get; set; }
public DateTime? Detail29UpdatedAt { get; set; }
public string Detail29CreatedBy { get; set; }
public bool IsDetail29Active { get; set; }
public int Detail29SortOrder { get; set; }


public int Entry24Id { get; set; }
public string Entry24Name { get; set; }
public string Entry24Description { get; set; }
public DateTime Entry24CreatedAt { get; set; }
public DateTime? Entry24UpdatedAt { get; set; }
public string Entry24CreatedBy { get; set; }
public bool IsEntry24Active { get; set; }
public int Entry24SortOrder { get; set; }


public int Item56Id { get; set; }
public string Item56Name { get; set; }
public string Item56Description { get; set; }
public DateTime Item56CreatedAt { get; set; }
public DateTime? Item56UpdatedAt { get; set; }
public string Item56CreatedBy { get; set; }
public bool IsItem56Active { get; set; }
public int Item56SortOrder { get; set; }


public int Param32Id { get; set; }
public string Param32Name { get; set; }
public string Param32Description { get; set; }
public DateTime Param32CreatedAt { get; set; }
public DateTime? Param32UpdatedAt { get; set; }
public string Param32CreatedBy { get; set; }
public bool IsParam32Active { get; set; }
public int Param32SortOrder { get; set; }


public int Detail29Id { get; set; }
public string Detail29Name { get; set; }
public string Detail29Description { get; set; }
public DateTime Detail29CreatedAt { get; set; }
public DateTime? Detail29UpdatedAt { get; set; }
public string Detail29CreatedBy { get; set; }
public bool IsDetail29Active { get; set; }
public int Detail29SortOrder { get; set; }


public int Attr96Id { get; set; }
public string Attr96Name { get; set; }
public string Attr96Description { get; set; }
public DateTime Attr96CreatedAt { get; set; }
public DateTime? Attr96UpdatedAt { get; set; }
public string Attr96CreatedBy { get; set; }
public bool IsAttr96Active { get; set; }
public int Attr96SortOrder { get; set; }

    }
}