﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cinematix.Data;
using Cinematix.Models;

namespace Cinematix
{
    public class DetailsModel : PageModel
    {
        private readonly Cinematix.Data.CinematixContext _context;

        public DetailsModel(Cinematix.Data.CinematixContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
        
    }
}
