using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {

       private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        // GET
        public IActionResult Index()
        {
            IEnumerable<Product> objList = _db.Products;

            foreach (var obj in objList)
            {
                obj.Category = _db.Categories.FirstOrDefault(u => u.Id == obj.CategoryId);
            }
            return View(objList);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        
        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategotyDropDown = _db.Categories.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            
            });
            ViewBag.CategotyDropDown = CategotyDropDown;
            Product product = new Product();
            if (id == null)
            {
                return View(product);
            }
            else
            {
                product = _db.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            
        }
        //POST-UPSERT
        
        
        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            

        }
    }
}