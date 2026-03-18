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
    public class Consumer1
    {
        private readonly Auth_Client38_Helper6 _auth_Client38_Helper6;
        private readonly Auth_Client38_Service1 _auth_Client38_Service1;
        private readonly Portal_Handlers26_Service7 _portal_Handlers26_Service7;
        private readonly Portal_Handlers26_Provider3 _portal_Handlers26_Provider3;
        private readonly IPortal_Handlers26_Factory4 _iPortal_Handlers26_Factory4;
        private readonly Integration_Tests_Builder1 _integration_Tests_Builder1;
        private readonly Integration_Tests_Result _integration_Tests_Result;
        private readonly Import_Api314_Options7 _import_Api314_Options7;

        public Consumer1(Auth_Client38_Helper6 auth_Client38_Helper6, Auth_Client38_Service1 auth_Client38_Service1, Portal_Handlers26_Service7 portal_Handlers26_Service7, Portal_Handlers26_Provider3 portal_Handlers26_Provider3, IPortal_Handlers26_Factory4 iPortal_Handlers26_Factory4, Integration_Tests_Builder1 integration_Tests_Builder1, Integration_Tests_Result integration_Tests_Result, Import_Api314_Options7 import_Api314_Options7)
        {
            _auth_Client38_Helper6 = auth_Client38_Helper6 ?? throw new ArgumentNullException(nameof(auth_Client38_Helper6));
            _auth_Client38_Service1 = auth_Client38_Service1 ?? throw new ArgumentNullException(nameof(auth_Client38_Service1));
            _portal_Handlers26_Service7 = portal_Handlers26_Service7 ?? throw new ArgumentNullException(nameof(portal_Handlers26_Service7));
            _portal_Handlers26_Provider3 = portal_Handlers26_Provider3 ?? throw new ArgumentNullException(nameof(portal_Handlers26_Provider3));
            _iPortal_Handlers26_Factory4 = iPortal_Handlers26_Factory4 ?? throw new ArgumentNullException(nameof(iPortal_Handlers26_Factory4));
            _integration_Tests_Builder1 = integration_Tests_Builder1 ?? throw new ArgumentNullException(nameof(integration_Tests_Builder1));
            _integration_Tests_Result = integration_Tests_Result ?? throw new ArgumentNullException(nameof(integration_Tests_Result));
            _import_Api314_Options7 = import_Api314_Options7 ?? throw new ArgumentNullException(nameof(import_Api314_Options7));
        }

        public Auth_Client38_Helper6 GetAuth_Client38_Helper6() => _auth_Client38_Helper6;
        public Auth_Client38_Service1 GetAuth_Client38_Service1() => _auth_Client38_Service1;
        public Portal_Handlers26_Service7 GetPortal_Handlers26_Service7() => _portal_Handlers26_Service7;
        public Portal_Handlers26_Provider3 GetPortal_Handlers26_Provider3() => _portal_Handlers26_Provider3;
        public IPortal_Handlers26_Factory4 GetIPortal_Handlers26_Factory4() => _iPortal_Handlers26_Factory4;
        public Integration_Tests_Builder1 GetIntegration_Tests_Builder1() => _integration_Tests_Builder1;
        public Integration_Tests_Result GetIntegration_Tests_Result() => _integration_Tests_Result;
        public Import_Api314_Options7 GetImport_Api314_Options7() => _import_Api314_Options7;

/// <summary>
/// Validates the Consumer1 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer1(Consumer1Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer1));
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
/// Processes the Consumer1 operation asynchronously.
/// </summary>
public async Task<Consumer1Result> ProcessConsumer1Async(
    Consumer1Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer1), request.Id);

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
            return new Consumer1Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer1));
        return new Consumer1Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer1));
        return new Consumer1Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer1 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer1Dto>> GetConsumer1ListAsync(
    Consumer1Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer1Entity>().AsQueryable();

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
        .Select(x => new Consumer1Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer1Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer1Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer1Service(
    ILogger<Consumer1Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer1:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer1 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer1Data> GetCachedConsumer1Async(string key)
{
    var cacheKey = $"Consumer1_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer1Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer1SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Item53Id { get; set; }
public string Item53Name { get; set; }
public string Item53Description { get; set; }
public DateTime Item53CreatedAt { get; set; }
public DateTime? Item53UpdatedAt { get; set; }
public string Item53CreatedBy { get; set; }
public bool IsItem53Active { get; set; }
public int Item53SortOrder { get; set; }


public int Field34Id { get; set; }
public string Field34Name { get; set; }
public string Field34Description { get; set; }
public DateTime Field34CreatedAt { get; set; }
public DateTime? Field34UpdatedAt { get; set; }
public string Field34CreatedBy { get; set; }
public bool IsField34Active { get; set; }
public int Field34SortOrder { get; set; }


public int Field33Id { get; set; }
public string Field33Name { get; set; }
public string Field33Description { get; set; }
public DateTime Field33CreatedAt { get; set; }
public DateTime? Field33UpdatedAt { get; set; }
public string Field33CreatedBy { get; set; }
public bool IsField33Active { get; set; }
public int Field33SortOrder { get; set; }


public int Config47Id { get; set; }
public string Config47Name { get; set; }
public string Config47Description { get; set; }
public DateTime Config47CreatedAt { get; set; }
public DateTime? Config47UpdatedAt { get; set; }
public string Config47CreatedBy { get; set; }
public bool IsConfig47Active { get; set; }
public int Config47SortOrder { get; set; }


public int Config98Id { get; set; }
public string Config98Name { get; set; }
public string Config98Description { get; set; }
public DateTime Config98CreatedAt { get; set; }
public DateTime? Config98UpdatedAt { get; set; }
public string Config98CreatedBy { get; set; }
public bool IsConfig98Active { get; set; }
public int Config98SortOrder { get; set; }


public int Attr48Id { get; set; }
public string Attr48Name { get; set; }
public string Attr48Description { get; set; }
public DateTime Attr48CreatedAt { get; set; }
public DateTime? Attr48UpdatedAt { get; set; }
public string Attr48CreatedBy { get; set; }
public bool IsAttr48Active { get; set; }
public int Attr48SortOrder { get; set; }


public int Attr35Id { get; set; }
public string Attr35Name { get; set; }
public string Attr35Description { get; set; }
public DateTime Attr35CreatedAt { get; set; }
public DateTime? Attr35UpdatedAt { get; set; }
public string Attr35CreatedBy { get; set; }
public bool IsAttr35Active { get; set; }
public int Attr35SortOrder { get; set; }


public int Param54Id { get; set; }
public string Param54Name { get; set; }
public string Param54Description { get; set; }
public DateTime Param54CreatedAt { get; set; }
public DateTime? Param54UpdatedAt { get; set; }
public string Param54CreatedBy { get; set; }
public bool IsParam54Active { get; set; }
public int Param54SortOrder { get; set; }


public int Attr11Id { get; set; }
public string Attr11Name { get; set; }
public string Attr11Description { get; set; }
public DateTime Attr11CreatedAt { get; set; }
public DateTime? Attr11UpdatedAt { get; set; }
public string Attr11CreatedBy { get; set; }
public bool IsAttr11Active { get; set; }
public int Attr11SortOrder { get; set; }


public int Entry17Id { get; set; }
public string Entry17Name { get; set; }
public string Entry17Description { get; set; }
public DateTime Entry17CreatedAt { get; set; }
public DateTime? Entry17UpdatedAt { get; set; }
public string Entry17CreatedBy { get; set; }
public bool IsEntry17Active { get; set; }
public int Entry17SortOrder { get; set; }


public int Param19Id { get; set; }
public string Param19Name { get; set; }
public string Param19Description { get; set; }
public DateTime Param19CreatedAt { get; set; }
public DateTime? Param19UpdatedAt { get; set; }
public string Param19CreatedBy { get; set; }
public bool IsParam19Active { get; set; }
public int Param19SortOrder { get; set; }


public int Detail85Id { get; set; }
public string Detail85Name { get; set; }
public string Detail85Description { get; set; }
public DateTime Detail85CreatedAt { get; set; }
public DateTime? Detail85UpdatedAt { get; set; }
public string Detail85CreatedBy { get; set; }
public bool IsDetail85Active { get; set; }
public int Detail85SortOrder { get; set; }


public int Detail50Id { get; set; }
public string Detail50Name { get; set; }
public string Detail50Description { get; set; }
public DateTime Detail50CreatedAt { get; set; }
public DateTime? Detail50UpdatedAt { get; set; }
public string Detail50CreatedBy { get; set; }
public bool IsDetail50Active { get; set; }
public int Detail50SortOrder { get; set; }


public int Config83Id { get; set; }
public string Config83Name { get; set; }
public string Config83Description { get; set; }
public DateTime Config83CreatedAt { get; set; }
public DateTime? Config83UpdatedAt { get; set; }
public string Config83CreatedBy { get; set; }
public bool IsConfig83Active { get; set; }
public int Config83SortOrder { get; set; }


public int Attr84Id { get; set; }
public string Attr84Name { get; set; }
public string Attr84Description { get; set; }
public DateTime Attr84CreatedAt { get; set; }
public DateTime? Attr84UpdatedAt { get; set; }
public string Attr84CreatedBy { get; set; }
public bool IsAttr84Active { get; set; }
public int Attr84SortOrder { get; set; }


public int Entry50Id { get; set; }
public string Entry50Name { get; set; }
public string Entry50Description { get; set; }
public DateTime Entry50CreatedAt { get; set; }
public DateTime? Entry50UpdatedAt { get; set; }
public string Entry50CreatedBy { get; set; }
public bool IsEntry50Active { get; set; }
public int Entry50SortOrder { get; set; }


public int Param13Id { get; set; }
public string Param13Name { get; set; }
public string Param13Description { get; set; }
public DateTime Param13CreatedAt { get; set; }
public DateTime? Param13UpdatedAt { get; set; }
public string Param13CreatedBy { get; set; }
public bool IsParam13Active { get; set; }
public int Param13SortOrder { get; set; }


public int Param71Id { get; set; }
public string Param71Name { get; set; }
public string Param71Description { get; set; }
public DateTime Param71CreatedAt { get; set; }
public DateTime? Param71UpdatedAt { get; set; }
public string Param71CreatedBy { get; set; }
public bool IsParam71Active { get; set; }
public int Param71SortOrder { get; set; }


public int Attr54Id { get; set; }
public string Attr54Name { get; set; }
public string Attr54Description { get; set; }
public DateTime Attr54CreatedAt { get; set; }
public DateTime? Attr54UpdatedAt { get; set; }
public string Attr54CreatedBy { get; set; }
public bool IsAttr54Active { get; set; }
public int Attr54SortOrder { get; set; }


public int Entry46Id { get; set; }
public string Entry46Name { get; set; }
public string Entry46Description { get; set; }
public DateTime Entry46CreatedAt { get; set; }
public DateTime? Entry46UpdatedAt { get; set; }
public string Entry46CreatedBy { get; set; }
public bool IsEntry46Active { get; set; }
public int Entry46SortOrder { get; set; }


public int Field31Id { get; set; }
public string Field31Name { get; set; }
public string Field31Description { get; set; }
public DateTime Field31CreatedAt { get; set; }
public DateTime? Field31UpdatedAt { get; set; }
public string Field31CreatedBy { get; set; }
public bool IsField31Active { get; set; }
public int Field31SortOrder { get; set; }


public int Param8Id { get; set; }
public string Param8Name { get; set; }
public string Param8Description { get; set; }
public DateTime Param8CreatedAt { get; set; }
public DateTime? Param8UpdatedAt { get; set; }
public string Param8CreatedBy { get; set; }
public bool IsParam8Active { get; set; }
public int Param8SortOrder { get; set; }


public int Param85Id { get; set; }
public string Param85Name { get; set; }
public string Param85Description { get; set; }
public DateTime Param85CreatedAt { get; set; }
public DateTime? Param85UpdatedAt { get; set; }
public string Param85CreatedBy { get; set; }
public bool IsParam85Active { get; set; }
public int Param85SortOrder { get; set; }


public int Param34Id { get; set; }
public string Param34Name { get; set; }
public string Param34Description { get; set; }
public DateTime Param34CreatedAt { get; set; }
public DateTime? Param34UpdatedAt { get; set; }
public string Param34CreatedBy { get; set; }
public bool IsParam34Active { get; set; }
public int Param34SortOrder { get; set; }


public int Entry61Id { get; set; }
public string Entry61Name { get; set; }
public string Entry61Description { get; set; }
public DateTime Entry61CreatedAt { get; set; }
public DateTime? Entry61UpdatedAt { get; set; }
public string Entry61CreatedBy { get; set; }
public bool IsEntry61Active { get; set; }
public int Entry61SortOrder { get; set; }


public int Detail57Id { get; set; }
public string Detail57Name { get; set; }
public string Detail57Description { get; set; }
public DateTime Detail57CreatedAt { get; set; }
public DateTime? Detail57UpdatedAt { get; set; }
public string Detail57CreatedBy { get; set; }
public bool IsDetail57Active { get; set; }
public int Detail57SortOrder { get; set; }


public int Attr80Id { get; set; }
public string Attr80Name { get; set; }
public string Attr80Description { get; set; }
public DateTime Attr80CreatedAt { get; set; }
public DateTime? Attr80UpdatedAt { get; set; }
public string Attr80CreatedBy { get; set; }
public bool IsAttr80Active { get; set; }
public int Attr80SortOrder { get; set; }


public int Param90Id { get; set; }
public string Param90Name { get; set; }
public string Param90Description { get; set; }
public DateTime Param90CreatedAt { get; set; }
public DateTime? Param90UpdatedAt { get; set; }
public string Param90CreatedBy { get; set; }
public bool IsParam90Active { get; set; }
public int Param90SortOrder { get; set; }


public int Item24Id { get; set; }
public string Item24Name { get; set; }
public string Item24Description { get; set; }
public DateTime Item24CreatedAt { get; set; }
public DateTime? Item24UpdatedAt { get; set; }
public string Item24CreatedBy { get; set; }
public bool IsItem24Active { get; set; }
public int Item24SortOrder { get; set; }


public int Record72Id { get; set; }
public string Record72Name { get; set; }
public string Record72Description { get; set; }
public DateTime Record72CreatedAt { get; set; }
public DateTime? Record72UpdatedAt { get; set; }
public string Record72CreatedBy { get; set; }
public bool IsRecord72Active { get; set; }
public int Record72SortOrder { get; set; }


public int Param53Id { get; set; }
public string Param53Name { get; set; }
public string Param53Description { get; set; }
public DateTime Param53CreatedAt { get; set; }
public DateTime? Param53UpdatedAt { get; set; }
public string Param53CreatedBy { get; set; }
public bool IsParam53Active { get; set; }
public int Param53SortOrder { get; set; }


public int Param56Id { get; set; }
public string Param56Name { get; set; }
public string Param56Description { get; set; }
public DateTime Param56CreatedAt { get; set; }
public DateTime? Param56UpdatedAt { get; set; }
public string Param56CreatedBy { get; set; }
public bool IsParam56Active { get; set; }
public int Param56SortOrder { get; set; }


public int Record13Id { get; set; }
public string Record13Name { get; set; }
public string Record13Description { get; set; }
public DateTime Record13CreatedAt { get; set; }
public DateTime? Record13UpdatedAt { get; set; }
public string Record13CreatedBy { get; set; }
public bool IsRecord13Active { get; set; }
public int Record13SortOrder { get; set; }


public int Item34Id { get; set; }
public string Item34Name { get; set; }
public string Item34Description { get; set; }
public DateTime Item34CreatedAt { get; set; }
public DateTime? Item34UpdatedAt { get; set; }
public string Item34CreatedBy { get; set; }
public bool IsItem34Active { get; set; }
public int Item34SortOrder { get; set; }


public int Record92Id { get; set; }
public string Record92Name { get; set; }
public string Record92Description { get; set; }
public DateTime Record92CreatedAt { get; set; }
public DateTime? Record92UpdatedAt { get; set; }
public string Record92CreatedBy { get; set; }
public bool IsRecord92Active { get; set; }
public int Record92SortOrder { get; set; }


public int Record89Id { get; set; }
public string Record89Name { get; set; }
public string Record89Description { get; set; }
public DateTime Record89CreatedAt { get; set; }
public DateTime? Record89UpdatedAt { get; set; }
public string Record89CreatedBy { get; set; }
public bool IsRecord89Active { get; set; }
public int Record89SortOrder { get; set; }


public int Param1Id { get; set; }
public string Param1Name { get; set; }
public string Param1Description { get; set; }
public DateTime Param1CreatedAt { get; set; }
public DateTime? Param1UpdatedAt { get; set; }
public string Param1CreatedBy { get; set; }
public bool IsParam1Active { get; set; }
public int Param1SortOrder { get; set; }


public int Param37Id { get; set; }
public string Param37Name { get; set; }
public string Param37Description { get; set; }
public DateTime Param37CreatedAt { get; set; }
public DateTime? Param37UpdatedAt { get; set; }
public string Param37CreatedBy { get; set; }
public bool IsParam37Active { get; set; }
public int Param37SortOrder { get; set; }


public int Item5Id { get; set; }
public string Item5Name { get; set; }
public string Item5Description { get; set; }
public DateTime Item5CreatedAt { get; set; }
public DateTime? Item5UpdatedAt { get; set; }
public string Item5CreatedBy { get; set; }
public bool IsItem5Active { get; set; }
public int Item5SortOrder { get; set; }


public int Param99Id { get; set; }
public string Param99Name { get; set; }
public string Param99Description { get; set; }
public DateTime Param99CreatedAt { get; set; }
public DateTime? Param99UpdatedAt { get; set; }
public string Param99CreatedBy { get; set; }
public bool IsParam99Active { get; set; }
public int Param99SortOrder { get; set; }


public int Item60Id { get; set; }
public string Item60Name { get; set; }
public string Item60Description { get; set; }
public DateTime Item60CreatedAt { get; set; }
public DateTime? Item60UpdatedAt { get; set; }
public string Item60CreatedBy { get; set; }
public bool IsItem60Active { get; set; }
public int Item60SortOrder { get; set; }


public int Field68Id { get; set; }
public string Field68Name { get; set; }
public string Field68Description { get; set; }
public DateTime Field68CreatedAt { get; set; }
public DateTime? Field68UpdatedAt { get; set; }
public string Field68CreatedBy { get; set; }
public bool IsField68Active { get; set; }
public int Field68SortOrder { get; set; }


public int Record26Id { get; set; }
public string Record26Name { get; set; }
public string Record26Description { get; set; }
public DateTime Record26CreatedAt { get; set; }
public DateTime? Record26UpdatedAt { get; set; }
public string Record26CreatedBy { get; set; }
public bool IsRecord26Active { get; set; }
public int Record26SortOrder { get; set; }


public int Attr30Id { get; set; }
public string Attr30Name { get; set; }
public string Attr30Description { get; set; }
public DateTime Attr30CreatedAt { get; set; }
public DateTime? Attr30UpdatedAt { get; set; }
public string Attr30CreatedBy { get; set; }
public bool IsAttr30Active { get; set; }
public int Attr30SortOrder { get; set; }


public int Config38Id { get; set; }
public string Config38Name { get; set; }
public string Config38Description { get; set; }
public DateTime Config38CreatedAt { get; set; }
public DateTime? Config38UpdatedAt { get; set; }
public string Config38CreatedBy { get; set; }
public bool IsConfig38Active { get; set; }
public int Config38SortOrder { get; set; }


public int Field81Id { get; set; }
public string Field81Name { get; set; }
public string Field81Description { get; set; }
public DateTime Field81CreatedAt { get; set; }
public DateTime? Field81UpdatedAt { get; set; }
public string Field81CreatedBy { get; set; }
public bool IsField81Active { get; set; }
public int Field81SortOrder { get; set; }

    }
}