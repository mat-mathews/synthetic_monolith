using Admin.Api255;
using Admin.Client346;
using Admin.Tests10;
using BatchJobs.Tests270;
using Common.Client;
using Common.Processors245;
using Common.Service258;
using DataAccess.Api307;
using DataAccess.Core;
using DataAccess.Tests;
using Documents.Models;
using Export.Core;
using Imaging.Mappers93;
using Import.Handlers167;
using Integration.Data175;
using Integration.Service401;
using Portal.Validators227;
using Reporting.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Integration.Service107
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer19
    {
        private readonly IAdmin_Api255_Handler11 _iAdmin_Api255_Handler11;
        private readonly Admin_Client346_Repository8 _admin_Client346_Repository8;
        private readonly Admin_Tests10_Helper8 _admin_Tests10_Helper8;
        private readonly Reporting_Api_Service4 _reporting_Api_Service4;
        private readonly Reporting_Api_Result _reporting_Api_Result;
        private readonly DataAccess_Core_Factory12 _dataAccess_Core_Factory12;
        private readonly Common_Service258_Provider4 _common_Service258_Provider4;
        private readonly Import_Handlers167_Dto3 _import_Handlers167_Dto3;

        public Consumer19(IAdmin_Api255_Handler11 iAdmin_Api255_Handler11, Admin_Client346_Repository8 admin_Client346_Repository8, Admin_Tests10_Helper8 admin_Tests10_Helper8, Reporting_Api_Service4 reporting_Api_Service4, Reporting_Api_Result reporting_Api_Result, DataAccess_Core_Factory12 dataAccess_Core_Factory12, Common_Service258_Provider4 common_Service258_Provider4, Import_Handlers167_Dto3 import_Handlers167_Dto3)
        {
            _iAdmin_Api255_Handler11 = iAdmin_Api255_Handler11 ?? throw new ArgumentNullException(nameof(iAdmin_Api255_Handler11));
            _admin_Client346_Repository8 = admin_Client346_Repository8 ?? throw new ArgumentNullException(nameof(admin_Client346_Repository8));
            _admin_Tests10_Helper8 = admin_Tests10_Helper8 ?? throw new ArgumentNullException(nameof(admin_Tests10_Helper8));
            _reporting_Api_Service4 = reporting_Api_Service4 ?? throw new ArgumentNullException(nameof(reporting_Api_Service4));
            _reporting_Api_Result = reporting_Api_Result ?? throw new ArgumentNullException(nameof(reporting_Api_Result));
            _dataAccess_Core_Factory12 = dataAccess_Core_Factory12 ?? throw new ArgumentNullException(nameof(dataAccess_Core_Factory12));
            _common_Service258_Provider4 = common_Service258_Provider4 ?? throw new ArgumentNullException(nameof(common_Service258_Provider4));
            _import_Handlers167_Dto3 = import_Handlers167_Dto3 ?? throw new ArgumentNullException(nameof(import_Handlers167_Dto3));
        }

        public IAdmin_Api255_Handler11 GetIAdmin_Api255_Handler11() => _iAdmin_Api255_Handler11;
        public Admin_Client346_Repository8 GetAdmin_Client346_Repository8() => _admin_Client346_Repository8;
        public Admin_Tests10_Helper8 GetAdmin_Tests10_Helper8() => _admin_Tests10_Helper8;
        public Reporting_Api_Service4 GetReporting_Api_Service4() => _reporting_Api_Service4;
        public Reporting_Api_Result GetReporting_Api_Result() => _reporting_Api_Result;
        public DataAccess_Core_Factory12 GetDataAccess_Core_Factory12() => _dataAccess_Core_Factory12;
        public Common_Service258_Provider4 GetCommon_Service258_Provider4() => _common_Service258_Provider4;
        public Import_Handlers167_Dto3 GetImport_Handlers167_Dto3() => _import_Handlers167_Dto3;

/// <summary>
/// Validates the Consumer19 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer19(Consumer19Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer19));
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
/// Processes the Consumer19 operation asynchronously.
/// </summary>
public async Task<Consumer19Result> ProcessConsumer19Async(
    Consumer19Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer19), request.Id);

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
            return new Consumer19Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer19));
        return new Consumer19Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer19));
        return new Consumer19Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer19 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer19Dto>> GetConsumer19ListAsync(
    Consumer19Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer19Entity>().AsQueryable();

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
        .Select(x => new Consumer19Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer19Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer19Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer19Service(
    ILogger<Consumer19Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer19:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer19 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer19Data> GetCachedConsumer19Async(string key)
{
    var cacheKey = $"Consumer19_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer19Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer19SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Field98Id { get; set; }
public string Field98Name { get; set; }
public string Field98Description { get; set; }
public DateTime Field98CreatedAt { get; set; }
public DateTime? Field98UpdatedAt { get; set; }
public string Field98CreatedBy { get; set; }
public bool IsField98Active { get; set; }
public int Field98SortOrder { get; set; }


public int Entry20Id { get; set; }
public string Entry20Name { get; set; }
public string Entry20Description { get; set; }
public DateTime Entry20CreatedAt { get; set; }
public DateTime? Entry20UpdatedAt { get; set; }
public string Entry20CreatedBy { get; set; }
public bool IsEntry20Active { get; set; }
public int Entry20SortOrder { get; set; }


public int Config62Id { get; set; }
public string Config62Name { get; set; }
public string Config62Description { get; set; }
public DateTime Config62CreatedAt { get; set; }
public DateTime? Config62UpdatedAt { get; set; }
public string Config62CreatedBy { get; set; }
public bool IsConfig62Active { get; set; }
public int Config62SortOrder { get; set; }


public int Field86Id { get; set; }
public string Field86Name { get; set; }
public string Field86Description { get; set; }
public DateTime Field86CreatedAt { get; set; }
public DateTime? Field86UpdatedAt { get; set; }
public string Field86CreatedBy { get; set; }
public bool IsField86Active { get; set; }
public int Field86SortOrder { get; set; }


public int Detail49Id { get; set; }
public string Detail49Name { get; set; }
public string Detail49Description { get; set; }
public DateTime Detail49CreatedAt { get; set; }
public DateTime? Detail49UpdatedAt { get; set; }
public string Detail49CreatedBy { get; set; }
public bool IsDetail49Active { get; set; }
public int Detail49SortOrder { get; set; }


public int Config12Id { get; set; }
public string Config12Name { get; set; }
public string Config12Description { get; set; }
public DateTime Config12CreatedAt { get; set; }
public DateTime? Config12UpdatedAt { get; set; }
public string Config12CreatedBy { get; set; }
public bool IsConfig12Active { get; set; }
public int Config12SortOrder { get; set; }


public int Item31Id { get; set; }
public string Item31Name { get; set; }
public string Item31Description { get; set; }
public DateTime Item31CreatedAt { get; set; }
public DateTime? Item31UpdatedAt { get; set; }
public string Item31CreatedBy { get; set; }
public bool IsItem31Active { get; set; }
public int Item31SortOrder { get; set; }


public int Detail16Id { get; set; }
public string Detail16Name { get; set; }
public string Detail16Description { get; set; }
public DateTime Detail16CreatedAt { get; set; }
public DateTime? Detail16UpdatedAt { get; set; }
public string Detail16CreatedBy { get; set; }
public bool IsDetail16Active { get; set; }
public int Detail16SortOrder { get; set; }


public int Record37Id { get; set; }
public string Record37Name { get; set; }
public string Record37Description { get; set; }
public DateTime Record37CreatedAt { get; set; }
public DateTime? Record37UpdatedAt { get; set; }
public string Record37CreatedBy { get; set; }
public bool IsRecord37Active { get; set; }
public int Record37SortOrder { get; set; }


public int Record56Id { get; set; }
public string Record56Name { get; set; }
public string Record56Description { get; set; }
public DateTime Record56CreatedAt { get; set; }
public DateTime? Record56UpdatedAt { get; set; }
public string Record56CreatedBy { get; set; }
public bool IsRecord56Active { get; set; }
public int Record56SortOrder { get; set; }


public int Record78Id { get; set; }
public string Record78Name { get; set; }
public string Record78Description { get; set; }
public DateTime Record78CreatedAt { get; set; }
public DateTime? Record78UpdatedAt { get; set; }
public string Record78CreatedBy { get; set; }
public bool IsRecord78Active { get; set; }
public int Record78SortOrder { get; set; }


public int Param29Id { get; set; }
public string Param29Name { get; set; }
public string Param29Description { get; set; }
public DateTime Param29CreatedAt { get; set; }
public DateTime? Param29UpdatedAt { get; set; }
public string Param29CreatedBy { get; set; }
public bool IsParam29Active { get; set; }
public int Param29SortOrder { get; set; }


public int Detail34Id { get; set; }
public string Detail34Name { get; set; }
public string Detail34Description { get; set; }
public DateTime Detail34CreatedAt { get; set; }
public DateTime? Detail34UpdatedAt { get; set; }
public string Detail34CreatedBy { get; set; }
public bool IsDetail34Active { get; set; }
public int Detail34SortOrder { get; set; }


public int Entry57Id { get; set; }
public string Entry57Name { get; set; }
public string Entry57Description { get; set; }
public DateTime Entry57CreatedAt { get; set; }
public DateTime? Entry57UpdatedAt { get; set; }
public string Entry57CreatedBy { get; set; }
public bool IsEntry57Active { get; set; }
public int Entry57SortOrder { get; set; }


public int Config59Id { get; set; }
public string Config59Name { get; set; }
public string Config59Description { get; set; }
public DateTime Config59CreatedAt { get; set; }
public DateTime? Config59UpdatedAt { get; set; }
public string Config59CreatedBy { get; set; }
public bool IsConfig59Active { get; set; }
public int Config59SortOrder { get; set; }


public int Param46Id { get; set; }
public string Param46Name { get; set; }
public string Param46Description { get; set; }
public DateTime Param46CreatedAt { get; set; }
public DateTime? Param46UpdatedAt { get; set; }
public string Param46CreatedBy { get; set; }
public bool IsParam46Active { get; set; }
public int Param46SortOrder { get; set; }


public int Field5Id { get; set; }
public string Field5Name { get; set; }
public string Field5Description { get; set; }
public DateTime Field5CreatedAt { get; set; }
public DateTime? Field5UpdatedAt { get; set; }
public string Field5CreatedBy { get; set; }
public bool IsField5Active { get; set; }
public int Field5SortOrder { get; set; }


public int Attr31Id { get; set; }
public string Attr31Name { get; set; }
public string Attr31Description { get; set; }
public DateTime Attr31CreatedAt { get; set; }
public DateTime? Attr31UpdatedAt { get; set; }
public string Attr31CreatedBy { get; set; }
public bool IsAttr31Active { get; set; }
public int Attr31SortOrder { get; set; }


public int Field39Id { get; set; }
public string Field39Name { get; set; }
public string Field39Description { get; set; }
public DateTime Field39CreatedAt { get; set; }
public DateTime? Field39UpdatedAt { get; set; }
public string Field39CreatedBy { get; set; }
public bool IsField39Active { get; set; }
public int Field39SortOrder { get; set; }


public int Attr39Id { get; set; }
public string Attr39Name { get; set; }
public string Attr39Description { get; set; }
public DateTime Attr39CreatedAt { get; set; }
public DateTime? Attr39UpdatedAt { get; set; }
public string Attr39CreatedBy { get; set; }
public bool IsAttr39Active { get; set; }
public int Attr39SortOrder { get; set; }


public int Record35Id { get; set; }
public string Record35Name { get; set; }
public string Record35Description { get; set; }
public DateTime Record35CreatedAt { get; set; }
public DateTime? Record35UpdatedAt { get; set; }
public string Record35CreatedBy { get; set; }
public bool IsRecord35Active { get; set; }
public int Record35SortOrder { get; set; }


public int Detail6Id { get; set; }
public string Detail6Name { get; set; }
public string Detail6Description { get; set; }
public DateTime Detail6CreatedAt { get; set; }
public DateTime? Detail6UpdatedAt { get; set; }
public string Detail6CreatedBy { get; set; }
public bool IsDetail6Active { get; set; }
public int Detail6SortOrder { get; set; }


public int Record98Id { get; set; }
public string Record98Name { get; set; }
public string Record98Description { get; set; }
public DateTime Record98CreatedAt { get; set; }
public DateTime? Record98UpdatedAt { get; set; }
public string Record98CreatedBy { get; set; }
public bool IsRecord98Active { get; set; }
public int Record98SortOrder { get; set; }


public int Item97Id { get; set; }
public string Item97Name { get; set; }
public string Item97Description { get; set; }
public DateTime Item97CreatedAt { get; set; }
public DateTime? Item97UpdatedAt { get; set; }
public string Item97CreatedBy { get; set; }
public bool IsItem97Active { get; set; }
public int Item97SortOrder { get; set; }


public int Param68Id { get; set; }
public string Param68Name { get; set; }
public string Param68Description { get; set; }
public DateTime Param68CreatedAt { get; set; }
public DateTime? Param68UpdatedAt { get; set; }
public string Param68CreatedBy { get; set; }
public bool IsParam68Active { get; set; }
public int Param68SortOrder { get; set; }


public int Entry33Id { get; set; }
public string Entry33Name { get; set; }
public string Entry33Description { get; set; }
public DateTime Entry33CreatedAt { get; set; }
public DateTime? Entry33UpdatedAt { get; set; }
public string Entry33CreatedBy { get; set; }
public bool IsEntry33Active { get; set; }
public int Entry33SortOrder { get; set; }


public int Entry16Id { get; set; }
public string Entry16Name { get; set; }
public string Entry16Description { get; set; }
public DateTime Entry16CreatedAt { get; set; }
public DateTime? Entry16UpdatedAt { get; set; }
public string Entry16CreatedBy { get; set; }
public bool IsEntry16Active { get; set; }
public int Entry16SortOrder { get; set; }


public int Field66Id { get; set; }
public string Field66Name { get; set; }
public string Field66Description { get; set; }
public DateTime Field66CreatedAt { get; set; }
public DateTime? Field66UpdatedAt { get; set; }
public string Field66CreatedBy { get; set; }
public bool IsField66Active { get; set; }
public int Field66SortOrder { get; set; }


public int Item81Id { get; set; }
public string Item81Name { get; set; }
public string Item81Description { get; set; }
public DateTime Item81CreatedAt { get; set; }
public DateTime? Item81UpdatedAt { get; set; }
public string Item81CreatedBy { get; set; }
public bool IsItem81Active { get; set; }
public int Item81SortOrder { get; set; }


public int Attr5Id { get; set; }
public string Attr5Name { get; set; }
public string Attr5Description { get; set; }
public DateTime Attr5CreatedAt { get; set; }
public DateTime? Attr5UpdatedAt { get; set; }
public string Attr5CreatedBy { get; set; }
public bool IsAttr5Active { get; set; }
public int Attr5SortOrder { get; set; }


public int Entry23Id { get; set; }
public string Entry23Name { get; set; }
public string Entry23Description { get; set; }
public DateTime Entry23CreatedAt { get; set; }
public DateTime? Entry23UpdatedAt { get; set; }
public string Entry23CreatedBy { get; set; }
public bool IsEntry23Active { get; set; }
public int Entry23SortOrder { get; set; }


public int Field31Id { get; set; }
public string Field31Name { get; set; }
public string Field31Description { get; set; }
public DateTime Field31CreatedAt { get; set; }
public DateTime? Field31UpdatedAt { get; set; }
public string Field31CreatedBy { get; set; }
public bool IsField31Active { get; set; }
public int Field31SortOrder { get; set; }


public int Item85Id { get; set; }
public string Item85Name { get; set; }
public string Item85Description { get; set; }
public DateTime Item85CreatedAt { get; set; }
public DateTime? Item85UpdatedAt { get; set; }
public string Item85CreatedBy { get; set; }
public bool IsItem85Active { get; set; }
public int Item85SortOrder { get; set; }


public int Attr31Id { get; set; }
public string Attr31Name { get; set; }
public string Attr31Description { get; set; }
public DateTime Attr31CreatedAt { get; set; }
public DateTime? Attr31UpdatedAt { get; set; }
public string Attr31CreatedBy { get; set; }
public bool IsAttr31Active { get; set; }
public int Attr31SortOrder { get; set; }


public int Entry94Id { get; set; }
public string Entry94Name { get; set; }
public string Entry94Description { get; set; }
public DateTime Entry94CreatedAt { get; set; }
public DateTime? Entry94UpdatedAt { get; set; }
public string Entry94CreatedBy { get; set; }
public bool IsEntry94Active { get; set; }
public int Entry94SortOrder { get; set; }


public int Field46Id { get; set; }
public string Field46Name { get; set; }
public string Field46Description { get; set; }
public DateTime Field46CreatedAt { get; set; }
public DateTime? Field46UpdatedAt { get; set; }
public string Field46CreatedBy { get; set; }
public bool IsField46Active { get; set; }
public int Field46SortOrder { get; set; }


public int Record53Id { get; set; }
public string Record53Name { get; set; }
public string Record53Description { get; set; }
public DateTime Record53CreatedAt { get; set; }
public DateTime? Record53UpdatedAt { get; set; }
public string Record53CreatedBy { get; set; }
public bool IsRecord53Active { get; set; }
public int Record53SortOrder { get; set; }


public int Field20Id { get; set; }
public string Field20Name { get; set; }
public string Field20Description { get; set; }
public DateTime Field20CreatedAt { get; set; }
public DateTime? Field20UpdatedAt { get; set; }
public string Field20CreatedBy { get; set; }
public bool IsField20Active { get; set; }
public int Field20SortOrder { get; set; }


public int Attr25Id { get; set; }
public string Attr25Name { get; set; }
public string Attr25Description { get; set; }
public DateTime Attr25CreatedAt { get; set; }
public DateTime? Attr25UpdatedAt { get; set; }
public string Attr25CreatedBy { get; set; }
public bool IsAttr25Active { get; set; }
public int Attr25SortOrder { get; set; }


public int Item17Id { get; set; }
public string Item17Name { get; set; }
public string Item17Description { get; set; }
public DateTime Item17CreatedAt { get; set; }
public DateTime? Item17UpdatedAt { get; set; }
public string Item17CreatedBy { get; set; }
public bool IsItem17Active { get; set; }
public int Item17SortOrder { get; set; }


public int Record47Id { get; set; }
public string Record47Name { get; set; }
public string Record47Description { get; set; }
public DateTime Record47CreatedAt { get; set; }
public DateTime? Record47UpdatedAt { get; set; }
public string Record47CreatedBy { get; set; }
public bool IsRecord47Active { get; set; }
public int Record47SortOrder { get; set; }


public int Attr18Id { get; set; }
public string Attr18Name { get; set; }
public string Attr18Description { get; set; }
public DateTime Attr18CreatedAt { get; set; }
public DateTime? Attr18UpdatedAt { get; set; }
public string Attr18CreatedBy { get; set; }
public bool IsAttr18Active { get; set; }
public int Attr18SortOrder { get; set; }


public int Detail42Id { get; set; }
public string Detail42Name { get; set; }
public string Detail42Description { get; set; }
public DateTime Detail42CreatedAt { get; set; }
public DateTime? Detail42UpdatedAt { get; set; }
public string Detail42CreatedBy { get; set; }
public bool IsDetail42Active { get; set; }
public int Detail42SortOrder { get; set; }


public int Entry13Id { get; set; }
public string Entry13Name { get; set; }
public string Entry13Description { get; set; }
public DateTime Entry13CreatedAt { get; set; }
public DateTime? Entry13UpdatedAt { get; set; }
public string Entry13CreatedBy { get; set; }
public bool IsEntry13Active { get; set; }
public int Entry13SortOrder { get; set; }


public int Param48Id { get; set; }
public string Param48Name { get; set; }
public string Param48Description { get; set; }
public DateTime Param48CreatedAt { get; set; }
public DateTime? Param48UpdatedAt { get; set; }
public string Param48CreatedBy { get; set; }
public bool IsParam48Active { get; set; }
public int Param48SortOrder { get; set; }


public int Param32Id { get; set; }
public string Param32Name { get; set; }
public string Param32Description { get; set; }
public DateTime Param32CreatedAt { get; set; }
public DateTime? Param32UpdatedAt { get; set; }
public string Param32CreatedBy { get; set; }
public bool IsParam32Active { get; set; }
public int Param32SortOrder { get; set; }

    }
}