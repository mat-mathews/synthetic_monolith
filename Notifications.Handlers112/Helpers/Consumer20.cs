using Admin.Api255;
using Admin.Handlers;
using Admin.Handlers61;
using Admin.Shared363;
using Auth.Data;
using Billing.Api9;
using Billing.Handlers101;
using Common.Events367;
using Common.Web;
using Documents.Client;
using Import.Processors;
using Integration.Processors71;
using Notifications.Shared;
using Portal.Events139;
using Scheduling.Core;
using Scheduling.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Handlers;

namespace Notifications.Handlers112
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer20
    {
        private readonly IAdmin_Handlers_Factory7 _iAdmin_Handlers_Factory7;
        private readonly IAdmin_Api255_Service2 _iAdmin_Api255_Service2;
        private readonly Portal_Events139_Builder12 _portal_Events139_Builder12;
        private readonly INotifications_Shared_Validator5 _iNotifications_Shared_Validator5;
        private readonly Notifications_Shared_Processor4 _notifications_Shared_Processor4;
        private readonly Notifications_Shared_Factory6 _notifications_Shared_Factory6;
        private readonly Billing_Handlers101_Manager10 _billing_Handlers101_Manager10;
        private readonly IAdmin_Handlers61_Repository10 _iAdmin_Handlers61_Repository10;

        public Consumer20(IAdmin_Handlers_Factory7 iAdmin_Handlers_Factory7, IAdmin_Api255_Service2 iAdmin_Api255_Service2, Portal_Events139_Builder12 portal_Events139_Builder12, INotifications_Shared_Validator5 iNotifications_Shared_Validator5, Notifications_Shared_Processor4 notifications_Shared_Processor4, Notifications_Shared_Factory6 notifications_Shared_Factory6, Billing_Handlers101_Manager10 billing_Handlers101_Manager10, IAdmin_Handlers61_Repository10 iAdmin_Handlers61_Repository10)
        {
            _iAdmin_Handlers_Factory7 = iAdmin_Handlers_Factory7 ?? throw new ArgumentNullException(nameof(iAdmin_Handlers_Factory7));
            _iAdmin_Api255_Service2 = iAdmin_Api255_Service2 ?? throw new ArgumentNullException(nameof(iAdmin_Api255_Service2));
            _portal_Events139_Builder12 = portal_Events139_Builder12 ?? throw new ArgumentNullException(nameof(portal_Events139_Builder12));
            _iNotifications_Shared_Validator5 = iNotifications_Shared_Validator5 ?? throw new ArgumentNullException(nameof(iNotifications_Shared_Validator5));
            _notifications_Shared_Processor4 = notifications_Shared_Processor4 ?? throw new ArgumentNullException(nameof(notifications_Shared_Processor4));
            _notifications_Shared_Factory6 = notifications_Shared_Factory6 ?? throw new ArgumentNullException(nameof(notifications_Shared_Factory6));
            _billing_Handlers101_Manager10 = billing_Handlers101_Manager10 ?? throw new ArgumentNullException(nameof(billing_Handlers101_Manager10));
            _iAdmin_Handlers61_Repository10 = iAdmin_Handlers61_Repository10 ?? throw new ArgumentNullException(nameof(iAdmin_Handlers61_Repository10));
        }

        public IAdmin_Handlers_Factory7 GetIAdmin_Handlers_Factory7() => _iAdmin_Handlers_Factory7;
        public IAdmin_Api255_Service2 GetIAdmin_Api255_Service2() => _iAdmin_Api255_Service2;
        public Portal_Events139_Builder12 GetPortal_Events139_Builder12() => _portal_Events139_Builder12;
        public INotifications_Shared_Validator5 GetINotifications_Shared_Validator5() => _iNotifications_Shared_Validator5;
        public Notifications_Shared_Processor4 GetNotifications_Shared_Processor4() => _notifications_Shared_Processor4;
        public Notifications_Shared_Factory6 GetNotifications_Shared_Factory6() => _notifications_Shared_Factory6;
        public Billing_Handlers101_Manager10 GetBilling_Handlers101_Manager10() => _billing_Handlers101_Manager10;
        public IAdmin_Handlers61_Repository10 GetIAdmin_Handlers61_Repository10() => _iAdmin_Handlers61_Repository10;

/// <summary>
/// Validates the Consumer20 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer20(Consumer20Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer20));
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
/// Processes the Consumer20 operation asynchronously.
/// </summary>
public async Task<Consumer20Result> ProcessConsumer20Async(
    Consumer20Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer20), request.Id);

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
            return new Consumer20Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer20));
        return new Consumer20Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer20));
        return new Consumer20Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer20 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer20Dto>> GetConsumer20ListAsync(
    Consumer20Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer20Entity>().AsQueryable();

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
        .Select(x => new Consumer20Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer20Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer20Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer20Service(
    ILogger<Consumer20Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer20:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer20 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer20Data> GetCachedConsumer20Async(string key)
{
    var cacheKey = $"Consumer20_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer20Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer20SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Field41Id { get; set; }
public string Field41Name { get; set; }
public string Field41Description { get; set; }
public DateTime Field41CreatedAt { get; set; }
public DateTime? Field41UpdatedAt { get; set; }
public string Field41CreatedBy { get; set; }
public bool IsField41Active { get; set; }
public int Field41SortOrder { get; set; }


public int Entry9Id { get; set; }
public string Entry9Name { get; set; }
public string Entry9Description { get; set; }
public DateTime Entry9CreatedAt { get; set; }
public DateTime? Entry9UpdatedAt { get; set; }
public string Entry9CreatedBy { get; set; }
public bool IsEntry9Active { get; set; }
public int Entry9SortOrder { get; set; }


public int Field59Id { get; set; }
public string Field59Name { get; set; }
public string Field59Description { get; set; }
public DateTime Field59CreatedAt { get; set; }
public DateTime? Field59UpdatedAt { get; set; }
public string Field59CreatedBy { get; set; }
public bool IsField59Active { get; set; }
public int Field59SortOrder { get; set; }


public int Record36Id { get; set; }
public string Record36Name { get; set; }
public string Record36Description { get; set; }
public DateTime Record36CreatedAt { get; set; }
public DateTime? Record36UpdatedAt { get; set; }
public string Record36CreatedBy { get; set; }
public bool IsRecord36Active { get; set; }
public int Record36SortOrder { get; set; }


public int Record54Id { get; set; }
public string Record54Name { get; set; }
public string Record54Description { get; set; }
public DateTime Record54CreatedAt { get; set; }
public DateTime? Record54UpdatedAt { get; set; }
public string Record54CreatedBy { get; set; }
public bool IsRecord54Active { get; set; }
public int Record54SortOrder { get; set; }


public int Field54Id { get; set; }
public string Field54Name { get; set; }
public string Field54Description { get; set; }
public DateTime Field54CreatedAt { get; set; }
public DateTime? Field54UpdatedAt { get; set; }
public string Field54CreatedBy { get; set; }
public bool IsField54Active { get; set; }
public int Field54SortOrder { get; set; }


public int Attr79Id { get; set; }
public string Attr79Name { get; set; }
public string Attr79Description { get; set; }
public DateTime Attr79CreatedAt { get; set; }
public DateTime? Attr79UpdatedAt { get; set; }
public string Attr79CreatedBy { get; set; }
public bool IsAttr79Active { get; set; }
public int Attr79SortOrder { get; set; }


public int Field47Id { get; set; }
public string Field47Name { get; set; }
public string Field47Description { get; set; }
public DateTime Field47CreatedAt { get; set; }
public DateTime? Field47UpdatedAt { get; set; }
public string Field47CreatedBy { get; set; }
public bool IsField47Active { get; set; }
public int Field47SortOrder { get; set; }


public int Field17Id { get; set; }
public string Field17Name { get; set; }
public string Field17Description { get; set; }
public DateTime Field17CreatedAt { get; set; }
public DateTime? Field17UpdatedAt { get; set; }
public string Field17CreatedBy { get; set; }
public bool IsField17Active { get; set; }
public int Field17SortOrder { get; set; }


public int Detail67Id { get; set; }
public string Detail67Name { get; set; }
public string Detail67Description { get; set; }
public DateTime Detail67CreatedAt { get; set; }
public DateTime? Detail67UpdatedAt { get; set; }
public string Detail67CreatedBy { get; set; }
public bool IsDetail67Active { get; set; }
public int Detail67SortOrder { get; set; }


public int Entry11Id { get; set; }
public string Entry11Name { get; set; }
public string Entry11Description { get; set; }
public DateTime Entry11CreatedAt { get; set; }
public DateTime? Entry11UpdatedAt { get; set; }
public string Entry11CreatedBy { get; set; }
public bool IsEntry11Active { get; set; }
public int Entry11SortOrder { get; set; }


public int Config76Id { get; set; }
public string Config76Name { get; set; }
public string Config76Description { get; set; }
public DateTime Config76CreatedAt { get; set; }
public DateTime? Config76UpdatedAt { get; set; }
public string Config76CreatedBy { get; set; }
public bool IsConfig76Active { get; set; }
public int Config76SortOrder { get; set; }


public int Param10Id { get; set; }
public string Param10Name { get; set; }
public string Param10Description { get; set; }
public DateTime Param10CreatedAt { get; set; }
public DateTime? Param10UpdatedAt { get; set; }
public string Param10CreatedBy { get; set; }
public bool IsParam10Active { get; set; }
public int Param10SortOrder { get; set; }


public int Attr69Id { get; set; }
public string Attr69Name { get; set; }
public string Attr69Description { get; set; }
public DateTime Attr69CreatedAt { get; set; }
public DateTime? Attr69UpdatedAt { get; set; }
public string Attr69CreatedBy { get; set; }
public bool IsAttr69Active { get; set; }
public int Attr69SortOrder { get; set; }


public int Attr1Id { get; set; }
public string Attr1Name { get; set; }
public string Attr1Description { get; set; }
public DateTime Attr1CreatedAt { get; set; }
public DateTime? Attr1UpdatedAt { get; set; }
public string Attr1CreatedBy { get; set; }
public bool IsAttr1Active { get; set; }
public int Attr1SortOrder { get; set; }


public int Record35Id { get; set; }
public string Record35Name { get; set; }
public string Record35Description { get; set; }
public DateTime Record35CreatedAt { get; set; }
public DateTime? Record35UpdatedAt { get; set; }
public string Record35CreatedBy { get; set; }
public bool IsRecord35Active { get; set; }
public int Record35SortOrder { get; set; }


public int Item80Id { get; set; }
public string Item80Name { get; set; }
public string Item80Description { get; set; }
public DateTime Item80CreatedAt { get; set; }
public DateTime? Item80UpdatedAt { get; set; }
public string Item80CreatedBy { get; set; }
public bool IsItem80Active { get; set; }
public int Item80SortOrder { get; set; }


public int Field60Id { get; set; }
public string Field60Name { get; set; }
public string Field60Description { get; set; }
public DateTime Field60CreatedAt { get; set; }
public DateTime? Field60UpdatedAt { get; set; }
public string Field60CreatedBy { get; set; }
public bool IsField60Active { get; set; }
public int Field60SortOrder { get; set; }


public int Entry45Id { get; set; }
public string Entry45Name { get; set; }
public string Entry45Description { get; set; }
public DateTime Entry45CreatedAt { get; set; }
public DateTime? Entry45UpdatedAt { get; set; }
public string Entry45CreatedBy { get; set; }
public bool IsEntry45Active { get; set; }
public int Entry45SortOrder { get; set; }


public int Entry47Id { get; set; }
public string Entry47Name { get; set; }
public string Entry47Description { get; set; }
public DateTime Entry47CreatedAt { get; set; }
public DateTime? Entry47UpdatedAt { get; set; }
public string Entry47CreatedBy { get; set; }
public bool IsEntry47Active { get; set; }
public int Entry47SortOrder { get; set; }


public int Param69Id { get; set; }
public string Param69Name { get; set; }
public string Param69Description { get; set; }
public DateTime Param69CreatedAt { get; set; }
public DateTime? Param69UpdatedAt { get; set; }
public string Param69CreatedBy { get; set; }
public bool IsParam69Active { get; set; }
public int Param69SortOrder { get; set; }


public int Entry83Id { get; set; }
public string Entry83Name { get; set; }
public string Entry83Description { get; set; }
public DateTime Entry83CreatedAt { get; set; }
public DateTime? Entry83UpdatedAt { get; set; }
public string Entry83CreatedBy { get; set; }
public bool IsEntry83Active { get; set; }
public int Entry83SortOrder { get; set; }


public int Record34Id { get; set; }
public string Record34Name { get; set; }
public string Record34Description { get; set; }
public DateTime Record34CreatedAt { get; set; }
public DateTime? Record34UpdatedAt { get; set; }
public string Record34CreatedBy { get; set; }
public bool IsRecord34Active { get; set; }
public int Record34SortOrder { get; set; }


public int Config65Id { get; set; }
public string Config65Name { get; set; }
public string Config65Description { get; set; }
public DateTime Config65CreatedAt { get; set; }
public DateTime? Config65UpdatedAt { get; set; }
public string Config65CreatedBy { get; set; }
public bool IsConfig65Active { get; set; }
public int Config65SortOrder { get; set; }


public int Item40Id { get; set; }
public string Item40Name { get; set; }
public string Item40Description { get; set; }
public DateTime Item40CreatedAt { get; set; }
public DateTime? Item40UpdatedAt { get; set; }
public string Item40CreatedBy { get; set; }
public bool IsItem40Active { get; set; }
public int Item40SortOrder { get; set; }


public int Param85Id { get; set; }
public string Param85Name { get; set; }
public string Param85Description { get; set; }
public DateTime Param85CreatedAt { get; set; }
public DateTime? Param85UpdatedAt { get; set; }
public string Param85CreatedBy { get; set; }
public bool IsParam85Active { get; set; }
public int Param85SortOrder { get; set; }


public int Param77Id { get; set; }
public string Param77Name { get; set; }
public string Param77Description { get; set; }
public DateTime Param77CreatedAt { get; set; }
public DateTime? Param77UpdatedAt { get; set; }
public string Param77CreatedBy { get; set; }
public bool IsParam77Active { get; set; }
public int Param77SortOrder { get; set; }


public int Entry81Id { get; set; }
public string Entry81Name { get; set; }
public string Entry81Description { get; set; }
public DateTime Entry81CreatedAt { get; set; }
public DateTime? Entry81UpdatedAt { get; set; }
public string Entry81CreatedBy { get; set; }
public bool IsEntry81Active { get; set; }
public int Entry81SortOrder { get; set; }


public int Config61Id { get; set; }
public string Config61Name { get; set; }
public string Config61Description { get; set; }
public DateTime Config61CreatedAt { get; set; }
public DateTime? Config61UpdatedAt { get; set; }
public string Config61CreatedBy { get; set; }
public bool IsConfig61Active { get; set; }
public int Config61SortOrder { get; set; }


public int Record73Id { get; set; }
public string Record73Name { get; set; }
public string Record73Description { get; set; }
public DateTime Record73CreatedAt { get; set; }
public DateTime? Record73UpdatedAt { get; set; }
public string Record73CreatedBy { get; set; }
public bool IsRecord73Active { get; set; }
public int Record73SortOrder { get; set; }


public int Record46Id { get; set; }
public string Record46Name { get; set; }
public string Record46Description { get; set; }
public DateTime Record46CreatedAt { get; set; }
public DateTime? Record46UpdatedAt { get; set; }
public string Record46CreatedBy { get; set; }
public bool IsRecord46Active { get; set; }
public int Record46SortOrder { get; set; }


public int Param94Id { get; set; }
public string Param94Name { get; set; }
public string Param94Description { get; set; }
public DateTime Param94CreatedAt { get; set; }
public DateTime? Param94UpdatedAt { get; set; }
public string Param94CreatedBy { get; set; }
public bool IsParam94Active { get; set; }
public int Param94SortOrder { get; set; }


public int Entry38Id { get; set; }
public string Entry38Name { get; set; }
public string Entry38Description { get; set; }
public DateTime Entry38CreatedAt { get; set; }
public DateTime? Entry38UpdatedAt { get; set; }
public string Entry38CreatedBy { get; set; }
public bool IsEntry38Active { get; set; }
public int Entry38SortOrder { get; set; }


public int Entry27Id { get; set; }
public string Entry27Name { get; set; }
public string Entry27Description { get; set; }
public DateTime Entry27CreatedAt { get; set; }
public DateTime? Entry27UpdatedAt { get; set; }
public string Entry27CreatedBy { get; set; }
public bool IsEntry27Active { get; set; }
public int Entry27SortOrder { get; set; }


public int Field25Id { get; set; }
public string Field25Name { get; set; }
public string Field25Description { get; set; }
public DateTime Field25CreatedAt { get; set; }
public DateTime? Field25UpdatedAt { get; set; }
public string Field25CreatedBy { get; set; }
public bool IsField25Active { get; set; }
public int Field25SortOrder { get; set; }


public int Record19Id { get; set; }
public string Record19Name { get; set; }
public string Record19Description { get; set; }
public DateTime Record19CreatedAt { get; set; }
public DateTime? Record19UpdatedAt { get; set; }
public string Record19CreatedBy { get; set; }
public bool IsRecord19Active { get; set; }
public int Record19SortOrder { get; set; }


public int Field42Id { get; set; }
public string Field42Name { get; set; }
public string Field42Description { get; set; }
public DateTime Field42CreatedAt { get; set; }
public DateTime? Field42UpdatedAt { get; set; }
public string Field42CreatedBy { get; set; }
public bool IsField42Active { get; set; }
public int Field42SortOrder { get; set; }


public int Field10Id { get; set; }
public string Field10Name { get; set; }
public string Field10Description { get; set; }
public DateTime Field10CreatedAt { get; set; }
public DateTime? Field10UpdatedAt { get; set; }
public string Field10CreatedBy { get; set; }
public bool IsField10Active { get; set; }
public int Field10SortOrder { get; set; }


public int Entry49Id { get; set; }
public string Entry49Name { get; set; }
public string Entry49Description { get; set; }
public DateTime Entry49CreatedAt { get; set; }
public DateTime? Entry49UpdatedAt { get; set; }
public string Entry49CreatedBy { get; set; }
public bool IsEntry49Active { get; set; }
public int Entry49SortOrder { get; set; }


public int Param40Id { get; set; }
public string Param40Name { get; set; }
public string Param40Description { get; set; }
public DateTime Param40CreatedAt { get; set; }
public DateTime? Param40UpdatedAt { get; set; }
public string Param40CreatedBy { get; set; }
public bool IsParam40Active { get; set; }
public int Param40SortOrder { get; set; }


public int Entry33Id { get; set; }
public string Entry33Name { get; set; }
public string Entry33Description { get; set; }
public DateTime Entry33CreatedAt { get; set; }
public DateTime? Entry33UpdatedAt { get; set; }
public string Entry33CreatedBy { get; set; }
public bool IsEntry33Active { get; set; }
public int Entry33SortOrder { get; set; }


public int Param93Id { get; set; }
public string Param93Name { get; set; }
public string Param93Description { get; set; }
public DateTime Param93CreatedAt { get; set; }
public DateTime? Param93UpdatedAt { get; set; }
public string Param93CreatedBy { get; set; }
public bool IsParam93Active { get; set; }
public int Param93SortOrder { get; set; }


public int Entry49Id { get; set; }
public string Entry49Name { get; set; }
public string Entry49Description { get; set; }
public DateTime Entry49CreatedAt { get; set; }
public DateTime? Entry49UpdatedAt { get; set; }
public string Entry49CreatedBy { get; set; }
public bool IsEntry49Active { get; set; }
public int Entry49SortOrder { get; set; }


public int Entry6Id { get; set; }
public string Entry6Name { get; set; }
public string Entry6Description { get; set; }
public DateTime Entry6CreatedAt { get; set; }
public DateTime? Entry6UpdatedAt { get; set; }
public string Entry6CreatedBy { get; set; }
public bool IsEntry6Active { get; set; }
public int Entry6SortOrder { get; set; }


public int Record11Id { get; set; }
public string Record11Name { get; set; }
public string Record11Description { get; set; }
public DateTime Record11CreatedAt { get; set; }
public DateTime? Record11UpdatedAt { get; set; }
public string Record11CreatedBy { get; set; }
public bool IsRecord11Active { get; set; }
public int Record11SortOrder { get; set; }

    }
}