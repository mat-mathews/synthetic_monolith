using Admin.Handlers450;
using Auth.Contracts402;
using Billing.Contracts;
using Common.Mappers190;
using DataAccess.Validators409;
using Export.Web229;
using Import.Handlers407;
using Import.Models457;
using Integration.Handlers244;
using Logging.Models379;
using Reporting.Events188;
using Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api;
using Utilities.Validators;
using Workflow.Contracts192;
using Workflow.Service161;

namespace Utilities.Core
{
    internal class Utilities_Core_Processor1
    {
        public void Execute()
        {
            // Utilities_Core_Processor1 implementation
        }

/// <summary>
/// Validates the Processor1 before processing.
/// Checks required fields, business rules, and data integrity.
/// </summary>
/// <param name="input">The input to validate.</param>
/// <returns>True if valid, false otherwise.</returns>
public bool ValidateProcessor1(Processor1Request input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));

    if (string.IsNullOrWhiteSpace(input.Name))
    {
        _logger.LogWarning("Validation failed: Name is required for {Type}", nameof(Processor1));
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
/// Processes the Processor1 operation asynchronously.
/// </summary>
public async Task<Processor1Result> ProcessProcessor1Async(
    Processor1Request request,
    CancellationToken cancellationToken = default)
{
    _logger.LogInformation("Processing {Operation} for {Id}",
        nameof(Processor1), request.Id);

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
            return new Processor1Result { Success = false, ErrorCode = "NOT_FOUND" };
        }

        // Apply business logic transformations
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = request.UserId;
        entity.Status = CalculateNewStatus(entity, request);

        await _repository.UpdateAsync(entity, cancellationToken);
        scope.Complete();

        _logger.LogInformation("Successfully processed {Operation}", nameof(Processor1));
        return new Processor1Result { Success = true, Data = entity };
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict processing {Operation}", nameof(Processor1));
        return new Processor1Result { Success = false, ErrorCode = "CONCURRENCY_CONFLICT" };
    }
}

/// <summary>
/// Retrieves a filtered and paginated list of Processor1 entities.
/// </summary>
/// <param name="filter">Filter criteria.</param>
/// <param name="page">Page number (1-based).</param>
/// <param name="pageSize">Items per page.</param>
public async Task<PagedResult<Processor1Dto>> GetProcessor1ListAsync(
    Processor1Filter filter, int page = 1, int pageSize = 25)
{
    // Ensure valid pagination parameters
    page = Math.Max(1, page);
    pageSize = Math.Clamp(pageSize, 1, 100);

    var query = _dbContext.Set<Processor1Entity>().AsQueryable();

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
        .Select(x => new Processor1Dto
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status.ToString(),
            CreatedAt = x.CreatedAt,
        })
        .ToListAsync();

    return new PagedResult<Processor1Dto>
    {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize,
    };
}

// Configuration and dependency injection setup
private readonly ILogger<Processor1Service> _logger;
private readonly IConfiguration _configuration;
private readonly IMemoryCache _cache;
private readonly TimeSpan _cacheDuration;

/*
 * Constructor initializes all dependencies.
 * Uses the options pattern for configuration binding.
 * Cache duration is configurable via appsettings.json.
 */
public Processor1Service(
    ILogger<Processor1Service> logger,
    IConfiguration configuration,
    IMemoryCache cache)
{
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    _cacheDuration = TimeSpan.FromMinutes(
        _configuration.GetValue<int>("Processor1:CacheDurationMinutes", 30));
}

/// <summary>
/// Gets or creates a cached Processor1 instance.
/// Uses IMemoryCache with sliding expiration.
/// </summary>
public async Task<Processor1Data> GetCachedProcessor1Async(string key)
{
    var cacheKey = $"Processor1_{key}";

    if (_cache.TryGetValue(cacheKey, out Processor1Data cached))
    {
        _logger.LogDebug("Cache hit for {Key}", cacheKey);
        return cached;
    }

    _logger.LogDebug("Cache miss for {Key}, loading from source", cacheKey);

    var data = await LoadFromProcessor1SourceAsync(key);

    var cacheOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(_cacheDuration)
        .SetAbsoluteExpiration(TimeSpan.FromHours(4));

    _cache.Set(cacheKey, data, cacheOptions);
    return data;
}

public int Attr25Id { get; set; }
public string Attr25Name { get; set; }
public string Attr25Description { get; set; }
public DateTime Attr25CreatedAt { get; set; }
public DateTime? Attr25UpdatedAt { get; set; }
public string Attr25CreatedBy { get; set; }
public bool IsAttr25Active { get; set; }
public int Attr25SortOrder { get; set; }


public int Field85Id { get; set; }
public string Field85Name { get; set; }
public string Field85Description { get; set; }
public DateTime Field85CreatedAt { get; set; }
public DateTime? Field85UpdatedAt { get; set; }
public string Field85CreatedBy { get; set; }
public bool IsField85Active { get; set; }
public int Field85SortOrder { get; set; }


public int Detail41Id { get; set; }
public string Detail41Name { get; set; }
public string Detail41Description { get; set; }
public DateTime Detail41CreatedAt { get; set; }
public DateTime? Detail41UpdatedAt { get; set; }
public string Detail41CreatedBy { get; set; }
public bool IsDetail41Active { get; set; }
public int Detail41SortOrder { get; set; }


public int Field67Id { get; set; }
public string Field67Name { get; set; }
public string Field67Description { get; set; }
public DateTime Field67CreatedAt { get; set; }
public DateTime? Field67UpdatedAt { get; set; }
public string Field67CreatedBy { get; set; }
public bool IsField67Active { get; set; }
public int Field67SortOrder { get; set; }


public int Param54Id { get; set; }
public string Param54Name { get; set; }
public string Param54Description { get; set; }
public DateTime Param54CreatedAt { get; set; }
public DateTime? Param54UpdatedAt { get; set; }
public string Param54CreatedBy { get; set; }
public bool IsParam54Active { get; set; }
public int Param54SortOrder { get; set; }


public int Detail55Id { get; set; }
public string Detail55Name { get; set; }
public string Detail55Description { get; set; }
public DateTime Detail55CreatedAt { get; set; }
public DateTime? Detail55UpdatedAt { get; set; }
public string Detail55CreatedBy { get; set; }
public bool IsDetail55Active { get; set; }
public int Detail55SortOrder { get; set; }


public int Record97Id { get; set; }
public string Record97Name { get; set; }
public string Record97Description { get; set; }
public DateTime Record97CreatedAt { get; set; }
public DateTime? Record97UpdatedAt { get; set; }
public string Record97CreatedBy { get; set; }
public bool IsRecord97Active { get; set; }
public int Record97SortOrder { get; set; }


public int Field85Id { get; set; }
public string Field85Name { get; set; }
public string Field85Description { get; set; }
public DateTime Field85CreatedAt { get; set; }
public DateTime? Field85UpdatedAt { get; set; }
public string Field85CreatedBy { get; set; }
public bool IsField85Active { get; set; }
public int Field85SortOrder { get; set; }


public int Config68Id { get; set; }
public string Config68Name { get; set; }
public string Config68Description { get; set; }
public DateTime Config68CreatedAt { get; set; }
public DateTime? Config68UpdatedAt { get; set; }
public string Config68CreatedBy { get; set; }
public bool IsConfig68Active { get; set; }
public int Config68SortOrder { get; set; }


public int Record10Id { get; set; }
public string Record10Name { get; set; }
public string Record10Description { get; set; }
public DateTime Record10CreatedAt { get; set; }
public DateTime? Record10UpdatedAt { get; set; }
public string Record10CreatedBy { get; set; }
public bool IsRecord10Active { get; set; }
public int Record10SortOrder { get; set; }


public int Item25Id { get; set; }
public string Item25Name { get; set; }
public string Item25Description { get; set; }
public DateTime Item25CreatedAt { get; set; }
public DateTime? Item25UpdatedAt { get; set; }
public string Item25CreatedBy { get; set; }
public bool IsItem25Active { get; set; }
public int Item25SortOrder { get; set; }


public int Param54Id { get; set; }
public string Param54Name { get; set; }
public string Param54Description { get; set; }
public DateTime Param54CreatedAt { get; set; }
public DateTime? Param54UpdatedAt { get; set; }
public string Param54CreatedBy { get; set; }
public bool IsParam54Active { get; set; }
public int Param54SortOrder { get; set; }


public int Entry99Id { get; set; }
public string Entry99Name { get; set; }
public string Entry99Description { get; set; }
public DateTime Entry99CreatedAt { get; set; }
public DateTime? Entry99UpdatedAt { get; set; }
public string Entry99CreatedBy { get; set; }
public bool IsEntry99Active { get; set; }
public int Entry99SortOrder { get; set; }


public int Param71Id { get; set; }
public string Param71Name { get; set; }
public string Param71Description { get; set; }
public DateTime Param71CreatedAt { get; set; }
public DateTime? Param71UpdatedAt { get; set; }
public string Param71CreatedBy { get; set; }
public bool IsParam71Active { get; set; }
public int Param71SortOrder { get; set; }


public int Field65Id { get; set; }
public string Field65Name { get; set; }
public string Field65Description { get; set; }
public DateTime Field65CreatedAt { get; set; }
public DateTime? Field65UpdatedAt { get; set; }
public string Field65CreatedBy { get; set; }
public bool IsField65Active { get; set; }
public int Field65SortOrder { get; set; }


public int Attr23Id { get; set; }
public string Attr23Name { get; set; }
public string Attr23Description { get; set; }
public DateTime Attr23CreatedAt { get; set; }
public DateTime? Attr23UpdatedAt { get; set; }
public string Attr23CreatedBy { get; set; }
public bool IsAttr23Active { get; set; }
public int Attr23SortOrder { get; set; }


public int Attr79Id { get; set; }
public string Attr79Name { get; set; }
public string Attr79Description { get; set; }
public DateTime Attr79CreatedAt { get; set; }
public DateTime? Attr79UpdatedAt { get; set; }
public string Attr79CreatedBy { get; set; }
public bool IsAttr79Active { get; set; }
public int Attr79SortOrder { get; set; }


public int Item9Id { get; set; }
public string Item9Name { get; set; }
public string Item9Description { get; set; }
public DateTime Item9CreatedAt { get; set; }
public DateTime? Item9UpdatedAt { get; set; }
public string Item9CreatedBy { get; set; }
public bool IsItem9Active { get; set; }
public int Item9SortOrder { get; set; }


public int Item39Id { get; set; }
public string Item39Name { get; set; }
public string Item39Description { get; set; }
public DateTime Item39CreatedAt { get; set; }
public DateTime? Item39UpdatedAt { get; set; }
public string Item39CreatedBy { get; set; }
public bool IsItem39Active { get; set; }
public int Item39SortOrder { get; set; }


public int Item35Id { get; set; }
public string Item35Name { get; set; }
public string Item35Description { get; set; }
public DateTime Item35CreatedAt { get; set; }
public DateTime? Item35UpdatedAt { get; set; }
public string Item35CreatedBy { get; set; }
public bool IsItem35Active { get; set; }
public int Item35SortOrder { get; set; }


public int Field90Id { get; set; }
public string Field90Name { get; set; }
public string Field90Description { get; set; }
public DateTime Field90CreatedAt { get; set; }
public DateTime? Field90UpdatedAt { get; set; }
public string Field90CreatedBy { get; set; }
public bool IsField90Active { get; set; }
public int Field90SortOrder { get; set; }


public int Entry26Id { get; set; }
public string Entry26Name { get; set; }
public string Entry26Description { get; set; }
public DateTime Entry26CreatedAt { get; set; }
public DateTime? Entry26UpdatedAt { get; set; }
public string Entry26CreatedBy { get; set; }
public bool IsEntry26Active { get; set; }
public int Entry26SortOrder { get; set; }


public int Field16Id { get; set; }
public string Field16Name { get; set; }
public string Field16Description { get; set; }
public DateTime Field16CreatedAt { get; set; }
public DateTime? Field16UpdatedAt { get; set; }
public string Field16CreatedBy { get; set; }
public bool IsField16Active { get; set; }
public int Field16SortOrder { get; set; }


public int Field48Id { get; set; }
public string Field48Name { get; set; }
public string Field48Description { get; set; }
public DateTime Field48CreatedAt { get; set; }
public DateTime? Field48UpdatedAt { get; set; }
public string Field48CreatedBy { get; set; }
public bool IsField48Active { get; set; }
public int Field48SortOrder { get; set; }


public int Item16Id { get; set; }
public string Item16Name { get; set; }
public string Item16Description { get; set; }
public DateTime Item16CreatedAt { get; set; }
public DateTime? Item16UpdatedAt { get; set; }
public string Item16CreatedBy { get; set; }
public bool IsItem16Active { get; set; }
public int Item16SortOrder { get; set; }


public int Param16Id { get; set; }
public string Param16Name { get; set; }
public string Param16Description { get; set; }
public DateTime Param16CreatedAt { get; set; }
public DateTime? Param16UpdatedAt { get; set; }
public string Param16CreatedBy { get; set; }
public bool IsParam16Active { get; set; }
public int Param16SortOrder { get; set; }


public int Detail72Id { get; set; }
public string Detail72Name { get; set; }
public string Detail72Description { get; set; }
public DateTime Detail72CreatedAt { get; set; }
public DateTime? Detail72UpdatedAt { get; set; }
public string Detail72CreatedBy { get; set; }
public bool IsDetail72Active { get; set; }
public int Detail72SortOrder { get; set; }


public int Attr43Id { get; set; }
public string Attr43Name { get; set; }
public string Attr43Description { get; set; }
public DateTime Attr43CreatedAt { get; set; }
public DateTime? Attr43UpdatedAt { get; set; }
public string Attr43CreatedBy { get; set; }
public bool IsAttr43Active { get; set; }
public int Attr43SortOrder { get; set; }


public int Param5Id { get; set; }
public string Param5Name { get; set; }
public string Param5Description { get; set; }
public DateTime Param5CreatedAt { get; set; }
public DateTime? Param5UpdatedAt { get; set; }
public string Param5CreatedBy { get; set; }
public bool IsParam5Active { get; set; }
public int Param5SortOrder { get; set; }


public int Record81Id { get; set; }
public string Record81Name { get; set; }
public string Record81Description { get; set; }
public DateTime Record81CreatedAt { get; set; }
public DateTime? Record81UpdatedAt { get; set; }
public string Record81CreatedBy { get; set; }
public bool IsRecord81Active { get; set; }
public int Record81SortOrder { get; set; }


public int Entry1Id { get; set; }
public string Entry1Name { get; set; }
public string Entry1Description { get; set; }
public DateTime Entry1CreatedAt { get; set; }
public DateTime? Entry1UpdatedAt { get; set; }
public string Entry1CreatedBy { get; set; }
public bool IsEntry1Active { get; set; }
public int Entry1SortOrder { get; set; }


public int Field10Id { get; set; }
public string Field10Name { get; set; }
public string Field10Description { get; set; }
public DateTime Field10CreatedAt { get; set; }
public DateTime? Field10UpdatedAt { get; set; }
public string Field10CreatedBy { get; set; }
public bool IsField10Active { get; set; }
public int Field10SortOrder { get; set; }


public int Item93Id { get; set; }
public string Item93Name { get; set; }
public string Item93Description { get; set; }
public DateTime Item93CreatedAt { get; set; }
public DateTime? Item93UpdatedAt { get; set; }
public string Item93CreatedBy { get; set; }
public bool IsItem93Active { get; set; }
public int Item93SortOrder { get; set; }


public int Entry5Id { get; set; }
public string Entry5Name { get; set; }
public string Entry5Description { get; set; }
public DateTime Entry5CreatedAt { get; set; }
public DateTime? Entry5UpdatedAt { get; set; }
public string Entry5CreatedBy { get; set; }
public bool IsEntry5Active { get; set; }
public int Entry5SortOrder { get; set; }


public int Item43Id { get; set; }
public string Item43Name { get; set; }
public string Item43Description { get; set; }
public DateTime Item43CreatedAt { get; set; }
public DateTime? Item43UpdatedAt { get; set; }
public string Item43CreatedBy { get; set; }
public bool IsItem43Active { get; set; }
public int Item43SortOrder { get; set; }


public int Attr67Id { get; set; }
public string Attr67Name { get; set; }
public string Attr67Description { get; set; }
public DateTime Attr67CreatedAt { get; set; }
public DateTime? Attr67UpdatedAt { get; set; }
public string Attr67CreatedBy { get; set; }
public bool IsAttr67Active { get; set; }
public int Attr67SortOrder { get; set; }


public int Entry11Id { get; set; }
public string Entry11Name { get; set; }
public string Entry11Description { get; set; }
public DateTime Entry11CreatedAt { get; set; }
public DateTime? Entry11UpdatedAt { get; set; }
public string Entry11CreatedBy { get; set; }
public bool IsEntry11Active { get; set; }
public int Entry11SortOrder { get; set; }


public int Config75Id { get; set; }
public string Config75Name { get; set; }
public string Config75Description { get; set; }
public DateTime Config75CreatedAt { get; set; }
public DateTime? Config75UpdatedAt { get; set; }
public string Config75CreatedBy { get; set; }
public bool IsConfig75Active { get; set; }
public int Config75SortOrder { get; set; }


public int Entry22Id { get; set; }
public string Entry22Name { get; set; }
public string Entry22Description { get; set; }
public DateTime Entry22CreatedAt { get; set; }
public DateTime? Entry22UpdatedAt { get; set; }
public string Entry22CreatedBy { get; set; }
public bool IsEntry22Active { get; set; }
public int Entry22SortOrder { get; set; }


public int Field49Id { get; set; }
public string Field49Name { get; set; }
public string Field49Description { get; set; }
public DateTime Field49CreatedAt { get; set; }
public DateTime? Field49UpdatedAt { get; set; }
public string Field49CreatedBy { get; set; }
public bool IsField49Active { get; set; }
public int Field49SortOrder { get; set; }


public int Entry98Id { get; set; }
public string Entry98Name { get; set; }
public string Entry98Description { get; set; }
public DateTime Entry98CreatedAt { get; set; }
public DateTime? Entry98UpdatedAt { get; set; }
public string Entry98CreatedBy { get; set; }
public bool IsEntry98Active { get; set; }
public int Entry98SortOrder { get; set; }


public int Param64Id { get; set; }
public string Param64Name { get; set; }
public string Param64Description { get; set; }
public DateTime Param64CreatedAt { get; set; }
public DateTime? Param64UpdatedAt { get; set; }
public string Param64CreatedBy { get; set; }
public bool IsParam64Active { get; set; }
public int Param64SortOrder { get; set; }


public int Attr42Id { get; set; }
public string Attr42Name { get; set; }
public string Attr42Description { get; set; }
public DateTime Attr42CreatedAt { get; set; }
public DateTime? Attr42UpdatedAt { get; set; }
public string Attr42CreatedBy { get; set; }
public bool IsAttr42Active { get; set; }
public int Attr42SortOrder { get; set; }


public int Entry64Id { get; set; }
public string Entry64Name { get; set; }
public string Entry64Description { get; set; }
public DateTime Entry64CreatedAt { get; set; }
public DateTime? Entry64UpdatedAt { get; set; }
public string Entry64CreatedBy { get; set; }
public bool IsEntry64Active { get; set; }
public int Entry64SortOrder { get; set; }


public int Param6Id { get; set; }
public string Param6Name { get; set; }
public string Param6Description { get; set; }
public DateTime Param6CreatedAt { get; set; }
public DateTime? Param6UpdatedAt { get; set; }
public string Param6CreatedBy { get; set; }
public bool IsParam6Active { get; set; }
public int Param6SortOrder { get; set; }


public int Config83Id { get; set; }
public string Config83Name { get; set; }
public string Config83Description { get; set; }
public DateTime Config83CreatedAt { get; set; }
public DateTime? Config83UpdatedAt { get; set; }
public string Config83CreatedBy { get; set; }
public bool IsConfig83Active { get; set; }
public int Config83SortOrder { get; set; }


public int Record39Id { get; set; }
public string Record39Name { get; set; }
public string Record39Description { get; set; }
public DateTime Record39CreatedAt { get; set; }
public DateTime? Record39UpdatedAt { get; set; }
public string Record39CreatedBy { get; set; }
public bool IsRecord39Active { get; set; }
public int Record39SortOrder { get; set; }


public int Attr83Id { get; set; }
public string Attr83Name { get; set; }
public string Attr83Description { get; set; }
public DateTime Attr83CreatedAt { get; set; }
public DateTime? Attr83UpdatedAt { get; set; }
public string Attr83CreatedBy { get; set; }
public bool IsAttr83Active { get; set; }
public int Attr83SortOrder { get; set; }


public int Record61Id { get; set; }
public string Record61Name { get; set; }
public string Record61Description { get; set; }
public DateTime Record61CreatedAt { get; set; }
public DateTime? Record61UpdatedAt { get; set; }
public string Record61CreatedBy { get; set; }
public bool IsRecord61Active { get; set; }
public int Record61SortOrder { get; set; }


public int Param22Id { get; set; }
public string Param22Name { get; set; }
public string Param22Description { get; set; }
public DateTime Param22CreatedAt { get; set; }
public DateTime? Param22UpdatedAt { get; set; }
public string Param22CreatedBy { get; set; }
public bool IsParam22Active { get; set; }
public int Param22SortOrder { get; set; }


public int Record59Id { get; set; }
public string Record59Name { get; set; }
public string Record59Description { get; set; }
public DateTime Record59CreatedAt { get; set; }
public DateTime? Record59UpdatedAt { get; set; }
public string Record59CreatedBy { get; set; }
public bool IsRecord59Active { get; set; }
public int Record59SortOrder { get; set; }


public int Attr60Id { get; set; }
public string Attr60Name { get; set; }
public string Attr60Description { get; set; }
public DateTime Attr60CreatedAt { get; set; }
public DateTime? Attr60UpdatedAt { get; set; }
public string Attr60CreatedBy { get; set; }
public bool IsAttr60Active { get; set; }
public int Attr60SortOrder { get; set; }


public int Detail43Id { get; set; }
public string Detail43Name { get; set; }
public string Detail43Description { get; set; }
public DateTime Detail43CreatedAt { get; set; }
public DateTime? Detail43UpdatedAt { get; set; }
public string Detail43CreatedBy { get; set; }
public bool IsDetail43Active { get; set; }
public int Detail43SortOrder { get; set; }


public int Item76Id { get; set; }
public string Item76Name { get; set; }
public string Item76Description { get; set; }
public DateTime Item76CreatedAt { get; set; }
public DateTime? Item76UpdatedAt { get; set; }
public string Item76CreatedBy { get; set; }
public bool IsItem76Active { get; set; }
public int Item76SortOrder { get; set; }

    }

}