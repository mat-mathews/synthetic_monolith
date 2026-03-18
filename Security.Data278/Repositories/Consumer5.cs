using Admin.Web;
using Auth.Contracts395;
using Auth.Core;
using BatchJobs.Api212;
using Billing.Shared;
using Common.Service;
using DataAccess.Core;
using Export.Models461;
using GalaxyWorks.Processors;
using Imaging.Contracts;
using Imaging.Contracts89;
using Import.Contracts131;
using Integration.Mappers;
using Integration.Processors71;
using Notifications.Api144;
using Scheduling.Models;
using Security.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Mappers;

namespace Security.Data278
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer5
    {
        private readonly Admin_Web_Info4 _admin_Web_Info4;
        private readonly Admin_Web_Response2 _admin_Web_Response2;
        private readonly IAuth_Contracts395_Validator14 _iAuth_Contracts395_Validator14;
        private readonly IAuth_Core_Validator7 _iAuth_Core_Validator7;
        private readonly Auth_Core_Processor8 _auth_Core_Processor8;
        private readonly IGalaxyWorks_Processors_Service5 _iGalaxyWorks_Processors_Service5;
        private readonly ISecurity_Api_Provider _iSecurity_Api_Provider;
        private readonly ISecurity_Api_Factory4 _iSecurity_Api_Factory4;

        public Consumer5(Admin_Web_Info4 admin_Web_Info4, Admin_Web_Response2 admin_Web_Response2, IAuth_Contracts395_Validator14 iAuth_Contracts395_Validator14, IAuth_Core_Validator7 iAuth_Core_Validator7, Auth_Core_Processor8 auth_Core_Processor8, IGalaxyWorks_Processors_Service5 iGalaxyWorks_Processors_Service5, ISecurity_Api_Provider iSecurity_Api_Provider, ISecurity_Api_Factory4 iSecurity_Api_Factory4)
        {
            _admin_Web_Info4 = admin_Web_Info4 ?? throw new ArgumentNullException(nameof(admin_Web_Info4));
            _admin_Web_Response2 = admin_Web_Response2 ?? throw new ArgumentNullException(nameof(admin_Web_Response2));
            _iAuth_Contracts395_Validator14 = iAuth_Contracts395_Validator14 ?? throw new ArgumentNullException(nameof(iAuth_Contracts395_Validator14));
            _iAuth_Core_Validator7 = iAuth_Core_Validator7 ?? throw new ArgumentNullException(nameof(iAuth_Core_Validator7));
            _auth_Core_Processor8 = auth_Core_Processor8 ?? throw new ArgumentNullException(nameof(auth_Core_Processor8));
            _iGalaxyWorks_Processors_Service5 = iGalaxyWorks_Processors_Service5 ?? throw new ArgumentNullException(nameof(iGalaxyWorks_Processors_Service5));
            _iSecurity_Api_Provider = iSecurity_Api_Provider ?? throw new ArgumentNullException(nameof(iSecurity_Api_Provider));
            _iSecurity_Api_Factory4 = iSecurity_Api_Factory4 ?? throw new ArgumentNullException(nameof(iSecurity_Api_Factory4));
        }

        public Admin_Web_Info4 GetAdmin_Web_Info4() => _admin_Web_Info4;
        public Admin_Web_Response2 GetAdmin_Web_Response2() => _admin_Web_Response2;
        public IAuth_Contracts395_Validator14 GetIAuth_Contracts395_Validator14() => _iAuth_Contracts395_Validator14;
        public IAuth_Core_Validator7 GetIAuth_Core_Validator7() => _iAuth_Core_Validator7;
        public Auth_Core_Processor8 GetAuth_Core_Processor8() => _auth_Core_Processor8;
        public IGalaxyWorks_Processors_Service5 GetIGalaxyWorks_Processors_Service5() => _iGalaxyWorks_Processors_Service5;
        public ISecurity_Api_Provider GetISecurity_Api_Provider() => _iSecurity_Api_Provider;
        public ISecurity_Api_Factory4 GetISecurity_Api_Factory4() => _iSecurity_Api_Factory4;

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

public int Record41Id { get; set; }
public string Record41Name { get; set; }
public string Record41Description { get; set; }
public DateTime Record41CreatedAt { get; set; }
public DateTime? Record41UpdatedAt { get; set; }
public string Record41CreatedBy { get; set; }
public bool IsRecord41Active { get; set; }
public int Record41SortOrder { get; set; }


public int Detail15Id { get; set; }
public string Detail15Name { get; set; }
public string Detail15Description { get; set; }
public DateTime Detail15CreatedAt { get; set; }
public DateTime? Detail15UpdatedAt { get; set; }
public string Detail15CreatedBy { get; set; }
public bool IsDetail15Active { get; set; }
public int Detail15SortOrder { get; set; }


public int Field8Id { get; set; }
public string Field8Name { get; set; }
public string Field8Description { get; set; }
public DateTime Field8CreatedAt { get; set; }
public DateTime? Field8UpdatedAt { get; set; }
public string Field8CreatedBy { get; set; }
public bool IsField8Active { get; set; }
public int Field8SortOrder { get; set; }


public int Entry21Id { get; set; }
public string Entry21Name { get; set; }
public string Entry21Description { get; set; }
public DateTime Entry21CreatedAt { get; set; }
public DateTime? Entry21UpdatedAt { get; set; }
public string Entry21CreatedBy { get; set; }
public bool IsEntry21Active { get; set; }
public int Entry21SortOrder { get; set; }


public int Config90Id { get; set; }
public string Config90Name { get; set; }
public string Config90Description { get; set; }
public DateTime Config90CreatedAt { get; set; }
public DateTime? Config90UpdatedAt { get; set; }
public string Config90CreatedBy { get; set; }
public bool IsConfig90Active { get; set; }
public int Config90SortOrder { get; set; }


public int Config34Id { get; set; }
public string Config34Name { get; set; }
public string Config34Description { get; set; }
public DateTime Config34CreatedAt { get; set; }
public DateTime? Config34UpdatedAt { get; set; }
public string Config34CreatedBy { get; set; }
public bool IsConfig34Active { get; set; }
public int Config34SortOrder { get; set; }


public int Field19Id { get; set; }
public string Field19Name { get; set; }
public string Field19Description { get; set; }
public DateTime Field19CreatedAt { get; set; }
public DateTime? Field19UpdatedAt { get; set; }
public string Field19CreatedBy { get; set; }
public bool IsField19Active { get; set; }
public int Field19SortOrder { get; set; }


public int Item58Id { get; set; }
public string Item58Name { get; set; }
public string Item58Description { get; set; }
public DateTime Item58CreatedAt { get; set; }
public DateTime? Item58UpdatedAt { get; set; }
public string Item58CreatedBy { get; set; }
public bool IsItem58Active { get; set; }
public int Item58SortOrder { get; set; }


public int Field41Id { get; set; }
public string Field41Name { get; set; }
public string Field41Description { get; set; }
public DateTime Field41CreatedAt { get; set; }
public DateTime? Field41UpdatedAt { get; set; }
public string Field41CreatedBy { get; set; }
public bool IsField41Active { get; set; }
public int Field41SortOrder { get; set; }


public int Attr61Id { get; set; }
public string Attr61Name { get; set; }
public string Attr61Description { get; set; }
public DateTime Attr61CreatedAt { get; set; }
public DateTime? Attr61UpdatedAt { get; set; }
public string Attr61CreatedBy { get; set; }
public bool IsAttr61Active { get; set; }
public int Attr61SortOrder { get; set; }


public int Attr80Id { get; set; }
public string Attr80Name { get; set; }
public string Attr80Description { get; set; }
public DateTime Attr80CreatedAt { get; set; }
public DateTime? Attr80UpdatedAt { get; set; }
public string Attr80CreatedBy { get; set; }
public bool IsAttr80Active { get; set; }
public int Attr80SortOrder { get; set; }


public int Record21Id { get; set; }
public string Record21Name { get; set; }
public string Record21Description { get; set; }
public DateTime Record21CreatedAt { get; set; }
public DateTime? Record21UpdatedAt { get; set; }
public string Record21CreatedBy { get; set; }
public bool IsRecord21Active { get; set; }
public int Record21SortOrder { get; set; }


public int Field99Id { get; set; }
public string Field99Name { get; set; }
public string Field99Description { get; set; }
public DateTime Field99CreatedAt { get; set; }
public DateTime? Field99UpdatedAt { get; set; }
public string Field99CreatedBy { get; set; }
public bool IsField99Active { get; set; }
public int Field99SortOrder { get; set; }


public int Item58Id { get; set; }
public string Item58Name { get; set; }
public string Item58Description { get; set; }
public DateTime Item58CreatedAt { get; set; }
public DateTime? Item58UpdatedAt { get; set; }
public string Item58CreatedBy { get; set; }
public bool IsItem58Active { get; set; }
public int Item58SortOrder { get; set; }


public int Config77Id { get; set; }
public string Config77Name { get; set; }
public string Config77Description { get; set; }
public DateTime Config77CreatedAt { get; set; }
public DateTime? Config77UpdatedAt { get; set; }
public string Config77CreatedBy { get; set; }
public bool IsConfig77Active { get; set; }
public int Config77SortOrder { get; set; }


public int Field72Id { get; set; }
public string Field72Name { get; set; }
public string Field72Description { get; set; }
public DateTime Field72CreatedAt { get; set; }
public DateTime? Field72UpdatedAt { get; set; }
public string Field72CreatedBy { get; set; }
public bool IsField72Active { get; set; }
public int Field72SortOrder { get; set; }


public int Attr82Id { get; set; }
public string Attr82Name { get; set; }
public string Attr82Description { get; set; }
public DateTime Attr82CreatedAt { get; set; }
public DateTime? Attr82UpdatedAt { get; set; }
public string Attr82CreatedBy { get; set; }
public bool IsAttr82Active { get; set; }
public int Attr82SortOrder { get; set; }


public int Record8Id { get; set; }
public string Record8Name { get; set; }
public string Record8Description { get; set; }
public DateTime Record8CreatedAt { get; set; }
public DateTime? Record8UpdatedAt { get; set; }
public string Record8CreatedBy { get; set; }
public bool IsRecord8Active { get; set; }
public int Record8SortOrder { get; set; }


public int Item8Id { get; set; }
public string Item8Name { get; set; }
public string Item8Description { get; set; }
public DateTime Item8CreatedAt { get; set; }
public DateTime? Item8UpdatedAt { get; set; }
public string Item8CreatedBy { get; set; }
public bool IsItem8Active { get; set; }
public int Item8SortOrder { get; set; }


public int Field15Id { get; set; }
public string Field15Name { get; set; }
public string Field15Description { get; set; }
public DateTime Field15CreatedAt { get; set; }
public DateTime? Field15UpdatedAt { get; set; }
public string Field15CreatedBy { get; set; }
public bool IsField15Active { get; set; }
public int Field15SortOrder { get; set; }


public int Item53Id { get; set; }
public string Item53Name { get; set; }
public string Item53Description { get; set; }
public DateTime Item53CreatedAt { get; set; }
public DateTime? Item53UpdatedAt { get; set; }
public string Item53CreatedBy { get; set; }
public bool IsItem53Active { get; set; }
public int Item53SortOrder { get; set; }


public int Entry2Id { get; set; }
public string Entry2Name { get; set; }
public string Entry2Description { get; set; }
public DateTime Entry2CreatedAt { get; set; }
public DateTime? Entry2UpdatedAt { get; set; }
public string Entry2CreatedBy { get; set; }
public bool IsEntry2Active { get; set; }
public int Entry2SortOrder { get; set; }


public int Config92Id { get; set; }
public string Config92Name { get; set; }
public string Config92Description { get; set; }
public DateTime Config92CreatedAt { get; set; }
public DateTime? Config92UpdatedAt { get; set; }
public string Config92CreatedBy { get; set; }
public bool IsConfig92Active { get; set; }
public int Config92SortOrder { get; set; }


public int Item38Id { get; set; }
public string Item38Name { get; set; }
public string Item38Description { get; set; }
public DateTime Item38CreatedAt { get; set; }
public DateTime? Item38UpdatedAt { get; set; }
public string Item38CreatedBy { get; set; }
public bool IsItem38Active { get; set; }
public int Item38SortOrder { get; set; }


public int Field24Id { get; set; }
public string Field24Name { get; set; }
public string Field24Description { get; set; }
public DateTime Field24CreatedAt { get; set; }
public DateTime? Field24UpdatedAt { get; set; }
public string Field24CreatedBy { get; set; }
public bool IsField24Active { get; set; }
public int Field24SortOrder { get; set; }


public int Entry16Id { get; set; }
public string Entry16Name { get; set; }
public string Entry16Description { get; set; }
public DateTime Entry16CreatedAt { get; set; }
public DateTime? Entry16UpdatedAt { get; set; }
public string Entry16CreatedBy { get; set; }
public bool IsEntry16Active { get; set; }
public int Entry16SortOrder { get; set; }


public int Field34Id { get; set; }
public string Field34Name { get; set; }
public string Field34Description { get; set; }
public DateTime Field34CreatedAt { get; set; }
public DateTime? Field34UpdatedAt { get; set; }
public string Field34CreatedBy { get; set; }
public bool IsField34Active { get; set; }
public int Field34SortOrder { get; set; }


public int Item24Id { get; set; }
public string Item24Name { get; set; }
public string Item24Description { get; set; }
public DateTime Item24CreatedAt { get; set; }
public DateTime? Item24UpdatedAt { get; set; }
public string Item24CreatedBy { get; set; }
public bool IsItem24Active { get; set; }
public int Item24SortOrder { get; set; }


public int Entry87Id { get; set; }
public string Entry87Name { get; set; }
public string Entry87Description { get; set; }
public DateTime Entry87CreatedAt { get; set; }
public DateTime? Entry87UpdatedAt { get; set; }
public string Entry87CreatedBy { get; set; }
public bool IsEntry87Active { get; set; }
public int Entry87SortOrder { get; set; }


public int Detail28Id { get; set; }
public string Detail28Name { get; set; }
public string Detail28Description { get; set; }
public DateTime Detail28CreatedAt { get; set; }
public DateTime? Detail28UpdatedAt { get; set; }
public string Detail28CreatedBy { get; set; }
public bool IsDetail28Active { get; set; }
public int Detail28SortOrder { get; set; }


public int Config45Id { get; set; }
public string Config45Name { get; set; }
public string Config45Description { get; set; }
public DateTime Config45CreatedAt { get; set; }
public DateTime? Config45UpdatedAt { get; set; }
public string Config45CreatedBy { get; set; }
public bool IsConfig45Active { get; set; }
public int Config45SortOrder { get; set; }


public int Param31Id { get; set; }
public string Param31Name { get; set; }
public string Param31Description { get; set; }
public DateTime Param31CreatedAt { get; set; }
public DateTime? Param31UpdatedAt { get; set; }
public string Param31CreatedBy { get; set; }
public bool IsParam31Active { get; set; }
public int Param31SortOrder { get; set; }


public int Record28Id { get; set; }
public string Record28Name { get; set; }
public string Record28Description { get; set; }
public DateTime Record28CreatedAt { get; set; }
public DateTime? Record28UpdatedAt { get; set; }
public string Record28CreatedBy { get; set; }
public bool IsRecord28Active { get; set; }
public int Record28SortOrder { get; set; }


public int Entry81Id { get; set; }
public string Entry81Name { get; set; }
public string Entry81Description { get; set; }
public DateTime Entry81CreatedAt { get; set; }
public DateTime? Entry81UpdatedAt { get; set; }
public string Entry81CreatedBy { get; set; }
public bool IsEntry81Active { get; set; }
public int Entry81SortOrder { get; set; }


public int Detail43Id { get; set; }
public string Detail43Name { get; set; }
public string Detail43Description { get; set; }
public DateTime Detail43CreatedAt { get; set; }
public DateTime? Detail43UpdatedAt { get; set; }
public string Detail43CreatedBy { get; set; }
public bool IsDetail43Active { get; set; }
public int Detail43SortOrder { get; set; }


public int Field28Id { get; set; }
public string Field28Name { get; set; }
public string Field28Description { get; set; }
public DateTime Field28CreatedAt { get; set; }
public DateTime? Field28UpdatedAt { get; set; }
public string Field28CreatedBy { get; set; }
public bool IsField28Active { get; set; }
public int Field28SortOrder { get; set; }


public int Detail12Id { get; set; }
public string Detail12Name { get; set; }
public string Detail12Description { get; set; }
public DateTime Detail12CreatedAt { get; set; }
public DateTime? Detail12UpdatedAt { get; set; }
public string Detail12CreatedBy { get; set; }
public bool IsDetail12Active { get; set; }
public int Detail12SortOrder { get; set; }


public int Record81Id { get; set; }
public string Record81Name { get; set; }
public string Record81Description { get; set; }
public DateTime Record81CreatedAt { get; set; }
public DateTime? Record81UpdatedAt { get; set; }
public string Record81CreatedBy { get; set; }
public bool IsRecord81Active { get; set; }
public int Record81SortOrder { get; set; }


public int Param78Id { get; set; }
public string Param78Name { get; set; }
public string Param78Description { get; set; }
public DateTime Param78CreatedAt { get; set; }
public DateTime? Param78UpdatedAt { get; set; }
public string Param78CreatedBy { get; set; }
public bool IsParam78Active { get; set; }
public int Param78SortOrder { get; set; }


public int Detail40Id { get; set; }
public string Detail40Name { get; set; }
public string Detail40Description { get; set; }
public DateTime Detail40CreatedAt { get; set; }
public DateTime? Detail40UpdatedAt { get; set; }
public string Detail40CreatedBy { get; set; }
public bool IsDetail40Active { get; set; }
public int Detail40SortOrder { get; set; }


public int Entry99Id { get; set; }
public string Entry99Name { get; set; }
public string Entry99Description { get; set; }
public DateTime Entry99CreatedAt { get; set; }
public DateTime? Entry99UpdatedAt { get; set; }
public string Entry99CreatedBy { get; set; }
public bool IsEntry99Active { get; set; }
public int Entry99SortOrder { get; set; }


public int Config7Id { get; set; }
public string Config7Name { get; set; }
public string Config7Description { get; set; }
public DateTime Config7CreatedAt { get; set; }
public DateTime? Config7UpdatedAt { get; set; }
public string Config7CreatedBy { get; set; }
public bool IsConfig7Active { get; set; }
public int Config7SortOrder { get; set; }


public int Config45Id { get; set; }
public string Config45Name { get; set; }
public string Config45Description { get; set; }
public DateTime Config45CreatedAt { get; set; }
public DateTime? Config45UpdatedAt { get; set; }
public string Config45CreatedBy { get; set; }
public bool IsConfig45Active { get; set; }
public int Config45SortOrder { get; set; }


public int Entry16Id { get; set; }
public string Entry16Name { get; set; }
public string Entry16Description { get; set; }
public DateTime Entry16CreatedAt { get; set; }
public DateTime? Entry16UpdatedAt { get; set; }
public string Entry16CreatedBy { get; set; }
public bool IsEntry16Active { get; set; }
public int Entry16SortOrder { get; set; }


public int Entry55Id { get; set; }
public string Entry55Name { get; set; }
public string Entry55Description { get; set; }
public DateTime Entry55CreatedAt { get; set; }
public DateTime? Entry55UpdatedAt { get; set; }
public string Entry55CreatedBy { get; set; }
public bool IsEntry55Active { get; set; }
public int Entry55SortOrder { get; set; }


public int Entry98Id { get; set; }
public string Entry98Name { get; set; }
public string Entry98Description { get; set; }
public DateTime Entry98CreatedAt { get; set; }
public DateTime? Entry98UpdatedAt { get; set; }
public string Entry98CreatedBy { get; set; }
public bool IsEntry98Active { get; set; }
public int Entry98SortOrder { get; set; }

    }
}