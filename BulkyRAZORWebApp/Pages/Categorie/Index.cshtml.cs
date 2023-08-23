using BulkyRAZORWebApp.Data;
using BulkyRAZORWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRAZORWebApp.Pages.Categorie
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db; 
        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
