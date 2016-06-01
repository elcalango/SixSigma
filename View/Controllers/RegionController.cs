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

        public ActionResult ListRegions(int page = 1)
        {
            _regionService = new RegionService();

            var regions = _regionService.GetRegions();

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Region, RegionViewModel>();
            });

            IMapper mapper2 = config2.CreateMapper();

            IList<RegionViewModel> regionViewModel = mapper2.Map<IList<Region>, IList<RegionViewModel>>(regions);

            var modelPagedList = regionViewModel.ToPagedList<RegionViewModel>(page, 2);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IPagedList<RegionViewModel>, PagedViewModel<RegionViewModel>>()
                    .ConvertUsing(new PagedListTypeConverter<RegionViewModel>());
            });


            IMapper mapper = config.CreateMapper();

            var viewModels = mapper.Map<IPagedList<RegionViewModel>, PagedViewModel<RegionViewModel>>(modelPagedList);


            return View(viewModels);
        }


        // GET: Region
        //public ActionResult ListRegions(int page = 1)
        //{
        //    _regionService = new RegionService(); 

        //    var regions = _regionService.GetRegions();

        //    var config2 = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Region, RegionViewModel>();
        //    });

        //    IMapper mapper2 = config2.CreateMapper();

        //    IList<RegionViewModel> regionViewModel = mapper2.Map<IList<Region>, IList<RegionViewModel>>(regions);

        //    var modelPagedList = regionViewModel.ToPagedList<RegionViewModel>(page, 2);

        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<IPagedList<RegionViewModel>, PagedViewModel<RegionViewModel>>()
        //            .ConvertUsing(new PagedListTypeConverter<RegionViewModel>());
        //    });


        //    IMapper mapper = config.CreateMapper();

        //    var viewModels = mapper.Map<IPagedList<RegionViewModel>, PagedViewModel<RegionViewModel>>(modelPagedList);


        //    return View(viewModels);
        //}

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

     


}