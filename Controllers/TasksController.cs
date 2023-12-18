using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using buisnessCase_trends3.Data;
using buisnessCase_trends3.Models;


namespace buisnessCase_trends3.Controllers
{

    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        


        // GET: Tasks
        public async Task<IActionResult> Index(int? selectedUserId)
        {
            ViewBag.Users = await _context.Users.ToListAsync();

            if (selectedUserId.HasValue)
            {
                ViewBag.SelectedUserId = selectedUserId.Value;

                var tasks = await _context.Task
                    .Where(t => t.UserId == selectedUserId || t.UserId == null)
                    .Include(t => t.User)
                    .ToListAsync();

                return View(tasks);
            }

            ViewBag.SelectedUserId = null;

            var allTasks = await _context.Task.Include(t => t.User).ToListAsync();
            return View(allTasks);



            //try
            //{
            //    return View(await _context.Task.ToListAsync());
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error en la acción Index: {ex}");
            //    throw;
            //}

            //ViewBag.Users = await _context.Users.ToListAsync();
            //return View(await _context.Task.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {


            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskName,TaskDescription,Points,UserId,Completed")] Models.Task task)
        {
            task.UserId = null;
            task.Completed = false;

            Console.WriteLine("hay un error");

            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Model error: {error.ErrorMessage}");
                }
                return View(task);
            }
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var task = await _context.Task.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskName,TaskDescription,Points")] Models.Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Task == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Task'  is null.");
            }
            var task = await _context.Task.FindAsync(id);
            if (task != null)
            {
                _context.Task.Remove(task);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return (_context.Task?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        [HttpPost]
        public async Task<IActionResult> Complete(int taskId, int userId)
        {
            
                var task = await _context.Task.FindAsync(taskId);
                var user = await _context.Users.FindAsync(userId);

                if (task != null && user != null && (task.Completed == null || task.Completed == false))

                {
                    task.Completed = true;
                    task.UserId = userId;
                    user.Points += task.Points;
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            


        }
    }

