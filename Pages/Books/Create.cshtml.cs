﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LAB_2.Data;
using LAB_2.Models;

namespace LAB_2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly LAB_2.Data.LAB_2Context _context;

        public CreateModel(LAB_2.Data.LAB_2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            var authors = _context.Set<Author>().ToList(); // Obține lista de autori
            if (authors.Count > 0)
            {
                ViewData["AuthorID"] = new SelectList(authors, "ID", "FirstName", "LastName"); // Adaugă autori
            }
            else
            {
                ViewData["AuthorID"] = new SelectList(Enumerable.Empty<Author>(), "ID", "FirstName"); // Adaugă un select gol
            }

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
