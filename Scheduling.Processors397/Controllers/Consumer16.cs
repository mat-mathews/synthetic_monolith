using Admin.Shared;
using Admin.Validators;
using Auth.Client249;
using Billing.Core;
using Billing.Handlers122;
using Billing.Mappers;
using Billing.Processors;
using DataAccess.Client113;
using DataAccess.Validators88;
using Documents.Data492;
using Export.Client;
using Export.Web229;
using Import.Processors472;
using Notifications.Handlers112;
using Reporting.Api287;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Validators;

namespace Scheduling.Processors397
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer16
    {
        private readonly Auth_Client249_Dto2 _auth_Client249_Dto2;
        private readonly Import_Processors472_Manager10 _import_Processors472_Manager10;
        private readonly Import_Processors472_ViewModel7 _import_Processors472_ViewModel7;
        private readonly DataAccess_Client113_Factory4 _dataAccess_Client113_Factory4;
        private readonly Utilities_Validators_Repository6 _utilities_Validators_Repository6;
        private readonly Utilities_Validators_Handler2 _utilities_Validators_Handler2;
        private readonly Notifications_Handlers112_Helper3 _notifications_Handlers112_Helper3;
        private readonly Notifications_Handlers112_Builder _notifications_Handlers112_Builder;

        public Consumer16(Auth_Client249_Dto2 auth_Client249_Dto2, Import_Processors472_Manager10 import_Processors472_Manager10, Import_Processors472_ViewModel7 import_Processors472_ViewModel7, DataAccess_Client113_Factory4 dataAccess_Client113_Factory4, Utilities_Validators_Repository6 utilities_Validators_Repository6, Utilities_Validators_Handler2 utilities_Validators_Handler2, Notifications_Handlers112_Helper3 notifications_Handlers112_Helper3, Notifications_Handlers112_Builder notifications_Handlers112_Builder)
        {
            _auth_Client249_Dto2 = auth_Client249_Dto2 ?? throw new ArgumentNullException(nameof(auth_Client249_Dto2));
            _import_Processors472_Manager10 = import_Processors472_Manager10 ?? throw new ArgumentNullException(nameof(import_Processors472_Manager10));
            _import_Processors472_ViewModel7 = import_Processors472_ViewModel7 ?? throw new ArgumentNullException(nameof(import_Processors472_ViewModel7));
            _dataAccess_Client113_Factory4 = dataAccess_Client113_Factory4 ?? throw new ArgumentNullException(nameof(dataAccess_Client113_Factory4));
            _utilities_Validators_Repository6 = utilities_Validators_Repository6 ?? throw new ArgumentNullException(nameof(utilities_Validators_Repository6));
            _utilities_Validators_Handler2 = utilities_Validators_Handler2 ?? throw new ArgumentNullException(nameof(utilities_Validators_Handler2));
            _notifications_Handlers112_Helper3 = notifications_Handlers112_Helper3 ?? throw new ArgumentNullException(nameof(notifications_Handlers112_Helper3));
            _notifications_Handlers112_Builder = notifications_Handlers112_Builder ?? throw new ArgumentNullException(nameof(notifications_Handlers112_Builder));
        }

        public Auth_Client249_Dto2 GetAuth_Client249_Dto2() => _auth_Client249_Dto2;
        public Import_Processors472_Manager10 GetImport_Processors472_Manager10() => _import_Processors472_Manager10;
        public Import_Processors472_ViewModel7 GetImport_Processors472_ViewModel7() => _import_Processors472_ViewModel7;
        public DataAccess_Client113_Factory4 GetDataAccess_Client113_Factory4() => _dataAccess_Client113_Factory4;
        public Utilities_Validators_Repository6 GetUtilities_Validators_Repository6() => _utilities_Validators_Repository6;
        public Utilities_Validators_Handler2 GetUtilities_Validators_Handler2() => _utilities_Validators_Handler2;
        public Notifications_Handlers112_Helper3 GetNotifications_Handlers112_Helper3() => _notifications_Handlers112_Helper3;
        public Notifications_Handlers112_Builder GetNotifications_Handlers112_Builder() => _notifications_Handlers112_Builder;

/// <summary>
/// Validates the Consumer16 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer16(Consumer16Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer16));
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
/// Processes the Consumer16 operation asynchronously.
/// </summary>
public async Task<Consumer16Result> ProcessConsumer16Async(
    Consumer16Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer16), request.Id);

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
            return new Consumer16Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer16));
        return new Consumer16Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer16));
        return new Consumer16Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer16 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer16Dto>> GetConsumer16ListAsync(
    Consumer16Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer16Entity>().AsQueryable();

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
        .Select(x => new Consumer16Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer16Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer16Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer16Service(
    ILogger<Consumer16Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer16:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer16 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer16Data> GetCachedConsumer16Async(string key)
{
    var cacheKey = $"Consumer16_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer16Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer16SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Record36Id { get; set; }
public string Record36Name { get; set; }
public string Record36Description { get; set; }
public DateTime Record36CreatedAt { get; set; }
public DateTime? Record36UpdatedAt { get; set; }
public string Record36CreatedBy { get; set; }
public bool IsRecord36Active { get; set; }
public int Record36SortOrder { get; set; }


public int Param34Id { get; set; }
public string Param34Name { get; set; }
public string Param34Description { get; set; }
public DateTime Param34CreatedAt { get; set; }
public DateTime? Param34UpdatedAt { get; set; }
public string Param34CreatedBy { get; set; }
public bool IsParam34Active { get; set; }
public int Param34SortOrder { get; set; }


public int Record94Id { get; set; }
public string Record94Name { get; set; }
public string Record94Description { get; set; }
public DateTime Record94CreatedAt { get; set; }
public DateTime? Record94UpdatedAt { get; set; }
public string Record94CreatedBy { get; set; }
public bool IsRecord94Active { get; set; }
public int Record94SortOrder { get; set; }


public int Detail97Id { get; set; }
public string Detail97Name { get; set; }
public string Detail97Description { get; set; }
public DateTime Detail97CreatedAt { get; set; }
public DateTime? Detail97UpdatedAt { get; set; }
public string Detail97CreatedBy { get; set; }
public bool IsDetail97Active { get; set; }
public int Detail97SortOrder { get; set; }


public int Detail64Id { get; set; }
public string Detail64Name { get; set; }
public string Detail64Description { get; set; }
public DateTime Detail64CreatedAt { get; set; }
public DateTime? Detail64UpdatedAt { get; set; }
public string Detail64CreatedBy { get; set; }
public bool IsDetail64Active { get; set; }
public int Detail64SortOrder { get; set; }


public int Param22Id { get; set; }
public string Param22Name { get; set; }
public string Param22Description { get; set; }
public DateTime Param22CreatedAt { get; set; }
public DateTime? Param22UpdatedAt { get; set; }
public string Param22CreatedBy { get; set; }
public bool IsParam22Active { get; set; }
public int Param22SortOrder { get; set; }


public int Record87Id { get; set; }
public string Record87Name { get; set; }
public string Record87Description { get; set; }
public DateTime Record87CreatedAt { get; set; }
public DateTime? Record87UpdatedAt { get; set; }
public string Record87CreatedBy { get; set; }
public bool IsRecord87Active { get; set; }
public int Record87SortOrder { get; set; }


public int Item27Id { get; set; }
public string Item27Name { get; set; }
public string Item27Description { get; set; }
public DateTime Item27CreatedAt { get; set; }
public DateTime? Item27UpdatedAt { get; set; }
public string Item27CreatedBy { get; set; }
public bool IsItem27Active { get; set; }
public int Item27SortOrder { get; set; }


public int Entry92Id { get; set; }
public string Entry92Name { get; set; }
public string Entry92Description { get; set; }
public DateTime Entry92CreatedAt { get; set; }
public DateTime? Entry92UpdatedAt { get; set; }
public string Entry92CreatedBy { get; set; }
public bool IsEntry92Active { get; set; }
public int Entry92SortOrder { get; set; }


public int Entry93Id { get; set; }
public string Entry93Name { get; set; }
public string Entry93Description { get; set; }
public DateTime Entry93CreatedAt { get; set; }
public DateTime? Entry93UpdatedAt { get; set; }
public string Entry93CreatedBy { get; set; }
public bool IsEntry93Active { get; set; }
public int Entry93SortOrder { get; set; }


public int Detail41Id { get; set; }
public string Detail41Name { get; set; }
public string Detail41Description { get; set; }
public DateTime Detail41CreatedAt { get; set; }
public DateTime? Detail41UpdatedAt { get; set; }
public string Detail41CreatedBy { get; set; }
public bool IsDetail41Active { get; set; }
public int Detail41SortOrder { get; set; }


public int Attr83Id { get; set; }
public string Attr83Name { get; set; }
public string Attr83Description { get; set; }
public DateTime Attr83CreatedAt { get; set; }
public DateTime? Attr83UpdatedAt { get; set; }
public string Attr83CreatedBy { get; set; }
public bool IsAttr83Active { get; set; }
public int Attr83SortOrder { get; set; }


public int Record75Id { get; set; }
public string Record75Name { get; set; }
public string Record75Description { get; set; }
public DateTime Record75CreatedAt { get; set; }
public DateTime? Record75UpdatedAt { get; set; }
public string Record75CreatedBy { get; set; }
public bool IsRecord75Active { get; set; }
public int Record75SortOrder { get; set; }


public int Attr63Id { get; set; }
public string Attr63Name { get; set; }
public string Attr63Description { get; set; }
public DateTime Attr63CreatedAt { get; set; }
public DateTime? Attr63UpdatedAt { get; set; }
public string Attr63CreatedBy { get; set; }
public bool IsAttr63Active { get; set; }
public int Attr63SortOrder { get; set; }


public int Detail73Id { get; set; }
public string Detail73Name { get; set; }
public string Detail73Description { get; set; }
public DateTime Detail73CreatedAt { get; set; }
public DateTime? Detail73UpdatedAt { get; set; }
public string Detail73CreatedBy { get; set; }
public bool IsDetail73Active { get; set; }
public int Detail73SortOrder { get; set; }


public int Item54Id { get; set; }
public string Item54Name { get; set; }
public string Item54Description { get; set; }
public DateTime Item54CreatedAt { get; set; }
public DateTime? Item54UpdatedAt { get; set; }
public string Item54CreatedBy { get; set; }
public bool IsItem54Active { get; set; }
public int Item54SortOrder { get; set; }


public int Item85Id { get; set; }
public string Item85Name { get; set; }
public string Item85Description { get; set; }
public DateTime Item85CreatedAt { get; set; }
public DateTime? Item85UpdatedAt { get; set; }
public string Item85CreatedBy { get; set; }
public bool IsItem85Active { get; set; }
public int Item85SortOrder { get; set; }


public int Field63Id { get; set; }
public string Field63Name { get; set; }
public string Field63Description { get; set; }
public DateTime Field63CreatedAt { get; set; }
public DateTime? Field63UpdatedAt { get; set; }
public string Field63CreatedBy { get; set; }
public bool IsField63Active { get; set; }
public int Field63SortOrder { get; set; }


public int Entry18Id { get; set; }
public string Entry18Name { get; set; }
public string Entry18Description { get; set; }
public DateTime Entry18CreatedAt { get; set; }
public DateTime? Entry18UpdatedAt { get; set; }
public string Entry18CreatedBy { get; set; }
public bool IsEntry18Active { get; set; }
public int Entry18SortOrder { get; set; }


public int Attr20Id { get; set; }
public string Attr20Name { get; set; }
public string Attr20Description { get; set; }
public DateTime Attr20CreatedAt { get; set; }
public DateTime? Attr20UpdatedAt { get; set; }
public string Attr20CreatedBy { get; set; }
public bool IsAttr20Active { get; set; }
public int Attr20SortOrder { get; set; }


public int Attr62Id { get; set; }
public string Attr62Name { get; set; }
public string Attr62Description { get; set; }
public DateTime Attr62CreatedAt { get; set; }
public DateTime? Attr62UpdatedAt { get; set; }
public string Attr62CreatedBy { get; set; }
public bool IsAttr62Active { get; set; }
public int Attr62SortOrder { get; set; }


public int Field6Id { get; set; }
public string Field6Name { get; set; }
public string Field6Description { get; set; }
public DateTime Field6CreatedAt { get; set; }
public DateTime? Field6UpdatedAt { get; set; }
public string Field6CreatedBy { get; set; }
public bool IsField6Active { get; set; }
public int Field6SortOrder { get; set; }


public int Item91Id { get; set; }
public string Item91Name { get; set; }
public string Item91Description { get; set; }
public DateTime Item91CreatedAt { get; set; }
public DateTime? Item91UpdatedAt { get; set; }
public string Item91CreatedBy { get; set; }
public bool IsItem91Active { get; set; }
public int Item91SortOrder { get; set; }


public int Attr76Id { get; set; }
public string Attr76Name { get; set; }
public string Attr76Description { get; set; }
public DateTime Attr76CreatedAt { get; set; }
public DateTime? Attr76UpdatedAt { get; set; }
public string Attr76CreatedBy { get; set; }
public bool IsAttr76Active { get; set; }
public int Attr76SortOrder { get; set; }


public int Record62Id { get; set; }
public string Record62Name { get; set; }
public string Record62Description { get; set; }
public DateTime Record62CreatedAt { get; set; }
public DateTime? Record62UpdatedAt { get; set; }
public string Record62CreatedBy { get; set; }
public bool IsRecord62Active { get; set; }
public int Record62SortOrder { get; set; }


public int Param77Id { get; set; }
public string Param77Name { get; set; }
public string Param77Description { get; set; }
public DateTime Param77CreatedAt { get; set; }
public DateTime? Param77UpdatedAt { get; set; }
public string Param77CreatedBy { get; set; }
public bool IsParam77Active { get; set; }
public int Param77SortOrder { get; set; }


public int Detail92Id { get; set; }
public string Detail92Name { get; set; }
public string Detail92Description { get; set; }
public DateTime Detail92CreatedAt { get; set; }
public DateTime? Detail92UpdatedAt { get; set; }
public string Detail92CreatedBy { get; set; }
public bool IsDetail92Active { get; set; }
public int Detail92SortOrder { get; set; }


public int Detail29Id { get; set; }
public string Detail29Name { get; set; }
public string Detail29Description { get; set; }
public DateTime Detail29CreatedAt { get; set; }
public DateTime? Detail29UpdatedAt { get; set; }
public string Detail29CreatedBy { get; set; }
public bool IsDetail29Active { get; set; }
public int Detail29SortOrder { get; set; }


public int Attr13Id { get; set; }
public string Attr13Name { get; set; }
public string Attr13Description { get; set; }
public DateTime Attr13CreatedAt { get; set; }
public DateTime? Attr13UpdatedAt { get; set; }
public string Attr13CreatedBy { get; set; }
public bool IsAttr13Active { get; set; }
public int Attr13SortOrder { get; set; }


public int Config95Id { get; set; }
public string Config95Name { get; set; }
public string Config95Description { get; set; }
public DateTime Config95CreatedAt { get; set; }
public DateTime? Config95UpdatedAt { get; set; }
public string Config95CreatedBy { get; set; }
public bool IsConfig95Active { get; set; }
public int Config95SortOrder { get; set; }


public int Config6Id { get; set; }
public string Config6Name { get; set; }
public string Config6Description { get; set; }
public DateTime Config6CreatedAt { get; set; }
public DateTime? Config6UpdatedAt { get; set; }
public string Config6CreatedBy { get; set; }
public bool IsConfig6Active { get; set; }
public int Config6SortOrder { get; set; }


public int Config5Id { get; set; }
public string Config5Name { get; set; }
public string Config5Description { get; set; }
public DateTime Config5CreatedAt { get; set; }
public DateTime? Config5UpdatedAt { get; set; }
public string Config5CreatedBy { get; set; }
public bool IsConfig5Active { get; set; }
public int Config5SortOrder { get; set; }


public int Param38Id { get; set; }
public string Param38Name { get; set; }
public string Param38Description { get; set; }
public DateTime Param38CreatedAt { get; set; }
public DateTime? Param38UpdatedAt { get; set; }
public string Param38CreatedBy { get; set; }
public bool IsParam38Active { get; set; }
public int Param38SortOrder { get; set; }


public int Detail96Id { get; set; }
public string Detail96Name { get; set; }
public string Detail96Description { get; set; }
public DateTime Detail96CreatedAt { get; set; }
public DateTime? Detail96UpdatedAt { get; set; }
public string Detail96CreatedBy { get; set; }
public bool IsDetail96Active { get; set; }
public int Detail96SortOrder { get; set; }


public int Record49Id { get; set; }
public string Record49Name { get; set; }
public string Record49Description { get; set; }
public DateTime Record49CreatedAt { get; set; }
public DateTime? Record49UpdatedAt { get; set; }
public string Record49CreatedBy { get; set; }
public bool IsRecord49Active { get; set; }
public int Record49SortOrder { get; set; }


public int Record22Id { get; set; }
public string Record22Name { get; set; }
public string Record22Description { get; set; }
public DateTime Record22CreatedAt { get; set; }
public DateTime? Record22UpdatedAt { get; set; }
public string Record22CreatedBy { get; set; }
public bool IsRecord22Active { get; set; }
public int Record22SortOrder { get; set; }


public int Config33Id { get; set; }
public string Config33Name { get; set; }
public string Config33Description { get; set; }
public DateTime Config33CreatedAt { get; set; }
public DateTime? Config33UpdatedAt { get; set; }
public string Config33CreatedBy { get; set; }
public bool IsConfig33Active { get; set; }
public int Config33SortOrder { get; set; }


public int Param91Id { get; set; }
public string Param91Name { get; set; }
public string Param91Description { get; set; }
public DateTime Param91CreatedAt { get; set; }
public DateTime? Param91UpdatedAt { get; set; }
public string Param91CreatedBy { get; set; }
public bool IsParam91Active { get; set; }
public int Param91SortOrder { get; set; }


public int Config45Id { get; set; }
public string Config45Name { get; set; }
public string Config45Description { get; set; }
public DateTime Config45CreatedAt { get; set; }
public DateTime? Config45UpdatedAt { get; set; }
public string Config45CreatedBy { get; set; }
public bool IsConfig45Active { get; set; }
public int Config45SortOrder { get; set; }


public int Detail38Id { get; set; }
public string Detail38Name { get; set; }
public string Detail38Description { get; set; }
public DateTime Detail38CreatedAt { get; set; }
public DateTime? Detail38UpdatedAt { get; set; }
public string Detail38CreatedBy { get; set; }
public bool IsDetail38Active { get; set; }
public int Detail38SortOrder { get; set; }


public int Param32Id { get; set; }
public string Param32Name { get; set; }
public string Param32Description { get; set; }
public DateTime Param32CreatedAt { get; set; }
public DateTime? Param32UpdatedAt { get; set; }
public string Param32CreatedBy { get; set; }
public bool IsParam32Active { get; set; }
public int Param32SortOrder { get; set; }


public int Entry7Id { get; set; }
public string Entry7Name { get; set; }
public string Entry7Description { get; set; }
public DateTime Entry7CreatedAt { get; set; }
public DateTime? Entry7UpdatedAt { get; set; }
public string Entry7CreatedBy { get; set; }
public bool IsEntry7Active { get; set; }
public int Entry7SortOrder { get; set; }


public int Attr82Id { get; set; }
public string Attr82Name { get; set; }
public string Attr82Description { get; set; }
public DateTime Attr82CreatedAt { get; set; }
public DateTime? Attr82UpdatedAt { get; set; }
public string Attr82CreatedBy { get; set; }
public bool IsAttr82Active { get; set; }
public int Attr82SortOrder { get; set; }


public int Entry60Id { get; set; }
public string Entry60Name { get; set; }
public string Entry60Description { get; set; }
public DateTime Entry60CreatedAt { get; set; }
public DateTime? Entry60UpdatedAt { get; set; }
public string Entry60CreatedBy { get; set; }
public bool IsEntry60Active { get; set; }
public int Entry60SortOrder { get; set; }

    }
}