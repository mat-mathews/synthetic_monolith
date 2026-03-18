using Admin.Events306;
using Admin.Processors35;
using Auth.Mappers206;
using BatchJobs.Processors500;
using BatchJobs.Service;
using Common.Core118;
using Documents.Handlers;
using Export.Client414;
using Export.Validators152;
using Import.Data;
using Logging.Service160;
using Portal.Api99;
using Portal.Service231;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Api;
using Workflow.Validators;

namespace Imaging.Validators108
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer34
    {
        private readonly Admin_Events306_Repository2 _admin_Events306_Repository2;
        private readonly IAdmin_Events306_Factory _iAdmin_Events306_Factory;
        private readonly Admin_Processors35_Range2 _admin_Processors35_Range2;
        private readonly Admin_Processors35_Repository5 _admin_Processors35_Repository5;
        private readonly Admin_Processors35_Factory _admin_Processors35_Factory;
        private readonly Documents_Handlers_Provider1 _documents_Handlers_Provider1;
        private readonly IExport_Validators152_Handler7 _iExport_Validators152_Handler7;
        private readonly Security_Web376_Handler5 _security_Web376_Handler5;

        public Consumer34(Admin_Events306_Repository2 admin_Events306_Repository2, IAdmin_Events306_Factory iAdmin_Events306_Factory, Admin_Processors35_Range2 admin_Processors35_Range2, Admin_Processors35_Repository5 admin_Processors35_Repository5, Admin_Processors35_Factory admin_Processors35_Factory, Documents_Handlers_Provider1 documents_Handlers_Provider1, IExport_Validators152_Handler7 iExport_Validators152_Handler7, Security_Web376_Handler5 security_Web376_Handler5)
        {
            _admin_Events306_Repository2 = admin_Events306_Repository2 ?? throw new ArgumentNullException(nameof(admin_Events306_Repository2));
            _iAdmin_Events306_Factory = iAdmin_Events306_Factory ?? throw new ArgumentNullException(nameof(iAdmin_Events306_Factory));
            _admin_Processors35_Range2 = admin_Processors35_Range2 ?? throw new ArgumentNullException(nameof(admin_Processors35_Range2));
            _admin_Processors35_Repository5 = admin_Processors35_Repository5 ?? throw new ArgumentNullException(nameof(admin_Processors35_Repository5));
            _admin_Processors35_Factory = admin_Processors35_Factory ?? throw new ArgumentNullException(nameof(admin_Processors35_Factory));
            _documents_Handlers_Provider1 = documents_Handlers_Provider1 ?? throw new ArgumentNullException(nameof(documents_Handlers_Provider1));
            _iExport_Validators152_Handler7 = iExport_Validators152_Handler7 ?? throw new ArgumentNullException(nameof(iExport_Validators152_Handler7));
            _security_Web376_Handler5 = security_Web376_Handler5 ?? throw new ArgumentNullException(nameof(security_Web376_Handler5));
        }

        public Admin_Events306_Repository2 GetAdmin_Events306_Repository2() => _admin_Events306_Repository2;
        public IAdmin_Events306_Factory GetIAdmin_Events306_Factory() => _iAdmin_Events306_Factory;
        public Admin_Processors35_Range2 GetAdmin_Processors35_Range2() => _admin_Processors35_Range2;
        public Admin_Processors35_Repository5 GetAdmin_Processors35_Repository5() => _admin_Processors35_Repository5;
        public Admin_Processors35_Factory GetAdmin_Processors35_Factory() => _admin_Processors35_Factory;
        public Documents_Handlers_Provider1 GetDocuments_Handlers_Provider1() => _documents_Handlers_Provider1;
        public IExport_Validators152_Handler7 GetIExport_Validators152_Handler7() => _iExport_Validators152_Handler7;
        public Security_Web376_Handler5 GetSecurity_Web376_Handler5() => _security_Web376_Handler5;

/// <summary>
/// Validates the Consumer34 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer34(Consumer34Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer34));
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
/// Processes the Consumer34 operation asynchronously.
/// </summary>
public async Task<Consumer34Result> ProcessConsumer34Async(
    Consumer34Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer34), request.Id);

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
            return new Consumer34Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer34));
        return new Consumer34Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer34));
        return new Consumer34Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer34 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer34Dto>> GetConsumer34ListAsync(
    Consumer34Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer34Entity>().AsQueryable();

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
        .Select(x => new Consumer34Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer34Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer34Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer34Service(
    ILogger<Consumer34Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer34:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer34 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer34Data> GetCachedConsumer34Async(string key)
{
    var cacheKey = $"Consumer34_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer34Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer34SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Attr14Id { get; set; }
public string Attr14Name { get; set; }
public string Attr14Description { get; set; }
public DateTime Attr14CreatedAt { get; set; }
public DateTime? Attr14UpdatedAt { get; set; }
public string Attr14CreatedBy { get; set; }
public bool IsAttr14Active { get; set; }
public int Attr14SortOrder { get; set; }


public int Item87Id { get; set; }
public string Item87Name { get; set; }
public string Item87Description { get; set; }
public DateTime Item87CreatedAt { get; set; }
public DateTime? Item87UpdatedAt { get; set; }
public string Item87CreatedBy { get; set; }
public bool IsItem87Active { get; set; }
public int Item87SortOrder { get; set; }


public int Detail91Id { get; set; }
public string Detail91Name { get; set; }
public string Detail91Description { get; set; }
public DateTime Detail91CreatedAt { get; set; }
public DateTime? Detail91UpdatedAt { get; set; }
public string Detail91CreatedBy { get; set; }
public bool IsDetail91Active { get; set; }
public int Detail91SortOrder { get; set; }


public int Attr59Id { get; set; }
public string Attr59Name { get; set; }
public string Attr59Description { get; set; }
public DateTime Attr59CreatedAt { get; set; }
public DateTime? Attr59UpdatedAt { get; set; }
public string Attr59CreatedBy { get; set; }
public bool IsAttr59Active { get; set; }
public int Attr59SortOrder { get; set; }


public int Field54Id { get; set; }
public string Field54Name { get; set; }
public string Field54Description { get; set; }
public DateTime Field54CreatedAt { get; set; }
public DateTime? Field54UpdatedAt { get; set; }
public string Field54CreatedBy { get; set; }
public bool IsField54Active { get; set; }
public int Field54SortOrder { get; set; }


public int Item70Id { get; set; }
public string Item70Name { get; set; }
public string Item70Description { get; set; }
public DateTime Item70CreatedAt { get; set; }
public DateTime? Item70UpdatedAt { get; set; }
public string Item70CreatedBy { get; set; }
public bool IsItem70Active { get; set; }
public int Item70SortOrder { get; set; }


public int Param63Id { get; set; }
public string Param63Name { get; set; }
public string Param63Description { get; set; }
public DateTime Param63CreatedAt { get; set; }
public DateTime? Param63UpdatedAt { get; set; }
public string Param63CreatedBy { get; set; }
public bool IsParam63Active { get; set; }
public int Param63SortOrder { get; set; }


public int Config5Id { get; set; }
public string Config5Name { get; set; }
public string Config5Description { get; set; }
public DateTime Config5CreatedAt { get; set; }
public DateTime? Config5UpdatedAt { get; set; }
public string Config5CreatedBy { get; set; }
public bool IsConfig5Active { get; set; }
public int Config5SortOrder { get; set; }


public int Field39Id { get; set; }
public string Field39Name { get; set; }
public string Field39Description { get; set; }
public DateTime Field39CreatedAt { get; set; }
public DateTime? Field39UpdatedAt { get; set; }
public string Field39CreatedBy { get; set; }
public bool IsField39Active { get; set; }
public int Field39SortOrder { get; set; }


public int Field3Id { get; set; }
public string Field3Name { get; set; }
public string Field3Description { get; set; }
public DateTime Field3CreatedAt { get; set; }
public DateTime? Field3UpdatedAt { get; set; }
public string Field3CreatedBy { get; set; }
public bool IsField3Active { get; set; }
public int Field3SortOrder { get; set; }


public int Config95Id { get; set; }
public string Config95Name { get; set; }
public string Config95Description { get; set; }
public DateTime Config95CreatedAt { get; set; }
public DateTime? Config95UpdatedAt { get; set; }
public string Config95CreatedBy { get; set; }
public bool IsConfig95Active { get; set; }
public int Config95SortOrder { get; set; }


public int Param50Id { get; set; }
public string Param50Name { get; set; }
public string Param50Description { get; set; }
public DateTime Param50CreatedAt { get; set; }
public DateTime? Param50UpdatedAt { get; set; }
public string Param50CreatedBy { get; set; }
public bool IsParam50Active { get; set; }
public int Param50SortOrder { get; set; }


public int Record10Id { get; set; }
public string Record10Name { get; set; }
public string Record10Description { get; set; }
public DateTime Record10CreatedAt { get; set; }
public DateTime? Record10UpdatedAt { get; set; }
public string Record10CreatedBy { get; set; }
public bool IsRecord10Active { get; set; }
public int Record10SortOrder { get; set; }


public int Item28Id { get; set; }
public string Item28Name { get; set; }
public string Item28Description { get; set; }
public DateTime Item28CreatedAt { get; set; }
public DateTime? Item28UpdatedAt { get; set; }
public string Item28CreatedBy { get; set; }
public bool IsItem28Active { get; set; }
public int Item28SortOrder { get; set; }


public int Entry29Id { get; set; }
public string Entry29Name { get; set; }
public string Entry29Description { get; set; }
public DateTime Entry29CreatedAt { get; set; }
public DateTime? Entry29UpdatedAt { get; set; }
public string Entry29CreatedBy { get; set; }
public bool IsEntry29Active { get; set; }
public int Entry29SortOrder { get; set; }


public int Entry55Id { get; set; }
public string Entry55Name { get; set; }
public string Entry55Description { get; set; }
public DateTime Entry55CreatedAt { get; set; }
public DateTime? Entry55UpdatedAt { get; set; }
public string Entry55CreatedBy { get; set; }
public bool IsEntry55Active { get; set; }
public int Entry55SortOrder { get; set; }


public int Config58Id { get; set; }
public string Config58Name { get; set; }
public string Config58Description { get; set; }
public DateTime Config58CreatedAt { get; set; }
public DateTime? Config58UpdatedAt { get; set; }
public string Config58CreatedBy { get; set; }
public bool IsConfig58Active { get; set; }
public int Config58SortOrder { get; set; }


public int Detail57Id { get; set; }
public string Detail57Name { get; set; }
public string Detail57Description { get; set; }
public DateTime Detail57CreatedAt { get; set; }
public DateTime? Detail57UpdatedAt { get; set; }
public string Detail57CreatedBy { get; set; }
public bool IsDetail57Active { get; set; }
public int Detail57SortOrder { get; set; }


public int Detail1Id { get; set; }
public string Detail1Name { get; set; }
public string Detail1Description { get; set; }
public DateTime Detail1CreatedAt { get; set; }
public DateTime? Detail1UpdatedAt { get; set; }
public string Detail1CreatedBy { get; set; }
public bool IsDetail1Active { get; set; }
public int Detail1SortOrder { get; set; }


public int Attr21Id { get; set; }
public string Attr21Name { get; set; }
public string Attr21Description { get; set; }
public DateTime Attr21CreatedAt { get; set; }
public DateTime? Attr21UpdatedAt { get; set; }
public string Attr21CreatedBy { get; set; }
public bool IsAttr21Active { get; set; }
public int Attr21SortOrder { get; set; }


public int Config49Id { get; set; }
public string Config49Name { get; set; }
public string Config49Description { get; set; }
public DateTime Config49CreatedAt { get; set; }
public DateTime? Config49UpdatedAt { get; set; }
public string Config49CreatedBy { get; set; }
public bool IsConfig49Active { get; set; }
public int Config49SortOrder { get; set; }


public int Config26Id { get; set; }
public string Config26Name { get; set; }
public string Config26Description { get; set; }
public DateTime Config26CreatedAt { get; set; }
public DateTime? Config26UpdatedAt { get; set; }
public string Config26CreatedBy { get; set; }
public bool IsConfig26Active { get; set; }
public int Config26SortOrder { get; set; }


public int Config84Id { get; set; }
public string Config84Name { get; set; }
public string Config84Description { get; set; }
public DateTime Config84CreatedAt { get; set; }
public DateTime? Config84UpdatedAt { get; set; }
public string Config84CreatedBy { get; set; }
public bool IsConfig84Active { get; set; }
public int Config84SortOrder { get; set; }


public int Config50Id { get; set; }
public string Config50Name { get; set; }
public string Config50Description { get; set; }
public DateTime Config50CreatedAt { get; set; }
public DateTime? Config50UpdatedAt { get; set; }
public string Config50CreatedBy { get; set; }
public bool IsConfig50Active { get; set; }
public int Config50SortOrder { get; set; }


public int Entry62Id { get; set; }
public string Entry62Name { get; set; }
public string Entry62Description { get; set; }
public DateTime Entry62CreatedAt { get; set; }
public DateTime? Entry62UpdatedAt { get; set; }
public string Entry62CreatedBy { get; set; }
public bool IsEntry62Active { get; set; }
public int Entry62SortOrder { get; set; }


public int Config9Id { get; set; }
public string Config9Name { get; set; }
public string Config9Description { get; set; }
public DateTime Config9CreatedAt { get; set; }
public DateTime? Config9UpdatedAt { get; set; }
public string Config9CreatedBy { get; set; }
public bool IsConfig9Active { get; set; }
public int Config9SortOrder { get; set; }


public int Record34Id { get; set; }
public string Record34Name { get; set; }
public string Record34Description { get; set; }
public DateTime Record34CreatedAt { get; set; }
public DateTime? Record34UpdatedAt { get; set; }
public string Record34CreatedBy { get; set; }
public bool IsRecord34Active { get; set; }
public int Record34SortOrder { get; set; }


public int Detail73Id { get; set; }
public string Detail73Name { get; set; }
public string Detail73Description { get; set; }
public DateTime Detail73CreatedAt { get; set; }
public DateTime? Detail73UpdatedAt { get; set; }
public string Detail73CreatedBy { get; set; }
public bool IsDetail73Active { get; set; }
public int Detail73SortOrder { get; set; }


public int Entry69Id { get; set; }
public string Entry69Name { get; set; }
public string Entry69Description { get; set; }
public DateTime Entry69CreatedAt { get; set; }
public DateTime? Entry69UpdatedAt { get; set; }
public string Entry69CreatedBy { get; set; }
public bool IsEntry69Active { get; set; }
public int Entry69SortOrder { get; set; }


public int Detail58Id { get; set; }
public string Detail58Name { get; set; }
public string Detail58Description { get; set; }
public DateTime Detail58CreatedAt { get; set; }
public DateTime? Detail58UpdatedAt { get; set; }
public string Detail58CreatedBy { get; set; }
public bool IsDetail58Active { get; set; }
public int Detail58SortOrder { get; set; }


public int Config97Id { get; set; }
public string Config97Name { get; set; }
public string Config97Description { get; set; }
public DateTime Config97CreatedAt { get; set; }
public DateTime? Config97UpdatedAt { get; set; }
public string Config97CreatedBy { get; set; }
public bool IsConfig97Active { get; set; }
public int Config97SortOrder { get; set; }


public int Detail47Id { get; set; }
public string Detail47Name { get; set; }
public string Detail47Description { get; set; }
public DateTime Detail47CreatedAt { get; set; }
public DateTime? Detail47UpdatedAt { get; set; }
public string Detail47CreatedBy { get; set; }
public bool IsDetail47Active { get; set; }
public int Detail47SortOrder { get; set; }


public int Attr39Id { get; set; }
public string Attr39Name { get; set; }
public string Attr39Description { get; set; }
public DateTime Attr39CreatedAt { get; set; }
public DateTime? Attr39UpdatedAt { get; set; }
public string Attr39CreatedBy { get; set; }
public bool IsAttr39Active { get; set; }
public int Attr39SortOrder { get; set; }


public int Record29Id { get; set; }
public string Record29Name { get; set; }
public string Record29Description { get; set; }
public DateTime Record29CreatedAt { get; set; }
public DateTime? Record29UpdatedAt { get; set; }
public string Record29CreatedBy { get; set; }
public bool IsRecord29Active { get; set; }
public int Record29SortOrder { get; set; }


public int Config19Id { get; set; }
public string Config19Name { get; set; }
public string Config19Description { get; set; }
public DateTime Config19CreatedAt { get; set; }
public DateTime? Config19UpdatedAt { get; set; }
public string Config19CreatedBy { get; set; }
public bool IsConfig19Active { get; set; }
public int Config19SortOrder { get; set; }


public int Param90Id { get; set; }
public string Param90Name { get; set; }
public string Param90Description { get; set; }
public DateTime Param90CreatedAt { get; set; }
public DateTime? Param90UpdatedAt { get; set; }
public string Param90CreatedBy { get; set; }
public bool IsParam90Active { get; set; }
public int Param90SortOrder { get; set; }


public int Item46Id { get; set; }
public string Item46Name { get; set; }
public string Item46Description { get; set; }
public DateTime Item46CreatedAt { get; set; }
public DateTime? Item46UpdatedAt { get; set; }
public string Item46CreatedBy { get; set; }
public bool IsItem46Active { get; set; }
public int Item46SortOrder { get; set; }


public int Detail11Id { get; set; }
public string Detail11Name { get; set; }
public string Detail11Description { get; set; }
public DateTime Detail11CreatedAt { get; set; }
public DateTime? Detail11UpdatedAt { get; set; }
public string Detail11CreatedBy { get; set; }
public bool IsDetail11Active { get; set; }
public int Detail11SortOrder { get; set; }


public int Field1Id { get; set; }
public string Field1Name { get; set; }
public string Field1Description { get; set; }
public DateTime Field1CreatedAt { get; set; }
public DateTime? Field1UpdatedAt { get; set; }
public string Field1CreatedBy { get; set; }
public bool IsField1Active { get; set; }
public int Field1SortOrder { get; set; }


public int Config17Id { get; set; }
public string Config17Name { get; set; }
public string Config17Description { get; set; }
public DateTime Config17CreatedAt { get; set; }
public DateTime? Config17UpdatedAt { get; set; }
public string Config17CreatedBy { get; set; }
public bool IsConfig17Active { get; set; }
public int Config17SortOrder { get; set; }


public int Field77Id { get; set; }
public string Field77Name { get; set; }
public string Field77Description { get; set; }
public DateTime Field77CreatedAt { get; set; }
public DateTime? Field77UpdatedAt { get; set; }
public string Field77CreatedBy { get; set; }
public bool IsField77Active { get; set; }
public int Field77SortOrder { get; set; }


public int Config33Id { get; set; }
public string Config33Name { get; set; }
public string Config33Description { get; set; }
public DateTime Config33CreatedAt { get; set; }
public DateTime? Config33UpdatedAt { get; set; }
public string Config33CreatedBy { get; set; }
public bool IsConfig33Active { get; set; }
public int Config33SortOrder { get; set; }


public int Detail10Id { get; set; }
public string Detail10Name { get; set; }
public string Detail10Description { get; set; }
public DateTime Detail10CreatedAt { get; set; }
public DateTime? Detail10UpdatedAt { get; set; }
public string Detail10CreatedBy { get; set; }
public bool IsDetail10Active { get; set; }
public int Detail10SortOrder { get; set; }


public int Detail23Id { get; set; }
public string Detail23Name { get; set; }
public string Detail23Description { get; set; }
public DateTime Detail23CreatedAt { get; set; }
public DateTime? Detail23UpdatedAt { get; set; }
public string Detail23CreatedBy { get; set; }
public bool IsDetail23Active { get; set; }
public int Detail23SortOrder { get; set; }


public int Detail15Id { get; set; }
public string Detail15Name { get; set; }
public string Detail15Description { get; set; }
public DateTime Detail15CreatedAt { get; set; }
public DateTime? Detail15UpdatedAt { get; set; }
public string Detail15CreatedBy { get; set; }
public bool IsDetail15Active { get; set; }
public int Detail15SortOrder { get; set; }

    }
}