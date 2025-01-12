﻿using Microsoft.AspNetCore.Mvc;
using proj2_tutorialPL.Models;
using proj2_tutorialPL.Services.Interfaces;
using System.Xml.Linq;

namespace proj2_tutorialPL.Controllers
{
	public class ProductController : Controller
	{
		private readonly IWarehouseService _warehouseService;
        public ProductController(IWarehouseService warehouseService)
        {
            
        }


        public IActionResult Index()
		{
			return View();
		}
		public IActionResult Product()
		{
			var product = new Models.Product
			{
				Id = 1,
				Category = "samochód",
				Description = "Super samochód",
				Name = "Bmw M6",
				Model = "ZX2",
				Fuel_burning = 6
				

			};
			return View(product);
		}
		public IActionResult List() {

			var productList = _warehouseService.GetAll();
			return View(productList);
		}
		public IActionResult Data() {

			ViewBag.Name = "Jarek";
			ViewData["Surename"] = "Kowalski";
			TempData["SecondName"] = "Piotrek";
			return View();
		}
	}
}
