﻿using System.Threading.Tasks;
using ComposerCore.Attributes;
using Tesseract.Core.Storage.Model;

namespace Tesseract.Core.Logic
{
    [Contract]
    public interface ICurrentTenantLogic
    {
        string Id { get; }
        string None { get; }
        void InitializeInfo(string tenantId);
        Task PopulateInfo();

        bool DoesTagNsExist(string ns);
        TagNsDefinitionData GetTagNsDefinition(string ns);

        bool DoesFieldExist(string fieldName);
        FieldDefinitionData GetFieldDefinition(string fieldName);
    }
}