using Admin.Handlers447;
using Auth.Client249;
using Auth.Contracts402;
using Auth.Models23;
using Auth.Processors400;
using Billing.Processors259;
using Common.Contracts;
using Common.Mappers190;
using Documents.Tests;
using Documents.Tests171;
using GalaxyWorks.Data96;
using Integration.Contracts;
using Integration.Models;
using Logging.Core159;
using Notifications.Data446;
using Reporting.Client146;
using Reporting.Processors;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Validators
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer5
    {
        private readonly Auth_Models23_Controller5 _auth_Models23_Controller5;
        private readonly Auth_Models23_Request6 _auth_Models23_Request6;
        private readonly Auth_Client249_Manager _auth_Client249_Manager;
        private readonly Admin_Handlers447_Repository3 _admin_Handlers447_Repository3;
        private readonly Integration_Contracts_Dto6 _integration_Contracts_Dto6;
        private readonly Integration_Contracts_Repository1 _integration_Contracts_Repository1;
        private readonly Documents_Tests171_Provider3 _documents_Tests171_Provider3;
        private readonly Common_Mappers190_Helper3 _common_Mappers190_Helper3;

        public Consumer5(Auth_Models23_Controller5 auth_Models23_Controller5, Auth_Models23_Request6 auth_Models23_Request6, Auth_Client249_Manager auth_Client249_Manager, Admin_Handlers447_Repository3 admin_Handlers447_Repository3, Integration_Contracts_Dto6 integration_Contracts_Dto6, Integration_Contracts_Repository1 integration_Contracts_Repository1, Documents_Tests171_Provider3 documents_Tests171_Provider3, Common_Mappers190_Helper3 common_Mappers190_Helper3)
        {
            _auth_Models23_Controller5 = auth_Models23_Controller5 ?? throw new ArgumentNullException(nameof(auth_Models23_Controller5));
            _auth_Models23_Request6 = auth_Models23_Request6 ?? throw new ArgumentNullException(nameof(auth_Models23_Request6));
            _auth_Client249_Manager = auth_Client249_Manager ?? throw new ArgumentNullException(nameof(auth_Client249_Manager));
            _admin_Handlers447_Repository3 = admin_Handlers447_Repository3 ?? throw new ArgumentNullException(nameof(admin_Handlers447_Repository3));
            _integration_Contracts_Dto6 = integration_Contracts_Dto6 ?? throw new ArgumentNullException(nameof(integration_Contracts_Dto6));
            _integration_Contracts_Repository1 = integration_Contracts_Repository1 ?? throw new ArgumentNullException(nameof(integration_Contracts_Repository1));
            _documents_Tests171_Provider3 = documents_Tests171_Provider3 ?? throw new ArgumentNullException(nameof(documents_Tests171_Provider3));
            _common_Mappers190_Helper3 = common_Mappers190_Helper3 ?? throw new ArgumentNullException(nameof(common_Mappers190_Helper3));
        }

        public Auth_Models23_Controller5 GetAuth_Models23_Controller5() => _auth_Models23_Controller5;
        public Auth_Models23_Request6 GetAuth_Models23_Request6() => _auth_Models23_Request6;
        public Auth_Client249_Manager GetAuth_Client249_Manager() => _auth_Client249_Manager;
        public Admin_Handlers447_Repository3 GetAdmin_Handlers447_Repository3() => _admin_Handlers447_Repository3;
        public Integration_Contracts_Dto6 GetIntegration_Contracts_Dto6() => _integration_Contracts_Dto6;
        public Integration_Contracts_Repository1 GetIntegration_Contracts_Repository1() => _integration_Contracts_Repository1;
        public Documents_Tests171_Provider3 GetDocuments_Tests171_Provider3() => _documents_Tests171_Provider3;
        public Common_Mappers190_Helper3 GetCommon_Mappers190_Helper3() => _common_Mappers190_Helper3;

/// <summary>
/// Validates the Consumer5 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer5(Consumer5Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer5));
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
/// Processes the Consumer5 operation asynchronously.
/// </summary>
public async Task<Consumer5Result> ProcessConsumer5Async(
    Consumer5Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer5), request.Id);

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
            return new Consumer5Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer5));
        return new Consumer5Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer5));
        return new Consumer5Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer5 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer5Dto>> GetConsumer5ListAsync(
    Consumer5Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer5Entity>().AsQueryable();

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
        .Select(x => new Consumer5Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer5Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer5Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer5Service(
    ILogger<Consumer5Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer5:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer5 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer5Data> GetCachedConsumer5Async(string key)
{
    var cacheKey = $"Consumer5_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer5Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer5SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Detail76Id { get; set; }
public string Detail76Name { get; set; }
public string Detail76Description { get; set; }
public DateTime Detail76CreatedAt { get; set; }
public DateTime? Detail76UpdatedAt { get; set; }
public string Detail76CreatedBy { get; set; }
public bool IsDetail76Active { get; set; }
public int Detail76SortOrder { get; set; }


public int Record10Id { get; set; }
public string Record10Name { get; set; }
public string Record10Description { get; set; }
public DateTime Record10CreatedAt { get; set; }
public DateTime? Record10UpdatedAt { get; set; }
public string Record10CreatedBy { get; set; }
public bool IsRecord10Active { get; set; }
public int Record10SortOrder { get; set; }


public int Item5Id { get; set; }
public string Item5Name { get; set; }
public string Item5Description { get; set; }
public DateTime Item5CreatedAt { get; set; }
public DateTime? Item5UpdatedAt { get; set; }
public string Item5CreatedBy { get; set; }
public bool IsItem5Active { get; set; }
public int Item5SortOrder { get; set; }


public int Attr29Id { get; set; }
public string Attr29Name { get; set; }
public string Attr29Description { get; set; }
public DateTime Attr29CreatedAt { get; set; }
public DateTime? Attr29UpdatedAt { get; set; }
public string Attr29CreatedBy { get; set; }
public bool IsAttr29Active { get; set; }
public int Attr29SortOrder { get; set; }


public int Param28Id { get; set; }
public string Param28Name { get; set; }
public string Param28Description { get; set; }
public DateTime Param28CreatedAt { get; set; }
public DateTime? Param28UpdatedAt { get; set; }
public string Param28CreatedBy { get; set; }
public bool IsParam28Active { get; set; }
public int Param28SortOrder { get; set; }


public int Entry12Id { get; set; }
public string Entry12Name { get; set; }
public string Entry12Description { get; set; }
public DateTime Entry12CreatedAt { get; set; }
public DateTime? Entry12UpdatedAt { get; set; }
public string Entry12CreatedBy { get; set; }
public bool IsEntry12Active { get; set; }
public int Entry12SortOrder { get; set; }


public int Config33Id { get; set; }
public string Config33Name { get; set; }
public string Config33Description { get; set; }
public DateTime Config33CreatedAt { get; set; }
public DateTime? Config33UpdatedAt { get; set; }
public string Config33CreatedBy { get; set; }
public bool IsConfig33Active { get; set; }
public int Config33SortOrder { get; set; }


public int Entry39Id { get; set; }
public string Entry39Name { get; set; }
public string Entry39Description { get; set; }
public DateTime Entry39CreatedAt { get; set; }
public DateTime? Entry39UpdatedAt { get; set; }
public string Entry39CreatedBy { get; set; }
public bool IsEntry39Active { get; set; }
public int Entry39SortOrder { get; set; }


public int Field84Id { get; set; }
public string Field84Name { get; set; }
public string Field84Description { get; set; }
public DateTime Field84CreatedAt { get; set; }
public DateTime? Field84UpdatedAt { get; set; }
public string Field84CreatedBy { get; set; }
public bool IsField84Active { get; set; }
public int Field84SortOrder { get; set; }


public int Detail3Id { get; set; }
public string Detail3Name { get; set; }
public string Detail3Description { get; set; }
public DateTime Detail3CreatedAt { get; set; }
public DateTime? Detail3UpdatedAt { get; set; }
public string Detail3CreatedBy { get; set; }
public bool IsDetail3Active { get; set; }
public int Detail3SortOrder { get; set; }


public int Record11Id { get; set; }
public string Record11Name { get; set; }
public string Record11Description { get; set; }
public DateTime Record11CreatedAt { get; set; }
public DateTime? Record11UpdatedAt { get; set; }
public string Record11CreatedBy { get; set; }
public bool IsRecord11Active { get; set; }
public int Record11SortOrder { get; set; }


public int Attr97Id { get; set; }
public string Attr97Name { get; set; }
public string Attr97Description { get; set; }
public DateTime Attr97CreatedAt { get; set; }
public DateTime? Attr97UpdatedAt { get; set; }
public string Attr97CreatedBy { get; set; }
public bool IsAttr97Active { get; set; }
public int Attr97SortOrder { get; set; }


public int Item95Id { get; set; }
public string Item95Name { get; set; }
public string Item95Description { get; set; }
public DateTime Item95CreatedAt { get; set; }
public DateTime? Item95UpdatedAt { get; set; }
public string Item95CreatedBy { get; set; }
public bool IsItem95Active { get; set; }
public int Item95SortOrder { get; set; }


public int Field69Id { get; set; }
public string Field69Name { get; set; }
public string Field69Description { get; set; }
public DateTime Field69CreatedAt { get; set; }
public DateTime? Field69UpdatedAt { get; set; }
public string Field69CreatedBy { get; set; }
public bool IsField69Active { get; set; }
public int Field69SortOrder { get; set; }


public int Config29Id { get; set; }
public string Config29Name { get; set; }
public string Config29Description { get; set; }
public DateTime Config29CreatedAt { get; set; }
public DateTime? Config29UpdatedAt { get; set; }
public string Config29CreatedBy { get; set; }
public bool IsConfig29Active { get; set; }
public int Config29SortOrder { get; set; }


public int Param90Id { get; set; }
public string Param90Name { get; set; }
public string Param90Description { get; set; }
public DateTime Param90CreatedAt { get; set; }
public DateTime? Param90UpdatedAt { get; set; }
public string Param90CreatedBy { get; set; }
public bool IsParam90Active { get; set; }
public int Param90SortOrder { get; set; }


public int Param4Id { get; set; }
public string Param4Name { get; set; }
public string Param4Description { get; set; }
public DateTime Param4CreatedAt { get; set; }
public DateTime? Param4UpdatedAt { get; set; }
public string Param4CreatedBy { get; set; }
public bool IsParam4Active { get; set; }
public int Param4SortOrder { get; set; }


public int Record21Id { get; set; }
public string Record21Name { get; set; }
public string Record21Description { get; set; }
public DateTime Record21CreatedAt { get; set; }
public DateTime? Record21UpdatedAt { get; set; }
public string Record21CreatedBy { get; set; }
public bool IsRecord21Active { get; set; }
public int Record21SortOrder { get; set; }


public int Attr94Id { get; set; }
public string Attr94Name { get; set; }
public string Attr94Description { get; set; }
public DateTime Attr94CreatedAt { get; set; }
public DateTime? Attr94UpdatedAt { get; set; }
public string Attr94CreatedBy { get; set; }
public bool IsAttr94Active { get; set; }
public int Attr94SortOrder { get; set; }


public int Field28Id { get; set; }
public string Field28Name { get; set; }
public string Field28Description { get; set; }
public DateTime Field28CreatedAt { get; set; }
public DateTime? Field28UpdatedAt { get; set; }
public string Field28CreatedBy { get; set; }
public bool IsField28Active { get; set; }
public int Field28SortOrder { get; set; }


public int Param31Id { get; set; }
public string Param31Name { get; set; }
public string Param31Description { get; set; }
public DateTime Param31CreatedAt { get; set; }
public DateTime? Param31UpdatedAt { get; set; }
public string Param31CreatedBy { get; set; }
public bool IsParam31Active { get; set; }
public int Param31SortOrder { get; set; }


public int Item44Id { get; set; }
public string Item44Name { get; set; }
public string Item44Description { get; set; }
public DateTime Item44CreatedAt { get; set; }
public DateTime? Item44UpdatedAt { get; set; }
public string Item44CreatedBy { get; set; }
public bool IsItem44Active { get; set; }
public int Item44SortOrder { get; set; }


public int Item50Id { get; set; }
public string Item50Name { get; set; }
public string Item50Description { get; set; }
public DateTime Item50CreatedAt { get; set; }
public DateTime? Item50UpdatedAt { get; set; }
public string Item50CreatedBy { get; set; }
public bool IsItem50Active { get; set; }
public int Item50SortOrder { get; set; }


public int Entry65Id { get; set; }
public string Entry65Name { get; set; }
public string Entry65Description { get; set; }
public DateTime Entry65CreatedAt { get; set; }
public DateTime? Entry65UpdatedAt { get; set; }
public string Entry65CreatedBy { get; set; }
public bool IsEntry65Active { get; set; }
public int Entry65SortOrder { get; set; }


public int Config59Id { get; set; }
public string Config59Name { get; set; }
public string Config59Description { get; set; }
public DateTime Config59CreatedAt { get; set; }
public DateTime? Config59UpdatedAt { get; set; }
public string Config59CreatedBy { get; set; }
public bool IsConfig59Active { get; set; }
public int Config59SortOrder { get; set; }


public int Item7Id { get; set; }
public string Item7Name { get; set; }
public string Item7Description { get; set; }
public DateTime Item7CreatedAt { get; set; }
public DateTime? Item7UpdatedAt { get; set; }
public string Item7CreatedBy { get; set; }
public bool IsItem7Active { get; set; }
public int Item7SortOrder { get; set; }


public int Field37Id { get; set; }
public string Field37Name { get; set; }
public string Field37Description { get; set; }
public DateTime Field37CreatedAt { get; set; }
public DateTime? Field37UpdatedAt { get; set; }
public string Field37CreatedBy { get; set; }
public bool IsField37Active { get; set; }
public int Field37SortOrder { get; set; }


public int Item14Id { get; set; }
public string Item14Name { get; set; }
public string Item14Description { get; set; }
public DateTime Item14CreatedAt { get; set; }
public DateTime? Item14UpdatedAt { get; set; }
public string Item14CreatedBy { get; set; }
public bool IsItem14Active { get; set; }
public int Item14SortOrder { get; set; }


public int Field6Id { get; set; }
public string Field6Name { get; set; }
public string Field6Description { get; set; }
public DateTime Field6CreatedAt { get; set; }
public DateTime? Field6UpdatedAt { get; set; }
public string Field6CreatedBy { get; set; }
public bool IsField6Active { get; set; }
public int Field6SortOrder { get; set; }


public int Field21Id { get; set; }
public string Field21Name { get; set; }
public string Field21Description { get; set; }
public DateTime Field21CreatedAt { get; set; }
public DateTime? Field21UpdatedAt { get; set; }
public string Field21CreatedBy { get; set; }
public bool IsField21Active { get; set; }
public int Field21SortOrder { get; set; }


public int Field95Id { get; set; }
public string Field95Name { get; set; }
public string Field95Description { get; set; }
public DateTime Field95CreatedAt { get; set; }
public DateTime? Field95UpdatedAt { get; set; }
public string Field95CreatedBy { get; set; }
public bool IsField95Active { get; set; }
public int Field95SortOrder { get; set; }


public int Item90Id { get; set; }
public string Item90Name { get; set; }
public string Item90Description { get; set; }
public DateTime Item90CreatedAt { get; set; }
public DateTime? Item90UpdatedAt { get; set; }
public string Item90CreatedBy { get; set; }
public bool IsItem90Active { get; set; }
public int Item90SortOrder { get; set; }


public int Field72Id { get; set; }
public string Field72Name { get; set; }
public string Field72Description { get; set; }
public DateTime Field72CreatedAt { get; set; }
public DateTime? Field72UpdatedAt { get; set; }
public string Field72CreatedBy { get; set; }
public bool IsField72Active { get; set; }
public int Field72SortOrder { get; set; }


public int Entry15Id { get; set; }
public string Entry15Name { get; set; }
public string Entry15Description { get; set; }
public DateTime Entry15CreatedAt { get; set; }
public DateTime? Entry15UpdatedAt { get; set; }
public string Entry15CreatedBy { get; set; }
public bool IsEntry15Active { get; set; }
public int Entry15SortOrder { get; set; }


public int Attr23Id { get; set; }
public string Attr23Name { get; set; }
public string Attr23Description { get; set; }
public DateTime Attr23CreatedAt { get; set; }
public DateTime? Attr23UpdatedAt { get; set; }
public string Attr23CreatedBy { get; set; }
public bool IsAttr23Active { get; set; }
public int Attr23SortOrder { get; set; }


public int Field10Id { get; set; }
public string Field10Name { get; set; }
public string Field10Description { get; set; }
public DateTime Field10CreatedAt { get; set; }
public DateTime? Field10UpdatedAt { get; set; }
public string Field10CreatedBy { get; set; }
public bool IsField10Active { get; set; }
public int Field10SortOrder { get; set; }


public int Item73Id { get; set; }
public string Item73Name { get; set; }
public string Item73Description { get; set; }
public DateTime Item73CreatedAt { get; set; }
public DateTime? Item73UpdatedAt { get; set; }
public string Item73CreatedBy { get; set; }
public bool IsItem73Active { get; set; }
public int Item73SortOrder { get; set; }


public int Entry16Id { get; set; }
public string Entry16Name { get; set; }
public string Entry16Description { get; set; }
public DateTime Entry16CreatedAt { get; set; }
public DateTime? Entry16UpdatedAt { get; set; }
public string Entry16CreatedBy { get; set; }
public bool IsEntry16Active { get; set; }
public int Entry16SortOrder { get; set; }


public int Config96Id { get; set; }
public string Config96Name { get; set; }
public string Config96Description { get; set; }
public DateTime Config96CreatedAt { get; set; }
public DateTime? Config96UpdatedAt { get; set; }
public string Config96CreatedBy { get; set; }
public bool IsConfig96Active { get; set; }
public int Config96SortOrder { get; set; }


public int Field67Id { get; set; }
public string Field67Name { get; set; }
public string Field67Description { get; set; }
public DateTime Field67CreatedAt { get; set; }
public DateTime? Field67UpdatedAt { get; set; }
public string Field67CreatedBy { get; set; }
public bool IsField67Active { get; set; }
public int Field67SortOrder { get; set; }


public int Config3Id { get; set; }
public string Config3Name { get; set; }
public string Config3Description { get; set; }
public DateTime Config3CreatedAt { get; set; }
public DateTime? Config3UpdatedAt { get; set; }
public string Config3CreatedBy { get; set; }
public bool IsConfig3Active { get; set; }
public int Config3SortOrder { get; set; }


public int Item36Id { get; set; }
public string Item36Name { get; set; }
public string Item36Description { get; set; }
public DateTime Item36CreatedAt { get; set; }
public DateTime? Item36UpdatedAt { get; set; }
public string Item36CreatedBy { get; set; }
public bool IsItem36Active { get; set; }
public int Item36SortOrder { get; set; }


public int Param34Id { get; set; }
public string Param34Name { get; set; }
public string Param34Description { get; set; }
public DateTime Param34CreatedAt { get; set; }
public DateTime? Param34UpdatedAt { get; set; }
public string Param34CreatedBy { get; set; }
public bool IsParam34Active { get; set; }
public int Param34SortOrder { get; set; }


public int Detail92Id { get; set; }
public string Detail92Name { get; set; }
public string Detail92Description { get; set; }
public DateTime Detail92CreatedAt { get; set; }
public DateTime? Detail92UpdatedAt { get; set; }
public string Detail92CreatedBy { get; set; }
public bool IsDetail92Active { get; set; }
public int Detail92SortOrder { get; set; }


public int Detail71Id { get; set; }
public string Detail71Name { get; set; }
public string Detail71Description { get; set; }
public DateTime Detail71CreatedAt { get; set; }
public DateTime? Detail71UpdatedAt { get; set; }
public string Detail71CreatedBy { get; set; }
public bool IsDetail71Active { get; set; }
public int Detail71SortOrder { get; set; }

    }
}