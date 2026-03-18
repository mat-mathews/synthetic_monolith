using Admin.Shared310;
using Auth.Data;
using BatchJobs.Shared;
using Billing.Processors103;
using DataAccess.Events283;
using DataAccess.Validators409;
using Export.Models;
using Export.Models461;
using GalaxyWorks.Validators355;
using Imaging.Contracts89;
using Integration.Contracts290;
using Notifications.Service165;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Processors440;
using Workflow.Api148;
using Workflow.Service161;
using Workflow.Tests75;

namespace GalaxyWorks.Processors16
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer28
    {
        private readonly IAdmin_Shared310_Factory2 _iAdmin_Shared310_Factory2;
        private readonly Admin_Shared310_Provider10 _admin_Shared310_Provider10;
        private readonly Auth_Data_Controller3 _auth_Data_Controller3;
        private readonly DataAccess_Validators409_Repository6 _dataAccess_Validators409_Repository6;
        private readonly DataAccess_Validators409_Factory14 _dataAccess_Validators409_Factory14;
        private readonly Workflow_Service161_Controller10 _workflow_Service161_Controller10;
        private readonly Workflow_Service161_ViewModel8 _workflow_Service161_ViewModel8;
        private readonly Imaging_Contracts89_Service8 _imaging_Contracts89_Service8;

        public Consumer28(IAdmin_Shared310_Factory2 iAdmin_Shared310_Factory2, Admin_Shared310_Provider10 admin_Shared310_Provider10, Auth_Data_Controller3 auth_Data_Controller3, DataAccess_Validators409_Repository6 dataAccess_Validators409_Repository6, DataAccess_Validators409_Factory14 dataAccess_Validators409_Factory14, Workflow_Service161_Controller10 workflow_Service161_Controller10, Workflow_Service161_ViewModel8 workflow_Service161_ViewModel8, Imaging_Contracts89_Service8 imaging_Contracts89_Service8)
        {
            _iAdmin_Shared310_Factory2 = iAdmin_Shared310_Factory2 ?? throw new ArgumentNullException(nameof(iAdmin_Shared310_Factory2));
            _admin_Shared310_Provider10 = admin_Shared310_Provider10 ?? throw new ArgumentNullException(nameof(admin_Shared310_Provider10));
            _auth_Data_Controller3 = auth_Data_Controller3 ?? throw new ArgumentNullException(nameof(auth_Data_Controller3));
            _dataAccess_Validators409_Repository6 = dataAccess_Validators409_Repository6 ?? throw new ArgumentNullException(nameof(dataAccess_Validators409_Repository6));
            _dataAccess_Validators409_Factory14 = dataAccess_Validators409_Factory14 ?? throw new ArgumentNullException(nameof(dataAccess_Validators409_Factory14));
            _workflow_Service161_Controller10 = workflow_Service161_Controller10 ?? throw new ArgumentNullException(nameof(workflow_Service161_Controller10));
            _workflow_Service161_ViewModel8 = workflow_Service161_ViewModel8 ?? throw new ArgumentNullException(nameof(workflow_Service161_ViewModel8));
            _imaging_Contracts89_Service8 = imaging_Contracts89_Service8 ?? throw new ArgumentNullException(nameof(imaging_Contracts89_Service8));
        }

        public IAdmin_Shared310_Factory2 GetIAdmin_Shared310_Factory2() => _iAdmin_Shared310_Factory2;
        public Admin_Shared310_Provider10 GetAdmin_Shared310_Provider10() => _admin_Shared310_Provider10;
        public Auth_Data_Controller3 GetAuth_Data_Controller3() => _auth_Data_Controller3;
        public DataAccess_Validators409_Repository6 GetDataAccess_Validators409_Repository6() => _dataAccess_Validators409_Repository6;
        public DataAccess_Validators409_Factory14 GetDataAccess_Validators409_Factory14() => _dataAccess_Validators409_Factory14;
        public Workflow_Service161_Controller10 GetWorkflow_Service161_Controller10() => _workflow_Service161_Controller10;
        public Workflow_Service161_ViewModel8 GetWorkflow_Service161_ViewModel8() => _workflow_Service161_ViewModel8;
        public Imaging_Contracts89_Service8 GetImaging_Contracts89_Service8() => _imaging_Contracts89_Service8;

/// <summary>
/// Validates the Consumer28 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer28(Consumer28Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer28));
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
/// Processes the Consumer28 operation asynchronously.
/// </summary>
public async Task<Consumer28Result> ProcessConsumer28Async(
    Consumer28Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer28), request.Id);

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
            return new Consumer28Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer28));
        return new Consumer28Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer28));
        return new Consumer28Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer28 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer28Dto>> GetConsumer28ListAsync(
    Consumer28Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer28Entity>().AsQueryable();

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
        .Select(x => new Consumer28Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer28Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer28Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer28Service(
    ILogger<Consumer28Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer28:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer28 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer28Data> GetCachedConsumer28Async(string key)
{
    var cacheKey = $"Consumer28_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer28Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer28SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Field64Id { get; set; }
public string Field64Name { get; set; }
public string Field64Description { get; set; }
public DateTime Field64CreatedAt { get; set; }
public DateTime? Field64UpdatedAt { get; set; }
public string Field64CreatedBy { get; set; }
public bool IsField64Active { get; set; }
public int Field64SortOrder { get; set; }


public int Item71Id { get; set; }
public string Item71Name { get; set; }
public string Item71Description { get; set; }
public DateTime Item71CreatedAt { get; set; }
public DateTime? Item71UpdatedAt { get; set; }
public string Item71CreatedBy { get; set; }
public bool IsItem71Active { get; set; }
public int Item71SortOrder { get; set; }


public int Item41Id { get; set; }
public string Item41Name { get; set; }
public string Item41Description { get; set; }
public DateTime Item41CreatedAt { get; set; }
public DateTime? Item41UpdatedAt { get; set; }
public string Item41CreatedBy { get; set; }
public bool IsItem41Active { get; set; }
public int Item41SortOrder { get; set; }


public int Item42Id { get; set; }
public string Item42Name { get; set; }
public string Item42Description { get; set; }
public DateTime Item42CreatedAt { get; set; }
public DateTime? Item42UpdatedAt { get; set; }
public string Item42CreatedBy { get; set; }
public bool IsItem42Active { get; set; }
public int Item42SortOrder { get; set; }


public int Config69Id { get; set; }
public string Config69Name { get; set; }
public string Config69Description { get; set; }
public DateTime Config69CreatedAt { get; set; }
public DateTime? Config69UpdatedAt { get; set; }
public string Config69CreatedBy { get; set; }
public bool IsConfig69Active { get; set; }
public int Config69SortOrder { get; set; }


public int Detail84Id { get; set; }
public string Detail84Name { get; set; }
public string Detail84Description { get; set; }
public DateTime Detail84CreatedAt { get; set; }
public DateTime? Detail84UpdatedAt { get; set; }
public string Detail84CreatedBy { get; set; }
public bool IsDetail84Active { get; set; }
public int Detail84SortOrder { get; set; }


public int Param74Id { get; set; }
public string Param74Name { get; set; }
public string Param74Description { get; set; }
public DateTime Param74CreatedAt { get; set; }
public DateTime? Param74UpdatedAt { get; set; }
public string Param74CreatedBy { get; set; }
public bool IsParam74Active { get; set; }
public int Param74SortOrder { get; set; }


public int Field80Id { get; set; }
public string Field80Name { get; set; }
public string Field80Description { get; set; }
public DateTime Field80CreatedAt { get; set; }
public DateTime? Field80UpdatedAt { get; set; }
public string Field80CreatedBy { get; set; }
public bool IsField80Active { get; set; }
public int Field80SortOrder { get; set; }


public int Entry16Id { get; set; }
public string Entry16Name { get; set; }
public string Entry16Description { get; set; }
public DateTime Entry16CreatedAt { get; set; }
public DateTime? Entry16UpdatedAt { get; set; }
public string Entry16CreatedBy { get; set; }
public bool IsEntry16Active { get; set; }
public int Entry16SortOrder { get; set; }


public int Param45Id { get; set; }
public string Param45Name { get; set; }
public string Param45Description { get; set; }
public DateTime Param45CreatedAt { get; set; }
public DateTime? Param45UpdatedAt { get; set; }
public string Param45CreatedBy { get; set; }
public bool IsParam45Active { get; set; }
public int Param45SortOrder { get; set; }


public int Detail99Id { get; set; }
public string Detail99Name { get; set; }
public string Detail99Description { get; set; }
public DateTime Detail99CreatedAt { get; set; }
public DateTime? Detail99UpdatedAt { get; set; }
public string Detail99CreatedBy { get; set; }
public bool IsDetail99Active { get; set; }
public int Detail99SortOrder { get; set; }


public int Detail39Id { get; set; }
public string Detail39Name { get; set; }
public string Detail39Description { get; set; }
public DateTime Detail39CreatedAt { get; set; }
public DateTime? Detail39UpdatedAt { get; set; }
public string Detail39CreatedBy { get; set; }
public bool IsDetail39Active { get; set; }
public int Detail39SortOrder { get; set; }


public int Detail71Id { get; set; }
public string Detail71Name { get; set; }
public string Detail71Description { get; set; }
public DateTime Detail71CreatedAt { get; set; }
public DateTime? Detail71UpdatedAt { get; set; }
public string Detail71CreatedBy { get; set; }
public bool IsDetail71Active { get; set; }
public int Detail71SortOrder { get; set; }


public int Field71Id { get; set; }
public string Field71Name { get; set; }
public string Field71Description { get; set; }
public DateTime Field71CreatedAt { get; set; }
public DateTime? Field71UpdatedAt { get; set; }
public string Field71CreatedBy { get; set; }
public bool IsField71Active { get; set; }
public int Field71SortOrder { get; set; }


public int Attr62Id { get; set; }
public string Attr62Name { get; set; }
public string Attr62Description { get; set; }
public DateTime Attr62CreatedAt { get; set; }
public DateTime? Attr62UpdatedAt { get; set; }
public string Attr62CreatedBy { get; set; }
public bool IsAttr62Active { get; set; }
public int Attr62SortOrder { get; set; }


public int Field26Id { get; set; }
public string Field26Name { get; set; }
public string Field26Description { get; set; }
public DateTime Field26CreatedAt { get; set; }
public DateTime? Field26UpdatedAt { get; set; }
public string Field26CreatedBy { get; set; }
public bool IsField26Active { get; set; }
public int Field26SortOrder { get; set; }


public int Entry91Id { get; set; }
public string Entry91Name { get; set; }
public string Entry91Description { get; set; }
public DateTime Entry91CreatedAt { get; set; }
public DateTime? Entry91UpdatedAt { get; set; }
public string Entry91CreatedBy { get; set; }
public bool IsEntry91Active { get; set; }
public int Entry91SortOrder { get; set; }


public int Detail24Id { get; set; }
public string Detail24Name { get; set; }
public string Detail24Description { get; set; }
public DateTime Detail24CreatedAt { get; set; }
public DateTime? Detail24UpdatedAt { get; set; }
public string Detail24CreatedBy { get; set; }
public bool IsDetail24Active { get; set; }
public int Detail24SortOrder { get; set; }


public int Field78Id { get; set; }
public string Field78Name { get; set; }
public string Field78Description { get; set; }
public DateTime Field78CreatedAt { get; set; }
public DateTime? Field78UpdatedAt { get; set; }
public string Field78CreatedBy { get; set; }
public bool IsField78Active { get; set; }
public int Field78SortOrder { get; set; }


public int Param73Id { get; set; }
public string Param73Name { get; set; }
public string Param73Description { get; set; }
public DateTime Param73CreatedAt { get; set; }
public DateTime? Param73UpdatedAt { get; set; }
public string Param73CreatedBy { get; set; }
public bool IsParam73Active { get; set; }
public int Param73SortOrder { get; set; }


public int Record76Id { get; set; }
public string Record76Name { get; set; }
public string Record76Description { get; set; }
public DateTime Record76CreatedAt { get; set; }
public DateTime? Record76UpdatedAt { get; set; }
public string Record76CreatedBy { get; set; }
public bool IsRecord76Active { get; set; }
public int Record76SortOrder { get; set; }


public int Param44Id { get; set; }
public string Param44Name { get; set; }
public string Param44Description { get; set; }
public DateTime Param44CreatedAt { get; set; }
public DateTime? Param44UpdatedAt { get; set; }
public string Param44CreatedBy { get; set; }
public bool IsParam44Active { get; set; }
public int Param44SortOrder { get; set; }


public int Attr1Id { get; set; }
public string Attr1Name { get; set; }
public string Attr1Description { get; set; }
public DateTime Attr1CreatedAt { get; set; }
public DateTime? Attr1UpdatedAt { get; set; }
public string Attr1CreatedBy { get; set; }
public bool IsAttr1Active { get; set; }
public int Attr1SortOrder { get; set; }


public int Item7Id { get; set; }
public string Item7Name { get; set; }
public string Item7Description { get; set; }
public DateTime Item7CreatedAt { get; set; }
public DateTime? Item7UpdatedAt { get; set; }
public string Item7CreatedBy { get; set; }
public bool IsItem7Active { get; set; }
public int Item7SortOrder { get; set; }


public int Detail7Id { get; set; }
public string Detail7Name { get; set; }
public string Detail7Description { get; set; }
public DateTime Detail7CreatedAt { get; set; }
public DateTime? Detail7UpdatedAt { get; set; }
public string Detail7CreatedBy { get; set; }
public bool IsDetail7Active { get; set; }
public int Detail7SortOrder { get; set; }


public int Detail34Id { get; set; }
public string Detail34Name { get; set; }
public string Detail34Description { get; set; }
public DateTime Detail34CreatedAt { get; set; }
public DateTime? Detail34UpdatedAt { get; set; }
public string Detail34CreatedBy { get; set; }
public bool IsDetail34Active { get; set; }
public int Detail34SortOrder { get; set; }


public int Entry55Id { get; set; }
public string Entry55Name { get; set; }
public string Entry55Description { get; set; }
public DateTime Entry55CreatedAt { get; set; }
public DateTime? Entry55UpdatedAt { get; set; }
public string Entry55CreatedBy { get; set; }
public bool IsEntry55Active { get; set; }
public int Entry55SortOrder { get; set; }


public int Detail68Id { get; set; }
public string Detail68Name { get; set; }
public string Detail68Description { get; set; }
public DateTime Detail68CreatedAt { get; set; }
public DateTime? Detail68UpdatedAt { get; set; }
public string Detail68CreatedBy { get; set; }
public bool IsDetail68Active { get; set; }
public int Detail68SortOrder { get; set; }


public int Config19Id { get; set; }
public string Config19Name { get; set; }
public string Config19Description { get; set; }
public DateTime Config19CreatedAt { get; set; }
public DateTime? Config19UpdatedAt { get; set; }
public string Config19CreatedBy { get; set; }
public bool IsConfig19Active { get; set; }
public int Config19SortOrder { get; set; }


public int Record18Id { get; set; }
public string Record18Name { get; set; }
public string Record18Description { get; set; }
public DateTime Record18CreatedAt { get; set; }
public DateTime? Record18UpdatedAt { get; set; }
public string Record18CreatedBy { get; set; }
public bool IsRecord18Active { get; set; }
public int Record18SortOrder { get; set; }


public int Param67Id { get; set; }
public string Param67Name { get; set; }
public string Param67Description { get; set; }
public DateTime Param67CreatedAt { get; set; }
public DateTime? Param67UpdatedAt { get; set; }
public string Param67CreatedBy { get; set; }
public bool IsParam67Active { get; set; }
public int Param67SortOrder { get; set; }


public int Attr20Id { get; set; }
public string Attr20Name { get; set; }
public string Attr20Description { get; set; }
public DateTime Attr20CreatedAt { get; set; }
public DateTime? Attr20UpdatedAt { get; set; }
public string Attr20CreatedBy { get; set; }
public bool IsAttr20Active { get; set; }
public int Attr20SortOrder { get; set; }


public int Entry29Id { get; set; }
public string Entry29Name { get; set; }
public string Entry29Description { get; set; }
public DateTime Entry29CreatedAt { get; set; }
public DateTime? Entry29UpdatedAt { get; set; }
public string Entry29CreatedBy { get; set; }
public bool IsEntry29Active { get; set; }
public int Entry29SortOrder { get; set; }


public int Config88Id { get; set; }
public string Config88Name { get; set; }
public string Config88Description { get; set; }
public DateTime Config88CreatedAt { get; set; }
public DateTime? Config88UpdatedAt { get; set; }
public string Config88CreatedBy { get; set; }
public bool IsConfig88Active { get; set; }
public int Config88SortOrder { get; set; }


public int Param77Id { get; set; }
public string Param77Name { get; set; }
public string Param77Description { get; set; }
public DateTime Param77CreatedAt { get; set; }
public DateTime? Param77UpdatedAt { get; set; }
public string Param77CreatedBy { get; set; }
public bool IsParam77Active { get; set; }
public int Param77SortOrder { get; set; }


public int Entry90Id { get; set; }
public string Entry90Name { get; set; }
public string Entry90Description { get; set; }
public DateTime Entry90CreatedAt { get; set; }
public DateTime? Entry90UpdatedAt { get; set; }
public string Entry90CreatedBy { get; set; }
public bool IsEntry90Active { get; set; }
public int Entry90SortOrder { get; set; }


public int Item99Id { get; set; }
public string Item99Name { get; set; }
public string Item99Description { get; set; }
public DateTime Item99CreatedAt { get; set; }
public DateTime? Item99UpdatedAt { get; set; }
public string Item99CreatedBy { get; set; }
public bool IsItem99Active { get; set; }
public int Item99SortOrder { get; set; }


public int Config82Id { get; set; }
public string Config82Name { get; set; }
public string Config82Description { get; set; }
public DateTime Config82CreatedAt { get; set; }
public DateTime? Config82UpdatedAt { get; set; }
public string Config82CreatedBy { get; set; }
public bool IsConfig82Active { get; set; }
public int Config82SortOrder { get; set; }


public int Field11Id { get; set; }
public string Field11Name { get; set; }
public string Field11Description { get; set; }
public DateTime Field11CreatedAt { get; set; }
public DateTime? Field11UpdatedAt { get; set; }
public string Field11CreatedBy { get; set; }
public bool IsField11Active { get; set; }
public int Field11SortOrder { get; set; }


public int Config11Id { get; set; }
public string Config11Name { get; set; }
public string Config11Description { get; set; }
public DateTime Config11CreatedAt { get; set; }
public DateTime? Config11UpdatedAt { get; set; }
public string Config11CreatedBy { get; set; }
public bool IsConfig11Active { get; set; }
public int Config11SortOrder { get; set; }


public int Record94Id { get; set; }
public string Record94Name { get; set; }
public string Record94Description { get; set; }
public DateTime Record94CreatedAt { get; set; }
public DateTime? Record94UpdatedAt { get; set; }
public string Record94CreatedBy { get; set; }
public bool IsRecord94Active { get; set; }
public int Record94SortOrder { get; set; }


public int Field57Id { get; set; }
public string Field57Name { get; set; }
public string Field57Description { get; set; }
public DateTime Field57CreatedAt { get; set; }
public DateTime? Field57UpdatedAt { get; set; }
public string Field57CreatedBy { get; set; }
public bool IsField57Active { get; set; }
public int Field57SortOrder { get; set; }


public int Detail86Id { get; set; }
public string Detail86Name { get; set; }
public string Detail86Description { get; set; }
public DateTime Detail86CreatedAt { get; set; }
public DateTime? Detail86UpdatedAt { get; set; }
public string Detail86CreatedBy { get; set; }
public bool IsDetail86Active { get; set; }
public int Detail86SortOrder { get; set; }


public int Entry41Id { get; set; }
public string Entry41Name { get; set; }
public string Entry41Description { get; set; }
public DateTime Entry41CreatedAt { get; set; }
public DateTime? Entry41UpdatedAt { get; set; }
public string Entry41CreatedBy { get; set; }
public bool IsEntry41Active { get; set; }
public int Entry41SortOrder { get; set; }

    }
}