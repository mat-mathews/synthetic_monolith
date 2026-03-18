using Admin.Mappers324;
using Auth.Api143;
using Auth.Models;
using BatchJobs.Processors500;
using Billing.Processors;
using Common.Validators;
using DataAccess.Contracts;
using Export.Models461;
using GalaxyWorks.Mappers318;
using Import.Core;
using Integration.Service477;
using Reporting.Api287;
using Reporting.Client146;
using Reporting.Events483;
using Scheduling.Events;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Contracts192;
using Workflow.Contracts434;

namespace Scheduling.Web264
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer14
    {
        private readonly Auth_Models_Builder7 _auth_Models_Builder7;
        private readonly Admin_Mappers324_Repository8 _admin_Mappers324_Repository8;
        private readonly Admin_Mappers324_Key9 _admin_Mappers324_Key9;
        private readonly Admin_Mappers324_Provider1 _admin_Mappers324_Provider1;
        private readonly IAuth_Api143_Service6 _iAuth_Api143_Service6;
        private readonly IAuth_Api143_Factory _iAuth_Api143_Factory;
        private readonly Security_Validators217_Repository10 _security_Validators217_Repository10;
        private readonly Export_Models461_Manager5 _export_Models461_Manager5;

        public Consumer14(Auth_Models_Builder7 auth_Models_Builder7, Admin_Mappers324_Repository8 admin_Mappers324_Repository8, Admin_Mappers324_Key9 admin_Mappers324_Key9, Admin_Mappers324_Provider1 admin_Mappers324_Provider1, IAuth_Api143_Service6 iAuth_Api143_Service6, IAuth_Api143_Factory iAuth_Api143_Factory, Security_Validators217_Repository10 security_Validators217_Repository10, Export_Models461_Manager5 export_Models461_Manager5)
        {
            _auth_Models_Builder7 = auth_Models_Builder7 ?? throw new ArgumentNullException(nameof(auth_Models_Builder7));
            _admin_Mappers324_Repository8 = admin_Mappers324_Repository8 ?? throw new ArgumentNullException(nameof(admin_Mappers324_Repository8));
            _admin_Mappers324_Key9 = admin_Mappers324_Key9 ?? throw new ArgumentNullException(nameof(admin_Mappers324_Key9));
            _admin_Mappers324_Provider1 = admin_Mappers324_Provider1 ?? throw new ArgumentNullException(nameof(admin_Mappers324_Provider1));
            _iAuth_Api143_Service6 = iAuth_Api143_Service6 ?? throw new ArgumentNullException(nameof(iAuth_Api143_Service6));
            _iAuth_Api143_Factory = iAuth_Api143_Factory ?? throw new ArgumentNullException(nameof(iAuth_Api143_Factory));
            _security_Validators217_Repository10 = security_Validators217_Repository10 ?? throw new ArgumentNullException(nameof(security_Validators217_Repository10));
            _export_Models461_Manager5 = export_Models461_Manager5 ?? throw new ArgumentNullException(nameof(export_Models461_Manager5));
        }

        public Auth_Models_Builder7 GetAuth_Models_Builder7() => _auth_Models_Builder7;
        public Admin_Mappers324_Repository8 GetAdmin_Mappers324_Repository8() => _admin_Mappers324_Repository8;
        public Admin_Mappers324_Key9 GetAdmin_Mappers324_Key9() => _admin_Mappers324_Key9;
        public Admin_Mappers324_Provider1 GetAdmin_Mappers324_Provider1() => _admin_Mappers324_Provider1;
        public IAuth_Api143_Service6 GetIAuth_Api143_Service6() => _iAuth_Api143_Service6;
        public IAuth_Api143_Factory GetIAuth_Api143_Factory() => _iAuth_Api143_Factory;
        public Security_Validators217_Repository10 GetSecurity_Validators217_Repository10() => _security_Validators217_Repository10;
        public Export_Models461_Manager5 GetExport_Models461_Manager5() => _export_Models461_Manager5;

/// <summary>
/// Validates the Consumer14 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer14(Consumer14Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer14));
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
/// Processes the Consumer14 operation asynchronously.
/// </summary>
public async Task<Consumer14Result> ProcessConsumer14Async(
    Consumer14Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer14), request.Id);

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
            return new Consumer14Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer14));
        return new Consumer14Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer14));
        return new Consumer14Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer14 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer14Dto>> GetConsumer14ListAsync(
    Consumer14Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer14Entity>().AsQueryable();

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
        .Select(x => new Consumer14Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer14Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer14Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer14Service(
    ILogger<Consumer14Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer14:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer14 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer14Data> GetCachedConsumer14Async(string key)
{
    var cacheKey = $"Consumer14_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer14Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer14SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Param32Id { get; set; }
public string Param32Name { get; set; }
public string Param32Description { get; set; }
public DateTime Param32CreatedAt { get; set; }
public DateTime? Param32UpdatedAt { get; set; }
public string Param32CreatedBy { get; set; }
public bool IsParam32Active { get; set; }
public int Param32SortOrder { get; set; }


public int Entry1Id { get; set; }
public string Entry1Name { get; set; }
public string Entry1Description { get; set; }
public DateTime Entry1CreatedAt { get; set; }
public DateTime? Entry1UpdatedAt { get; set; }
public string Entry1CreatedBy { get; set; }
public bool IsEntry1Active { get; set; }
public int Entry1SortOrder { get; set; }


public int Field81Id { get; set; }
public string Field81Name { get; set; }
public string Field81Description { get; set; }
public DateTime Field81CreatedAt { get; set; }
public DateTime? Field81UpdatedAt { get; set; }
public string Field81CreatedBy { get; set; }
public bool IsField81Active { get; set; }
public int Field81SortOrder { get; set; }


public int Attr16Id { get; set; }
public string Attr16Name { get; set; }
public string Attr16Description { get; set; }
public DateTime Attr16CreatedAt { get; set; }
public DateTime? Attr16UpdatedAt { get; set; }
public string Attr16CreatedBy { get; set; }
public bool IsAttr16Active { get; set; }
public int Attr16SortOrder { get; set; }


public int Attr22Id { get; set; }
public string Attr22Name { get; set; }
public string Attr22Description { get; set; }
public DateTime Attr22CreatedAt { get; set; }
public DateTime? Attr22UpdatedAt { get; set; }
public string Attr22CreatedBy { get; set; }
public bool IsAttr22Active { get; set; }
public int Attr22SortOrder { get; set; }


public int Config98Id { get; set; }
public string Config98Name { get; set; }
public string Config98Description { get; set; }
public DateTime Config98CreatedAt { get; set; }
public DateTime? Config98UpdatedAt { get; set; }
public string Config98CreatedBy { get; set; }
public bool IsConfig98Active { get; set; }
public int Config98SortOrder { get; set; }


public int Config30Id { get; set; }
public string Config30Name { get; set; }
public string Config30Description { get; set; }
public DateTime Config30CreatedAt { get; set; }
public DateTime? Config30UpdatedAt { get; set; }
public string Config30CreatedBy { get; set; }
public bool IsConfig30Active { get; set; }
public int Config30SortOrder { get; set; }


public int Config88Id { get; set; }
public string Config88Name { get; set; }
public string Config88Description { get; set; }
public DateTime Config88CreatedAt { get; set; }
public DateTime? Config88UpdatedAt { get; set; }
public string Config88CreatedBy { get; set; }
public bool IsConfig88Active { get; set; }
public int Config88SortOrder { get; set; }


public int Record95Id { get; set; }
public string Record95Name { get; set; }
public string Record95Description { get; set; }
public DateTime Record95CreatedAt { get; set; }
public DateTime? Record95UpdatedAt { get; set; }
public string Record95CreatedBy { get; set; }
public bool IsRecord95Active { get; set; }
public int Record95SortOrder { get; set; }


public int Item76Id { get; set; }
public string Item76Name { get; set; }
public string Item76Description { get; set; }
public DateTime Item76CreatedAt { get; set; }
public DateTime? Item76UpdatedAt { get; set; }
public string Item76CreatedBy { get; set; }
public bool IsItem76Active { get; set; }
public int Item76SortOrder { get; set; }


public int Entry89Id { get; set; }
public string Entry89Name { get; set; }
public string Entry89Description { get; set; }
public DateTime Entry89CreatedAt { get; set; }
public DateTime? Entry89UpdatedAt { get; set; }
public string Entry89CreatedBy { get; set; }
public bool IsEntry89Active { get; set; }
public int Entry89SortOrder { get; set; }


public int Field34Id { get; set; }
public string Field34Name { get; set; }
public string Field34Description { get; set; }
public DateTime Field34CreatedAt { get; set; }
public DateTime? Field34UpdatedAt { get; set; }
public string Field34CreatedBy { get; set; }
public bool IsField34Active { get; set; }
public int Field34SortOrder { get; set; }


public int Attr79Id { get; set; }
public string Attr79Name { get; set; }
public string Attr79Description { get; set; }
public DateTime Attr79CreatedAt { get; set; }
public DateTime? Attr79UpdatedAt { get; set; }
public string Attr79CreatedBy { get; set; }
public bool IsAttr79Active { get; set; }
public int Attr79SortOrder { get; set; }


public int Item12Id { get; set; }
public string Item12Name { get; set; }
public string Item12Description { get; set; }
public DateTime Item12CreatedAt { get; set; }
public DateTime? Item12UpdatedAt { get; set; }
public string Item12CreatedBy { get; set; }
public bool IsItem12Active { get; set; }
public int Item12SortOrder { get; set; }


public int Record59Id { get; set; }
public string Record59Name { get; set; }
public string Record59Description { get; set; }
public DateTime Record59CreatedAt { get; set; }
public DateTime? Record59UpdatedAt { get; set; }
public string Record59CreatedBy { get; set; }
public bool IsRecord59Active { get; set; }
public int Record59SortOrder { get; set; }


public int Record55Id { get; set; }
public string Record55Name { get; set; }
public string Record55Description { get; set; }
public DateTime Record55CreatedAt { get; set; }
public DateTime? Record55UpdatedAt { get; set; }
public string Record55CreatedBy { get; set; }
public bool IsRecord55Active { get; set; }
public int Record55SortOrder { get; set; }


public int Record2Id { get; set; }
public string Record2Name { get; set; }
public string Record2Description { get; set; }
public DateTime Record2CreatedAt { get; set; }
public DateTime? Record2UpdatedAt { get; set; }
public string Record2CreatedBy { get; set; }
public bool IsRecord2Active { get; set; }
public int Record2SortOrder { get; set; }


public int Detail59Id { get; set; }
public string Detail59Name { get; set; }
public string Detail59Description { get; set; }
public DateTime Detail59CreatedAt { get; set; }
public DateTime? Detail59UpdatedAt { get; set; }
public string Detail59CreatedBy { get; set; }
public bool IsDetail59Active { get; set; }
public int Detail59SortOrder { get; set; }


public int Record26Id { get; set; }
public string Record26Name { get; set; }
public string Record26Description { get; set; }
public DateTime Record26CreatedAt { get; set; }
public DateTime? Record26UpdatedAt { get; set; }
public string Record26CreatedBy { get; set; }
public bool IsRecord26Active { get; set; }
public int Record26SortOrder { get; set; }


public int Item64Id { get; set; }
public string Item64Name { get; set; }
public string Item64Description { get; set; }
public DateTime Item64CreatedAt { get; set; }
public DateTime? Item64UpdatedAt { get; set; }
public string Item64CreatedBy { get; set; }
public bool IsItem64Active { get; set; }
public int Item64SortOrder { get; set; }


public int Field18Id { get; set; }
public string Field18Name { get; set; }
public string Field18Description { get; set; }
public DateTime Field18CreatedAt { get; set; }
public DateTime? Field18UpdatedAt { get; set; }
public string Field18CreatedBy { get; set; }
public bool IsField18Active { get; set; }
public int Field18SortOrder { get; set; }


public int Field34Id { get; set; }
public string Field34Name { get; set; }
public string Field34Description { get; set; }
public DateTime Field34CreatedAt { get; set; }
public DateTime? Field34UpdatedAt { get; set; }
public string Field34CreatedBy { get; set; }
public bool IsField34Active { get; set; }
public int Field34SortOrder { get; set; }


public int Param70Id { get; set; }
public string Param70Name { get; set; }
public string Param70Description { get; set; }
public DateTime Param70CreatedAt { get; set; }
public DateTime? Param70UpdatedAt { get; set; }
public string Param70CreatedBy { get; set; }
public bool IsParam70Active { get; set; }
public int Param70SortOrder { get; set; }


public int Param20Id { get; set; }
public string Param20Name { get; set; }
public string Param20Description { get; set; }
public DateTime Param20CreatedAt { get; set; }
public DateTime? Param20UpdatedAt { get; set; }
public string Param20CreatedBy { get; set; }
public bool IsParam20Active { get; set; }
public int Param20SortOrder { get; set; }


public int Attr89Id { get; set; }
public string Attr89Name { get; set; }
public string Attr89Description { get; set; }
public DateTime Attr89CreatedAt { get; set; }
public DateTime? Attr89UpdatedAt { get; set; }
public string Attr89CreatedBy { get; set; }
public bool IsAttr89Active { get; set; }
public int Attr89SortOrder { get; set; }


public int Record40Id { get; set; }
public string Record40Name { get; set; }
public string Record40Description { get; set; }
public DateTime Record40CreatedAt { get; set; }
public DateTime? Record40UpdatedAt { get; set; }
public string Record40CreatedBy { get; set; }
public bool IsRecord40Active { get; set; }
public int Record40SortOrder { get; set; }


public int Detail19Id { get; set; }
public string Detail19Name { get; set; }
public string Detail19Description { get; set; }
public DateTime Detail19CreatedAt { get; set; }
public DateTime? Detail19UpdatedAt { get; set; }
public string Detail19CreatedBy { get; set; }
public bool IsDetail19Active { get; set; }
public int Detail19SortOrder { get; set; }


public int Entry5Id { get; set; }
public string Entry5Name { get; set; }
public string Entry5Description { get; set; }
public DateTime Entry5CreatedAt { get; set; }
public DateTime? Entry5UpdatedAt { get; set; }
public string Entry5CreatedBy { get; set; }
public bool IsEntry5Active { get; set; }
public int Entry5SortOrder { get; set; }


public int Config48Id { get; set; }
public string Config48Name { get; set; }
public string Config48Description { get; set; }
public DateTime Config48CreatedAt { get; set; }
public DateTime? Config48UpdatedAt { get; set; }
public string Config48CreatedBy { get; set; }
public bool IsConfig48Active { get; set; }
public int Config48SortOrder { get; set; }


public int Field13Id { get; set; }
public string Field13Name { get; set; }
public string Field13Description { get; set; }
public DateTime Field13CreatedAt { get; set; }
public DateTime? Field13UpdatedAt { get; set; }
public string Field13CreatedBy { get; set; }
public bool IsField13Active { get; set; }
public int Field13SortOrder { get; set; }


public int Record62Id { get; set; }
public string Record62Name { get; set; }
public string Record62Description { get; set; }
public DateTime Record62CreatedAt { get; set; }
public DateTime? Record62UpdatedAt { get; set; }
public string Record62CreatedBy { get; set; }
public bool IsRecord62Active { get; set; }
public int Record62SortOrder { get; set; }


public int Config32Id { get; set; }
public string Config32Name { get; set; }
public string Config32Description { get; set; }
public DateTime Config32CreatedAt { get; set; }
public DateTime? Config32UpdatedAt { get; set; }
public string Config32CreatedBy { get; set; }
public bool IsConfig32Active { get; set; }
public int Config32SortOrder { get; set; }


public int Entry52Id { get; set; }
public string Entry52Name { get; set; }
public string Entry52Description { get; set; }
public DateTime Entry52CreatedAt { get; set; }
public DateTime? Entry52UpdatedAt { get; set; }
public string Entry52CreatedBy { get; set; }
public bool IsEntry52Active { get; set; }
public int Entry52SortOrder { get; set; }


public int Param67Id { get; set; }
public string Param67Name { get; set; }
public string Param67Description { get; set; }
public DateTime Param67CreatedAt { get; set; }
public DateTime? Param67UpdatedAt { get; set; }
public string Param67CreatedBy { get; set; }
public bool IsParam67Active { get; set; }
public int Param67SortOrder { get; set; }


public int Detail4Id { get; set; }
public string Detail4Name { get; set; }
public string Detail4Description { get; set; }
public DateTime Detail4CreatedAt { get; set; }
public DateTime? Detail4UpdatedAt { get; set; }
public string Detail4CreatedBy { get; set; }
public bool IsDetail4Active { get; set; }
public int Detail4SortOrder { get; set; }


public int Item41Id { get; set; }
public string Item41Name { get; set; }
public string Item41Description { get; set; }
public DateTime Item41CreatedAt { get; set; }
public DateTime? Item41UpdatedAt { get; set; }
public string Item41CreatedBy { get; set; }
public bool IsItem41Active { get; set; }
public int Item41SortOrder { get; set; }


public int Field30Id { get; set; }
public string Field30Name { get; set; }
public string Field30Description { get; set; }
public DateTime Field30CreatedAt { get; set; }
public DateTime? Field30UpdatedAt { get; set; }
public string Field30CreatedBy { get; set; }
public bool IsField30Active { get; set; }
public int Field30SortOrder { get; set; }


public int Detail42Id { get; set; }
public string Detail42Name { get; set; }
public string Detail42Description { get; set; }
public DateTime Detail42CreatedAt { get; set; }
public DateTime? Detail42UpdatedAt { get; set; }
public string Detail42CreatedBy { get; set; }
public bool IsDetail42Active { get; set; }
public int Detail42SortOrder { get; set; }


public int Field20Id { get; set; }
public string Field20Name { get; set; }
public string Field20Description { get; set; }
public DateTime Field20CreatedAt { get; set; }
public DateTime? Field20UpdatedAt { get; set; }
public string Field20CreatedBy { get; set; }
public bool IsField20Active { get; set; }
public int Field20SortOrder { get; set; }


public int Attr2Id { get; set; }
public string Attr2Name { get; set; }
public string Attr2Description { get; set; }
public DateTime Attr2CreatedAt { get; set; }
public DateTime? Attr2UpdatedAt { get; set; }
public string Attr2CreatedBy { get; set; }
public bool IsAttr2Active { get; set; }
public int Attr2SortOrder { get; set; }


public int Field49Id { get; set; }
public string Field49Name { get; set; }
public string Field49Description { get; set; }
public DateTime Field49CreatedAt { get; set; }
public DateTime? Field49UpdatedAt { get; set; }
public string Field49CreatedBy { get; set; }
public bool IsField49Active { get; set; }
public int Field49SortOrder { get; set; }


public int Entry84Id { get; set; }
public string Entry84Name { get; set; }
public string Entry84Description { get; set; }
public DateTime Entry84CreatedAt { get; set; }
public DateTime? Entry84UpdatedAt { get; set; }
public string Entry84CreatedBy { get; set; }
public bool IsEntry84Active { get; set; }
public int Entry84SortOrder { get; set; }


public int Detail79Id { get; set; }
public string Detail79Name { get; set; }
public string Detail79Description { get; set; }
public DateTime Detail79CreatedAt { get; set; }
public DateTime? Detail79UpdatedAt { get; set; }
public string Detail79CreatedBy { get; set; }
public bool IsDetail79Active { get; set; }
public int Detail79SortOrder { get; set; }


public int Detail56Id { get; set; }
public string Detail56Name { get; set; }
public string Detail56Description { get; set; }
public DateTime Detail56CreatedAt { get; set; }
public DateTime? Detail56UpdatedAt { get; set; }
public string Detail56CreatedBy { get; set; }
public bool IsDetail56Active { get; set; }
public int Detail56SortOrder { get; set; }


public int Config20Id { get; set; }
public string Config20Name { get; set; }
public string Config20Description { get; set; }
public DateTime Config20CreatedAt { get; set; }
public DateTime? Config20UpdatedAt { get; set; }
public string Config20CreatedBy { get; set; }
public bool IsConfig20Active { get; set; }
public int Config20SortOrder { get; set; }

    }
}