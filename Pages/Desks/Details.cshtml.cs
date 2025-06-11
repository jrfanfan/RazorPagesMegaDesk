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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMegaDesk.Data.RazorPagesMegaDeskContext _context;

        public DetailsModel(RazorPagesMegaDesk.Data.RazorPagesMegaDeskContext context)
        {
            _context = context;
        }

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
    }
}
