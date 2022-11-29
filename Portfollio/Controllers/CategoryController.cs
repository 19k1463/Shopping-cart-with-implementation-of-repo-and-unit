using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MyApp.DataAccessLayer.data;
using MyApp.Models;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.DataAccessLayer.Infrastructure.Repository;

namespace Portfollio.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitofWork;
        public CategoryController(IUnitOfWork unitofwork)
        {
            _unitofWork = unitofwork;

        }
        public IActionResult index()
        {
            IEnumerable<Category> categories = _unitofWork.Category.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.Category.Add(category);
                _unitofWork.Save();
                TempData["success"] = "Category Created done";
                return RedirectToAction("Index");
            }
            return View(category);

        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var category = _unitofWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.Category.Update(category);
                _unitofWork.Save();
                TempData["success"] = "Category Updated Done!";
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();

            }
            var category = _unitofWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();

            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var category = _unitofWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitofWork.Category.Delete(category);
            _unitofWork.Save();
            TempData["success"] = "Category Deleted done";
            return RedirectToAction("Index");

        }




    }

}
