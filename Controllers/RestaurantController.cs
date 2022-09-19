using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace RestaurantDemo.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            RestaurantBusinessLayer restaurantBusinessLayer = new RestaurantBusinessLayer();

            List<Restaurant> restaurants = restaurantBusinessLayer.restaurants.ToList();
            return View(restaurants);
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {

            RestaurantBusinessLayer restaurantBusinessLayer = new RestaurantBusinessLayer();

            Restaurant restaurant = restaurantBusinessLayer.restaurants.Single(rest => rest.RestaurantID== id);
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                RestaurantBusinessLayer restaurantBusinessLayer = new RestaurantBusinessLayer();
                restaurantBusinessLayer.AddRestaurant(restaurant);
                return RedirectToAction("Index", "Restaurant");
            }
            return View();
        }

        // GET: Restaurant/Edit/5

        [HttpGet]
        public ActionResult Edit(int id)
        {
            RestaurantBusinessLayer restaurantBusinessLayer = new RestaurantBusinessLayer();
            Restaurant restaurant = restaurantBusinessLayer.restaurants.Single(rest => rest.RestaurantID == id);
            return View(restaurant);
        }


        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {

                RestaurantBusinessLayer restaurantBusinessLayer = new RestaurantBusinessLayer();
                restaurantBusinessLayer.UpdateRestaurant(restaurant);
                return RedirectToAction("Index", "Restaurant");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            RestaurantBusinessLayer restaurantBusinessLayer = new RestaurantBusinessLayer();
            Restaurant restaurant = restaurantBusinessLayer.restaurants.Single(rest => rest.RestaurantID == id);
            return View(restaurant);
        }
        [HttpPost]
        public ActionResult Delete(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {

                RestaurantBusinessLayer restaurantBusinessLayer = new RestaurantBusinessLayer();
                restaurantBusinessLayer.DeleteRestaurant(restaurant);
                return RedirectToAction("Index", "Restaurant");
            }
            return View();
        }
    }
}
