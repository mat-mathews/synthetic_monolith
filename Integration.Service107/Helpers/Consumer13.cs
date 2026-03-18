using Admin.Api255;
using Admin.Client346;
using Admin.Tests10;
using BatchJobs.Tests270;
using Common.Client;
using Common.Processors245;
using Common.Service258;
using DataAccess.Api307;
using DataAccess.Core;
using DataAccess.Tests;
using Documents.Models;
using Export.Core;
using Imaging.Mappers93;
using Import.Handlers167;
using Integration.Data175;
using Integration.Service401;
using Portal.Validators227;
using Reporting.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Integration.Service107
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer13
    {
        private readonly Admin_Api255_ViewModel1 _admin_Api255_ViewModel1;
        private readonly Admin_Client346_Provider13 _admin_Client346_Provider13;
        private readonly Admin_Client346_Repository9 _admin_Client346_Repository9;
        private readonly Admin_Client346_Helper4 _admin_Client346_Helper4;
        private readonly Admin_Tests10_Helper12 _admin_Tests10_Helper12;
        private readonly Reporting_Api_Result3 _reporting_Api_Result3;
        private readonly Reporting_Api_Helper2 _reporting_Api_Helper2;
        private readonly DataAccess_Api307_Service5 _dataAccess_Api307_Service5;

        public Consumer13(Admin_Api255_ViewModel1 admin_Api255_ViewModel1, Admin_Client346_Provider13 admin_Client346_Provider13, Admin_Client346_Repository9 admin_Client346_Repository9, Admin_Client346_Helper4 admin_Client346_Helper4, Admin_Tests10_Helper12 admin_Tests10_Helper12, Reporting_Api_Result3 reporting_Api_Result3, Reporting_Api_Helper2 reporting_Api_Helper2, DataAccess_Api307_Service5 dataAccess_Api307_Service5)
        {
            _admin_Api255_ViewModel1 = admin_Api255_ViewModel1 ?? throw new ArgumentNullException(nameof(admin_Api255_ViewModel1));
            _admin_Client346_Provider13 = admin_Client346_Provider13 ?? throw new ArgumentNullException(nameof(admin_Client346_Provider13));
            _admin_Client346_Repository9 = admin_Client346_Repository9 ?? throw new ArgumentNullException(nameof(admin_Client346_Repository9));
            _admin_Client346_Helper4 = admin_Client346_Helper4 ?? throw new ArgumentNullException(nameof(admin_Client346_Helper4));
            _admin_Tests10_Helper12 = admin_Tests10_Helper12 ?? throw new ArgumentNullException(nameof(admin_Tests10_Helper12));
            _reporting_Api_Result3 = reporting_Api_Result3 ?? throw new ArgumentNullException(nameof(reporting_Api_Result3));
            _reporting_Api_Helper2 = reporting_Api_Helper2 ?? throw new ArgumentNullException(nameof(reporting_Api_Helper2));
            _dataAccess_Api307_Service5 = dataAccess_Api307_Service5 ?? throw new ArgumentNullException(nameof(dataAccess_Api307_Service5));
        }

        public Admin_Api255_ViewModel1 GetAdmin_Api255_ViewModel1() => _admin_Api255_ViewModel1;
        public Admin_Client346_Provider13 GetAdmin_Client346_Provider13() => _admin_Client346_Provider13;
        public Admin_Client346_Repository9 GetAdmin_Client346_Repository9() => _admin_Client346_Repository9;
        public Admin_Client346_Helper4 GetAdmin_Client346_Helper4() => _admin_Client346_Helper4;
        public Admin_Tests10_Helper12 GetAdmin_Tests10_Helper12() => _admin_Tests10_Helper12;
        public Reporting_Api_Result3 GetReporting_Api_Result3() => _reporting_Api_Result3;
        public Reporting_Api_Helper2 GetReporting_Api_Helper2() => _reporting_Api_Helper2;
        public DataAccess_Api307_Service5 GetDataAccess_Api307_Service5() => _dataAccess_Api307_Service5;

/// <summary>
/// Validates the Consumer13 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer13(Consumer13Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer13));
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
/// Processes the Consumer13 operation asynchronously.
/// </summary>
public async Task<Consumer13Result> ProcessConsumer13Async(
    Consumer13Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer13), request.Id);

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
            return new Consumer13Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer13));
        return new Consumer13Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer13));
        return new Consumer13Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer13 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer13Dto>> GetConsumer13ListAsync(
    Consumer13Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer13Entity>().AsQueryable();

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
        .Select(x => new Consumer13Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer13Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer13Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer13Service(
    ILogger<Consumer13Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer13:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer13 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer13Data> GetCachedConsumer13Async(string key)
{
    var cacheKey = $"Consumer13_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer13Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer13SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Attr94Id { get; set; }
public string Attr94Name { get; set; }
public string Attr94Description { get; set; }
public DateTime Attr94CreatedAt { get; set; }
public DateTime? Attr94UpdatedAt { get; set; }
public string Attr94CreatedBy { get; set; }
public bool IsAttr94Active { get; set; }
public int Attr94SortOrder { get; set; }


public int Detail75Id { get; set; }
public string Detail75Name { get; set; }
public string Detail75Description { get; set; }
public DateTime Detail75CreatedAt { get; set; }
public DateTime? Detail75UpdatedAt { get; set; }
public string Detail75CreatedBy { get; set; }
public bool IsDetail75Active { get; set; }
public int Detail75SortOrder { get; set; }


public int Record32Id { get; set; }
public string Record32Name { get; set; }
public string Record32Description { get; set; }
public DateTime Record32CreatedAt { get; set; }
public DateTime? Record32UpdatedAt { get; set; }
public string Record32CreatedBy { get; set; }
public bool IsRecord32Active { get; set; }
public int Record32SortOrder { get; set; }


public int Param75Id { get; set; }
public string Param75Name { get; set; }
public string Param75Description { get; set; }
public DateTime Param75CreatedAt { get; set; }
public DateTime? Param75UpdatedAt { get; set; }
public string Param75CreatedBy { get; set; }
public bool IsParam75Active { get; set; }
public int Param75SortOrder { get; set; }


public int Param26Id { get; set; }
public string Param26Name { get; set; }
public string Param26Description { get; set; }
public DateTime Param26CreatedAt { get; set; }
public DateTime? Param26UpdatedAt { get; set; }
public string Param26CreatedBy { get; set; }
public bool IsParam26Active { get; set; }
public int Param26SortOrder { get; set; }


public int Detail86Id { get; set; }
public string Detail86Name { get; set; }
public string Detail86Description { get; set; }
public DateTime Detail86CreatedAt { get; set; }
public DateTime? Detail86UpdatedAt { get; set; }
public string Detail86CreatedBy { get; set; }
public bool IsDetail86Active { get; set; }
public int Detail86SortOrder { get; set; }


public int Item48Id { get; set; }
public string Item48Name { get; set; }
public string Item48Description { get; set; }
public DateTime Item48CreatedAt { get; set; }
public DateTime? Item48UpdatedAt { get; set; }
public string Item48CreatedBy { get; set; }
public bool IsItem48Active { get; set; }
public int Item48SortOrder { get; set; }


public int Detail58Id { get; set; }
public string Detail58Name { get; set; }
public string Detail58Description { get; set; }
public DateTime Detail58CreatedAt { get; set; }
public DateTime? Detail58UpdatedAt { get; set; }
public string Detail58CreatedBy { get; set; }
public bool IsDetail58Active { get; set; }
public int Detail58SortOrder { get; set; }


public int Item79Id { get; set; }
public string Item79Name { get; set; }
public string Item79Description { get; set; }
public DateTime Item79CreatedAt { get; set; }
public DateTime? Item79UpdatedAt { get; set; }
public string Item79CreatedBy { get; set; }
public bool IsItem79Active { get; set; }
public int Item79SortOrder { get; set; }


public int Param90Id { get; set; }
public string Param90Name { get; set; }
public string Param90Description { get; set; }
public DateTime Param90CreatedAt { get; set; }
public DateTime? Param90UpdatedAt { get; set; }
public string Param90CreatedBy { get; set; }
public bool IsParam90Active { get; set; }
public int Param90SortOrder { get; set; }


public int Detail71Id { get; set; }
public string Detail71Name { get; set; }
public string Detail71Description { get; set; }
public DateTime Detail71CreatedAt { get; set; }
public DateTime? Detail71UpdatedAt { get; set; }
public string Detail71CreatedBy { get; set; }
public bool IsDetail71Active { get; set; }
public int Detail71SortOrder { get; set; }


public int Config88Id { get; set; }
public string Config88Name { get; set; }
public string Config88Description { get; set; }
public DateTime Config88CreatedAt { get; set; }
public DateTime? Config88UpdatedAt { get; set; }
public string Config88CreatedBy { get; set; }
public bool IsConfig88Active { get; set; }
public int Config88SortOrder { get; set; }


public int Detail80Id { get; set; }
public string Detail80Name { get; set; }
public string Detail80Description { get; set; }
public DateTime Detail80CreatedAt { get; set; }
public DateTime? Detail80UpdatedAt { get; set; }
public string Detail80CreatedBy { get; set; }
public bool IsDetail80Active { get; set; }
public int Detail80SortOrder { get; set; }


public int Config13Id { get; set; }
public string Config13Name { get; set; }
public string Config13Description { get; set; }
public DateTime Config13CreatedAt { get; set; }
public DateTime? Config13UpdatedAt { get; set; }
public string Config13CreatedBy { get; set; }
public bool IsConfig13Active { get; set; }
public int Config13SortOrder { get; set; }


public int Field57Id { get; set; }
public string Field57Name { get; set; }
public string Field57Description { get; set; }
public DateTime Field57CreatedAt { get; set; }
public DateTime? Field57UpdatedAt { get; set; }
public string Field57CreatedBy { get; set; }
public bool IsField57Active { get; set; }
public int Field57SortOrder { get; set; }


public int Attr55Id { get; set; }
public string Attr55Name { get; set; }
public string Attr55Description { get; set; }
public DateTime Attr55CreatedAt { get; set; }
public DateTime? Attr55UpdatedAt { get; set; }
public string Attr55CreatedBy { get; set; }
public bool IsAttr55Active { get; set; }
public int Attr55SortOrder { get; set; }


public int Field7Id { get; set; }
public string Field7Name { get; set; }
public string Field7Description { get; set; }
public DateTime Field7CreatedAt { get; set; }
public DateTime? Field7UpdatedAt { get; set; }
public string Field7CreatedBy { get; set; }
public bool IsField7Active { get; set; }
public int Field7SortOrder { get; set; }


public int Entry30Id { get; set; }
public string Entry30Name { get; set; }
public string Entry30Description { get; set; }
public DateTime Entry30CreatedAt { get; set; }
public DateTime? Entry30UpdatedAt { get; set; }
public string Entry30CreatedBy { get; set; }
public bool IsEntry30Active { get; set; }
public int Entry30SortOrder { get; set; }


public int Config32Id { get; set; }
public string Config32Name { get; set; }
public string Config32Description { get; set; }
public DateTime Config32CreatedAt { get; set; }
public DateTime? Config32UpdatedAt { get; set; }
public string Config32CreatedBy { get; set; }
public bool IsConfig32Active { get; set; }
public int Config32SortOrder { get; set; }


public int Item83Id { get; set; }
public string Item83Name { get; set; }
public string Item83Description { get; set; }
public DateTime Item83CreatedAt { get; set; }
public DateTime? Item83UpdatedAt { get; set; }
public string Item83CreatedBy { get; set; }
public bool IsItem83Active { get; set; }
public int Item83SortOrder { get; set; }


public int Record77Id { get; set; }
public string Record77Name { get; set; }
public string Record77Description { get; set; }
public DateTime Record77CreatedAt { get; set; }
public DateTime? Record77UpdatedAt { get; set; }
public string Record77CreatedBy { get; set; }
public bool IsRecord77Active { get; set; }
public int Record77SortOrder { get; set; }


public int Field22Id { get; set; }
public string Field22Name { get; set; }
public string Field22Description { get; set; }
public DateTime Field22CreatedAt { get; set; }
public DateTime? Field22UpdatedAt { get; set; }
public string Field22CreatedBy { get; set; }
public bool IsField22Active { get; set; }
public int Field22SortOrder { get; set; }


public int Field75Id { get; set; }
public string Field75Name { get; set; }
public string Field75Description { get; set; }
public DateTime Field75CreatedAt { get; set; }
public DateTime? Field75UpdatedAt { get; set; }
public string Field75CreatedBy { get; set; }
public bool IsField75Active { get; set; }
public int Field75SortOrder { get; set; }


public int Param90Id { get; set; }
public string Param90Name { get; set; }
public string Param90Description { get; set; }
public DateTime Param90CreatedAt { get; set; }
public DateTime? Param90UpdatedAt { get; set; }
public string Param90CreatedBy { get; set; }
public bool IsParam90Active { get; set; }
public int Param90SortOrder { get; set; }


public int Detail17Id { get; set; }
public string Detail17Name { get; set; }
public string Detail17Description { get; set; }
public DateTime Detail17CreatedAt { get; set; }
public DateTime? Detail17UpdatedAt { get; set; }
public string Detail17CreatedBy { get; set; }
public bool IsDetail17Active { get; set; }
public int Detail17SortOrder { get; set; }


public int Field92Id { get; set; }
public string Field92Name { get; set; }
public string Field92Description { get; set; }
public DateTime Field92CreatedAt { get; set; }
public DateTime? Field92UpdatedAt { get; set; }
public string Field92CreatedBy { get; set; }
public bool IsField92Active { get; set; }
public int Field92SortOrder { get; set; }


public int Record46Id { get; set; }
public string Record46Name { get; set; }
public string Record46Description { get; set; }
public DateTime Record46CreatedAt { get; set; }
public DateTime? Record46UpdatedAt { get; set; }
public string Record46CreatedBy { get; set; }
public bool IsRecord46Active { get; set; }
public int Record46SortOrder { get; set; }


public int Item29Id { get; set; }
public string Item29Name { get; set; }
public string Item29Description { get; set; }
public DateTime Item29CreatedAt { get; set; }
public DateTime? Item29UpdatedAt { get; set; }
public string Item29CreatedBy { get; set; }
public bool IsItem29Active { get; set; }
public int Item29SortOrder { get; set; }


public int Attr49Id { get; set; }
public string Attr49Name { get; set; }
public string Attr49Description { get; set; }
public DateTime Attr49CreatedAt { get; set; }
public DateTime? Attr49UpdatedAt { get; set; }
public string Attr49CreatedBy { get; set; }
public bool IsAttr49Active { get; set; }
public int Attr49SortOrder { get; set; }


public int Field59Id { get; set; }
public string Field59Name { get; set; }
public string Field59Description { get; set; }
public DateTime Field59CreatedAt { get; set; }
public DateTime? Field59UpdatedAt { get; set; }
public string Field59CreatedBy { get; set; }
public bool IsField59Active { get; set; }
public int Field59SortOrder { get; set; }


public int Detail57Id { get; set; }
public string Detail57Name { get; set; }
public string Detail57Description { get; set; }
public DateTime Detail57CreatedAt { get; set; }
public DateTime? Detail57UpdatedAt { get; set; }
public string Detail57CreatedBy { get; set; }
public bool IsDetail57Active { get; set; }
public int Detail57SortOrder { get; set; }


public int Record58Id { get; set; }
public string Record58Name { get; set; }
public string Record58Description { get; set; }
public DateTime Record58CreatedAt { get; set; }
public DateTime? Record58UpdatedAt { get; set; }
public string Record58CreatedBy { get; set; }
public bool IsRecord58Active { get; set; }
public int Record58SortOrder { get; set; }


public int Entry43Id { get; set; }
public string Entry43Name { get; set; }
public string Entry43Description { get; set; }
public DateTime Entry43CreatedAt { get; set; }
public DateTime? Entry43UpdatedAt { get; set; }
public string Entry43CreatedBy { get; set; }
public bool IsEntry43Active { get; set; }
public int Entry43SortOrder { get; set; }


public int Attr60Id { get; set; }
public string Attr60Name { get; set; }
public string Attr60Description { get; set; }
public DateTime Attr60CreatedAt { get; set; }
public DateTime? Attr60UpdatedAt { get; set; }
public string Attr60CreatedBy { get; set; }
public bool IsAttr60Active { get; set; }
public int Attr60SortOrder { get; set; }


public int Attr90Id { get; set; }
public string Attr90Name { get; set; }
public string Attr90Description { get; set; }
public DateTime Attr90CreatedAt { get; set; }
public DateTime? Attr90UpdatedAt { get; set; }
public string Attr90CreatedBy { get; set; }
public bool IsAttr90Active { get; set; }
public int Attr90SortOrder { get; set; }


public int Config41Id { get; set; }
public string Config41Name { get; set; }
public string Config41Description { get; set; }
public DateTime Config41CreatedAt { get; set; }
public DateTime? Config41UpdatedAt { get; set; }
public string Config41CreatedBy { get; set; }
public bool IsConfig41Active { get; set; }
public int Config41SortOrder { get; set; }


public int Record92Id { get; set; }
public string Record92Name { get; set; }
public string Record92Description { get; set; }
public DateTime Record92CreatedAt { get; set; }
public DateTime? Record92UpdatedAt { get; set; }
public string Record92CreatedBy { get; set; }
public bool IsRecord92Active { get; set; }
public int Record92SortOrder { get; set; }


public int Param93Id { get; set; }
public string Param93Name { get; set; }
public string Param93Description { get; set; }
public DateTime Param93CreatedAt { get; set; }
public DateTime? Param93UpdatedAt { get; set; }
public string Param93CreatedBy { get; set; }
public bool IsParam93Active { get; set; }
public int Param93SortOrder { get; set; }


public int Field35Id { get; set; }
public string Field35Name { get; set; }
public string Field35Description { get; set; }
public DateTime Field35CreatedAt { get; set; }
public DateTime? Field35UpdatedAt { get; set; }
public string Field35CreatedBy { get; set; }
public bool IsField35Active { get; set; }
public int Field35SortOrder { get; set; }


public int Attr10Id { get; set; }
public string Attr10Name { get; set; }
public string Attr10Description { get; set; }
public DateTime Attr10CreatedAt { get; set; }
public DateTime? Attr10UpdatedAt { get; set; }
public string Attr10CreatedBy { get; set; }
public bool IsAttr10Active { get; set; }
public int Attr10SortOrder { get; set; }


public int Item51Id { get; set; }
public string Item51Name { get; set; }
public string Item51Description { get; set; }
public DateTime Item51CreatedAt { get; set; }
public DateTime? Item51UpdatedAt { get; set; }
public string Item51CreatedBy { get; set; }
public bool IsItem51Active { get; set; }
public int Item51SortOrder { get; set; }


public int Attr35Id { get; set; }
public string Attr35Name { get; set; }
public string Attr35Description { get; set; }
public DateTime Attr35CreatedAt { get; set; }
public DateTime? Attr35UpdatedAt { get; set; }
public string Attr35CreatedBy { get; set; }
public bool IsAttr35Active { get; set; }
public int Attr35SortOrder { get; set; }


public int Attr53Id { get; set; }
public string Attr53Name { get; set; }
public string Attr53Description { get; set; }
public DateTime Attr53CreatedAt { get; set; }
public DateTime? Attr53UpdatedAt { get; set; }
public string Attr53CreatedBy { get; set; }
public bool IsAttr53Active { get; set; }
public int Attr53SortOrder { get; set; }


public int Attr78Id { get; set; }
public string Attr78Name { get; set; }
public string Attr78Description { get; set; }
public DateTime Attr78CreatedAt { get; set; }
public DateTime? Attr78UpdatedAt { get; set; }
public string Attr78CreatedBy { get; set; }
public bool IsAttr78Active { get; set; }
public int Attr78SortOrder { get; set; }


public int Config63Id { get; set; }
public string Config63Name { get; set; }
public string Config63Description { get; set; }
public DateTime Config63CreatedAt { get; set; }
public DateTime? Config63UpdatedAt { get; set; }
public string Config63CreatedBy { get; set; }
public bool IsConfig63Active { get; set; }
public int Config63SortOrder { get; set; }


public int Param52Id { get; set; }
public string Param52Name { get; set; }
public string Param52Description { get; set; }
public DateTime Param52CreatedAt { get; set; }
public DateTime? Param52UpdatedAt { get; set; }
public string Param52CreatedBy { get; set; }
public bool IsParam52Active { get; set; }
public int Param52SortOrder { get; set; }

    }
}