using Admin.Client;
using Admin.Service;
using Admin.Web4;
using Auth.Handlers209;
using Auth.Mappers208;
using Common.Mappers343;
using Common.Tests;
using GalaxyWorks.Handlers;
using Imaging.Core;
using Imaging.Models459;
using Import.Mappers56;
using Integration.Contracts290;
using Integration.Mappers;
using Notifications.Validators391;
using Reporting.Handlers;
using Reporting.Tests;
using Reporting.Web345;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Notifications.Core166
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer14
    {
        private readonly Admin_Web4_Event3 _admin_Web4_Event3;
        private readonly Admin_Web4_Manager6 _admin_Web4_Manager6;
        private readonly Admin_Web4_Provider1 _admin_Web4_Provider1;
        private readonly Auth_Mappers208_Processor5 _auth_Mappers208_Processor5;
        private readonly IReporting_Tests_Repository2 _iReporting_Tests_Repository2;
        private readonly Reporting_Tests_Builder _reporting_Tests_Builder;
        private readonly IImport_Mappers56_Validator7 _iImport_Mappers56_Validator7;
        private readonly IIntegration_Mappers_Handler7 _iIntegration_Mappers_Handler7;

        public Consumer14(Admin_Web4_Event3 admin_Web4_Event3, Admin_Web4_Manager6 admin_Web4_Manager6, Admin_Web4_Provider1 admin_Web4_Provider1, Auth_Mappers208_Processor5 auth_Mappers208_Processor5, IReporting_Tests_Repository2 iReporting_Tests_Repository2, Reporting_Tests_Builder reporting_Tests_Builder, IImport_Mappers56_Validator7 iImport_Mappers56_Validator7, IIntegration_Mappers_Handler7 iIntegration_Mappers_Handler7)
        {
            _admin_Web4_Event3 = admin_Web4_Event3 ?? throw new ArgumentNullException(nameof(admin_Web4_Event3));
            _admin_Web4_Manager6 = admin_Web4_Manager6 ?? throw new ArgumentNullException(nameof(admin_Web4_Manager6));
            _admin_Web4_Provider1 = admin_Web4_Provider1 ?? throw new ArgumentNullException(nameof(admin_Web4_Provider1));
            _auth_Mappers208_Processor5 = auth_Mappers208_Processor5 ?? throw new ArgumentNullException(nameof(auth_Mappers208_Processor5));
            _iReporting_Tests_Repository2 = iReporting_Tests_Repository2 ?? throw new ArgumentNullException(nameof(iReporting_Tests_Repository2));
            _reporting_Tests_Builder = reporting_Tests_Builder ?? throw new ArgumentNullException(nameof(reporting_Tests_Builder));
            _iImport_Mappers56_Validator7 = iImport_Mappers56_Validator7 ?? throw new ArgumentNullException(nameof(iImport_Mappers56_Validator7));
            _iIntegration_Mappers_Handler7 = iIntegration_Mappers_Handler7 ?? throw new ArgumentNullException(nameof(iIntegration_Mappers_Handler7));
        }

        public Admin_Web4_Event3 GetAdmin_Web4_Event3() => _admin_Web4_Event3;
        public Admin_Web4_Manager6 GetAdmin_Web4_Manager6() => _admin_Web4_Manager6;
        public Admin_Web4_Provider1 GetAdmin_Web4_Provider1() => _admin_Web4_Provider1;
        public Auth_Mappers208_Processor5 GetAuth_Mappers208_Processor5() => _auth_Mappers208_Processor5;
        public IReporting_Tests_Repository2 GetIReporting_Tests_Repository2() => _iReporting_Tests_Repository2;
        public Reporting_Tests_Builder GetReporting_Tests_Builder() => _reporting_Tests_Builder;
        public IImport_Mappers56_Validator7 GetIImport_Mappers56_Validator7() => _iImport_Mappers56_Validator7;
        public IIntegration_Mappers_Handler7 GetIIntegration_Mappers_Handler7() => _iIntegration_Mappers_Handler7;

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

public int Record97Id { get; set; }
public string Record97Name { get; set; }
public string Record97Description { get; set; }
public DateTime Record97CreatedAt { get; set; }
public DateTime? Record97UpdatedAt { get; set; }
public string Record97CreatedBy { get; set; }
public bool IsRecord97Active { get; set; }
public int Record97SortOrder { get; set; }


public int Entry95Id { get; set; }
public string Entry95Name { get; set; }
public string Entry95Description { get; set; }
public DateTime Entry95CreatedAt { get; set; }
public DateTime? Entry95UpdatedAt { get; set; }
public string Entry95CreatedBy { get; set; }
public bool IsEntry95Active { get; set; }
public int Entry95SortOrder { get; set; }


public int Param37Id { get; set; }
public string Param37Name { get; set; }
public string Param37Description { get; set; }
public DateTime Param37CreatedAt { get; set; }
public DateTime? Param37UpdatedAt { get; set; }
public string Param37CreatedBy { get; set; }
public bool IsParam37Active { get; set; }
public int Param37SortOrder { get; set; }


public int Item83Id { get; set; }
public string Item83Name { get; set; }
public string Item83Description { get; set; }
public DateTime Item83CreatedAt { get; set; }
public DateTime? Item83UpdatedAt { get; set; }
public string Item83CreatedBy { get; set; }
public bool IsItem83Active { get; set; }
public int Item83SortOrder { get; set; }


public int Record63Id { get; set; }
public string Record63Name { get; set; }
public string Record63Description { get; set; }
public DateTime Record63CreatedAt { get; set; }
public DateTime? Record63UpdatedAt { get; set; }
public string Record63CreatedBy { get; set; }
public bool IsRecord63Active { get; set; }
public int Record63SortOrder { get; set; }


public int Item3Id { get; set; }
public string Item3Name { get; set; }
public string Item3Description { get; set; }
public DateTime Item3CreatedAt { get; set; }
public DateTime? Item3UpdatedAt { get; set; }
public string Item3CreatedBy { get; set; }
public bool IsItem3Active { get; set; }
public int Item3SortOrder { get; set; }


public int Param28Id { get; set; }
public string Param28Name { get; set; }
public string Param28Description { get; set; }
public DateTime Param28CreatedAt { get; set; }
public DateTime? Param28UpdatedAt { get; set; }
public string Param28CreatedBy { get; set; }
public bool IsParam28Active { get; set; }
public int Param28SortOrder { get; set; }


public int Param69Id { get; set; }
public string Param69Name { get; set; }
public string Param69Description { get; set; }
public DateTime Param69CreatedAt { get; set; }
public DateTime? Param69UpdatedAt { get; set; }
public string Param69CreatedBy { get; set; }
public bool IsParam69Active { get; set; }
public int Param69SortOrder { get; set; }


public int Param87Id { get; set; }
public string Param87Name { get; set; }
public string Param87Description { get; set; }
public DateTime Param87CreatedAt { get; set; }
public DateTime? Param87UpdatedAt { get; set; }
public string Param87CreatedBy { get; set; }
public bool IsParam87Active { get; set; }
public int Param87SortOrder { get; set; }


public int Item32Id { get; set; }
public string Item32Name { get; set; }
public string Item32Description { get; set; }
public DateTime Item32CreatedAt { get; set; }
public DateTime? Item32UpdatedAt { get; set; }
public string Item32CreatedBy { get; set; }
public bool IsItem32Active { get; set; }
public int Item32SortOrder { get; set; }


public int Attr56Id { get; set; }
public string Attr56Name { get; set; }
public string Attr56Description { get; set; }
public DateTime Attr56CreatedAt { get; set; }
public DateTime? Attr56UpdatedAt { get; set; }
public string Attr56CreatedBy { get; set; }
public bool IsAttr56Active { get; set; }
public int Attr56SortOrder { get; set; }


public int Record58Id { get; set; }
public string Record58Name { get; set; }
public string Record58Description { get; set; }
public DateTime Record58CreatedAt { get; set; }
public DateTime? Record58UpdatedAt { get; set; }
public string Record58CreatedBy { get; set; }
public bool IsRecord58Active { get; set; }
public int Record58SortOrder { get; set; }


public int Record35Id { get; set; }
public string Record35Name { get; set; }
public string Record35Description { get; set; }
public DateTime Record35CreatedAt { get; set; }
public DateTime? Record35UpdatedAt { get; set; }
public string Record35CreatedBy { get; set; }
public bool IsRecord35Active { get; set; }
public int Record35SortOrder { get; set; }


public int Field25Id { get; set; }
public string Field25Name { get; set; }
public string Field25Description { get; set; }
public DateTime Field25CreatedAt { get; set; }
public DateTime? Field25UpdatedAt { get; set; }
public string Field25CreatedBy { get; set; }
public bool IsField25Active { get; set; }
public int Field25SortOrder { get; set; }


public int Record2Id { get; set; }
public string Record2Name { get; set; }
public string Record2Description { get; set; }
public DateTime Record2CreatedAt { get; set; }
public DateTime? Record2UpdatedAt { get; set; }
public string Record2CreatedBy { get; set; }
public bool IsRecord2Active { get; set; }
public int Record2SortOrder { get; set; }


public int Param27Id { get; set; }
public string Param27Name { get; set; }
public string Param27Description { get; set; }
public DateTime Param27CreatedAt { get; set; }
public DateTime? Param27UpdatedAt { get; set; }
public string Param27CreatedBy { get; set; }
public bool IsParam27Active { get; set; }
public int Param27SortOrder { get; set; }


public int Attr81Id { get; set; }
public string Attr81Name { get; set; }
public string Attr81Description { get; set; }
public DateTime Attr81CreatedAt { get; set; }
public DateTime? Attr81UpdatedAt { get; set; }
public string Attr81CreatedBy { get; set; }
public bool IsAttr81Active { get; set; }
public int Attr81SortOrder { get; set; }


public int Config7Id { get; set; }
public string Config7Name { get; set; }
public string Config7Description { get; set; }
public DateTime Config7CreatedAt { get; set; }
public DateTime? Config7UpdatedAt { get; set; }
public string Config7CreatedBy { get; set; }
public bool IsConfig7Active { get; set; }
public int Config7SortOrder { get; set; }


public int Detail36Id { get; set; }
public string Detail36Name { get; set; }
public string Detail36Description { get; set; }
public DateTime Detail36CreatedAt { get; set; }
public DateTime? Detail36UpdatedAt { get; set; }
public string Detail36CreatedBy { get; set; }
public bool IsDetail36Active { get; set; }
public int Detail36SortOrder { get; set; }


public int Entry28Id { get; set; }
public string Entry28Name { get; set; }
public string Entry28Description { get; set; }
public DateTime Entry28CreatedAt { get; set; }
public DateTime? Entry28UpdatedAt { get; set; }
public string Entry28CreatedBy { get; set; }
public bool IsEntry28Active { get; set; }
public int Entry28SortOrder { get; set; }


public int Attr91Id { get; set; }
public string Attr91Name { get; set; }
public string Attr91Description { get; set; }
public DateTime Attr91CreatedAt { get; set; }
public DateTime? Attr91UpdatedAt { get; set; }
public string Attr91CreatedBy { get; set; }
public bool IsAttr91Active { get; set; }
public int Attr91SortOrder { get; set; }


public int Detail18Id { get; set; }
public string Detail18Name { get; set; }
public string Detail18Description { get; set; }
public DateTime Detail18CreatedAt { get; set; }
public DateTime? Detail18UpdatedAt { get; set; }
public string Detail18CreatedBy { get; set; }
public bool IsDetail18Active { get; set; }
public int Detail18SortOrder { get; set; }


public int Attr44Id { get; set; }
public string Attr44Name { get; set; }
public string Attr44Description { get; set; }
public DateTime Attr44CreatedAt { get; set; }
public DateTime? Attr44UpdatedAt { get; set; }
public string Attr44CreatedBy { get; set; }
public bool IsAttr44Active { get; set; }
public int Attr44SortOrder { get; set; }


public int Field50Id { get; set; }
public string Field50Name { get; set; }
public string Field50Description { get; set; }
public DateTime Field50CreatedAt { get; set; }
public DateTime? Field50UpdatedAt { get; set; }
public string Field50CreatedBy { get; set; }
public bool IsField50Active { get; set; }
public int Field50SortOrder { get; set; }


public int Record37Id { get; set; }
public string Record37Name { get; set; }
public string Record37Description { get; set; }
public DateTime Record37CreatedAt { get; set; }
public DateTime? Record37UpdatedAt { get; set; }
public string Record37CreatedBy { get; set; }
public bool IsRecord37Active { get; set; }
public int Record37SortOrder { get; set; }


public int Param84Id { get; set; }
public string Param84Name { get; set; }
public string Param84Description { get; set; }
public DateTime Param84CreatedAt { get; set; }
public DateTime? Param84UpdatedAt { get; set; }
public string Param84CreatedBy { get; set; }
public bool IsParam84Active { get; set; }
public int Param84SortOrder { get; set; }


public int Item43Id { get; set; }
public string Item43Name { get; set; }
public string Item43Description { get; set; }
public DateTime Item43CreatedAt { get; set; }
public DateTime? Item43UpdatedAt { get; set; }
public string Item43CreatedBy { get; set; }
public bool IsItem43Active { get; set; }
public int Item43SortOrder { get; set; }


public int Attr29Id { get; set; }
public string Attr29Name { get; set; }
public string Attr29Description { get; set; }
public DateTime Attr29CreatedAt { get; set; }
public DateTime? Attr29UpdatedAt { get; set; }
public string Attr29CreatedBy { get; set; }
public bool IsAttr29Active { get; set; }
public int Attr29SortOrder { get; set; }


public int Attr88Id { get; set; }
public string Attr88Name { get; set; }
public string Attr88Description { get; set; }
public DateTime Attr88CreatedAt { get; set; }
public DateTime? Attr88UpdatedAt { get; set; }
public string Attr88CreatedBy { get; set; }
public bool IsAttr88Active { get; set; }
public int Attr88SortOrder { get; set; }


public int Config18Id { get; set; }
public string Config18Name { get; set; }
public string Config18Description { get; set; }
public DateTime Config18CreatedAt { get; set; }
public DateTime? Config18UpdatedAt { get; set; }
public string Config18CreatedBy { get; set; }
public bool IsConfig18Active { get; set; }
public int Config18SortOrder { get; set; }


public int Detail28Id { get; set; }
public string Detail28Name { get; set; }
public string Detail28Description { get; set; }
public DateTime Detail28CreatedAt { get; set; }
public DateTime? Detail28UpdatedAt { get; set; }
public string Detail28CreatedBy { get; set; }
public bool IsDetail28Active { get; set; }
public int Detail28SortOrder { get; set; }


public int Entry65Id { get; set; }
public string Entry65Name { get; set; }
public string Entry65Description { get; set; }
public DateTime Entry65CreatedAt { get; set; }
public DateTime? Entry65UpdatedAt { get; set; }
public string Entry65CreatedBy { get; set; }
public bool IsEntry65Active { get; set; }
public int Entry65SortOrder { get; set; }


public int Record78Id { get; set; }
public string Record78Name { get; set; }
public string Record78Description { get; set; }
public DateTime Record78CreatedAt { get; set; }
public DateTime? Record78UpdatedAt { get; set; }
public string Record78CreatedBy { get; set; }
public bool IsRecord78Active { get; set; }
public int Record78SortOrder { get; set; }


public int Attr38Id { get; set; }
public string Attr38Name { get; set; }
public string Attr38Description { get; set; }
public DateTime Attr38CreatedAt { get; set; }
public DateTime? Attr38UpdatedAt { get; set; }
public string Attr38CreatedBy { get; set; }
public bool IsAttr38Active { get; set; }
public int Attr38SortOrder { get; set; }


public int Config17Id { get; set; }
public string Config17Name { get; set; }
public string Config17Description { get; set; }
public DateTime Config17CreatedAt { get; set; }
public DateTime? Config17UpdatedAt { get; set; }
public string Config17CreatedBy { get; set; }
public bool IsConfig17Active { get; set; }
public int Config17SortOrder { get; set; }


public int Entry9Id { get; set; }
public string Entry9Name { get; set; }
public string Entry9Description { get; set; }
public DateTime Entry9CreatedAt { get; set; }
public DateTime? Entry9UpdatedAt { get; set; }
public string Entry9CreatedBy { get; set; }
public bool IsEntry9Active { get; set; }
public int Entry9SortOrder { get; set; }


public int Entry47Id { get; set; }
public string Entry47Name { get; set; }
public string Entry47Description { get; set; }
public DateTime Entry47CreatedAt { get; set; }
public DateTime? Entry47UpdatedAt { get; set; }
public string Entry47CreatedBy { get; set; }
public bool IsEntry47Active { get; set; }
public int Entry47SortOrder { get; set; }


public int Attr37Id { get; set; }
public string Attr37Name { get; set; }
public string Attr37Description { get; set; }
public DateTime Attr37CreatedAt { get; set; }
public DateTime? Attr37UpdatedAt { get; set; }
public string Attr37CreatedBy { get; set; }
public bool IsAttr37Active { get; set; }
public int Attr37SortOrder { get; set; }


public int Record28Id { get; set; }
public string Record28Name { get; set; }
public string Record28Description { get; set; }
public DateTime Record28CreatedAt { get; set; }
public DateTime? Record28UpdatedAt { get; set; }
public string Record28CreatedBy { get; set; }
public bool IsRecord28Active { get; set; }
public int Record28SortOrder { get; set; }


public int Record76Id { get; set; }
public string Record76Name { get; set; }
public string Record76Description { get; set; }
public DateTime Record76CreatedAt { get; set; }
public DateTime? Record76UpdatedAt { get; set; }
public string Record76CreatedBy { get; set; }
public bool IsRecord76Active { get; set; }
public int Record76SortOrder { get; set; }


public int Attr3Id { get; set; }
public string Attr3Name { get; set; }
public string Attr3Description { get; set; }
public DateTime Attr3CreatedAt { get; set; }
public DateTime? Attr3UpdatedAt { get; set; }
public string Attr3CreatedBy { get; set; }
public bool IsAttr3Active { get; set; }
public int Attr3SortOrder { get; set; }


public int Attr19Id { get; set; }
public string Attr19Name { get; set; }
public string Attr19Description { get; set; }
public DateTime Attr19CreatedAt { get; set; }
public DateTime? Attr19UpdatedAt { get; set; }
public string Attr19CreatedBy { get; set; }
public bool IsAttr19Active { get; set; }
public int Attr19SortOrder { get; set; }


public int Attr96Id { get; set; }
public string Attr96Name { get; set; }
public string Attr96Description { get; set; }
public DateTime Attr96CreatedAt { get; set; }
public DateTime? Attr96UpdatedAt { get; set; }
public string Attr96CreatedBy { get; set; }
public bool IsAttr96Active { get; set; }
public int Attr96SortOrder { get; set; }


public int Detail23Id { get; set; }
public string Detail23Name { get; set; }
public string Detail23Description { get; set; }
public DateTime Detail23CreatedAt { get; set; }
public DateTime? Detail23UpdatedAt { get; set; }
public string Detail23CreatedBy { get; set; }
public bool IsDetail23Active { get; set; }
public int Detail23SortOrder { get; set; }


public int Record13Id { get; set; }
public string Record13Name { get; set; }
public string Record13Description { get; set; }
public DateTime Record13CreatedAt { get; set; }
public DateTime? Record13UpdatedAt { get; set; }
public string Record13CreatedBy { get; set; }
public bool IsRecord13Active { get; set; }
public int Record13SortOrder { get; set; }


public int Record9Id { get; set; }
public string Record9Name { get; set; }
public string Record9Description { get; set; }
public DateTime Record9CreatedAt { get; set; }
public DateTime? Record9UpdatedAt { get; set; }
public string Record9CreatedBy { get; set; }
public bool IsRecord9Active { get; set; }
public int Record9SortOrder { get; set; }

    }
}