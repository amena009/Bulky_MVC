using Bulky.DataAccess.Repository.IRepository;
using BulkyMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyMVCWebApp.Controllers
{
    //now whatever CategoryRepository we have created is already doing DbContext work
    //so insted of using ApplicationDbContext, we can directly use our repository
    public class CategoryController : Controller
    {
        //private readonly ApplicationDbContext _db;
        //private readonly ICategoryRepository _db;
        private readonly IUnitOfWork _db;  //coz now instead of ICategoryRepo, we are using UnitOfWork

        //public CategoryController(ApplicationDbContext db)
       // public CategoryController(ICategoryRepository db)
       public CategoryController(IUnitOfWork db)
        {
            _db = db;  
        }
        public IActionResult Index()
        {
            //List<Category> allCategories = _db.GetAll().ToList(); //using ICategoryRepo
            List<Category> allCategories = _db.Category.GetAll().ToList(); //in UnitOfWork we have to mention which registered repo we are using
            return View(allCategories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category createObj)
        {

            //custom validation-for ex, name and display order can't be same
            //this is server side validation
            if(createObj.Name == createObj.DisplayOrder.ToString())
            {
                //here adding our custom error to the model, here name is the form-control key
                ModelState.AddModelError("name", "Display order and Name cannot be same");
            }

            //here we are checking another validation,but giving any form-control
            //so if this error occurs, it'll not displayed under any form field, but will display under ErrorSummary
           
            //if (createObj.Name != null && createObj.Name.ToLower() == "test")
            //{
            //    //here adding our custom error to the model, here name is the form-control key
            //    ModelState.AddModelError("", "Display order and Name cannot be same");
            //}

            if (ModelState.IsValid)
            {
                //_db.Categories.Add(createObj);
                //_db.Add(createObj);
                _db.Category.Add(createObj);

                //_db.SaveChanges();
                _db.Save();  //we'll not mention category here coz save is in UnotOfWork, not in CategoryRepo

                //temp data value is only available for the next render.
                //on page refresh the value vanishes.
                //mainly used to show notification.
                TempData["success"] = "Category created successfully.";
                return RedirectToAction("Index");

            }
            return View();
        }

        
        public IActionResult Edit(int? id)
        {
            if(id == null || id  == 0)
            {
                return NotFound();
            }
            //Find works on primary key
            //Category categoryById = _db.Categories.Find(id);

            //it work even on non-primary fields also, like name etc
            //it'll return the record if exist, or return the null value
            // Category? categoryById = _db.Categories.FirstOrDefault(a => a.Id == id);
            // Category? categoryById = _db.Get(a => a.Id == id);
             Category? categoryById = _db.Category.Get(a => a.Id == id); //UnitOfWork


            //similar to FirstOrDefault but once you get data you can apply more functionalities
            // Category? categoryById = _db.Categories.Where(a => a.Id == id).FirstOrDefault();
            if (categoryById == null)
            {
                return NotFound();
            }

            
            return View(categoryById);
        }
        [HttpPost]
        public IActionResult Edit(Category createObj)
        {
            //since we don't have any ID form-control,it'll create a new record on top of the existing record
            //to update existing record,we should pass id properly(such as id as hidden field)
            if (ModelState.IsValid)
            {
                // _db.Categories.Update(createObj);
                //_db.SaveChanges();

                // _db.Update(createObj);
                _db.Category.Update(createObj); //UnitOfWork

                _db.Save();
                TempData["success"] = "Category edited successfully.";

                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Find works on primary key
            //Category categoryById = _db.Categories.Find(id);

            //it work even on non-primary fields also, like name etc
            //it'll return the record if exist, or return the null value
            //Category? categoryById = _db.Get(a => a.Id == id);
            Category? categoryById = _db.Category.Get(a => a.Id == id); //UnitOfWork


            //similar to FirstOrDefault but once you get data you can apply more functionalities
            // Category? categoryById = _db.Categories.Where(a => a.Id == id).FirstOrDefault();
            if (categoryById == null)
            {
                return NotFound();
            }


            return View(categoryById);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            // Category? obj = _db.Get(u =>  u.Id == id);
             Category? obj = _db.Category.Get(u =>  u.Id == id); //UnitOfWork

            if (obj == null)
            {
                return NotFound();
            }
            //_db.Remove(obj);
            _db.Category.Remove(obj); //UnitOfWork

            _db.Save();
            TempData["success"] = "Category deleted successfully.";

            return RedirectToAction("Index");
        }

    }
}
