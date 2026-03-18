using Admin.Contracts120;
using Admin.Data408;
using Admin.Service;
using Admin.Shared14;
using Auth.Mappers;
using BatchJobs.Handlers443;
using Common.Contracts279;
using Common.Shared;
using Common.Tests350;
using DataAccess.Models;
using Documents.Core;
using Documents.Data419;
using Imaging.Api127;
using Import.Validators;
using Logging.Mappers157;
using Portal.Models413;
using Reporting.Processors;
using Scheduling.Processors25;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portal.Service231
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer25
    {
        private readonly Admin_Data408_Event _admin_Data408_Event;
        private readonly Admin_Data408_Builder1 _admin_Data408_Builder1;
        private readonly Auth_Mappers_Controller9 _auth_Mappers_Controller9;
        private readonly Admin_Shared14_Command11 _admin_Shared14_Command11;
        private readonly Admin_Shared14_Options5 _admin_Shared14_Options5;
        private readonly Documents_Data419_Point _documents_Data419_Point;
        private readonly IDocuments_Data419_Validator2 _iDocuments_Data419_Validator2;
        private readonly Admin_Contracts120_Builder3 _admin_Contracts120_Builder3;

        public Consumer25(Admin_Data408_Event admin_Data408_Event, Admin_Data408_Builder1 admin_Data408_Builder1, Auth_Mappers_Controller9 auth_Mappers_Controller9, Admin_Shared14_Command11 admin_Shared14_Command11, Admin_Shared14_Options5 admin_Shared14_Options5, Documents_Data419_Point documents_Data419_Point, IDocuments_Data419_Validator2 iDocuments_Data419_Validator2, Admin_Contracts120_Builder3 admin_Contracts120_Builder3)
        {
            _admin_Data408_Event = admin_Data408_Event ?? throw new ArgumentNullException(nameof(admin_Data408_Event));
            _admin_Data408_Builder1 = admin_Data408_Builder1 ?? throw new ArgumentNullException(nameof(admin_Data408_Builder1));
            _auth_Mappers_Controller9 = auth_Mappers_Controller9 ?? throw new ArgumentNullException(nameof(auth_Mappers_Controller9));
            _admin_Shared14_Command11 = admin_Shared14_Command11 ?? throw new ArgumentNullException(nameof(admin_Shared14_Command11));
            _admin_Shared14_Options5 = admin_Shared14_Options5 ?? throw new ArgumentNullException(nameof(admin_Shared14_Options5));
            _documents_Data419_Point = documents_Data419_Point ?? throw new ArgumentNullException(nameof(documents_Data419_Point));
            _iDocuments_Data419_Validator2 = iDocuments_Data419_Validator2 ?? throw new ArgumentNullException(nameof(iDocuments_Data419_Validator2));
            _admin_Contracts120_Builder3 = admin_Contracts120_Builder3 ?? throw new ArgumentNullException(nameof(admin_Contracts120_Builder3));
        }

        public Admin_Data408_Event GetAdmin_Data408_Event() => _admin_Data408_Event;
        public Admin_Data408_Builder1 GetAdmin_Data408_Builder1() => _admin_Data408_Builder1;
        public Auth_Mappers_Controller9 GetAuth_Mappers_Controller9() => _auth_Mappers_Controller9;
        public Admin_Shared14_Command11 GetAdmin_Shared14_Command11() => _admin_Shared14_Command11;
        public Admin_Shared14_Options5 GetAdmin_Shared14_Options5() => _admin_Shared14_Options5;
        public Documents_Data419_Point GetDocuments_Data419_Point() => _documents_Data419_Point;
        public IDocuments_Data419_Validator2 GetIDocuments_Data419_Validator2() => _iDocuments_Data419_Validator2;
        public Admin_Contracts120_Builder3 GetAdmin_Contracts120_Builder3() => _admin_Contracts120_Builder3;

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

public int Field92Id { get; set; }
public string Field92Name { get; set; }
public string Field92Description { get; set; }
public DateTime Field92CreatedAt { get; set; }
public DateTime? Field92UpdatedAt { get; set; }
public string Field92CreatedBy { get; set; }
public bool IsField92Active { get; set; }
public int Field92SortOrder { get; set; }


public int Field41Id { get; set; }
public string Field41Name { get; set; }
public string Field41Description { get; set; }
public DateTime Field41CreatedAt { get; set; }
public DateTime? Field41UpdatedAt { get; set; }
public string Field41CreatedBy { get; set; }
public bool IsField41Active { get; set; }
public int Field41SortOrder { get; set; }


public int Attr33Id { get; set; }
public string Attr33Name { get; set; }
public string Attr33Description { get; set; }
public DateTime Attr33CreatedAt { get; set; }
public DateTime? Attr33UpdatedAt { get; set; }
public string Attr33CreatedBy { get; set; }
public bool IsAttr33Active { get; set; }
public int Attr33SortOrder { get; set; }


public int Item76Id { get; set; }
public string Item76Name { get; set; }
public string Item76Description { get; set; }
public DateTime Item76CreatedAt { get; set; }
public DateTime? Item76UpdatedAt { get; set; }
public string Item76CreatedBy { get; set; }
public bool IsItem76Active { get; set; }
public int Item76SortOrder { get; set; }


public int Field76Id { get; set; }
public string Field76Name { get; set; }
public string Field76Description { get; set; }
public DateTime Field76CreatedAt { get; set; }
public DateTime? Field76UpdatedAt { get; set; }
public string Field76CreatedBy { get; set; }
public bool IsField76Active { get; set; }
public int Field76SortOrder { get; set; }


public int Record46Id { get; set; }
public string Record46Name { get; set; }
public string Record46Description { get; set; }
public DateTime Record46CreatedAt { get; set; }
public DateTime? Record46UpdatedAt { get; set; }
public string Record46CreatedBy { get; set; }
public bool IsRecord46Active { get; set; }
public int Record46SortOrder { get; set; }


public int Attr44Id { get; set; }
public string Attr44Name { get; set; }
public string Attr44Description { get; set; }
public DateTime Attr44CreatedAt { get; set; }
public DateTime? Attr44UpdatedAt { get; set; }
public string Attr44CreatedBy { get; set; }
public bool IsAttr44Active { get; set; }
public int Attr44SortOrder { get; set; }


public int Detail36Id { get; set; }
public string Detail36Name { get; set; }
public string Detail36Description { get; set; }
public DateTime Detail36CreatedAt { get; set; }
public DateTime? Detail36UpdatedAt { get; set; }
public string Detail36CreatedBy { get; set; }
public bool IsDetail36Active { get; set; }
public int Detail36SortOrder { get; set; }


public int Item45Id { get; set; }
public string Item45Name { get; set; }
public string Item45Description { get; set; }
public DateTime Item45CreatedAt { get; set; }
public DateTime? Item45UpdatedAt { get; set; }
public string Item45CreatedBy { get; set; }
public bool IsItem45Active { get; set; }
public int Item45SortOrder { get; set; }


public int Item10Id { get; set; }
public string Item10Name { get; set; }
public string Item10Description { get; set; }
public DateTime Item10CreatedAt { get; set; }
public DateTime? Item10UpdatedAt { get; set; }
public string Item10CreatedBy { get; set; }
public bool IsItem10Active { get; set; }
public int Item10SortOrder { get; set; }


public int Item79Id { get; set; }
public string Item79Name { get; set; }
public string Item79Description { get; set; }
public DateTime Item79CreatedAt { get; set; }
public DateTime? Item79UpdatedAt { get; set; }
public string Item79CreatedBy { get; set; }
public bool IsItem79Active { get; set; }
public int Item79SortOrder { get; set; }


public int Config60Id { get; set; }
public string Config60Name { get; set; }
public string Config60Description { get; set; }
public DateTime Config60CreatedAt { get; set; }
public DateTime? Config60UpdatedAt { get; set; }
public string Config60CreatedBy { get; set; }
public bool IsConfig60Active { get; set; }
public int Config60SortOrder { get; set; }


public int Param41Id { get; set; }
public string Param41Name { get; set; }
public string Param41Description { get; set; }
public DateTime Param41CreatedAt { get; set; }
public DateTime? Param41UpdatedAt { get; set; }
public string Param41CreatedBy { get; set; }
public bool IsParam41Active { get; set; }
public int Param41SortOrder { get; set; }


public int Attr84Id { get; set; }
public string Attr84Name { get; set; }
public string Attr84Description { get; set; }
public DateTime Attr84CreatedAt { get; set; }
public DateTime? Attr84UpdatedAt { get; set; }
public string Attr84CreatedBy { get; set; }
public bool IsAttr84Active { get; set; }
public int Attr84SortOrder { get; set; }


public int Item84Id { get; set; }
public string Item84Name { get; set; }
public string Item84Description { get; set; }
public DateTime Item84CreatedAt { get; set; }
public DateTime? Item84UpdatedAt { get; set; }
public string Item84CreatedBy { get; set; }
public bool IsItem84Active { get; set; }
public int Item84SortOrder { get; set; }


public int Attr25Id { get; set; }
public string Attr25Name { get; set; }
public string Attr25Description { get; set; }
public DateTime Attr25CreatedAt { get; set; }
public DateTime? Attr25UpdatedAt { get; set; }
public string Attr25CreatedBy { get; set; }
public bool IsAttr25Active { get; set; }
public int Attr25SortOrder { get; set; }


public int Attr97Id { get; set; }
public string Attr97Name { get; set; }
public string Attr97Description { get; set; }
public DateTime Attr97CreatedAt { get; set; }
public DateTime? Attr97UpdatedAt { get; set; }
public string Attr97CreatedBy { get; set; }
public bool IsAttr97Active { get; set; }
public int Attr97SortOrder { get; set; }


public int Item90Id { get; set; }
public string Item90Name { get; set; }
public string Item90Description { get; set; }
public DateTime Item90CreatedAt { get; set; }
public DateTime? Item90UpdatedAt { get; set; }
public string Item90CreatedBy { get; set; }
public bool IsItem90Active { get; set; }
public int Item90SortOrder { get; set; }


public int Param49Id { get; set; }
public string Param49Name { get; set; }
public string Param49Description { get; set; }
public DateTime Param49CreatedAt { get; set; }
public DateTime? Param49UpdatedAt { get; set; }
public string Param49CreatedBy { get; set; }
public bool IsParam49Active { get; set; }
public int Param49SortOrder { get; set; }


public int Entry4Id { get; set; }
public string Entry4Name { get; set; }
public string Entry4Description { get; set; }
public DateTime Entry4CreatedAt { get; set; }
public DateTime? Entry4UpdatedAt { get; set; }
public string Entry4CreatedBy { get; set; }
public bool IsEntry4Active { get; set; }
public int Entry4SortOrder { get; set; }


public int Entry76Id { get; set; }
public string Entry76Name { get; set; }
public string Entry76Description { get; set; }
public DateTime Entry76CreatedAt { get; set; }
public DateTime? Entry76UpdatedAt { get; set; }
public string Entry76CreatedBy { get; set; }
public bool IsEntry76Active { get; set; }
public int Entry76SortOrder { get; set; }


public int Attr14Id { get; set; }
public string Attr14Name { get; set; }
public string Attr14Description { get; set; }
public DateTime Attr14CreatedAt { get; set; }
public DateTime? Attr14UpdatedAt { get; set; }
public string Attr14CreatedBy { get; set; }
public bool IsAttr14Active { get; set; }
public int Attr14SortOrder { get; set; }


public int Config78Id { get; set; }
public string Config78Name { get; set; }
public string Config78Description { get; set; }
public DateTime Config78CreatedAt { get; set; }
public DateTime? Config78UpdatedAt { get; set; }
public string Config78CreatedBy { get; set; }
public bool IsConfig78Active { get; set; }
public int Config78SortOrder { get; set; }


public int Detail81Id { get; set; }
public string Detail81Name { get; set; }
public string Detail81Description { get; set; }
public DateTime Detail81CreatedAt { get; set; }
public DateTime? Detail81UpdatedAt { get; set; }
public string Detail81CreatedBy { get; set; }
public bool IsDetail81Active { get; set; }
public int Detail81SortOrder { get; set; }


public int Field78Id { get; set; }
public string Field78Name { get; set; }
public string Field78Description { get; set; }
public DateTime Field78CreatedAt { get; set; }
public DateTime? Field78UpdatedAt { get; set; }
public string Field78CreatedBy { get; set; }
public bool IsField78Active { get; set; }
public int Field78SortOrder { get; set; }


public int Record69Id { get; set; }
public string Record69Name { get; set; }
public string Record69Description { get; set; }
public DateTime Record69CreatedAt { get; set; }
public DateTime? Record69UpdatedAt { get; set; }
public string Record69CreatedBy { get; set; }
public bool IsRecord69Active { get; set; }
public int Record69SortOrder { get; set; }


public int Record82Id { get; set; }
public string Record82Name { get; set; }
public string Record82Description { get; set; }
public DateTime Record82CreatedAt { get; set; }
public DateTime? Record82UpdatedAt { get; set; }
public string Record82CreatedBy { get; set; }
public bool IsRecord82Active { get; set; }
public int Record82SortOrder { get; set; }


public int Entry47Id { get; set; }
public string Entry47Name { get; set; }
public string Entry47Description { get; set; }
public DateTime Entry47CreatedAt { get; set; }
public DateTime? Entry47UpdatedAt { get; set; }
public string Entry47CreatedBy { get; set; }
public bool IsEntry47Active { get; set; }
public int Entry47SortOrder { get; set; }


public int Attr17Id { get; set; }
public string Attr17Name { get; set; }
public string Attr17Description { get; set; }
public DateTime Attr17CreatedAt { get; set; }
public DateTime? Attr17UpdatedAt { get; set; }
public string Attr17CreatedBy { get; set; }
public bool IsAttr17Active { get; set; }
public int Attr17SortOrder { get; set; }


public int Config89Id { get; set; }
public string Config89Name { get; set; }
public string Config89Description { get; set; }
public DateTime Config89CreatedAt { get; set; }
public DateTime? Config89UpdatedAt { get; set; }
public string Config89CreatedBy { get; set; }
public bool IsConfig89Active { get; set; }
public int Config89SortOrder { get; set; }


public int Entry6Id { get; set; }
public string Entry6Name { get; set; }
public string Entry6Description { get; set; }
public DateTime Entry6CreatedAt { get; set; }
public DateTime? Entry6UpdatedAt { get; set; }
public string Entry6CreatedBy { get; set; }
public bool IsEntry6Active { get; set; }
public int Entry6SortOrder { get; set; }


public int Param87Id { get; set; }
public string Param87Name { get; set; }
public string Param87Description { get; set; }
public DateTime Param87CreatedAt { get; set; }
public DateTime? Param87UpdatedAt { get; set; }
public string Param87CreatedBy { get; set; }
public bool IsParam87Active { get; set; }
public int Param87SortOrder { get; set; }


public int Config45Id { get; set; }
public string Config45Name { get; set; }
public string Config45Description { get; set; }
public DateTime Config45CreatedAt { get; set; }
public DateTime? Config45UpdatedAt { get; set; }
public string Config45CreatedBy { get; set; }
public bool IsConfig45Active { get; set; }
public int Config45SortOrder { get; set; }


public int Config9Id { get; set; }
public string Config9Name { get; set; }
public string Config9Description { get; set; }
public DateTime Config9CreatedAt { get; set; }
public DateTime? Config9UpdatedAt { get; set; }
public string Config9CreatedBy { get; set; }
public bool IsConfig9Active { get; set; }
public int Config9SortOrder { get; set; }


public int Config97Id { get; set; }
public string Config97Name { get; set; }
public string Config97Description { get; set; }
public DateTime Config97CreatedAt { get; set; }
public DateTime? Config97UpdatedAt { get; set; }
public string Config97CreatedBy { get; set; }
public bool IsConfig97Active { get; set; }
public int Config97SortOrder { get; set; }


public int Config97Id { get; set; }
public string Config97Name { get; set; }
public string Config97Description { get; set; }
public DateTime Config97CreatedAt { get; set; }
public DateTime? Config97UpdatedAt { get; set; }
public string Config97CreatedBy { get; set; }
public bool IsConfig97Active { get; set; }
public int Config97SortOrder { get; set; }


public int Detail6Id { get; set; }
public string Detail6Name { get; set; }
public string Detail6Description { get; set; }
public DateTime Detail6CreatedAt { get; set; }
public DateTime? Detail6UpdatedAt { get; set; }
public string Detail6CreatedBy { get; set; }
public bool IsDetail6Active { get; set; }
public int Detail6SortOrder { get; set; }


public int Attr34Id { get; set; }
public string Attr34Name { get; set; }
public string Attr34Description { get; set; }
public DateTime Attr34CreatedAt { get; set; }
public DateTime? Attr34UpdatedAt { get; set; }
public string Attr34CreatedBy { get; set; }
public bool IsAttr34Active { get; set; }
public int Attr34SortOrder { get; set; }


public int Record29Id { get; set; }
public string Record29Name { get; set; }
public string Record29Description { get; set; }
public DateTime Record29CreatedAt { get; set; }
public DateTime? Record29UpdatedAt { get; set; }
public string Record29CreatedBy { get; set; }
public bool IsRecord29Active { get; set; }
public int Record29SortOrder { get; set; }


public int Field41Id { get; set; }
public string Field41Name { get; set; }
public string Field41Description { get; set; }
public DateTime Field41CreatedAt { get; set; }
public DateTime? Field41UpdatedAt { get; set; }
public string Field41CreatedBy { get; set; }
public bool IsField41Active { get; set; }
public int Field41SortOrder { get; set; }


public int Entry3Id { get; set; }
public string Entry3Name { get; set; }
public string Entry3Description { get; set; }
public DateTime Entry3CreatedAt { get; set; }
public DateTime? Entry3UpdatedAt { get; set; }
public string Entry3CreatedBy { get; set; }
public bool IsEntry3Active { get; set; }
public int Entry3SortOrder { get; set; }


public int Record26Id { get; set; }
public string Record26Name { get; set; }
public string Record26Description { get; set; }
public DateTime Record26CreatedAt { get; set; }
public DateTime? Record26UpdatedAt { get; set; }
public string Record26CreatedBy { get; set; }
public bool IsRecord26Active { get; set; }
public int Record26SortOrder { get; set; }


public int Detail68Id { get; set; }
public string Detail68Name { get; set; }
public string Detail68Description { get; set; }
public DateTime Detail68CreatedAt { get; set; }
public DateTime? Detail68UpdatedAt { get; set; }
public string Detail68CreatedBy { get; set; }
public bool IsDetail68Active { get; set; }
public int Detail68SortOrder { get; set; }


public int Record53Id { get; set; }
public string Record53Name { get; set; }
public string Record53Description { get; set; }
public DateTime Record53CreatedAt { get; set; }
public DateTime? Record53UpdatedAt { get; set; }
public string Record53CreatedBy { get; set; }
public bool IsRecord53Active { get; set; }
public int Record53SortOrder { get; set; }


public int Attr36Id { get; set; }
public string Attr36Name { get; set; }
public string Attr36Description { get; set; }
public DateTime Attr36CreatedAt { get; set; }
public DateTime? Attr36UpdatedAt { get; set; }
public string Attr36CreatedBy { get; set; }
public bool IsAttr36Active { get; set; }
public int Attr36SortOrder { get; set; }


public int Detail72Id { get; set; }
public string Detail72Name { get; set; }
public string Detail72Description { get; set; }
public DateTime Detail72CreatedAt { get; set; }
public DateTime? Detail72UpdatedAt { get; set; }
public string Detail72CreatedBy { get; set; }
public bool IsDetail72Active { get; set; }
public int Detail72SortOrder { get; set; }

    }
}