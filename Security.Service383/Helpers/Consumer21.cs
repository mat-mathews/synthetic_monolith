using Admin.Data;
using Admin.Mappers;
using Auth.Client;
using Auth.Processors319;
using Common.Models381;
using Common.Service;
using Documents.Contracts;
using Documents.Validators;
using Export.Core372;
using Export.Models262;
using Export.Processors426;
using GalaxyWorks.Client366;
using Integration.Service401;
using Logging.Tests;
using Notifications.Shared380;
using Security.Core243;
using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Api433;
using Workflow.Validators201;

namespace Security.Service383
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer21
    {
        private readonly Admin_Mappers_Provider6 _admin_Mappers_Provider6;
        private readonly Auth_Processors319_Processor1 _auth_Processors319_Processor1;
        private readonly Auth_Processors319_Response2 _auth_Processors319_Response2;
        private readonly Auth_Client_Result12 _auth_Client_Result12;
        private readonly IExport_Models262_Repository3 _iExport_Models262_Repository3;
        private readonly Export_Models262_Helper7 _export_Models262_Helper7;
        private readonly Export_Models262_Handler4 _export_Models262_Handler4;
        private readonly IDocuments_Validators_Validator10 _iDocuments_Validators_Validator10;

        public Consumer21(Admin_Mappers_Provider6 admin_Mappers_Provider6, Auth_Processors319_Processor1 auth_Processors319_Processor1, Auth_Processors319_Response2 auth_Processors319_Response2, Auth_Client_Result12 auth_Client_Result12, IExport_Models262_Repository3 iExport_Models262_Repository3, Export_Models262_Helper7 export_Models262_Helper7, Export_Models262_Handler4 export_Models262_Handler4, IDocuments_Validators_Validator10 iDocuments_Validators_Validator10)
        {
            _admin_Mappers_Provider6 = admin_Mappers_Provider6 ?? throw new ArgumentNullException(nameof(admin_Mappers_Provider6));
            _auth_Processors319_Processor1 = auth_Processors319_Processor1 ?? throw new ArgumentNullException(nameof(auth_Processors319_Processor1));
            _auth_Processors319_Response2 = auth_Processors319_Response2 ?? throw new ArgumentNullException(nameof(auth_Processors319_Response2));
            _auth_Client_Result12 = auth_Client_Result12 ?? throw new ArgumentNullException(nameof(auth_Client_Result12));
            _iExport_Models262_Repository3 = iExport_Models262_Repository3 ?? throw new ArgumentNullException(nameof(iExport_Models262_Repository3));
            _export_Models262_Helper7 = export_Models262_Helper7 ?? throw new ArgumentNullException(nameof(export_Models262_Helper7));
            _export_Models262_Handler4 = export_Models262_Handler4 ?? throw new ArgumentNullException(nameof(export_Models262_Handler4));
            _iDocuments_Validators_Validator10 = iDocuments_Validators_Validator10 ?? throw new ArgumentNullException(nameof(iDocuments_Validators_Validator10));
        }

        public Admin_Mappers_Provider6 GetAdmin_Mappers_Provider6() => _admin_Mappers_Provider6;
        public Auth_Processors319_Processor1 GetAuth_Processors319_Processor1() => _auth_Processors319_Processor1;
        public Auth_Processors319_Response2 GetAuth_Processors319_Response2() => _auth_Processors319_Response2;
        public Auth_Client_Result12 GetAuth_Client_Result12() => _auth_Client_Result12;
        public IExport_Models262_Repository3 GetIExport_Models262_Repository3() => _iExport_Models262_Repository3;
        public Export_Models262_Helper7 GetExport_Models262_Helper7() => _export_Models262_Helper7;
        public Export_Models262_Handler4 GetExport_Models262_Handler4() => _export_Models262_Handler4;
        public IDocuments_Validators_Validator10 GetIDocuments_Validators_Validator10() => _iDocuments_Validators_Validator10;

/// <summary>
/// Validates the Consumer21 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer21(Consumer21Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer21));
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
/// Processes the Consumer21 operation asynchronously.
/// </summary>
public async Task<Consumer21Result> ProcessConsumer21Async(
    Consumer21Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer21), request.Id);

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
            return new Consumer21Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer21));
        return new Consumer21Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer21));
        return new Consumer21Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer21 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer21Dto>> GetConsumer21ListAsync(
    Consumer21Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer21Entity>().AsQueryable();

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
        .Select(x => new Consumer21Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer21Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer21Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer21Service(
    ILogger<Consumer21Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer21:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer21 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer21Data> GetCachedConsumer21Async(string key)
{
    var cacheKey = $"Consumer21_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer21Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer21SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Record37Id { get; set; }
public string Record37Name { get; set; }
public string Record37Description { get; set; }
public DateTime Record37CreatedAt { get; set; }
public DateTime? Record37UpdatedAt { get; set; }
public string Record37CreatedBy { get; set; }
public bool IsRecord37Active { get; set; }
public int Record37SortOrder { get; set; }


public int Config67Id { get; set; }
public string Config67Name { get; set; }
public string Config67Description { get; set; }
public DateTime Config67CreatedAt { get; set; }
public DateTime? Config67UpdatedAt { get; set; }
public string Config67CreatedBy { get; set; }
public bool IsConfig67Active { get; set; }
public int Config67SortOrder { get; set; }


public int Field48Id { get; set; }
public string Field48Name { get; set; }
public string Field48Description { get; set; }
public DateTime Field48CreatedAt { get; set; }
public DateTime? Field48UpdatedAt { get; set; }
public string Field48CreatedBy { get; set; }
public bool IsField48Active { get; set; }
public int Field48SortOrder { get; set; }


public int Attr55Id { get; set; }
public string Attr55Name { get; set; }
public string Attr55Description { get; set; }
public DateTime Attr55CreatedAt { get; set; }
public DateTime? Attr55UpdatedAt { get; set; }
public string Attr55CreatedBy { get; set; }
public bool IsAttr55Active { get; set; }
public int Attr55SortOrder { get; set; }


public int Detail17Id { get; set; }
public string Detail17Name { get; set; }
public string Detail17Description { get; set; }
public DateTime Detail17CreatedAt { get; set; }
public DateTime? Detail17UpdatedAt { get; set; }
public string Detail17CreatedBy { get; set; }
public bool IsDetail17Active { get; set; }
public int Detail17SortOrder { get; set; }


public int Record15Id { get; set; }
public string Record15Name { get; set; }
public string Record15Description { get; set; }
public DateTime Record15CreatedAt { get; set; }
public DateTime? Record15UpdatedAt { get; set; }
public string Record15CreatedBy { get; set; }
public bool IsRecord15Active { get; set; }
public int Record15SortOrder { get; set; }


public int Param31Id { get; set; }
public string Param31Name { get; set; }
public string Param31Description { get; set; }
public DateTime Param31CreatedAt { get; set; }
public DateTime? Param31UpdatedAt { get; set; }
public string Param31CreatedBy { get; set; }
public bool IsParam31Active { get; set; }
public int Param31SortOrder { get; set; }


public int Field94Id { get; set; }
public string Field94Name { get; set; }
public string Field94Description { get; set; }
public DateTime Field94CreatedAt { get; set; }
public DateTime? Field94UpdatedAt { get; set; }
public string Field94CreatedBy { get; set; }
public bool IsField94Active { get; set; }
public int Field94SortOrder { get; set; }


public int Param25Id { get; set; }
public string Param25Name { get; set; }
public string Param25Description { get; set; }
public DateTime Param25CreatedAt { get; set; }
public DateTime? Param25UpdatedAt { get; set; }
public string Param25CreatedBy { get; set; }
public bool IsParam25Active { get; set; }
public int Param25SortOrder { get; set; }


public int Item29Id { get; set; }
public string Item29Name { get; set; }
public string Item29Description { get; set; }
public DateTime Item29CreatedAt { get; set; }
public DateTime? Item29UpdatedAt { get; set; }
public string Item29CreatedBy { get; set; }
public bool IsItem29Active { get; set; }
public int Item29SortOrder { get; set; }


public int Entry97Id { get; set; }
public string Entry97Name { get; set; }
public string Entry97Description { get; set; }
public DateTime Entry97CreatedAt { get; set; }
public DateTime? Entry97UpdatedAt { get; set; }
public string Entry97CreatedBy { get; set; }
public bool IsEntry97Active { get; set; }
public int Entry97SortOrder { get; set; }


public int Detail99Id { get; set; }
public string Detail99Name { get; set; }
public string Detail99Description { get; set; }
public DateTime Detail99CreatedAt { get; set; }
public DateTime? Detail99UpdatedAt { get; set; }
public string Detail99CreatedBy { get; set; }
public bool IsDetail99Active { get; set; }
public int Detail99SortOrder { get; set; }


public int Param47Id { get; set; }
public string Param47Name { get; set; }
public string Param47Description { get; set; }
public DateTime Param47CreatedAt { get; set; }
public DateTime? Param47UpdatedAt { get; set; }
public string Param47CreatedBy { get; set; }
public bool IsParam47Active { get; set; }
public int Param47SortOrder { get; set; }


public int Detail20Id { get; set; }
public string Detail20Name { get; set; }
public string Detail20Description { get; set; }
public DateTime Detail20CreatedAt { get; set; }
public DateTime? Detail20UpdatedAt { get; set; }
public string Detail20CreatedBy { get; set; }
public bool IsDetail20Active { get; set; }
public int Detail20SortOrder { get; set; }


public int Param93Id { get; set; }
public string Param93Name { get; set; }
public string Param93Description { get; set; }
public DateTime Param93CreatedAt { get; set; }
public DateTime? Param93UpdatedAt { get; set; }
public string Param93CreatedBy { get; set; }
public bool IsParam93Active { get; set; }
public int Param93SortOrder { get; set; }


public int Field56Id { get; set; }
public string Field56Name { get; set; }
public string Field56Description { get; set; }
public DateTime Field56CreatedAt { get; set; }
public DateTime? Field56UpdatedAt { get; set; }
public string Field56CreatedBy { get; set; }
public bool IsField56Active { get; set; }
public int Field56SortOrder { get; set; }


public int Detail48Id { get; set; }
public string Detail48Name { get; set; }
public string Detail48Description { get; set; }
public DateTime Detail48CreatedAt { get; set; }
public DateTime? Detail48UpdatedAt { get; set; }
public string Detail48CreatedBy { get; set; }
public bool IsDetail48Active { get; set; }
public int Detail48SortOrder { get; set; }


public int Param58Id { get; set; }
public string Param58Name { get; set; }
public string Param58Description { get; set; }
public DateTime Param58CreatedAt { get; set; }
public DateTime? Param58UpdatedAt { get; set; }
public string Param58CreatedBy { get; set; }
public bool IsParam58Active { get; set; }
public int Param58SortOrder { get; set; }


public int Entry18Id { get; set; }
public string Entry18Name { get; set; }
public string Entry18Description { get; set; }
public DateTime Entry18CreatedAt { get; set; }
public DateTime? Entry18UpdatedAt { get; set; }
public string Entry18CreatedBy { get; set; }
public bool IsEntry18Active { get; set; }
public int Entry18SortOrder { get; set; }


public int Record16Id { get; set; }
public string Record16Name { get; set; }
public string Record16Description { get; set; }
public DateTime Record16CreatedAt { get; set; }
public DateTime? Record16UpdatedAt { get; set; }
public string Record16CreatedBy { get; set; }
public bool IsRecord16Active { get; set; }
public int Record16SortOrder { get; set; }


public int Item79Id { get; set; }
public string Item79Name { get; set; }
public string Item79Description { get; set; }
public DateTime Item79CreatedAt { get; set; }
public DateTime? Item79UpdatedAt { get; set; }
public string Item79CreatedBy { get; set; }
public bool IsItem79Active { get; set; }
public int Item79SortOrder { get; set; }


public int Entry10Id { get; set; }
public string Entry10Name { get; set; }
public string Entry10Description { get; set; }
public DateTime Entry10CreatedAt { get; set; }
public DateTime? Entry10UpdatedAt { get; set; }
public string Entry10CreatedBy { get; set; }
public bool IsEntry10Active { get; set; }
public int Entry10SortOrder { get; set; }


public int Item68Id { get; set; }
public string Item68Name { get; set; }
public string Item68Description { get; set; }
public DateTime Item68CreatedAt { get; set; }
public DateTime? Item68UpdatedAt { get; set; }
public string Item68CreatedBy { get; set; }
public bool IsItem68Active { get; set; }
public int Item68SortOrder { get; set; }


public int Param19Id { get; set; }
public string Param19Name { get; set; }
public string Param19Description { get; set; }
public DateTime Param19CreatedAt { get; set; }
public DateTime? Param19UpdatedAt { get; set; }
public string Param19CreatedBy { get; set; }
public bool IsParam19Active { get; set; }
public int Param19SortOrder { get; set; }


public int Param8Id { get; set; }
public string Param8Name { get; set; }
public string Param8Description { get; set; }
public DateTime Param8CreatedAt { get; set; }
public DateTime? Param8UpdatedAt { get; set; }
public string Param8CreatedBy { get; set; }
public bool IsParam8Active { get; set; }
public int Param8SortOrder { get; set; }


public int Config39Id { get; set; }
public string Config39Name { get; set; }
public string Config39Description { get; set; }
public DateTime Config39CreatedAt { get; set; }
public DateTime? Config39UpdatedAt { get; set; }
public string Config39CreatedBy { get; set; }
public bool IsConfig39Active { get; set; }
public int Config39SortOrder { get; set; }


public int Detail95Id { get; set; }
public string Detail95Name { get; set; }
public string Detail95Description { get; set; }
public DateTime Detail95CreatedAt { get; set; }
public DateTime? Detail95UpdatedAt { get; set; }
public string Detail95CreatedBy { get; set; }
public bool IsDetail95Active { get; set; }
public int Detail95SortOrder { get; set; }


public int Field78Id { get; set; }
public string Field78Name { get; set; }
public string Field78Description { get; set; }
public DateTime Field78CreatedAt { get; set; }
public DateTime? Field78UpdatedAt { get; set; }
public string Field78CreatedBy { get; set; }
public bool IsField78Active { get; set; }
public int Field78SortOrder { get; set; }


public int Attr78Id { get; set; }
public string Attr78Name { get; set; }
public string Attr78Description { get; set; }
public DateTime Attr78CreatedAt { get; set; }
public DateTime? Attr78UpdatedAt { get; set; }
public string Attr78CreatedBy { get; set; }
public bool IsAttr78Active { get; set; }
public int Attr78SortOrder { get; set; }


public int Config87Id { get; set; }
public string Config87Name { get; set; }
public string Config87Description { get; set; }
public DateTime Config87CreatedAt { get; set; }
public DateTime? Config87UpdatedAt { get; set; }
public string Config87CreatedBy { get; set; }
public bool IsConfig87Active { get; set; }
public int Config87SortOrder { get; set; }


public int Entry85Id { get; set; }
public string Entry85Name { get; set; }
public string Entry85Description { get; set; }
public DateTime Entry85CreatedAt { get; set; }
public DateTime? Entry85UpdatedAt { get; set; }
public string Entry85CreatedBy { get; set; }
public bool IsEntry85Active { get; set; }
public int Entry85SortOrder { get; set; }


public int Detail34Id { get; set; }
public string Detail34Name { get; set; }
public string Detail34Description { get; set; }
public DateTime Detail34CreatedAt { get; set; }
public DateTime? Detail34UpdatedAt { get; set; }
public string Detail34CreatedBy { get; set; }
public bool IsDetail34Active { get; set; }
public int Detail34SortOrder { get; set; }


public int Record79Id { get; set; }
public string Record79Name { get; set; }
public string Record79Description { get; set; }
public DateTime Record79CreatedAt { get; set; }
public DateTime? Record79UpdatedAt { get; set; }
public string Record79CreatedBy { get; set; }
public bool IsRecord79Active { get; set; }
public int Record79SortOrder { get; set; }


public int Param23Id { get; set; }
public string Param23Name { get; set; }
public string Param23Description { get; set; }
public DateTime Param23CreatedAt { get; set; }
public DateTime? Param23UpdatedAt { get; set; }
public string Param23CreatedBy { get; set; }
public bool IsParam23Active { get; set; }
public int Param23SortOrder { get; set; }


public int Field37Id { get; set; }
public string Field37Name { get; set; }
public string Field37Description { get; set; }
public DateTime Field37CreatedAt { get; set; }
public DateTime? Field37UpdatedAt { get; set; }
public string Field37CreatedBy { get; set; }
public bool IsField37Active { get; set; }
public int Field37SortOrder { get; set; }


public int Config70Id { get; set; }
public string Config70Name { get; set; }
public string Config70Description { get; set; }
public DateTime Config70CreatedAt { get; set; }
public DateTime? Config70UpdatedAt { get; set; }
public string Config70CreatedBy { get; set; }
public bool IsConfig70Active { get; set; }
public int Config70SortOrder { get; set; }


public int Entry71Id { get; set; }
public string Entry71Name { get; set; }
public string Entry71Description { get; set; }
public DateTime Entry71CreatedAt { get; set; }
public DateTime? Entry71UpdatedAt { get; set; }
public string Entry71CreatedBy { get; set; }
public bool IsEntry71Active { get; set; }
public int Entry71SortOrder { get; set; }


public int Item91Id { get; set; }
public string Item91Name { get; set; }
public string Item91Description { get; set; }
public DateTime Item91CreatedAt { get; set; }
public DateTime? Item91UpdatedAt { get; set; }
public string Item91CreatedBy { get; set; }
public bool IsItem91Active { get; set; }
public int Item91SortOrder { get; set; }


public int Entry3Id { get; set; }
public string Entry3Name { get; set; }
public string Entry3Description { get; set; }
public DateTime Entry3CreatedAt { get; set; }
public DateTime? Entry3UpdatedAt { get; set; }
public string Entry3CreatedBy { get; set; }
public bool IsEntry3Active { get; set; }
public int Entry3SortOrder { get; set; }


public int Config20Id { get; set; }
public string Config20Name { get; set; }
public string Config20Description { get; set; }
public DateTime Config20CreatedAt { get; set; }
public DateTime? Config20UpdatedAt { get; set; }
public string Config20CreatedBy { get; set; }
public bool IsConfig20Active { get; set; }
public int Config20SortOrder { get; set; }


public int Param19Id { get; set; }
public string Param19Name { get; set; }
public string Param19Description { get; set; }
public DateTime Param19CreatedAt { get; set; }
public DateTime? Param19UpdatedAt { get; set; }
public string Param19CreatedBy { get; set; }
public bool IsParam19Active { get; set; }
public int Param19SortOrder { get; set; }


public int Param75Id { get; set; }
public string Param75Name { get; set; }
public string Param75Description { get; set; }
public DateTime Param75CreatedAt { get; set; }
public DateTime? Param75UpdatedAt { get; set; }
public string Param75CreatedBy { get; set; }
public bool IsParam75Active { get; set; }
public int Param75SortOrder { get; set; }


public int Config19Id { get; set; }
public string Config19Name { get; set; }
public string Config19Description { get; set; }
public DateTime Config19CreatedAt { get; set; }
public DateTime? Config19UpdatedAt { get; set; }
public string Config19CreatedBy { get; set; }
public bool IsConfig19Active { get; set; }
public int Config19SortOrder { get; set; }


public int Detail4Id { get; set; }
public string Detail4Name { get; set; }
public string Detail4Description { get; set; }
public DateTime Detail4CreatedAt { get; set; }
public DateTime? Detail4UpdatedAt { get; set; }
public string Detail4CreatedBy { get; set; }
public bool IsDetail4Active { get; set; }
public int Detail4SortOrder { get; set; }


public int Config96Id { get; set; }
public string Config96Name { get; set; }
public string Config96Description { get; set; }
public DateTime Config96CreatedAt { get; set; }
public DateTime? Config96UpdatedAt { get; set; }
public string Config96CreatedBy { get; set; }
public bool IsConfig96Active { get; set; }
public int Config96SortOrder { get; set; }

    }
}