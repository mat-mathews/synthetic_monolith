using Auth.Client271;
using DataAccess.Mappers;
using Documents.Core;
using Documents.Events;
using Export.Processors104;
using GalaxyWorks.Data96;
using Import.Service496;
using Notifications.Tests;
using Portal.Handlers;
using Reporting.Events188;
using Reporting.Service207;
using Scheduling.Processors80;
using Scheduling.Tests76;
using Security.Models284;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Mappers232;
using Workflow.Tests;

namespace Workflow.Web377
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer5
    {
        private readonly IAuth_Client271_Repository4 _iAuth_Client271_Repository4;
        private readonly IAuth_Client271_Handler7 _iAuth_Client271_Handler7;
        private readonly Auth_Client271_Manager _auth_Client271_Manager;
        private readonly Workflow_Tests_Helper4 _workflow_Tests_Helper4;
        private readonly Workflow_Tests_Factory11 _workflow_Tests_Factory11;
        private readonly Reporting_Service207_Manager5 _reporting_Service207_Manager5;
        private readonly Reporting_Service207_Range7 _reporting_Service207_Range7;
        private readonly Reporting_Service207_Options9 _reporting_Service207_Options9;

        public Consumer5(IAuth_Client271_Repository4 iAuth_Client271_Repository4, IAuth_Client271_Handler7 iAuth_Client271_Handler7, Auth_Client271_Manager auth_Client271_Manager, Workflow_Tests_Helper4 workflow_Tests_Helper4, Workflow_Tests_Factory11 workflow_Tests_Factory11, Reporting_Service207_Manager5 reporting_Service207_Manager5, Reporting_Service207_Range7 reporting_Service207_Range7, Reporting_Service207_Options9 reporting_Service207_Options9)
        {
            _iAuth_Client271_Repository4 = iAuth_Client271_Repository4 ?? throw new ArgumentNullException(nameof(iAuth_Client271_Repository4));
            _iAuth_Client271_Handler7 = iAuth_Client271_Handler7 ?? throw new ArgumentNullException(nameof(iAuth_Client271_Handler7));
            _auth_Client271_Manager = auth_Client271_Manager ?? throw new ArgumentNullException(nameof(auth_Client271_Manager));
            _workflow_Tests_Helper4 = workflow_Tests_Helper4 ?? throw new ArgumentNullException(nameof(workflow_Tests_Helper4));
            _workflow_Tests_Factory11 = workflow_Tests_Factory11 ?? throw new ArgumentNullException(nameof(workflow_Tests_Factory11));
            _reporting_Service207_Manager5 = reporting_Service207_Manager5 ?? throw new ArgumentNullException(nameof(reporting_Service207_Manager5));
            _reporting_Service207_Range7 = reporting_Service207_Range7 ?? throw new ArgumentNullException(nameof(reporting_Service207_Range7));
            _reporting_Service207_Options9 = reporting_Service207_Options9 ?? throw new ArgumentNullException(nameof(reporting_Service207_Options9));
        }

        public IAuth_Client271_Repository4 GetIAuth_Client271_Repository4() => _iAuth_Client271_Repository4;
        public IAuth_Client271_Handler7 GetIAuth_Client271_Handler7() => _iAuth_Client271_Handler7;
        public Auth_Client271_Manager GetAuth_Client271_Manager() => _auth_Client271_Manager;
        public Workflow_Tests_Helper4 GetWorkflow_Tests_Helper4() => _workflow_Tests_Helper4;
        public Workflow_Tests_Factory11 GetWorkflow_Tests_Factory11() => _workflow_Tests_Factory11;
        public Reporting_Service207_Manager5 GetReporting_Service207_Manager5() => _reporting_Service207_Manager5;
        public Reporting_Service207_Range7 GetReporting_Service207_Range7() => _reporting_Service207_Range7;
        public Reporting_Service207_Options9 GetReporting_Service207_Options9() => _reporting_Service207_Options9;

/// <summary>
/// Validates the Consumer5 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer5(Consumer5Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer5));
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
/// Processes the Consumer5 operation asynchronously.
/// </summary>
public async Task<Consumer5Result> ProcessConsumer5Async(
    Consumer5Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer5), request.Id);

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
            return new Consumer5Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer5));
        return new Consumer5Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer5));
        return new Consumer5Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer5 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer5Dto>> GetConsumer5ListAsync(
    Consumer5Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer5Entity>().AsQueryable();

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
        .Select(x => new Consumer5Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer5Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer5Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer5Service(
    ILogger<Consumer5Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer5:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer5 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer5Data> GetCachedConsumer5Async(string key)
{
    var cacheKey = $"Consumer5_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer5Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer5SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Field72Id { get; set; }
public string Field72Name { get; set; }
public string Field72Description { get; set; }
public DateTime Field72CreatedAt { get; set; }
public DateTime? Field72UpdatedAt { get; set; }
public string Field72CreatedBy { get; set; }
public bool IsField72Active { get; set; }
public int Field72SortOrder { get; set; }


public int Detail63Id { get; set; }
public string Detail63Name { get; set; }
public string Detail63Description { get; set; }
public DateTime Detail63CreatedAt { get; set; }
public DateTime? Detail63UpdatedAt { get; set; }
public string Detail63CreatedBy { get; set; }
public bool IsDetail63Active { get; set; }
public int Detail63SortOrder { get; set; }


public int Item66Id { get; set; }
public string Item66Name { get; set; }
public string Item66Description { get; set; }
public DateTime Item66CreatedAt { get; set; }
public DateTime? Item66UpdatedAt { get; set; }
public string Item66CreatedBy { get; set; }
public bool IsItem66Active { get; set; }
public int Item66SortOrder { get; set; }


public int Item86Id { get; set; }
public string Item86Name { get; set; }
public string Item86Description { get; set; }
public DateTime Item86CreatedAt { get; set; }
public DateTime? Item86UpdatedAt { get; set; }
public string Item86CreatedBy { get; set; }
public bool IsItem86Active { get; set; }
public int Item86SortOrder { get; set; }


public int Attr48Id { get; set; }
public string Attr48Name { get; set; }
public string Attr48Description { get; set; }
public DateTime Attr48CreatedAt { get; set; }
public DateTime? Attr48UpdatedAt { get; set; }
public string Attr48CreatedBy { get; set; }
public bool IsAttr48Active { get; set; }
public int Attr48SortOrder { get; set; }


public int Param9Id { get; set; }
public string Param9Name { get; set; }
public string Param9Description { get; set; }
public DateTime Param9CreatedAt { get; set; }
public DateTime? Param9UpdatedAt { get; set; }
public string Param9CreatedBy { get; set; }
public bool IsParam9Active { get; set; }
public int Param9SortOrder { get; set; }


public int Item50Id { get; set; }
public string Item50Name { get; set; }
public string Item50Description { get; set; }
public DateTime Item50CreatedAt { get; set; }
public DateTime? Item50UpdatedAt { get; set; }
public string Item50CreatedBy { get; set; }
public bool IsItem50Active { get; set; }
public int Item50SortOrder { get; set; }


public int Field53Id { get; set; }
public string Field53Name { get; set; }
public string Field53Description { get; set; }
public DateTime Field53CreatedAt { get; set; }
public DateTime? Field53UpdatedAt { get; set; }
public string Field53CreatedBy { get; set; }
public bool IsField53Active { get; set; }
public int Field53SortOrder { get; set; }


public int Detail84Id { get; set; }
public string Detail84Name { get; set; }
public string Detail84Description { get; set; }
public DateTime Detail84CreatedAt { get; set; }
public DateTime? Detail84UpdatedAt { get; set; }
public string Detail84CreatedBy { get; set; }
public bool IsDetail84Active { get; set; }
public int Detail84SortOrder { get; set; }


public int Config86Id { get; set; }
public string Config86Name { get; set; }
public string Config86Description { get; set; }
public DateTime Config86CreatedAt { get; set; }
public DateTime? Config86UpdatedAt { get; set; }
public string Config86CreatedBy { get; set; }
public bool IsConfig86Active { get; set; }
public int Config86SortOrder { get; set; }


public int Entry46Id { get; set; }
public string Entry46Name { get; set; }
public string Entry46Description { get; set; }
public DateTime Entry46CreatedAt { get; set; }
public DateTime? Entry46UpdatedAt { get; set; }
public string Entry46CreatedBy { get; set; }
public bool IsEntry46Active { get; set; }
public int Entry46SortOrder { get; set; }


public int Item1Id { get; set; }
public string Item1Name { get; set; }
public string Item1Description { get; set; }
public DateTime Item1CreatedAt { get; set; }
public DateTime? Item1UpdatedAt { get; set; }
public string Item1CreatedBy { get; set; }
public bool IsItem1Active { get; set; }
public int Item1SortOrder { get; set; }


public int Detail87Id { get; set; }
public string Detail87Name { get; set; }
public string Detail87Description { get; set; }
public DateTime Detail87CreatedAt { get; set; }
public DateTime? Detail87UpdatedAt { get; set; }
public string Detail87CreatedBy { get; set; }
public bool IsDetail87Active { get; set; }
public int Detail87SortOrder { get; set; }


public int Param72Id { get; set; }
public string Param72Name { get; set; }
public string Param72Description { get; set; }
public DateTime Param72CreatedAt { get; set; }
public DateTime? Param72UpdatedAt { get; set; }
public string Param72CreatedBy { get; set; }
public bool IsParam72Active { get; set; }
public int Param72SortOrder { get; set; }


public int Entry93Id { get; set; }
public string Entry93Name { get; set; }
public string Entry93Description { get; set; }
public DateTime Entry93CreatedAt { get; set; }
public DateTime? Entry93UpdatedAt { get; set; }
public string Entry93CreatedBy { get; set; }
public bool IsEntry93Active { get; set; }
public int Entry93SortOrder { get; set; }


public int Detail54Id { get; set; }
public string Detail54Name { get; set; }
public string Detail54Description { get; set; }
public DateTime Detail54CreatedAt { get; set; }
public DateTime? Detail54UpdatedAt { get; set; }
public string Detail54CreatedBy { get; set; }
public bool IsDetail54Active { get; set; }
public int Detail54SortOrder { get; set; }


public int Field90Id { get; set; }
public string Field90Name { get; set; }
public string Field90Description { get; set; }
public DateTime Field90CreatedAt { get; set; }
public DateTime? Field90UpdatedAt { get; set; }
public string Field90CreatedBy { get; set; }
public bool IsField90Active { get; set; }
public int Field90SortOrder { get; set; }


public int Field56Id { get; set; }
public string Field56Name { get; set; }
public string Field56Description { get; set; }
public DateTime Field56CreatedAt { get; set; }
public DateTime? Field56UpdatedAt { get; set; }
public string Field56CreatedBy { get; set; }
public bool IsField56Active { get; set; }
public int Field56SortOrder { get; set; }


public int Entry60Id { get; set; }
public string Entry60Name { get; set; }
public string Entry60Description { get; set; }
public DateTime Entry60CreatedAt { get; set; }
public DateTime? Entry60UpdatedAt { get; set; }
public string Entry60CreatedBy { get; set; }
public bool IsEntry60Active { get; set; }
public int Entry60SortOrder { get; set; }


public int Param57Id { get; set; }
public string Param57Name { get; set; }
public string Param57Description { get; set; }
public DateTime Param57CreatedAt { get; set; }
public DateTime? Param57UpdatedAt { get; set; }
public string Param57CreatedBy { get; set; }
public bool IsParam57Active { get; set; }
public int Param57SortOrder { get; set; }


public int Item96Id { get; set; }
public string Item96Name { get; set; }
public string Item96Description { get; set; }
public DateTime Item96CreatedAt { get; set; }
public DateTime? Item96UpdatedAt { get; set; }
public string Item96CreatedBy { get; set; }
public bool IsItem96Active { get; set; }
public int Item96SortOrder { get; set; }


public int Record1Id { get; set; }
public string Record1Name { get; set; }
public string Record1Description { get; set; }
public DateTime Record1CreatedAt { get; set; }
public DateTime? Record1UpdatedAt { get; set; }
public string Record1CreatedBy { get; set; }
public bool IsRecord1Active { get; set; }
public int Record1SortOrder { get; set; }


public int Field36Id { get; set; }
public string Field36Name { get; set; }
public string Field36Description { get; set; }
public DateTime Field36CreatedAt { get; set; }
public DateTime? Field36UpdatedAt { get; set; }
public string Field36CreatedBy { get; set; }
public bool IsField36Active { get; set; }
public int Field36SortOrder { get; set; }


public int Param21Id { get; set; }
public string Param21Name { get; set; }
public string Param21Description { get; set; }
public DateTime Param21CreatedAt { get; set; }
public DateTime? Param21UpdatedAt { get; set; }
public string Param21CreatedBy { get; set; }
public bool IsParam21Active { get; set; }
public int Param21SortOrder { get; set; }


public int Entry5Id { get; set; }
public string Entry5Name { get; set; }
public string Entry5Description { get; set; }
public DateTime Entry5CreatedAt { get; set; }
public DateTime? Entry5UpdatedAt { get; set; }
public string Entry5CreatedBy { get; set; }
public bool IsEntry5Active { get; set; }
public int Entry5SortOrder { get; set; }


public int Config95Id { get; set; }
public string Config95Name { get; set; }
public string Config95Description { get; set; }
public DateTime Config95CreatedAt { get; set; }
public DateTime? Config95UpdatedAt { get; set; }
public string Config95CreatedBy { get; set; }
public bool IsConfig95Active { get; set; }
public int Config95SortOrder { get; set; }


public int Config81Id { get; set; }
public string Config81Name { get; set; }
public string Config81Description { get; set; }
public DateTime Config81CreatedAt { get; set; }
public DateTime? Config81UpdatedAt { get; set; }
public string Config81CreatedBy { get; set; }
public bool IsConfig81Active { get; set; }
public int Config81SortOrder { get; set; }


public int Param70Id { get; set; }
public string Param70Name { get; set; }
public string Param70Description { get; set; }
public DateTime Param70CreatedAt { get; set; }
public DateTime? Param70UpdatedAt { get; set; }
public string Param70CreatedBy { get; set; }
public bool IsParam70Active { get; set; }
public int Param70SortOrder { get; set; }


public int Config92Id { get; set; }
public string Config92Name { get; set; }
public string Config92Description { get; set; }
public DateTime Config92CreatedAt { get; set; }
public DateTime? Config92UpdatedAt { get; set; }
public string Config92CreatedBy { get; set; }
public bool IsConfig92Active { get; set; }
public int Config92SortOrder { get; set; }


public int Attr54Id { get; set; }
public string Attr54Name { get; set; }
public string Attr54Description { get; set; }
public DateTime Attr54CreatedAt { get; set; }
public DateTime? Attr54UpdatedAt { get; set; }
public string Attr54CreatedBy { get; set; }
public bool IsAttr54Active { get; set; }
public int Attr54SortOrder { get; set; }


public int Field81Id { get; set; }
public string Field81Name { get; set; }
public string Field81Description { get; set; }
public DateTime Field81CreatedAt { get; set; }
public DateTime? Field81UpdatedAt { get; set; }
public string Field81CreatedBy { get; set; }
public bool IsField81Active { get; set; }
public int Field81SortOrder { get; set; }


public int Item53Id { get; set; }
public string Item53Name { get; set; }
public string Item53Description { get; set; }
public DateTime Item53CreatedAt { get; set; }
public DateTime? Item53UpdatedAt { get; set; }
public string Item53CreatedBy { get; set; }
public bool IsItem53Active { get; set; }
public int Item53SortOrder { get; set; }


public int Attr74Id { get; set; }
public string Attr74Name { get; set; }
public string Attr74Description { get; set; }
public DateTime Attr74CreatedAt { get; set; }
public DateTime? Attr74UpdatedAt { get; set; }
public string Attr74CreatedBy { get; set; }
public bool IsAttr74Active { get; set; }
public int Attr74SortOrder { get; set; }


public int Config5Id { get; set; }
public string Config5Name { get; set; }
public string Config5Description { get; set; }
public DateTime Config5CreatedAt { get; set; }
public DateTime? Config5UpdatedAt { get; set; }
public string Config5CreatedBy { get; set; }
public bool IsConfig5Active { get; set; }
public int Config5SortOrder { get; set; }


public int Entry48Id { get; set; }
public string Entry48Name { get; set; }
public string Entry48Description { get; set; }
public DateTime Entry48CreatedAt { get; set; }
public DateTime? Entry48UpdatedAt { get; set; }
public string Entry48CreatedBy { get; set; }
public bool IsEntry48Active { get; set; }
public int Entry48SortOrder { get; set; }


public int Item46Id { get; set; }
public string Item46Name { get; set; }
public string Item46Description { get; set; }
public DateTime Item46CreatedAt { get; set; }
public DateTime? Item46UpdatedAt { get; set; }
public string Item46CreatedBy { get; set; }
public bool IsItem46Active { get; set; }
public int Item46SortOrder { get; set; }


public int Entry18Id { get; set; }
public string Entry18Name { get; set; }
public string Entry18Description { get; set; }
public DateTime Entry18CreatedAt { get; set; }
public DateTime? Entry18UpdatedAt { get; set; }
public string Entry18CreatedBy { get; set; }
public bool IsEntry18Active { get; set; }
public int Entry18SortOrder { get; set; }


public int Attr68Id { get; set; }
public string Attr68Name { get; set; }
public string Attr68Description { get; set; }
public DateTime Attr68CreatedAt { get; set; }
public DateTime? Attr68UpdatedAt { get; set; }
public string Attr68CreatedBy { get; set; }
public bool IsAttr68Active { get; set; }
public int Attr68SortOrder { get; set; }


public int Config95Id { get; set; }
public string Config95Name { get; set; }
public string Config95Description { get; set; }
public DateTime Config95CreatedAt { get; set; }
public DateTime? Config95UpdatedAt { get; set; }
public string Config95CreatedBy { get; set; }
public bool IsConfig95Active { get; set; }
public int Config95SortOrder { get; set; }


public int Detail12Id { get; set; }
public string Detail12Name { get; set; }
public string Detail12Description { get; set; }
public DateTime Detail12CreatedAt { get; set; }
public DateTime? Detail12UpdatedAt { get; set; }
public string Detail12CreatedBy { get; set; }
public bool IsDetail12Active { get; set; }
public int Detail12SortOrder { get; set; }


public int Param47Id { get; set; }
public string Param47Name { get; set; }
public string Param47Description { get; set; }
public DateTime Param47CreatedAt { get; set; }
public DateTime? Param47UpdatedAt { get; set; }
public string Param47CreatedBy { get; set; }
public bool IsParam47Active { get; set; }
public int Param47SortOrder { get; set; }


public int Field89Id { get; set; }
public string Field89Name { get; set; }
public string Field89Description { get; set; }
public DateTime Field89CreatedAt { get; set; }
public DateTime? Field89UpdatedAt { get; set; }
public string Field89CreatedBy { get; set; }
public bool IsField89Active { get; set; }
public int Field89SortOrder { get; set; }


public int Item94Id { get; set; }
public string Item94Name { get; set; }
public string Item94Description { get; set; }
public DateTime Item94CreatedAt { get; set; }
public DateTime? Item94UpdatedAt { get; set; }
public string Item94CreatedBy { get; set; }
public bool IsItem94Active { get; set; }
public int Item94SortOrder { get; set; }


public int Param25Id { get; set; }
public string Param25Name { get; set; }
public string Param25Description { get; set; }
public DateTime Param25CreatedAt { get; set; }
public DateTime? Param25UpdatedAt { get; set; }
public string Param25CreatedBy { get; set; }
public bool IsParam25Active { get; set; }
public int Param25SortOrder { get; set; }


public int Field43Id { get; set; }
public string Field43Name { get; set; }
public string Field43Description { get; set; }
public DateTime Field43CreatedAt { get; set; }
public DateTime? Field43UpdatedAt { get; set; }
public string Field43CreatedBy { get; set; }
public bool IsField43Active { get; set; }
public int Field43SortOrder { get; set; }


public int Record6Id { get; set; }
public string Record6Name { get; set; }
public string Record6Description { get; set; }
public DateTime Record6CreatedAt { get; set; }
public DateTime? Record6UpdatedAt { get; set; }
public string Record6CreatedBy { get; set; }
public bool IsRecord6Active { get; set; }
public int Record6SortOrder { get; set; }

    }
}