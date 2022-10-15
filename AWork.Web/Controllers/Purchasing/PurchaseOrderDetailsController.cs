using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AWork.Domain.Models;
using AWork.Persistence;
using AWork.Domain.Base;
using AWork.Services.Abstraction;
using AWork.Contracts.Dto.Purchasing;

namespace AWork.Web.Controllers.Purchasing
{
    public class PurchaseOrderDetailsController : Controller
    {
        private readonly AdventureWorks2019Context _context;
        private readonly IPurchasingServiceManager _serviceContext;

        public PurchaseOrderDetailsController(AdventureWorks2019Context context, IPurchasingServiceManager serviceContext)
        {
            _context = context;
            _serviceContext = serviceContext;
        }

        // GET: PurchaseOrderDetails
        public async Task<IActionResult> Index()
        {
            var purchaseOd = await _context.PurchaseOrderDetails.ToListAsync();
            var purchaseODDto = await _serviceContext.PurchaseOrderDetailService.GetAllPurchaseOD(false);
            return View(purchaseODDto);
        }

        // GET: PurchaseOrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var purchaseOrderDetail = await _context.PurchaseOrderDetails
                .Include(p => p.Product)
                .Include(p => p.PurchaseOrder)
                .FirstOrDefaultAsync(m => m.PurchaseOrderId == id);*/
            var purchaseOrderDetail = await _serviceContext.PurchaseOrderDetailService.GetPurchaseODById((int)id, false);
            if (purchaseOrderDetail == null)
            {
                return NotFound();
            }

            return View(purchaseOrderDetail);
        }

        // GET: PurchaseOrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseOrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseOrderId,PurchaseOrderDetailId,DueDate,OrderQty,ProductId,UnitPrice,LineTotal,ReceivedQty,RejectedQty,StockedQty,ModifiedDate")] PurchaseOrderDetailsForCreateDto purchaseOrderDetailsForCreateDto)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(purchaseOrderDetail);
                await _context.SaveChangesAsync();*/
                /*_context.PurchaseOrderDetailRepository.Insert(purchaseOrderDetail);
                await _context.SaveAsync();*/
                _serviceContext.PurchaseOrderDetailService.Insert(purchaseOrderDetailsForCreateDto);
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", purchaseOrderDetail.ProductId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrderHeaders, "PurchaseOrderId", "PurchaseOrderId", purchaseOrderDetail.PurchaseOrderId);*/
            return View(purchaseOrderDetailsForCreateDto);
        }

        // GET: PurchaseOrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderDetail = await _serviceContext.PurchaseOrderDetailService.GetPurchaseODById((int)id, true);
            if (purchaseOrderDetail == null)
            {
                return NotFound();
            }
            /*ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", purchaseOrderDetail.ProductId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrderHeaders, "PurchaseOrderId", "PurchaseOrderId", purchaseOrderDetail.PurchaseOrderId);*/
            return View(purchaseOrderDetail);
        }

        // POST: PurchaseOrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseOrderId,PurchaseOrderDetailId,DueDate,OrderQty,ProductId,UnitPrice,LineTotal,ReceivedQty,RejectedQty,StockedQty,ModifiedDate")] PurchaseOrderDetailsDto purchaseOrderDetailsDto)
        {
            if (id != purchaseOrderDetailsDto.PurchaseOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(purchaseOrderDetail);
                    await _context.SaveChangesAsync();*/
                    _serviceContext.PurchaseOrderDetailService.Edit(purchaseOrderDetailsDto);
                    //await _context.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!PurchaseOrderDetailExists(purchaseOrderDetail.PurchaseOrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }*/
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", purchaseOrderDetail.ProductId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrderHeaders, "PurchaseOrderId", "PurchaseOrderId", purchaseOrderDetail.PurchaseOrderId);*/
            return View(purchaseOrderDetailsDto);
        }

        // GET: PurchaseOrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var purchaseOrderDetail = await _context.PurchaseOrderDetails
                .Include(p => p.Product)
                .Include(p => p.PurchaseOrder)
                .FirstOrDefaultAsync(m => m.PurchaseOrderId == id);*/
            var purchaseOrderDetail = await _serviceContext.PurchaseOrderDetailService.GetPurchaseODById((int)id, false);
            if (purchaseOrderDetail == null)
            {
                return NotFound();
            }

            return View(purchaseOrderDetail);
        }

        // POST: PurchaseOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseOrderDetail = await _serviceContext.PurchaseOrderDetailService.GetPurchaseODById((int)id, false);
            _serviceContext.PurchaseOrderDetailService.Remove(purchaseOrderDetail);
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderDetailExists(int id)
        {
            return _context.PurchaseOrderDetails.Any(e => e.PurchaseOrderId == id);
        }
    }
}
