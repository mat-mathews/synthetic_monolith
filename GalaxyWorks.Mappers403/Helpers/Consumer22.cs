using Admin.Api;
using Admin.Core;
using Auth.Mappers206;
using Auth.Models236;
using BatchJobs.Contracts;
using Billing.Core191;
using Billing.Service;
using Common.Service258;
using Documents.Api251;
using Documents.Events;
using Import.Api314;
using Integration.Tests45;
using Logging.Client405;
using Scheduling.Handlers63;
using Scheduling.Models441;
using Scheduling.Web196;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Core;
using Utilities.Web40;

namespace GalaxyWorks.Mappers403
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer22
    {
        private readonly Auth_Models236_Controller3 _auth_Models236_Controller3;
        private readonly Auth_Models236_Processor1 _auth_Models236_Processor1;
        private readonly IAdmin_Api_Repository3 _iAdmin_Api_Repository3;
        private readonly Utilities_Web40_Manager _utilities_Web40_Manager;
        private readonly Documents_Events_Builder10 _documents_Events_Builder10;
        private readonly Documents_Events_ViewModel12 _documents_Events_ViewModel12;
        private readonly Import_Api314_Controller5 _import_Api314_Controller5;
        private readonly IBilling_Core191_Repository1 _iBilling_Core191_Repository1;

        public Consumer22(Auth_Models236_Controller3 auth_Models236_Controller3, Auth_Models236_Processor1 auth_Models236_Processor1, IAdmin_Api_Repository3 iAdmin_Api_Repository3, Utilities_Web40_Manager utilities_Web40_Manager, Documents_Events_Builder10 documents_Events_Builder10, Documents_Events_ViewModel12 documents_Events_ViewModel12, Import_Api314_Controller5 import_Api314_Controller5, IBilling_Core191_Repository1 iBilling_Core191_Repository1)
        {
            _auth_Models236_Controller3 = auth_Models236_Controller3 ?? throw new ArgumentNullException(nameof(auth_Models236_Controller3));
            _auth_Models236_Processor1 = auth_Models236_Processor1 ?? throw new ArgumentNullException(nameof(auth_Models236_Processor1));
            _iAdmin_Api_Repository3 = iAdmin_Api_Repository3 ?? throw new ArgumentNullException(nameof(iAdmin_Api_Repository3));
            _utilities_Web40_Manager = utilities_Web40_Manager ?? throw new ArgumentNullException(nameof(utilities_Web40_Manager));
            _documents_Events_Builder10 = documents_Events_Builder10 ?? throw new ArgumentNullException(nameof(documents_Events_Builder10));
            _documents_Events_ViewModel12 = documents_Events_ViewModel12 ?? throw new ArgumentNullException(nameof(documents_Events_ViewModel12));
            _import_Api314_Controller5 = import_Api314_Controller5 ?? throw new ArgumentNullException(nameof(import_Api314_Controller5));
            _iBilling_Core191_Repository1 = iBilling_Core191_Repository1 ?? throw new ArgumentNullException(nameof(iBilling_Core191_Repository1));
        }

        public Auth_Models236_Controller3 GetAuth_Models236_Controller3() => _auth_Models236_Controller3;
        public Auth_Models236_Processor1 GetAuth_Models236_Processor1() => _auth_Models236_Processor1;
        public IAdmin_Api_Repository3 GetIAdmin_Api_Repository3() => _iAdmin_Api_Repository3;
        public Utilities_Web40_Manager GetUtilities_Web40_Manager() => _utilities_Web40_Manager;
        public Documents_Events_Builder10 GetDocuments_Events_Builder10() => _documents_Events_Builder10;
        public Documents_Events_ViewModel12 GetDocuments_Events_ViewModel12() => _documents_Events_ViewModel12;
        public Import_Api314_Controller5 GetImport_Api314_Controller5() => _import_Api314_Controller5;
        public IBilling_Core191_Repository1 GetIBilling_Core191_Repository1() => _iBilling_Core191_Repository1;

/// <summary>
/// Validates the Consumer22 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer22(Consumer22Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer22));
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
/// Processes the Consumer22 operation asynchronously.
/// </summary>
public async Task<Consumer22Result> ProcessConsumer22Async(
    Consumer22Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer22), request.Id);

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
            return new Consumer22Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer22));
        return new Consumer22Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer22));
        return new Consumer22Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer22 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer22Dto>> GetConsumer22ListAsync(
    Consumer22Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer22Entity>().AsQueryable();

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
        .Select(x => new Consumer22Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer22Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer22Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer22Service(
    ILogger<Consumer22Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer22:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer22 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer22Data> GetCachedConsumer22Async(string key)
{
    var cacheKey = $"Consumer22_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer22Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer22SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Param94Id { get; set; }
public string Param94Name { get; set; }
public string Param94Description { get; set; }
public DateTime Param94CreatedAt { get; set; }
public DateTime? Param94UpdatedAt { get; set; }
public string Param94CreatedBy { get; set; }
public bool IsParam94Active { get; set; }
public int Param94SortOrder { get; set; }


public int Record81Id { get; set; }
public string Record81Name { get; set; }
public string Record81Description { get; set; }
public DateTime Record81CreatedAt { get; set; }
public DateTime? Record81UpdatedAt { get; set; }
public string Record81CreatedBy { get; set; }
public bool IsRecord81Active { get; set; }
public int Record81SortOrder { get; set; }


public int Item41Id { get; set; }
public string Item41Name { get; set; }
public string Item41Description { get; set; }
public DateTime Item41CreatedAt { get; set; }
public DateTime? Item41UpdatedAt { get; set; }
public string Item41CreatedBy { get; set; }
public bool IsItem41Active { get; set; }
public int Item41SortOrder { get; set; }


public int Config85Id { get; set; }
public string Config85Name { get; set; }
public string Config85Description { get; set; }
public DateTime Config85CreatedAt { get; set; }
public DateTime? Config85UpdatedAt { get; set; }
public string Config85CreatedBy { get; set; }
public bool IsConfig85Active { get; set; }
public int Config85SortOrder { get; set; }


public int Config63Id { get; set; }
public string Config63Name { get; set; }
public string Config63Description { get; set; }
public DateTime Config63CreatedAt { get; set; }
public DateTime? Config63UpdatedAt { get; set; }
public string Config63CreatedBy { get; set; }
public bool IsConfig63Active { get; set; }
public int Config63SortOrder { get; set; }


public int Detail77Id { get; set; }
public string Detail77Name { get; set; }
public string Detail77Description { get; set; }
public DateTime Detail77CreatedAt { get; set; }
public DateTime? Detail77UpdatedAt { get; set; }
public string Detail77CreatedBy { get; set; }
public bool IsDetail77Active { get; set; }
public int Detail77SortOrder { get; set; }


public int Field1Id { get; set; }
public string Field1Name { get; set; }
public string Field1Description { get; set; }
public DateTime Field1CreatedAt { get; set; }
public DateTime? Field1UpdatedAt { get; set; }
public string Field1CreatedBy { get; set; }
public bool IsField1Active { get; set; }
public int Field1SortOrder { get; set; }


public int Param6Id { get; set; }
public string Param6Name { get; set; }
public string Param6Description { get; set; }
public DateTime Param6CreatedAt { get; set; }
public DateTime? Param6UpdatedAt { get; set; }
public string Param6CreatedBy { get; set; }
public bool IsParam6Active { get; set; }
public int Param6SortOrder { get; set; }


public int Param87Id { get; set; }
public string Param87Name { get; set; }
public string Param87Description { get; set; }
public DateTime Param87CreatedAt { get; set; }
public DateTime? Param87UpdatedAt { get; set; }
public string Param87CreatedBy { get; set; }
public bool IsParam87Active { get; set; }
public int Param87SortOrder { get; set; }


public int Item80Id { get; set; }
public string Item80Name { get; set; }
public string Item80Description { get; set; }
public DateTime Item80CreatedAt { get; set; }
public DateTime? Item80UpdatedAt { get; set; }
public string Item80CreatedBy { get; set; }
public bool IsItem80Active { get; set; }
public int Item80SortOrder { get; set; }


public int Attr50Id { get; set; }
public string Attr50Name { get; set; }
public string Attr50Description { get; set; }
public DateTime Attr50CreatedAt { get; set; }
public DateTime? Attr50UpdatedAt { get; set; }
public string Attr50CreatedBy { get; set; }
public bool IsAttr50Active { get; set; }
public int Attr50SortOrder { get; set; }


public int Record78Id { get; set; }
public string Record78Name { get; set; }
public string Record78Description { get; set; }
public DateTime Record78CreatedAt { get; set; }
public DateTime? Record78UpdatedAt { get; set; }
public string Record78CreatedBy { get; set; }
public bool IsRecord78Active { get; set; }
public int Record78SortOrder { get; set; }


public int Param94Id { get; set; }
public string Param94Name { get; set; }
public string Param94Description { get; set; }
public DateTime Param94CreatedAt { get; set; }
public DateTime? Param94UpdatedAt { get; set; }
public string Param94CreatedBy { get; set; }
public bool IsParam94Active { get; set; }
public int Param94SortOrder { get; set; }


public int Detail5Id { get; set; }
public string Detail5Name { get; set; }
public string Detail5Description { get; set; }
public DateTime Detail5CreatedAt { get; set; }
public DateTime? Detail5UpdatedAt { get; set; }
public string Detail5CreatedBy { get; set; }
public bool IsDetail5Active { get; set; }
public int Detail5SortOrder { get; set; }


public int Attr28Id { get; set; }
public string Attr28Name { get; set; }
public string Attr28Description { get; set; }
public DateTime Attr28CreatedAt { get; set; }
public DateTime? Attr28UpdatedAt { get; set; }
public string Attr28CreatedBy { get; set; }
public bool IsAttr28Active { get; set; }
public int Attr28SortOrder { get; set; }


public int Item16Id { get; set; }
public string Item16Name { get; set; }
public string Item16Description { get; set; }
public DateTime Item16CreatedAt { get; set; }
public DateTime? Item16UpdatedAt { get; set; }
public string Item16CreatedBy { get; set; }
public bool IsItem16Active { get; set; }
public int Item16SortOrder { get; set; }


public int Param78Id { get; set; }
public string Param78Name { get; set; }
public string Param78Description { get; set; }
public DateTime Param78CreatedAt { get; set; }
public DateTime? Param78UpdatedAt { get; set; }
public string Param78CreatedBy { get; set; }
public bool IsParam78Active { get; set; }
public int Param78SortOrder { get; set; }


public int Record27Id { get; set; }
public string Record27Name { get; set; }
public string Record27Description { get; set; }
public DateTime Record27CreatedAt { get; set; }
public DateTime? Record27UpdatedAt { get; set; }
public string Record27CreatedBy { get; set; }
public bool IsRecord27Active { get; set; }
public int Record27SortOrder { get; set; }


public int Param57Id { get; set; }
public string Param57Name { get; set; }
public string Param57Description { get; set; }
public DateTime Param57CreatedAt { get; set; }
public DateTime? Param57UpdatedAt { get; set; }
public string Param57CreatedBy { get; set; }
public bool IsParam57Active { get; set; }
public int Param57SortOrder { get; set; }


public int Attr45Id { get; set; }
public string Attr45Name { get; set; }
public string Attr45Description { get; set; }
public DateTime Attr45CreatedAt { get; set; }
public DateTime? Attr45UpdatedAt { get; set; }
public string Attr45CreatedBy { get; set; }
public bool IsAttr45Active { get; set; }
public int Attr45SortOrder { get; set; }


public int Field61Id { get; set; }
public string Field61Name { get; set; }
public string Field61Description { get; set; }
public DateTime Field61CreatedAt { get; set; }
public DateTime? Field61UpdatedAt { get; set; }
public string Field61CreatedBy { get; set; }
public bool IsField61Active { get; set; }
public int Field61SortOrder { get; set; }


public int Detail43Id { get; set; }
public string Detail43Name { get; set; }
public string Detail43Description { get; set; }
public DateTime Detail43CreatedAt { get; set; }
public DateTime? Detail43UpdatedAt { get; set; }
public string Detail43CreatedBy { get; set; }
public bool IsDetail43Active { get; set; }
public int Detail43SortOrder { get; set; }


public int Detail8Id { get; set; }
public string Detail8Name { get; set; }
public string Detail8Description { get; set; }
public DateTime Detail8CreatedAt { get; set; }
public DateTime? Detail8UpdatedAt { get; set; }
public string Detail8CreatedBy { get; set; }
public bool IsDetail8Active { get; set; }
public int Detail8SortOrder { get; set; }


public int Field76Id { get; set; }
public string Field76Name { get; set; }
public string Field76Description { get; set; }
public DateTime Field76CreatedAt { get; set; }
public DateTime? Field76UpdatedAt { get; set; }
public string Field76CreatedBy { get; set; }
public bool IsField76Active { get; set; }
public int Field76SortOrder { get; set; }


public int Attr52Id { get; set; }
public string Attr52Name { get; set; }
public string Attr52Description { get; set; }
public DateTime Attr52CreatedAt { get; set; }
public DateTime? Attr52UpdatedAt { get; set; }
public string Attr52CreatedBy { get; set; }
public bool IsAttr52Active { get; set; }
public int Attr52SortOrder { get; set; }


public int Param31Id { get; set; }
public string Param31Name { get; set; }
public string Param31Description { get; set; }
public DateTime Param31CreatedAt { get; set; }
public DateTime? Param31UpdatedAt { get; set; }
public string Param31CreatedBy { get; set; }
public bool IsParam31Active { get; set; }
public int Param31SortOrder { get; set; }


public int Record46Id { get; set; }
public string Record46Name { get; set; }
public string Record46Description { get; set; }
public DateTime Record46CreatedAt { get; set; }
public DateTime? Record46UpdatedAt { get; set; }
public string Record46CreatedBy { get; set; }
public bool IsRecord46Active { get; set; }
public int Record46SortOrder { get; set; }


public int Field41Id { get; set; }
public string Field41Name { get; set; }
public string Field41Description { get; set; }
public DateTime Field41CreatedAt { get; set; }
public DateTime? Field41UpdatedAt { get; set; }
public string Field41CreatedBy { get; set; }
public bool IsField41Active { get; set; }
public int Field41SortOrder { get; set; }


public int Attr13Id { get; set; }
public string Attr13Name { get; set; }
public string Attr13Description { get; set; }
public DateTime Attr13CreatedAt { get; set; }
public DateTime? Attr13UpdatedAt { get; set; }
public string Attr13CreatedBy { get; set; }
public bool IsAttr13Active { get; set; }
public int Attr13SortOrder { get; set; }


public int Attr53Id { get; set; }
public string Attr53Name { get; set; }
public string Attr53Description { get; set; }
public DateTime Attr53CreatedAt { get; set; }
public DateTime? Attr53UpdatedAt { get; set; }
public string Attr53CreatedBy { get; set; }
public bool IsAttr53Active { get; set; }
public int Attr53SortOrder { get; set; }


public int Entry85Id { get; set; }
public string Entry85Name { get; set; }
public string Entry85Description { get; set; }
public DateTime Entry85CreatedAt { get; set; }
public DateTime? Entry85UpdatedAt { get; set; }
public string Entry85CreatedBy { get; set; }
public bool IsEntry85Active { get; set; }
public int Entry85SortOrder { get; set; }


public int Config36Id { get; set; }
public string Config36Name { get; set; }
public string Config36Description { get; set; }
public DateTime Config36CreatedAt { get; set; }
public DateTime? Config36UpdatedAt { get; set; }
public string Config36CreatedBy { get; set; }
public bool IsConfig36Active { get; set; }
public int Config36SortOrder { get; set; }


public int Record90Id { get; set; }
public string Record90Name { get; set; }
public string Record90Description { get; set; }
public DateTime Record90CreatedAt { get; set; }
public DateTime? Record90UpdatedAt { get; set; }
public string Record90CreatedBy { get; set; }
public bool IsRecord90Active { get; set; }
public int Record90SortOrder { get; set; }


public int Detail25Id { get; set; }
public string Detail25Name { get; set; }
public string Detail25Description { get; set; }
public DateTime Detail25CreatedAt { get; set; }
public DateTime? Detail25UpdatedAt { get; set; }
public string Detail25CreatedBy { get; set; }
public bool IsDetail25Active { get; set; }
public int Detail25SortOrder { get; set; }


public int Detail45Id { get; set; }
public string Detail45Name { get; set; }
public string Detail45Description { get; set; }
public DateTime Detail45CreatedAt { get; set; }
public DateTime? Detail45UpdatedAt { get; set; }
public string Detail45CreatedBy { get; set; }
public bool IsDetail45Active { get; set; }
public int Detail45SortOrder { get; set; }


public int Field2Id { get; set; }
public string Field2Name { get; set; }
public string Field2Description { get; set; }
public DateTime Field2CreatedAt { get; set; }
public DateTime? Field2UpdatedAt { get; set; }
public string Field2CreatedBy { get; set; }
public bool IsField2Active { get; set; }
public int Field2SortOrder { get; set; }


public int Config86Id { get; set; }
public string Config86Name { get; set; }
public string Config86Description { get; set; }
public DateTime Config86CreatedAt { get; set; }
public DateTime? Config86UpdatedAt { get; set; }
public string Config86CreatedBy { get; set; }
public bool IsConfig86Active { get; set; }
public int Config86SortOrder { get; set; }


public int Item34Id { get; set; }
public string Item34Name { get; set; }
public string Item34Description { get; set; }
public DateTime Item34CreatedAt { get; set; }
public DateTime? Item34UpdatedAt { get; set; }
public string Item34CreatedBy { get; set; }
public bool IsItem34Active { get; set; }
public int Item34SortOrder { get; set; }


public int Record59Id { get; set; }
public string Record59Name { get; set; }
public string Record59Description { get; set; }
public DateTime Record59CreatedAt { get; set; }
public DateTime? Record59UpdatedAt { get; set; }
public string Record59CreatedBy { get; set; }
public bool IsRecord59Active { get; set; }
public int Record59SortOrder { get; set; }


public int Attr77Id { get; set; }
public string Attr77Name { get; set; }
public string Attr77Description { get; set; }
public DateTime Attr77CreatedAt { get; set; }
public DateTime? Attr77UpdatedAt { get; set; }
public string Attr77CreatedBy { get; set; }
public bool IsAttr77Active { get; set; }
public int Attr77SortOrder { get; set; }


public int Entry47Id { get; set; }
public string Entry47Name { get; set; }
public string Entry47Description { get; set; }
public DateTime Entry47CreatedAt { get; set; }
public DateTime? Entry47UpdatedAt { get; set; }
public string Entry47CreatedBy { get; set; }
public bool IsEntry47Active { get; set; }
public int Entry47SortOrder { get; set; }


public int Config40Id { get; set; }
public string Config40Name { get; set; }
public string Config40Description { get; set; }
public DateTime Config40CreatedAt { get; set; }
public DateTime? Config40UpdatedAt { get; set; }
public string Config40CreatedBy { get; set; }
public bool IsConfig40Active { get; set; }
public int Config40SortOrder { get; set; }


public int Record76Id { get; set; }
public string Record76Name { get; set; }
public string Record76Description { get; set; }
public DateTime Record76CreatedAt { get; set; }
public DateTime? Record76UpdatedAt { get; set; }
public string Record76CreatedBy { get; set; }
public bool IsRecord76Active { get; set; }
public int Record76SortOrder { get; set; }


public int Field52Id { get; set; }
public string Field52Name { get; set; }
public string Field52Description { get; set; }
public DateTime Field52CreatedAt { get; set; }
public DateTime? Field52UpdatedAt { get; set; }
public string Field52CreatedBy { get; set; }
public bool IsField52Active { get; set; }
public int Field52SortOrder { get; set; }


public int Attr36Id { get; set; }
public string Attr36Name { get; set; }
public string Attr36Description { get; set; }
public DateTime Attr36CreatedAt { get; set; }
public DateTime? Attr36UpdatedAt { get; set; }
public string Attr36CreatedBy { get; set; }
public bool IsAttr36Active { get; set; }
public int Attr36SortOrder { get; set; }

    }
}