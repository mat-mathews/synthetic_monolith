using Admin.Events306;
using Admin.Handlers;
using Admin.Models199;
using BatchJobs.Api;
using Billing.Events;
using Common.Service258;
using GalaxyWorks.Web;
using Imaging.Models459;
using Import.Tests;
using Integration.Processors248;
using Notifications.Mappers110;
using Portal.Events151;
using Portal.Validators;
using Scheduling.Events;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Processors;

namespace Common.Shared95
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer17
    {
        private readonly Admin_Handlers_Provider13 _admin_Handlers_Provider13;
        private readonly Admin_Handlers_Factory5 _admin_Handlers_Factory5;
        private readonly IAdmin_Handlers_Handler11 _iAdmin_Handlers_Handler11;
        private readonly Admin_Models199_Dto _admin_Models199_Dto;
        private readonly IBatchJobs_Api_Factory3 _iBatchJobs_Api_Factory3;
        private readonly Billing_Events_Service5 _billing_Events_Service5;
        private readonly Import_Tests_Dto1 _import_Tests_Dto1;
        private readonly Import_Tests_Handler5 _import_Tests_Handler5;

        public Consumer17(Admin_Handlers_Provider13 admin_Handlers_Provider13, Admin_Handlers_Factory5 admin_Handlers_Factory5, IAdmin_Handlers_Handler11 iAdmin_Handlers_Handler11, Admin_Models199_Dto admin_Models199_Dto, IBatchJobs_Api_Factory3 iBatchJobs_Api_Factory3, Billing_Events_Service5 billing_Events_Service5, Import_Tests_Dto1 import_Tests_Dto1, Import_Tests_Handler5 import_Tests_Handler5)
        {
            _admin_Handlers_Provider13 = admin_Handlers_Provider13 ?? throw new ArgumentNullException(nameof(admin_Handlers_Provider13));
            _admin_Handlers_Factory5 = admin_Handlers_Factory5 ?? throw new ArgumentNullException(nameof(admin_Handlers_Factory5));
            _iAdmin_Handlers_Handler11 = iAdmin_Handlers_Handler11 ?? throw new ArgumentNullException(nameof(iAdmin_Handlers_Handler11));
            _admin_Models199_Dto = admin_Models199_Dto ?? throw new ArgumentNullException(nameof(admin_Models199_Dto));
            _iBatchJobs_Api_Factory3 = iBatchJobs_Api_Factory3 ?? throw new ArgumentNullException(nameof(iBatchJobs_Api_Factory3));
            _billing_Events_Service5 = billing_Events_Service5 ?? throw new ArgumentNullException(nameof(billing_Events_Service5));
            _import_Tests_Dto1 = import_Tests_Dto1 ?? throw new ArgumentNullException(nameof(import_Tests_Dto1));
            _import_Tests_Handler5 = import_Tests_Handler5 ?? throw new ArgumentNullException(nameof(import_Tests_Handler5));
        }

        public Admin_Handlers_Provider13 GetAdmin_Handlers_Provider13() => _admin_Handlers_Provider13;
        public Admin_Handlers_Factory5 GetAdmin_Handlers_Factory5() => _admin_Handlers_Factory5;
        public IAdmin_Handlers_Handler11 GetIAdmin_Handlers_Handler11() => _iAdmin_Handlers_Handler11;
        public Admin_Models199_Dto GetAdmin_Models199_Dto() => _admin_Models199_Dto;
        public IBatchJobs_Api_Factory3 GetIBatchJobs_Api_Factory3() => _iBatchJobs_Api_Factory3;
        public Billing_Events_Service5 GetBilling_Events_Service5() => _billing_Events_Service5;
        public Import_Tests_Dto1 GetImport_Tests_Dto1() => _import_Tests_Dto1;
        public Import_Tests_Handler5 GetImport_Tests_Handler5() => _import_Tests_Handler5;

/// <summary>
/// Validates the Consumer17 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer17(Consumer17Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer17));
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
/// Processes the Consumer17 operation asynchronously.
/// </summary>
public async Task<Consumer17Result> ProcessConsumer17Async(
    Consumer17Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer17), request.Id);

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
            return new Consumer17Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer17));
        return new Consumer17Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer17));
        return new Consumer17Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer17 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer17Dto>> GetConsumer17ListAsync(
    Consumer17Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer17Entity>().AsQueryable();

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
        .Select(x => new Consumer17Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer17Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer17Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer17Service(
    ILogger<Consumer17Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer17:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer17 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer17Data> GetCachedConsumer17Async(string key)
{
    var cacheKey = $"Consumer17_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer17Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer17SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Attr57Id { get; set; }
public string Attr57Name { get; set; }
public string Attr57Description { get; set; }
public DateTime Attr57CreatedAt { get; set; }
public DateTime? Attr57UpdatedAt { get; set; }
public string Attr57CreatedBy { get; set; }
public bool IsAttr57Active { get; set; }
public int Attr57SortOrder { get; set; }


public int Detail62Id { get; set; }
public string Detail62Name { get; set; }
public string Detail62Description { get; set; }
public DateTime Detail62CreatedAt { get; set; }
public DateTime? Detail62UpdatedAt { get; set; }
public string Detail62CreatedBy { get; set; }
public bool IsDetail62Active { get; set; }
public int Detail62SortOrder { get; set; }


public int Detail64Id { get; set; }
public string Detail64Name { get; set; }
public string Detail64Description { get; set; }
public DateTime Detail64CreatedAt { get; set; }
public DateTime? Detail64UpdatedAt { get; set; }
public string Detail64CreatedBy { get; set; }
public bool IsDetail64Active { get; set; }
public int Detail64SortOrder { get; set; }


public int Field84Id { get; set; }
public string Field84Name { get; set; }
public string Field84Description { get; set; }
public DateTime Field84CreatedAt { get; set; }
public DateTime? Field84UpdatedAt { get; set; }
public string Field84CreatedBy { get; set; }
public bool IsField84Active { get; set; }
public int Field84SortOrder { get; set; }


public int Detail21Id { get; set; }
public string Detail21Name { get; set; }
public string Detail21Description { get; set; }
public DateTime Detail21CreatedAt { get; set; }
public DateTime? Detail21UpdatedAt { get; set; }
public string Detail21CreatedBy { get; set; }
public bool IsDetail21Active { get; set; }
public int Detail21SortOrder { get; set; }


public int Attr94Id { get; set; }
public string Attr94Name { get; set; }
public string Attr94Description { get; set; }
public DateTime Attr94CreatedAt { get; set; }
public DateTime? Attr94UpdatedAt { get; set; }
public string Attr94CreatedBy { get; set; }
public bool IsAttr94Active { get; set; }
public int Attr94SortOrder { get; set; }


public int Field44Id { get; set; }
public string Field44Name { get; set; }
public string Field44Description { get; set; }
public DateTime Field44CreatedAt { get; set; }
public DateTime? Field44UpdatedAt { get; set; }
public string Field44CreatedBy { get; set; }
public bool IsField44Active { get; set; }
public int Field44SortOrder { get; set; }


public int Detail95Id { get; set; }
public string Detail95Name { get; set; }
public string Detail95Description { get; set; }
public DateTime Detail95CreatedAt { get; set; }
public DateTime? Detail95UpdatedAt { get; set; }
public string Detail95CreatedBy { get; set; }
public bool IsDetail95Active { get; set; }
public int Detail95SortOrder { get; set; }


public int Item49Id { get; set; }
public string Item49Name { get; set; }
public string Item49Description { get; set; }
public DateTime Item49CreatedAt { get; set; }
public DateTime? Item49UpdatedAt { get; set; }
public string Item49CreatedBy { get; set; }
public bool IsItem49Active { get; set; }
public int Item49SortOrder { get; set; }


public int Field65Id { get; set; }
public string Field65Name { get; set; }
public string Field65Description { get; set; }
public DateTime Field65CreatedAt { get; set; }
public DateTime? Field65UpdatedAt { get; set; }
public string Field65CreatedBy { get; set; }
public bool IsField65Active { get; set; }
public int Field65SortOrder { get; set; }


public int Attr60Id { get; set; }
public string Attr60Name { get; set; }
public string Attr60Description { get; set; }
public DateTime Attr60CreatedAt { get; set; }
public DateTime? Attr60UpdatedAt { get; set; }
public string Attr60CreatedBy { get; set; }
public bool IsAttr60Active { get; set; }
public int Attr60SortOrder { get; set; }


public int Record4Id { get; set; }
public string Record4Name { get; set; }
public string Record4Description { get; set; }
public DateTime Record4CreatedAt { get; set; }
public DateTime? Record4UpdatedAt { get; set; }
public string Record4CreatedBy { get; set; }
public bool IsRecord4Active { get; set; }
public int Record4SortOrder { get; set; }


public int Record65Id { get; set; }
public string Record65Name { get; set; }
public string Record65Description { get; set; }
public DateTime Record65CreatedAt { get; set; }
public DateTime? Record65UpdatedAt { get; set; }
public string Record65CreatedBy { get; set; }
public bool IsRecord65Active { get; set; }
public int Record65SortOrder { get; set; }


public int Item7Id { get; set; }
public string Item7Name { get; set; }
public string Item7Description { get; set; }
public DateTime Item7CreatedAt { get; set; }
public DateTime? Item7UpdatedAt { get; set; }
public string Item7CreatedBy { get; set; }
public bool IsItem7Active { get; set; }
public int Item7SortOrder { get; set; }


public int Field82Id { get; set; }
public string Field82Name { get; set; }
public string Field82Description { get; set; }
public DateTime Field82CreatedAt { get; set; }
public DateTime? Field82UpdatedAt { get; set; }
public string Field82CreatedBy { get; set; }
public bool IsField82Active { get; set; }
public int Field82SortOrder { get; set; }


public int Record19Id { get; set; }
public string Record19Name { get; set; }
public string Record19Description { get; set; }
public DateTime Record19CreatedAt { get; set; }
public DateTime? Record19UpdatedAt { get; set; }
public string Record19CreatedBy { get; set; }
public bool IsRecord19Active { get; set; }
public int Record19SortOrder { get; set; }


public int Field49Id { get; set; }
public string Field49Name { get; set; }
public string Field49Description { get; set; }
public DateTime Field49CreatedAt { get; set; }
public DateTime? Field49UpdatedAt { get; set; }
public string Field49CreatedBy { get; set; }
public bool IsField49Active { get; set; }
public int Field49SortOrder { get; set; }


public int Param32Id { get; set; }
public string Param32Name { get; set; }
public string Param32Description { get; set; }
public DateTime Param32CreatedAt { get; set; }
public DateTime? Param32UpdatedAt { get; set; }
public string Param32CreatedBy { get; set; }
public bool IsParam32Active { get; set; }
public int Param32SortOrder { get; set; }


public int Record54Id { get; set; }
public string Record54Name { get; set; }
public string Record54Description { get; set; }
public DateTime Record54CreatedAt { get; set; }
public DateTime? Record54UpdatedAt { get; set; }
public string Record54CreatedBy { get; set; }
public bool IsRecord54Active { get; set; }
public int Record54SortOrder { get; set; }


public int Attr81Id { get; set; }
public string Attr81Name { get; set; }
public string Attr81Description { get; set; }
public DateTime Attr81CreatedAt { get; set; }
public DateTime? Attr81UpdatedAt { get; set; }
public string Attr81CreatedBy { get; set; }
public bool IsAttr81Active { get; set; }
public int Attr81SortOrder { get; set; }


public int Entry28Id { get; set; }
public string Entry28Name { get; set; }
public string Entry28Description { get; set; }
public DateTime Entry28CreatedAt { get; set; }
public DateTime? Entry28UpdatedAt { get; set; }
public string Entry28CreatedBy { get; set; }
public bool IsEntry28Active { get; set; }
public int Entry28SortOrder { get; set; }


public int Record39Id { get; set; }
public string Record39Name { get; set; }
public string Record39Description { get; set; }
public DateTime Record39CreatedAt { get; set; }
public DateTime? Record39UpdatedAt { get; set; }
public string Record39CreatedBy { get; set; }
public bool IsRecord39Active { get; set; }
public int Record39SortOrder { get; set; }


public int Entry62Id { get; set; }
public string Entry62Name { get; set; }
public string Entry62Description { get; set; }
public DateTime Entry62CreatedAt { get; set; }
public DateTime? Entry62UpdatedAt { get; set; }
public string Entry62CreatedBy { get; set; }
public bool IsEntry62Active { get; set; }
public int Entry62SortOrder { get; set; }


public int Attr26Id { get; set; }
public string Attr26Name { get; set; }
public string Attr26Description { get; set; }
public DateTime Attr26CreatedAt { get; set; }
public DateTime? Attr26UpdatedAt { get; set; }
public string Attr26CreatedBy { get; set; }
public bool IsAttr26Active { get; set; }
public int Attr26SortOrder { get; set; }


public int Item59Id { get; set; }
public string Item59Name { get; set; }
public string Item59Description { get; set; }
public DateTime Item59CreatedAt { get; set; }
public DateTime? Item59UpdatedAt { get; set; }
public string Item59CreatedBy { get; set; }
public bool IsItem59Active { get; set; }
public int Item59SortOrder { get; set; }


public int Entry97Id { get; set; }
public string Entry97Name { get; set; }
public string Entry97Description { get; set; }
public DateTime Entry97CreatedAt { get; set; }
public DateTime? Entry97UpdatedAt { get; set; }
public string Entry97CreatedBy { get; set; }
public bool IsEntry97Active { get; set; }
public int Entry97SortOrder { get; set; }


public int Record68Id { get; set; }
public string Record68Name { get; set; }
public string Record68Description { get; set; }
public DateTime Record68CreatedAt { get; set; }
public DateTime? Record68UpdatedAt { get; set; }
public string Record68CreatedBy { get; set; }
public bool IsRecord68Active { get; set; }
public int Record68SortOrder { get; set; }


public int Record73Id { get; set; }
public string Record73Name { get; set; }
public string Record73Description { get; set; }
public DateTime Record73CreatedAt { get; set; }
public DateTime? Record73UpdatedAt { get; set; }
public string Record73CreatedBy { get; set; }
public bool IsRecord73Active { get; set; }
public int Record73SortOrder { get; set; }


public int Field9Id { get; set; }
public string Field9Name { get; set; }
public string Field9Description { get; set; }
public DateTime Field9CreatedAt { get; set; }
public DateTime? Field9UpdatedAt { get; set; }
public string Field9CreatedBy { get; set; }
public bool IsField9Active { get; set; }
public int Field9SortOrder { get; set; }


public int Item93Id { get; set; }
public string Item93Name { get; set; }
public string Item93Description { get; set; }
public DateTime Item93CreatedAt { get; set; }
public DateTime? Item93UpdatedAt { get; set; }
public string Item93CreatedBy { get; set; }
public bool IsItem93Active { get; set; }
public int Item93SortOrder { get; set; }


public int Record72Id { get; set; }
public string Record72Name { get; set; }
public string Record72Description { get; set; }
public DateTime Record72CreatedAt { get; set; }
public DateTime? Record72UpdatedAt { get; set; }
public string Record72CreatedBy { get; set; }
public bool IsRecord72Active { get; set; }
public int Record72SortOrder { get; set; }


public int Attr41Id { get; set; }
public string Attr41Name { get; set; }
public string Attr41Description { get; set; }
public DateTime Attr41CreatedAt { get; set; }
public DateTime? Attr41UpdatedAt { get; set; }
public string Attr41CreatedBy { get; set; }
public bool IsAttr41Active { get; set; }
public int Attr41SortOrder { get; set; }


public int Param67Id { get; set; }
public string Param67Name { get; set; }
public string Param67Description { get; set; }
public DateTime Param67CreatedAt { get; set; }
public DateTime? Param67UpdatedAt { get; set; }
public string Param67CreatedBy { get; set; }
public bool IsParam67Active { get; set; }
public int Param67SortOrder { get; set; }


public int Field19Id { get; set; }
public string Field19Name { get; set; }
public string Field19Description { get; set; }
public DateTime Field19CreatedAt { get; set; }
public DateTime? Field19UpdatedAt { get; set; }
public string Field19CreatedBy { get; set; }
public bool IsField19Active { get; set; }
public int Field19SortOrder { get; set; }


public int Detail13Id { get; set; }
public string Detail13Name { get; set; }
public string Detail13Description { get; set; }
public DateTime Detail13CreatedAt { get; set; }
public DateTime? Detail13UpdatedAt { get; set; }
public string Detail13CreatedBy { get; set; }
public bool IsDetail13Active { get; set; }
public int Detail13SortOrder { get; set; }


public int Item32Id { get; set; }
public string Item32Name { get; set; }
public string Item32Description { get; set; }
public DateTime Item32CreatedAt { get; set; }
public DateTime? Item32UpdatedAt { get; set; }
public string Item32CreatedBy { get; set; }
public bool IsItem32Active { get; set; }
public int Item32SortOrder { get; set; }


public int Record60Id { get; set; }
public string Record60Name { get; set; }
public string Record60Description { get; set; }
public DateTime Record60CreatedAt { get; set; }
public DateTime? Record60UpdatedAt { get; set; }
public string Record60CreatedBy { get; set; }
public bool IsRecord60Active { get; set; }
public int Record60SortOrder { get; set; }


public int Detail44Id { get; set; }
public string Detail44Name { get; set; }
public string Detail44Description { get; set; }
public DateTime Detail44CreatedAt { get; set; }
public DateTime? Detail44UpdatedAt { get; set; }
public string Detail44CreatedBy { get; set; }
public bool IsDetail44Active { get; set; }
public int Detail44SortOrder { get; set; }


public int Config88Id { get; set; }
public string Config88Name { get; set; }
public string Config88Description { get; set; }
public DateTime Config88CreatedAt { get; set; }
public DateTime? Config88UpdatedAt { get; set; }
public string Config88CreatedBy { get; set; }
public bool IsConfig88Active { get; set; }
public int Config88SortOrder { get; set; }


public int Entry39Id { get; set; }
public string Entry39Name { get; set; }
public string Entry39Description { get; set; }
public DateTime Entry39CreatedAt { get; set; }
public DateTime? Entry39UpdatedAt { get; set; }
public string Entry39CreatedBy { get; set; }
public bool IsEntry39Active { get; set; }
public int Entry39SortOrder { get; set; }


public int Record71Id { get; set; }
public string Record71Name { get; set; }
public string Record71Description { get; set; }
public DateTime Record71CreatedAt { get; set; }
public DateTime? Record71UpdatedAt { get; set; }
public string Record71CreatedBy { get; set; }
public bool IsRecord71Active { get; set; }
public int Record71SortOrder { get; set; }


public int Config54Id { get; set; }
public string Config54Name { get; set; }
public string Config54Description { get; set; }
public DateTime Config54CreatedAt { get; set; }
public DateTime? Config54UpdatedAt { get; set; }
public string Config54CreatedBy { get; set; }
public bool IsConfig54Active { get; set; }
public int Config54SortOrder { get; set; }


public int Config31Id { get; set; }
public string Config31Name { get; set; }
public string Config31Description { get; set; }
public DateTime Config31CreatedAt { get; set; }
public DateTime? Config31UpdatedAt { get; set; }
public string Config31CreatedBy { get; set; }
public bool IsConfig31Active { get; set; }
public int Config31SortOrder { get; set; }


public int Record13Id { get; set; }
public string Record13Name { get; set; }
public string Record13Description { get; set; }
public DateTime Record13CreatedAt { get; set; }
public DateTime? Record13UpdatedAt { get; set; }
public string Record13CreatedBy { get; set; }
public bool IsRecord13Active { get; set; }
public int Record13SortOrder { get; set; }


public int Detail92Id { get; set; }
public string Detail92Name { get; set; }
public string Detail92Description { get; set; }
public DateTime Detail92CreatedAt { get; set; }
public DateTime? Detail92UpdatedAt { get; set; }
public string Detail92CreatedBy { get; set; }
public bool IsDetail92Active { get; set; }
public int Detail92SortOrder { get; set; }


public int Item3Id { get; set; }
public string Item3Name { get; set; }
public string Item3Description { get; set; }
public DateTime Item3CreatedAt { get; set; }
public DateTime? Item3UpdatedAt { get; set; }
public string Item3CreatedBy { get; set; }
public bool IsItem3Active { get; set; }
public int Item3SortOrder { get; set; }

    }
}