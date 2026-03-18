using Admin.Core121;
using Admin.Validators431;
using Auth.Client271;
using Auth.Client38;
using Common.Models;
using DataAccess.Service;
using DataAccess.Validators409;
using Documents.Shared334;
using Portal.Api;
using Reporting.Handlers;
using Scheduling.Client;
using Scheduling.Contracts425;
using Scheduling.Handlers;
using Security.Handlers162;
using Security.Validators428;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Validators;
using Workflow.Events327;

namespace Workflow.Events
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer0
    {
        private readonly Admin_Core121_Repository3 _admin_Core121_Repository3;
        private readonly Admin_Validators431_Factory3 _admin_Validators431_Factory3;
        private readonly Admin_Validators431_Service7 _admin_Validators431_Service7;
        private readonly Portal_Api_Manager2 _portal_Api_Manager2;
        private readonly IReporting_Handlers_Provider _iReporting_Handlers_Provider;
        private readonly Reporting_Handlers_Builder8 _reporting_Handlers_Builder8;
        private readonly Workflow_Events327_Repository9 _workflow_Events327_Repository9;
        private readonly Common_Models_Processor4 _common_Models_Processor4;

        public Consumer0(Admin_Core121_Repository3 admin_Core121_Repository3, Admin_Validators431_Factory3 admin_Validators431_Factory3, Admin_Validators431_Service7 admin_Validators431_Service7, Portal_Api_Manager2 portal_Api_Manager2, IReporting_Handlers_Provider iReporting_Handlers_Provider, Reporting_Handlers_Builder8 reporting_Handlers_Builder8, Workflow_Events327_Repository9 workflow_Events327_Repository9, Common_Models_Processor4 common_Models_Processor4)
        {
            _admin_Core121_Repository3 = admin_Core121_Repository3 ?? throw new ArgumentNullException(nameof(admin_Core121_Repository3));
            _admin_Validators431_Factory3 = admin_Validators431_Factory3 ?? throw new ArgumentNullException(nameof(admin_Validators431_Factory3));
            _admin_Validators431_Service7 = admin_Validators431_Service7 ?? throw new ArgumentNullException(nameof(admin_Validators431_Service7));
            _portal_Api_Manager2 = portal_Api_Manager2 ?? throw new ArgumentNullException(nameof(portal_Api_Manager2));
            _iReporting_Handlers_Provider = iReporting_Handlers_Provider ?? throw new ArgumentNullException(nameof(iReporting_Handlers_Provider));
            _reporting_Handlers_Builder8 = reporting_Handlers_Builder8 ?? throw new ArgumentNullException(nameof(reporting_Handlers_Builder8));
            _workflow_Events327_Repository9 = workflow_Events327_Repository9 ?? throw new ArgumentNullException(nameof(workflow_Events327_Repository9));
            _common_Models_Processor4 = common_Models_Processor4 ?? throw new ArgumentNullException(nameof(common_Models_Processor4));
        }

        public Admin_Core121_Repository3 GetAdmin_Core121_Repository3() => _admin_Core121_Repository3;
        public Admin_Validators431_Factory3 GetAdmin_Validators431_Factory3() => _admin_Validators431_Factory3;
        public Admin_Validators431_Service7 GetAdmin_Validators431_Service7() => _admin_Validators431_Service7;
        public Portal_Api_Manager2 GetPortal_Api_Manager2() => _portal_Api_Manager2;
        public IReporting_Handlers_Provider GetIReporting_Handlers_Provider() => _iReporting_Handlers_Provider;
        public Reporting_Handlers_Builder8 GetReporting_Handlers_Builder8() => _reporting_Handlers_Builder8;
        public Workflow_Events327_Repository9 GetWorkflow_Events327_Repository9() => _workflow_Events327_Repository9;
        public Common_Models_Processor4 GetCommon_Models_Processor4() => _common_Models_Processor4;

/// <summary>
/// Validates the Consumer0 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer0(Consumer0Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer0));
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
/// Processes the Consumer0 operation asynchronously.
/// </summary>
public async Task<Consumer0Result> ProcessConsumer0Async(
    Consumer0Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer0), request.Id);

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
            return new Consumer0Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer0));
        return new Consumer0Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer0));
        return new Consumer0Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer0 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer0Dto>> GetConsumer0ListAsync(
    Consumer0Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer0Entity>().AsQueryable();

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
        .Select(x => new Consumer0Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer0Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer0Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer0Service(
    ILogger<Consumer0Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer0:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer0 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer0Data> GetCachedConsumer0Async(string key)
{
    var cacheKey = $"Consumer0_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer0Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer0SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Record55Id { get; set; }
public string Record55Name { get; set; }
public string Record55Description { get; set; }
public DateTime Record55CreatedAt { get; set; }
public DateTime? Record55UpdatedAt { get; set; }
public string Record55CreatedBy { get; set; }
public bool IsRecord55Active { get; set; }
public int Record55SortOrder { get; set; }


public int Item24Id { get; set; }
public string Item24Name { get; set; }
public string Item24Description { get; set; }
public DateTime Item24CreatedAt { get; set; }
public DateTime? Item24UpdatedAt { get; set; }
public string Item24CreatedBy { get; set; }
public bool IsItem24Active { get; set; }
public int Item24SortOrder { get; set; }


public int Record25Id { get; set; }
public string Record25Name { get; set; }
public string Record25Description { get; set; }
public DateTime Record25CreatedAt { get; set; }
public DateTime? Record25UpdatedAt { get; set; }
public string Record25CreatedBy { get; set; }
public bool IsRecord25Active { get; set; }
public int Record25SortOrder { get; set; }


public int Config44Id { get; set; }
public string Config44Name { get; set; }
public string Config44Description { get; set; }
public DateTime Config44CreatedAt { get; set; }
public DateTime? Config44UpdatedAt { get; set; }
public string Config44CreatedBy { get; set; }
public bool IsConfig44Active { get; set; }
public int Config44SortOrder { get; set; }


public int Config61Id { get; set; }
public string Config61Name { get; set; }
public string Config61Description { get; set; }
public DateTime Config61CreatedAt { get; set; }
public DateTime? Config61UpdatedAt { get; set; }
public string Config61CreatedBy { get; set; }
public bool IsConfig61Active { get; set; }
public int Config61SortOrder { get; set; }


public int Record68Id { get; set; }
public string Record68Name { get; set; }
public string Record68Description { get; set; }
public DateTime Record68CreatedAt { get; set; }
public DateTime? Record68UpdatedAt { get; set; }
public string Record68CreatedBy { get; set; }
public bool IsRecord68Active { get; set; }
public int Record68SortOrder { get; set; }


public int Param61Id { get; set; }
public string Param61Name { get; set; }
public string Param61Description { get; set; }
public DateTime Param61CreatedAt { get; set; }
public DateTime? Param61UpdatedAt { get; set; }
public string Param61CreatedBy { get; set; }
public bool IsParam61Active { get; set; }
public int Param61SortOrder { get; set; }


public int Param36Id { get; set; }
public string Param36Name { get; set; }
public string Param36Description { get; set; }
public DateTime Param36CreatedAt { get; set; }
public DateTime? Param36UpdatedAt { get; set; }
public string Param36CreatedBy { get; set; }
public bool IsParam36Active { get; set; }
public int Param36SortOrder { get; set; }


public int Detail60Id { get; set; }
public string Detail60Name { get; set; }
public string Detail60Description { get; set; }
public DateTime Detail60CreatedAt { get; set; }
public DateTime? Detail60UpdatedAt { get; set; }
public string Detail60CreatedBy { get; set; }
public bool IsDetail60Active { get; set; }
public int Detail60SortOrder { get; set; }


public int Item37Id { get; set; }
public string Item37Name { get; set; }
public string Item37Description { get; set; }
public DateTime Item37CreatedAt { get; set; }
public DateTime? Item37UpdatedAt { get; set; }
public string Item37CreatedBy { get; set; }
public bool IsItem37Active { get; set; }
public int Item37SortOrder { get; set; }


public int Param99Id { get; set; }
public string Param99Name { get; set; }
public string Param99Description { get; set; }
public DateTime Param99CreatedAt { get; set; }
public DateTime? Param99UpdatedAt { get; set; }
public string Param99CreatedBy { get; set; }
public bool IsParam99Active { get; set; }
public int Param99SortOrder { get; set; }


public int Field64Id { get; set; }
public string Field64Name { get; set; }
public string Field64Description { get; set; }
public DateTime Field64CreatedAt { get; set; }
public DateTime? Field64UpdatedAt { get; set; }
public string Field64CreatedBy { get; set; }
public bool IsField64Active { get; set; }
public int Field64SortOrder { get; set; }


public int Field54Id { get; set; }
public string Field54Name { get; set; }
public string Field54Description { get; set; }
public DateTime Field54CreatedAt { get; set; }
public DateTime? Field54UpdatedAt { get; set; }
public string Field54CreatedBy { get; set; }
public bool IsField54Active { get; set; }
public int Field54SortOrder { get; set; }


public int Record35Id { get; set; }
public string Record35Name { get; set; }
public string Record35Description { get; set; }
public DateTime Record35CreatedAt { get; set; }
public DateTime? Record35UpdatedAt { get; set; }
public string Record35CreatedBy { get; set; }
public bool IsRecord35Active { get; set; }
public int Record35SortOrder { get; set; }


public int Param55Id { get; set; }
public string Param55Name { get; set; }
public string Param55Description { get; set; }
public DateTime Param55CreatedAt { get; set; }
public DateTime? Param55UpdatedAt { get; set; }
public string Param55CreatedBy { get; set; }
public bool IsParam55Active { get; set; }
public int Param55SortOrder { get; set; }


public int Entry26Id { get; set; }
public string Entry26Name { get; set; }
public string Entry26Description { get; set; }
public DateTime Entry26CreatedAt { get; set; }
public DateTime? Entry26UpdatedAt { get; set; }
public string Entry26CreatedBy { get; set; }
public bool IsEntry26Active { get; set; }
public int Entry26SortOrder { get; set; }


public int Detail57Id { get; set; }
public string Detail57Name { get; set; }
public string Detail57Description { get; set; }
public DateTime Detail57CreatedAt { get; set; }
public DateTime? Detail57UpdatedAt { get; set; }
public string Detail57CreatedBy { get; set; }
public bool IsDetail57Active { get; set; }
public int Detail57SortOrder { get; set; }


public int Item83Id { get; set; }
public string Item83Name { get; set; }
public string Item83Description { get; set; }
public DateTime Item83CreatedAt { get; set; }
public DateTime? Item83UpdatedAt { get; set; }
public string Item83CreatedBy { get; set; }
public bool IsItem83Active { get; set; }
public int Item83SortOrder { get; set; }


public int Detail60Id { get; set; }
public string Detail60Name { get; set; }
public string Detail60Description { get; set; }
public DateTime Detail60CreatedAt { get; set; }
public DateTime? Detail60UpdatedAt { get; set; }
public string Detail60CreatedBy { get; set; }
public bool IsDetail60Active { get; set; }
public int Detail60SortOrder { get; set; }


public int Attr84Id { get; set; }
public string Attr84Name { get; set; }
public string Attr84Description { get; set; }
public DateTime Attr84CreatedAt { get; set; }
public DateTime? Attr84UpdatedAt { get; set; }
public string Attr84CreatedBy { get; set; }
public bool IsAttr84Active { get; set; }
public int Attr84SortOrder { get; set; }


public int Record69Id { get; set; }
public string Record69Name { get; set; }
public string Record69Description { get; set; }
public DateTime Record69CreatedAt { get; set; }
public DateTime? Record69UpdatedAt { get; set; }
public string Record69CreatedBy { get; set; }
public bool IsRecord69Active { get; set; }
public int Record69SortOrder { get; set; }


public int Item73Id { get; set; }
public string Item73Name { get; set; }
public string Item73Description { get; set; }
public DateTime Item73CreatedAt { get; set; }
public DateTime? Item73UpdatedAt { get; set; }
public string Item73CreatedBy { get; set; }
public bool IsItem73Active { get; set; }
public int Item73SortOrder { get; set; }


public int Record19Id { get; set; }
public string Record19Name { get; set; }
public string Record19Description { get; set; }
public DateTime Record19CreatedAt { get; set; }
public DateTime? Record19UpdatedAt { get; set; }
public string Record19CreatedBy { get; set; }
public bool IsRecord19Active { get; set; }
public int Record19SortOrder { get; set; }


public int Detail26Id { get; set; }
public string Detail26Name { get; set; }
public string Detail26Description { get; set; }
public DateTime Detail26CreatedAt { get; set; }
public DateTime? Detail26UpdatedAt { get; set; }
public string Detail26CreatedBy { get; set; }
public bool IsDetail26Active { get; set; }
public int Detail26SortOrder { get; set; }


public int Config16Id { get; set; }
public string Config16Name { get; set; }
public string Config16Description { get; set; }
public DateTime Config16CreatedAt { get; set; }
public DateTime? Config16UpdatedAt { get; set; }
public string Config16CreatedBy { get; set; }
public bool IsConfig16Active { get; set; }
public int Config16SortOrder { get; set; }


public int Entry19Id { get; set; }
public string Entry19Name { get; set; }
public string Entry19Description { get; set; }
public DateTime Entry19CreatedAt { get; set; }
public DateTime? Entry19UpdatedAt { get; set; }
public string Entry19CreatedBy { get; set; }
public bool IsEntry19Active { get; set; }
public int Entry19SortOrder { get; set; }


public int Param77Id { get; set; }
public string Param77Name { get; set; }
public string Param77Description { get; set; }
public DateTime Param77CreatedAt { get; set; }
public DateTime? Param77UpdatedAt { get; set; }
public string Param77CreatedBy { get; set; }
public bool IsParam77Active { get; set; }
public int Param77SortOrder { get; set; }


public int Record41Id { get; set; }
public string Record41Name { get; set; }
public string Record41Description { get; set; }
public DateTime Record41CreatedAt { get; set; }
public DateTime? Record41UpdatedAt { get; set; }
public string Record41CreatedBy { get; set; }
public bool IsRecord41Active { get; set; }
public int Record41SortOrder { get; set; }


public int Config12Id { get; set; }
public string Config12Name { get; set; }
public string Config12Description { get; set; }
public DateTime Config12CreatedAt { get; set; }
public DateTime? Config12UpdatedAt { get; set; }
public string Config12CreatedBy { get; set; }
public bool IsConfig12Active { get; set; }
public int Config12SortOrder { get; set; }


public int Item11Id { get; set; }
public string Item11Name { get; set; }
public string Item11Description { get; set; }
public DateTime Item11CreatedAt { get; set; }
public DateTime? Item11UpdatedAt { get; set; }
public string Item11CreatedBy { get; set; }
public bool IsItem11Active { get; set; }
public int Item11SortOrder { get; set; }


public int Entry67Id { get; set; }
public string Entry67Name { get; set; }
public string Entry67Description { get; set; }
public DateTime Entry67CreatedAt { get; set; }
public DateTime? Entry67UpdatedAt { get; set; }
public string Entry67CreatedBy { get; set; }
public bool IsEntry67Active { get; set; }
public int Entry67SortOrder { get; set; }


public int Param28Id { get; set; }
public string Param28Name { get; set; }
public string Param28Description { get; set; }
public DateTime Param28CreatedAt { get; set; }
public DateTime? Param28UpdatedAt { get; set; }
public string Param28CreatedBy { get; set; }
public bool IsParam28Active { get; set; }
public int Param28SortOrder { get; set; }


public int Record10Id { get; set; }
public string Record10Name { get; set; }
public string Record10Description { get; set; }
public DateTime Record10CreatedAt { get; set; }
public DateTime? Record10UpdatedAt { get; set; }
public string Record10CreatedBy { get; set; }
public bool IsRecord10Active { get; set; }
public int Record10SortOrder { get; set; }


public int Record30Id { get; set; }
public string Record30Name { get; set; }
public string Record30Description { get; set; }
public DateTime Record30CreatedAt { get; set; }
public DateTime? Record30UpdatedAt { get; set; }
public string Record30CreatedBy { get; set; }
public bool IsRecord30Active { get; set; }
public int Record30SortOrder { get; set; }


public int Record55Id { get; set; }
public string Record55Name { get; set; }
public string Record55Description { get; set; }
public DateTime Record55CreatedAt { get; set; }
public DateTime? Record55UpdatedAt { get; set; }
public string Record55CreatedBy { get; set; }
public bool IsRecord55Active { get; set; }
public int Record55SortOrder { get; set; }


public int Detail93Id { get; set; }
public string Detail93Name { get; set; }
public string Detail93Description { get; set; }
public DateTime Detail93CreatedAt { get; set; }
public DateTime? Detail93UpdatedAt { get; set; }
public string Detail93CreatedBy { get; set; }
public bool IsDetail93Active { get; set; }
public int Detail93SortOrder { get; set; }


public int Config35Id { get; set; }
public string Config35Name { get; set; }
public string Config35Description { get; set; }
public DateTime Config35CreatedAt { get; set; }
public DateTime? Config35UpdatedAt { get; set; }
public string Config35CreatedBy { get; set; }
public bool IsConfig35Active { get; set; }
public int Config35SortOrder { get; set; }


public int Entry53Id { get; set; }
public string Entry53Name { get; set; }
public string Entry53Description { get; set; }
public DateTime Entry53CreatedAt { get; set; }
public DateTime? Entry53UpdatedAt { get; set; }
public string Entry53CreatedBy { get; set; }
public bool IsEntry53Active { get; set; }
public int Entry53SortOrder { get; set; }


public int Config97Id { get; set; }
public string Config97Name { get; set; }
public string Config97Description { get; set; }
public DateTime Config97CreatedAt { get; set; }
public DateTime? Config97UpdatedAt { get; set; }
public string Config97CreatedBy { get; set; }
public bool IsConfig97Active { get; set; }
public int Config97SortOrder { get; set; }


public int Record47Id { get; set; }
public string Record47Name { get; set; }
public string Record47Description { get; set; }
public DateTime Record47CreatedAt { get; set; }
public DateTime? Record47UpdatedAt { get; set; }
public string Record47CreatedBy { get; set; }
public bool IsRecord47Active { get; set; }
public int Record47SortOrder { get; set; }


public int Config81Id { get; set; }
public string Config81Name { get; set; }
public string Config81Description { get; set; }
public DateTime Config81CreatedAt { get; set; }
public DateTime? Config81UpdatedAt { get; set; }
public string Config81CreatedBy { get; set; }
public bool IsConfig81Active { get; set; }
public int Config81SortOrder { get; set; }


public int Entry98Id { get; set; }
public string Entry98Name { get; set; }
public string Entry98Description { get; set; }
public DateTime Entry98CreatedAt { get; set; }
public DateTime? Entry98UpdatedAt { get; set; }
public string Entry98CreatedBy { get; set; }
public bool IsEntry98Active { get; set; }
public int Entry98SortOrder { get; set; }


public int Record58Id { get; set; }
public string Record58Name { get; set; }
public string Record58Description { get; set; }
public DateTime Record58CreatedAt { get; set; }
public DateTime? Record58UpdatedAt { get; set; }
public string Record58CreatedBy { get; set; }
public bool IsRecord58Active { get; set; }
public int Record58SortOrder { get; set; }


public int Param13Id { get; set; }
public string Param13Name { get; set; }
public string Param13Description { get; set; }
public DateTime Param13CreatedAt { get; set; }
public DateTime? Param13UpdatedAt { get; set; }
public string Param13CreatedBy { get; set; }
public bool IsParam13Active { get; set; }
public int Param13SortOrder { get; set; }


public int Attr42Id { get; set; }
public string Attr42Name { get; set; }
public string Attr42Description { get; set; }
public DateTime Attr42CreatedAt { get; set; }
public DateTime? Attr42UpdatedAt { get; set; }
public string Attr42CreatedBy { get; set; }
public bool IsAttr42Active { get; set; }
public int Attr42SortOrder { get; set; }

    }
}