﻿using AnyMapper;
using Binner.Common.Configuration;
using Binner.Common.Models;
using Binner.Common.Models.Responses;
using Binner.Common.Services;
using Binner.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Binner.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    public class PartTypeController : ControllerBase
    {
        private readonly ILogger<PartTypeController> _logger;
        private readonly WebHostServiceConfiguration _config;
        private readonly IPartTypeService _partTypeService;
        private readonly IPartService _partService;

        public PartTypeController(ILogger<PartTypeController> logger, WebHostServiceConfiguration config, IPartTypeService partTypeService, IPartService partService)
        {
            _logger = logger;
            _config = config;
            _partTypeService = partTypeService;
            _partService = partService;
        }

        /// <summary>
        /// Get a list of all part types
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllPartTypesAsync()
        {
            var partTypes = await _partService.GetPartTypesAsync();
            var partTypesResponse = Mapper.Map<ICollection<PartType>, ICollection<PartTypeResponse>>(partTypes);
            foreach (var partType in partTypesResponse)
            {
                // todo: extend part service to support this more efficiently
                partType.ParentPartType = partTypes
                    .Where(x => x.ParentPartTypeId == partType.ParentPartTypeId)
                    .Select(x => x.Name)
                    .FirstOrDefault();
            }
            return Ok(partTypesResponse);
        }

        /// <summary>
        /// Get a list of part types
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<IActionResult> GetPartTypesAsync([FromQuery] string? parent)
        {
            var partTypes = await _partService.GetPartTypesAsync();

            PartType? parentPartType = null;
            if (!string.IsNullOrEmpty(parent))
            {
                parentPartType = partTypes.FirstOrDefault(x => x.Name.Equals(parent, StringComparison.InvariantCultureIgnoreCase));
                if (parentPartType == null)
                    return NotFound();
            }

            var partTypesFiltered = partTypes
                .Where(x => x.ParentPartTypeId == parentPartType?.PartTypeId)
                .ToList();

            var partTypesResponse = Mapper.Map<ICollection<PartType>, ICollection<PartTypeResponse>>(partTypesFiltered);
            foreach (var partType in partTypesResponse)
            {
                // todo: extend part service to support this more efficiently
                var partsForPartType = await _partService.GetPartsAsync(x => x.PartTypeId == partType.PartTypeId);
                partType.Parts = partsForPartType.Count;
                partType.ParentPartType = parentPartType?.Name;
            }
            return Ok(partTypesResponse);
        }

        /// <summary>
        /// Create a new part type
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreatePartTypeAsync(CreatePartTypeRequest request)
        {
            var mappedPartType = Mapper.Map<CreatePartTypeRequest, PartType>(request);
            mappedPartType.DateCreatedUtc = DateTime.UtcNow;
            var partType = await _partTypeService.AddPartTypeAsync(mappedPartType);

            var partTypeResponse = Mapper.Map<PartType, PartTypeResponse>(partType);
            if (partType.ParentPartTypeId != null)
            {
                // todo: extend part service to support this more efficiently
                var partTypes = await _partService.GetPartTypesAsync();
                partTypeResponse.ParentPartType = partTypes.Where(x => x.PartTypeId == partType.ParentPartTypeId).Select(x => x.Name).FirstOrDefault();
            }

            return Ok(partTypeResponse);
        }

        /// <summary>
        /// Update an existing part type
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdatePartTypeAsync(UpdatePartTypeRequest request)
        {
            var mappedPartType = Mapper.Map<UpdatePartTypeRequest, PartType>(request);
            var partType = await _partTypeService.UpdatePartTypeAsync(mappedPartType);
            return Ok(partType);
        }

        /// <summary>
        /// Delete an existing part type
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeletePartTypeAsync(DeletePartTypeRequest request)
        {
            try
            {
                var isDeleted = await _partTypeService.DeletePartTypeAsync(new PartType
                {
                    PartTypeId = request.PartTypeId
                });
                return Ok(isDeleted);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ExceptionResponse("Cannot delete. ", ex));
            }
        }
    }
}
