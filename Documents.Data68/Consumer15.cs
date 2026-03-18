using Admin.Data117;
using BatchJobs.Client267;
using Billing.Web;
using Common.Events367;
using DataAccess.Contracts404;
using Export.Contracts;
using Export.Core;
using Export.Web210;
using Imaging.Client261;
using Imaging.Core204;
using Integration.Handlers244;
using Portal.Contracts;
using Portal.Events;
using Scheduling.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Models;
using Utilities.Tests;

namespace Documents.Data68
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer15
    {
        private readonly Admin_Data117_Event2 _admin_Data117_Event2;
        private readonly IAdmin_Data117_Provider3 _iAdmin_Data117_Provider3;
        private readonly IAdmin_Data117_Factory8 _iAdmin_Data117_Factory8;
        private readonly Imaging_Core204_Processor6 _imaging_Core204_Processor6;
        private readonly Utilities_Models_Manager4 _utilities_Models_Manager4;
        private readonly Utilities_Models_Handler _utilities_Models_Handler;
        private readonly Portal_Contracts_Service2 _portal_Contracts_Service2;
        private readonly IPortal_Contracts_Service3 _iPortal_Contracts_Service3;

        public Consumer15(Admin_Data117_Event2 admin_Data117_Event2, IAdmin_Data117_Provider3 iAdmin_Data117_Provider3, IAdmin_Data117_Factory8 iAdmin_Data117_Factory8, Imaging_Core204_Processor6 imaging_Core204_Processor6, Utilities_Models_Manager4 utilities_Models_Manager4, Utilities_Models_Handler utilities_Models_Handler, Portal_Contracts_Service2 portal_Contracts_Service2, IPortal_Contracts_Service3 iPortal_Contracts_Service3)
        {
            _admin_Data117_Event2 = admin_Data117_Event2 ?? throw new ArgumentNullException(nameof(admin_Data117_Event2));
            _iAdmin_Data117_Provider3 = iAdmin_Data117_Provider3 ?? throw new ArgumentNullException(nameof(iAdmin_Data117_Provider3));
            _iAdmin_Data117_Factory8 = iAdmin_Data117_Factory8 ?? throw new ArgumentNullException(nameof(iAdmin_Data117_Factory8));
            _imaging_Core204_Processor6 = imaging_Core204_Processor6 ?? throw new ArgumentNullException(nameof(imaging_Core204_Processor6));
            _utilities_Models_Manager4 = utilities_Models_Manager4 ?? throw new ArgumentNullException(nameof(utilities_Models_Manager4));
            _utilities_Models_Handler = utilities_Models_Handler ?? throw new ArgumentNullException(nameof(utilities_Models_Handler));
            _portal_Contracts_Service2 = portal_Contracts_Service2 ?? throw new ArgumentNullException(nameof(portal_Contracts_Service2));
            _iPortal_Contracts_Service3 = iPortal_Contracts_Service3 ?? throw new ArgumentNullException(nameof(iPortal_Contracts_Service3));
        }

        public Admin_Data117_Event2 GetAdmin_Data117_Event2() => _admin_Data117_Event2;
        public IAdmin_Data117_Provider3 GetIAdmin_Data117_Provider3() => _iAdmin_Data117_Provider3;
        public IAdmin_Data117_Factory8 GetIAdmin_Data117_Factory8() => _iAdmin_Data117_Factory8;
        public Imaging_Core204_Processor6 GetImaging_Core204_Processor6() => _imaging_Core204_Processor6;
        public Utilities_Models_Manager4 GetUtilities_Models_Manager4() => _utilities_Models_Manager4;
        public Utilities_Models_Handler GetUtilities_Models_Handler() => _utilities_Models_Handler;
        public Portal_Contracts_Service2 GetPortal_Contracts_Service2() => _portal_Contracts_Service2;
        public IPortal_Contracts_Service3 GetIPortal_Contracts_Service3() => _iPortal_Contracts_Service3;

/// <summary>
/// Validates the Consumer15 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer15(Consumer15Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer15));
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
/// Processes the Consumer15 operation asynchronously.
/// </summary>
public async Task<Consumer15Result> ProcessConsumer15Async(
    Consumer15Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer15), request.Id);

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
            return new Consumer15Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer15));
        return new Consumer15Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer15));
        return new Consumer15Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer15 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer15Dto>> GetConsumer15ListAsync(
    Consumer15Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer15Entity>().AsQueryable();

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
        .Select(x => new Consumer15Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer15Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer15Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer15Service(
    ILogger<Consumer15Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer15:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer15 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer15Data> GetCachedConsumer15Async(string key)
{
    var cacheKey = $"Consumer15_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer15Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer15SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Config78Id { get; set; }
public string Config78Name { get; set; }
public string Config78Description { get; set; }
public DateTime Config78CreatedAt { get; set; }
public DateTime? Config78UpdatedAt { get; set; }
public string Config78CreatedBy { get; set; }
public bool IsConfig78Active { get; set; }
public int Config78SortOrder { get; set; }


public int Record88Id { get; set; }
public string Record88Name { get; set; }
public string Record88Description { get; set; }
public DateTime Record88CreatedAt { get; set; }
public DateTime? Record88UpdatedAt { get; set; }
public string Record88CreatedBy { get; set; }
public bool IsRecord88Active { get; set; }
public int Record88SortOrder { get; set; }


public int Entry95Id { get; set; }
public string Entry95Name { get; set; }
public string Entry95Description { get; set; }
public DateTime Entry95CreatedAt { get; set; }
public DateTime? Entry95UpdatedAt { get; set; }
public string Entry95CreatedBy { get; set; }
public bool IsEntry95Active { get; set; }
public int Entry95SortOrder { get; set; }


public int Detail94Id { get; set; }
public string Detail94Name { get; set; }
public string Detail94Description { get; set; }
public DateTime Detail94CreatedAt { get; set; }
public DateTime? Detail94UpdatedAt { get; set; }
public string Detail94CreatedBy { get; set; }
public bool IsDetail94Active { get; set; }
public int Detail94SortOrder { get; set; }


public int Entry38Id { get; set; }
public string Entry38Name { get; set; }
public string Entry38Description { get; set; }
public DateTime Entry38CreatedAt { get; set; }
public DateTime? Entry38UpdatedAt { get; set; }
public string Entry38CreatedBy { get; set; }
public bool IsEntry38Active { get; set; }
public int Entry38SortOrder { get; set; }


public int Record80Id { get; set; }
public string Record80Name { get; set; }
public string Record80Description { get; set; }
public DateTime Record80CreatedAt { get; set; }
public DateTime? Record80UpdatedAt { get; set; }
public string Record80CreatedBy { get; set; }
public bool IsRecord80Active { get; set; }
public int Record80SortOrder { get; set; }


public int Detail30Id { get; set; }
public string Detail30Name { get; set; }
public string Detail30Description { get; set; }
public DateTime Detail30CreatedAt { get; set; }
public DateTime? Detail30UpdatedAt { get; set; }
public string Detail30CreatedBy { get; set; }
public bool IsDetail30Active { get; set; }
public int Detail30SortOrder { get; set; }


public int Detail26Id { get; set; }
public string Detail26Name { get; set; }
public string Detail26Description { get; set; }
public DateTime Detail26CreatedAt { get; set; }
public DateTime? Detail26UpdatedAt { get; set; }
public string Detail26CreatedBy { get; set; }
public bool IsDetail26Active { get; set; }
public int Detail26SortOrder { get; set; }


public int Item97Id { get; set; }
public string Item97Name { get; set; }
public string Item97Description { get; set; }
public DateTime Item97CreatedAt { get; set; }
public DateTime? Item97UpdatedAt { get; set; }
public string Item97CreatedBy { get; set; }
public bool IsItem97Active { get; set; }
public int Item97SortOrder { get; set; }


public int Attr11Id { get; set; }
public string Attr11Name { get; set; }
public string Attr11Description { get; set; }
public DateTime Attr11CreatedAt { get; set; }
public DateTime? Attr11UpdatedAt { get; set; }
public string Attr11CreatedBy { get; set; }
public bool IsAttr11Active { get; set; }
public int Attr11SortOrder { get; set; }


public int Attr27Id { get; set; }
public string Attr27Name { get; set; }
public string Attr27Description { get; set; }
public DateTime Attr27CreatedAt { get; set; }
public DateTime? Attr27UpdatedAt { get; set; }
public string Attr27CreatedBy { get; set; }
public bool IsAttr27Active { get; set; }
public int Attr27SortOrder { get; set; }


public int Record78Id { get; set; }
public string Record78Name { get; set; }
public string Record78Description { get; set; }
public DateTime Record78CreatedAt { get; set; }
public DateTime? Record78UpdatedAt { get; set; }
public string Record78CreatedBy { get; set; }
public bool IsRecord78Active { get; set; }
public int Record78SortOrder { get; set; }


public int Item64Id { get; set; }
public string Item64Name { get; set; }
public string Item64Description { get; set; }
public DateTime Item64CreatedAt { get; set; }
public DateTime? Item64UpdatedAt { get; set; }
public string Item64CreatedBy { get; set; }
public bool IsItem64Active { get; set; }
public int Item64SortOrder { get; set; }


public int Field4Id { get; set; }
public string Field4Name { get; set; }
public string Field4Description { get; set; }
public DateTime Field4CreatedAt { get; set; }
public DateTime? Field4UpdatedAt { get; set; }
public string Field4CreatedBy { get; set; }
public bool IsField4Active { get; set; }
public int Field4SortOrder { get; set; }


public int Param4Id { get; set; }
public string Param4Name { get; set; }
public string Param4Description { get; set; }
public DateTime Param4CreatedAt { get; set; }
public DateTime? Param4UpdatedAt { get; set; }
public string Param4CreatedBy { get; set; }
public bool IsParam4Active { get; set; }
public int Param4SortOrder { get; set; }


public int Attr16Id { get; set; }
public string Attr16Name { get; set; }
public string Attr16Description { get; set; }
public DateTime Attr16CreatedAt { get; set; }
public DateTime? Attr16UpdatedAt { get; set; }
public string Attr16CreatedBy { get; set; }
public bool IsAttr16Active { get; set; }
public int Attr16SortOrder { get; set; }


public int Detail58Id { get; set; }
public string Detail58Name { get; set; }
public string Detail58Description { get; set; }
public DateTime Detail58CreatedAt { get; set; }
public DateTime? Detail58UpdatedAt { get; set; }
public string Detail58CreatedBy { get; set; }
public bool IsDetail58Active { get; set; }
public int Detail58SortOrder { get; set; }


public int Item82Id { get; set; }
public string Item82Name { get; set; }
public string Item82Description { get; set; }
public DateTime Item82CreatedAt { get; set; }
public DateTime? Item82UpdatedAt { get; set; }
public string Item82CreatedBy { get; set; }
public bool IsItem82Active { get; set; }
public int Item82SortOrder { get; set; }


public int Entry40Id { get; set; }
public string Entry40Name { get; set; }
public string Entry40Description { get; set; }
public DateTime Entry40CreatedAt { get; set; }
public DateTime? Entry40UpdatedAt { get; set; }
public string Entry40CreatedBy { get; set; }
public bool IsEntry40Active { get; set; }
public int Entry40SortOrder { get; set; }


public int Record41Id { get; set; }
public string Record41Name { get; set; }
public string Record41Description { get; set; }
public DateTime Record41CreatedAt { get; set; }
public DateTime? Record41UpdatedAt { get; set; }
public string Record41CreatedBy { get; set; }
public bool IsRecord41Active { get; set; }
public int Record41SortOrder { get; set; }


public int Entry1Id { get; set; }
public string Entry1Name { get; set; }
public string Entry1Description { get; set; }
public DateTime Entry1CreatedAt { get; set; }
public DateTime? Entry1UpdatedAt { get; set; }
public string Entry1CreatedBy { get; set; }
public bool IsEntry1Active { get; set; }
public int Entry1SortOrder { get; set; }


public int Detail16Id { get; set; }
public string Detail16Name { get; set; }
public string Detail16Description { get; set; }
public DateTime Detail16CreatedAt { get; set; }
public DateTime? Detail16UpdatedAt { get; set; }
public string Detail16CreatedBy { get; set; }
public bool IsDetail16Active { get; set; }
public int Detail16SortOrder { get; set; }


public int Entry62Id { get; set; }
public string Entry62Name { get; set; }
public string Entry62Description { get; set; }
public DateTime Entry62CreatedAt { get; set; }
public DateTime? Entry62UpdatedAt { get; set; }
public string Entry62CreatedBy { get; set; }
public bool IsEntry62Active { get; set; }
public int Entry62SortOrder { get; set; }


public int Entry62Id { get; set; }
public string Entry62Name { get; set; }
public string Entry62Description { get; set; }
public DateTime Entry62CreatedAt { get; set; }
public DateTime? Entry62UpdatedAt { get; set; }
public string Entry62CreatedBy { get; set; }
public bool IsEntry62Active { get; set; }
public int Entry62SortOrder { get; set; }


public int Entry61Id { get; set; }
public string Entry61Name { get; set; }
public string Entry61Description { get; set; }
public DateTime Entry61CreatedAt { get; set; }
public DateTime? Entry61UpdatedAt { get; set; }
public string Entry61CreatedBy { get; set; }
public bool IsEntry61Active { get; set; }
public int Entry61SortOrder { get; set; }


public int Attr80Id { get; set; }
public string Attr80Name { get; set; }
public string Attr80Description { get; set; }
public DateTime Attr80CreatedAt { get; set; }
public DateTime? Attr80UpdatedAt { get; set; }
public string Attr80CreatedBy { get; set; }
public bool IsAttr80Active { get; set; }
public int Attr80SortOrder { get; set; }


public int Param34Id { get; set; }
public string Param34Name { get; set; }
public string Param34Description { get; set; }
public DateTime Param34CreatedAt { get; set; }
public DateTime? Param34UpdatedAt { get; set; }
public string Param34CreatedBy { get; set; }
public bool IsParam34Active { get; set; }
public int Param34SortOrder { get; set; }


public int Param13Id { get; set; }
public string Param13Name { get; set; }
public string Param13Description { get; set; }
public DateTime Param13CreatedAt { get; set; }
public DateTime? Param13UpdatedAt { get; set; }
public string Param13CreatedBy { get; set; }
public bool IsParam13Active { get; set; }
public int Param13SortOrder { get; set; }


public int Config25Id { get; set; }
public string Config25Name { get; set; }
public string Config25Description { get; set; }
public DateTime Config25CreatedAt { get; set; }
public DateTime? Config25UpdatedAt { get; set; }
public string Config25CreatedBy { get; set; }
public bool IsConfig25Active { get; set; }
public int Config25SortOrder { get; set; }


public int Param75Id { get; set; }
public string Param75Name { get; set; }
public string Param75Description { get; set; }
public DateTime Param75CreatedAt { get; set; }
public DateTime? Param75UpdatedAt { get; set; }
public string Param75CreatedBy { get; set; }
public bool IsParam75Active { get; set; }
public int Param75SortOrder { get; set; }


public int Param98Id { get; set; }
public string Param98Name { get; set; }
public string Param98Description { get; set; }
public DateTime Param98CreatedAt { get; set; }
public DateTime? Param98UpdatedAt { get; set; }
public string Param98CreatedBy { get; set; }
public bool IsParam98Active { get; set; }
public int Param98SortOrder { get; set; }


public int Attr43Id { get; set; }
public string Attr43Name { get; set; }
public string Attr43Description { get; set; }
public DateTime Attr43CreatedAt { get; set; }
public DateTime? Attr43UpdatedAt { get; set; }
public string Attr43CreatedBy { get; set; }
public bool IsAttr43Active { get; set; }
public int Attr43SortOrder { get; set; }


public int Detail41Id { get; set; }
public string Detail41Name { get; set; }
public string Detail41Description { get; set; }
public DateTime Detail41CreatedAt { get; set; }
public DateTime? Detail41UpdatedAt { get; set; }
public string Detail41CreatedBy { get; set; }
public bool IsDetail41Active { get; set; }
public int Detail41SortOrder { get; set; }


public int Item16Id { get; set; }
public string Item16Name { get; set; }
public string Item16Description { get; set; }
public DateTime Item16CreatedAt { get; set; }
public DateTime? Item16UpdatedAt { get; set; }
public string Item16CreatedBy { get; set; }
public bool IsItem16Active { get; set; }
public int Item16SortOrder { get; set; }


public int Detail35Id { get; set; }
public string Detail35Name { get; set; }
public string Detail35Description { get; set; }
public DateTime Detail35CreatedAt { get; set; }
public DateTime? Detail35UpdatedAt { get; set; }
public string Detail35CreatedBy { get; set; }
public bool IsDetail35Active { get; set; }
public int Detail35SortOrder { get; set; }


public int Attr76Id { get; set; }
public string Attr76Name { get; set; }
public string Attr76Description { get; set; }
public DateTime Attr76CreatedAt { get; set; }
public DateTime? Attr76UpdatedAt { get; set; }
public string Attr76CreatedBy { get; set; }
public bool IsAttr76Active { get; set; }
public int Attr76SortOrder { get; set; }


public int Config18Id { get; set; }
public string Config18Name { get; set; }
public string Config18Description { get; set; }
public DateTime Config18CreatedAt { get; set; }
public DateTime? Config18UpdatedAt { get; set; }
public string Config18CreatedBy { get; set; }
public bool IsConfig18Active { get; set; }
public int Config18SortOrder { get; set; }


public int Item99Id { get; set; }
public string Item99Name { get; set; }
public string Item99Description { get; set; }
public DateTime Item99CreatedAt { get; set; }
public DateTime? Item99UpdatedAt { get; set; }
public string Item99CreatedBy { get; set; }
public bool IsItem99Active { get; set; }
public int Item99SortOrder { get; set; }


public int Config88Id { get; set; }
public string Config88Name { get; set; }
public string Config88Description { get; set; }
public DateTime Config88CreatedAt { get; set; }
public DateTime? Config88UpdatedAt { get; set; }
public string Config88CreatedBy { get; set; }
public bool IsConfig88Active { get; set; }
public int Config88SortOrder { get; set; }


public int Config56Id { get; set; }
public string Config56Name { get; set; }
public string Config56Description { get; set; }
public DateTime Config56CreatedAt { get; set; }
public DateTime? Config56UpdatedAt { get; set; }
public string Config56CreatedBy { get; set; }
public bool IsConfig56Active { get; set; }
public int Config56SortOrder { get; set; }


public int Record67Id { get; set; }
public string Record67Name { get; set; }
public string Record67Description { get; set; }
public DateTime Record67CreatedAt { get; set; }
public DateTime? Record67UpdatedAt { get; set; }
public string Record67CreatedBy { get; set; }
public bool IsRecord67Active { get; set; }
public int Record67SortOrder { get; set; }


public int Attr74Id { get; set; }
public string Attr74Name { get; set; }
public string Attr74Description { get; set; }
public DateTime Attr74CreatedAt { get; set; }
public DateTime? Attr74UpdatedAt { get; set; }
public string Attr74CreatedBy { get; set; }
public bool IsAttr74Active { get; set; }
public int Attr74SortOrder { get; set; }


public int Detail92Id { get; set; }
public string Detail92Name { get; set; }
public string Detail92Description { get; set; }
public DateTime Detail92CreatedAt { get; set; }
public DateTime? Detail92UpdatedAt { get; set; }
public string Detail92CreatedBy { get; set; }
public bool IsDetail92Active { get; set; }
public int Detail92SortOrder { get; set; }


public int Field38Id { get; set; }
public string Field38Name { get; set; }
public string Field38Description { get; set; }
public DateTime Field38CreatedAt { get; set; }
public DateTime? Field38UpdatedAt { get; set; }
public string Field38CreatedBy { get; set; }
public bool IsField38Active { get; set; }
public int Field38SortOrder { get; set; }


public int Record76Id { get; set; }
public string Record76Name { get; set; }
public string Record76Description { get; set; }
public DateTime Record76CreatedAt { get; set; }
public DateTime? Record76UpdatedAt { get; set; }
public string Record76CreatedBy { get; set; }
public bool IsRecord76Active { get; set; }
public int Record76SortOrder { get; set; }


public int Record39Id { get; set; }
public string Record39Name { get; set; }
public string Record39Description { get; set; }
public DateTime Record39CreatedAt { get; set; }
public DateTime? Record39UpdatedAt { get; set; }
public string Record39CreatedBy { get; set; }
public bool IsRecord39Active { get; set; }
public int Record39SortOrder { get; set; }

    }
}