using BulkyRAZORWebApp.Data;
using BulkyRAZORWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRAZORWebApp.Pages.Categorie
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        //with BindProperty attribute,our post obj will be binded to this property
        //and we don't have to pass any post obj in OnPost method
        [BindProperty]
        public Category category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {}

        public IActionResult OnPost() { 
            _db.Categories.Add(category);
          _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
