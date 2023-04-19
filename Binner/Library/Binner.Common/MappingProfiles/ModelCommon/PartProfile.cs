﻿using AutoMapper;
using Binner.Model;
using System.Collections.Generic;
using System.Linq;
using Binner.Model.Responses;
using DataModel = Binner.Data.Model;

namespace Binner.Common.MappingProfiles.ModelCommon
{
    public class PartProfile : Profile
    {
        public PartProfile()
        {
            CreateMap<DataModel.Part, PartResponse>()
                .ForMember(x => x.BinNumber, options => options.MapFrom(x => x.BinNumber))
                .ForMember(x => x.BinNumber2, options => options.MapFrom(x => x.BinNumber2))
                .ForMember(x => x.Cost, options => options.MapFrom(x => (decimal)x.Cost))
                .ForMember(x => x.Currency, options => options.MapFrom(x => x.Currency))
                .ForMember(x => x.DatasheetUrl, options => options.MapFrom(x => x.DatasheetUrl))
                .ForMember(x => x.Description, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.DigiKeyPartNumber, options => options.MapFrom(x => x.DigiKeyPartNumber))
                .ForMember(x => x.ImageUrl, options => options.MapFrom(x => x.ImageUrl))
                .ForMember(x => x.Keywords, options => options.MapFrom(x => x.Keywords))
                .ForMember(x => x.Location, options => options.MapFrom(x => x.Location))
                .ForMember(x => x.LowestCostSupplier, options => options.MapFrom(x => x.LowestCostSupplier))
                .ForMember(x => x.LowestCostSupplierUrl, options => options.MapFrom(x => x.LowestCostSupplierUrl))
                .ForMember(x => x.LowStockThreshold, options => options.MapFrom(x => x.LowStockThreshold))
                .ForMember(x => x.Manufacturer, options => options.MapFrom(x => x.Manufacturer))
                .ForMember(x => x.ManufacturerPartNumber, options => options.MapFrom(x => x.ManufacturerPartNumber))
                .ForMember(x => x.MountingTypeId, options => options.MapFrom(x => x.MountingTypeId))
                .ForMember(x => x.MouserPartNumber, options => options.MapFrom(x => x.MouserPartNumber))
                .ForMember(x => x.ArrowPartNumber, options => options.MapFrom(x => x.ArrowPartNumber))
                .ForMember(x => x.PackageType, options => options.MapFrom(x => x.PackageType))
                .ForMember(x => x.PartId, options => options.MapFrom(x => x.PartId))
                .ForMember(x => x.PartNumber, options => options.MapFrom(x => x.PartNumber))
                .ForMember(x => x.PartType, options => options.MapFrom(x => x.PartType))
                .ForMember(x => x.PartTypeId, options => options.MapFrom(x => x.PartTypeId))
                .ForMember(x => x.ProductUrl, options => options.MapFrom(x => x.ProductUrl))
                .ForMember(x => x.ProjectId, options => options.MapFrom(x => x.ProjectId))
                .ForMember(x => x.Quantity, options => options.MapFrom(x => x.Quantity))
                .ForMember(x => x.MountingType, options => options.Ignore())
                ;

            CreateMap<PartResponse, DataModel.Part>()
                .ForMember(x => x.BinNumber, options => options.MapFrom(x => x.BinNumber))
                .ForMember(x => x.BinNumber2, options => options.MapFrom(x => x.BinNumber2))
                .ForMember(x => x.Cost, options => options.MapFrom(x => (double)x.Cost))
                .ForMember(x => x.Currency, options => options.MapFrom(x => x.Currency))
                .ForMember(x => x.DatasheetUrl, options => options.MapFrom(x => x.DatasheetUrl))
                .ForMember(x => x.Description, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.DigiKeyPartNumber, options => options.MapFrom(x => x.DigiKeyPartNumber))
                .ForMember(x => x.ImageUrl, options => options.MapFrom(x => x.ImageUrl))
                .ForMember(x => x.Keywords, options => options.MapFrom(x => x.Keywords))
                .ForMember(x => x.KeywordsList, options => options.MapFrom(x => x.Keywords != null ? x.Keywords.Split(",", System.StringSplitOptions.None).ToList() : new List<string>()))
                .ForMember(x => x.Location, options => options.MapFrom(x => x.Location))
                .ForMember(x => x.LowestCostSupplier, options => options.MapFrom(x => x.LowestCostSupplier))
                .ForMember(x => x.LowestCostSupplierUrl, options => options.MapFrom(x => x.LowestCostSupplierUrl))
                .ForMember(x => x.LowStockThreshold, options => options.MapFrom(x => x.LowStockThreshold))
                .ForMember(x => x.Manufacturer, options => options.MapFrom(x => x.Manufacturer))
                .ForMember(x => x.ManufacturerPartNumber, options => options.MapFrom(x => x.ManufacturerPartNumber))
                .ForMember(x => x.MountingTypeId, options => options.MapFrom(x => x.MountingTypeId))
                .ForMember(x => x.MouserPartNumber, options => options.MapFrom(x => x.MouserPartNumber))
                .ForMember(x => x.ArrowPartNumber, options => options.MapFrom(x => x.ArrowPartNumber))
                .ForMember(x => x.PackageType, options => options.MapFrom(x => x.PackageType))
                .ForMember(x => x.PartId, options => options.MapFrom(x => x.PartId))
                .ForMember(x => x.PartNumber, options => options.MapFrom(x => x.PartNumber))
                .ForMember(x => x.PartTypeId, options => options.MapFrom(x => x.PartTypeId))
                .ForMember(x => x.ProductUrl, options => options.MapFrom(x => x.ProductUrl))
                .ForMember(x => x.ProjectId, options => options.MapFrom(x => x.ProjectId))
                .ForMember(x => x.Quantity, options => options.MapFrom(x => x.Quantity))
                .ForMember(x => x.DateCreatedUtc, options => options.Ignore())
                .ForMember(x => x.KeywordsList, options => options.Ignore())
                .ForMember(x => x.PartType, options => options.Ignore())
                .ForMember(x => x.Project, options => options.Ignore())
                .ForMember(x => x.ProjectPartAssignments, options => options.Ignore())
                .ForMember(x => x.StoredFiles, options => options.Ignore())
                .ForMember(x => x.UserId, options => options.Ignore())
                .ForMember(x => x.PartSuppliers, options => options.Ignore())
                .ForMember(x => x.OrganizationId, options => options.Ignore())
#if INITIALCREATE
                .ForMember(x => x.DateModifiedUtc, options => options.Ignore())
                .ForMember(x => x.User, options => options.Ignore())
#endif
                ;

            CreateMap<DataModel.Part, Part>()
                .ForMember(x => x.BinNumber, options => options.MapFrom(x => x.BinNumber))
                .ForMember(x => x.BinNumber2, options => options.MapFrom(x => x.BinNumber2))
                .ForMember(x => x.Cost, options => options.MapFrom(x => (decimal)x.Cost))
                .ForMember(x => x.Currency, options => options.MapFrom(x => x.Currency))
                .ForMember(x => x.DatasheetUrl, options => options.MapFrom(x => x.DatasheetUrl))
                .ForMember(x => x.Description, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.DigiKeyPartNumber, options => options.MapFrom(x => x.DigiKeyPartNumber))
                .ForMember(x => x.ImageUrl, options => options.MapFrom(x => x.ImageUrl))
                .ForMember(x => x.Keywords, options => options.MapFrom(x => x.Keywords != null ? x.Keywords.Split(",", System.StringSplitOptions.None).ToList() : new List<string>()))
                .ForMember(x => x.Location, options => options.MapFrom(x => x.Location))
                .ForMember(x => x.LowestCostSupplier, options => options.MapFrom(x => x.LowestCostSupplier))
                .ForMember(x => x.LowestCostSupplierUrl, options => options.MapFrom(x => x.LowestCostSupplierUrl))
                .ForMember(x => x.LowStockThreshold, options => options.MapFrom(x => x.LowStockThreshold))
                .ForMember(x => x.Manufacturer, options => options.MapFrom(x => x.Manufacturer))
                .ForMember(x => x.ManufacturerPartNumber, options => options.MapFrom(x => x.ManufacturerPartNumber))
                .ForMember(x => x.MountingTypeId, options => options.MapFrom(x => x.MountingTypeId))
                .ForMember(x => x.MouserPartNumber, options => options.MapFrom(x => x.MouserPartNumber))
                .ForMember(x => x.ArrowPartNumber, options => options.MapFrom(x => x.ArrowPartNumber))
                .ForMember(x => x.PackageType, options => options.MapFrom(x => x.PackageType))
                .ForMember(x => x.PartId, options => options.MapFrom(x => x.PartId))
                .ForMember(x => x.PartNumber, options => options.MapFrom(x => x.PartNumber))
                .ForMember(x => x.PartTypeId, options => options.MapFrom(x => x.PartTypeId))
                .ForMember(x => x.ProductUrl, options => options.MapFrom(x => x.ProductUrl))
                .ForMember(x => x.ProjectId, options => options.MapFrom(x => x.ProjectId))
                .ForMember(x => x.Quantity, options => options.MapFrom(x => x.Quantity))
                .ForMember(x => x.DateCreatedUtc, options => options.MapFrom(x => x.DateCreatedUtc))
                ;

            CreateMap<Part, DataModel.Part>()
                .ForMember(x => x.BinNumber, options => options.MapFrom(x => x.BinNumber))
                .ForMember(x => x.BinNumber2, options => options.MapFrom(x => x.BinNumber2))
                .ForMember(x => x.Cost, options => options.MapFrom(x => (double)x.Cost))
                .ForMember(x => x.Currency, options => options.MapFrom(x => x.Currency))
                .ForMember(x => x.DatasheetUrl, options => options.MapFrom(x => x.DatasheetUrl))
                .ForMember(x => x.Description, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.DigiKeyPartNumber, options => options.MapFrom(x => x.DigiKeyPartNumber))
                .ForMember(x => x.ImageUrl, options => options.MapFrom(x => x.ImageUrl))
                .ForMember(x => x.Keywords, options => options.MapFrom(x => x.Keywords != null ? string.Join(",", x.Keywords) : string.Empty))
                .ForMember(x => x.KeywordsList, options => options.MapFrom(x => x.Keywords))
                .ForMember(x => x.Location, options => options.MapFrom(x => x.Location))
                .ForMember(x => x.LowestCostSupplier, options => options.MapFrom(x => x.LowestCostSupplier))
                .ForMember(x => x.LowestCostSupplierUrl, options => options.MapFrom(x => x.LowestCostSupplierUrl))
                .ForMember(x => x.LowStockThreshold, options => options.MapFrom(x => x.LowStockThreshold))
                .ForMember(x => x.Manufacturer, options => options.MapFrom(x => x.Manufacturer))
                .ForMember(x => x.ManufacturerPartNumber, options => options.MapFrom(x => x.ManufacturerPartNumber))
                .ForMember(x => x.MountingTypeId, options => options.MapFrom(x => x.MountingTypeId))
                .ForMember(x => x.MouserPartNumber, options => options.MapFrom(x => x.MouserPartNumber))
                .ForMember(x => x.ArrowPartNumber, options => options.MapFrom(x => x.ArrowPartNumber))
                .ForMember(x => x.PackageType, options => options.MapFrom(x => x.PackageType))
                .ForMember(x => x.PartId, options => options.MapFrom(x => x.PartId))
                .ForMember(x => x.PartNumber, options => options.MapFrom(x => x.PartNumber))
                .ForMember(x => x.PartTypeId, options => options.MapFrom(x => x.PartTypeId))
                .ForMember(x => x.ProductUrl, options => options.MapFrom(x => x.ProductUrl))
                .ForMember(x => x.ProjectId, options => options.MapFrom(x => x.ProjectId))
                .ForMember(x => x.Quantity, options => options.MapFrom(x => x.Quantity))
                .ForMember(x => x.DateCreatedUtc, options => options.MapFrom(x => x.DateCreatedUtc))
                .ForMember(x => x.PartSuppliers, options => options.Ignore())
                .ForMember(x => x.PartType, options => options.Ignore())
                .ForMember(x => x.Project, options => options.Ignore())
                .ForMember(x => x.ProjectPartAssignments, options => options.Ignore())
                .ForMember(x => x.StoredFiles, options => options.Ignore())
                .ForMember(x => x.UserId, options => options.Ignore())
                .ForMember(x => x.OrganizationId, options => options.Ignore())
#if INITIALCREATE
                .ForMember(x => x.User, options => options.Ignore())
                .ForMember(x => x.DateModifiedUtc, options => options.Ignore())
#endif
                ;
        }
    }
}
