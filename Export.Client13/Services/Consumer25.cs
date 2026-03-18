using Admin.Core121;
using Admin.Handlers447;
using Admin.Web4;
using Auth.Client271;
using Auth.Mappers208;
using Common.Models;
using DataAccess.Contracts;
using DataAccess.Shared486;
using GalaxyWorks.Client;
using GalaxyWorks.Service293;
using Imaging.Data;
using Imaging.Events416;
using Imaging.Service;
using Integration.Validators;
using Reporting.Events;
using Security.Shared;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Data415;

namespace Export.Client13
{
    /// <summary>
    /// Consumes services from referenced projects.
    /// Auto-generated for benchmark testing.
    /// </summary>
    public class Consumer25
    {
        private readonly IAdmin_Web4_Validator4 _iAdmin_Web4_Validator4;
        private readonly Admin_Web4_Provider1 _admin_Web4_Provider1;
        private readonly Admin_Web4_Controller5 _admin_Web4_Controller5;
        private readonly Admin_Handlers447_Manager2 _admin_Handlers447_Manager2;
        private readonly Admin_Handlers447_Repository3 _admin_Handlers447_Repository3;
        private readonly Admin_Handlers447_Command4 _admin_Handlers447_Command4;
        private readonly Auth_Mappers208_Point7 _auth_Mappers208_Point7;
        private readonly Auth_Mappers208_Range1 _auth_Mappers208_Range1;

        public Consumer25(IAdmin_Web4_Validator4 iAdmin_Web4_Validator4, Admin_Web4_Provider1 admin_Web4_Provider1, Admin_Web4_Controller5 admin_Web4_Controller5, Admin_Handlers447_Manager2 admin_Handlers447_Manager2, Admin_Handlers447_Repository3 admin_Handlers447_Repository3, Admin_Handlers447_Command4 admin_Handlers447_Command4, Auth_Mappers208_Point7 auth_Mappers208_Point7, Auth_Mappers208_Range1 auth_Mappers208_Range1)
        {
            _iAdmin_Web4_Validator4 = iAdmin_Web4_Validator4 ?? throw new ArgumentNullException(nameof(iAdmin_Web4_Validator4));
            _admin_Web4_Provider1 = admin_Web4_Provider1 ?? throw new ArgumentNullException(nameof(admin_Web4_Provider1));
            _admin_Web4_Controller5 = admin_Web4_Controller5 ?? throw new ArgumentNullException(nameof(admin_Web4_Controller5));
            _admin_Handlers447_Manager2 = admin_Handlers447_Manager2 ?? throw new ArgumentNullException(nameof(admin_Handlers447_Manager2));
            _admin_Handlers447_Repository3 = admin_Handlers447_Repository3 ?? throw new ArgumentNullException(nameof(admin_Handlers447_Repository3));
            _admin_Handlers447_Command4 = admin_Handlers447_Command4 ?? throw new ArgumentNullException(nameof(admin_Handlers447_Command4));
            _auth_Mappers208_Point7 = auth_Mappers208_Point7 ?? throw new ArgumentNullException(nameof(auth_Mappers208_Point7));
            _auth_Mappers208_Range1 = auth_Mappers208_Range1 ?? throw new ArgumentNullException(nameof(auth_Mappers208_Range1));
        }

        public IAdmin_Web4_Validator4 GetIAdmin_Web4_Validator4() => _iAdmin_Web4_Validator4;
        public Admin_Web4_Provider1 GetAdmin_Web4_Provider1() => _admin_Web4_Provider1;
        public Admin_Web4_Controller5 GetAdmin_Web4_Controller5() => _admin_Web4_Controller5;
        public Admin_Handlers447_Manager2 GetAdmin_Handlers447_Manager2() => _admin_Handlers447_Manager2;
        public Admin_Handlers447_Repository3 GetAdmin_Handlers447_Repository3() => _admin_Handlers447_Repository3;
        public Admin_Handlers447_Command4 GetAdmin_Handlers447_Command4() => _admin_Handlers447_Command4;
        public Auth_Mappers208_Point7 GetAuth_Mappers208_Point7() => _auth_Mappers208_Point7;
        public Auth_Mappers208_Range1 GetAuth_Mappers208_Range1() => _auth_Mappers208_Range1;

/// <summary>
/// Validates the Consumer25 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateConsumer25(Consumer25Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Consumer25));
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
/// Processes the Consumer25 operation asynchronously.
/// </summary>
public async Task<Consumer25Result> ProcessConsumer25Async(
    Consumer25Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Consumer25), request.Id);

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
            return new Consumer25Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Consumer25));
        return new Consumer25Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Consumer25));
        return new Consumer25Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Consumer25 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Consumer25Dto>> GetConsumer25ListAsync(
    Consumer25Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Consumer25Entity>().AsQueryable();

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
        .Select(x => new Consumer25Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Consumer25Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Consumer25Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Consumer25Service(
    ILogger<Consumer25Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Consumer25:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Consumer25 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Consumer25Data> GetCachedConsumer25Async(string key)
{
    var cacheKey = $"Consumer25_{key}";

    if (_cache.TryGetValue(cacheKey, out Consumer25Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromConsumer25SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Attr22Id { get; set; }
public string Attr22Name { get; set; }
public string Attr22Description { get; set; }
public DateTime Attr22CreatedAt { get; set; }
public DateTime? Attr22UpdatedAt { get; set; }
public string Attr22CreatedBy { get; set; }
public bool IsAttr22Active { get; set; }
public int Attr22SortOrder { get; set; }


public int Item57Id { get; set; }
public string Item57Name { get; set; }
public string Item57Description { get; set; }
public DateTime Item57CreatedAt { get; set; }
public DateTime? Item57UpdatedAt { get; set; }
public string Item57CreatedBy { get; set; }
public bool IsItem57Active { get; set; }
public int Item57SortOrder { get; set; }


public int Record74Id { get; set; }
public string Record74Name { get; set; }
public string Record74Description { get; set; }
public DateTime Record74CreatedAt { get; set; }
public DateTime? Record74UpdatedAt { get; set; }
public string Record74CreatedBy { get; set; }
public bool IsRecord74Active { get; set; }
public int Record74SortOrder { get; set; }


public int Record17Id { get; set; }
public string Record17Name { get; set; }
public string Record17Description { get; set; }
public DateTime Record17CreatedAt { get; set; }
public DateTime? Record17UpdatedAt { get; set; }
public string Record17CreatedBy { get; set; }
public bool IsRecord17Active { get; set; }
public int Record17SortOrder { get; set; }


public int Item77Id { get; set; }
public string Item77Name { get; set; }
public string Item77Description { get; set; }
public DateTime Item77CreatedAt { get; set; }
public DateTime? Item77UpdatedAt { get; set; }
public string Item77CreatedBy { get; set; }
public bool IsItem77Active { get; set; }
public int Item77SortOrder { get; set; }


public int Item35Id { get; set; }
public string Item35Name { get; set; }
public string Item35Description { get; set; }
public DateTime Item35CreatedAt { get; set; }
public DateTime? Item35UpdatedAt { get; set; }
public string Item35CreatedBy { get; set; }
public bool IsItem35Active { get; set; }
public int Item35SortOrder { get; set; }


public int Field3Id { get; set; }
public string Field3Name { get; set; }
public string Field3Description { get; set; }
public DateTime Field3CreatedAt { get; set; }
public DateTime? Field3UpdatedAt { get; set; }
public string Field3CreatedBy { get; set; }
public bool IsField3Active { get; set; }
public int Field3SortOrder { get; set; }


public int Item37Id { get; set; }
public string Item37Name { get; set; }
public string Item37Description { get; set; }
public DateTime Item37CreatedAt { get; set; }
public DateTime? Item37UpdatedAt { get; set; }
public string Item37CreatedBy { get; set; }
public bool IsItem37Active { get; set; }
public int Item37SortOrder { get; set; }


public int Attr66Id { get; set; }
public string Attr66Name { get; set; }
public string Attr66Description { get; set; }
public DateTime Attr66CreatedAt { get; set; }
public DateTime? Attr66UpdatedAt { get; set; }
public string Attr66CreatedBy { get; set; }
public bool IsAttr66Active { get; set; }
public int Attr66SortOrder { get; set; }


public int Detail89Id { get; set; }
public string Detail89Name { get; set; }
public string Detail89Description { get; set; }
public DateTime Detail89CreatedAt { get; set; }
public DateTime? Detail89UpdatedAt { get; set; }
public string Detail89CreatedBy { get; set; }
public bool IsDetail89Active { get; set; }
public int Detail89SortOrder { get; set; }


public int Field35Id { get; set; }
public string Field35Name { get; set; }
public string Field35Description { get; set; }
public DateTime Field35CreatedAt { get; set; }
public DateTime? Field35UpdatedAt { get; set; }
public string Field35CreatedBy { get; set; }
public bool IsField35Active { get; set; }
public int Field35SortOrder { get; set; }


public int Attr27Id { get; set; }
public string Attr27Name { get; set; }
public string Attr27Description { get; set; }
public DateTime Attr27CreatedAt { get; set; }
public DateTime? Attr27UpdatedAt { get; set; }
public string Attr27CreatedBy { get; set; }
public bool IsAttr27Active { get; set; }
public int Attr27SortOrder { get; set; }


public int Item97Id { get; set; }
public string Item97Name { get; set; }
public string Item97Description { get; set; }
public DateTime Item97CreatedAt { get; set; }
public DateTime? Item97UpdatedAt { get; set; }
public string Item97CreatedBy { get; set; }
public bool IsItem97Active { get; set; }
public int Item97SortOrder { get; set; }


public int Param44Id { get; set; }
public string Param44Name { get; set; }
public string Param44Description { get; set; }
public DateTime Param44CreatedAt { get; set; }
public DateTime? Param44UpdatedAt { get; set; }
public string Param44CreatedBy { get; set; }
public bool IsParam44Active { get; set; }
public int Param44SortOrder { get; set; }


public int Config34Id { get; set; }
public string Config34Name { get; set; }
public string Config34Description { get; set; }
public DateTime Config34CreatedAt { get; set; }
public DateTime? Config34UpdatedAt { get; set; }
public string Config34CreatedBy { get; set; }
public bool IsConfig34Active { get; set; }
public int Config34SortOrder { get; set; }


public int Item39Id { get; set; }
public string Item39Name { get; set; }
public string Item39Description { get; set; }
public DateTime Item39CreatedAt { get; set; }
public DateTime? Item39UpdatedAt { get; set; }
public string Item39CreatedBy { get; set; }
public bool IsItem39Active { get; set; }
public int Item39SortOrder { get; set; }


public int Detail97Id { get; set; }
public string Detail97Name { get; set; }
public string Detail97Description { get; set; }
public DateTime Detail97CreatedAt { get; set; }
public DateTime? Detail97UpdatedAt { get; set; }
public string Detail97CreatedBy { get; set; }
public bool IsDetail97Active { get; set; }
public int Detail97SortOrder { get; set; }


public int Field79Id { get; set; }
public string Field79Name { get; set; }
public string Field79Description { get; set; }
public DateTime Field79CreatedAt { get; set; }
public DateTime? Field79UpdatedAt { get; set; }
public string Field79CreatedBy { get; set; }
public bool IsField79Active { get; set; }
public int Field79SortOrder { get; set; }


public int Detail43Id { get; set; }
public string Detail43Name { get; set; }
public string Detail43Description { get; set; }
public DateTime Detail43CreatedAt { get; set; }
public DateTime? Detail43UpdatedAt { get; set; }
public string Detail43CreatedBy { get; set; }
public bool IsDetail43Active { get; set; }
public int Detail43SortOrder { get; set; }


public int Field71Id { get; set; }
public string Field71Name { get; set; }
public string Field71Description { get; set; }
public DateTime Field71CreatedAt { get; set; }
public DateTime? Field71UpdatedAt { get; set; }
public string Field71CreatedBy { get; set; }
public bool IsField71Active { get; set; }
public int Field71SortOrder { get; set; }


public int Attr94Id { get; set; }
public string Attr94Name { get; set; }
public string Attr94Description { get; set; }
public DateTime Attr94CreatedAt { get; set; }
public DateTime? Attr94UpdatedAt { get; set; }
public string Attr94CreatedBy { get; set; }
public bool IsAttr94Active { get; set; }
public int Attr94SortOrder { get; set; }


public int Config90Id { get; set; }
public string Config90Name { get; set; }
public string Config90Description { get; set; }
public DateTime Config90CreatedAt { get; set; }
public DateTime? Config90UpdatedAt { get; set; }
public string Config90CreatedBy { get; set; }
public bool IsConfig90Active { get; set; }
public int Config90SortOrder { get; set; }


public int Attr58Id { get; set; }
public string Attr58Name { get; set; }
public string Attr58Description { get; set; }
public DateTime Attr58CreatedAt { get; set; }
public DateTime? Attr58UpdatedAt { get; set; }
public string Attr58CreatedBy { get; set; }
public bool IsAttr58Active { get; set; }
public int Attr58SortOrder { get; set; }


public int Item82Id { get; set; }
public string Item82Name { get; set; }
public string Item82Description { get; set; }
public DateTime Item82CreatedAt { get; set; }
public DateTime? Item82UpdatedAt { get; set; }
public string Item82CreatedBy { get; set; }
public bool IsItem82Active { get; set; }
public int Item82SortOrder { get; set; }


public int Item36Id { get; set; }
public string Item36Name { get; set; }
public string Item36Description { get; set; }
public DateTime Item36CreatedAt { get; set; }
public DateTime? Item36UpdatedAt { get; set; }
public string Item36CreatedBy { get; set; }
public bool IsItem36Active { get; set; }
public int Item36SortOrder { get; set; }


public int Attr96Id { get; set; }
public string Attr96Name { get; set; }
public string Attr96Description { get; set; }
public DateTime Attr96CreatedAt { get; set; }
public DateTime? Attr96UpdatedAt { get; set; }
public string Attr96CreatedBy { get; set; }
public bool IsAttr96Active { get; set; }
public int Attr96SortOrder { get; set; }


public int Field62Id { get; set; }
public string Field62Name { get; set; }
public string Field62Description { get; set; }
public DateTime Field62CreatedAt { get; set; }
public DateTime? Field62UpdatedAt { get; set; }
public string Field62CreatedBy { get; set; }
public bool IsField62Active { get; set; }
public int Field62SortOrder { get; set; }


public int Config76Id { get; set; }
public string Config76Name { get; set; }
public string Config76Description { get; set; }
public DateTime Config76CreatedAt { get; set; }
public DateTime? Config76UpdatedAt { get; set; }
public string Config76CreatedBy { get; set; }
public bool IsConfig76Active { get; set; }
public int Config76SortOrder { get; set; }


public int Record70Id { get; set; }
public string Record70Name { get; set; }
public string Record70Description { get; set; }
public DateTime Record70CreatedAt { get; set; }
public DateTime? Record70UpdatedAt { get; set; }
public string Record70CreatedBy { get; set; }
public bool IsRecord70Active { get; set; }
public int Record70SortOrder { get; set; }


public int Field95Id { get; set; }
public string Field95Name { get; set; }
public string Field95Description { get; set; }
public DateTime Field95CreatedAt { get; set; }
public DateTime? Field95UpdatedAt { get; set; }
public string Field95CreatedBy { get; set; }
public bool IsField95Active { get; set; }
public int Field95SortOrder { get; set; }


public int Field54Id { get; set; }
public string Field54Name { get; set; }
public string Field54Description { get; set; }
public DateTime Field54CreatedAt { get; set; }
public DateTime? Field54UpdatedAt { get; set; }
public string Field54CreatedBy { get; set; }
public bool IsField54Active { get; set; }
public int Field54SortOrder { get; set; }


public int Config67Id { get; set; }
public string Config67Name { get; set; }
public string Config67Description { get; set; }
public DateTime Config67CreatedAt { get; set; }
public DateTime? Config67UpdatedAt { get; set; }
public string Config67CreatedBy { get; set; }
public bool IsConfig67Active { get; set; }
public int Config67SortOrder { get; set; }


public int Entry15Id { get; set; }
public string Entry15Name { get; set; }
public string Entry15Description { get; set; }
public DateTime Entry15CreatedAt { get; set; }
public DateTime? Entry15UpdatedAt { get; set; }
public string Entry15CreatedBy { get; set; }
public bool IsEntry15Active { get; set; }
public int Entry15SortOrder { get; set; }


public int Param14Id { get; set; }
public string Param14Name { get; set; }
public string Param14Description { get; set; }
public DateTime Param14CreatedAt { get; set; }
public DateTime? Param14UpdatedAt { get; set; }
public string Param14CreatedBy { get; set; }
public bool IsParam14Active { get; set; }
public int Param14SortOrder { get; set; }


public int Config30Id { get; set; }
public string Config30Name { get; set; }
public string Config30Description { get; set; }
public DateTime Config30CreatedAt { get; set; }
public DateTime? Config30UpdatedAt { get; set; }
public string Config30CreatedBy { get; set; }
public bool IsConfig30Active { get; set; }
public int Config30SortOrder { get; set; }


public int Config56Id { get; set; }
public string Config56Name { get; set; }
public string Config56Description { get; set; }
public DateTime Config56CreatedAt { get; set; }
public DateTime? Config56UpdatedAt { get; set; }
public string Config56CreatedBy { get; set; }
public bool IsConfig56Active { get; set; }
public int Config56SortOrder { get; set; }


public int Config69Id { get; set; }
public string Config69Name { get; set; }
public string Config69Description { get; set; }
public DateTime Config69CreatedAt { get; set; }
public DateTime? Config69UpdatedAt { get; set; }
public string Config69CreatedBy { get; set; }
public bool IsConfig69Active { get; set; }
public int Config69SortOrder { get; set; }


public int Field43Id { get; set; }
public string Field43Name { get; set; }
public string Field43Description { get; set; }
public DateTime Field43CreatedAt { get; set; }
public DateTime? Field43UpdatedAt { get; set; }
public string Field43CreatedBy { get; set; }
public bool IsField43Active { get; set; }
public int Field43SortOrder { get; set; }


public int Attr36Id { get; set; }
public string Attr36Name { get; set; }
public string Attr36Description { get; set; }
public DateTime Attr36CreatedAt { get; set; }
public DateTime? Attr36UpdatedAt { get; set; }
public string Attr36CreatedBy { get; set; }
public bool IsAttr36Active { get; set; }
public int Attr36SortOrder { get; set; }


public int Field97Id { get; set; }
public string Field97Name { get; set; }
public string Field97Description { get; set; }
public DateTime Field97CreatedAt { get; set; }
public DateTime? Field97UpdatedAt { get; set; }
public string Field97CreatedBy { get; set; }
public bool IsField97Active { get; set; }
public int Field97SortOrder { get; set; }


public int Item39Id { get; set; }
public string Item39Name { get; set; }
public string Item39Description { get; set; }
public DateTime Item39CreatedAt { get; set; }
public DateTime? Item39UpdatedAt { get; set; }
public string Item39CreatedBy { get; set; }
public bool IsItem39Active { get; set; }
public int Item39SortOrder { get; set; }


public int Detail67Id { get; set; }
public string Detail67Name { get; set; }
public string Detail67Description { get; set; }
public DateTime Detail67CreatedAt { get; set; }
public DateTime? Detail67UpdatedAt { get; set; }
public string Detail67CreatedBy { get; set; }
public bool IsDetail67Active { get; set; }
public int Detail67SortOrder { get; set; }


public int Param35Id { get; set; }
public string Param35Name { get; set; }
public string Param35Description { get; set; }
public DateTime Param35CreatedAt { get; set; }
public DateTime? Param35UpdatedAt { get; set; }
public string Param35CreatedBy { get; set; }
public bool IsParam35Active { get; set; }
public int Param35SortOrder { get; set; }


public int Detail91Id { get; set; }
public string Detail91Name { get; set; }
public string Detail91Description { get; set; }
public DateTime Detail91CreatedAt { get; set; }
public DateTime? Detail91UpdatedAt { get; set; }
public string Detail91CreatedBy { get; set; }
public bool IsDetail91Active { get; set; }
public int Detail91SortOrder { get; set; }


public int Param39Id { get; set; }
public string Param39Name { get; set; }
public string Param39Description { get; set; }
public DateTime Param39CreatedAt { get; set; }
public DateTime? Param39UpdatedAt { get; set; }
public string Param39CreatedBy { get; set; }
public bool IsParam39Active { get; set; }
public int Param39SortOrder { get; set; }


public int Item12Id { get; set; }
public string Item12Name { get; set; }
public string Item12Description { get; set; }
public DateTime Item12CreatedAt { get; set; }
public DateTime? Item12UpdatedAt { get; set; }
public string Item12CreatedBy { get; set; }
public bool IsItem12Active { get; set; }
public int Item12SortOrder { get; set; }

    }
}