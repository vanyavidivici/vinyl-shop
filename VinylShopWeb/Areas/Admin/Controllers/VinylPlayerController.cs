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
    public class VinylPlayerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public VinylPlayerController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
            VinylPlayer vinylPlayer = new VinylPlayer();
            IEnumerable<SelectListItem> ManufacturerList = _unitOfWork.Manufacturer.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
            if (id == null || id == 0)
            {
                // create
                ViewBag.ManufacturerList = ManufacturerList;
                return View(vinylPlayer);
            }
            else
            {
                // update
                ViewBag.ManufacturerList = ManufacturerList;
                vinylPlayer = _unitOfWork.VinylPlayer.GetFirstOrDefault(u => u.Id == id);
                return View(vinylPlayer);
            }
            
            
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(VinylPlayer obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\vinylplayers");
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
                    obj.ImageUrl = @"\images\vinylplayers\" + fileName + extension;
                }
                if (obj.Id == 0)
                {
                    _unitOfWork.VinylPlayer.Add(obj);
                }
                else
                {
                    _unitOfWork.VinylPlayer.Update(obj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Vinyl player created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
 
      

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var vinylPlayersList = _unitOfWork.VinylPlayer.GetAll(includeProperties:"Manufacturer");
            return Json(new { data = vinylPlayersList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.VinylPlayer.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.VinylPlayer.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Success" });
        }
        #endregion
    }
}
