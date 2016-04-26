using AutoMapper;
using DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using View.Models;

namespace View.Helpers
{
    public class PagedListConverter : ITypeConverter<PagedList<Region>, PagedList<RegionViewModel>>
    {
        public PagedList<RegionViewModel> Convert(ResolutionContext context)
        {
            var model = (PagedList<Region>)context.SourceValue;
            var vm = model.Select(m => Mapper.Map<Region, RegionViewModel>(m)).ToList();

            return new PagedList<RegionViewModel>(vm, model.PageNumber, model.PageSize);
        }
    }
}