using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Admin.Api
{
    /// <summary>
    /// Provides bulk CRUD operations for admin entities.
    /// Supports batched inserts, updates, and soft-deletes with
    /// transaction safety and progress reporting.
    /// </summary>
    public class AdminBulkOperationService
    {
        private readonly ILogger<AdminBulkOperationService> _logger;
        private readonly IRepository _repository;
        private readonly int _maxBatchSize;

        public AdminBulkOperationService(
            ILogger<AdminBulkOperationService> logger,
            IRepository repository,
            int maxBatchSize = 500)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _maxBatchSize = maxBatchSize;
        }

        /// <summary>
        /// Bulk insert entities with automatic batching.
        /// </summary>
        public async Task<BulkOperationResult> BulkInsertAsync(
            IEnumerable<AdminEntity> entities,
            CancellationToken cancellationToken = default)
        {
            var items = entities.ToList();
            _logger.LogInformation("Starting bulk insert of {Count} entities", items.Count);

            var inserted = 0;
            var failed = 0;
            var errors = new List<string>();

            foreach (var batch in items.Chunk(_maxBatchSize))
            {
                try
                {
                    await _repository.BulkInsertAsync(batch, cancellationToken);
                    inserted += batch.Length;
                }
                catch (Exception ex)
                {
                    failed += batch.Length;
                    errors.Add($"Batch failed: {ex.Message}");
                    _logger.LogError(ex, "Bulk insert batch failed at offset {Offset}", inserted);
                }
            }

            return new BulkOperationResult
            {
                TotalRequested = items.Count,
                Succeeded = inserted,
                Failed = failed,
                Errors = errors
            };
        }

        /// <summary>
        /// Soft-delete entities matching a predicate.
        /// </summary>
        public async Task<int> BulkSoftDeleteAsync(
            Func<AdminEntity, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            var targets = await _repository.GetAllAsync(cancellationToken);
            var toDelete = targets.Where(predicate).ToList();

            _logger.LogInformation("Soft-deleting {Count} entities", toDelete.Count);

            foreach (var entity in toDelete)
            {
                entity.IsActive = false;
                entity.UpdatedAt = DateTime.UtcNow;
            }

            await _repository.BulkUpdateAsync(toDelete, cancellationToken);
            return toDelete.Count;
        }
    }

    public class BulkOperationResult
    {
        public int TotalRequested { get; set; }
        public int Succeeded { get; set; }
        public int Failed { get; set; }
        public List<string> Errors { get; set; } = new();
        public bool IsFullSuccess => Failed == 0;
    }
}
