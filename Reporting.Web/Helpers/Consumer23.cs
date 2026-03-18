using Admin.Contracts;
using Admin.Events235;
using Admin.Validators336;
using Auth.Client38;
using Common.Validators;
using DataAccess.Tests282;
using GalaxyWorks.Core;
using GalaxyWorks.Events77;
using GalaxyWorks.Tests;
using Import.Handlers167;
using Integration.Handlers244;
using Integration.Service477;
using Logging.Models379;
using Notifications.Data348;
using Notifications.Handlers470;
using Reporting.Validators;
using Security.Processors246;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Processors;

namespace Reporting.Web
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer23
    {
        private readonly Admin_Validators336_Result4 _admin_Validators336_Result4;
        private readonly Admin_Validators336_Manager1 _admin_Validators336_Manager1;
        private readonly Admin_Validators336_Controller2 _admin_Validators336_Controller2;
        private readonly Admin_Contracts_Point4 _admin_Contracts_Point4;
        private readonly IAuth_Client38_Factory5 _iAuth_Client38_Factory5;
        private readonly Auth_Client38_Controller _auth_Client38_Controller;
        private readonly Logging_Models379_Controller1 _logging_Models379_Controller1;
        private readonly Logging_Models379_Info6 _logging_Models379_Info6;

        public Consumer23(Admin_Validators336_Result4 admin_Validators336_Result4, Admin_Validators336_Manager1 admin_Validators336_Manager1, Admin_Validators336_Controller2 admin_Validators336_Controller2, Admin_Contracts_Point4 admin_Contracts_Point4, IAuth_Client38_Factory5 iAuth_Client38_Factory5, Auth_Client38_Controller auth_Client38_Controller, Logging_Models379_Controller1 logging_Models379_Controller1, Logging_Models379_Info6 logging_Models379_Info6)
        {
            _admin_Validators336_Result4 = admin_Validators336_Result4 ?? throw new ArgumentNullException(nameof(admin_Validators336_Result4));
            _admin_Validators336_Manager1 = admin_Validators336_Manager1 ?? throw new ArgumentNullException(nameof(admin_Validators336_Manager1));
            _admin_Validators336_Controller2 = admin_Validators336_Controller2 ?? throw new ArgumentNullException(nameof(admin_Validators336_Controller2));
            _admin_Contracts_Point4 = admin_Contracts_Point4 ?? throw new ArgumentNullException(nameof(admin_Contracts_Point4));
            _iAuth_Client38_Factory5 = iAuth_Client38_Factory5 ?? throw new ArgumentNullException(nameof(iAuth_Client38_Factory5));
            _auth_Client38_Controller = auth_Client38_Controller ?? throw new ArgumentNullException(nameof(auth_Client38_Controller));
            _logging_Models379_Controller1 = logging_Models379_Controller1 ?? throw new ArgumentNullException(nameof(logging_Models379_Controller1));
            _logging_Models379_Info6 = logging_Models379_Info6 ?? throw new ArgumentNullException(nameof(logging_Models379_Info6));
        }

        public Admin_Validators336_Result4 GetAdmin_Validators336_Result4() => _admin_Validators336_Result4;
        public Admin_Validators336_Manager1 GetAdmin_Validators336_Manager1() => _admin_Validators336_Manager1;
        public Admin_Validators336_Controller2 GetAdmin_Validators336_Controller2() => _admin_Validators336_Controller2;
        public Admin_Contracts_Point4 GetAdmin_Contracts_Point4() => _admin_Contracts_Point4;
        public IAuth_Client38_Factory5 GetIAuth_Client38_Factory5() => _iAuth_Client38_Factory5;
        public Auth_Client38_Controller GetAuth_Client38_Controller() => _auth_Client38_Controller;
        public Logging_Models379_Controller1 GetLogging_Models379_Controller1() => _logging_Models379_Controller1;
        public Logging_Models379_Info6 GetLogging_Models379_Info6() => _logging_Models379_Info6;

/// <summary>
/// Validates the Consumer23 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer23(Consumer23Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer23));
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
/// Processes the Consumer23 operation asynchronously.
/// </summary>
public async Task<Consumer23Result> ProcessConsumer23Async(
    Consumer23Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer23), request.Id);

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
            return new Consumer23Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer23));
        return new Consumer23Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer23));
        return new Consumer23Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer23 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer23Dto>> GetConsumer23ListAsync(
    Consumer23Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer23Entity>().AsQueryable();

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
        .Select(x => new Consumer23Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer23Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer23Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer23Service(
    ILogger<Consumer23Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer23:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer23 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer23Data> GetCachedConsumer23Async(string key)
{
    var cacheKey = $"Consumer23_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer23Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer23SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Attr7Id { get; set; }
public string Attr7Name { get; set; }
public string Attr7Description { get; set; }
public DateTime Attr7CreatedAt { get; set; }
public DateTime? Attr7UpdatedAt { get; set; }
public string Attr7CreatedBy { get; set; }
public bool IsAttr7Active { get; set; }
public int Attr7SortOrder { get; set; }


public int Detail64Id { get; set; }
public string Detail64Name { get; set; }
public string Detail64Description { get; set; }
public DateTime Detail64CreatedAt { get; set; }
public DateTime? Detail64UpdatedAt { get; set; }
public string Detail64CreatedBy { get; set; }
public bool IsDetail64Active { get; set; }
public int Detail64SortOrder { get; set; }


public int Param66Id { get; set; }
public string Param66Name { get; set; }
public string Param66Description { get; set; }
public DateTime Param66CreatedAt { get; set; }
public DateTime? Param66UpdatedAt { get; set; }
public string Param66CreatedBy { get; set; }
public bool IsParam66Active { get; set; }
public int Param66SortOrder { get; set; }


public int Record22Id { get; set; }
public string Record22Name { get; set; }
public string Record22Description { get; set; }
public DateTime Record22CreatedAt { get; set; }
public DateTime? Record22UpdatedAt { get; set; }
public string Record22CreatedBy { get; set; }
public bool IsRecord22Active { get; set; }
public int Record22SortOrder { get; set; }


public int Detail84Id { get; set; }
public string Detail84Name { get; set; }
public string Detail84Description { get; set; }
public DateTime Detail84CreatedAt { get; set; }
public DateTime? Detail84UpdatedAt { get; set; }
public string Detail84CreatedBy { get; set; }
public bool IsDetail84Active { get; set; }
public int Detail84SortOrder { get; set; }


public int Item70Id { get; set; }
public string Item70Name { get; set; }
public string Item70Description { get; set; }
public DateTime Item70CreatedAt { get; set; }
public DateTime? Item70UpdatedAt { get; set; }
public string Item70CreatedBy { get; set; }
public bool IsItem70Active { get; set; }
public int Item70SortOrder { get; set; }


public int Param13Id { get; set; }
public string Param13Name { get; set; }
public string Param13Description { get; set; }
public DateTime Param13CreatedAt { get; set; }
public DateTime? Param13UpdatedAt { get; set; }
public string Param13CreatedBy { get; set; }
public bool IsParam13Active { get; set; }
public int Param13SortOrder { get; set; }


public int Param57Id { get; set; }
public string Param57Name { get; set; }
public string Param57Description { get; set; }
public DateTime Param57CreatedAt { get; set; }
public DateTime? Param57UpdatedAt { get; set; }
public string Param57CreatedBy { get; set; }
public bool IsParam57Active { get; set; }
public int Param57SortOrder { get; set; }


public int Detail38Id { get; set; }
public string Detail38Name { get; set; }
public string Detail38Description { get; set; }
public DateTime Detail38CreatedAt { get; set; }
public DateTime? Detail38UpdatedAt { get; set; }
public string Detail38CreatedBy { get; set; }
public bool IsDetail38Active { get; set; }
public int Detail38SortOrder { get; set; }


public int Item52Id { get; set; }
public string Item52Name { get; set; }
public string Item52Description { get; set; }
public DateTime Item52CreatedAt { get; set; }
public DateTime? Item52UpdatedAt { get; set; }
public string Item52CreatedBy { get; set; }
public bool IsItem52Active { get; set; }
public int Item52SortOrder { get; set; }


public int Record38Id { get; set; }
public string Record38Name { get; set; }
public string Record38Description { get; set; }
public DateTime Record38CreatedAt { get; set; }
public DateTime? Record38UpdatedAt { get; set; }
public string Record38CreatedBy { get; set; }
public bool IsRecord38Active { get; set; }
public int Record38SortOrder { get; set; }


public int Attr86Id { get; set; }
public string Attr86Name { get; set; }
public string Attr86Description { get; set; }
public DateTime Attr86CreatedAt { get; set; }
public DateTime? Attr86UpdatedAt { get; set; }
public string Attr86CreatedBy { get; set; }
public bool IsAttr86Active { get; set; }
public int Attr86SortOrder { get; set; }


public int Field61Id { get; set; }
public string Field61Name { get; set; }
public string Field61Description { get; set; }
public DateTime Field61CreatedAt { get; set; }
public DateTime? Field61UpdatedAt { get; set; }
public string Field61CreatedBy { get; set; }
public bool IsField61Active { get; set; }
public int Field61SortOrder { get; set; }


public int Record69Id { get; set; }
public string Record69Name { get; set; }
public string Record69Description { get; set; }
public DateTime Record69CreatedAt { get; set; }
public DateTime? Record69UpdatedAt { get; set; }
public string Record69CreatedBy { get; set; }
public bool IsRecord69Active { get; set; }
public int Record69SortOrder { get; set; }


public int Config8Id { get; set; }
public string Config8Name { get; set; }
public string Config8Description { get; set; }
public DateTime Config8CreatedAt { get; set; }
public DateTime? Config8UpdatedAt { get; set; }
public string Config8CreatedBy { get; set; }
public bool IsConfig8Active { get; set; }
public int Config8SortOrder { get; set; }


public int Entry24Id { get; set; }
public string Entry24Name { get; set; }
public string Entry24Description { get; set; }
public DateTime Entry24CreatedAt { get; set; }
public DateTime? Entry24UpdatedAt { get; set; }
public string Entry24CreatedBy { get; set; }
public bool IsEntry24Active { get; set; }
public int Entry24SortOrder { get; set; }


public int Record68Id { get; set; }
public string Record68Name { get; set; }
public string Record68Description { get; set; }
public DateTime Record68CreatedAt { get; set; }
public DateTime? Record68UpdatedAt { get; set; }
public string Record68CreatedBy { get; set; }
public bool IsRecord68Active { get; set; }
public int Record68SortOrder { get; set; }


public int Record39Id { get; set; }
public string Record39Name { get; set; }
public string Record39Description { get; set; }
public DateTime Record39CreatedAt { get; set; }
public DateTime? Record39UpdatedAt { get; set; }
public string Record39CreatedBy { get; set; }
public bool IsRecord39Active { get; set; }
public int Record39SortOrder { get; set; }


public int Entry73Id { get; set; }
public string Entry73Name { get; set; }
public string Entry73Description { get; set; }
public DateTime Entry73CreatedAt { get; set; }
public DateTime? Entry73UpdatedAt { get; set; }
public string Entry73CreatedBy { get; set; }
public bool IsEntry73Active { get; set; }
public int Entry73SortOrder { get; set; }


public int Param95Id { get; set; }
public string Param95Name { get; set; }
public string Param95Description { get; set; }
public DateTime Param95CreatedAt { get; set; }
public DateTime? Param95UpdatedAt { get; set; }
public string Param95CreatedBy { get; set; }
public bool IsParam95Active { get; set; }
public int Param95SortOrder { get; set; }


public int Field10Id { get; set; }
public string Field10Name { get; set; }
public string Field10Description { get; set; }
public DateTime Field10CreatedAt { get; set; }
public DateTime? Field10UpdatedAt { get; set; }
public string Field10CreatedBy { get; set; }
public bool IsField10Active { get; set; }
public int Field10SortOrder { get; set; }


public int Attr58Id { get; set; }
public string Attr58Name { get; set; }
public string Attr58Description { get; set; }
public DateTime Attr58CreatedAt { get; set; }
public DateTime? Attr58UpdatedAt { get; set; }
public string Attr58CreatedBy { get; set; }
public bool IsAttr58Active { get; set; }
public int Attr58SortOrder { get; set; }


public int Attr8Id { get; set; }
public string Attr8Name { get; set; }
public string Attr8Description { get; set; }
public DateTime Attr8CreatedAt { get; set; }
public DateTime? Attr8UpdatedAt { get; set; }
public string Attr8CreatedBy { get; set; }
public bool IsAttr8Active { get; set; }
public int Attr8SortOrder { get; set; }


public int Field83Id { get; set; }
public string Field83Name { get; set; }
public string Field83Description { get; set; }
public DateTime Field83CreatedAt { get; set; }
public DateTime? Field83UpdatedAt { get; set; }
public string Field83CreatedBy { get; set; }
public bool IsField83Active { get; set; }
public int Field83SortOrder { get; set; }


public int Entry8Id { get; set; }
public string Entry8Name { get; set; }
public string Entry8Description { get; set; }
public DateTime Entry8CreatedAt { get; set; }
public DateTime? Entry8UpdatedAt { get; set; }
public string Entry8CreatedBy { get; set; }
public bool IsEntry8Active { get; set; }
public int Entry8SortOrder { get; set; }


public int Attr20Id { get; set; }
public string Attr20Name { get; set; }
public string Attr20Description { get; set; }
public DateTime Attr20CreatedAt { get; set; }
public DateTime? Attr20UpdatedAt { get; set; }
public string Attr20CreatedBy { get; set; }
public bool IsAttr20Active { get; set; }
public int Attr20SortOrder { get; set; }


public int Field53Id { get; set; }
public string Field53Name { get; set; }
public string Field53Description { get; set; }
public DateTime Field53CreatedAt { get; set; }
public DateTime? Field53UpdatedAt { get; set; }
public string Field53CreatedBy { get; set; }
public bool IsField53Active { get; set; }
public int Field53SortOrder { get; set; }


public int Item27Id { get; set; }
public string Item27Name { get; set; }
public string Item27Description { get; set; }
public DateTime Item27CreatedAt { get; set; }
public DateTime? Item27UpdatedAt { get; set; }
public string Item27CreatedBy { get; set; }
public bool IsItem27Active { get; set; }
public int Item27SortOrder { get; set; }


public int Param64Id { get; set; }
public string Param64Name { get; set; }
public string Param64Description { get; set; }
public DateTime Param64CreatedAt { get; set; }
public DateTime? Param64UpdatedAt { get; set; }
public string Param64CreatedBy { get; set; }
public bool IsParam64Active { get; set; }
public int Param64SortOrder { get; set; }


public int Entry51Id { get; set; }
public string Entry51Name { get; set; }
public string Entry51Description { get; set; }
public DateTime Entry51CreatedAt { get; set; }
public DateTime? Entry51UpdatedAt { get; set; }
public string Entry51CreatedBy { get; set; }
public bool IsEntry51Active { get; set; }
public int Entry51SortOrder { get; set; }


public int Config49Id { get; set; }
public string Config49Name { get; set; }
public string Config49Description { get; set; }
public DateTime Config49CreatedAt { get; set; }
public DateTime? Config49UpdatedAt { get; set; }
public string Config49CreatedBy { get; set; }
public bool IsConfig49Active { get; set; }
public int Config49SortOrder { get; set; }


public int Config78Id { get; set; }
public string Config78Name { get; set; }
public string Config78Description { get; set; }
public DateTime Config78CreatedAt { get; set; }
public DateTime? Config78UpdatedAt { get; set; }
public string Config78CreatedBy { get; set; }
public bool IsConfig78Active { get; set; }
public int Config78SortOrder { get; set; }


public int Param59Id { get; set; }
public string Param59Name { get; set; }
public string Param59Description { get; set; }
public DateTime Param59CreatedAt { get; set; }
public DateTime? Param59UpdatedAt { get; set; }
public string Param59CreatedBy { get; set; }
public bool IsParam59Active { get; set; }
public int Param59SortOrder { get; set; }


public int Entry76Id { get; set; }
public string Entry76Name { get; set; }
public string Entry76Description { get; set; }
public DateTime Entry76CreatedAt { get; set; }
public DateTime? Entry76UpdatedAt { get; set; }
public string Entry76CreatedBy { get; set; }
public bool IsEntry76Active { get; set; }
public int Entry76SortOrder { get; set; }


public int Field93Id { get; set; }
public string Field93Name { get; set; }
public string Field93Description { get; set; }
public DateTime Field93CreatedAt { get; set; }
public DateTime? Field93UpdatedAt { get; set; }
public string Field93CreatedBy { get; set; }
public bool IsField93Active { get; set; }
public int Field93SortOrder { get; set; }


public int Record55Id { get; set; }
public string Record55Name { get; set; }
public string Record55Description { get; set; }
public DateTime Record55CreatedAt { get; set; }
public DateTime? Record55UpdatedAt { get; set; }
public string Record55CreatedBy { get; set; }
public bool IsRecord55Active { get; set; }
public int Record55SortOrder { get; set; }


public int Config21Id { get; set; }
public string Config21Name { get; set; }
public string Config21Description { get; set; }
public DateTime Config21CreatedAt { get; set; }
public DateTime? Config21UpdatedAt { get; set; }
public string Config21CreatedBy { get; set; }
public bool IsConfig21Active { get; set; }
public int Config21SortOrder { get; set; }


public int Item41Id { get; set; }
public string Item41Name { get; set; }
public string Item41Description { get; set; }
public DateTime Item41CreatedAt { get; set; }
public DateTime? Item41UpdatedAt { get; set; }
public string Item41CreatedBy { get; set; }
public bool IsItem41Active { get; set; }
public int Item41SortOrder { get; set; }


public int Detail85Id { get; set; }
public string Detail85Name { get; set; }
public string Detail85Description { get; set; }
public DateTime Detail85CreatedAt { get; set; }
public DateTime? Detail85UpdatedAt { get; set; }
public string Detail85CreatedBy { get; set; }
public bool IsDetail85Active { get; set; }
public int Detail85SortOrder { get; set; }


public int Detail70Id { get; set; }
public string Detail70Name { get; set; }
public string Detail70Description { get; set; }
public DateTime Detail70CreatedAt { get; set; }
public DateTime? Detail70UpdatedAt { get; set; }
public string Detail70CreatedBy { get; set; }
public bool IsDetail70Active { get; set; }
public int Detail70SortOrder { get; set; }


public int Item72Id { get; set; }
public string Item72Name { get; set; }
public string Item72Description { get; set; }
public DateTime Item72CreatedAt { get; set; }
public DateTime? Item72UpdatedAt { get; set; }
public string Item72CreatedBy { get; set; }
public bool IsItem72Active { get; set; }
public int Item72SortOrder { get; set; }


public int Config67Id { get; set; }
public string Config67Name { get; set; }
public string Config67Description { get; set; }
public DateTime Config67CreatedAt { get; set; }
public DateTime? Config67UpdatedAt { get; set; }
public string Config67CreatedBy { get; set; }
public bool IsConfig67Active { get; set; }
public int Config67SortOrder { get; set; }


public int Detail1Id { get; set; }
public string Detail1Name { get; set; }
public string Detail1Description { get; set; }
public DateTime Detail1CreatedAt { get; set; }
public DateTime? Detail1UpdatedAt { get; set; }
public string Detail1CreatedBy { get; set; }
public bool IsDetail1Active { get; set; }
public int Detail1SortOrder { get; set; }


public int Record14Id { get; set; }
public string Record14Name { get; set; }
public string Record14Description { get; set; }
public DateTime Record14CreatedAt { get; set; }
public DateTime? Record14UpdatedAt { get; set; }
public string Record14CreatedBy { get; set; }
public bool IsRecord14Active { get; set; }
public int Record14SortOrder { get; set; }


public int Param93Id { get; set; }
public string Param93Name { get; set; }
public string Param93Description { get; set; }
public DateTime Param93CreatedAt { get; set; }
public DateTime? Param93UpdatedAt { get; set; }
public string Param93CreatedBy { get; set; }
public bool IsParam93Active { get; set; }
public int Param93SortOrder { get; set; }

    }
}