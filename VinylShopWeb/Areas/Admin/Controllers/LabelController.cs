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
    public class LabelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public LabelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Label> objLabelList = _unitOfWork.Label.GetAll();
            return View(objLabelList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Label obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Label.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Label created successfully";
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
            var labelFromDbFirst = _unitOfWork.Label.GetFirstOrDefault(u => u.Id == id);
            if (labelFromDbFirst == null)
            {
                return NotFound();
            }
            return View(labelFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Label obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Label.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Label updated successfully";
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
            var labelFromDbFirst = _unitOfWork.Label.GetFirstOrDefault(u => u.Id == id);
            if (labelFromDbFirst == null)
            {
                return NotFound();
            }
            return View(labelFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Label.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Label.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Label deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
