﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Tesseract.Core.Storage.Model;

namespace Tesseract.Core.Queue
{
    public interface IJobProcessor<TItem> where TItem : JobStepBase
    {
        void Initialize(JobData jobData);
        Task<JobProcessingResult> Process(List<TItem> items);
        Task<long> GetTargetQueueLength();
    }
}