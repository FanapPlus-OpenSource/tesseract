﻿using System.Threading.Tasks;
using Nest;

namespace Tesseract.Core.Connection
{
    public interface IEsManager
    {
        ElasticClient Client { get; }
        string GetTenantIndexName(string tenantId);
        Task DeleteTenantIndex(string tenantId);
        Task CreateTenantIndex(string tenantId);
        Task EnsureTenantIndex(string tenantId);
        Task EnsureIndexTagNsAndFieldMappings(string tenantId);

        Task SetTagNsMapping(string tenantId, string ns);
        Task SetFieldMapping(string tenantId, string fieldName);
    }
}