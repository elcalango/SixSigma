using AutoMapper;
using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;
using PagedList;
using View.Helpers;
using AutoMapper.QueryableExtensions;
using DelegateDecompiler;

namespace View.Controllers
{
    public class RegionController : Controller
    {
        private RegionService _regionService;
        // GET: Region
        public ActionResult ListRegions(int page = 1)
        {
            _regionService = new RegionService();

            //var regions = _regionService.GetRegions().ToPagedList<Region>(page, 2);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PagedList<Region>, PagedList<RegionViewModel>>()
                    .ConvertUsing<PagedListConverter>();
            });


            config.CreateMapper(new PagedListTypeConverter<Region, RegionViewModel>)
            IMapper mapper = config.CreateMapper();


            var viewModels = Mapper.Map<PagedList<Region>, PagedList<RegionViewModel>>(regions);



            return View(viewModels);
        }

        public ActionResult Index()
        {
            _regionService = new RegionService();
            var regions = _regionService.GetRegions();


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Region, RegionViewModel>();
            });

            IMapper mapper = config.CreateMapper();

            var model = mapper.Map<IList<Region>, IList<RegionViewModel>>(regions);


            return View(model);
        }


    }

    public class PagedViewModel<T>
    {
        public int FirstItemOnPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int LastItemOnPage { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public IEnumerable<T> rows { get; set; }
    }

    public class PagedListTypeConverter<T> : ITypeConverter<IPagedList<T>, PagedViewModel<T>>
    {
        public PagedViewModel<T> Convert(ResolutionContext context)
        {
            var source = (IPagedList<T>)context.SourceValue;
            return new PagedViewModel<T>()
            {
                FirstItemOnPage = source.FirstItemOnPage,
                HasNextPage = source.HasNextPage,
                HasPreviousPage = source.HasPreviousPage,
                IsFirstPage = source.IsFirstPage,
                IsLastPage = source.IsLastPage,
                LastItemOnPage = source.LastItemOnPage,
                PageCount = source.PageCount,
                PageNumber = source.PageNumber,
                PageSize = source.PageSize,
                TotalItemCount = source.TotalItemCount,
                rows = source
            };
        }
    }

    public class PagedListConverter : ITypeConverter<PagedList<Region>, PagedList<RegionViewModel>>
    {
        public PagedList<RegionViewModel> Convert(ResolutionContext context)
        {
            var model = (PagedList<Region>)context.SourceValue;
            var vm = model.Select(m => Mapper.Map<Region, RegionViewModel>(m)).ToList();

            return new PagedList<RegionViewModel>(vm, model.PageNumber, model.PageSize);
        }
    }

    public static class MapperExtensions
    {
        public static IPagedList<TDestination> ProjectToPagedList<TDestination>(this IQueryable queryable, MapperConfiguration config,
            int pageNumber, int pageSize)
        {
            return queryable.ProjectTo<TDestination>(config).Decompile().ToPagedList(pageNumber, pageSize);
        }
    }
}