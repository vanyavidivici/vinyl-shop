using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinylShop.DataAccess;
using VinylShop.DataAccess.Repository.IRepository;
using VinylShop.Models;
using VinylShop.Utility;

namespace VinylShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ManufacturerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ManufacturerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Manufacturer> objManufacturerList = _unitOfWork.Manufacturer.GetAll();
            return View(objManufacturerList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manufacturer obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Manufacturer.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Manufacturer created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var manufacturerFromDbFirst = _unitOfWork.Manufacturer.GetFirstOrDefault(u => u.Id == id);
            if (manufacturerFromDbFirst == null)
            {
                return NotFound();
            }
            return View(manufacturerFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Manufacturer obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Manufacturer.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Manufacturer updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var manufacturerFromDbFirst = _unitOfWork.Manufacturer.GetFirstOrDefault(u => u.Id == id);
            if (manufacturerFromDbFirst == null)
            {
                return NotFound();
            }
            return View(manufacturerFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Manufacturer.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Manufacturer.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Manufacturer deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
