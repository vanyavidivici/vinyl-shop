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
    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Author> objAuthorList = _unitOfWork.Author.GetAll();
            return View(objAuthorList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Author.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Author created successfully";
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
            var authorFromDbFirst = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == id);
            if (authorFromDbFirst == null)
            {
                return NotFound();
            }
            return View(authorFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Author.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Author updated successfully";
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
            var authorFromDbFirst = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == id);
            if (authorFromDbFirst == null)
            {
                return NotFound();
            }
            return View(authorFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Author.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Author deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
