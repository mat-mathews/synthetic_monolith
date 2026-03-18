using Admin.Validators336;
using Auth.Api143;
using Auth.Data;
using Billing.Validators174;
using Common.Client;
using Common.Client53;
using Common.Models;
using DataAccess.Tests286;
using Export.Contracts;
using GalaxyWorks.Events256;
using Imaging.Contracts89;
using Imaging.Web;
using Import.Processors412;
using Notifications.Tests299;
using Portal.Events151;
using Reporting.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Export.Handlers202
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer5
    {
        private readonly Admin_Validators336_Info _admin_Validators336_Info;
        private readonly IAuth_Data_Validator8 _iAuth_Data_Validator8;
        private readonly Auth_Data_Helper1 _auth_Data_Helper1;
        private readonly Billing_Validators174_Options2 _billing_Validators174_Options2;
        private readonly IBilling_Validators174_Service6 _iBilling_Validators174_Service6;
        private readonly DataAccess_Tests286_Handler5 _dataAccess_Tests286_Handler5;
        private readonly DataAccess_Tests286_Range _dataAccess_Tests286_Range;
        private readonly Notifications_Tests299_Controller1 _notifications_Tests299_Controller1;

        public Consumer5(Admin_Validators336_Info admin_Validators336_Info, IAuth_Data_Validator8 iAuth_Data_Validator8, Auth_Data_Helper1 auth_Data_Helper1, Billing_Validators174_Options2 billing_Validators174_Options2, IBilling_Validators174_Service6 iBilling_Validators174_Service6, DataAccess_Tests286_Handler5 dataAccess_Tests286_Handler5, DataAccess_Tests286_Range dataAccess_Tests286_Range, Notifications_Tests299_Controller1 notifications_Tests299_Controller1)
        {
            _admin_Validators336_Info = admin_Validators336_Info ?? throw new ArgumentNullException(nameof(admin_Validators336_Info));
            _iAuth_Data_Validator8 = iAuth_Data_Validator8 ?? throw new ArgumentNullException(nameof(iAuth_Data_Validator8));
            _auth_Data_Helper1 = auth_Data_Helper1 ?? throw new ArgumentNullException(nameof(auth_Data_Helper1));
            _billing_Validators174_Options2 = billing_Validators174_Options2 ?? throw new ArgumentNullException(nameof(billing_Validators174_Options2));
            _iBilling_Validators174_Service6 = iBilling_Validators174_Service6 ?? throw new ArgumentNullException(nameof(iBilling_Validators174_Service6));
            _dataAccess_Tests286_Handler5 = dataAccess_Tests286_Handler5 ?? throw new ArgumentNullException(nameof(dataAccess_Tests286_Handler5));
            _dataAccess_Tests286_Range = dataAccess_Tests286_Range ?? throw new ArgumentNullException(nameof(dataAccess_Tests286_Range));
            _notifications_Tests299_Controller1 = notifications_Tests299_Controller1 ?? throw new ArgumentNullException(nameof(notifications_Tests299_Controller1));
        }

        public Admin_Validators336_Info GetAdmin_Validators336_Info() => _admin_Validators336_Info;
        public IAuth_Data_Validator8 GetIAuth_Data_Validator8() => _iAuth_Data_Validator8;
        public Auth_Data_Helper1 GetAuth_Data_Helper1() => _auth_Data_Helper1;
        public Billing_Validators174_Options2 GetBilling_Validators174_Options2() => _billing_Validators174_Options2;
        public IBilling_Validators174_Service6 GetIBilling_Validators174_Service6() => _iBilling_Validators174_Service6;
        public DataAccess_Tests286_Handler5 GetDataAccess_Tests286_Handler5() => _dataAccess_Tests286_Handler5;
        public DataAccess_Tests286_Range GetDataAccess_Tests286_Range() => _dataAccess_Tests286_Range;
        public Notifications_Tests299_Controller1 GetNotifications_Tests299_Controller1() => _notifications_Tests299_Controller1;

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

public int Attr7Id { get; set; }
public string Attr7Name { get; set; }
public string Attr7Description { get; set; }
public DateTime Attr7CreatedAt { get; set; }
public DateTime? Attr7UpdatedAt { get; set; }
public string Attr7CreatedBy { get; set; }
public bool IsAttr7Active { get; set; }
public int Attr7SortOrder { get; set; }


public int Attr43Id { get; set; }
public string Attr43Name { get; set; }
public string Attr43Description { get; set; }
public DateTime Attr43CreatedAt { get; set; }
public DateTime? Attr43UpdatedAt { get; set; }
public string Attr43CreatedBy { get; set; }
public bool IsAttr43Active { get; set; }
public int Attr43SortOrder { get; set; }


public int Detail84Id { get; set; }
public string Detail84Name { get; set; }
public string Detail84Description { get; set; }
public DateTime Detail84CreatedAt { get; set; }
public DateTime? Detail84UpdatedAt { get; set; }
public string Detail84CreatedBy { get; set; }
public bool IsDetail84Active { get; set; }
public int Detail84SortOrder { get; set; }


public int Config18Id { get; set; }
public string Config18Name { get; set; }
public string Config18Description { get; set; }
public DateTime Config18CreatedAt { get; set; }
public DateTime? Config18UpdatedAt { get; set; }
public string Config18CreatedBy { get; set; }
public bool IsConfig18Active { get; set; }
public int Config18SortOrder { get; set; }


public int Detail62Id { get; set; }
public string Detail62Name { get; set; }
public string Detail62Description { get; set; }
public DateTime Detail62CreatedAt { get; set; }
public DateTime? Detail62UpdatedAt { get; set; }
public string Detail62CreatedBy { get; set; }
public bool IsDetail62Active { get; set; }
public int Detail62SortOrder { get; set; }


public int Field25Id { get; set; }
public string Field25Name { get; set; }
public string Field25Description { get; set; }
public DateTime Field25CreatedAt { get; set; }
public DateTime? Field25UpdatedAt { get; set; }
public string Field25CreatedBy { get; set; }
public bool IsField25Active { get; set; }
public int Field25SortOrder { get; set; }


public int Detail9Id { get; set; }
public string Detail9Name { get; set; }
public string Detail9Description { get; set; }
public DateTime Detail9CreatedAt { get; set; }
public DateTime? Detail9UpdatedAt { get; set; }
public string Detail9CreatedBy { get; set; }
public bool IsDetail9Active { get; set; }
public int Detail9SortOrder { get; set; }


public int Item92Id { get; set; }
public string Item92Name { get; set; }
public string Item92Description { get; set; }
public DateTime Item92CreatedAt { get; set; }
public DateTime? Item92UpdatedAt { get; set; }
public string Item92CreatedBy { get; set; }
public bool IsItem92Active { get; set; }
public int Item92SortOrder { get; set; }


public int Item82Id { get; set; }
public string Item82Name { get; set; }
public string Item82Description { get; set; }
public DateTime Item82CreatedAt { get; set; }
public DateTime? Item82UpdatedAt { get; set; }
public string Item82CreatedBy { get; set; }
public bool IsItem82Active { get; set; }
public int Item82SortOrder { get; set; }


public int Field46Id { get; set; }
public string Field46Name { get; set; }
public string Field46Description { get; set; }
public DateTime Field46CreatedAt { get; set; }
public DateTime? Field46UpdatedAt { get; set; }
public string Field46CreatedBy { get; set; }
public bool IsField46Active { get; set; }
public int Field46SortOrder { get; set; }


public int Field33Id { get; set; }
public string Field33Name { get; set; }
public string Field33Description { get; set; }
public DateTime Field33CreatedAt { get; set; }
public DateTime? Field33UpdatedAt { get; set; }
public string Field33CreatedBy { get; set; }
public bool IsField33Active { get; set; }
public int Field33SortOrder { get; set; }


public int Item89Id { get; set; }
public string Item89Name { get; set; }
public string Item89Description { get; set; }
public DateTime Item89CreatedAt { get; set; }
public DateTime? Item89UpdatedAt { get; set; }
public string Item89CreatedBy { get; set; }
public bool IsItem89Active { get; set; }
public int Item89SortOrder { get; set; }


public int Entry69Id { get; set; }
public string Entry69Name { get; set; }
public string Entry69Description { get; set; }
public DateTime Entry69CreatedAt { get; set; }
public DateTime? Entry69UpdatedAt { get; set; }
public string Entry69CreatedBy { get; set; }
public bool IsEntry69Active { get; set; }
public int Entry69SortOrder { get; set; }


public int Detail53Id { get; set; }
public string Detail53Name { get; set; }
public string Detail53Description { get; set; }
public DateTime Detail53CreatedAt { get; set; }
public DateTime? Detail53UpdatedAt { get; set; }
public string Detail53CreatedBy { get; set; }
public bool IsDetail53Active { get; set; }
public int Detail53SortOrder { get; set; }


public int Param47Id { get; set; }
public string Param47Name { get; set; }
public string Param47Description { get; set; }
public DateTime Param47CreatedAt { get; set; }
public DateTime? Param47UpdatedAt { get; set; }
public string Param47CreatedBy { get; set; }
public bool IsParam47Active { get; set; }
public int Param47SortOrder { get; set; }


public int Item43Id { get; set; }
public string Item43Name { get; set; }
public string Item43Description { get; set; }
public DateTime Item43CreatedAt { get; set; }
public DateTime? Item43UpdatedAt { get; set; }
public string Item43CreatedBy { get; set; }
public bool IsItem43Active { get; set; }
public int Item43SortOrder { get; set; }


public int Param89Id { get; set; }
public string Param89Name { get; set; }
public string Param89Description { get; set; }
public DateTime Param89CreatedAt { get; set; }
public DateTime? Param89UpdatedAt { get; set; }
public string Param89CreatedBy { get; set; }
public bool IsParam89Active { get; set; }
public int Param89SortOrder { get; set; }


public int Detail24Id { get; set; }
public string Detail24Name { get; set; }
public string Detail24Description { get; set; }
public DateTime Detail24CreatedAt { get; set; }
public DateTime? Detail24UpdatedAt { get; set; }
public string Detail24CreatedBy { get; set; }
public bool IsDetail24Active { get; set; }
public int Detail24SortOrder { get; set; }


public int Config4Id { get; set; }
public string Config4Name { get; set; }
public string Config4Description { get; set; }
public DateTime Config4CreatedAt { get; set; }
public DateTime? Config4UpdatedAt { get; set; }
public string Config4CreatedBy { get; set; }
public bool IsConfig4Active { get; set; }
public int Config4SortOrder { get; set; }


public int Record21Id { get; set; }
public string Record21Name { get; set; }
public string Record21Description { get; set; }
public DateTime Record21CreatedAt { get; set; }
public DateTime? Record21UpdatedAt { get; set; }
public string Record21CreatedBy { get; set; }
public bool IsRecord21Active { get; set; }
public int Record21SortOrder { get; set; }


public int Record93Id { get; set; }
public string Record93Name { get; set; }
public string Record93Description { get; set; }
public DateTime Record93CreatedAt { get; set; }
public DateTime? Record93UpdatedAt { get; set; }
public string Record93CreatedBy { get; set; }
public bool IsRecord93Active { get; set; }
public int Record93SortOrder { get; set; }


public int Field3Id { get; set; }
public string Field3Name { get; set; }
public string Field3Description { get; set; }
public DateTime Field3CreatedAt { get; set; }
public DateTime? Field3UpdatedAt { get; set; }
public string Field3CreatedBy { get; set; }
public bool IsField3Active { get; set; }
public int Field3SortOrder { get; set; }


public int Param50Id { get; set; }
public string Param50Name { get; set; }
public string Param50Description { get; set; }
public DateTime Param50CreatedAt { get; set; }
public DateTime? Param50UpdatedAt { get; set; }
public string Param50CreatedBy { get; set; }
public bool IsParam50Active { get; set; }
public int Param50SortOrder { get; set; }


public int Item10Id { get; set; }
public string Item10Name { get; set; }
public string Item10Description { get; set; }
public DateTime Item10CreatedAt { get; set; }
public DateTime? Item10UpdatedAt { get; set; }
public string Item10CreatedBy { get; set; }
public bool IsItem10Active { get; set; }
public int Item10SortOrder { get; set; }


public int Config9Id { get; set; }
public string Config9Name { get; set; }
public string Config9Description { get; set; }
public DateTime Config9CreatedAt { get; set; }
public DateTime? Config9UpdatedAt { get; set; }
public string Config9CreatedBy { get; set; }
public bool IsConfig9Active { get; set; }
public int Config9SortOrder { get; set; }


public int Field69Id { get; set; }
public string Field69Name { get; set; }
public string Field69Description { get; set; }
public DateTime Field69CreatedAt { get; set; }
public DateTime? Field69UpdatedAt { get; set; }
public string Field69CreatedBy { get; set; }
public bool IsField69Active { get; set; }
public int Field69SortOrder { get; set; }


public int Field34Id { get; set; }
public string Field34Name { get; set; }
public string Field34Description { get; set; }
public DateTime Field34CreatedAt { get; set; }
public DateTime? Field34UpdatedAt { get; set; }
public string Field34CreatedBy { get; set; }
public bool IsField34Active { get; set; }
public int Field34SortOrder { get; set; }


public int Attr18Id { get; set; }
public string Attr18Name { get; set; }
public string Attr18Description { get; set; }
public DateTime Attr18CreatedAt { get; set; }
public DateTime? Attr18UpdatedAt { get; set; }
public string Attr18CreatedBy { get; set; }
public bool IsAttr18Active { get; set; }
public int Attr18SortOrder { get; set; }


public int Field95Id { get; set; }
public string Field95Name { get; set; }
public string Field95Description { get; set; }
public DateTime Field95CreatedAt { get; set; }
public DateTime? Field95UpdatedAt { get; set; }
public string Field95CreatedBy { get; set; }
public bool IsField95Active { get; set; }
public int Field95SortOrder { get; set; }


public int Attr86Id { get; set; }
public string Attr86Name { get; set; }
public string Attr86Description { get; set; }
public DateTime Attr86CreatedAt { get; set; }
public DateTime? Attr86UpdatedAt { get; set; }
public string Attr86CreatedBy { get; set; }
public bool IsAttr86Active { get; set; }
public int Attr86SortOrder { get; set; }


public int Item50Id { get; set; }
public string Item50Name { get; set; }
public string Item50Description { get; set; }
public DateTime Item50CreatedAt { get; set; }
public DateTime? Item50UpdatedAt { get; set; }
public string Item50CreatedBy { get; set; }
public bool IsItem50Active { get; set; }
public int Item50SortOrder { get; set; }


public int Item35Id { get; set; }
public string Item35Name { get; set; }
public string Item35Description { get; set; }
public DateTime Item35CreatedAt { get; set; }
public DateTime? Item35UpdatedAt { get; set; }
public string Item35CreatedBy { get; set; }
public bool IsItem35Active { get; set; }
public int Item35SortOrder { get; set; }


public int Item73Id { get; set; }
public string Item73Name { get; set; }
public string Item73Description { get; set; }
public DateTime Item73CreatedAt { get; set; }
public DateTime? Item73UpdatedAt { get; set; }
public string Item73CreatedBy { get; set; }
public bool IsItem73Active { get; set; }
public int Item73SortOrder { get; set; }


public int Item3Id { get; set; }
public string Item3Name { get; set; }
public string Item3Description { get; set; }
public DateTime Item3CreatedAt { get; set; }
public DateTime? Item3UpdatedAt { get; set; }
public string Item3CreatedBy { get; set; }
public bool IsItem3Active { get; set; }
public int Item3SortOrder { get; set; }


public int Item18Id { get; set; }
public string Item18Name { get; set; }
public string Item18Description { get; set; }
public DateTime Item18CreatedAt { get; set; }
public DateTime? Item18UpdatedAt { get; set; }
public string Item18CreatedBy { get; set; }
public bool IsItem18Active { get; set; }
public int Item18SortOrder { get; set; }


public int Record40Id { get; set; }
public string Record40Name { get; set; }
public string Record40Description { get; set; }
public DateTime Record40CreatedAt { get; set; }
public DateTime? Record40UpdatedAt { get; set; }
public string Record40CreatedBy { get; set; }
public bool IsRecord40Active { get; set; }
public int Record40SortOrder { get; set; }


public int Attr8Id { get; set; }
public string Attr8Name { get; set; }
public string Attr8Description { get; set; }
public DateTime Attr8CreatedAt { get; set; }
public DateTime? Attr8UpdatedAt { get; set; }
public string Attr8CreatedBy { get; set; }
public bool IsAttr8Active { get; set; }
public int Attr8SortOrder { get; set; }


public int Record70Id { get; set; }
public string Record70Name { get; set; }
public string Record70Description { get; set; }
public DateTime Record70CreatedAt { get; set; }
public DateTime? Record70UpdatedAt { get; set; }
public string Record70CreatedBy { get; set; }
public bool IsRecord70Active { get; set; }
public int Record70SortOrder { get; set; }


public int Item20Id { get; set; }
public string Item20Name { get; set; }
public string Item20Description { get; set; }
public DateTime Item20CreatedAt { get; set; }
public DateTime? Item20UpdatedAt { get; set; }
public string Item20CreatedBy { get; set; }
public bool IsItem20Active { get; set; }
public int Item20SortOrder { get; set; }


public int Param18Id { get; set; }
public string Param18Name { get; set; }
public string Param18Description { get; set; }
public DateTime Param18CreatedAt { get; set; }
public DateTime? Param18UpdatedAt { get; set; }
public string Param18CreatedBy { get; set; }
public bool IsParam18Active { get; set; }
public int Param18SortOrder { get; set; }


public int Field34Id { get; set; }
public string Field34Name { get; set; }
public string Field34Description { get; set; }
public DateTime Field34CreatedAt { get; set; }
public DateTime? Field34UpdatedAt { get; set; }
public string Field34CreatedBy { get; set; }
public bool IsField34Active { get; set; }
public int Field34SortOrder { get; set; }


public int Entry73Id { get; set; }
public string Entry73Name { get; set; }
public string Entry73Description { get; set; }
public DateTime Entry73CreatedAt { get; set; }
public DateTime? Entry73UpdatedAt { get; set; }
public string Entry73CreatedBy { get; set; }
public bool IsEntry73Active { get; set; }
public int Entry73SortOrder { get; set; }


public int Record38Id { get; set; }
public string Record38Name { get; set; }
public string Record38Description { get; set; }
public DateTime Record38CreatedAt { get; set; }
public DateTime? Record38UpdatedAt { get; set; }
public string Record38CreatedBy { get; set; }
public bool IsRecord38Active { get; set; }
public int Record38SortOrder { get; set; }


public int Record90Id { get; set; }
public string Record90Name { get; set; }
public string Record90Description { get; set; }
public DateTime Record90CreatedAt { get; set; }
public DateTime? Record90UpdatedAt { get; set; }
public string Record90CreatedBy { get; set; }
public bool IsRecord90Active { get; set; }
public int Record90SortOrder { get; set; }


public int Detail46Id { get; set; }
public string Detail46Name { get; set; }
public string Detail46Description { get; set; }
public DateTime Detail46CreatedAt { get; set; }
public DateTime? Detail46UpdatedAt { get; set; }
public string Detail46CreatedBy { get; set; }
public bool IsDetail46Active { get; set; }
public int Detail46SortOrder { get; set; }


public int Detail4Id { get; set; }
public string Detail4Name { get; set; }
public string Detail4Description { get; set; }
public DateTime Detail4CreatedAt { get; set; }
public DateTime? Detail4UpdatedAt { get; set; }
public string Detail4CreatedBy { get; set; }
public bool IsDetail4Active { get; set; }
public int Detail4SortOrder { get; set; }

    }
}