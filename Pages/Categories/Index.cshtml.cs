using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hognogi_Daniela_Taisia_Laborator2.Data;
using Hognogi_Daniela_Taisia_Laborator2.Models;
using Hognogi_Daniela_Taisia_Laborator2.Models.ViewModels;

namespace Hognogi_Daniela_Taisia_Laborator2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Hognogi_Daniela_Taisia_Laborator2.Data.Hognogi_Daniela_Taisia_Laborator2Context _context;

        public IndexModel(Hognogi_Daniela_Taisia_Laborator2.Data.Hognogi_Daniela_Taisia_Laborator2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;
        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                    .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                var selectedCategory = CategoryData.Categories
                    .FirstOrDefault(c => c.ID == id.Value);
                if (selectedCategory != null)
                {
                    CategoryData.Books = selectedCategory.BookCategories
                        .Select(bc => bc.Book)
                        .ToList();
                }
            }
        }
    }
}

