using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trial_SubjectManager.Models;

namespace Trial_SubjectManager.Controllers
{
    public class SubTopicController : Controller
    {
        private readonly YourDbContext _context;

        public SubTopicController(YourDbContext context)
        {
            _context = context;
        }

        // GET: SubTopic
        public async Task<IActionResult> Index()
        {
            var yourDbContext = _context.SubTopics.Include(s => s.Topic);
            return View(await yourDbContext.ToListAsync());
        }

        // GET: SubTopic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTopic = await _context.SubTopics
                .Include(s => s.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subTopic == null)
            {
                return NotFound();
            }

            return View(Index);
        }

        // GET: SubTopic/Create
        public IActionResult Create()
        {
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id");
            return View();
        }

        // POST: SubTopic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,TopicId")] SubTopic subTopic)
        {
              _context.Add(subTopic);
                await _context.SaveChangesAsync();
            
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id", subTopic.TopicId);
            return View(subTopic);
        }

        // GET: SubTopic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTopic = await _context.SubTopics.FindAsync(id);
            if (subTopic == null)
            {
                return NotFound();
            }
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id", subTopic.TopicId);
            return View(subTopic);
        }

        // POST: SubTopic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,TopicId")] SubTopic subTopic)
        {
            if (id != subTopic.Id)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(subTopic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubTopicExists(subTopic.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id", subTopic.TopicId);
            return View(subTopic);
        }

        // GET: SubTopic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTopic = await _context.SubTopics
                .Include(s => s.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subTopic == null)
            {
                return NotFound();
            }

            return View(subTopic);
        }

        // POST: SubTopic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subTopic = await _context.SubTopics.FindAsync(id);
            if (subTopic != null)
            {
                _context.SubTopics.Remove(subTopic);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubTopicExists(int id)
        {
            return _context.SubTopics.Any(e => e.Id == id);
        }
    }
}
