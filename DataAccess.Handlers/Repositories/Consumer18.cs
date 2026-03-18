using Admin.Client;
using Admin.Web46;
using Auth.Client;
using Auth.Events;
using Auth.Mappers28;
using Auth.Processors319;
using Documents.Core357;
using Documents.Shared487;
using Imaging.Validators;
using Import.Shared;
using Integration.Data;
using Logging.Core159;
using Logging.Data29;
using Logging.Validators359;
using Portal.Client;
using Portal.Contracts;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Core;

namespace DataAccess.Handlers
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer18
    {
        private readonly Admin_Client_Processor4 _admin_Client_Processor4;
        private readonly Admin_Client_Command12 _admin_Client_Command12;
        private readonly Import_Shared_Service2 _import_Shared_Service2;
        private readonly IImport_Shared_Service1 _iImport_Shared_Service1;
        private readonly Import_Shared_Builder3 _import_Shared_Builder3;
        private readonly Portal_Contracts_Service2 _portal_Contracts_Service2;
        private readonly Portal_Contracts_Handler1 _portal_Contracts_Handler1;
        private readonly Auth_Events_Event3 _auth_Events_Event3;

        public Consumer18(Admin_Client_Processor4 admin_Client_Processor4, Admin_Client_Command12 admin_Client_Command12, Import_Shared_Service2 import_Shared_Service2, IImport_Shared_Service1 iImport_Shared_Service1, Import_Shared_Builder3 import_Shared_Builder3, Portal_Contracts_Service2 portal_Contracts_Service2, Portal_Contracts_Handler1 portal_Contracts_Handler1, Auth_Events_Event3 auth_Events_Event3)
        {
            _admin_Client_Processor4 = admin_Client_Processor4 ?? throw new ArgumentNullException(nameof(admin_Client_Processor4));
            _admin_Client_Command12 = admin_Client_Command12 ?? throw new ArgumentNullException(nameof(admin_Client_Command12));
            _import_Shared_Service2 = import_Shared_Service2 ?? throw new ArgumentNullException(nameof(import_Shared_Service2));
            _iImport_Shared_Service1 = iImport_Shared_Service1 ?? throw new ArgumentNullException(nameof(iImport_Shared_Service1));
            _import_Shared_Builder3 = import_Shared_Builder3 ?? throw new ArgumentNullException(nameof(import_Shared_Builder3));
            _portal_Contracts_Service2 = portal_Contracts_Service2 ?? throw new ArgumentNullException(nameof(portal_Contracts_Service2));
            _portal_Contracts_Handler1 = portal_Contracts_Handler1 ?? throw new ArgumentNullException(nameof(portal_Contracts_Handler1));
            _auth_Events_Event3 = auth_Events_Event3 ?? throw new ArgumentNullException(nameof(auth_Events_Event3));
        }

        public Admin_Client_Processor4 GetAdmin_Client_Processor4() => _admin_Client_Processor4;
        public Admin_Client_Command12 GetAdmin_Client_Command12() => _admin_Client_Command12;
        public Import_Shared_Service2 GetImport_Shared_Service2() => _import_Shared_Service2;
        public IImport_Shared_Service1 GetIImport_Shared_Service1() => _iImport_Shared_Service1;
        public Import_Shared_Builder3 GetImport_Shared_Builder3() => _import_Shared_Builder3;
        public Portal_Contracts_Service2 GetPortal_Contracts_Service2() => _portal_Contracts_Service2;
        public Portal_Contracts_Handler1 GetPortal_Contracts_Handler1() => _portal_Contracts_Handler1;
        public Auth_Events_Event3 GetAuth_Events_Event3() => _auth_Events_Event3;

/// <summary>
/// Validates the Consumer18 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer18(Consumer18Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer18));
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
/// Processes the Consumer18 operation asynchronously.
/// </summary>
public async Task<Consumer18Result> ProcessConsumer18Async(
    Consumer18Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer18), request.Id);

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
            return new Consumer18Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer18));
        return new Consumer18Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer18));
        return new Consumer18Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer18 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer18Dto>> GetConsumer18ListAsync(
    Consumer18Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer18Entity>().AsQueryable();

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
        .Select(x => new Consumer18Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer18Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer18Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer18Service(
    ILogger<Consumer18Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer18:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer18 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer18Data> GetCachedConsumer18Async(string key)
{
    var cacheKey = $"Consumer18_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer18Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer18SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Field2Id { get; set; }
public string Field2Name { get; set; }
public string Field2Description { get; set; }
public DateTime Field2CreatedAt { get; set; }
public DateTime? Field2UpdatedAt { get; set; }
public string Field2CreatedBy { get; set; }
public bool IsField2Active { get; set; }
public int Field2SortOrder { get; set; }


public int Param9Id { get; set; }
public string Param9Name { get; set; }
public string Param9Description { get; set; }
public DateTime Param9CreatedAt { get; set; }
public DateTime? Param9UpdatedAt { get; set; }
public string Param9CreatedBy { get; set; }
public bool IsParam9Active { get; set; }
public int Param9SortOrder { get; set; }


public int Field59Id { get; set; }
public string Field59Name { get; set; }
public string Field59Description { get; set; }
public DateTime Field59CreatedAt { get; set; }
public DateTime? Field59UpdatedAt { get; set; }
public string Field59CreatedBy { get; set; }
public bool IsField59Active { get; set; }
public int Field59SortOrder { get; set; }


public int Config76Id { get; set; }
public string Config76Name { get; set; }
public string Config76Description { get; set; }
public DateTime Config76CreatedAt { get; set; }
public DateTime? Config76UpdatedAt { get; set; }
public string Config76CreatedBy { get; set; }
public bool IsConfig76Active { get; set; }
public int Config76SortOrder { get; set; }


public int Param75Id { get; set; }
public string Param75Name { get; set; }
public string Param75Description { get; set; }
public DateTime Param75CreatedAt { get; set; }
public DateTime? Param75UpdatedAt { get; set; }
public string Param75CreatedBy { get; set; }
public bool IsParam75Active { get; set; }
public int Param75SortOrder { get; set; }


public int Detail27Id { get; set; }
public string Detail27Name { get; set; }
public string Detail27Description { get; set; }
public DateTime Detail27CreatedAt { get; set; }
public DateTime? Detail27UpdatedAt { get; set; }
public string Detail27CreatedBy { get; set; }
public bool IsDetail27Active { get; set; }
public int Detail27SortOrder { get; set; }


public int Config97Id { get; set; }
public string Config97Name { get; set; }
public string Config97Description { get; set; }
public DateTime Config97CreatedAt { get; set; }
public DateTime? Config97UpdatedAt { get; set; }
public string Config97CreatedBy { get; set; }
public bool IsConfig97Active { get; set; }
public int Config97SortOrder { get; set; }


public int Config2Id { get; set; }
public string Config2Name { get; set; }
public string Config2Description { get; set; }
public DateTime Config2CreatedAt { get; set; }
public DateTime? Config2UpdatedAt { get; set; }
public string Config2CreatedBy { get; set; }
public bool IsConfig2Active { get; set; }
public int Config2SortOrder { get; set; }


public int Field31Id { get; set; }
public string Field31Name { get; set; }
public string Field31Description { get; set; }
public DateTime Field31CreatedAt { get; set; }
public DateTime? Field31UpdatedAt { get; set; }
public string Field31CreatedBy { get; set; }
public bool IsField31Active { get; set; }
public int Field31SortOrder { get; set; }


public int Record17Id { get; set; }
public string Record17Name { get; set; }
public string Record17Description { get; set; }
public DateTime Record17CreatedAt { get; set; }
public DateTime? Record17UpdatedAt { get; set; }
public string Record17CreatedBy { get; set; }
public bool IsRecord17Active { get; set; }
public int Record17SortOrder { get; set; }


public int Param60Id { get; set; }
public string Param60Name { get; set; }
public string Param60Description { get; set; }
public DateTime Param60CreatedAt { get; set; }
public DateTime? Param60UpdatedAt { get; set; }
public string Param60CreatedBy { get; set; }
public bool IsParam60Active { get; set; }
public int Param60SortOrder { get; set; }


public int Field97Id { get; set; }
public string Field97Name { get; set; }
public string Field97Description { get; set; }
public DateTime Field97CreatedAt { get; set; }
public DateTime? Field97UpdatedAt { get; set; }
public string Field97CreatedBy { get; set; }
public bool IsField97Active { get; set; }
public int Field97SortOrder { get; set; }


public int Item31Id { get; set; }
public string Item31Name { get; set; }
public string Item31Description { get; set; }
public DateTime Item31CreatedAt { get; set; }
public DateTime? Item31UpdatedAt { get; set; }
public string Item31CreatedBy { get; set; }
public bool IsItem31Active { get; set; }
public int Item31SortOrder { get; set; }


public int Field6Id { get; set; }
public string Field6Name { get; set; }
public string Field6Description { get; set; }
public DateTime Field6CreatedAt { get; set; }
public DateTime? Field6UpdatedAt { get; set; }
public string Field6CreatedBy { get; set; }
public bool IsField6Active { get; set; }
public int Field6SortOrder { get; set; }


public int Item61Id { get; set; }
public string Item61Name { get; set; }
public string Item61Description { get; set; }
public DateTime Item61CreatedAt { get; set; }
public DateTime? Item61UpdatedAt { get; set; }
public string Item61CreatedBy { get; set; }
public bool IsItem61Active { get; set; }
public int Item61SortOrder { get; set; }


public int Param73Id { get; set; }
public string Param73Name { get; set; }
public string Param73Description { get; set; }
public DateTime Param73CreatedAt { get; set; }
public DateTime? Param73UpdatedAt { get; set; }
public string Param73CreatedBy { get; set; }
public bool IsParam73Active { get; set; }
public int Param73SortOrder { get; set; }


public int Detail89Id { get; set; }
public string Detail89Name { get; set; }
public string Detail89Description { get; set; }
public DateTime Detail89CreatedAt { get; set; }
public DateTime? Detail89UpdatedAt { get; set; }
public string Detail89CreatedBy { get; set; }
public bool IsDetail89Active { get; set; }
public int Detail89SortOrder { get; set; }


public int Entry54Id { get; set; }
public string Entry54Name { get; set; }
public string Entry54Description { get; set; }
public DateTime Entry54CreatedAt { get; set; }
public DateTime? Entry54UpdatedAt { get; set; }
public string Entry54CreatedBy { get; set; }
public bool IsEntry54Active { get; set; }
public int Entry54SortOrder { get; set; }


public int Config31Id { get; set; }
public string Config31Name { get; set; }
public string Config31Description { get; set; }
public DateTime Config31CreatedAt { get; set; }
public DateTime? Config31UpdatedAt { get; set; }
public string Config31CreatedBy { get; set; }
public bool IsConfig31Active { get; set; }
public int Config31SortOrder { get; set; }


public int Config64Id { get; set; }
public string Config64Name { get; set; }
public string Config64Description { get; set; }
public DateTime Config64CreatedAt { get; set; }
public DateTime? Config64UpdatedAt { get; set; }
public string Config64CreatedBy { get; set; }
public bool IsConfig64Active { get; set; }
public int Config64SortOrder { get; set; }


public int Item66Id { get; set; }
public string Item66Name { get; set; }
public string Item66Description { get; set; }
public DateTime Item66CreatedAt { get; set; }
public DateTime? Item66UpdatedAt { get; set; }
public string Item66CreatedBy { get; set; }
public bool IsItem66Active { get; set; }
public int Item66SortOrder { get; set; }


public int Detail55Id { get; set; }
public string Detail55Name { get; set; }
public string Detail55Description { get; set; }
public DateTime Detail55CreatedAt { get; set; }
public DateTime? Detail55UpdatedAt { get; set; }
public string Detail55CreatedBy { get; set; }
public bool IsDetail55Active { get; set; }
public int Detail55SortOrder { get; set; }


public int Item98Id { get; set; }
public string Item98Name { get; set; }
public string Item98Description { get; set; }
public DateTime Item98CreatedAt { get; set; }
public DateTime? Item98UpdatedAt { get; set; }
public string Item98CreatedBy { get; set; }
public bool IsItem98Active { get; set; }
public int Item98SortOrder { get; set; }


public int Param11Id { get; set; }
public string Param11Name { get; set; }
public string Param11Description { get; set; }
public DateTime Param11CreatedAt { get; set; }
public DateTime? Param11UpdatedAt { get; set; }
public string Param11CreatedBy { get; set; }
public bool IsParam11Active { get; set; }
public int Param11SortOrder { get; set; }


public int Config31Id { get; set; }
public string Config31Name { get; set; }
public string Config31Description { get; set; }
public DateTime Config31CreatedAt { get; set; }
public DateTime? Config31UpdatedAt { get; set; }
public string Config31CreatedBy { get; set; }
public bool IsConfig31Active { get; set; }
public int Config31SortOrder { get; set; }


public int Config2Id { get; set; }
public string Config2Name { get; set; }
public string Config2Description { get; set; }
public DateTime Config2CreatedAt { get; set; }
public DateTime? Config2UpdatedAt { get; set; }
public string Config2CreatedBy { get; set; }
public bool IsConfig2Active { get; set; }
public int Config2SortOrder { get; set; }


public int Record33Id { get; set; }
public string Record33Name { get; set; }
public string Record33Description { get; set; }
public DateTime Record33CreatedAt { get; set; }
public DateTime? Record33UpdatedAt { get; set; }
public string Record33CreatedBy { get; set; }
public bool IsRecord33Active { get; set; }
public int Record33SortOrder { get; set; }


public int Config81Id { get; set; }
public string Config81Name { get; set; }
public string Config81Description { get; set; }
public DateTime Config81CreatedAt { get; set; }
public DateTime? Config81UpdatedAt { get; set; }
public string Config81CreatedBy { get; set; }
public bool IsConfig81Active { get; set; }
public int Config81SortOrder { get; set; }


public int Item54Id { get; set; }
public string Item54Name { get; set; }
public string Item54Description { get; set; }
public DateTime Item54CreatedAt { get; set; }
public DateTime? Item54UpdatedAt { get; set; }
public string Item54CreatedBy { get; set; }
public bool IsItem54Active { get; set; }
public int Item54SortOrder { get; set; }


public int Field87Id { get; set; }
public string Field87Name { get; set; }
public string Field87Description { get; set; }
public DateTime Field87CreatedAt { get; set; }
public DateTime? Field87UpdatedAt { get; set; }
public string Field87CreatedBy { get; set; }
public bool IsField87Active { get; set; }
public int Field87SortOrder { get; set; }


public int Config7Id { get; set; }
public string Config7Name { get; set; }
public string Config7Description { get; set; }
public DateTime Config7CreatedAt { get; set; }
public DateTime? Config7UpdatedAt { get; set; }
public string Config7CreatedBy { get; set; }
public bool IsConfig7Active { get; set; }
public int Config7SortOrder { get; set; }


public int Attr95Id { get; set; }
public string Attr95Name { get; set; }
public string Attr95Description { get; set; }
public DateTime Attr95CreatedAt { get; set; }
public DateTime? Attr95UpdatedAt { get; set; }
public string Attr95CreatedBy { get; set; }
public bool IsAttr95Active { get; set; }
public int Attr95SortOrder { get; set; }


public int Entry11Id { get; set; }
public string Entry11Name { get; set; }
public string Entry11Description { get; set; }
public DateTime Entry11CreatedAt { get; set; }
public DateTime? Entry11UpdatedAt { get; set; }
public string Entry11CreatedBy { get; set; }
public bool IsEntry11Active { get; set; }
public int Entry11SortOrder { get; set; }


public int Item63Id { get; set; }
public string Item63Name { get; set; }
public string Item63Description { get; set; }
public DateTime Item63CreatedAt { get; set; }
public DateTime? Item63UpdatedAt { get; set; }
public string Item63CreatedBy { get; set; }
public bool IsItem63Active { get; set; }
public int Item63SortOrder { get; set; }


public int Field89Id { get; set; }
public string Field89Name { get; set; }
public string Field89Description { get; set; }
public DateTime Field89CreatedAt { get; set; }
public DateTime? Field89UpdatedAt { get; set; }
public string Field89CreatedBy { get; set; }
public bool IsField89Active { get; set; }
public int Field89SortOrder { get; set; }


public int Record43Id { get; set; }
public string Record43Name { get; set; }
public string Record43Description { get; set; }
public DateTime Record43CreatedAt { get; set; }
public DateTime? Record43UpdatedAt { get; set; }
public string Record43CreatedBy { get; set; }
public bool IsRecord43Active { get; set; }
public int Record43SortOrder { get; set; }


public int Param78Id { get; set; }
public string Param78Name { get; set; }
public string Param78Description { get; set; }
public DateTime Param78CreatedAt { get; set; }
public DateTime? Param78UpdatedAt { get; set; }
public string Param78CreatedBy { get; set; }
public bool IsParam78Active { get; set; }
public int Param78SortOrder { get; set; }


public int Attr70Id { get; set; }
public string Attr70Name { get; set; }
public string Attr70Description { get; set; }
public DateTime Attr70CreatedAt { get; set; }
public DateTime? Attr70UpdatedAt { get; set; }
public string Attr70CreatedBy { get; set; }
public bool IsAttr70Active { get; set; }
public int Attr70SortOrder { get; set; }


public int Config93Id { get; set; }
public string Config93Name { get; set; }
public string Config93Description { get; set; }
public DateTime Config93CreatedAt { get; set; }
public DateTime? Config93UpdatedAt { get; set; }
public string Config93CreatedBy { get; set; }
public bool IsConfig93Active { get; set; }
public int Config93SortOrder { get; set; }


public int Entry2Id { get; set; }
public string Entry2Name { get; set; }
public string Entry2Description { get; set; }
public DateTime Entry2CreatedAt { get; set; }
public DateTime? Entry2UpdatedAt { get; set; }
public string Entry2CreatedBy { get; set; }
public bool IsEntry2Active { get; set; }
public int Entry2SortOrder { get; set; }


public int Detail93Id { get; set; }
public string Detail93Name { get; set; }
public string Detail93Description { get; set; }
public DateTime Detail93CreatedAt { get; set; }
public DateTime? Detail93UpdatedAt { get; set; }
public string Detail93CreatedBy { get; set; }
public bool IsDetail93Active { get; set; }
public int Detail93SortOrder { get; set; }


public int Detail45Id { get; set; }
public string Detail45Name { get; set; }
public string Detail45Description { get; set; }
public DateTime Detail45CreatedAt { get; set; }
public DateTime? Detail45UpdatedAt { get; set; }
public string Detail45CreatedBy { get; set; }
public bool IsDetail45Active { get; set; }
public int Detail45SortOrder { get; set; }


public int Field6Id { get; set; }
public string Field6Name { get; set; }
public string Field6Description { get; set; }
public DateTime Field6CreatedAt { get; set; }
public DateTime? Field6UpdatedAt { get; set; }
public string Field6CreatedBy { get; set; }
public bool IsField6Active { get; set; }
public int Field6SortOrder { get; set; }


public int Config51Id { get; set; }
public string Config51Name { get; set; }
public string Config51Description { get; set; }
public DateTime Config51CreatedAt { get; set; }
public DateTime? Config51UpdatedAt { get; set; }
public string Config51CreatedBy { get; set; }
public bool IsConfig51Active { get; set; }
public int Config51SortOrder { get; set; }


public int Record54Id { get; set; }
public string Record54Name { get; set; }
public string Record54Description { get; set; }
public DateTime Record54CreatedAt { get; set; }
public DateTime? Record54UpdatedAt { get; set; }
public string Record54CreatedBy { get; set; }
public bool IsRecord54Active { get; set; }
public int Record54SortOrder { get; set; }


public int Detail41Id { get; set; }
public string Detail41Name { get; set; }
public string Detail41Description { get; set; }
public DateTime Detail41CreatedAt { get; set; }
public DateTime? Detail41UpdatedAt { get; set; }
public string Detail41CreatedBy { get; set; }
public bool IsDetail41Active { get; set; }
public int Detail41SortOrder { get; set; }

    }
}