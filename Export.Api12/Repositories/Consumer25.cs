using Auth.Client38;
using Export.Models461;
using Export.Service;
using Export.Shared;
using Import.Api314;
using Import.Client7;
using Integration.Api;
using Integration.Handlers333;
using Integration.Tests;
using Logging.Service382;
using Portal.Api123;
using Portal.Handlers26;
using Portal.Shared;
using Reporting.Core;
using Security.Api134;
using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Models;

namespace Export.Api12
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer25
    {
        private readonly Auth_Client38_Handler2 _auth_Client38_Handler2;
        private readonly Auth_Client38_Handler4 _auth_Client38_Handler4;
        private readonly Portal_Handlers26_Result6 _portal_Handlers26_Result6;
        private readonly Portal_Handlers26_Provider3 _portal_Handlers26_Provider3;
        private readonly Integration_Tests_Manager2 _integration_Tests_Manager2;
        private readonly IIntegration_Tests_Service4 _iIntegration_Tests_Service4;
        private readonly Import_Api314_Options7 _import_Api314_Options7;
        private readonly Import_Api314_Service2 _import_Api314_Service2;

        public Consumer25(Auth_Client38_Handler2 auth_Client38_Handler2, Auth_Client38_Handler4 auth_Client38_Handler4, Portal_Handlers26_Result6 portal_Handlers26_Result6, Portal_Handlers26_Provider3 portal_Handlers26_Provider3, Integration_Tests_Manager2 integration_Tests_Manager2, IIntegration_Tests_Service4 iIntegration_Tests_Service4, Import_Api314_Options7 import_Api314_Options7, Import_Api314_Service2 import_Api314_Service2)
        {
            _auth_Client38_Handler2 = auth_Client38_Handler2 ?? throw new ArgumentNullException(nameof(auth_Client38_Handler2));
            _auth_Client38_Handler4 = auth_Client38_Handler4 ?? throw new ArgumentNullException(nameof(auth_Client38_Handler4));
            _portal_Handlers26_Result6 = portal_Handlers26_Result6 ?? throw new ArgumentNullException(nameof(portal_Handlers26_Result6));
            _portal_Handlers26_Provider3 = portal_Handlers26_Provider3 ?? throw new ArgumentNullException(nameof(portal_Handlers26_Provider3));
            _integration_Tests_Manager2 = integration_Tests_Manager2 ?? throw new ArgumentNullException(nameof(integration_Tests_Manager2));
            _iIntegration_Tests_Service4 = iIntegration_Tests_Service4 ?? throw new ArgumentNullException(nameof(iIntegration_Tests_Service4));
            _import_Api314_Options7 = import_Api314_Options7 ?? throw new ArgumentNullException(nameof(import_Api314_Options7));
            _import_Api314_Service2 = import_Api314_Service2 ?? throw new ArgumentNullException(nameof(import_Api314_Service2));
        }

        public Auth_Client38_Handler2 GetAuth_Client38_Handler2() => _auth_Client38_Handler2;
        public Auth_Client38_Handler4 GetAuth_Client38_Handler4() => _auth_Client38_Handler4;
        public Portal_Handlers26_Result6 GetPortal_Handlers26_Result6() => _portal_Handlers26_Result6;
        public Portal_Handlers26_Provider3 GetPortal_Handlers26_Provider3() => _portal_Handlers26_Provider3;
        public Integration_Tests_Manager2 GetIntegration_Tests_Manager2() => _integration_Tests_Manager2;
        public IIntegration_Tests_Service4 GetIIntegration_Tests_Service4() => _iIntegration_Tests_Service4;
        public Import_Api314_Options7 GetImport_Api314_Options7() => _import_Api314_Options7;
        public Import_Api314_Service2 GetImport_Api314_Service2() => _import_Api314_Service2;

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

public int Field96Id { get; set; }
public string Field96Name { get; set; }
public string Field96Description { get; set; }
public DateTime Field96CreatedAt { get; set; }
public DateTime? Field96UpdatedAt { get; set; }
public string Field96CreatedBy { get; set; }
public bool IsField96Active { get; set; }
public int Field96SortOrder { get; set; }


public int Param57Id { get; set; }
public string Param57Name { get; set; }
public string Param57Description { get; set; }
public DateTime Param57CreatedAt { get; set; }
public DateTime? Param57UpdatedAt { get; set; }
public string Param57CreatedBy { get; set; }
public bool IsParam57Active { get; set; }
public int Param57SortOrder { get; set; }


public int Record44Id { get; set; }
public string Record44Name { get; set; }
public string Record44Description { get; set; }
public DateTime Record44CreatedAt { get; set; }
public DateTime? Record44UpdatedAt { get; set; }
public string Record44CreatedBy { get; set; }
public bool IsRecord44Active { get; set; }
public int Record44SortOrder { get; set; }


public int Detail54Id { get; set; }
public string Detail54Name { get; set; }
public string Detail54Description { get; set; }
public DateTime Detail54CreatedAt { get; set; }
public DateTime? Detail54UpdatedAt { get; set; }
public string Detail54CreatedBy { get; set; }
public bool IsDetail54Active { get; set; }
public int Detail54SortOrder { get; set; }


public int Config96Id { get; set; }
public string Config96Name { get; set; }
public string Config96Description { get; set; }
public DateTime Config96CreatedAt { get; set; }
public DateTime? Config96UpdatedAt { get; set; }
public string Config96CreatedBy { get; set; }
public bool IsConfig96Active { get; set; }
public int Config96SortOrder { get; set; }


public int Record4Id { get; set; }
public string Record4Name { get; set; }
public string Record4Description { get; set; }
public DateTime Record4CreatedAt { get; set; }
public DateTime? Record4UpdatedAt { get; set; }
public string Record4CreatedBy { get; set; }
public bool IsRecord4Active { get; set; }
public int Record4SortOrder { get; set; }


public int Record82Id { get; set; }
public string Record82Name { get; set; }
public string Record82Description { get; set; }
public DateTime Record82CreatedAt { get; set; }
public DateTime? Record82UpdatedAt { get; set; }
public string Record82CreatedBy { get; set; }
public bool IsRecord82Active { get; set; }
public int Record82SortOrder { get; set; }


public int Record26Id { get; set; }
public string Record26Name { get; set; }
public string Record26Description { get; set; }
public DateTime Record26CreatedAt { get; set; }
public DateTime? Record26UpdatedAt { get; set; }
public string Record26CreatedBy { get; set; }
public bool IsRecord26Active { get; set; }
public int Record26SortOrder { get; set; }


public int Detail63Id { get; set; }
public string Detail63Name { get; set; }
public string Detail63Description { get; set; }
public DateTime Detail63CreatedAt { get; set; }
public DateTime? Detail63UpdatedAt { get; set; }
public string Detail63CreatedBy { get; set; }
public bool IsDetail63Active { get; set; }
public int Detail63SortOrder { get; set; }


public int Param47Id { get; set; }
public string Param47Name { get; set; }
public string Param47Description { get; set; }
public DateTime Param47CreatedAt { get; set; }
public DateTime? Param47UpdatedAt { get; set; }
public string Param47CreatedBy { get; set; }
public bool IsParam47Active { get; set; }
public int Param47SortOrder { get; set; }


public int Param25Id { get; set; }
public string Param25Name { get; set; }
public string Param25Description { get; set; }
public DateTime Param25CreatedAt { get; set; }
public DateTime? Param25UpdatedAt { get; set; }
public string Param25CreatedBy { get; set; }
public bool IsParam25Active { get; set; }
public int Param25SortOrder { get; set; }


public int Attr14Id { get; set; }
public string Attr14Name { get; set; }
public string Attr14Description { get; set; }
public DateTime Attr14CreatedAt { get; set; }
public DateTime? Attr14UpdatedAt { get; set; }
public string Attr14CreatedBy { get; set; }
public bool IsAttr14Active { get; set; }
public int Attr14SortOrder { get; set; }


public int Attr69Id { get; set; }
public string Attr69Name { get; set; }
public string Attr69Description { get; set; }
public DateTime Attr69CreatedAt { get; set; }
public DateTime? Attr69UpdatedAt { get; set; }
public string Attr69CreatedBy { get; set; }
public bool IsAttr69Active { get; set; }
public int Attr69SortOrder { get; set; }


public int Record35Id { get; set; }
public string Record35Name { get; set; }
public string Record35Description { get; set; }
public DateTime Record35CreatedAt { get; set; }
public DateTime? Record35UpdatedAt { get; set; }
public string Record35CreatedBy { get; set; }
public bool IsRecord35Active { get; set; }
public int Record35SortOrder { get; set; }


public int Record57Id { get; set; }
public string Record57Name { get; set; }
public string Record57Description { get; set; }
public DateTime Record57CreatedAt { get; set; }
public DateTime? Record57UpdatedAt { get; set; }
public string Record57CreatedBy { get; set; }
public bool IsRecord57Active { get; set; }
public int Record57SortOrder { get; set; }


public int Item68Id { get; set; }
public string Item68Name { get; set; }
public string Item68Description { get; set; }
public DateTime Item68CreatedAt { get; set; }
public DateTime? Item68UpdatedAt { get; set; }
public string Item68CreatedBy { get; set; }
public bool IsItem68Active { get; set; }
public int Item68SortOrder { get; set; }


public int Config41Id { get; set; }
public string Config41Name { get; set; }
public string Config41Description { get; set; }
public DateTime Config41CreatedAt { get; set; }
public DateTime? Config41UpdatedAt { get; set; }
public string Config41CreatedBy { get; set; }
public bool IsConfig41Active { get; set; }
public int Config41SortOrder { get; set; }


public int Detail44Id { get; set; }
public string Detail44Name { get; set; }
public string Detail44Description { get; set; }
public DateTime Detail44CreatedAt { get; set; }
public DateTime? Detail44UpdatedAt { get; set; }
public string Detail44CreatedBy { get; set; }
public bool IsDetail44Active { get; set; }
public int Detail44SortOrder { get; set; }


public int Detail43Id { get; set; }
public string Detail43Name { get; set; }
public string Detail43Description { get; set; }
public DateTime Detail43CreatedAt { get; set; }
public DateTime? Detail43UpdatedAt { get; set; }
public string Detail43CreatedBy { get; set; }
public bool IsDetail43Active { get; set; }
public int Detail43SortOrder { get; set; }


public int Config96Id { get; set; }
public string Config96Name { get; set; }
public string Config96Description { get; set; }
public DateTime Config96CreatedAt { get; set; }
public DateTime? Config96UpdatedAt { get; set; }
public string Config96CreatedBy { get; set; }
public bool IsConfig96Active { get; set; }
public int Config96SortOrder { get; set; }


public int Entry79Id { get; set; }
public string Entry79Name { get; set; }
public string Entry79Description { get; set; }
public DateTime Entry79CreatedAt { get; set; }
public DateTime? Entry79UpdatedAt { get; set; }
public string Entry79CreatedBy { get; set; }
public bool IsEntry79Active { get; set; }
public int Entry79SortOrder { get; set; }


public int Item13Id { get; set; }
public string Item13Name { get; set; }
public string Item13Description { get; set; }
public DateTime Item13CreatedAt { get; set; }
public DateTime? Item13UpdatedAt { get; set; }
public string Item13CreatedBy { get; set; }
public bool IsItem13Active { get; set; }
public int Item13SortOrder { get; set; }


public int Record27Id { get; set; }
public string Record27Name { get; set; }
public string Record27Description { get; set; }
public DateTime Record27CreatedAt { get; set; }
public DateTime? Record27UpdatedAt { get; set; }
public string Record27CreatedBy { get; set; }
public bool IsRecord27Active { get; set; }
public int Record27SortOrder { get; set; }


public int Entry49Id { get; set; }
public string Entry49Name { get; set; }
public string Entry49Description { get; set; }
public DateTime Entry49CreatedAt { get; set; }
public DateTime? Entry49UpdatedAt { get; set; }
public string Entry49CreatedBy { get; set; }
public bool IsEntry49Active { get; set; }
public int Entry49SortOrder { get; set; }


public int Field9Id { get; set; }
public string Field9Name { get; set; }
public string Field9Description { get; set; }
public DateTime Field9CreatedAt { get; set; }
public DateTime? Field9UpdatedAt { get; set; }
public string Field9CreatedBy { get; set; }
public bool IsField9Active { get; set; }
public int Field9SortOrder { get; set; }


public int Entry87Id { get; set; }
public string Entry87Name { get; set; }
public string Entry87Description { get; set; }
public DateTime Entry87CreatedAt { get; set; }
public DateTime? Entry87UpdatedAt { get; set; }
public string Entry87CreatedBy { get; set; }
public bool IsEntry87Active { get; set; }
public int Entry87SortOrder { get; set; }


public int Param38Id { get; set; }
public string Param38Name { get; set; }
public string Param38Description { get; set; }
public DateTime Param38CreatedAt { get; set; }
public DateTime? Param38UpdatedAt { get; set; }
public string Param38CreatedBy { get; set; }
public bool IsParam38Active { get; set; }
public int Param38SortOrder { get; set; }


public int Item27Id { get; set; }
public string Item27Name { get; set; }
public string Item27Description { get; set; }
public DateTime Item27CreatedAt { get; set; }
public DateTime? Item27UpdatedAt { get; set; }
public string Item27CreatedBy { get; set; }
public bool IsItem27Active { get; set; }
public int Item27SortOrder { get; set; }


public int Record65Id { get; set; }
public string Record65Name { get; set; }
public string Record65Description { get; set; }
public DateTime Record65CreatedAt { get; set; }
public DateTime? Record65UpdatedAt { get; set; }
public string Record65CreatedBy { get; set; }
public bool IsRecord65Active { get; set; }
public int Record65SortOrder { get; set; }


public int Record52Id { get; set; }
public string Record52Name { get; set; }
public string Record52Description { get; set; }
public DateTime Record52CreatedAt { get; set; }
public DateTime? Record52UpdatedAt { get; set; }
public string Record52CreatedBy { get; set; }
public bool IsRecord52Active { get; set; }
public int Record52SortOrder { get; set; }


public int Detail47Id { get; set; }
public string Detail47Name { get; set; }
public string Detail47Description { get; set; }
public DateTime Detail47CreatedAt { get; set; }
public DateTime? Detail47UpdatedAt { get; set; }
public string Detail47CreatedBy { get; set; }
public bool IsDetail47Active { get; set; }
public int Detail47SortOrder { get; set; }


public int Config24Id { get; set; }
public string Config24Name { get; set; }
public string Config24Description { get; set; }
public DateTime Config24CreatedAt { get; set; }
public DateTime? Config24UpdatedAt { get; set; }
public string Config24CreatedBy { get; set; }
public bool IsConfig24Active { get; set; }
public int Config24SortOrder { get; set; }


public int Entry75Id { get; set; }
public string Entry75Name { get; set; }
public string Entry75Description { get; set; }
public DateTime Entry75CreatedAt { get; set; }
public DateTime? Entry75UpdatedAt { get; set; }
public string Entry75CreatedBy { get; set; }
public bool IsEntry75Active { get; set; }
public int Entry75SortOrder { get; set; }


public int Item96Id { get; set; }
public string Item96Name { get; set; }
public string Item96Description { get; set; }
public DateTime Item96CreatedAt { get; set; }
public DateTime? Item96UpdatedAt { get; set; }
public string Item96CreatedBy { get; set; }
public bool IsItem96Active { get; set; }
public int Item96SortOrder { get; set; }


public int Detail78Id { get; set; }
public string Detail78Name { get; set; }
public string Detail78Description { get; set; }
public DateTime Detail78CreatedAt { get; set; }
public DateTime? Detail78UpdatedAt { get; set; }
public string Detail78CreatedBy { get; set; }
public bool IsDetail78Active { get; set; }
public int Detail78SortOrder { get; set; }


public int Field95Id { get; set; }
public string Field95Name { get; set; }
public string Field95Description { get; set; }
public DateTime Field95CreatedAt { get; set; }
public DateTime? Field95UpdatedAt { get; set; }
public string Field95CreatedBy { get; set; }
public bool IsField95Active { get; set; }
public int Field95SortOrder { get; set; }


public int Detail28Id { get; set; }
public string Detail28Name { get; set; }
public string Detail28Description { get; set; }
public DateTime Detail28CreatedAt { get; set; }
public DateTime? Detail28UpdatedAt { get; set; }
public string Detail28CreatedBy { get; set; }
public bool IsDetail28Active { get; set; }
public int Detail28SortOrder { get; set; }


public int Record12Id { get; set; }
public string Record12Name { get; set; }
public string Record12Description { get; set; }
public DateTime Record12CreatedAt { get; set; }
public DateTime? Record12UpdatedAt { get; set; }
public string Record12CreatedBy { get; set; }
public bool IsRecord12Active { get; set; }
public int Record12SortOrder { get; set; }


public int Item90Id { get; set; }
public string Item90Name { get; set; }
public string Item90Description { get; set; }
public DateTime Item90CreatedAt { get; set; }
public DateTime? Item90UpdatedAt { get; set; }
public string Item90CreatedBy { get; set; }
public bool IsItem90Active { get; set; }
public int Item90SortOrder { get; set; }


public int Entry89Id { get; set; }
public string Entry89Name { get; set; }
public string Entry89Description { get; set; }
public DateTime Entry89CreatedAt { get; set; }
public DateTime? Entry89UpdatedAt { get; set; }
public string Entry89CreatedBy { get; set; }
public bool IsEntry89Active { get; set; }
public int Entry89SortOrder { get; set; }


public int Record41Id { get; set; }
public string Record41Name { get; set; }
public string Record41Description { get; set; }
public DateTime Record41CreatedAt { get; set; }
public DateTime? Record41UpdatedAt { get; set; }
public string Record41CreatedBy { get; set; }
public bool IsRecord41Active { get; set; }
public int Record41SortOrder { get; set; }


public int Entry64Id { get; set; }
public string Entry64Name { get; set; }
public string Entry64Description { get; set; }
public DateTime Entry64CreatedAt { get; set; }
public DateTime? Entry64UpdatedAt { get; set; }
public string Entry64CreatedBy { get; set; }
public bool IsEntry64Active { get; set; }
public int Entry64SortOrder { get; set; }


public int Attr46Id { get; set; }
public string Attr46Name { get; set; }
public string Attr46Description { get; set; }
public DateTime Attr46CreatedAt { get; set; }
public DateTime? Attr46UpdatedAt { get; set; }
public string Attr46CreatedBy { get; set; }
public bool IsAttr46Active { get; set; }
public int Attr46SortOrder { get; set; }


public int Attr96Id { get; set; }
public string Attr96Name { get; set; }
public string Attr96Description { get; set; }
public DateTime Attr96CreatedAt { get; set; }
public DateTime? Attr96UpdatedAt { get; set; }
public string Attr96CreatedBy { get; set; }
public bool IsAttr96Active { get; set; }
public int Attr96SortOrder { get; set; }


public int Config22Id { get; set; }
public string Config22Name { get; set; }
public string Config22Description { get; set; }
public DateTime Config22CreatedAt { get; set; }
public DateTime? Config22UpdatedAt { get; set; }
public string Config22CreatedBy { get; set; }
public bool IsConfig22Active { get; set; }
public int Config22SortOrder { get; set; }


public int Attr56Id { get; set; }
public string Attr56Name { get; set; }
public string Attr56Description { get; set; }
public DateTime Attr56CreatedAt { get; set; }
public DateTime? Attr56UpdatedAt { get; set; }
public string Attr56CreatedBy { get; set; }
public bool IsAttr56Active { get; set; }
public int Attr56SortOrder { get; set; }

    }
}