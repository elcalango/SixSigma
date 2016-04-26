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

namespace View.Controllers
{
    public class RegionController : Controller
    {
        private RegionService _regionService;
        // GET: Region
        public ActionResult ListRegions(int page = 1)
        {
            _regionService = new RegionService();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Region, RegionViewModel>();
            });

            IMapper mapper = config.CreateMapper();

            var regions = _regionService.GetRegions().ToPagedList(page, 2);

            

            var model = mapper.Map<IPagedList<Region>, IPagedList<RegionViewModel>>(regions);

            //IMapper mapper = Mapper.CreateMap<Region, RegionViewModel>();
            //Mapper
            //   .CreateMap<PagedList<Region>, PagedList<RegionViewModel>>()
            //   .ConvertUsing<PagedListConverter>();

            //model = mapper.ToMappedPagedList<Region, RegionViewModel>(regions);
            return View(model);
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

        //public static IPagedList<TDestination> ToMappedPagedList<TSource, TDestination>(this IPagedList<TSource> list)
        //{
        //    IEnumerable<TDestination> sourceList = Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
        //    IPagedList<TDestination> pagedResult = new StaticPagedList<TDestination>(sourceList, list.GetMetaData());
        //    return pagedResult;

        //}

    
        /// <summary>       
        /// Search LossReserve by filter as parameter - History       
        /// </summary>       
        /// <param name="filter">filter parameters</param>        
        /// <returns>A <see cref="ApplicationUserSearchResult"/></returns>        
        //public IPagedList<LossReserveResult> GetLossReserveHistoryByCoverageId(LossReserveHistory filter)
        //{
        //    var lossReserveFilter = filter.Map(new BusinessModel.EntityCustom.LossReserveFilter());
        //    var lossReserveResult = this.lossReserveBusiness.GetLossReserveHistoryByCoverageId(lossReserveFilter);
        //    var lossReserves = lossReserveResult.Result.Map(new List<LossReserveResult>());
        //    var pagedList = new StaticPagedList<LossReserveResult>(lossReserves, lossReserveResult.Offset, lossReserveResult.Limit, lossReserveResult.Count);
        //    return pagedList;
        //}
    }
}