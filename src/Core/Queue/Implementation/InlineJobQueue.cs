﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComposerCore.Attributes;
using Tesseract.Common.Extensions;

namespace Tesseract.Core.Queue.Implementation
{
    [Component]
    [IgnoredOnAssemblyRegistration]
    public class InlineJobQueue<TItem> : IJobQueue<TItem> where TItem : JobStepBase
    {
        [ComponentPlug]
        public IJobProcessor<TItem> Processor { get; set; }

        public Task EnsureJobQueueExists(string jobId = null)
        {
            return Task.CompletedTask;
        }

        public Task<long> GetQueueLength(string jobId = null)
        {
            return Task.FromResult(0L);
        }

        public Task PurgeQueueContents(string jobId = null)
        {
            return Task.CompletedTask;
        }

        public async Task Enqueue(TItem item, string jobId = null)
        {
            await Processor.Process(item.Yield().ToList());
        }

        public async Task EnqueueBatch(IEnumerable<TItem> items, string jobId = null)
        {
            await Processor.Process(items.ToList());
        }

        public Task<TItem> Dequeue(string jobId = null)
        {
            return Task.FromResult<TItem>(null);
        }

        public Task<IEnumerable<TItem>> DequeueBatch(int maxBatchSize, string jobId = null)
        {
            return Task.FromResult(Enumerable.Empty<TItem>());
        }
    }
}