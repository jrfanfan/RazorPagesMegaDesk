﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMegaDesk.Data;
using RazorPagesMegaDesk.Models;

namespace RazorPagesMegaDesk.Pages.Desks
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMegaDesk.Data.RazorPagesMegaDeskContext _context;

        public EditModel(RazorPagesMegaDesk.Data.RazorPagesMegaDeskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Desk Desk { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desk =  await _context.Desk.FirstOrDefaultAsync(m => m.Id == id);
            if (desk == null)
            {
                return NotFound();
            }
            Desk = desk;
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

            _context.Attach(Desk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskExists(Desk.Id))
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

        private bool DeskExists(int id)
        {
            return _context.Desk.Any(e => e.Id == id);
        }
    }
}
