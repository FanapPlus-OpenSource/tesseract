﻿using System;
using System.Threading.Tasks;
using Tesseract.Core.Context;
using Tesseract.Core.MultiTenancy;
using Tesseract.Core.Storage.Model;

namespace Tesseract.Core.Logic.Implementation
{
    public class DefaultCurrentTenantLogic : ICurrentTenantLogic
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ITenantContextAccessor _tenantContextAccessor;

        private static readonly TenantContextInfo FanapPlusTenant = new TenantContextInfo("fanap-plus");


        public DefaultCurrentTenantLogic(IServiceProvider serviceProvider, ITenantContextAccessor tenantContextAccessor)
        {
            _serviceProvider = serviceProvider;
            _tenantContextAccessor = tenantContextAccessor;
        }

        public void InitializeInfo(string tenantId)
        {
            // TODO: read tenant ID from request
            SetTenantInfo(null);
        }

        public Task PopulateInfo()
        {
            // no await, no async. Just pass the task from the inner call.
            return GetTenantInfo().Initialize(_serviceProvider);
        }

        public string Id => GetTenantInfo().Id;
        public string None => "_NONE_";

        public bool DoesTagNsExist(string ns)
        {
            return GetInitializedTenantInfo().TagNsDefinitions.ContainsKey(ns);
        }

        public TagNsDefinitionData GetTagNsDefinition(string ns)
        {
            var definitions = GetTenantInfo()?.TagNsDefinitions;
            TagNsDefinitionData result = null;
            definitions?.TryGetValue(ns, out result);
            return result;
        }

        public bool DoesFieldExist(string fieldName)
        {
            return GetInitializedTenantInfo().FieldDefinitions.ContainsKey(fieldName);
        }

        public FieldDefinitionData GetFieldDefinition(string fieldName)
        {
            var definitions = GetTenantInfo()?.FieldDefinitions;
            FieldDefinitionData result = null;
            definitions?.TryGetValue(fieldName, out result);
            return result;
        }

        #region Private helper methods

        private TenantContextInfo GetTenantInfo()
        {
            var tenantContext = _tenantContextAccessor.TenantContext;
            return tenantContext.Tenant;
        }

        private TenantContextInfo GetInitializedTenantInfo()
        {
            var info = GetTenantInfo();
            if (!info.Initialized)
                throw new InvalidOperationException(
                    "TenantContextInfo is not yet initialized / populated with the data.");

            return info;
        }

        private void SetTenantInfo(string tenantId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}