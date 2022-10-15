using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AWork.Domain.Models;
using AWork.Persistence;
using AWork.Services.Abstraction;

namespace AWork.Web.Controllers.Production
{
    public class WorkOrdersController : Controller
    {
        private readonly AdventureWorks2019Context _context;
        private readonly IProductionServiceManager _productionServiceManager;

        public WorkOrdersController(AdventureWorks2019Context context, IProductionServiceManager productionServiceManager = null)
        {
            _context = context;
            _productionServiceManager = productionServiceManager;
        }

        // GET: WorkOrders
        public async Task<IActionResult> Index()
        {
            /*var adventureWorks2019Context = _context.WorkOrders.Include(w => w.Product).Include(w => w.ScrapReason);
            return View(await adventureWorks2019Context.ToListAsync());*/
            var orderWorkModel = await _productionServiceManager.WorkOrderService.GetAllWorkOrder(false);
            return View(orderWorkModel);
        }

        // GET: WorkOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrders
                .Include(w => w.Product)
                .Include(w => w.ScrapReason)
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return View(workOrder);
        }

        // GET: WorkOrders/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name");
            ViewData["ScrapReasonId"] = new SelectList(_context.ScrapReasons, "ScrapReasonId", "Name");
            return View();
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOrderId,ProductId,OrderQty,StockedQty,ScrappedQty,StartDate,EndDate,DueDate,ScrapReasonId,ModifiedDate")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", workOrder.ProductId);
            ViewData["ScrapReasonId"] = new SelectList(_context.ScrapReasons, "ScrapReasonId", "Name", workOrder.ScrapReasonId);
            return View(workOrder);
        }

        // GET: WorkOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrders.FindAsync(id);
            if (workOrder == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", workOrder.ProductId);
            ViewData["ScrapReasonId"] = new SelectList(_context.ScrapReasons, "ScrapReasonId", "Name", workOrder.ScrapReasonId);
            return View(workOrder);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkOrderId,ProductId,OrderQty,StockedQty,ScrappedQty,StartDate,EndDate,DueDate,ScrapReasonId,ModifiedDate")] WorkOrder workOrder)
        {
            if (id != workOrder.WorkOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderExists(workOrder.WorkOrderId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", workOrder.ProductId);
            ViewData["ScrapReasonId"] = new SelectList(_context.ScrapReasons, "ScrapReasonId", "Name", workOrder.ScrapReasonId);
            return View(workOrder);
        }

        // GET: WorkOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrders
                .Include(w => w.Product)
                .Include(w => w.ScrapReason)
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return View(workOrder);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrder = await _context.WorkOrders.FindAsync(id);
            _context.WorkOrders.Remove(workOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderExists(int id)
        {
            return _context.WorkOrders.Any(e => e.WorkOrderId == id);
        }
    }
}
