using Microsoft.AspNetCore.Mvc;
using WebProject.DataAccess.Repository;
using WebProject.DataAccess.Repository.IRepository;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Action to display a list of categories
        public IActionResult Index()
        {
            // Retrieve a list of categories from the database
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        // Action to display the form for creating a new category
        public IActionResult Create()
        {
            return View();
        }

        // POST action to handle the creation of a new category
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            // Add custom validation server side, the other validation is done client side
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Name cannot exactly match the Display Order.");
            }
            if (ModelState.IsValid)
            {
                // Add the category to the database and redirect to the index page
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            // Return to the create.cshtml view if the model is not valid
            return View();
        }

        // Action to display the form for editing an existing category
        public IActionResult Edit(int? id)
        {
            // Retrieve a category for editing by ID
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u=>u.Id == id);
            //Category? categoryFromDb2 = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //Category? categoryFromDb3 = _db.Categories.Where(u=>u.Id == id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        // POST action to handle the editing of an existing category
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            // Update the category in the database and redirect to the index page
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            // Return to the edit view if the model is not valid
            return View();
        }

        // Action to display the form for deleting an existing category
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // Retrieve a category for deletion by ID, 3 different ways of doing so
            Category? categoryFromDb = _unitOfWork.Category.Get(u=>u.Id == id);
            //Category? categoryFromDb2 = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //Category? categoryFromDb3 = _db.Categories.Where(u=>u.Id == id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        // POST action to handle the deletion of an existing category
        // Can't use Delete as name as already have an action named that with same parameters
        // But must use action name as Delete as that is the action the form submit will call
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}