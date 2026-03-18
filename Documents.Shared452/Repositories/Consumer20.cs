using Admin.Contracts120;
using Admin.Shared310;
using BatchJobs.Mappers362;
using Billing.Client;
using DataAccess.Validators;
using Documents.Api129;
using Export.Api49;
using Export.Processors79;
using Export.Validators152;
using Import.Client;
using Logging.Handlers285;
using Logging.Models379;
using Portal.Events151;
using Security.Client349;
using Security.Handlers460;
using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Tests27;

namespace Documents.Shared452
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer20
    {
        private readonly Admin_Shared310_Builder3 _admin_Shared310_Builder3;
        private readonly Import_Client_Controller6 _import_Client_Controller6;
        private readonly IImport_Client_Validator5 _iImport_Client_Validator5;
        private readonly Security_Handlers460_Controller5 _security_Handlers460_Controller5;
        private readonly Logging_Models379_Factory2 _logging_Models379_Factory2;
        private readonly Logging_Models379_Result3 _logging_Models379_Result3;
        private readonly Logging_Models379_Processor4 _logging_Models379_Processor4;
        private readonly Export_Api49_ViewModel7 _export_Api49_ViewModel7;

        public Consumer20(Admin_Shared310_Builder3 admin_Shared310_Builder3, Import_Client_Controller6 import_Client_Controller6, IImport_Client_Validator5 iImport_Client_Validator5, Security_Handlers460_Controller5 security_Handlers460_Controller5, Logging_Models379_Factory2 logging_Models379_Factory2, Logging_Models379_Result3 logging_Models379_Result3, Logging_Models379_Processor4 logging_Models379_Processor4, Export_Api49_ViewModel7 export_Api49_ViewModel7)
        {
            _admin_Shared310_Builder3 = admin_Shared310_Builder3 ?? throw new ArgumentNullException(nameof(admin_Shared310_Builder3));
            _import_Client_Controller6 = import_Client_Controller6 ?? throw new ArgumentNullException(nameof(import_Client_Controller6));
            _iImport_Client_Validator5 = iImport_Client_Validator5 ?? throw new ArgumentNullException(nameof(iImport_Client_Validator5));
            _security_Handlers460_Controller5 = security_Handlers460_Controller5 ?? throw new ArgumentNullException(nameof(security_Handlers460_Controller5));
            _logging_Models379_Factory2 = logging_Models379_Factory2 ?? throw new ArgumentNullException(nameof(logging_Models379_Factory2));
            _logging_Models379_Result3 = logging_Models379_Result3 ?? throw new ArgumentNullException(nameof(logging_Models379_Result3));
            _logging_Models379_Processor4 = logging_Models379_Processor4 ?? throw new ArgumentNullException(nameof(logging_Models379_Processor4));
            _export_Api49_ViewModel7 = export_Api49_ViewModel7 ?? throw new ArgumentNullException(nameof(export_Api49_ViewModel7));
        }

        public Admin_Shared310_Builder3 GetAdmin_Shared310_Builder3() => _admin_Shared310_Builder3;
        public Import_Client_Controller6 GetImport_Client_Controller6() => _import_Client_Controller6;
        public IImport_Client_Validator5 GetIImport_Client_Validator5() => _iImport_Client_Validator5;
        public Security_Handlers460_Controller5 GetSecurity_Handlers460_Controller5() => _security_Handlers460_Controller5;
        public Logging_Models379_Factory2 GetLogging_Models379_Factory2() => _logging_Models379_Factory2;
        public Logging_Models379_Result3 GetLogging_Models379_Result3() => _logging_Models379_Result3;
        public Logging_Models379_Processor4 GetLogging_Models379_Processor4() => _logging_Models379_Processor4;
        public Export_Api49_ViewModel7 GetExport_Api49_ViewModel7() => _export_Api49_ViewModel7;

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

public int Param92Id { get; set; }
public string Param92Name { get; set; }
public string Param92Description { get; set; }
public DateTime Param92CreatedAt { get; set; }
public DateTime? Param92UpdatedAt { get; set; }
public string Param92CreatedBy { get; set; }
public bool IsParam92Active { get; set; }
public int Param92SortOrder { get; set; }


public int Param26Id { get; set; }
public string Param26Name { get; set; }
public string Param26Description { get; set; }
public DateTime Param26CreatedAt { get; set; }
public DateTime? Param26UpdatedAt { get; set; }
public string Param26CreatedBy { get; set; }
public bool IsParam26Active { get; set; }
public int Param26SortOrder { get; set; }


public int Attr98Id { get; set; }
public string Attr98Name { get; set; }
public string Attr98Description { get; set; }
public DateTime Attr98CreatedAt { get; set; }
public DateTime? Attr98UpdatedAt { get; set; }
public string Attr98CreatedBy { get; set; }
public bool IsAttr98Active { get; set; }
public int Attr98SortOrder { get; set; }


public int Detail46Id { get; set; }
public string Detail46Name { get; set; }
public string Detail46Description { get; set; }
public DateTime Detail46CreatedAt { get; set; }
public DateTime? Detail46UpdatedAt { get; set; }
public string Detail46CreatedBy { get; set; }
public bool IsDetail46Active { get; set; }
public int Detail46SortOrder { get; set; }


public int Entry60Id { get; set; }
public string Entry60Name { get; set; }
public string Entry60Description { get; set; }
public DateTime Entry60CreatedAt { get; set; }
public DateTime? Entry60UpdatedAt { get; set; }
public string Entry60CreatedBy { get; set; }
public bool IsEntry60Active { get; set; }
public int Entry60SortOrder { get; set; }


public int Item25Id { get; set; }
public string Item25Name { get; set; }
public string Item25Description { get; set; }
public DateTime Item25CreatedAt { get; set; }
public DateTime? Item25UpdatedAt { get; set; }
public string Item25CreatedBy { get; set; }
public bool IsItem25Active { get; set; }
public int Item25SortOrder { get; set; }


public int Attr79Id { get; set; }
public string Attr79Name { get; set; }
public string Attr79Description { get; set; }
public DateTime Attr79CreatedAt { get; set; }
public DateTime? Attr79UpdatedAt { get; set; }
public string Attr79CreatedBy { get; set; }
public bool IsAttr79Active { get; set; }
public int Attr79SortOrder { get; set; }


public int Field13Id { get; set; }
public string Field13Name { get; set; }
public string Field13Description { get; set; }
public DateTime Field13CreatedAt { get; set; }
public DateTime? Field13UpdatedAt { get; set; }
public string Field13CreatedBy { get; set; }
public bool IsField13Active { get; set; }
public int Field13SortOrder { get; set; }


public int Attr87Id { get; set; }
public string Attr87Name { get; set; }
public string Attr87Description { get; set; }
public DateTime Attr87CreatedAt { get; set; }
public DateTime? Attr87UpdatedAt { get; set; }
public string Attr87CreatedBy { get; set; }
public bool IsAttr87Active { get; set; }
public int Attr87SortOrder { get; set; }


public int Record6Id { get; set; }
public string Record6Name { get; set; }
public string Record6Description { get; set; }
public DateTime Record6CreatedAt { get; set; }
public DateTime? Record6UpdatedAt { get; set; }
public string Record6CreatedBy { get; set; }
public bool IsRecord6Active { get; set; }
public int Record6SortOrder { get; set; }


public int Record83Id { get; set; }
public string Record83Name { get; set; }
public string Record83Description { get; set; }
public DateTime Record83CreatedAt { get; set; }
public DateTime? Record83UpdatedAt { get; set; }
public string Record83CreatedBy { get; set; }
public bool IsRecord83Active { get; set; }
public int Record83SortOrder { get; set; }


public int Field90Id { get; set; }
public string Field90Name { get; set; }
public string Field90Description { get; set; }
public DateTime Field90CreatedAt { get; set; }
public DateTime? Field90UpdatedAt { get; set; }
public string Field90CreatedBy { get; set; }
public bool IsField90Active { get; set; }
public int Field90SortOrder { get; set; }


public int Record5Id { get; set; }
public string Record5Name { get; set; }
public string Record5Description { get; set; }
public DateTime Record5CreatedAt { get; set; }
public DateTime? Record5UpdatedAt { get; set; }
public string Record5CreatedBy { get; set; }
public bool IsRecord5Active { get; set; }
public int Record5SortOrder { get; set; }


public int Param59Id { get; set; }
public string Param59Name { get; set; }
public string Param59Description { get; set; }
public DateTime Param59CreatedAt { get; set; }
public DateTime? Param59UpdatedAt { get; set; }
public string Param59CreatedBy { get; set; }
public bool IsParam59Active { get; set; }
public int Param59SortOrder { get; set; }


public int Record85Id { get; set; }
public string Record85Name { get; set; }
public string Record85Description { get; set; }
public DateTime Record85CreatedAt { get; set; }
public DateTime? Record85UpdatedAt { get; set; }
public string Record85CreatedBy { get; set; }
public bool IsRecord85Active { get; set; }
public int Record85SortOrder { get; set; }


public int Field55Id { get; set; }
public string Field55Name { get; set; }
public string Field55Description { get; set; }
public DateTime Field55CreatedAt { get; set; }
public DateTime? Field55UpdatedAt { get; set; }
public string Field55CreatedBy { get; set; }
public bool IsField55Active { get; set; }
public int Field55SortOrder { get; set; }


public int Attr76Id { get; set; }
public string Attr76Name { get; set; }
public string Attr76Description { get; set; }
public DateTime Attr76CreatedAt { get; set; }
public DateTime? Attr76UpdatedAt { get; set; }
public string Attr76CreatedBy { get; set; }
public bool IsAttr76Active { get; set; }
public int Attr76SortOrder { get; set; }


public int Item26Id { get; set; }
public string Item26Name { get; set; }
public string Item26Description { get; set; }
public DateTime Item26CreatedAt { get; set; }
public DateTime? Item26UpdatedAt { get; set; }
public string Item26CreatedBy { get; set; }
public bool IsItem26Active { get; set; }
public int Item26SortOrder { get; set; }


public int Param18Id { get; set; }
public string Param18Name { get; set; }
public string Param18Description { get; set; }
public DateTime Param18CreatedAt { get; set; }
public DateTime? Param18UpdatedAt { get; set; }
public string Param18CreatedBy { get; set; }
public bool IsParam18Active { get; set; }
public int Param18SortOrder { get; set; }


public int Config55Id { get; set; }
public string Config55Name { get; set; }
public string Config55Description { get; set; }
public DateTime Config55CreatedAt { get; set; }
public DateTime? Config55UpdatedAt { get; set; }
public string Config55CreatedBy { get; set; }
public bool IsConfig55Active { get; set; }
public int Config55SortOrder { get; set; }


public int Field96Id { get; set; }
public string Field96Name { get; set; }
public string Field96Description { get; set; }
public DateTime Field96CreatedAt { get; set; }
public DateTime? Field96UpdatedAt { get; set; }
public string Field96CreatedBy { get; set; }
public bool IsField96Active { get; set; }
public int Field96SortOrder { get; set; }


public int Record34Id { get; set; }
public string Record34Name { get; set; }
public string Record34Description { get; set; }
public DateTime Record34CreatedAt { get; set; }
public DateTime? Record34UpdatedAt { get; set; }
public string Record34CreatedBy { get; set; }
public bool IsRecord34Active { get; set; }
public int Record34SortOrder { get; set; }


public int Field52Id { get; set; }
public string Field52Name { get; set; }
public string Field52Description { get; set; }
public DateTime Field52CreatedAt { get; set; }
public DateTime? Field52UpdatedAt { get; set; }
public string Field52CreatedBy { get; set; }
public bool IsField52Active { get; set; }
public int Field52SortOrder { get; set; }


public int Item73Id { get; set; }
public string Item73Name { get; set; }
public string Item73Description { get; set; }
public DateTime Item73CreatedAt { get; set; }
public DateTime? Item73UpdatedAt { get; set; }
public string Item73CreatedBy { get; set; }
public bool IsItem73Active { get; set; }
public int Item73SortOrder { get; set; }


public int Record78Id { get; set; }
public string Record78Name { get; set; }
public string Record78Description { get; set; }
public DateTime Record78CreatedAt { get; set; }
public DateTime? Record78UpdatedAt { get; set; }
public string Record78CreatedBy { get; set; }
public bool IsRecord78Active { get; set; }
public int Record78SortOrder { get; set; }


public int Detail86Id { get; set; }
public string Detail86Name { get; set; }
public string Detail86Description { get; set; }
public DateTime Detail86CreatedAt { get; set; }
public DateTime? Detail86UpdatedAt { get; set; }
public string Detail86CreatedBy { get; set; }
public bool IsDetail86Active { get; set; }
public int Detail86SortOrder { get; set; }


public int Config10Id { get; set; }
public string Config10Name { get; set; }
public string Config10Description { get; set; }
public DateTime Config10CreatedAt { get; set; }
public DateTime? Config10UpdatedAt { get; set; }
public string Config10CreatedBy { get; set; }
public bool IsConfig10Active { get; set; }
public int Config10SortOrder { get; set; }


public int Param33Id { get; set; }
public string Param33Name { get; set; }
public string Param33Description { get; set; }
public DateTime Param33CreatedAt { get; set; }
public DateTime? Param33UpdatedAt { get; set; }
public string Param33CreatedBy { get; set; }
public bool IsParam33Active { get; set; }
public int Param33SortOrder { get; set; }


public int Record46Id { get; set; }
public string Record46Name { get; set; }
public string Record46Description { get; set; }
public DateTime Record46CreatedAt { get; set; }
public DateTime? Record46UpdatedAt { get; set; }
public string Record46CreatedBy { get; set; }
public bool IsRecord46Active { get; set; }
public int Record46SortOrder { get; set; }


public int Param20Id { get; set; }
public string Param20Name { get; set; }
public string Param20Description { get; set; }
public DateTime Param20CreatedAt { get; set; }
public DateTime? Param20UpdatedAt { get; set; }
public string Param20CreatedBy { get; set; }
public bool IsParam20Active { get; set; }
public int Param20SortOrder { get; set; }


public int Entry7Id { get; set; }
public string Entry7Name { get; set; }
public string Entry7Description { get; set; }
public DateTime Entry7CreatedAt { get; set; }
public DateTime? Entry7UpdatedAt { get; set; }
public string Entry7CreatedBy { get; set; }
public bool IsEntry7Active { get; set; }
public int Entry7SortOrder { get; set; }


public int Param35Id { get; set; }
public string Param35Name { get; set; }
public string Param35Description { get; set; }
public DateTime Param35CreatedAt { get; set; }
public DateTime? Param35UpdatedAt { get; set; }
public string Param35CreatedBy { get; set; }
public bool IsParam35Active { get; set; }
public int Param35SortOrder { get; set; }


public int Record15Id { get; set; }
public string Record15Name { get; set; }
public string Record15Description { get; set; }
public DateTime Record15CreatedAt { get; set; }
public DateTime? Record15UpdatedAt { get; set; }
public string Record15CreatedBy { get; set; }
public bool IsRecord15Active { get; set; }
public int Record15SortOrder { get; set; }


public int Record86Id { get; set; }
public string Record86Name { get; set; }
public string Record86Description { get; set; }
public DateTime Record86CreatedAt { get; set; }
public DateTime? Record86UpdatedAt { get; set; }
public string Record86CreatedBy { get; set; }
public bool IsRecord86Active { get; set; }
public int Record86SortOrder { get; set; }


public int Config70Id { get; set; }
public string Config70Name { get; set; }
public string Config70Description { get; set; }
public DateTime Config70CreatedAt { get; set; }
public DateTime? Config70UpdatedAt { get; set; }
public string Config70CreatedBy { get; set; }
public bool IsConfig70Active { get; set; }
public int Config70SortOrder { get; set; }


public int Param78Id { get; set; }
public string Param78Name { get; set; }
public string Param78Description { get; set; }
public DateTime Param78CreatedAt { get; set; }
public DateTime? Param78UpdatedAt { get; set; }
public string Param78CreatedBy { get; set; }
public bool IsParam78Active { get; set; }
public int Param78SortOrder { get; set; }


public int Item91Id { get; set; }
public string Item91Name { get; set; }
public string Item91Description { get; set; }
public DateTime Item91CreatedAt { get; set; }
public DateTime? Item91UpdatedAt { get; set; }
public string Item91CreatedBy { get; set; }
public bool IsItem91Active { get; set; }
public int Item91SortOrder { get; set; }


public int Record74Id { get; set; }
public string Record74Name { get; set; }
public string Record74Description { get; set; }
public DateTime Record74CreatedAt { get; set; }
public DateTime? Record74UpdatedAt { get; set; }
public string Record74CreatedBy { get; set; }
public bool IsRecord74Active { get; set; }
public int Record74SortOrder { get; set; }


public int Record41Id { get; set; }
public string Record41Name { get; set; }
public string Record41Description { get; set; }
public DateTime Record41CreatedAt { get; set; }
public DateTime? Record41UpdatedAt { get; set; }
public string Record41CreatedBy { get; set; }
public bool IsRecord41Active { get; set; }
public int Record41SortOrder { get; set; }


public int Detail32Id { get; set; }
public string Detail32Name { get; set; }
public string Detail32Description { get; set; }
public DateTime Detail32CreatedAt { get; set; }
public DateTime? Detail32UpdatedAt { get; set; }
public string Detail32CreatedBy { get; set; }
public bool IsDetail32Active { get; set; }
public int Detail32SortOrder { get; set; }


public int Param18Id { get; set; }
public string Param18Name { get; set; }
public string Param18Description { get; set; }
public DateTime Param18CreatedAt { get; set; }
public DateTime? Param18UpdatedAt { get; set; }
public string Param18CreatedBy { get; set; }
public bool IsParam18Active { get; set; }
public int Param18SortOrder { get; set; }


public int Detail30Id { get; set; }
public string Detail30Name { get; set; }
public string Detail30Description { get; set; }
public DateTime Detail30CreatedAt { get; set; }
public DateTime? Detail30UpdatedAt { get; set; }
public string Detail30CreatedBy { get; set; }
public bool IsDetail30Active { get; set; }
public int Detail30SortOrder { get; set; }


public int Detail1Id { get; set; }
public string Detail1Name { get; set; }
public string Detail1Description { get; set; }
public DateTime Detail1CreatedAt { get; set; }
public DateTime? Detail1UpdatedAt { get; set; }
public string Detail1CreatedBy { get; set; }
public bool IsDetail1Active { get; set; }
public int Detail1SortOrder { get; set; }


public int Detail9Id { get; set; }
public string Detail9Name { get; set; }
public string Detail9Description { get; set; }
public DateTime Detail9CreatedAt { get; set; }
public DateTime? Detail9UpdatedAt { get; set; }
public string Detail9CreatedBy { get; set; }
public bool IsDetail9Active { get; set; }
public int Detail9SortOrder { get; set; }


public int Attr27Id { get; set; }
public string Attr27Name { get; set; }
public string Attr27Description { get; set; }
public DateTime Attr27CreatedAt { get; set; }
public DateTime? Attr27UpdatedAt { get; set; }
public string Attr27CreatedBy { get; set; }
public bool IsAttr27Active { get; set; }
public int Attr27SortOrder { get; set; }

    }
}