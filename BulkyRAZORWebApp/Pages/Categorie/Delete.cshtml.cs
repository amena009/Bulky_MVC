using BulkyRAZORWebApp.Data;
using BulkyRAZORWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRAZORWebApp.Pages.Categorie
{
    [BindProperties]
    public class DeleteModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public Category category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        { 
            Category categoryById = _db.Categories.Find(category.Id);
            if (categoryById == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryById);
            _db.SaveChanges();  
            return Redirect("Index");
        }
    }
}
