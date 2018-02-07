﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Tesseract.Common.ComposerImposter;

namespace Tesseract.Core.Distribution
{
    [Contract]
    public interface IDistributionNodes
    {
        Task StartHeartbeat();
        Task StopHeartbeat();

        Task<List<string>> GetAllAliveNodes();
        Task<List<string>> GetAliveWebNodes();
        Task<List<string>> GetAliveWorkerNodes();
    }
}