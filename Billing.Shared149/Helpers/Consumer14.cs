using Admin.Models;
using Auth.Contracts402;
using Auth.Handlers;
using Auth.Mappers178;
using Auth.Mappers28;
using Auth.Processors;
using Auth.Processors319;
using BatchJobs.Client109;
using BatchJobs.Tests270;
using DataAccess.Handlers482;
using Documents.Events;
using Export.Processors426;
using Imaging.Api;
using Import.Service291;
using Reporting.Client;
using Scheduling.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Mappers197;
using Workflow.Handlers;

namespace Billing.Shared149
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer14
    {
        private readonly Auth_Contracts402_Options8 _auth_Contracts402_Options8;
        private readonly Auth_Contracts402_Factory10 _auth_Contracts402_Factory10;
        private readonly Auth_Contracts402_Event5 _auth_Contracts402_Event5;
        private readonly Auth_Processors_Request6 _auth_Processors_Request6;
        private readonly Auth_Processors_Builder3 _auth_Processors_Builder3;
        private readonly Auth_Mappers28_Controller5 _auth_Mappers28_Controller5;
        private readonly IAuth_Mappers28_Handler4 _iAuth_Mappers28_Handler4;
        private readonly IAuth_Mappers178_Provider _iAuth_Mappers178_Provider;

        public Consumer14(Auth_Contracts402_Options8 auth_Contracts402_Options8, Auth_Contracts402_Factory10 auth_Contracts402_Factory10, Auth_Contracts402_Event5 auth_Contracts402_Event5, Auth_Processors_Request6 auth_Processors_Request6, Auth_Processors_Builder3 auth_Processors_Builder3, Auth_Mappers28_Controller5 auth_Mappers28_Controller5, IAuth_Mappers28_Handler4 iAuth_Mappers28_Handler4, IAuth_Mappers178_Provider iAuth_Mappers178_Provider)
        {
            _auth_Contracts402_Options8 = auth_Contracts402_Options8 ?? throw new ArgumentNullException(nameof(auth_Contracts402_Options8));
            _auth_Contracts402_Factory10 = auth_Contracts402_Factory10 ?? throw new ArgumentNullException(nameof(auth_Contracts402_Factory10));
            _auth_Contracts402_Event5 = auth_Contracts402_Event5 ?? throw new ArgumentNullException(nameof(auth_Contracts402_Event5));
            _auth_Processors_Request6 = auth_Processors_Request6 ?? throw new ArgumentNullException(nameof(auth_Processors_Request6));
            _auth_Processors_Builder3 = auth_Processors_Builder3 ?? throw new ArgumentNullException(nameof(auth_Processors_Builder3));
            _auth_Mappers28_Controller5 = auth_Mappers28_Controller5 ?? throw new ArgumentNullException(nameof(auth_Mappers28_Controller5));
            _iAuth_Mappers28_Handler4 = iAuth_Mappers28_Handler4 ?? throw new ArgumentNullException(nameof(iAuth_Mappers28_Handler4));
            _iAuth_Mappers178_Provider = iAuth_Mappers178_Provider ?? throw new ArgumentNullException(nameof(iAuth_Mappers178_Provider));
        }

        public Auth_Contracts402_Options8 GetAuth_Contracts402_Options8() => _auth_Contracts402_Options8;
        public Auth_Contracts402_Factory10 GetAuth_Contracts402_Factory10() => _auth_Contracts402_Factory10;
        public Auth_Contracts402_Event5 GetAuth_Contracts402_Event5() => _auth_Contracts402_Event5;
        public Auth_Processors_Request6 GetAuth_Processors_Request6() => _auth_Processors_Request6;
        public Auth_Processors_Builder3 GetAuth_Processors_Builder3() => _auth_Processors_Builder3;
        public Auth_Mappers28_Controller5 GetAuth_Mappers28_Controller5() => _auth_Mappers28_Controller5;
        public IAuth_Mappers28_Handler4 GetIAuth_Mappers28_Handler4() => _iAuth_Mappers28_Handler4;
        public IAuth_Mappers178_Provider GetIAuth_Mappers178_Provider() => _iAuth_Mappers178_Provider;

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

public int Attr5Id { get; set; }
public string Attr5Name { get; set; }
public string Attr5Description { get; set; }
public DateTime Attr5CreatedAt { get; set; }
public DateTime? Attr5UpdatedAt { get; set; }
public string Attr5CreatedBy { get; set; }
public bool IsAttr5Active { get; set; }
public int Attr5SortOrder { get; set; }


public int Config7Id { get; set; }
public string Config7Name { get; set; }
public string Config7Description { get; set; }
public DateTime Config7CreatedAt { get; set; }
public DateTime? Config7UpdatedAt { get; set; }
public string Config7CreatedBy { get; set; }
public bool IsConfig7Active { get; set; }
public int Config7SortOrder { get; set; }


public int Attr93Id { get; set; }
public string Attr93Name { get; set; }
public string Attr93Description { get; set; }
public DateTime Attr93CreatedAt { get; set; }
public DateTime? Attr93UpdatedAt { get; set; }
public string Attr93CreatedBy { get; set; }
public bool IsAttr93Active { get; set; }
public int Attr93SortOrder { get; set; }


public int Record16Id { get; set; }
public string Record16Name { get; set; }
public string Record16Description { get; set; }
public DateTime Record16CreatedAt { get; set; }
public DateTime? Record16UpdatedAt { get; set; }
public string Record16CreatedBy { get; set; }
public bool IsRecord16Active { get; set; }
public int Record16SortOrder { get; set; }


public int Param93Id { get; set; }
public string Param93Name { get; set; }
public string Param93Description { get; set; }
public DateTime Param93CreatedAt { get; set; }
public DateTime? Param93UpdatedAt { get; set; }
public string Param93CreatedBy { get; set; }
public bool IsParam93Active { get; set; }
public int Param93SortOrder { get; set; }


public int Item26Id { get; set; }
public string Item26Name { get; set; }
public string Item26Description { get; set; }
public DateTime Item26CreatedAt { get; set; }
public DateTime? Item26UpdatedAt { get; set; }
public string Item26CreatedBy { get; set; }
public bool IsItem26Active { get; set; }
public int Item26SortOrder { get; set; }


public int Entry10Id { get; set; }
public string Entry10Name { get; set; }
public string Entry10Description { get; set; }
public DateTime Entry10CreatedAt { get; set; }
public DateTime? Entry10UpdatedAt { get; set; }
public string Entry10CreatedBy { get; set; }
public bool IsEntry10Active { get; set; }
public int Entry10SortOrder { get; set; }


public int Attr25Id { get; set; }
public string Attr25Name { get; set; }
public string Attr25Description { get; set; }
public DateTime Attr25CreatedAt { get; set; }
public DateTime? Attr25UpdatedAt { get; set; }
public string Attr25CreatedBy { get; set; }
public bool IsAttr25Active { get; set; }
public int Attr25SortOrder { get; set; }


public int Entry57Id { get; set; }
public string Entry57Name { get; set; }
public string Entry57Description { get; set; }
public DateTime Entry57CreatedAt { get; set; }
public DateTime? Entry57UpdatedAt { get; set; }
public string Entry57CreatedBy { get; set; }
public bool IsEntry57Active { get; set; }
public int Entry57SortOrder { get; set; }


public int Record79Id { get; set; }
public string Record79Name { get; set; }
public string Record79Description { get; set; }
public DateTime Record79CreatedAt { get; set; }
public DateTime? Record79UpdatedAt { get; set; }
public string Record79CreatedBy { get; set; }
public bool IsRecord79Active { get; set; }
public int Record79SortOrder { get; set; }


public int Detail94Id { get; set; }
public string Detail94Name { get; set; }
public string Detail94Description { get; set; }
public DateTime Detail94CreatedAt { get; set; }
public DateTime? Detail94UpdatedAt { get; set; }
public string Detail94CreatedBy { get; set; }
public bool IsDetail94Active { get; set; }
public int Detail94SortOrder { get; set; }


public int Attr1Id { get; set; }
public string Attr1Name { get; set; }
public string Attr1Description { get; set; }
public DateTime Attr1CreatedAt { get; set; }
public DateTime? Attr1UpdatedAt { get; set; }
public string Attr1CreatedBy { get; set; }
public bool IsAttr1Active { get; set; }
public int Attr1SortOrder { get; set; }


public int Param93Id { get; set; }
public string Param93Name { get; set; }
public string Param93Description { get; set; }
public DateTime Param93CreatedAt { get; set; }
public DateTime? Param93UpdatedAt { get; set; }
public string Param93CreatedBy { get; set; }
public bool IsParam93Active { get; set; }
public int Param93SortOrder { get; set; }


public int Entry93Id { get; set; }
public string Entry93Name { get; set; }
public string Entry93Description { get; set; }
public DateTime Entry93CreatedAt { get; set; }
public DateTime? Entry93UpdatedAt { get; set; }
public string Entry93CreatedBy { get; set; }
public bool IsEntry93Active { get; set; }
public int Entry93SortOrder { get; set; }


public int Detail27Id { get; set; }
public string Detail27Name { get; set; }
public string Detail27Description { get; set; }
public DateTime Detail27CreatedAt { get; set; }
public DateTime? Detail27UpdatedAt { get; set; }
public string Detail27CreatedBy { get; set; }
public bool IsDetail27Active { get; set; }
public int Detail27SortOrder { get; set; }


public int Field54Id { get; set; }
public string Field54Name { get; set; }
public string Field54Description { get; set; }
public DateTime Field54CreatedAt { get; set; }
public DateTime? Field54UpdatedAt { get; set; }
public string Field54CreatedBy { get; set; }
public bool IsField54Active { get; set; }
public int Field54SortOrder { get; set; }


public int Record34Id { get; set; }
public string Record34Name { get; set; }
public string Record34Description { get; set; }
public DateTime Record34CreatedAt { get; set; }
public DateTime? Record34UpdatedAt { get; set; }
public string Record34CreatedBy { get; set; }
public bool IsRecord34Active { get; set; }
public int Record34SortOrder { get; set; }


public int Record18Id { get; set; }
public string Record18Name { get; set; }
public string Record18Description { get; set; }
public DateTime Record18CreatedAt { get; set; }
public DateTime? Record18UpdatedAt { get; set; }
public string Record18CreatedBy { get; set; }
public bool IsRecord18Active { get; set; }
public int Record18SortOrder { get; set; }


public int Config83Id { get; set; }
public string Config83Name { get; set; }
public string Config83Description { get; set; }
public DateTime Config83CreatedAt { get; set; }
public DateTime? Config83UpdatedAt { get; set; }
public string Config83CreatedBy { get; set; }
public bool IsConfig83Active { get; set; }
public int Config83SortOrder { get; set; }


public int Record15Id { get; set; }
public string Record15Name { get; set; }
public string Record15Description { get; set; }
public DateTime Record15CreatedAt { get; set; }
public DateTime? Record15UpdatedAt { get; set; }
public string Record15CreatedBy { get; set; }
public bool IsRecord15Active { get; set; }
public int Record15SortOrder { get; set; }


public int Param57Id { get; set; }
public string Param57Name { get; set; }
public string Param57Description { get; set; }
public DateTime Param57CreatedAt { get; set; }
public DateTime? Param57UpdatedAt { get; set; }
public string Param57CreatedBy { get; set; }
public bool IsParam57Active { get; set; }
public int Param57SortOrder { get; set; }


public int Attr23Id { get; set; }
public string Attr23Name { get; set; }
public string Attr23Description { get; set; }
public DateTime Attr23CreatedAt { get; set; }
public DateTime? Attr23UpdatedAt { get; set; }
public string Attr23CreatedBy { get; set; }
public bool IsAttr23Active { get; set; }
public int Attr23SortOrder { get; set; }


public int Attr19Id { get; set; }
public string Attr19Name { get; set; }
public string Attr19Description { get; set; }
public DateTime Attr19CreatedAt { get; set; }
public DateTime? Attr19UpdatedAt { get; set; }
public string Attr19CreatedBy { get; set; }
public bool IsAttr19Active { get; set; }
public int Attr19SortOrder { get; set; }


public int Entry88Id { get; set; }
public string Entry88Name { get; set; }
public string Entry88Description { get; set; }
public DateTime Entry88CreatedAt { get; set; }
public DateTime? Entry88UpdatedAt { get; set; }
public string Entry88CreatedBy { get; set; }
public bool IsEntry88Active { get; set; }
public int Entry88SortOrder { get; set; }


public int Field93Id { get; set; }
public string Field93Name { get; set; }
public string Field93Description { get; set; }
public DateTime Field93CreatedAt { get; set; }
public DateTime? Field93UpdatedAt { get; set; }
public string Field93CreatedBy { get; set; }
public bool IsField93Active { get; set; }
public int Field93SortOrder { get; set; }


public int Param45Id { get; set; }
public string Param45Name { get; set; }
public string Param45Description { get; set; }
public DateTime Param45CreatedAt { get; set; }
public DateTime? Param45UpdatedAt { get; set; }
public string Param45CreatedBy { get; set; }
public bool IsParam45Active { get; set; }
public int Param45SortOrder { get; set; }


public int Field73Id { get; set; }
public string Field73Name { get; set; }
public string Field73Description { get; set; }
public DateTime Field73CreatedAt { get; set; }
public DateTime? Field73UpdatedAt { get; set; }
public string Field73CreatedBy { get; set; }
public bool IsField73Active { get; set; }
public int Field73SortOrder { get; set; }


public int Detail1Id { get; set; }
public string Detail1Name { get; set; }
public string Detail1Description { get; set; }
public DateTime Detail1CreatedAt { get; set; }
public DateTime? Detail1UpdatedAt { get; set; }
public string Detail1CreatedBy { get; set; }
public bool IsDetail1Active { get; set; }
public int Detail1SortOrder { get; set; }


public int Param41Id { get; set; }
public string Param41Name { get; set; }
public string Param41Description { get; set; }
public DateTime Param41CreatedAt { get; set; }
public DateTime? Param41UpdatedAt { get; set; }
public string Param41CreatedBy { get; set; }
public bool IsParam41Active { get; set; }
public int Param41SortOrder { get; set; }


public int Entry62Id { get; set; }
public string Entry62Name { get; set; }
public string Entry62Description { get; set; }
public DateTime Entry62CreatedAt { get; set; }
public DateTime? Entry62UpdatedAt { get; set; }
public string Entry62CreatedBy { get; set; }
public bool IsEntry62Active { get; set; }
public int Entry62SortOrder { get; set; }


public int Record20Id { get; set; }
public string Record20Name { get; set; }
public string Record20Description { get; set; }
public DateTime Record20CreatedAt { get; set; }
public DateTime? Record20UpdatedAt { get; set; }
public string Record20CreatedBy { get; set; }
public bool IsRecord20Active { get; set; }
public int Record20SortOrder { get; set; }


public int Config92Id { get; set; }
public string Config92Name { get; set; }
public string Config92Description { get; set; }
public DateTime Config92CreatedAt { get; set; }
public DateTime? Config92UpdatedAt { get; set; }
public string Config92CreatedBy { get; set; }
public bool IsConfig92Active { get; set; }
public int Config92SortOrder { get; set; }


public int Attr87Id { get; set; }
public string Attr87Name { get; set; }
public string Attr87Description { get; set; }
public DateTime Attr87CreatedAt { get; set; }
public DateTime? Attr87UpdatedAt { get; set; }
public string Attr87CreatedBy { get; set; }
public bool IsAttr87Active { get; set; }
public int Attr87SortOrder { get; set; }


public int Field98Id { get; set; }
public string Field98Name { get; set; }
public string Field98Description { get; set; }
public DateTime Field98CreatedAt { get; set; }
public DateTime? Field98UpdatedAt { get; set; }
public string Field98CreatedBy { get; set; }
public bool IsField98Active { get; set; }
public int Field98SortOrder { get; set; }


public int Item48Id { get; set; }
public string Item48Name { get; set; }
public string Item48Description { get; set; }
public DateTime Item48CreatedAt { get; set; }
public DateTime? Item48UpdatedAt { get; set; }
public string Item48CreatedBy { get; set; }
public bool IsItem48Active { get; set; }
public int Item48SortOrder { get; set; }


public int Detail95Id { get; set; }
public string Detail95Name { get; set; }
public string Detail95Description { get; set; }
public DateTime Detail95CreatedAt { get; set; }
public DateTime? Detail95UpdatedAt { get; set; }
public string Detail95CreatedBy { get; set; }
public bool IsDetail95Active { get; set; }
public int Detail95SortOrder { get; set; }


public int Field14Id { get; set; }
public string Field14Name { get; set; }
public string Field14Description { get; set; }
public DateTime Field14CreatedAt { get; set; }
public DateTime? Field14UpdatedAt { get; set; }
public string Field14CreatedBy { get; set; }
public bool IsField14Active { get; set; }
public int Field14SortOrder { get; set; }


public int Detail77Id { get; set; }
public string Detail77Name { get; set; }
public string Detail77Description { get; set; }
public DateTime Detail77CreatedAt { get; set; }
public DateTime? Detail77UpdatedAt { get; set; }
public string Detail77CreatedBy { get; set; }
public bool IsDetail77Active { get; set; }
public int Detail77SortOrder { get; set; }


public int Attr6Id { get; set; }
public string Attr6Name { get; set; }
public string Attr6Description { get; set; }
public DateTime Attr6CreatedAt { get; set; }
public DateTime? Attr6UpdatedAt { get; set; }
public string Attr6CreatedBy { get; set; }
public bool IsAttr6Active { get; set; }
public int Attr6SortOrder { get; set; }


public int Param77Id { get; set; }
public string Param77Name { get; set; }
public string Param77Description { get; set; }
public DateTime Param77CreatedAt { get; set; }
public DateTime? Param77UpdatedAt { get; set; }
public string Param77CreatedBy { get; set; }
public bool IsParam77Active { get; set; }
public int Param77SortOrder { get; set; }


public int Record63Id { get; set; }
public string Record63Name { get; set; }
public string Record63Description { get; set; }
public DateTime Record63CreatedAt { get; set; }
public DateTime? Record63UpdatedAt { get; set; }
public string Record63CreatedBy { get; set; }
public bool IsRecord63Active { get; set; }
public int Record63SortOrder { get; set; }


public int Attr59Id { get; set; }
public string Attr59Name { get; set; }
public string Attr59Description { get; set; }
public DateTime Attr59CreatedAt { get; set; }
public DateTime? Attr59UpdatedAt { get; set; }
public string Attr59CreatedBy { get; set; }
public bool IsAttr59Active { get; set; }
public int Attr59SortOrder { get; set; }


public int Attr26Id { get; set; }
public string Attr26Name { get; set; }
public string Attr26Description { get; set; }
public DateTime Attr26CreatedAt { get; set; }
public DateTime? Attr26UpdatedAt { get; set; }
public string Attr26CreatedBy { get; set; }
public bool IsAttr26Active { get; set; }
public int Attr26SortOrder { get; set; }


public int Entry1Id { get; set; }
public string Entry1Name { get; set; }
public string Entry1Description { get; set; }
public DateTime Entry1CreatedAt { get; set; }
public DateTime? Entry1UpdatedAt { get; set; }
public string Entry1CreatedBy { get; set; }
public bool IsEntry1Active { get; set; }
public int Entry1SortOrder { get; set; }


public int Item4Id { get; set; }
public string Item4Name { get; set; }
public string Item4Description { get; set; }
public DateTime Item4CreatedAt { get; set; }
public DateTime? Item4UpdatedAt { get; set; }
public string Item4CreatedBy { get; set; }
public bool IsItem4Active { get; set; }
public int Item4SortOrder { get; set; }


public int Attr40Id { get; set; }
public string Attr40Name { get; set; }
public string Attr40Description { get; set; }
public DateTime Attr40CreatedAt { get; set; }
public DateTime? Attr40UpdatedAt { get; set; }
public string Attr40CreatedBy { get; set; }
public bool IsAttr40Active { get; set; }
public int Attr40SortOrder { get; set; }

    }
}