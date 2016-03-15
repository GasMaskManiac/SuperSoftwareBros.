using ConnectionService.Connections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThreeAmigosWebApp.Controllers
{
    public class CatalogueController : Controller
    {
        public void Connect() {
            try {
                //Intialise connection to all services
                ConnectionService.Connections.DavisonService davison = new DavisonService();
                ConnectionService.Connections.CuttersService cutters = new CuttersService();
                ConnectionService.Connections.DealersService dealers = new DealersService();
                ConnectionService.Connections.KwikiService kwiki = new KwikiService();
                ConnectionService.Connections._3AmigoService _3amigos = new _3AmigoService();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Could not connect to Services" + e);
            }
 }
        //public IEnumerable<ThreeAmigosStoreServices.Models.ProductModel> GetProducts()
        //{
        //    var products = 
        //}

        

        [AllowAnonymous]
        // GET: Catalogue
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        // GET: Catalogue/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        // GET: Catalogue/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: Catalogue/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        // GET: Catalogue/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Authorize]
        // POST: Catalogue/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        // GET: Catalogue/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize]
        // POST: Catalogue/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
