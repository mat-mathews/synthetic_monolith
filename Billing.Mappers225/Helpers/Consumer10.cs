using Admin.Data117;
using Admin.Models199;
using Admin.Shared;
using Auth.Mappers28;
using Documents.Service471;
using Export.Events163;
using Import.Client64;
using Integration.Handlers;
using Logging.Web;
using Notifications.Contracts;
using Notifications.Validators;
using Portal.Api51;
using Reporting.Api393;
using Scheduling.Core;
using Scheduling.Web221;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Models41;

namespace Billing.Mappers225
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer10
    {
        private readonly IAdmin_Data117_Service _iAdmin_Data117_Service;
        private readonly IAdmin_Data117_Factory8 _iAdmin_Data117_Factory8;
        private readonly Integration_Handlers_Processor5 _integration_Handlers_Processor5;
        private readonly IIntegration_Handlers_Validator3 _iIntegration_Handlers_Validator3;
        private readonly Admin_Models199_Repository1 _admin_Models199_Repository1;
        private readonly IAdmin_Models199_Service2 _iAdmin_Models199_Service2;
        private readonly Utilities_Models41_Controller2 _utilities_Models41_Controller2;
        private readonly Notifications_Validators_Provider2 _notifications_Validators_Provider2;

        public Consumer10(IAdmin_Data117_Service iAdmin_Data117_Service, IAdmin_Data117_Factory8 iAdmin_Data117_Factory8, Integration_Handlers_Processor5 integration_Handlers_Processor5, IIntegration_Handlers_Validator3 iIntegration_Handlers_Validator3, Admin_Models199_Repository1 admin_Models199_Repository1, IAdmin_Models199_Service2 iAdmin_Models199_Service2, Utilities_Models41_Controller2 utilities_Models41_Controller2, Notifications_Validators_Provider2 notifications_Validators_Provider2)
        {
            _iAdmin_Data117_Service = iAdmin_Data117_Service ?? throw new ArgumentNullException(nameof(iAdmin_Data117_Service));
            _iAdmin_Data117_Factory8 = iAdmin_Data117_Factory8 ?? throw new ArgumentNullException(nameof(iAdmin_Data117_Factory8));
            _integration_Handlers_Processor5 = integration_Handlers_Processor5 ?? throw new ArgumentNullException(nameof(integration_Handlers_Processor5));
            _iIntegration_Handlers_Validator3 = iIntegration_Handlers_Validator3 ?? throw new ArgumentNullException(nameof(iIntegration_Handlers_Validator3));
            _admin_Models199_Repository1 = admin_Models199_Repository1 ?? throw new ArgumentNullException(nameof(admin_Models199_Repository1));
            _iAdmin_Models199_Service2 = iAdmin_Models199_Service2 ?? throw new ArgumentNullException(nameof(iAdmin_Models199_Service2));
            _utilities_Models41_Controller2 = utilities_Models41_Controller2 ?? throw new ArgumentNullException(nameof(utilities_Models41_Controller2));
            _notifications_Validators_Provider2 = notifications_Validators_Provider2 ?? throw new ArgumentNullException(nameof(notifications_Validators_Provider2));
        }

        public IAdmin_Data117_Service GetIAdmin_Data117_Service() => _iAdmin_Data117_Service;
        public IAdmin_Data117_Factory8 GetIAdmin_Data117_Factory8() => _iAdmin_Data117_Factory8;
        public Integration_Handlers_Processor5 GetIntegration_Handlers_Processor5() => _integration_Handlers_Processor5;
        public IIntegration_Handlers_Validator3 GetIIntegration_Handlers_Validator3() => _iIntegration_Handlers_Validator3;
        public Admin_Models199_Repository1 GetAdmin_Models199_Repository1() => _admin_Models199_Repository1;
        public IAdmin_Models199_Service2 GetIAdmin_Models199_Service2() => _iAdmin_Models199_Service2;
        public Utilities_Models41_Controller2 GetUtilities_Models41_Controller2() => _utilities_Models41_Controller2;
        public Notifications_Validators_Provider2 GetNotifications_Validators_Provider2() => _notifications_Validators_Provider2;

/// <summary>
/// Validates the Consumer10 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer10(Consumer10Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer10));
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
/// Processes the Consumer10 operation asynchronously.
/// </summary>
public async Task<Consumer10Result> ProcessConsumer10Async(
    Consumer10Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer10), request.Id);

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
            return new Consumer10Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer10));
        return new Consumer10Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer10));
        return new Consumer10Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer10 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer10Dto>> GetConsumer10ListAsync(
    Consumer10Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer10Entity>().AsQueryable();

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
        .Select(x => new Consumer10Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer10Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer10Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer10Service(
    ILogger<Consumer10Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer10:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer10 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer10Data> GetCachedConsumer10Async(string key)
{
    var cacheKey = $"Consumer10_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer10Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer10SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Attr40Id { get; set; }
public string Attr40Name { get; set; }
public string Attr40Description { get; set; }
public DateTime Attr40CreatedAt { get; set; }
public DateTime? Attr40UpdatedAt { get; set; }
public string Attr40CreatedBy { get; set; }
public bool IsAttr40Active { get; set; }
public int Attr40SortOrder { get; set; }


public int Attr53Id { get; set; }
public string Attr53Name { get; set; }
public string Attr53Description { get; set; }
public DateTime Attr53CreatedAt { get; set; }
public DateTime? Attr53UpdatedAt { get; set; }
public string Attr53CreatedBy { get; set; }
public bool IsAttr53Active { get; set; }
public int Attr53SortOrder { get; set; }


public int Attr37Id { get; set; }
public string Attr37Name { get; set; }
public string Attr37Description { get; set; }
public DateTime Attr37CreatedAt { get; set; }
public DateTime? Attr37UpdatedAt { get; set; }
public string Attr37CreatedBy { get; set; }
public bool IsAttr37Active { get; set; }
public int Attr37SortOrder { get; set; }


public int Field76Id { get; set; }
public string Field76Name { get; set; }
public string Field76Description { get; set; }
public DateTime Field76CreatedAt { get; set; }
public DateTime? Field76UpdatedAt { get; set; }
public string Field76CreatedBy { get; set; }
public bool IsField76Active { get; set; }
public int Field76SortOrder { get; set; }


public int Param43Id { get; set; }
public string Param43Name { get; set; }
public string Param43Description { get; set; }
public DateTime Param43CreatedAt { get; set; }
public DateTime? Param43UpdatedAt { get; set; }
public string Param43CreatedBy { get; set; }
public bool IsParam43Active { get; set; }
public int Param43SortOrder { get; set; }


public int Entry14Id { get; set; }
public string Entry14Name { get; set; }
public string Entry14Description { get; set; }
public DateTime Entry14CreatedAt { get; set; }
public DateTime? Entry14UpdatedAt { get; set; }
public string Entry14CreatedBy { get; set; }
public bool IsEntry14Active { get; set; }
public int Entry14SortOrder { get; set; }


public int Param71Id { get; set; }
public string Param71Name { get; set; }
public string Param71Description { get; set; }
public DateTime Param71CreatedAt { get; set; }
public DateTime? Param71UpdatedAt { get; set; }
public string Param71CreatedBy { get; set; }
public bool IsParam71Active { get; set; }
public int Param71SortOrder { get; set; }


public int Entry32Id { get; set; }
public string Entry32Name { get; set; }
public string Entry32Description { get; set; }
public DateTime Entry32CreatedAt { get; set; }
public DateTime? Entry32UpdatedAt { get; set; }
public string Entry32CreatedBy { get; set; }
public bool IsEntry32Active { get; set; }
public int Entry32SortOrder { get; set; }


public int Item3Id { get; set; }
public string Item3Name { get; set; }
public string Item3Description { get; set; }
public DateTime Item3CreatedAt { get; set; }
public DateTime? Item3UpdatedAt { get; set; }
public string Item3CreatedBy { get; set; }
public bool IsItem3Active { get; set; }
public int Item3SortOrder { get; set; }


public int Param76Id { get; set; }
public string Param76Name { get; set; }
public string Param76Description { get; set; }
public DateTime Param76CreatedAt { get; set; }
public DateTime? Param76UpdatedAt { get; set; }
public string Param76CreatedBy { get; set; }
public bool IsParam76Active { get; set; }
public int Param76SortOrder { get; set; }


public int Detail70Id { get; set; }
public string Detail70Name { get; set; }
public string Detail70Description { get; set; }
public DateTime Detail70CreatedAt { get; set; }
public DateTime? Detail70UpdatedAt { get; set; }
public string Detail70CreatedBy { get; set; }
public bool IsDetail70Active { get; set; }
public int Detail70SortOrder { get; set; }


public int Config80Id { get; set; }
public string Config80Name { get; set; }
public string Config80Description { get; set; }
public DateTime Config80CreatedAt { get; set; }
public DateTime? Config80UpdatedAt { get; set; }
public string Config80CreatedBy { get; set; }
public bool IsConfig80Active { get; set; }
public int Config80SortOrder { get; set; }


public int Attr75Id { get; set; }
public string Attr75Name { get; set; }
public string Attr75Description { get; set; }
public DateTime Attr75CreatedAt { get; set; }
public DateTime? Attr75UpdatedAt { get; set; }
public string Attr75CreatedBy { get; set; }
public bool IsAttr75Active { get; set; }
public int Attr75SortOrder { get; set; }


public int Record38Id { get; set; }
public string Record38Name { get; set; }
public string Record38Description { get; set; }
public DateTime Record38CreatedAt { get; set; }
public DateTime? Record38UpdatedAt { get; set; }
public string Record38CreatedBy { get; set; }
public bool IsRecord38Active { get; set; }
public int Record38SortOrder { get; set; }


public int Record68Id { get; set; }
public string Record68Name { get; set; }
public string Record68Description { get; set; }
public DateTime Record68CreatedAt { get; set; }
public DateTime? Record68UpdatedAt { get; set; }
public string Record68CreatedBy { get; set; }
public bool IsRecord68Active { get; set; }
public int Record68SortOrder { get; set; }


public int Item42Id { get; set; }
public string Item42Name { get; set; }
public string Item42Description { get; set; }
public DateTime Item42CreatedAt { get; set; }
public DateTime? Item42UpdatedAt { get; set; }
public string Item42CreatedBy { get; set; }
public bool IsItem42Active { get; set; }
public int Item42SortOrder { get; set; }


public int Item47Id { get; set; }
public string Item47Name { get; set; }
public string Item47Description { get; set; }
public DateTime Item47CreatedAt { get; set; }
public DateTime? Item47UpdatedAt { get; set; }
public string Item47CreatedBy { get; set; }
public bool IsItem47Active { get; set; }
public int Item47SortOrder { get; set; }


public int Detail16Id { get; set; }
public string Detail16Name { get; set; }
public string Detail16Description { get; set; }
public DateTime Detail16CreatedAt { get; set; }
public DateTime? Detail16UpdatedAt { get; set; }
public string Detail16CreatedBy { get; set; }
public bool IsDetail16Active { get; set; }
public int Detail16SortOrder { get; set; }


public int Item48Id { get; set; }
public string Item48Name { get; set; }
public string Item48Description { get; set; }
public DateTime Item48CreatedAt { get; set; }
public DateTime? Item48UpdatedAt { get; set; }
public string Item48CreatedBy { get; set; }
public bool IsItem48Active { get; set; }
public int Item48SortOrder { get; set; }


public int Param38Id { get; set; }
public string Param38Name { get; set; }
public string Param38Description { get; set; }
public DateTime Param38CreatedAt { get; set; }
public DateTime? Param38UpdatedAt { get; set; }
public string Param38CreatedBy { get; set; }
public bool IsParam38Active { get; set; }
public int Param38SortOrder { get; set; }


public int Item48Id { get; set; }
public string Item48Name { get; set; }
public string Item48Description { get; set; }
public DateTime Item48CreatedAt { get; set; }
public DateTime? Item48UpdatedAt { get; set; }
public string Item48CreatedBy { get; set; }
public bool IsItem48Active { get; set; }
public int Item48SortOrder { get; set; }


public int Item9Id { get; set; }
public string Item9Name { get; set; }
public string Item9Description { get; set; }
public DateTime Item9CreatedAt { get; set; }
public DateTime? Item9UpdatedAt { get; set; }
public string Item9CreatedBy { get; set; }
public bool IsItem9Active { get; set; }
public int Item9SortOrder { get; set; }


public int Detail7Id { get; set; }
public string Detail7Name { get; set; }
public string Detail7Description { get; set; }
public DateTime Detail7CreatedAt { get; set; }
public DateTime? Detail7UpdatedAt { get; set; }
public string Detail7CreatedBy { get; set; }
public bool IsDetail7Active { get; set; }
public int Detail7SortOrder { get; set; }


public int Attr77Id { get; set; }
public string Attr77Name { get; set; }
public string Attr77Description { get; set; }
public DateTime Attr77CreatedAt { get; set; }
public DateTime? Attr77UpdatedAt { get; set; }
public string Attr77CreatedBy { get; set; }
public bool IsAttr77Active { get; set; }
public int Attr77SortOrder { get; set; }


public int Record67Id { get; set; }
public string Record67Name { get; set; }
public string Record67Description { get; set; }
public DateTime Record67CreatedAt { get; set; }
public DateTime? Record67UpdatedAt { get; set; }
public string Record67CreatedBy { get; set; }
public bool IsRecord67Active { get; set; }
public int Record67SortOrder { get; set; }


public int Config48Id { get; set; }
public string Config48Name { get; set; }
public string Config48Description { get; set; }
public DateTime Config48CreatedAt { get; set; }
public DateTime? Config48UpdatedAt { get; set; }
public string Config48CreatedBy { get; set; }
public bool IsConfig48Active { get; set; }
public int Config48SortOrder { get; set; }


public int Field46Id { get; set; }
public string Field46Name { get; set; }
public string Field46Description { get; set; }
public DateTime Field46CreatedAt { get; set; }
public DateTime? Field46UpdatedAt { get; set; }
public string Field46CreatedBy { get; set; }
public bool IsField46Active { get; set; }
public int Field46SortOrder { get; set; }


public int Param35Id { get; set; }
public string Param35Name { get; set; }
public string Param35Description { get; set; }
public DateTime Param35CreatedAt { get; set; }
public DateTime? Param35UpdatedAt { get; set; }
public string Param35CreatedBy { get; set; }
public bool IsParam35Active { get; set; }
public int Param35SortOrder { get; set; }


public int Attr48Id { get; set; }
public string Attr48Name { get; set; }
public string Attr48Description { get; set; }
public DateTime Attr48CreatedAt { get; set; }
public DateTime? Attr48UpdatedAt { get; set; }
public string Attr48CreatedBy { get; set; }
public bool IsAttr48Active { get; set; }
public int Attr48SortOrder { get; set; }


public int Attr62Id { get; set; }
public string Attr62Name { get; set; }
public string Attr62Description { get; set; }
public DateTime Attr62CreatedAt { get; set; }
public DateTime? Attr62UpdatedAt { get; set; }
public string Attr62CreatedBy { get; set; }
public bool IsAttr62Active { get; set; }
public int Attr62SortOrder { get; set; }


public int Attr73Id { get; set; }
public string Attr73Name { get; set; }
public string Attr73Description { get; set; }
public DateTime Attr73CreatedAt { get; set; }
public DateTime? Attr73UpdatedAt { get; set; }
public string Attr73CreatedBy { get; set; }
public bool IsAttr73Active { get; set; }
public int Attr73SortOrder { get; set; }


public int Config62Id { get; set; }
public string Config62Name { get; set; }
public string Config62Description { get; set; }
public DateTime Config62CreatedAt { get; set; }
public DateTime? Config62UpdatedAt { get; set; }
public string Config62CreatedBy { get; set; }
public bool IsConfig62Active { get; set; }
public int Config62SortOrder { get; set; }


public int Config73Id { get; set; }
public string Config73Name { get; set; }
public string Config73Description { get; set; }
public DateTime Config73CreatedAt { get; set; }
public DateTime? Config73UpdatedAt { get; set; }
public string Config73CreatedBy { get; set; }
public bool IsConfig73Active { get; set; }
public int Config73SortOrder { get; set; }


public int Detail4Id { get; set; }
public string Detail4Name { get; set; }
public string Detail4Description { get; set; }
public DateTime Detail4CreatedAt { get; set; }
public DateTime? Detail4UpdatedAt { get; set; }
public string Detail4CreatedBy { get; set; }
public bool IsDetail4Active { get; set; }
public int Detail4SortOrder { get; set; }


public int Record80Id { get; set; }
public string Record80Name { get; set; }
public string Record80Description { get; set; }
public DateTime Record80CreatedAt { get; set; }
public DateTime? Record80UpdatedAt { get; set; }
public string Record80CreatedBy { get; set; }
public bool IsRecord80Active { get; set; }
public int Record80SortOrder { get; set; }


public int Field40Id { get; set; }
public string Field40Name { get; set; }
public string Field40Description { get; set; }
public DateTime Field40CreatedAt { get; set; }
public DateTime? Field40UpdatedAt { get; set; }
public string Field40CreatedBy { get; set; }
public bool IsField40Active { get; set; }
public int Field40SortOrder { get; set; }


public int Attr41Id { get; set; }
public string Attr41Name { get; set; }
public string Attr41Description { get; set; }
public DateTime Attr41CreatedAt { get; set; }
public DateTime? Attr41UpdatedAt { get; set; }
public string Attr41CreatedBy { get; set; }
public bool IsAttr41Active { get; set; }
public int Attr41SortOrder { get; set; }


public int Config5Id { get; set; }
public string Config5Name { get; set; }
public string Config5Description { get; set; }
public DateTime Config5CreatedAt { get; set; }
public DateTime? Config5UpdatedAt { get; set; }
public string Config5CreatedBy { get; set; }
public bool IsConfig5Active { get; set; }
public int Config5SortOrder { get; set; }


public int Config58Id { get; set; }
public string Config58Name { get; set; }
public string Config58Description { get; set; }
public DateTime Config58CreatedAt { get; set; }
public DateTime? Config58UpdatedAt { get; set; }
public string Config58CreatedBy { get; set; }
public bool IsConfig58Active { get; set; }
public int Config58SortOrder { get; set; }


public int Config3Id { get; set; }
public string Config3Name { get; set; }
public string Config3Description { get; set; }
public DateTime Config3CreatedAt { get; set; }
public DateTime? Config3UpdatedAt { get; set; }
public string Config3CreatedBy { get; set; }
public bool IsConfig3Active { get; set; }
public int Config3SortOrder { get; set; }


public int Attr25Id { get; set; }
public string Attr25Name { get; set; }
public string Attr25Description { get; set; }
public DateTime Attr25CreatedAt { get; set; }
public DateTime? Attr25UpdatedAt { get; set; }
public string Attr25CreatedBy { get; set; }
public bool IsAttr25Active { get; set; }
public int Attr25SortOrder { get; set; }


public int Entry34Id { get; set; }
public string Entry34Name { get; set; }
public string Entry34Description { get; set; }
public DateTime Entry34CreatedAt { get; set; }
public DateTime? Entry34UpdatedAt { get; set; }
public string Entry34CreatedBy { get; set; }
public bool IsEntry34Active { get; set; }
public int Entry34SortOrder { get; set; }


public int Param54Id { get; set; }
public string Param54Name { get; set; }
public string Param54Description { get; set; }
public DateTime Param54CreatedAt { get; set; }
public DateTime? Param54UpdatedAt { get; set; }
public string Param54CreatedBy { get; set; }
public bool IsParam54Active { get; set; }
public int Param54SortOrder { get; set; }


public int Entry39Id { get; set; }
public string Entry39Name { get; set; }
public string Entry39Description { get; set; }
public DateTime Entry39CreatedAt { get; set; }
public DateTime? Entry39UpdatedAt { get; set; }
public string Entry39CreatedBy { get; set; }
public bool IsEntry39Active { get; set; }
public int Entry39SortOrder { get; set; }


public int Detail16Id { get; set; }
public string Detail16Name { get; set; }
public string Detail16Description { get; set; }
public DateTime Detail16CreatedAt { get; set; }
public DateTime? Detail16UpdatedAt { get; set; }
public string Detail16CreatedBy { get; set; }
public bool IsDetail16Active { get; set; }
public int Detail16SortOrder { get; set; }

    }
}