using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AWork.Domain.Models;
using AWork.Persistence;

namespace AWork.Web.Controllers.Production
{
    public class WorkOrderRoutingsController : Controller
    {
        private readonly AdventureWorks2019Context _context;

        public WorkOrderRoutingsController(AdventureWorks2019Context context)
        {
            _context = context;
        }

        // GET: WorkOrderRoutings
        public async Task<IActionResult> Index()
        {
            var adventureWorks2019Context = _context.WorkOrderRoutings.Include(w => w.Location).Include(w => w.WorkOrder);
            return View(await adventureWorks2019Context.ToListAsync());
        }

        // GET: WorkOrderRoutings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderRouting = await _context.WorkOrderRoutings
                .Include(w => w.Location)
                .Include(w => w.WorkOrder)
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrderRouting == null)
            {
                return NotFound();
            }

            return View(workOrderRouting);
        }

        // GET: WorkOrderRoutings/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Name");
            ViewData["WorkOrderId"] = new SelectList(_context.WorkOrders, "WorkOrderId", "WorkOrderId");
            return View();
        }

        // POST: WorkOrderRoutings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOrderId,ProductId,OperationSequence,LocationId,ScheduledStartDate,ScheduledEndDate,ActualStartDate,ActualEndDate,ActualResourceHrs,PlannedCost,ActualCost,ModifiedDate")] WorkOrderRouting workOrderRouting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrderRouting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Name", workOrderRouting.LocationId);
            ViewData["WorkOrderId"] = new SelectList(_context.WorkOrders, "WorkOrderId", "WorkOrderId", workOrderRouting.WorkOrderId);
            return View(workOrderRouting);
        }

        // GET: WorkOrderRoutings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderRouting = await _context.WorkOrderRoutings.FindAsync(id);
            if (workOrderRouting == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Name", workOrderRouting.LocationId);
            ViewData["WorkOrderId"] = new SelectList(_context.WorkOrders, "WorkOrderId", "WorkOrderId", workOrderRouting.WorkOrderId);
            return View(workOrderRouting);
        }

        // POST: WorkOrderRoutings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkOrderId,ProductId,OperationSequence,LocationId,ScheduledStartDate,ScheduledEndDate,ActualStartDate,ActualEndDate,ActualResourceHrs,PlannedCost,ActualCost,ModifiedDate")] WorkOrderRouting workOrderRouting)
        {
            if (id != workOrderRouting.WorkOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrderRouting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderRoutingExists(workOrderRouting.WorkOrderId))
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
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Name", workOrderRouting.LocationId);
            ViewData["WorkOrderId"] = new SelectList(_context.WorkOrders, "WorkOrderId", "WorkOrderId", workOrderRouting.WorkOrderId);
            return View(workOrderRouting);
        }

        // GET: WorkOrderRoutings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderRouting = await _context.WorkOrderRoutings
                .Include(w => w.Location)
                .Include(w => w.WorkOrder)
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrderRouting == null)
            {
                return NotFound();
            }

            return View(workOrderRouting);
        }

        // POST: WorkOrderRoutings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrderRouting = await _context.WorkOrderRoutings.FindAsync(id);
            _context.WorkOrderRoutings.Remove(workOrderRouting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderRoutingExists(int id)
        {
            return _context.WorkOrderRoutings.Any(e => e.WorkOrderId == id);
        }
    }
}
