﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAB_2.Data;
using LAB_2.Models;

namespace LAB_2.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly LAB_2.Data.LAB_2Context _context;

        public EditModel(LAB_2.Data.LAB_2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Book = _context.Book.Include(b => b.Publisher).Include(b => b.Author).FirstOrDefault(b => b.ID == id);

            if (Book == null)
            {
                return NotFound();
            }

            ViewData["Title"] = "Edit"; // Aceasta linie este OK

            // Populează lista de editori
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");

            // Populează lista de autori
            var authors = _context.Author.ToList();
            ViewData["AuthorID"] = new SelectList(authors, "ID", "FullName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.ID == id);
        }
    }
}
