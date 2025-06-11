using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMegaDesk.Data;
using RazorPagesMegaDesk.Models;

namespace RazorPagesMegaDesk.Pages.Desks
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMegaDesk.Data.RazorPagesMegaDeskContext _context;

        public DeleteModel(RazorPagesMegaDesk.Data.RazorPagesMegaDeskContext context)
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

            var desk = await _context.Desk.FirstOrDefaultAsync(m => m.Id == id);

            if (desk is not null)
            {
                Desk = desk;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desk = await _context.Desk.FindAsync(id);
            if (desk != null)
            {
                Desk = desk;
                _context.Desk.Remove(Desk);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
