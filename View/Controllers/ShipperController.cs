using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;
using PagedList;

namespace View.Controllers
{
    public class ShipperController : Controller
    {
        private ShipperService _shipperService;

        public ActionResult Index(string searchTerm = null, int page = 1)
        {

            _shipperService = new ShipperService();
            var shippers = _shipperService.GetShippers(searchTerm);

            var shippersVM = new List<ShipperViewModel>();

            foreach (var item in shippers)
            {
                shippersVM.Add(new ShipperViewModel
                {
                    ShipperID = item.ShipperID,
                    CompanyName = item.CompanyName,
                    Phone = item.Phone
                });
            }


            if (shippersVM != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Shipper", shippersVM.ToPagedList(page, 2));
                }
                return View(shippersVM.ToPagedList(page, 2));
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Create (ShipperViewModel shipper)
        {
            _shipperService = new ShipperService();

            if (ModelState.IsValid)
            {
                _shipperService.CreateShipper(new DTO.Shipper
                {
                    ShipperID = shipper.ShipperID,
                    CompanyName = shipper.CompanyName,
                    Phone = shipper.Phone
                });

                return RedirectToAction("Index");
            }

            return View(shipper);
        }

        public ActionResult Create( )
        {
            _shipperService = new ShipperService(); 

            return View();
        }
    }
}