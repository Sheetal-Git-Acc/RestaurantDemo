using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
namespace RestaurantDemo.Controllers
{
    // public class CuisineController : Controller
    // {
    // GET: Cuisine
    //   public ActionResult Index()
    // {
    //    return View();
    // }
    // }


    public class CuisineController : Controller
    {

      //  [HttpGet]
        public ActionResult Index()
        {


            CuisineBusinessLayer cuisineBusinessLayer = new CuisineBusinessLayer();
            List<Cuisine> cuisines = cuisineBusinessLayer.Cuisines.ToList();
            return View(cuisines);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                CuisineBusinessLayer cuisineBusinessLayer = new CuisineBusinessLayer();
                cuisineBusinessLayer.AddCuisine(cuisine);
                return RedirectToAction("Index", "Cuisine");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CuisineBusinessLayer cuisineBusinessLayer = new CuisineBusinessLayer();
            Cuisine cuisine = cuisineBusinessLayer.Cuisines.Single(cus => cus.CuisineID == id);
            return View(cuisine);
        }


        [HttpPost]
        public ActionResult Edit(Cuisine cuisine)
        {
            if (ModelState.IsValid)
            {

                CuisineBusinessLayer cuisineBusinessLayer = new CuisineBusinessLayer();
                cuisineBusinessLayer.UpdateCuisine(cuisine);
                return RedirectToAction("Index", "Cuisine");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            CuisineBusinessLayer cuisineBusinessLayer = new CuisineBusinessLayer();
            Cuisine cuisine = cuisineBusinessLayer.Cuisines.Single(cus => cus.CuisineID == id);
            return View(cuisine);
        }
        [HttpPost]
        public ActionResult Delete(Cuisine cuisine)
       {
            if (ModelState.IsValid)
            {

                CuisineBusinessLayer cuisineBusinessLayer = new CuisineBusinessLayer();
              cuisineBusinessLayer.DeleteCuisine(cuisine);
                return RedirectToAction("Index", "Cuisine");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            CuisineBusinessLayer cuisineBusinessLayer = new CuisineBusinessLayer();

            Cuisine cuisine = cuisineBusinessLayer.Cuisines.Single(cus => cus.CuisineID == id);
            return View(cuisine);
        }
    }
}