using AWork.Contracts.Dto.Purchasing;
using AWork.Domain.Models;
using AWork.Persistence;
using AWork.Services.Abstraction;
using AWork.Services.Purchasing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Web.Controllers.Purchasing
{
    public class PurchaseOrderHeadersController : Controller
    {
        private readonly AdventureWorks2019Context _context;
        private readonly IPurchasingServiceManager _serviceContext;

        public PurchaseOrderHeadersController(AdventureWorks2019Context context, IPurchasingServiceManager serviceContext)
        {
            _context = context;
            _serviceContext = serviceContext;
        }

        // GET: PurchaseOrderHeaders
        public async Task<IActionResult> Index()
        {
            var purchaseOH = await _context.PurchaseOrderHeaders.ToListAsync();
            var purchaseOHDto = await _serviceContext.PurchaseOrderHeaderService.GetAllPurchaseOH(false);
            return View(purchaseOHDto);
        }

        // GET: PurchaseOrderHeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var purchaseOrderHeader = await _context.PurchaseOrderHeaders
                .Include(p => p.Employee)
                .Include(p => p.ShipMethod)
                .Include(p => p.Vendor)
                .FirstOrDefaultAsync(m => m.PurchaseOrderId == id);*/
            var purchaseOHDto = await _serviceContext.PurchaseOrderHeaderService.GetPurchaseOHById((int)id, false);
            if (purchaseOHDto == null)
            {
                return NotFound();
            }

            return View(purchaseOHDto);
        }

        // GET: PurchaseOrderHeaders/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "BusinessEntityId", "Gender");
            ViewData["ShipMethodId"] = new SelectList(_context.ShipMethods, "ShipMethodId", "Name");
            ViewData["VendorId"] = new SelectList(_context.Vendors, "BusinessEntityId", "AccountNumber");
            return View();
        }

        // POST: PurchaseOrderHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseOrderId,RevisionNumber,Status,EmployeeId,VendorId,ShipMethodId,OrderDate,ShipDate,SubTotal,TaxAmt,Freight,TotalDue,ModifiedDate")] PurchaseOrderHeaderForCreateDto purchaseOrderHeaderForCreateDto)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(purchaseOrderHeader);
                await _context.SaveChangesAsync();*/
                _serviceContext.PurchaseOrderHeaderService.Insert(purchaseOrderHeaderForCreateDto);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "BusinessEntityId", "Gender", purchaseOrderHeaderForCreateDto.EmployeeId);
            ViewData["ShipMethodId"] = new SelectList(_context.ShipMethods, "ShipMethodId", "Name", purchaseOrderHeaderForCreateDto.ShipMethodId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "BusinessEntityId", "AccountNumber", purchaseOrderHeaderForCreateDto.VendorId);
            return View(purchaseOrderHeaderForCreateDto);
        }

        // GET: PurchaseOrderHeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var purchaseOrderHeader = await _context.PurchaseOrderHeaders.FindAsync(id);*/
            var purchaseOrderHeader = await _serviceContext.PurchaseOrderHeaderService.GetPurchaseOHById((int)id, true);
            if (purchaseOrderHeader == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "BusinessEntityId", "Gender", purchaseOrderHeader.EmployeeId);
            ViewData["ShipMethodId"] = new SelectList(_context.ShipMethods, "ShipMethodId", "Name", purchaseOrderHeader.ShipMethodId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "BusinessEntityId", "AccountNumber", purchaseOrderHeader.VendorId);
            return View(purchaseOrderHeader);
        }

        // POST: PurchaseOrderHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseOrderId,RevisionNumber,Status,EmployeeId,VendorId,ShipMethodId,OrderDate,ShipDate,SubTotal,TaxAmt,Freight,TotalDue,ModifiedDate")] PurchaseOrderHeaderDto purchaseOrderHeaderDto)
        {
            if (id != purchaseOrderHeaderDto.PurchaseOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(purchaseOrderHeader);
                    await _context.SaveChangesAsync();*/
                    _serviceContext.PurchaseOrderHeaderService.Edit(purchaseOrderHeaderDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!PurchaseOrderHeaderExists(purchaseOrderHeaderDto.PurchaseOrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                    }*/
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "BusinessEntityId", "Gender", purchaseOrderHeaderDto.EmployeeId);
            ViewData["ShipMethodId"] = new SelectList(_context.ShipMethods, "ShipMethodId", "Name", purchaseOrderHeaderDto.ShipMethodId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "BusinessEntityId", "AccountNumber", purchaseOrderHeaderDto.VendorId);
            return View(purchaseOrderHeaderDto);
        }

        // GET: PurchaseOrderHeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var purchaseOrderHeader = await _context.PurchaseOrderHeaders
                .Include(p => p.Employee)
                .Include(p => p.ShipMethod)
                .Include(p => p.Vendor)
                .FirstOrDefaultAsync(m => m.PurchaseOrderId == id);*/
            var purchaseOrderHeader = await _serviceContext.PurchaseOrderHeaderService.GetPurchaseOHById((int)id, false);
            if (purchaseOrderHeader == null)
            {
                return NotFound();
            }

            return View(purchaseOrderHeader);
        }

        // POST: PurchaseOrderHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var purchaseOrderHeader = await _context.PurchaseOrderHeaders.FindAsync(id);
            _context.PurchaseOrderHeaders.Remove(purchaseOrderHeader);
            await _context.SaveChangesAsync();*/
            var purchaseOHModel = await _serviceContext.PurchaseOrderHeaderService.GetPurchaseOHById((int)id, false);
            _serviceContext.PurchaseOrderHeaderService.Remove(purchaseOHModel);
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderHeaderExists(int id)
        {
            return _context.PurchaseOrderHeaders.Any(e => e.PurchaseOrderId == id);
        }
    }
}
