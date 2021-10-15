using CakeManagements.Entities;
using CakeManagements.Models.Cake;
using CakeManagements.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeManagements.Controllers
{
    public class CakeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ICakeService cakeService;
        private static Category category = new Category();

        public CakeController(ICategoryService categoryService, ICakeService cakeService)
        {
            this.categoryService = categoryService;
            this.cakeService = cakeService;
        }
        [Route("/Cake/Index/{catId}")]
        public IActionResult Index(int catId)
        {
            category = categoryService.Get(catId);
            ViewBag.Category = category;
            return View(cakeService.GetCakeByCategory(catId));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = category;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Create model)
        {
            if (ModelState.IsValid)
            {
                model.CategoryId = category.CategoryId;
                var cake = new Cake()
                {
                    CategoryId = model.CategoryId,
                    CakeName = model.CakeName,
                    Ingredient = model.Ingredient,
                    Expiry = model.Expiry,
                    DateOfManufacture = model.DateOfManufacture,
                    Price = model.Price,
                    Deleted = model.Deleted
                };
                if (cakeService.CreateCake(cake))
                {
                    return RedirectToAction("Index", new { catId = category.CategoryId });
                }
            }
            ViewBag.Category = category;
            return View(model);
        }
        [HttpGet]
        [Route("Cake/Edit/{catId}")]
        public IActionResult Edit (int cakeId)
        {
            var cake = cakeService.Get(cakeId);
            var edit = new Edit()
            {
                CategoryId = cake.CategoryId,
                CakeId = cake.CakeId,
                CakeName = cake.CakeName,
                Ingredient = cake.Ingredient,
                Expiry = cake.Expiry,
                DateOfManufacture = cake.DateOfManufacture,
                Price = cake.Price,
                Deleted = cake.Deleted
            };
            ViewBag.Category = category;
            return View(edit);
        }
        [HttpPost("Cake/Edit/{cakeId}")]
        public IActionResult Edit (Edit model)
        {
            if (ModelState.IsValid)
            {
                var cake = cakeService.Get(model.CakeId);
                cake.CategoryId = model.CakeId;
                cake.CakeId = model.CakeId;
                cake.CakeName = model.CakeName;
                cake.Ingredient = model.Ingredient;
                cake.Expiry = model.Expiry;
                cake.DateOfManufacture = model.DateOfManufacture;
                cake.Price = model.Price;
                cake.Deleted = model.Deleted;
                if (cakeService.EditCake(cake))
                {
                    return RedirectToAction("Index", "Cake", new { catId = model.CategoryId });
                }
            }
            ViewBag.Category = category;
            return View(model);     
        }
        [HttpGet]
        [Route("Cake/Detail/{Id}")]
        public IActionResult Detail(int cakeId)
        {
            var cake = cakeService.Get(cakeId);
            var detail = new Detail()
            {
                CategoryId = cake.CategoryId,
                CakeId = cake.CakeId,
                CakeName = cake.CakeName,
                Ingredient = cake.Ingredient,
                Expiry = cake.Expiry,
                DateOfManufacture = cake.DateOfManufacture,
                Price = cake.Price,
                Deleted = cake.Deleted,
            };
            ViewBag.Category = category;
            return View(detail);
        }
    }
}
