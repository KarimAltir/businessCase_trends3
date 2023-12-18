using buisnessCase_trends3.Data;
using buisnessCase_trends3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace buisnessCase_trends3.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaderboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Show()
        {
            List<LeaderboardEntry> rankedEntries = _context.LeaderboardEntries
                .Include(u => u.User)
                .OrderByDescending(e => e.User.Points)
                .ToList();

            int rank = 1;
            foreach (var entry in rankedEntries)
            {
                entry.Rank = rank;
                rank++;
            }

            return View(rankedEntries);
        }
    }
}
