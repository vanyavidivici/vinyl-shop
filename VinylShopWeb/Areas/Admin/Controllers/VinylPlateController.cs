using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VinylShop.DataAccess;
using VinylShop.DataAccess.Repository.IRepository;
using VinylShop.Models;
using VinylShop.Utility;

namespace VinylShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class VinylPlateController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public VinylPlateController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        //GET
        public IActionResult Upsert(int? id)
        {
            VinylPlate vinylPlate = new VinylPlate();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select( u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
            IEnumerable<SelectListItem> AuthorList = _unitOfWork.Author.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
            IEnumerable<SelectListItem> LabelList = _unitOfWork.Label.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
            if (id == null || id == 0)
            {
                // create
                ViewBag.CategoryList = CategoryList;
                ViewBag.AuthorList = AuthorList;
                ViewBag.LabelList = LabelList;
                return View(vinylPlate);
            }
            else
            {
                // update
                ViewBag.CategoryList = CategoryList;
                ViewBag.AuthorList = AuthorList;
                ViewBag.LabelList = LabelList;
                vinylPlate = _unitOfWork.VinylPlate.GetFirstOrDefault(u => u.Id == id);
                return View(vinylPlate);
            }
            
            
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(VinylPlate obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\vinylplates");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.ImageUrl = @"\images\vinylplates\" + fileName + extension;
                }
                if (obj.Id == 0)
                {
                    _unitOfWork.VinylPlate.Add(obj);
                }
                else
                {
                    _unitOfWork.VinylPlate.Update(obj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Vinyl plate created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(string price)
        {

            var vinylPlatesList = _unitOfWork.VinylPlate.GetAll(includeProperties: "Category,Author,Label");
            
            switch (price)
            {
                case "topFive":
                    vinylPlatesList = vinylPlatesList.Where(u => u.Price == 1570);
                    break;
                default:
                    break;
            }

            return Json(new { data = vinylPlatesList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.VinylPlate.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.VinylPlate.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Success" });
        }
        #endregion
    }
}
