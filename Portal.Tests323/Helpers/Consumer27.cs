using Admin.Client177;
using Admin.Service364;
using Auth.Mappers178;
using Billing.Client491;
using Billing.Validators174;
using Common.Processors142;
using DataAccess.Data474;
using DataAccess.Service;
using Documents.Data;
using Export.Core386;
using Imaging.Web172;
using Import.Tests;
using Security.Contracts499;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Contracts228;
using Workflow.Handlers;
using Workflow.Validators;

namespace Portal.Tests323
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer27
    {
        private readonly Auth_Mappers178_ViewModel2 _auth_Mappers178_ViewModel2;
        private readonly IDataAccess_Service_Factory13 _iDataAccess_Service_Factory13;
        private readonly IDataAccess_Service_Validator5 _iDataAccess_Service_Validator5;
        private readonly Billing_Client491_Repository8 _billing_Client491_Repository8;
        private readonly Billing_Client491_Processor _billing_Client491_Processor;
        private readonly Billing_Client491_Factory7 _billing_Client491_Factory7;
        private readonly Admin_Service364_Range _admin_Service364_Range;
        private readonly Admin_Service364_Service9 _admin_Service364_Service9;

        public Consumer27(Auth_Mappers178_ViewModel2 auth_Mappers178_ViewModel2, IDataAccess_Service_Factory13 iDataAccess_Service_Factory13, IDataAccess_Service_Validator5 iDataAccess_Service_Validator5, Billing_Client491_Repository8 billing_Client491_Repository8, Billing_Client491_Processor billing_Client491_Processor, Billing_Client491_Factory7 billing_Client491_Factory7, Admin_Service364_Range admin_Service364_Range, Admin_Service364_Service9 admin_Service364_Service9)
        {
            _auth_Mappers178_ViewModel2 = auth_Mappers178_ViewModel2 ?? throw new ArgumentNullException(nameof(auth_Mappers178_ViewModel2));
            _iDataAccess_Service_Factory13 = iDataAccess_Service_Factory13 ?? throw new ArgumentNullException(nameof(iDataAccess_Service_Factory13));
            _iDataAccess_Service_Validator5 = iDataAccess_Service_Validator5 ?? throw new ArgumentNullException(nameof(iDataAccess_Service_Validator5));
            _billing_Client491_Repository8 = billing_Client491_Repository8 ?? throw new ArgumentNullException(nameof(billing_Client491_Repository8));
            _billing_Client491_Processor = billing_Client491_Processor ?? throw new ArgumentNullException(nameof(billing_Client491_Processor));
            _billing_Client491_Factory7 = billing_Client491_Factory7 ?? throw new ArgumentNullException(nameof(billing_Client491_Factory7));
            _admin_Service364_Range = admin_Service364_Range ?? throw new ArgumentNullException(nameof(admin_Service364_Range));
            _admin_Service364_Service9 = admin_Service364_Service9 ?? throw new ArgumentNullException(nameof(admin_Service364_Service9));
        }

        public Auth_Mappers178_ViewModel2 GetAuth_Mappers178_ViewModel2() => _auth_Mappers178_ViewModel2;
        public IDataAccess_Service_Factory13 GetIDataAccess_Service_Factory13() => _iDataAccess_Service_Factory13;
        public IDataAccess_Service_Validator5 GetIDataAccess_Service_Validator5() => _iDataAccess_Service_Validator5;
        public Billing_Client491_Repository8 GetBilling_Client491_Repository8() => _billing_Client491_Repository8;
        public Billing_Client491_Processor GetBilling_Client491_Processor() => _billing_Client491_Processor;
        public Billing_Client491_Factory7 GetBilling_Client491_Factory7() => _billing_Client491_Factory7;
        public Admin_Service364_Range GetAdmin_Service364_Range() => _admin_Service364_Range;
        public Admin_Service364_Service9 GetAdmin_Service364_Service9() => _admin_Service364_Service9;

/// <summary>
/// Validates the Consumer27 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer27(Consumer27Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer27));
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
/// Processes the Consumer27 operation asynchronously.
/// </summary>
public async Task<Consumer27Result> ProcessConsumer27Async(
    Consumer27Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer27), request.Id);

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
            return new Consumer27Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer27));
        return new Consumer27Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer27));
        return new Consumer27Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer27 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer27Dto>> GetConsumer27ListAsync(
    Consumer27Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer27Entity>().AsQueryable();

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
        .Select(x => new Consumer27Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer27Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer27Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer27Service(
    ILogger<Consumer27Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer27:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer27 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer27Data> GetCachedConsumer27Async(string key)
{
    var cacheKey = $"Consumer27_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer27Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer27SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Detail26Id { get; set; }
public string Detail26Name { get; set; }
public string Detail26Description { get; set; }
public DateTime Detail26CreatedAt { get; set; }
public DateTime? Detail26UpdatedAt { get; set; }
public string Detail26CreatedBy { get; set; }
public bool IsDetail26Active { get; set; }
public int Detail26SortOrder { get; set; }


public int Entry35Id { get; set; }
public string Entry35Name { get; set; }
public string Entry35Description { get; set; }
public DateTime Entry35CreatedAt { get; set; }
public DateTime? Entry35UpdatedAt { get; set; }
public string Entry35CreatedBy { get; set; }
public bool IsEntry35Active { get; set; }
public int Entry35SortOrder { get; set; }


public int Config99Id { get; set; }
public string Config99Name { get; set; }
public string Config99Description { get; set; }
public DateTime Config99CreatedAt { get; set; }
public DateTime? Config99UpdatedAt { get; set; }
public string Config99CreatedBy { get; set; }
public bool IsConfig99Active { get; set; }
public int Config99SortOrder { get; set; }


public int Detail31Id { get; set; }
public string Detail31Name { get; set; }
public string Detail31Description { get; set; }
public DateTime Detail31CreatedAt { get; set; }
public DateTime? Detail31UpdatedAt { get; set; }
public string Detail31CreatedBy { get; set; }
public bool IsDetail31Active { get; set; }
public int Detail31SortOrder { get; set; }


public int Detail11Id { get; set; }
public string Detail11Name { get; set; }
public string Detail11Description { get; set; }
public DateTime Detail11CreatedAt { get; set; }
public DateTime? Detail11UpdatedAt { get; set; }
public string Detail11CreatedBy { get; set; }
public bool IsDetail11Active { get; set; }
public int Detail11SortOrder { get; set; }


public int Detail51Id { get; set; }
public string Detail51Name { get; set; }
public string Detail51Description { get; set; }
public DateTime Detail51CreatedAt { get; set; }
public DateTime? Detail51UpdatedAt { get; set; }
public string Detail51CreatedBy { get; set; }
public bool IsDetail51Active { get; set; }
public int Detail51SortOrder { get; set; }


public int Config94Id { get; set; }
public string Config94Name { get; set; }
public string Config94Description { get; set; }
public DateTime Config94CreatedAt { get; set; }
public DateTime? Config94UpdatedAt { get; set; }
public string Config94CreatedBy { get; set; }
public bool IsConfig94Active { get; set; }
public int Config94SortOrder { get; set; }


public int Config17Id { get; set; }
public string Config17Name { get; set; }
public string Config17Description { get; set; }
public DateTime Config17CreatedAt { get; set; }
public DateTime? Config17UpdatedAt { get; set; }
public string Config17CreatedBy { get; set; }
public bool IsConfig17Active { get; set; }
public int Config17SortOrder { get; set; }


public int Detail8Id { get; set; }
public string Detail8Name { get; set; }
public string Detail8Description { get; set; }
public DateTime Detail8CreatedAt { get; set; }
public DateTime? Detail8UpdatedAt { get; set; }
public string Detail8CreatedBy { get; set; }
public bool IsDetail8Active { get; set; }
public int Detail8SortOrder { get; set; }


public int Config35Id { get; set; }
public string Config35Name { get; set; }
public string Config35Description { get; set; }
public DateTime Config35CreatedAt { get; set; }
public DateTime? Config35UpdatedAt { get; set; }
public string Config35CreatedBy { get; set; }
public bool IsConfig35Active { get; set; }
public int Config35SortOrder { get; set; }


public int Field60Id { get; set; }
public string Field60Name { get; set; }
public string Field60Description { get; set; }
public DateTime Field60CreatedAt { get; set; }
public DateTime? Field60UpdatedAt { get; set; }
public string Field60CreatedBy { get; set; }
public bool IsField60Active { get; set; }
public int Field60SortOrder { get; set; }


public int Param76Id { get; set; }
public string Param76Name { get; set; }
public string Param76Description { get; set; }
public DateTime Param76CreatedAt { get; set; }
public DateTime? Param76UpdatedAt { get; set; }
public string Param76CreatedBy { get; set; }
public bool IsParam76Active { get; set; }
public int Param76SortOrder { get; set; }


public int Param93Id { get; set; }
public string Param93Name { get; set; }
public string Param93Description { get; set; }
public DateTime Param93CreatedAt { get; set; }
public DateTime? Param93UpdatedAt { get; set; }
public string Param93CreatedBy { get; set; }
public bool IsParam93Active { get; set; }
public int Param93SortOrder { get; set; }


public int Attr79Id { get; set; }
public string Attr79Name { get; set; }
public string Attr79Description { get; set; }
public DateTime Attr79CreatedAt { get; set; }
public DateTime? Attr79UpdatedAt { get; set; }
public string Attr79CreatedBy { get; set; }
public bool IsAttr79Active { get; set; }
public int Attr79SortOrder { get; set; }


public int Param85Id { get; set; }
public string Param85Name { get; set; }
public string Param85Description { get; set; }
public DateTime Param85CreatedAt { get; set; }
public DateTime? Param85UpdatedAt { get; set; }
public string Param85CreatedBy { get; set; }
public bool IsParam85Active { get; set; }
public int Param85SortOrder { get; set; }


public int Param6Id { get; set; }
public string Param6Name { get; set; }
public string Param6Description { get; set; }
public DateTime Param6CreatedAt { get; set; }
public DateTime? Param6UpdatedAt { get; set; }
public string Param6CreatedBy { get; set; }
public bool IsParam6Active { get; set; }
public int Param6SortOrder { get; set; }


public int Attr64Id { get; set; }
public string Attr64Name { get; set; }
public string Attr64Description { get; set; }
public DateTime Attr64CreatedAt { get; set; }
public DateTime? Attr64UpdatedAt { get; set; }
public string Attr64CreatedBy { get; set; }
public bool IsAttr64Active { get; set; }
public int Attr64SortOrder { get; set; }


public int Config10Id { get; set; }
public string Config10Name { get; set; }
public string Config10Description { get; set; }
public DateTime Config10CreatedAt { get; set; }
public DateTime? Config10UpdatedAt { get; set; }
public string Config10CreatedBy { get; set; }
public bool IsConfig10Active { get; set; }
public int Config10SortOrder { get; set; }


public int Item94Id { get; set; }
public string Item94Name { get; set; }
public string Item94Description { get; set; }
public DateTime Item94CreatedAt { get; set; }
public DateTime? Item94UpdatedAt { get; set; }
public string Item94CreatedBy { get; set; }
public bool IsItem94Active { get; set; }
public int Item94SortOrder { get; set; }


public int Param19Id { get; set; }
public string Param19Name { get; set; }
public string Param19Description { get; set; }
public DateTime Param19CreatedAt { get; set; }
public DateTime? Param19UpdatedAt { get; set; }
public string Param19CreatedBy { get; set; }
public bool IsParam19Active { get; set; }
public int Param19SortOrder { get; set; }


public int Field55Id { get; set; }
public string Field55Name { get; set; }
public string Field55Description { get; set; }
public DateTime Field55CreatedAt { get; set; }
public DateTime? Field55UpdatedAt { get; set; }
public string Field55CreatedBy { get; set; }
public bool IsField55Active { get; set; }
public int Field55SortOrder { get; set; }


public int Item98Id { get; set; }
public string Item98Name { get; set; }
public string Item98Description { get; set; }
public DateTime Item98CreatedAt { get; set; }
public DateTime? Item98UpdatedAt { get; set; }
public string Item98CreatedBy { get; set; }
public bool IsItem98Active { get; set; }
public int Item98SortOrder { get; set; }


public int Item82Id { get; set; }
public string Item82Name { get; set; }
public string Item82Description { get; set; }
public DateTime Item82CreatedAt { get; set; }
public DateTime? Item82UpdatedAt { get; set; }
public string Item82CreatedBy { get; set; }
public bool IsItem82Active { get; set; }
public int Item82SortOrder { get; set; }


public int Attr94Id { get; set; }
public string Attr94Name { get; set; }
public string Attr94Description { get; set; }
public DateTime Attr94CreatedAt { get; set; }
public DateTime? Attr94UpdatedAt { get; set; }
public string Attr94CreatedBy { get; set; }
public bool IsAttr94Active { get; set; }
public int Attr94SortOrder { get; set; }


public int Record37Id { get; set; }
public string Record37Name { get; set; }
public string Record37Description { get; set; }
public DateTime Record37CreatedAt { get; set; }
public DateTime? Record37UpdatedAt { get; set; }
public string Record37CreatedBy { get; set; }
public bool IsRecord37Active { get; set; }
public int Record37SortOrder { get; set; }


public int Detail1Id { get; set; }
public string Detail1Name { get; set; }
public string Detail1Description { get; set; }
public DateTime Detail1CreatedAt { get; set; }
public DateTime? Detail1UpdatedAt { get; set; }
public string Detail1CreatedBy { get; set; }
public bool IsDetail1Active { get; set; }
public int Detail1SortOrder { get; set; }


public int Detail33Id { get; set; }
public string Detail33Name { get; set; }
public string Detail33Description { get; set; }
public DateTime Detail33CreatedAt { get; set; }
public DateTime? Detail33UpdatedAt { get; set; }
public string Detail33CreatedBy { get; set; }
public bool IsDetail33Active { get; set; }
public int Detail33SortOrder { get; set; }


public int Config15Id { get; set; }
public string Config15Name { get; set; }
public string Config15Description { get; set; }
public DateTime Config15CreatedAt { get; set; }
public DateTime? Config15UpdatedAt { get; set; }
public string Config15CreatedBy { get; set; }
public bool IsConfig15Active { get; set; }
public int Config15SortOrder { get; set; }


public int Detail90Id { get; set; }
public string Detail90Name { get; set; }
public string Detail90Description { get; set; }
public DateTime Detail90CreatedAt { get; set; }
public DateTime? Detail90UpdatedAt { get; set; }
public string Detail90CreatedBy { get; set; }
public bool IsDetail90Active { get; set; }
public int Detail90SortOrder { get; set; }


public int Param86Id { get; set; }
public string Param86Name { get; set; }
public string Param86Description { get; set; }
public DateTime Param86CreatedAt { get; set; }
public DateTime? Param86UpdatedAt { get; set; }
public string Param86CreatedBy { get; set; }
public bool IsParam86Active { get; set; }
public int Param86SortOrder { get; set; }


public int Item36Id { get; set; }
public string Item36Name { get; set; }
public string Item36Description { get; set; }
public DateTime Item36CreatedAt { get; set; }
public DateTime? Item36UpdatedAt { get; set; }
public string Item36CreatedBy { get; set; }
public bool IsItem36Active { get; set; }
public int Item36SortOrder { get; set; }


public int Entry27Id { get; set; }
public string Entry27Name { get; set; }
public string Entry27Description { get; set; }
public DateTime Entry27CreatedAt { get; set; }
public DateTime? Entry27UpdatedAt { get; set; }
public string Entry27CreatedBy { get; set; }
public bool IsEntry27Active { get; set; }
public int Entry27SortOrder { get; set; }


public int Entry10Id { get; set; }
public string Entry10Name { get; set; }
public string Entry10Description { get; set; }
public DateTime Entry10CreatedAt { get; set; }
public DateTime? Entry10UpdatedAt { get; set; }
public string Entry10CreatedBy { get; set; }
public bool IsEntry10Active { get; set; }
public int Entry10SortOrder { get; set; }


public int Attr51Id { get; set; }
public string Attr51Name { get; set; }
public string Attr51Description { get; set; }
public DateTime Attr51CreatedAt { get; set; }
public DateTime? Attr51UpdatedAt { get; set; }
public string Attr51CreatedBy { get; set; }
public bool IsAttr51Active { get; set; }
public int Attr51SortOrder { get; set; }


public int Detail61Id { get; set; }
public string Detail61Name { get; set; }
public string Detail61Description { get; set; }
public DateTime Detail61CreatedAt { get; set; }
public DateTime? Detail61UpdatedAt { get; set; }
public string Detail61CreatedBy { get; set; }
public bool IsDetail61Active { get; set; }
public int Detail61SortOrder { get; set; }


public int Attr99Id { get; set; }
public string Attr99Name { get; set; }
public string Attr99Description { get; set; }
public DateTime Attr99CreatedAt { get; set; }
public DateTime? Attr99UpdatedAt { get; set; }
public string Attr99CreatedBy { get; set; }
public bool IsAttr99Active { get; set; }
public int Attr99SortOrder { get; set; }


public int Detail11Id { get; set; }
public string Detail11Name { get; set; }
public string Detail11Description { get; set; }
public DateTime Detail11CreatedAt { get; set; }
public DateTime? Detail11UpdatedAt { get; set; }
public string Detail11CreatedBy { get; set; }
public bool IsDetail11Active { get; set; }
public int Detail11SortOrder { get; set; }


public int Param91Id { get; set; }
public string Param91Name { get; set; }
public string Param91Description { get; set; }
public DateTime Param91CreatedAt { get; set; }
public DateTime? Param91UpdatedAt { get; set; }
public string Param91CreatedBy { get; set; }
public bool IsParam91Active { get; set; }
public int Param91SortOrder { get; set; }


public int Field99Id { get; set; }
public string Field99Name { get; set; }
public string Field99Description { get; set; }
public DateTime Field99CreatedAt { get; set; }
public DateTime? Field99UpdatedAt { get; set; }
public string Field99CreatedBy { get; set; }
public bool IsField99Active { get; set; }
public int Field99SortOrder { get; set; }


public int Detail72Id { get; set; }
public string Detail72Name { get; set; }
public string Detail72Description { get; set; }
public DateTime Detail72CreatedAt { get; set; }
public DateTime? Detail72UpdatedAt { get; set; }
public string Detail72CreatedBy { get; set; }
public bool IsDetail72Active { get; set; }
public int Detail72SortOrder { get; set; }


public int Detail76Id { get; set; }
public string Detail76Name { get; set; }
public string Detail76Description { get; set; }
public DateTime Detail76CreatedAt { get; set; }
public DateTime? Detail76UpdatedAt { get; set; }
public string Detail76CreatedBy { get; set; }
public bool IsDetail76Active { get; set; }
public int Detail76SortOrder { get; set; }


public int Field27Id { get; set; }
public string Field27Name { get; set; }
public string Field27Description { get; set; }
public DateTime Field27CreatedAt { get; set; }
public DateTime? Field27UpdatedAt { get; set; }
public string Field27CreatedBy { get; set; }
public bool IsField27Active { get; set; }
public int Field27SortOrder { get; set; }


public int Attr60Id { get; set; }
public string Attr60Name { get; set; }
public string Attr60Description { get; set; }
public DateTime Attr60CreatedAt { get; set; }
public DateTime? Attr60UpdatedAt { get; set; }
public string Attr60CreatedBy { get; set; }
public bool IsAttr60Active { get; set; }
public int Attr60SortOrder { get; set; }


public int Entry96Id { get; set; }
public string Entry96Name { get; set; }
public string Entry96Description { get; set; }
public DateTime Entry96CreatedAt { get; set; }
public DateTime? Entry96UpdatedAt { get; set; }
public string Entry96CreatedBy { get; set; }
public bool IsEntry96Active { get; set; }
public int Entry96SortOrder { get; set; }


public int Field51Id { get; set; }
public string Field51Name { get; set; }
public string Field51Description { get; set; }
public DateTime Field51CreatedAt { get; set; }
public DateTime? Field51UpdatedAt { get; set; }
public string Field51CreatedBy { get; set; }
public bool IsField51Active { get; set; }
public int Field51SortOrder { get; set; }

    }
}