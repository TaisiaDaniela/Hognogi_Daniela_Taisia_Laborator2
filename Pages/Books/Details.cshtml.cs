﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hognogi_Daniela_Taisia_Laborator2.Data;
using Hognogi_Daniela_Taisia_Laborator2.Models;

namespace Hognogi_Daniela_Taisia_Laborator2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Hognogi_Daniela_Taisia_Laborator2.Data.Hognogi_Daniela_Taisia_Laborator2Context _context;

        public DetailsModel(Hognogi_Daniela_Taisia_Laborator2.Data.Hognogi_Daniela_Taisia_Laborator2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
        .Include(b => b.Author)
        .Include(b => b.Publisher)
        .Include(b => b.BookCategories) 
            .ThenInclude(bc => bc.Category) 
        .FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}
