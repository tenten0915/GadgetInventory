using Microsoft.AspNetCore.Mvc;
using GadgetInventory.Models;
using System.Collections.Generic;

namespace GadgetInventory.Controllers
{
    public class GadgetController : Controller
    {

        private static List<Gadget> gadgets = new List<Gadget>
        {
            new Gadget { Id = 1, Brand = "Apple", ModelName = "iPhone 13", Price = 799.00m },
            new Gadget { Id = 2, Brand = "Samsung", ModelName = "Galaxy S21", Price = 849.00m },
        };

        //GET: /Gadget/Index
        public IActionResult Index()
        {
            return View(gadgets);
        }
        
        //GET: /Gadget/Create (Display the blank form)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Gadget/Create (Process the form submission)
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Gadget newGadget)
        {
            if (!ModelState.IsValid)
            {
                return View(newGadget);
            }
            
            newGadget.Id = gadgets.Count + 1; 
            gadgets.Add(newGadget);

            return RedirectToAction("Index");
        }
    }
}

        