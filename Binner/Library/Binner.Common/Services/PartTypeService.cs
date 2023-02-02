﻿using Binner.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Binner.Common.Services
{
    public class PartTypeService : IPartTypeService
    {
        private IStorageProvider _storageProvider;
        private RequestContextAccessor _requestContext;

        public PartTypeService(IStorageProvider storageProvider, RequestContextAccessor requestContextAccessor)
        {
            _storageProvider = storageProvider;
            _requestContext = requestContextAccessor;
        }

        public async Task<PartType> AddPartTypeAsync(PartType partType)
        {
            return await _storageProvider.GetOrCreatePartTypeAsync(partType, _requestContext.GetUserContext());
        }

        public async Task<bool> DeletePartTypeAsync(PartType partType)
        {
            var existingPartType = await _storageProvider.GetPartTypeAsync(partType.PartTypeId, _requestContext.GetUserContext());
            if (existingPartType == null)
                return false;
            
            // does it have children? todo: need storage provider support for this
            var partTypes = await GetPartTypesAsync();
            if (partTypes.Where(x => x.ParentPartTypeId== existingPartType.PartTypeId).Any())
            {
                throw new InvalidOperationException($"Cannot delete part type '{existingPartType.Name}' until it's children are deleted.");
            }            

            return await _storageProvider.DeletePartTypeAsync(partType, _requestContext.GetUserContext());
        }

        public async Task<PartType> GetPartTypeAsync(long partTypeId)
        {
            return await _storageProvider.GetPartTypeAsync(partTypeId, _requestContext.GetUserContext());
        }

        public async Task<ICollection<PartType>> GetPartTypesAsync()
        {
            return await _storageProvider.GetPartTypesAsync(_requestContext.GetUserContext());
        }

        public async Task<PartType> UpdatePartTypeAsync(PartType partType)
        {
            return await _storageProvider.UpdatePartTypeAsync(partType, _requestContext.GetUserContext());
        }
    }
}
