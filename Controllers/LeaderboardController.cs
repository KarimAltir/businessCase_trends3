using buisnessCase_trends3.Data;
using buisnessCase_trends3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace buisnessCase_trends3.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaderboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<LeaderboardEntry> CalculateRanks(List<LeaderboardEntry> _entries)
        {
            List<LeaderboardEntry> entries = _entries.OrderByDescending(e => e.Points).ToList();

            int rank = 1;
            foreach (var entry in entries)
            {
                entry.Rank = rank;
                rank++;
            }

            return entries;
        }

        public IActionResult Show()
        {
            List<LeaderboardEntry> rankedEntries = CalculateRanks(_context.LeaderboardEntries
                .Include(u => u.User)
                .ToList());

            return View(rankedEntries);
        }
    }
}
