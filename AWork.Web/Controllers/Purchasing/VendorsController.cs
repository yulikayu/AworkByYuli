using AWork.Contracts.Dto.Purchasing;
using AWork.Persistence;
using AWork.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Web.Controllers.Purchasing
{
    public class VendorsController : Controller
    {
        private readonly AdventureWorks2019Context _context;
        private readonly IPurchasingServiceManager _serviceContext;

        public VendorsController(AdventureWorks2019Context context, IPurchasingServiceManager serviceContext)
        {
            _context = context;
            _serviceContext = serviceContext;
        }

        // GET: Vendors
        public async Task<IActionResult> Index()
        {
            var vendor = await _context.Vendors.ToListAsync();
            var vendorDto = await _serviceContext.VendorService.GetAllVendor(false);
            return View(vendorDto);
        }

        // GET: Vendors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var vendor = await _context.Vendors
                .Include(v => v.BusinessEntity)
                .FirstOrDefaultAsync(m => m.BusinessEntityId == id);*/
            var vendorDto = await _serviceContext.VendorService.GetVendorById((int)id, false);
            if (vendorDto == null)
            {
                return NotFound();
            }

            return View(vendorDto);
        }

        // GET: Vendors/Create
        public IActionResult Create()
        {
            ViewData["BusinessEntityId"] = new SelectList(_context.BusinessEntities, "BusinessEntityId", "BusinessEntityId");
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessEntityId,AccountNumber,Name,CreditRating,PreferredVendorStatus,ActiveFlag,PurchasingWebServiceUrl,ModifiedDate")] VendorForCreateDto vendorForCreateDto)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(vendor);
                await _context.SaveChangesAsync();*/
                _serviceContext.VendorService.Insert(vendorForCreateDto);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessEntityId"] = new SelectList(_context.BusinessEntities, "BusinessEntityId", "BusinessEntityId", vendorForCreateDto.BusinessEntityId);
            return View(vendorForCreateDto);
        }

        // GET: Vendors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var vendor = await _context.Vendors.FindAsync(id);*/
            var vendor = await _serviceContext.VendorService.GetVendorById((int)id, true);
            if (vendor == null)
            {
                return NotFound();
            }
            ViewData["BusinessEntityId"] = new SelectList(_context.BusinessEntities, "BusinessEntityId", "BusinessEntityId", vendor.BusinessEntityId);
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessEntityId,AccountNumber,Name,CreditRating,PreferredVendorStatus,ActiveFlag,PurchasingWebServiceUrl,ModifiedDate")] VendorDto vendorDto)
        {
            if (id != vendorDto.BusinessEntityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(vendor);
                    await _context.SaveChangesAsync();*/
                    _serviceContext.VendorService.Edit(vendorDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorExists(vendorDto.BusinessEntityId))
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
            ViewData["BusinessEntityId"] = new SelectList(_context.BusinessEntities, "BusinessEntityId", "BusinessEntityId", vendorDto.BusinessEntityId);
            return View(vendorDto);
        }

        // GET: Vendors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var vendor = await _context.Vendors
                .Include(v => v.BusinessEntity)
                .FirstOrDefaultAsync(m => m.BusinessEntityId == id);*/
            var vendor = await _serviceContext.VendorService.GetVendorById((int)id, false);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var vendor = await _context.Vendors.FindAsync(id);
            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();*/
            var vendorModel = await _serviceContext.VendorService.GetVendorById((int)id, false);
            _serviceContext.VendorService.Remove(vendorModel);
            return RedirectToAction(nameof(Index));
        }

        private bool VendorExists(int id)
        {
            return _context.Vendors.Any(e => e.BusinessEntityId == id);
        }
    }
}
