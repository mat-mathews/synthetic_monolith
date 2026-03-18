using Admin.Data117;
using Admin.Events235;
using Admin.Handlers;
using Admin.Processors;
using Billing.Mappers124;
using Common.Core118;
using Common.Events367;
using Documents.Shared487;
using Export.Api12;
using Imaging.Api;
using Import.Events;
using Import.Service291;
using Integration.Handlers17;
using Integration.Handlers333;
using Portal.Validators227;
using Reporting.Events220;
using Scheduling.Models260;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Data;

namespace Common.Contracts279
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer2
    {
        private readonly Admin_Processors_Handler _admin_Processors_Handler;
        private readonly Admin_Processors_Service2 _admin_Processors_Service2;
        private readonly Admin_Data117_Command6 _admin_Data117_Command6;
        private readonly Common_Events367_Processor _common_Events367_Processor;
        private readonly Common_Events367_Processor3 _common_Events367_Processor3;
        private readonly Common_Events367_Service4 _common_Events367_Service4;
        private readonly Portal_Validators227_Repository5 _portal_Validators227_Repository5;
        private readonly Reporting_Events220_Repository2 _reporting_Events220_Repository2;

        public Consumer2(Admin_Processors_Handler admin_Processors_Handler, Admin_Processors_Service2 admin_Processors_Service2, Admin_Data117_Command6 admin_Data117_Command6, Common_Events367_Processor common_Events367_Processor, Common_Events367_Processor3 common_Events367_Processor3, Common_Events367_Service4 common_Events367_Service4, Portal_Validators227_Repository5 portal_Validators227_Repository5, Reporting_Events220_Repository2 reporting_Events220_Repository2)
        {
            _admin_Processors_Handler = admin_Processors_Handler ?? throw new ArgumentNullException(nameof(admin_Processors_Handler));
            _admin_Processors_Service2 = admin_Processors_Service2 ?? throw new ArgumentNullException(nameof(admin_Processors_Service2));
            _admin_Data117_Command6 = admin_Data117_Command6 ?? throw new ArgumentNullException(nameof(admin_Data117_Command6));
            _common_Events367_Processor = common_Events367_Processor ?? throw new ArgumentNullException(nameof(common_Events367_Processor));
            _common_Events367_Processor3 = common_Events367_Processor3 ?? throw new ArgumentNullException(nameof(common_Events367_Processor3));
            _common_Events367_Service4 = common_Events367_Service4 ?? throw new ArgumentNullException(nameof(common_Events367_Service4));
            _portal_Validators227_Repository5 = portal_Validators227_Repository5 ?? throw new ArgumentNullException(nameof(portal_Validators227_Repository5));
            _reporting_Events220_Repository2 = reporting_Events220_Repository2 ?? throw new ArgumentNullException(nameof(reporting_Events220_Repository2));
        }

        public Admin_Processors_Handler GetAdmin_Processors_Handler() => _admin_Processors_Handler;
        public Admin_Processors_Service2 GetAdmin_Processors_Service2() => _admin_Processors_Service2;
        public Admin_Data117_Command6 GetAdmin_Data117_Command6() => _admin_Data117_Command6;
        public Common_Events367_Processor GetCommon_Events367_Processor() => _common_Events367_Processor;
        public Common_Events367_Processor3 GetCommon_Events367_Processor3() => _common_Events367_Processor3;
        public Common_Events367_Service4 GetCommon_Events367_Service4() => _common_Events367_Service4;
        public Portal_Validators227_Repository5 GetPortal_Validators227_Repository5() => _portal_Validators227_Repository5;
        public Reporting_Events220_Repository2 GetReporting_Events220_Repository2() => _reporting_Events220_Repository2;

/// <summary>
/// Validates the Consumer2 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer2(Consumer2Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer2));
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
/// Processes the Consumer2 operation asynchronously.
/// </summary>
public async Task<Consumer2Result> ProcessConsumer2Async(
    Consumer2Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer2), request.Id);

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
            return new Consumer2Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer2));
        return new Consumer2Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer2));
        return new Consumer2Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer2 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer2Dto>> GetConsumer2ListAsync(
    Consumer2Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer2Entity>().AsQueryable();

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
        .Select(x => new Consumer2Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer2Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer2Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer2Service(
    ILogger<Consumer2Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer2:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer2 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer2Data> GetCachedConsumer2Async(string key)
{
    var cacheKey = $"Consumer2_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer2Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer2SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Config87Id { get; set; }
public string Config87Name { get; set; }
public string Config87Description { get; set; }
public DateTime Config87CreatedAt { get; set; }
public DateTime? Config87UpdatedAt { get; set; }
public string Config87CreatedBy { get; set; }
public bool IsConfig87Active { get; set; }
public int Config87SortOrder { get; set; }


public int Detail50Id { get; set; }
public string Detail50Name { get; set; }
public string Detail50Description { get; set; }
public DateTime Detail50CreatedAt { get; set; }
public DateTime? Detail50UpdatedAt { get; set; }
public string Detail50CreatedBy { get; set; }
public bool IsDetail50Active { get; set; }
public int Detail50SortOrder { get; set; }


public int Field83Id { get; set; }
public string Field83Name { get; set; }
public string Field83Description { get; set; }
public DateTime Field83CreatedAt { get; set; }
public DateTime? Field83UpdatedAt { get; set; }
public string Field83CreatedBy { get; set; }
public bool IsField83Active { get; set; }
public int Field83SortOrder { get; set; }


public int Detail83Id { get; set; }
public string Detail83Name { get; set; }
public string Detail83Description { get; set; }
public DateTime Detail83CreatedAt { get; set; }
public DateTime? Detail83UpdatedAt { get; set; }
public string Detail83CreatedBy { get; set; }
public bool IsDetail83Active { get; set; }
public int Detail83SortOrder { get; set; }


public int Config50Id { get; set; }
public string Config50Name { get; set; }
public string Config50Description { get; set; }
public DateTime Config50CreatedAt { get; set; }
public DateTime? Config50UpdatedAt { get; set; }
public string Config50CreatedBy { get; set; }
public bool IsConfig50Active { get; set; }
public int Config50SortOrder { get; set; }


public int Attr99Id { get; set; }
public string Attr99Name { get; set; }
public string Attr99Description { get; set; }
public DateTime Attr99CreatedAt { get; set; }
public DateTime? Attr99UpdatedAt { get; set; }
public string Attr99CreatedBy { get; set; }
public bool IsAttr99Active { get; set; }
public int Attr99SortOrder { get; set; }


public int Config44Id { get; set; }
public string Config44Name { get; set; }
public string Config44Description { get; set; }
public DateTime Config44CreatedAt { get; set; }
public DateTime? Config44UpdatedAt { get; set; }
public string Config44CreatedBy { get; set; }
public bool IsConfig44Active { get; set; }
public int Config44SortOrder { get; set; }


public int Attr95Id { get; set; }
public string Attr95Name { get; set; }
public string Attr95Description { get; set; }
public DateTime Attr95CreatedAt { get; set; }
public DateTime? Attr95UpdatedAt { get; set; }
public string Attr95CreatedBy { get; set; }
public bool IsAttr95Active { get; set; }
public int Attr95SortOrder { get; set; }


public int Param79Id { get; set; }
public string Param79Name { get; set; }
public string Param79Description { get; set; }
public DateTime Param79CreatedAt { get; set; }
public DateTime? Param79UpdatedAt { get; set; }
public string Param79CreatedBy { get; set; }
public bool IsParam79Active { get; set; }
public int Param79SortOrder { get; set; }


public int Param30Id { get; set; }
public string Param30Name { get; set; }
public string Param30Description { get; set; }
public DateTime Param30CreatedAt { get; set; }
public DateTime? Param30UpdatedAt { get; set; }
public string Param30CreatedBy { get; set; }
public bool IsParam30Active { get; set; }
public int Param30SortOrder { get; set; }


public int Field3Id { get; set; }
public string Field3Name { get; set; }
public string Field3Description { get; set; }
public DateTime Field3CreatedAt { get; set; }
public DateTime? Field3UpdatedAt { get; set; }
public string Field3CreatedBy { get; set; }
public bool IsField3Active { get; set; }
public int Field3SortOrder { get; set; }


public int Field84Id { get; set; }
public string Field84Name { get; set; }
public string Field84Description { get; set; }
public DateTime Field84CreatedAt { get; set; }
public DateTime? Field84UpdatedAt { get; set; }
public string Field84CreatedBy { get; set; }
public bool IsField84Active { get; set; }
public int Field84SortOrder { get; set; }


public int Entry99Id { get; set; }
public string Entry99Name { get; set; }
public string Entry99Description { get; set; }
public DateTime Entry99CreatedAt { get; set; }
public DateTime? Entry99UpdatedAt { get; set; }
public string Entry99CreatedBy { get; set; }
public bool IsEntry99Active { get; set; }
public int Entry99SortOrder { get; set; }


public int Record60Id { get; set; }
public string Record60Name { get; set; }
public string Record60Description { get; set; }
public DateTime Record60CreatedAt { get; set; }
public DateTime? Record60UpdatedAt { get; set; }
public string Record60CreatedBy { get; set; }
public bool IsRecord60Active { get; set; }
public int Record60SortOrder { get; set; }


public int Field39Id { get; set; }
public string Field39Name { get; set; }
public string Field39Description { get; set; }
public DateTime Field39CreatedAt { get; set; }
public DateTime? Field39UpdatedAt { get; set; }
public string Field39CreatedBy { get; set; }
public bool IsField39Active { get; set; }
public int Field39SortOrder { get; set; }


public int Record83Id { get; set; }
public string Record83Name { get; set; }
public string Record83Description { get; set; }
public DateTime Record83CreatedAt { get; set; }
public DateTime? Record83UpdatedAt { get; set; }
public string Record83CreatedBy { get; set; }
public bool IsRecord83Active { get; set; }
public int Record83SortOrder { get; set; }


public int Attr59Id { get; set; }
public string Attr59Name { get; set; }
public string Attr59Description { get; set; }
public DateTime Attr59CreatedAt { get; set; }
public DateTime? Attr59UpdatedAt { get; set; }
public string Attr59CreatedBy { get; set; }
public bool IsAttr59Active { get; set; }
public int Attr59SortOrder { get; set; }


public int Entry93Id { get; set; }
public string Entry93Name { get; set; }
public string Entry93Description { get; set; }
public DateTime Entry93CreatedAt { get; set; }
public DateTime? Entry93UpdatedAt { get; set; }
public string Entry93CreatedBy { get; set; }
public bool IsEntry93Active { get; set; }
public int Entry93SortOrder { get; set; }


public int Param68Id { get; set; }
public string Param68Name { get; set; }
public string Param68Description { get; set; }
public DateTime Param68CreatedAt { get; set; }
public DateTime? Param68UpdatedAt { get; set; }
public string Param68CreatedBy { get; set; }
public bool IsParam68Active { get; set; }
public int Param68SortOrder { get; set; }


public int Record12Id { get; set; }
public string Record12Name { get; set; }
public string Record12Description { get; set; }
public DateTime Record12CreatedAt { get; set; }
public DateTime? Record12UpdatedAt { get; set; }
public string Record12CreatedBy { get; set; }
public bool IsRecord12Active { get; set; }
public int Record12SortOrder { get; set; }


public int Detail69Id { get; set; }
public string Detail69Name { get; set; }
public string Detail69Description { get; set; }
public DateTime Detail69CreatedAt { get; set; }
public DateTime? Detail69UpdatedAt { get; set; }
public string Detail69CreatedBy { get; set; }
public bool IsDetail69Active { get; set; }
public int Detail69SortOrder { get; set; }


public int Record17Id { get; set; }
public string Record17Name { get; set; }
public string Record17Description { get; set; }
public DateTime Record17CreatedAt { get; set; }
public DateTime? Record17UpdatedAt { get; set; }
public string Record17CreatedBy { get; set; }
public bool IsRecord17Active { get; set; }
public int Record17SortOrder { get; set; }


public int Param7Id { get; set; }
public string Param7Name { get; set; }
public string Param7Description { get; set; }
public DateTime Param7CreatedAt { get; set; }
public DateTime? Param7UpdatedAt { get; set; }
public string Param7CreatedBy { get; set; }
public bool IsParam7Active { get; set; }
public int Param7SortOrder { get; set; }


public int Param12Id { get; set; }
public string Param12Name { get; set; }
public string Param12Description { get; set; }
public DateTime Param12CreatedAt { get; set; }
public DateTime? Param12UpdatedAt { get; set; }
public string Param12CreatedBy { get; set; }
public bool IsParam12Active { get; set; }
public int Param12SortOrder { get; set; }


public int Item10Id { get; set; }
public string Item10Name { get; set; }
public string Item10Description { get; set; }
public DateTime Item10CreatedAt { get; set; }
public DateTime? Item10UpdatedAt { get; set; }
public string Item10CreatedBy { get; set; }
public bool IsItem10Active { get; set; }
public int Item10SortOrder { get; set; }


public int Item50Id { get; set; }
public string Item50Name { get; set; }
public string Item50Description { get; set; }
public DateTime Item50CreatedAt { get; set; }
public DateTime? Item50UpdatedAt { get; set; }
public string Item50CreatedBy { get; set; }
public bool IsItem50Active { get; set; }
public int Item50SortOrder { get; set; }


public int Config31Id { get; set; }
public string Config31Name { get; set; }
public string Config31Description { get; set; }
public DateTime Config31CreatedAt { get; set; }
public DateTime? Config31UpdatedAt { get; set; }
public string Config31CreatedBy { get; set; }
public bool IsConfig31Active { get; set; }
public int Config31SortOrder { get; set; }


public int Config60Id { get; set; }
public string Config60Name { get; set; }
public string Config60Description { get; set; }
public DateTime Config60CreatedAt { get; set; }
public DateTime? Config60UpdatedAt { get; set; }
public string Config60CreatedBy { get; set; }
public bool IsConfig60Active { get; set; }
public int Config60SortOrder { get; set; }


public int Detail57Id { get; set; }
public string Detail57Name { get; set; }
public string Detail57Description { get; set; }
public DateTime Detail57CreatedAt { get; set; }
public DateTime? Detail57UpdatedAt { get; set; }
public string Detail57CreatedBy { get; set; }
public bool IsDetail57Active { get; set; }
public int Detail57SortOrder { get; set; }


public int Attr75Id { get; set; }
public string Attr75Name { get; set; }
public string Attr75Description { get; set; }
public DateTime Attr75CreatedAt { get; set; }
public DateTime? Attr75UpdatedAt { get; set; }
public string Attr75CreatedBy { get; set; }
public bool IsAttr75Active { get; set; }
public int Attr75SortOrder { get; set; }


public int Field8Id { get; set; }
public string Field8Name { get; set; }
public string Field8Description { get; set; }
public DateTime Field8CreatedAt { get; set; }
public DateTime? Field8UpdatedAt { get; set; }
public string Field8CreatedBy { get; set; }
public bool IsField8Active { get; set; }
public int Field8SortOrder { get; set; }


public int Param47Id { get; set; }
public string Param47Name { get; set; }
public string Param47Description { get; set; }
public DateTime Param47CreatedAt { get; set; }
public DateTime? Param47UpdatedAt { get; set; }
public string Param47CreatedBy { get; set; }
public bool IsParam47Active { get; set; }
public int Param47SortOrder { get; set; }


public int Item1Id { get; set; }
public string Item1Name { get; set; }
public string Item1Description { get; set; }
public DateTime Item1CreatedAt { get; set; }
public DateTime? Item1UpdatedAt { get; set; }
public string Item1CreatedBy { get; set; }
public bool IsItem1Active { get; set; }
public int Item1SortOrder { get; set; }


public int Attr1Id { get; set; }
public string Attr1Name { get; set; }
public string Attr1Description { get; set; }
public DateTime Attr1CreatedAt { get; set; }
public DateTime? Attr1UpdatedAt { get; set; }
public string Attr1CreatedBy { get; set; }
public bool IsAttr1Active { get; set; }
public int Attr1SortOrder { get; set; }


public int Config87Id { get; set; }
public string Config87Name { get; set; }
public string Config87Description { get; set; }
public DateTime Config87CreatedAt { get; set; }
public DateTime? Config87UpdatedAt { get; set; }
public string Config87CreatedBy { get; set; }
public bool IsConfig87Active { get; set; }
public int Config87SortOrder { get; set; }


public int Item38Id { get; set; }
public string Item38Name { get; set; }
public string Item38Description { get; set; }
public DateTime Item38CreatedAt { get; set; }
public DateTime? Item38UpdatedAt { get; set; }
public string Item38CreatedBy { get; set; }
public bool IsItem38Active { get; set; }
public int Item38SortOrder { get; set; }


public int Record1Id { get; set; }
public string Record1Name { get; set; }
public string Record1Description { get; set; }
public DateTime Record1CreatedAt { get; set; }
public DateTime? Record1UpdatedAt { get; set; }
public string Record1CreatedBy { get; set; }
public bool IsRecord1Active { get; set; }
public int Record1SortOrder { get; set; }


public int Item69Id { get; set; }
public string Item69Name { get; set; }
public string Item69Description { get; set; }
public DateTime Item69CreatedAt { get; set; }
public DateTime? Item69UpdatedAt { get; set; }
public string Item69CreatedBy { get; set; }
public bool IsItem69Active { get; set; }
public int Item69SortOrder { get; set; }


public int Item12Id { get; set; }
public string Item12Name { get; set; }
public string Item12Description { get; set; }
public DateTime Item12CreatedAt { get; set; }
public DateTime? Item12UpdatedAt { get; set; }
public string Item12CreatedBy { get; set; }
public bool IsItem12Active { get; set; }
public int Item12SortOrder { get; set; }


public int Attr93Id { get; set; }
public string Attr93Name { get; set; }
public string Attr93Description { get; set; }
public DateTime Attr93CreatedAt { get; set; }
public DateTime? Attr93UpdatedAt { get; set; }
public string Attr93CreatedBy { get; set; }
public bool IsAttr93Active { get; set; }
public int Attr93SortOrder { get; set; }


public int Item9Id { get; set; }
public string Item9Name { get; set; }
public string Item9Description { get; set; }
public DateTime Item9CreatedAt { get; set; }
public DateTime? Item9UpdatedAt { get; set; }
public string Item9CreatedBy { get; set; }
public bool IsItem9Active { get; set; }
public int Item9SortOrder { get; set; }


public int Param6Id { get; set; }
public string Param6Name { get; set; }
public string Param6Description { get; set; }
public DateTime Param6CreatedAt { get; set; }
public DateTime? Param6UpdatedAt { get; set; }
public string Param6CreatedBy { get; set; }
public bool IsParam6Active { get; set; }
public int Param6SortOrder { get; set; }


public int Record28Id { get; set; }
public string Record28Name { get; set; }
public string Record28Description { get; set; }
public DateTime Record28CreatedAt { get; set; }
public DateTime? Record28UpdatedAt { get; set; }
public string Record28CreatedBy { get; set; }
public bool IsRecord28Active { get; set; }
public int Record28SortOrder { get; set; }


public int Entry14Id { get; set; }
public string Entry14Name { get; set; }
public string Entry14Description { get; set; }
public DateTime Entry14CreatedAt { get; set; }
public DateTime? Entry14UpdatedAt { get; set; }
public string Entry14CreatedBy { get; set; }
public bool IsEntry14Active { get; set; }
public int Entry14SortOrder { get; set; }


public int Attr41Id { get; set; }
public string Attr41Name { get; set; }
public string Attr41Description { get; set; }
public DateTime Attr41CreatedAt { get; set; }
public DateTime? Attr41UpdatedAt { get; set; }
public string Attr41CreatedBy { get; set; }
public bool IsAttr41Active { get; set; }
public int Attr41SortOrder { get; set; }

    }
}