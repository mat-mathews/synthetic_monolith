using Admin.Processors35;
using Admin.Service247;
using Admin.Web;
using Auth.Handlers281;
using BatchJobs.Mappers362;
using BatchJobs.Processors;
using DataAccess.Tests;
using Imaging.Core;
using Imaging.Events303;
using Import.Api;
using Logging.Models379;
using Notifications.Client;
using Notifications.Mappers;
using Portal.Mappers;
using Reporting.Shared;
using Scheduling.Processors80;
using Security.Models136;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Api387;

namespace Auth.Validators87
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer11
    {
        private readonly Admin_Web_Info4 _admin_Web_Info4;
        private readonly Admin_Web_Response2 _admin_Web_Response2;
        private readonly Auth_Handlers281_Command4 _auth_Handlers281_Command4;
        private readonly Auth_Handlers281_Controller _auth_Handlers281_Controller;
        private readonly IReporting_Shared_Validator8 _iReporting_Shared_Validator8;
        private readonly Reporting_Shared_Manager12 _reporting_Shared_Manager12;
        private readonly IReporting_Shared_Provider5 _iReporting_Shared_Provider5;
        private readonly ISecurity_Models136_Handler7 _iSecurity_Models136_Handler7;

        public Consumer11(Admin_Web_Info4 admin_Web_Info4, Admin_Web_Response2 admin_Web_Response2, Auth_Handlers281_Command4 auth_Handlers281_Command4, Auth_Handlers281_Controller auth_Handlers281_Controller, IReporting_Shared_Validator8 iReporting_Shared_Validator8, Reporting_Shared_Manager12 reporting_Shared_Manager12, IReporting_Shared_Provider5 iReporting_Shared_Provider5, ISecurity_Models136_Handler7 iSecurity_Models136_Handler7)
        {
            _admin_Web_Info4 = admin_Web_Info4 ?? throw new ArgumentNullException(nameof(admin_Web_Info4));
            _admin_Web_Response2 = admin_Web_Response2 ?? throw new ArgumentNullException(nameof(admin_Web_Response2));
            _auth_Handlers281_Command4 = auth_Handlers281_Command4 ?? throw new ArgumentNullException(nameof(auth_Handlers281_Command4));
            _auth_Handlers281_Controller = auth_Handlers281_Controller ?? throw new ArgumentNullException(nameof(auth_Handlers281_Controller));
            _iReporting_Shared_Validator8 = iReporting_Shared_Validator8 ?? throw new ArgumentNullException(nameof(iReporting_Shared_Validator8));
            _reporting_Shared_Manager12 = reporting_Shared_Manager12 ?? throw new ArgumentNullException(nameof(reporting_Shared_Manager12));
            _iReporting_Shared_Provider5 = iReporting_Shared_Provider5 ?? throw new ArgumentNullException(nameof(iReporting_Shared_Provider5));
            _iSecurity_Models136_Handler7 = iSecurity_Models136_Handler7 ?? throw new ArgumentNullException(nameof(iSecurity_Models136_Handler7));
        }

        public Admin_Web_Info4 GetAdmin_Web_Info4() => _admin_Web_Info4;
        public Admin_Web_Response2 GetAdmin_Web_Response2() => _admin_Web_Response2;
        public Auth_Handlers281_Command4 GetAuth_Handlers281_Command4() => _auth_Handlers281_Command4;
        public Auth_Handlers281_Controller GetAuth_Handlers281_Controller() => _auth_Handlers281_Controller;
        public IReporting_Shared_Validator8 GetIReporting_Shared_Validator8() => _iReporting_Shared_Validator8;
        public Reporting_Shared_Manager12 GetReporting_Shared_Manager12() => _reporting_Shared_Manager12;
        public IReporting_Shared_Provider5 GetIReporting_Shared_Provider5() => _iReporting_Shared_Provider5;
        public ISecurity_Models136_Handler7 GetISecurity_Models136_Handler7() => _iSecurity_Models136_Handler7;

/// <summary>
/// Validates the Consumer11 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer11(Consumer11Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer11));
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
/// Processes the Consumer11 operation asynchronously.
/// </summary>
public async Task<Consumer11Result> ProcessConsumer11Async(
    Consumer11Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer11), request.Id);

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
            return new Consumer11Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer11));
        return new Consumer11Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer11));
        return new Consumer11Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer11 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer11Dto>> GetConsumer11ListAsync(
    Consumer11Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer11Entity>().AsQueryable();

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
        .Select(x => new Consumer11Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer11Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer11Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer11Service(
    ILogger<Consumer11Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer11:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer11 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer11Data> GetCachedConsumer11Async(string key)
{
    var cacheKey = $"Consumer11_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer11Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer11SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Record25Id { get; set; }
public string Record25Name { get; set; }
public string Record25Description { get; set; }
public DateTime Record25CreatedAt { get; set; }
public DateTime? Record25UpdatedAt { get; set; }
public string Record25CreatedBy { get; set; }
public bool IsRecord25Active { get; set; }
public int Record25SortOrder { get; set; }


public int Field79Id { get; set; }
public string Field79Name { get; set; }
public string Field79Description { get; set; }
public DateTime Field79CreatedAt { get; set; }
public DateTime? Field79UpdatedAt { get; set; }
public string Field79CreatedBy { get; set; }
public bool IsField79Active { get; set; }
public int Field79SortOrder { get; set; }


public int Attr9Id { get; set; }
public string Attr9Name { get; set; }
public string Attr9Description { get; set; }
public DateTime Attr9CreatedAt { get; set; }
public DateTime? Attr9UpdatedAt { get; set; }
public string Attr9CreatedBy { get; set; }
public bool IsAttr9Active { get; set; }
public int Attr9SortOrder { get; set; }


public int Config78Id { get; set; }
public string Config78Name { get; set; }
public string Config78Description { get; set; }
public DateTime Config78CreatedAt { get; set; }
public DateTime? Config78UpdatedAt { get; set; }
public string Config78CreatedBy { get; set; }
public bool IsConfig78Active { get; set; }
public int Config78SortOrder { get; set; }


public int Param10Id { get; set; }
public string Param10Name { get; set; }
public string Param10Description { get; set; }
public DateTime Param10CreatedAt { get; set; }
public DateTime? Param10UpdatedAt { get; set; }
public string Param10CreatedBy { get; set; }
public bool IsParam10Active { get; set; }
public int Param10SortOrder { get; set; }


public int Detail35Id { get; set; }
public string Detail35Name { get; set; }
public string Detail35Description { get; set; }
public DateTime Detail35CreatedAt { get; set; }
public DateTime? Detail35UpdatedAt { get; set; }
public string Detail35CreatedBy { get; set; }
public bool IsDetail35Active { get; set; }
public int Detail35SortOrder { get; set; }


public int Record29Id { get; set; }
public string Record29Name { get; set; }
public string Record29Description { get; set; }
public DateTime Record29CreatedAt { get; set; }
public DateTime? Record29UpdatedAt { get; set; }
public string Record29CreatedBy { get; set; }
public bool IsRecord29Active { get; set; }
public int Record29SortOrder { get; set; }


public int Item56Id { get; set; }
public string Item56Name { get; set; }
public string Item56Description { get; set; }
public DateTime Item56CreatedAt { get; set; }
public DateTime? Item56UpdatedAt { get; set; }
public string Item56CreatedBy { get; set; }
public bool IsItem56Active { get; set; }
public int Item56SortOrder { get; set; }


public int Detail28Id { get; set; }
public string Detail28Name { get; set; }
public string Detail28Description { get; set; }
public DateTime Detail28CreatedAt { get; set; }
public DateTime? Detail28UpdatedAt { get; set; }
public string Detail28CreatedBy { get; set; }
public bool IsDetail28Active { get; set; }
public int Detail28SortOrder { get; set; }


public int Field99Id { get; set; }
public string Field99Name { get; set; }
public string Field99Description { get; set; }
public DateTime Field99CreatedAt { get; set; }
public DateTime? Field99UpdatedAt { get; set; }
public string Field99CreatedBy { get; set; }
public bool IsField99Active { get; set; }
public int Field99SortOrder { get; set; }


public int Detail82Id { get; set; }
public string Detail82Name { get; set; }
public string Detail82Description { get; set; }
public DateTime Detail82CreatedAt { get; set; }
public DateTime? Detail82UpdatedAt { get; set; }
public string Detail82CreatedBy { get; set; }
public bool IsDetail82Active { get; set; }
public int Detail82SortOrder { get; set; }


public int Detail76Id { get; set; }
public string Detail76Name { get; set; }
public string Detail76Description { get; set; }
public DateTime Detail76CreatedAt { get; set; }
public DateTime? Detail76UpdatedAt { get; set; }
public string Detail76CreatedBy { get; set; }
public bool IsDetail76Active { get; set; }
public int Detail76SortOrder { get; set; }


public int Field86Id { get; set; }
public string Field86Name { get; set; }
public string Field86Description { get; set; }
public DateTime Field86CreatedAt { get; set; }
public DateTime? Field86UpdatedAt { get; set; }
public string Field86CreatedBy { get; set; }
public bool IsField86Active { get; set; }
public int Field86SortOrder { get; set; }


public int Detail99Id { get; set; }
public string Detail99Name { get; set; }
public string Detail99Description { get; set; }
public DateTime Detail99CreatedAt { get; set; }
public DateTime? Detail99UpdatedAt { get; set; }
public string Detail99CreatedBy { get; set; }
public bool IsDetail99Active { get; set; }
public int Detail99SortOrder { get; set; }


public int Item99Id { get; set; }
public string Item99Name { get; set; }
public string Item99Description { get; set; }
public DateTime Item99CreatedAt { get; set; }
public DateTime? Item99UpdatedAt { get; set; }
public string Item99CreatedBy { get; set; }
public bool IsItem99Active { get; set; }
public int Item99SortOrder { get; set; }


public int Config34Id { get; set; }
public string Config34Name { get; set; }
public string Config34Description { get; set; }
public DateTime Config34CreatedAt { get; set; }
public DateTime? Config34UpdatedAt { get; set; }
public string Config34CreatedBy { get; set; }
public bool IsConfig34Active { get; set; }
public int Config34SortOrder { get; set; }


public int Field9Id { get; set; }
public string Field9Name { get; set; }
public string Field9Description { get; set; }
public DateTime Field9CreatedAt { get; set; }
public DateTime? Field9UpdatedAt { get; set; }
public string Field9CreatedBy { get; set; }
public bool IsField9Active { get; set; }
public int Field9SortOrder { get; set; }


public int Param48Id { get; set; }
public string Param48Name { get; set; }
public string Param48Description { get; set; }
public DateTime Param48CreatedAt { get; set; }
public DateTime? Param48UpdatedAt { get; set; }
public string Param48CreatedBy { get; set; }
public bool IsParam48Active { get; set; }
public int Param48SortOrder { get; set; }


public int Field28Id { get; set; }
public string Field28Name { get; set; }
public string Field28Description { get; set; }
public DateTime Field28CreatedAt { get; set; }
public DateTime? Field28UpdatedAt { get; set; }
public string Field28CreatedBy { get; set; }
public bool IsField28Active { get; set; }
public int Field28SortOrder { get; set; }


public int Attr94Id { get; set; }
public string Attr94Name { get; set; }
public string Attr94Description { get; set; }
public DateTime Attr94CreatedAt { get; set; }
public DateTime? Attr94UpdatedAt { get; set; }
public string Attr94CreatedBy { get; set; }
public bool IsAttr94Active { get; set; }
public int Attr94SortOrder { get; set; }


public int Item22Id { get; set; }
public string Item22Name { get; set; }
public string Item22Description { get; set; }
public DateTime Item22CreatedAt { get; set; }
public DateTime? Item22UpdatedAt { get; set; }
public string Item22CreatedBy { get; set; }
public bool IsItem22Active { get; set; }
public int Item22SortOrder { get; set; }


public int Attr64Id { get; set; }
public string Attr64Name { get; set; }
public string Attr64Description { get; set; }
public DateTime Attr64CreatedAt { get; set; }
public DateTime? Attr64UpdatedAt { get; set; }
public string Attr64CreatedBy { get; set; }
public bool IsAttr64Active { get; set; }
public int Attr64SortOrder { get; set; }


public int Item21Id { get; set; }
public string Item21Name { get; set; }
public string Item21Description { get; set; }
public DateTime Item21CreatedAt { get; set; }
public DateTime? Item21UpdatedAt { get; set; }
public string Item21CreatedBy { get; set; }
public bool IsItem21Active { get; set; }
public int Item21SortOrder { get; set; }


public int Param32Id { get; set; }
public string Param32Name { get; set; }
public string Param32Description { get; set; }
public DateTime Param32CreatedAt { get; set; }
public DateTime? Param32UpdatedAt { get; set; }
public string Param32CreatedBy { get; set; }
public bool IsParam32Active { get; set; }
public int Param32SortOrder { get; set; }


public int Record45Id { get; set; }
public string Record45Name { get; set; }
public string Record45Description { get; set; }
public DateTime Record45CreatedAt { get; set; }
public DateTime? Record45UpdatedAt { get; set; }
public string Record45CreatedBy { get; set; }
public bool IsRecord45Active { get; set; }
public int Record45SortOrder { get; set; }


public int Entry69Id { get; set; }
public string Entry69Name { get; set; }
public string Entry69Description { get; set; }
public DateTime Entry69CreatedAt { get; set; }
public DateTime? Entry69UpdatedAt { get; set; }
public string Entry69CreatedBy { get; set; }
public bool IsEntry69Active { get; set; }
public int Entry69SortOrder { get; set; }


public int Attr55Id { get; set; }
public string Attr55Name { get; set; }
public string Attr55Description { get; set; }
public DateTime Attr55CreatedAt { get; set; }
public DateTime? Attr55UpdatedAt { get; set; }
public string Attr55CreatedBy { get; set; }
public bool IsAttr55Active { get; set; }
public int Attr55SortOrder { get; set; }


public int Record67Id { get; set; }
public string Record67Name { get; set; }
public string Record67Description { get; set; }
public DateTime Record67CreatedAt { get; set; }
public DateTime? Record67UpdatedAt { get; set; }
public string Record67CreatedBy { get; set; }
public bool IsRecord67Active { get; set; }
public int Record67SortOrder { get; set; }


public int Config61Id { get; set; }
public string Config61Name { get; set; }
public string Config61Description { get; set; }
public DateTime Config61CreatedAt { get; set; }
public DateTime? Config61UpdatedAt { get; set; }
public string Config61CreatedBy { get; set; }
public bool IsConfig61Active { get; set; }
public int Config61SortOrder { get; set; }


public int Config49Id { get; set; }
public string Config49Name { get; set; }
public string Config49Description { get; set; }
public DateTime Config49CreatedAt { get; set; }
public DateTime? Config49UpdatedAt { get; set; }
public string Config49CreatedBy { get; set; }
public bool IsConfig49Active { get; set; }
public int Config49SortOrder { get; set; }


public int Record94Id { get; set; }
public string Record94Name { get; set; }
public string Record94Description { get; set; }
public DateTime Record94CreatedAt { get; set; }
public DateTime? Record94UpdatedAt { get; set; }
public string Record94CreatedBy { get; set; }
public bool IsRecord94Active { get; set; }
public int Record94SortOrder { get; set; }


public int Entry57Id { get; set; }
public string Entry57Name { get; set; }
public string Entry57Description { get; set; }
public DateTime Entry57CreatedAt { get; set; }
public DateTime? Entry57UpdatedAt { get; set; }
public string Entry57CreatedBy { get; set; }
public bool IsEntry57Active { get; set; }
public int Entry57SortOrder { get; set; }


public int Param1Id { get; set; }
public string Param1Name { get; set; }
public string Param1Description { get; set; }
public DateTime Param1CreatedAt { get; set; }
public DateTime? Param1UpdatedAt { get; set; }
public string Param1CreatedBy { get; set; }
public bool IsParam1Active { get; set; }
public int Param1SortOrder { get; set; }


public int Param4Id { get; set; }
public string Param4Name { get; set; }
public string Param4Description { get; set; }
public DateTime Param4CreatedAt { get; set; }
public DateTime? Param4UpdatedAt { get; set; }
public string Param4CreatedBy { get; set; }
public bool IsParam4Active { get; set; }
public int Param4SortOrder { get; set; }


public int Detail54Id { get; set; }
public string Detail54Name { get; set; }
public string Detail54Description { get; set; }
public DateTime Detail54CreatedAt { get; set; }
public DateTime? Detail54UpdatedAt { get; set; }
public string Detail54CreatedBy { get; set; }
public bool IsDetail54Active { get; set; }
public int Detail54SortOrder { get; set; }


public int Item78Id { get; set; }
public string Item78Name { get; set; }
public string Item78Description { get; set; }
public DateTime Item78CreatedAt { get; set; }
public DateTime? Item78UpdatedAt { get; set; }
public string Item78CreatedBy { get; set; }
public bool IsItem78Active { get; set; }
public int Item78SortOrder { get; set; }


public int Detail50Id { get; set; }
public string Detail50Name { get; set; }
public string Detail50Description { get; set; }
public DateTime Detail50CreatedAt { get; set; }
public DateTime? Detail50UpdatedAt { get; set; }
public string Detail50CreatedBy { get; set; }
public bool IsDetail50Active { get; set; }
public int Detail50SortOrder { get; set; }


public int Record22Id { get; set; }
public string Record22Name { get; set; }
public string Record22Description { get; set; }
public DateTime Record22CreatedAt { get; set; }
public DateTime? Record22UpdatedAt { get; set; }
public string Record22CreatedBy { get; set; }
public bool IsRecord22Active { get; set; }
public int Record22SortOrder { get; set; }


public int Detail6Id { get; set; }
public string Detail6Name { get; set; }
public string Detail6Description { get; set; }
public DateTime Detail6CreatedAt { get; set; }
public DateTime? Detail6UpdatedAt { get; set; }
public string Detail6CreatedBy { get; set; }
public bool IsDetail6Active { get; set; }
public int Detail6SortOrder { get; set; }


public int Record63Id { get; set; }
public string Record63Name { get; set; }
public string Record63Description { get; set; }
public DateTime Record63CreatedAt { get; set; }
public DateTime? Record63UpdatedAt { get; set; }
public string Record63CreatedBy { get; set; }
public bool IsRecord63Active { get; set; }
public int Record63SortOrder { get; set; }


public int Field47Id { get; set; }
public string Field47Name { get; set; }
public string Field47Description { get; set; }
public DateTime Field47CreatedAt { get; set; }
public DateTime? Field47UpdatedAt { get; set; }
public string Field47CreatedBy { get; set; }
public bool IsField47Active { get; set; }
public int Field47SortOrder { get; set; }


public int Item16Id { get; set; }
public string Item16Name { get; set; }
public string Item16Description { get; set; }
public DateTime Item16CreatedAt { get; set; }
public DateTime? Item16UpdatedAt { get; set; }
public string Item16CreatedBy { get; set; }
public bool IsItem16Active { get; set; }
public int Item16SortOrder { get; set; }


public int Entry68Id { get; set; }
public string Entry68Name { get; set; }
public string Entry68Description { get; set; }
public DateTime Entry68CreatedAt { get; set; }
public DateTime? Entry68UpdatedAt { get; set; }
public string Entry68CreatedBy { get; set; }
public bool IsEntry68Active { get; set; }
public int Entry68SortOrder { get; set; }


public int Item82Id { get; set; }
public string Item82Name { get; set; }
public string Item82Description { get; set; }
public DateTime Item82CreatedAt { get; set; }
public DateTime? Item82UpdatedAt { get; set; }
public string Item82CreatedBy { get; set; }
public bool IsItem82Active { get; set; }
public int Item82SortOrder { get; set; }


public int Attr88Id { get; set; }
public string Attr88Name { get; set; }
public string Attr88Description { get; set; }
public DateTime Attr88CreatedAt { get; set; }
public DateTime? Attr88UpdatedAt { get; set; }
public string Attr88CreatedBy { get; set; }
public bool IsAttr88Active { get; set; }
public int Attr88SortOrder { get; set; }


public int Attr21Id { get; set; }
public string Attr21Name { get; set; }
public string Attr21Description { get; set; }
public DateTime Attr21CreatedAt { get; set; }
public DateTime? Attr21UpdatedAt { get; set; }
public string Attr21CreatedBy { get; set; }
public bool IsAttr21Active { get; set; }
public int Attr21SortOrder { get; set; }

    }
}