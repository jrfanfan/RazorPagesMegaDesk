﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMegaDesk.Data.RazorPagesMegaDeskContext _context;

        public IndexModel(RazorPagesMegaDesk.Data.RazorPagesMegaDeskContext context)
        {
            _context = context;
        }

        public IList<Desk> Desk { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Desk = await _context.Desk.ToListAsync();
        }
    }
}
