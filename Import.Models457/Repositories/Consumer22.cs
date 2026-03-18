using Admin.Handlers450;
using Admin.Validators;
using Auth.Contracts402;
using BatchJobs.Service;
using Billing.Contracts;
using Billing.Validators;
using DataAccess.Core;
using Documents.Api129;
using Documents.Web;
using Export.Service205;
using Export.Tests62;
using Imaging.Models;
using Import.Models;
using Portal.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Mappers197;
using Utilities.Validators;
using Workflow.Data;

namespace Import.Models457
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer22
    {
        private readonly IAdmin_Validators_Validator1 _iAdmin_Validators_Validator1;
        private readonly IAdmin_Validators_Provider9 _iAdmin_Validators_Provider9;
        private readonly Admin_Handlers450_Result3 _admin_Handlers450_Result3;
        private readonly Admin_Handlers450_Controller4 _admin_Handlers450_Controller4;
        private readonly Billing_Contracts_Service4 _billing_Contracts_Service4;
        private readonly Documents_Api129_Provider11 _documents_Api129_Provider11;
        private readonly Documents_Api129_Provider3 _documents_Api129_Provider3;
        private readonly Export_Tests62_Factory9 _export_Tests62_Factory9;

        public Consumer22(IAdmin_Validators_Validator1 iAdmin_Validators_Validator1, IAdmin_Validators_Provider9 iAdmin_Validators_Provider9, Admin_Handlers450_Result3 admin_Handlers450_Result3, Admin_Handlers450_Controller4 admin_Handlers450_Controller4, Billing_Contracts_Service4 billing_Contracts_Service4, Documents_Api129_Provider11 documents_Api129_Provider11, Documents_Api129_Provider3 documents_Api129_Provider3, Export_Tests62_Factory9 export_Tests62_Factory9)
        {
            _iAdmin_Validators_Validator1 = iAdmin_Validators_Validator1 ?? throw new ArgumentNullException(nameof(iAdmin_Validators_Validator1));
            _iAdmin_Validators_Provider9 = iAdmin_Validators_Provider9 ?? throw new ArgumentNullException(nameof(iAdmin_Validators_Provider9));
            _admin_Handlers450_Result3 = admin_Handlers450_Result3 ?? throw new ArgumentNullException(nameof(admin_Handlers450_Result3));
            _admin_Handlers450_Controller4 = admin_Handlers450_Controller4 ?? throw new ArgumentNullException(nameof(admin_Handlers450_Controller4));
            _billing_Contracts_Service4 = billing_Contracts_Service4 ?? throw new ArgumentNullException(nameof(billing_Contracts_Service4));
            _documents_Api129_Provider11 = documents_Api129_Provider11 ?? throw new ArgumentNullException(nameof(documents_Api129_Provider11));
            _documents_Api129_Provider3 = documents_Api129_Provider3 ?? throw new ArgumentNullException(nameof(documents_Api129_Provider3));
            _export_Tests62_Factory9 = export_Tests62_Factory9 ?? throw new ArgumentNullException(nameof(export_Tests62_Factory9));
        }

        public IAdmin_Validators_Validator1 GetIAdmin_Validators_Validator1() => _iAdmin_Validators_Validator1;
        public IAdmin_Validators_Provider9 GetIAdmin_Validators_Provider9() => _iAdmin_Validators_Provider9;
        public Admin_Handlers450_Result3 GetAdmin_Handlers450_Result3() => _admin_Handlers450_Result3;
        public Admin_Handlers450_Controller4 GetAdmin_Handlers450_Controller4() => _admin_Handlers450_Controller4;
        public Billing_Contracts_Service4 GetBilling_Contracts_Service4() => _billing_Contracts_Service4;
        public Documents_Api129_Provider11 GetDocuments_Api129_Provider11() => _documents_Api129_Provider11;
        public Documents_Api129_Provider3 GetDocuments_Api129_Provider3() => _documents_Api129_Provider3;
        public Export_Tests62_Factory9 GetExport_Tests62_Factory9() => _export_Tests62_Factory9;

/// <summary>
/// Validates the Consumer22 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer22(Consumer22Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer22));
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
/// Processes the Consumer22 operation asynchronously.
/// </summary>
public async Task<Consumer22Result> ProcessConsumer22Async(
    Consumer22Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer22), request.Id);

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
            return new Consumer22Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer22));
        return new Consumer22Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer22));
        return new Consumer22Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer22 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer22Dto>> GetConsumer22ListAsync(
    Consumer22Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer22Entity>().AsQueryable();

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
        .Select(x => new Consumer22Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer22Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer22Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer22Service(
    ILogger<Consumer22Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer22:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer22 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer22Data> GetCachedConsumer22Async(string key)
{
    var cacheKey = $"Consumer22_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer22Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer22SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Param79Id { get; set; }
public string Param79Name { get; set; }
public string Param79Description { get; set; }
public DateTime Param79CreatedAt { get; set; }
public DateTime? Param79UpdatedAt { get; set; }
public string Param79CreatedBy { get; set; }
public bool IsParam79Active { get; set; }
public int Param79SortOrder { get; set; }


public int Record13Id { get; set; }
public string Record13Name { get; set; }
public string Record13Description { get; set; }
public DateTime Record13CreatedAt { get; set; }
public DateTime? Record13UpdatedAt { get; set; }
public string Record13CreatedBy { get; set; }
public bool IsRecord13Active { get; set; }
public int Record13SortOrder { get; set; }


public int Record94Id { get; set; }
public string Record94Name { get; set; }
public string Record94Description { get; set; }
public DateTime Record94CreatedAt { get; set; }
public DateTime? Record94UpdatedAt { get; set; }
public string Record94CreatedBy { get; set; }
public bool IsRecord94Active { get; set; }
public int Record94SortOrder { get; set; }


public int Config79Id { get; set; }
public string Config79Name { get; set; }
public string Config79Description { get; set; }
public DateTime Config79CreatedAt { get; set; }
public DateTime? Config79UpdatedAt { get; set; }
public string Config79CreatedBy { get; set; }
public bool IsConfig79Active { get; set; }
public int Config79SortOrder { get; set; }


public int Attr8Id { get; set; }
public string Attr8Name { get; set; }
public string Attr8Description { get; set; }
public DateTime Attr8CreatedAt { get; set; }
public DateTime? Attr8UpdatedAt { get; set; }
public string Attr8CreatedBy { get; set; }
public bool IsAttr8Active { get; set; }
public int Attr8SortOrder { get; set; }


public int Entry7Id { get; set; }
public string Entry7Name { get; set; }
public string Entry7Description { get; set; }
public DateTime Entry7CreatedAt { get; set; }
public DateTime? Entry7UpdatedAt { get; set; }
public string Entry7CreatedBy { get; set; }
public bool IsEntry7Active { get; set; }
public int Entry7SortOrder { get; set; }


public int Detail17Id { get; set; }
public string Detail17Name { get; set; }
public string Detail17Description { get; set; }
public DateTime Detail17CreatedAt { get; set; }
public DateTime? Detail17UpdatedAt { get; set; }
public string Detail17CreatedBy { get; set; }
public bool IsDetail17Active { get; set; }
public int Detail17SortOrder { get; set; }


public int Config26Id { get; set; }
public string Config26Name { get; set; }
public string Config26Description { get; set; }
public DateTime Config26CreatedAt { get; set; }
public DateTime? Config26UpdatedAt { get; set; }
public string Config26CreatedBy { get; set; }
public bool IsConfig26Active { get; set; }
public int Config26SortOrder { get; set; }


public int Entry16Id { get; set; }
public string Entry16Name { get; set; }
public string Entry16Description { get; set; }
public DateTime Entry16CreatedAt { get; set; }
public DateTime? Entry16UpdatedAt { get; set; }
public string Entry16CreatedBy { get; set; }
public bool IsEntry16Active { get; set; }
public int Entry16SortOrder { get; set; }


public int Config31Id { get; set; }
public string Config31Name { get; set; }
public string Config31Description { get; set; }
public DateTime Config31CreatedAt { get; set; }
public DateTime? Config31UpdatedAt { get; set; }
public string Config31CreatedBy { get; set; }
public bool IsConfig31Active { get; set; }
public int Config31SortOrder { get; set; }


public int Config6Id { get; set; }
public string Config6Name { get; set; }
public string Config6Description { get; set; }
public DateTime Config6CreatedAt { get; set; }
public DateTime? Config6UpdatedAt { get; set; }
public string Config6CreatedBy { get; set; }
public bool IsConfig6Active { get; set; }
public int Config6SortOrder { get; set; }


public int Item67Id { get; set; }
public string Item67Name { get; set; }
public string Item67Description { get; set; }
public DateTime Item67CreatedAt { get; set; }
public DateTime? Item67UpdatedAt { get; set; }
public string Item67CreatedBy { get; set; }
public bool IsItem67Active { get; set; }
public int Item67SortOrder { get; set; }


public int Record62Id { get; set; }
public string Record62Name { get; set; }
public string Record62Description { get; set; }
public DateTime Record62CreatedAt { get; set; }
public DateTime? Record62UpdatedAt { get; set; }
public string Record62CreatedBy { get; set; }
public bool IsRecord62Active { get; set; }
public int Record62SortOrder { get; set; }


public int Record66Id { get; set; }
public string Record66Name { get; set; }
public string Record66Description { get; set; }
public DateTime Record66CreatedAt { get; set; }
public DateTime? Record66UpdatedAt { get; set; }
public string Record66CreatedBy { get; set; }
public bool IsRecord66Active { get; set; }
public int Record66SortOrder { get; set; }


public int Param27Id { get; set; }
public string Param27Name { get; set; }
public string Param27Description { get; set; }
public DateTime Param27CreatedAt { get; set; }
public DateTime? Param27UpdatedAt { get; set; }
public string Param27CreatedBy { get; set; }
public bool IsParam27Active { get; set; }
public int Param27SortOrder { get; set; }


public int Param85Id { get; set; }
public string Param85Name { get; set; }
public string Param85Description { get; set; }
public DateTime Param85CreatedAt { get; set; }
public DateTime? Param85UpdatedAt { get; set; }
public string Param85CreatedBy { get; set; }
public bool IsParam85Active { get; set; }
public int Param85SortOrder { get; set; }


public int Param51Id { get; set; }
public string Param51Name { get; set; }
public string Param51Description { get; set; }
public DateTime Param51CreatedAt { get; set; }
public DateTime? Param51UpdatedAt { get; set; }
public string Param51CreatedBy { get; set; }
public bool IsParam51Active { get; set; }
public int Param51SortOrder { get; set; }


public int Config52Id { get; set; }
public string Config52Name { get; set; }
public string Config52Description { get; set; }
public DateTime Config52CreatedAt { get; set; }
public DateTime? Config52UpdatedAt { get; set; }
public string Config52CreatedBy { get; set; }
public bool IsConfig52Active { get; set; }
public int Config52SortOrder { get; set; }


public int Field30Id { get; set; }
public string Field30Name { get; set; }
public string Field30Description { get; set; }
public DateTime Field30CreatedAt { get; set; }
public DateTime? Field30UpdatedAt { get; set; }
public string Field30CreatedBy { get; set; }
public bool IsField30Active { get; set; }
public int Field30SortOrder { get; set; }


public int Config11Id { get; set; }
public string Config11Name { get; set; }
public string Config11Description { get; set; }
public DateTime Config11CreatedAt { get; set; }
public DateTime? Config11UpdatedAt { get; set; }
public string Config11CreatedBy { get; set; }
public bool IsConfig11Active { get; set; }
public int Config11SortOrder { get; set; }


public int Entry15Id { get; set; }
public string Entry15Name { get; set; }
public string Entry15Description { get; set; }
public DateTime Entry15CreatedAt { get; set; }
public DateTime? Entry15UpdatedAt { get; set; }
public string Entry15CreatedBy { get; set; }
public bool IsEntry15Active { get; set; }
public int Entry15SortOrder { get; set; }


public int Entry89Id { get; set; }
public string Entry89Name { get; set; }
public string Entry89Description { get; set; }
public DateTime Entry89CreatedAt { get; set; }
public DateTime? Entry89UpdatedAt { get; set; }
public string Entry89CreatedBy { get; set; }
public bool IsEntry89Active { get; set; }
public int Entry89SortOrder { get; set; }


public int Record85Id { get; set; }
public string Record85Name { get; set; }
public string Record85Description { get; set; }
public DateTime Record85CreatedAt { get; set; }
public DateTime? Record85UpdatedAt { get; set; }
public string Record85CreatedBy { get; set; }
public bool IsRecord85Active { get; set; }
public int Record85SortOrder { get; set; }


public int Record69Id { get; set; }
public string Record69Name { get; set; }
public string Record69Description { get; set; }
public DateTime Record69CreatedAt { get; set; }
public DateTime? Record69UpdatedAt { get; set; }
public string Record69CreatedBy { get; set; }
public bool IsRecord69Active { get; set; }
public int Record69SortOrder { get; set; }


public int Config12Id { get; set; }
public string Config12Name { get; set; }
public string Config12Description { get; set; }
public DateTime Config12CreatedAt { get; set; }
public DateTime? Config12UpdatedAt { get; set; }
public string Config12CreatedBy { get; set; }
public bool IsConfig12Active { get; set; }
public int Config12SortOrder { get; set; }


public int Param39Id { get; set; }
public string Param39Name { get; set; }
public string Param39Description { get; set; }
public DateTime Param39CreatedAt { get; set; }
public DateTime? Param39UpdatedAt { get; set; }
public string Param39CreatedBy { get; set; }
public bool IsParam39Active { get; set; }
public int Param39SortOrder { get; set; }


public int Param15Id { get; set; }
public string Param15Name { get; set; }
public string Param15Description { get; set; }
public DateTime Param15CreatedAt { get; set; }
public DateTime? Param15UpdatedAt { get; set; }
public string Param15CreatedBy { get; set; }
public bool IsParam15Active { get; set; }
public int Param15SortOrder { get; set; }


public int Config76Id { get; set; }
public string Config76Name { get; set; }
public string Config76Description { get; set; }
public DateTime Config76CreatedAt { get; set; }
public DateTime? Config76UpdatedAt { get; set; }
public string Config76CreatedBy { get; set; }
public bool IsConfig76Active { get; set; }
public int Config76SortOrder { get; set; }


public int Item83Id { get; set; }
public string Item83Name { get; set; }
public string Item83Description { get; set; }
public DateTime Item83CreatedAt { get; set; }
public DateTime? Item83UpdatedAt { get; set; }
public string Item83CreatedBy { get; set; }
public bool IsItem83Active { get; set; }
public int Item83SortOrder { get; set; }


public int Entry50Id { get; set; }
public string Entry50Name { get; set; }
public string Entry50Description { get; set; }
public DateTime Entry50CreatedAt { get; set; }
public DateTime? Entry50UpdatedAt { get; set; }
public string Entry50CreatedBy { get; set; }
public bool IsEntry50Active { get; set; }
public int Entry50SortOrder { get; set; }


public int Field67Id { get; set; }
public string Field67Name { get; set; }
public string Field67Description { get; set; }
public DateTime Field67CreatedAt { get; set; }
public DateTime? Field67UpdatedAt { get; set; }
public string Field67CreatedBy { get; set; }
public bool IsField67Active { get; set; }
public int Field67SortOrder { get; set; }


public int Param79Id { get; set; }
public string Param79Name { get; set; }
public string Param79Description { get; set; }
public DateTime Param79CreatedAt { get; set; }
public DateTime? Param79UpdatedAt { get; set; }
public string Param79CreatedBy { get; set; }
public bool IsParam79Active { get; set; }
public int Param79SortOrder { get; set; }


public int Field28Id { get; set; }
public string Field28Name { get; set; }
public string Field28Description { get; set; }
public DateTime Field28CreatedAt { get; set; }
public DateTime? Field28UpdatedAt { get; set; }
public string Field28CreatedBy { get; set; }
public bool IsField28Active { get; set; }
public int Field28SortOrder { get; set; }


public int Record37Id { get; set; }
public string Record37Name { get; set; }
public string Record37Description { get; set; }
public DateTime Record37CreatedAt { get; set; }
public DateTime? Record37UpdatedAt { get; set; }
public string Record37CreatedBy { get; set; }
public bool IsRecord37Active { get; set; }
public int Record37SortOrder { get; set; }


public int Attr76Id { get; set; }
public string Attr76Name { get; set; }
public string Attr76Description { get; set; }
public DateTime Attr76CreatedAt { get; set; }
public DateTime? Attr76UpdatedAt { get; set; }
public string Attr76CreatedBy { get; set; }
public bool IsAttr76Active { get; set; }
public int Attr76SortOrder { get; set; }


public int Item22Id { get; set; }
public string Item22Name { get; set; }
public string Item22Description { get; set; }
public DateTime Item22CreatedAt { get; set; }
public DateTime? Item22UpdatedAt { get; set; }
public string Item22CreatedBy { get; set; }
public bool IsItem22Active { get; set; }
public int Item22SortOrder { get; set; }


public int Config55Id { get; set; }
public string Config55Name { get; set; }
public string Config55Description { get; set; }
public DateTime Config55CreatedAt { get; set; }
public DateTime? Config55UpdatedAt { get; set; }
public string Config55CreatedBy { get; set; }
public bool IsConfig55Active { get; set; }
public int Config55SortOrder { get; set; }


public int Detail2Id { get; set; }
public string Detail2Name { get; set; }
public string Detail2Description { get; set; }
public DateTime Detail2CreatedAt { get; set; }
public DateTime? Detail2UpdatedAt { get; set; }
public string Detail2CreatedBy { get; set; }
public bool IsDetail2Active { get; set; }
public int Detail2SortOrder { get; set; }


public int Attr7Id { get; set; }
public string Attr7Name { get; set; }
public string Attr7Description { get; set; }
public DateTime Attr7CreatedAt { get; set; }
public DateTime? Attr7UpdatedAt { get; set; }
public string Attr7CreatedBy { get; set; }
public bool IsAttr7Active { get; set; }
public int Attr7SortOrder { get; set; }


public int Record12Id { get; set; }
public string Record12Name { get; set; }
public string Record12Description { get; set; }
public DateTime Record12CreatedAt { get; set; }
public DateTime? Record12UpdatedAt { get; set; }
public string Record12CreatedBy { get; set; }
public bool IsRecord12Active { get; set; }
public int Record12SortOrder { get; set; }


public int Record5Id { get; set; }
public string Record5Name { get; set; }
public string Record5Description { get; set; }
public DateTime Record5CreatedAt { get; set; }
public DateTime? Record5UpdatedAt { get; set; }
public string Record5CreatedBy { get; set; }
public bool IsRecord5Active { get; set; }
public int Record5SortOrder { get; set; }


public int Attr62Id { get; set; }
public string Attr62Name { get; set; }
public string Attr62Description { get; set; }
public DateTime Attr62CreatedAt { get; set; }
public DateTime? Attr62UpdatedAt { get; set; }
public string Attr62CreatedBy { get; set; }
public bool IsAttr62Active { get; set; }
public int Attr62SortOrder { get; set; }


public int Entry41Id { get; set; }
public string Entry41Name { get; set; }
public string Entry41Description { get; set; }
public DateTime Entry41CreatedAt { get; set; }
public DateTime? Entry41UpdatedAt { get; set; }
public string Entry41CreatedBy { get; set; }
public bool IsEntry41Active { get; set; }
public int Entry41SortOrder { get; set; }


public int Attr7Id { get; set; }
public string Attr7Name { get; set; }
public string Attr7Description { get; set; }
public DateTime Attr7CreatedAt { get; set; }
public DateTime? Attr7UpdatedAt { get; set; }
public string Attr7CreatedBy { get; set; }
public bool IsAttr7Active { get; set; }
public int Attr7SortOrder { get; set; }


public int Record27Id { get; set; }
public string Record27Name { get; set; }
public string Record27Description { get; set; }
public DateTime Record27CreatedAt { get; set; }
public DateTime? Record27UpdatedAt { get; set; }
public string Record27CreatedBy { get; set; }
public bool IsRecord27Active { get; set; }
public int Record27SortOrder { get; set; }

    }
}