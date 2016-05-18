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

            //var regions = _regionService.GetRegions().ToPagedList<Region>(page, 20);

            var regions = _regionService.GetRegions();

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Region, RegionViewModel>();
            });

            IMapper mapper2 = config2.CreateMapper();

            IList<RegionViewModel> regionView = mapper2.Map<IList<Region>, IList<RegionViewModel>>(regions);

            var modelPagedList = regionView.ToPagedList<RegionViewModel>(page, 2);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IPagedList<RegionViewModel>, PagedViewModel<RegionViewModel>>()
                    .ConvertUsing(new PagedListTypeConverter<RegionViewModel>());
            });

           
            IMapper mapper = config.CreateMapper();

            var viewModels = mapper.Map<IPagedList<RegionViewModel>, PagedViewModel<RegionViewModel>>(modelPagedList);
            //var viewModels = Mapper.Map<PagedList<Region>, PagedList<RegionViewModel>>(regions);



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