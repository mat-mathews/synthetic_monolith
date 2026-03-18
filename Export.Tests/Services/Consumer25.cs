using Admin.Web;
using Auth.Client271;
using Auth.Processors319;
using Common.Data21;
using Common.Mappers343;
using Documents.Service;
using Export.Models;
using GalaxyWorks.Data453;
using Imaging.Mappers93;
using Import.Tests;
using Scheduling.Client187;
using Scheduling.Contracts;
using Scheduling.Web60;
using Security.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Handlers;
using Workflow.Processors;

namespace Export.Tests
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer25
    {
        private readonly Auth_Client271_Manager _auth_Client271_Manager;
        private readonly Common_Data21_Builder4 _common_Data21_Builder4;
        private readonly Common_Data21_Provider2 _common_Data21_Provider2;
        private readonly Scheduling_Client187_Manager _scheduling_Client187_Manager;
        private readonly Utilities_Handlers_Repository12 _utilities_Handlers_Repository12;
        private readonly IExport_Models_Service10 _iExport_Models_Service10;
        private readonly Export_Models_Processor1 _export_Models_Processor1;
        private readonly Security_Api_Processor7 _security_Api_Processor7;

        public Consumer25(Auth_Client271_Manager auth_Client271_Manager, Common_Data21_Builder4 common_Data21_Builder4, Common_Data21_Provider2 common_Data21_Provider2, Scheduling_Client187_Manager scheduling_Client187_Manager, Utilities_Handlers_Repository12 utilities_Handlers_Repository12, IExport_Models_Service10 iExport_Models_Service10, Export_Models_Processor1 export_Models_Processor1, Security_Api_Processor7 security_Api_Processor7)
        {
            _auth_Client271_Manager = auth_Client271_Manager ?? throw new ArgumentNullException(nameof(auth_Client271_Manager));
            _common_Data21_Builder4 = common_Data21_Builder4 ?? throw new ArgumentNullException(nameof(common_Data21_Builder4));
            _common_Data21_Provider2 = common_Data21_Provider2 ?? throw new ArgumentNullException(nameof(common_Data21_Provider2));
            _scheduling_Client187_Manager = scheduling_Client187_Manager ?? throw new ArgumentNullException(nameof(scheduling_Client187_Manager));
            _utilities_Handlers_Repository12 = utilities_Handlers_Repository12 ?? throw new ArgumentNullException(nameof(utilities_Handlers_Repository12));
            _iExport_Models_Service10 = iExport_Models_Service10 ?? throw new ArgumentNullException(nameof(iExport_Models_Service10));
            _export_Models_Processor1 = export_Models_Processor1 ?? throw new ArgumentNullException(nameof(export_Models_Processor1));
            _security_Api_Processor7 = security_Api_Processor7 ?? throw new ArgumentNullException(nameof(security_Api_Processor7));
        }

        public Auth_Client271_Manager GetAuth_Client271_Manager() => _auth_Client271_Manager;
        public Common_Data21_Builder4 GetCommon_Data21_Builder4() => _common_Data21_Builder4;
        public Common_Data21_Provider2 GetCommon_Data21_Provider2() => _common_Data21_Provider2;
        public Scheduling_Client187_Manager GetScheduling_Client187_Manager() => _scheduling_Client187_Manager;
        public Utilities_Handlers_Repository12 GetUtilities_Handlers_Repository12() => _utilities_Handlers_Repository12;
        public IExport_Models_Service10 GetIExport_Models_Service10() => _iExport_Models_Service10;
        public Export_Models_Processor1 GetExport_Models_Processor1() => _export_Models_Processor1;
        public Security_Api_Processor7 GetSecurity_Api_Processor7() => _security_Api_Processor7;

/// <summary>
/// Validates the Consumer25 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer25(Consumer25Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer25));
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
/// Processes the Consumer25 operation asynchronously.
/// </summary>
public async Task<Consumer25Result> ProcessConsumer25Async(
    Consumer25Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer25), request.Id);

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
            return new Consumer25Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer25));
        return new Consumer25Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer25));
        return new Consumer25Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer25 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer25Dto>> GetConsumer25ListAsync(
    Consumer25Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer25Entity>().AsQueryable();

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
        .Select(x => new Consumer25Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer25Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer25Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer25Service(
    ILogger<Consumer25Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer25:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer25 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer25Data> GetCachedConsumer25Async(string key)
{
    var cacheKey = $"Consumer25_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer25Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer25SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Detail99Id { get; set; }
public string Detail99Name { get; set; }
public string Detail99Description { get; set; }
public DateTime Detail99CreatedAt { get; set; }
public DateTime? Detail99UpdatedAt { get; set; }
public string Detail99CreatedBy { get; set; }
public bool IsDetail99Active { get; set; }
public int Detail99SortOrder { get; set; }


public int Config39Id { get; set; }
public string Config39Name { get; set; }
public string Config39Description { get; set; }
public DateTime Config39CreatedAt { get; set; }
public DateTime? Config39UpdatedAt { get; set; }
public string Config39CreatedBy { get; set; }
public bool IsConfig39Active { get; set; }
public int Config39SortOrder { get; set; }


public int Detail25Id { get; set; }
public string Detail25Name { get; set; }
public string Detail25Description { get; set; }
public DateTime Detail25CreatedAt { get; set; }
public DateTime? Detail25UpdatedAt { get; set; }
public string Detail25CreatedBy { get; set; }
public bool IsDetail25Active { get; set; }
public int Detail25SortOrder { get; set; }


public int Config72Id { get; set; }
public string Config72Name { get; set; }
public string Config72Description { get; set; }
public DateTime Config72CreatedAt { get; set; }
public DateTime? Config72UpdatedAt { get; set; }
public string Config72CreatedBy { get; set; }
public bool IsConfig72Active { get; set; }
public int Config72SortOrder { get; set; }


public int Item8Id { get; set; }
public string Item8Name { get; set; }
public string Item8Description { get; set; }
public DateTime Item8CreatedAt { get; set; }
public DateTime? Item8UpdatedAt { get; set; }
public string Item8CreatedBy { get; set; }
public bool IsItem8Active { get; set; }
public int Item8SortOrder { get; set; }


public int Field91Id { get; set; }
public string Field91Name { get; set; }
public string Field91Description { get; set; }
public DateTime Field91CreatedAt { get; set; }
public DateTime? Field91UpdatedAt { get; set; }
public string Field91CreatedBy { get; set; }
public bool IsField91Active { get; set; }
public int Field91SortOrder { get; set; }


public int Param99Id { get; set; }
public string Param99Name { get; set; }
public string Param99Description { get; set; }
public DateTime Param99CreatedAt { get; set; }
public DateTime? Param99UpdatedAt { get; set; }
public string Param99CreatedBy { get; set; }
public bool IsParam99Active { get; set; }
public int Param99SortOrder { get; set; }


public int Item82Id { get; set; }
public string Item82Name { get; set; }
public string Item82Description { get; set; }
public DateTime Item82CreatedAt { get; set; }
public DateTime? Item82UpdatedAt { get; set; }
public string Item82CreatedBy { get; set; }
public bool IsItem82Active { get; set; }
public int Item82SortOrder { get; set; }


public int Detail99Id { get; set; }
public string Detail99Name { get; set; }
public string Detail99Description { get; set; }
public DateTime Detail99CreatedAt { get; set; }
public DateTime? Detail99UpdatedAt { get; set; }
public string Detail99CreatedBy { get; set; }
public bool IsDetail99Active { get; set; }
public int Detail99SortOrder { get; set; }


public int Record53Id { get; set; }
public string Record53Name { get; set; }
public string Record53Description { get; set; }
public DateTime Record53CreatedAt { get; set; }
public DateTime? Record53UpdatedAt { get; set; }
public string Record53CreatedBy { get; set; }
public bool IsRecord53Active { get; set; }
public int Record53SortOrder { get; set; }


public int Item19Id { get; set; }
public string Item19Name { get; set; }
public string Item19Description { get; set; }
public DateTime Item19CreatedAt { get; set; }
public DateTime? Item19UpdatedAt { get; set; }
public string Item19CreatedBy { get; set; }
public bool IsItem19Active { get; set; }
public int Item19SortOrder { get; set; }


public int Item9Id { get; set; }
public string Item9Name { get; set; }
public string Item9Description { get; set; }
public DateTime Item9CreatedAt { get; set; }
public DateTime? Item9UpdatedAt { get; set; }
public string Item9CreatedBy { get; set; }
public bool IsItem9Active { get; set; }
public int Item9SortOrder { get; set; }


public int Detail26Id { get; set; }
public string Detail26Name { get; set; }
public string Detail26Description { get; set; }
public DateTime Detail26CreatedAt { get; set; }
public DateTime? Detail26UpdatedAt { get; set; }
public string Detail26CreatedBy { get; set; }
public bool IsDetail26Active { get; set; }
public int Detail26SortOrder { get; set; }


public int Record26Id { get; set; }
public string Record26Name { get; set; }
public string Record26Description { get; set; }
public DateTime Record26CreatedAt { get; set; }
public DateTime? Record26UpdatedAt { get; set; }
public string Record26CreatedBy { get; set; }
public bool IsRecord26Active { get; set; }
public int Record26SortOrder { get; set; }


public int Detail36Id { get; set; }
public string Detail36Name { get; set; }
public string Detail36Description { get; set; }
public DateTime Detail36CreatedAt { get; set; }
public DateTime? Detail36UpdatedAt { get; set; }
public string Detail36CreatedBy { get; set; }
public bool IsDetail36Active { get; set; }
public int Detail36SortOrder { get; set; }


public int Item79Id { get; set; }
public string Item79Name { get; set; }
public string Item79Description { get; set; }
public DateTime Item79CreatedAt { get; set; }
public DateTime? Item79UpdatedAt { get; set; }
public string Item79CreatedBy { get; set; }
public bool IsItem79Active { get; set; }
public int Item79SortOrder { get; set; }


public int Detail75Id { get; set; }
public string Detail75Name { get; set; }
public string Detail75Description { get; set; }
public DateTime Detail75CreatedAt { get; set; }
public DateTime? Detail75UpdatedAt { get; set; }
public string Detail75CreatedBy { get; set; }
public bool IsDetail75Active { get; set; }
public int Detail75SortOrder { get; set; }


public int Item51Id { get; set; }
public string Item51Name { get; set; }
public string Item51Description { get; set; }
public DateTime Item51CreatedAt { get; set; }
public DateTime? Item51UpdatedAt { get; set; }
public string Item51CreatedBy { get; set; }
public bool IsItem51Active { get; set; }
public int Item51SortOrder { get; set; }


public int Attr62Id { get; set; }
public string Attr62Name { get; set; }
public string Attr62Description { get; set; }
public DateTime Attr62CreatedAt { get; set; }
public DateTime? Attr62UpdatedAt { get; set; }
public string Attr62CreatedBy { get; set; }
public bool IsAttr62Active { get; set; }
public int Attr62SortOrder { get; set; }


public int Record73Id { get; set; }
public string Record73Name { get; set; }
public string Record73Description { get; set; }
public DateTime Record73CreatedAt { get; set; }
public DateTime? Record73UpdatedAt { get; set; }
public string Record73CreatedBy { get; set; }
public bool IsRecord73Active { get; set; }
public int Record73SortOrder { get; set; }


public int Config95Id { get; set; }
public string Config95Name { get; set; }
public string Config95Description { get; set; }
public DateTime Config95CreatedAt { get; set; }
public DateTime? Config95UpdatedAt { get; set; }
public string Config95CreatedBy { get; set; }
public bool IsConfig95Active { get; set; }
public int Config95SortOrder { get; set; }


public int Detail66Id { get; set; }
public string Detail66Name { get; set; }
public string Detail66Description { get; set; }
public DateTime Detail66CreatedAt { get; set; }
public DateTime? Detail66UpdatedAt { get; set; }
public string Detail66CreatedBy { get; set; }
public bool IsDetail66Active { get; set; }
public int Detail66SortOrder { get; set; }


public int Config70Id { get; set; }
public string Config70Name { get; set; }
public string Config70Description { get; set; }
public DateTime Config70CreatedAt { get; set; }
public DateTime? Config70UpdatedAt { get; set; }
public string Config70CreatedBy { get; set; }
public bool IsConfig70Active { get; set; }
public int Config70SortOrder { get; set; }


public int Record51Id { get; set; }
public string Record51Name { get; set; }
public string Record51Description { get; set; }
public DateTime Record51CreatedAt { get; set; }
public DateTime? Record51UpdatedAt { get; set; }
public string Record51CreatedBy { get; set; }
public bool IsRecord51Active { get; set; }
public int Record51SortOrder { get; set; }


public int Entry9Id { get; set; }
public string Entry9Name { get; set; }
public string Entry9Description { get; set; }
public DateTime Entry9CreatedAt { get; set; }
public DateTime? Entry9UpdatedAt { get; set; }
public string Entry9CreatedBy { get; set; }
public bool IsEntry9Active { get; set; }
public int Entry9SortOrder { get; set; }


public int Record27Id { get; set; }
public string Record27Name { get; set; }
public string Record27Description { get; set; }
public DateTime Record27CreatedAt { get; set; }
public DateTime? Record27UpdatedAt { get; set; }
public string Record27CreatedBy { get; set; }
public bool IsRecord27Active { get; set; }
public int Record27SortOrder { get; set; }


public int Param36Id { get; set; }
public string Param36Name { get; set; }
public string Param36Description { get; set; }
public DateTime Param36CreatedAt { get; set; }
public DateTime? Param36UpdatedAt { get; set; }
public string Param36CreatedBy { get; set; }
public bool IsParam36Active { get; set; }
public int Param36SortOrder { get; set; }


public int Field72Id { get; set; }
public string Field72Name { get; set; }
public string Field72Description { get; set; }
public DateTime Field72CreatedAt { get; set; }
public DateTime? Field72UpdatedAt { get; set; }
public string Field72CreatedBy { get; set; }
public bool IsField72Active { get; set; }
public int Field72SortOrder { get; set; }


public int Entry29Id { get; set; }
public string Entry29Name { get; set; }
public string Entry29Description { get; set; }
public DateTime Entry29CreatedAt { get; set; }
public DateTime? Entry29UpdatedAt { get; set; }
public string Entry29CreatedBy { get; set; }
public bool IsEntry29Active { get; set; }
public int Entry29SortOrder { get; set; }


public int Param49Id { get; set; }
public string Param49Name { get; set; }
public string Param49Description { get; set; }
public DateTime Param49CreatedAt { get; set; }
public DateTime? Param49UpdatedAt { get; set; }
public string Param49CreatedBy { get; set; }
public bool IsParam49Active { get; set; }
public int Param49SortOrder { get; set; }


public int Entry72Id { get; set; }
public string Entry72Name { get; set; }
public string Entry72Description { get; set; }
public DateTime Entry72CreatedAt { get; set; }
public DateTime? Entry72UpdatedAt { get; set; }
public string Entry72CreatedBy { get; set; }
public bool IsEntry72Active { get; set; }
public int Entry72SortOrder { get; set; }


public int Record32Id { get; set; }
public string Record32Name { get; set; }
public string Record32Description { get; set; }
public DateTime Record32CreatedAt { get; set; }
public DateTime? Record32UpdatedAt { get; set; }
public string Record32CreatedBy { get; set; }
public bool IsRecord32Active { get; set; }
public int Record32SortOrder { get; set; }


public int Detail71Id { get; set; }
public string Detail71Name { get; set; }
public string Detail71Description { get; set; }
public DateTime Detail71CreatedAt { get; set; }
public DateTime? Detail71UpdatedAt { get; set; }
public string Detail71CreatedBy { get; set; }
public bool IsDetail71Active { get; set; }
public int Detail71SortOrder { get; set; }


public int Record61Id { get; set; }
public string Record61Name { get; set; }
public string Record61Description { get; set; }
public DateTime Record61CreatedAt { get; set; }
public DateTime? Record61UpdatedAt { get; set; }
public string Record61CreatedBy { get; set; }
public bool IsRecord61Active { get; set; }
public int Record61SortOrder { get; set; }


public int Config76Id { get; set; }
public string Config76Name { get; set; }
public string Config76Description { get; set; }
public DateTime Config76CreatedAt { get; set; }
public DateTime? Config76UpdatedAt { get; set; }
public string Config76CreatedBy { get; set; }
public bool IsConfig76Active { get; set; }
public int Config76SortOrder { get; set; }


public int Item35Id { get; set; }
public string Item35Name { get; set; }
public string Item35Description { get; set; }
public DateTime Item35CreatedAt { get; set; }
public DateTime? Item35UpdatedAt { get; set; }
public string Item35CreatedBy { get; set; }
public bool IsItem35Active { get; set; }
public int Item35SortOrder { get; set; }


public int Detail68Id { get; set; }
public string Detail68Name { get; set; }
public string Detail68Description { get; set; }
public DateTime Detail68CreatedAt { get; set; }
public DateTime? Detail68UpdatedAt { get; set; }
public string Detail68CreatedBy { get; set; }
public bool IsDetail68Active { get; set; }
public int Detail68SortOrder { get; set; }


public int Field19Id { get; set; }
public string Field19Name { get; set; }
public string Field19Description { get; set; }
public DateTime Field19CreatedAt { get; set; }
public DateTime? Field19UpdatedAt { get; set; }
public string Field19CreatedBy { get; set; }
public bool IsField19Active { get; set; }
public int Field19SortOrder { get; set; }


public int Config42Id { get; set; }
public string Config42Name { get; set; }
public string Config42Description { get; set; }
public DateTime Config42CreatedAt { get; set; }
public DateTime? Config42UpdatedAt { get; set; }
public string Config42CreatedBy { get; set; }
public bool IsConfig42Active { get; set; }
public int Config42SortOrder { get; set; }


public int Attr63Id { get; set; }
public string Attr63Name { get; set; }
public string Attr63Description { get; set; }
public DateTime Attr63CreatedAt { get; set; }
public DateTime? Attr63UpdatedAt { get; set; }
public string Attr63CreatedBy { get; set; }
public bool IsAttr63Active { get; set; }
public int Attr63SortOrder { get; set; }


public int Record35Id { get; set; }
public string Record35Name { get; set; }
public string Record35Description { get; set; }
public DateTime Record35CreatedAt { get; set; }
public DateTime? Record35UpdatedAt { get; set; }
public string Record35CreatedBy { get; set; }
public bool IsRecord35Active { get; set; }
public int Record35SortOrder { get; set; }


public int Attr67Id { get; set; }
public string Attr67Name { get; set; }
public string Attr67Description { get; set; }
public DateTime Attr67CreatedAt { get; set; }
public DateTime? Attr67UpdatedAt { get; set; }
public string Attr67CreatedBy { get; set; }
public bool IsAttr67Active { get; set; }
public int Attr67SortOrder { get; set; }


public int Entry67Id { get; set; }
public string Entry67Name { get; set; }
public string Entry67Description { get; set; }
public DateTime Entry67CreatedAt { get; set; }
public DateTime? Entry67UpdatedAt { get; set; }
public string Entry67CreatedBy { get; set; }
public bool IsEntry67Active { get; set; }
public int Entry67SortOrder { get; set; }


public int Param41Id { get; set; }
public string Param41Name { get; set; }
public string Param41Description { get; set; }
public DateTime Param41CreatedAt { get; set; }
public DateTime? Param41UpdatedAt { get; set; }
public string Param41CreatedBy { get; set; }
public bool IsParam41Active { get; set; }
public int Param41SortOrder { get; set; }


public int Param71Id { get; set; }
public string Param71Name { get; set; }
public string Param71Description { get; set; }
public DateTime Param71CreatedAt { get; set; }
public DateTime? Param71UpdatedAt { get; set; }
public string Param71CreatedBy { get; set; }
public bool IsParam71Active { get; set; }
public int Param71SortOrder { get; set; }

    }
}