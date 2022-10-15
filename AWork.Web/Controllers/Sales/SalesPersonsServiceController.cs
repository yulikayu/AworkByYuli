using AWork.Contracts.Dto.Sales.SalesPerson;
using AWork.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Web.Controllers.Sales
{
    public class SalesPersonsServiceController : Controller
    {
        //private readonly AdventureWorks2019Context _context;
        private readonly ISalesServiceManager _serviceContext;

        public SalesPersonsServiceController(ISalesServiceManager serviceContext)
        {
            //_context = context;
            _serviceContext = serviceContext;
        }

        // GET: SalesPersonsService
        public async Task<IActionResult> Index()
        {
            /*var adventureWorks2019Context = _context.SalesPeople.Include(s => s.BusinessEntity).Include(s => s.Territory);
            return View(await adventureWorks2019Context.ToListAsync());*/
            var salesPersonDto = await _serviceContext.SalesPersonService.GetAllSalesPerson(false);
            return View(salesPersonDto);
        }

        // GET: SalesPersonsService/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var salesPerson = await _context.SalesPeople
                .Include(s => s.BusinessEntity)
                .Include(s => s.Territory)
                .FirstOrDefaultAsync(m => m.BusinessEntityId == id);*/
            var salesPerson = await _serviceContext.SalesPersonService.GetSalesPersonById((int)id, false);
            if (salesPerson == null)
            {
                return NotFound();
            }

            return View(salesPerson);
        }

        // GET: SalesPersonsService/Create
        public async Task<IActionResult> Create()
        {
            var allTerritory = await _serviceContext.SalesTerritoryService.GetAllSalesTerritory(false);
            //ViewData["BusinessEntityId"] = new SelectList(_context.Employees, "BusinessEntityId", "Gender");
            ViewData["TerritoryId"] = new SelectList(allTerritory, "TerritoryId", "CountryRegionCode");
            return View();
        }

        // POST: SalesPersonsService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TerritoryId,SalesQuota,Bonus,CommissionPct,SalesYtd,SalesLastYear,Rowguid,ModifiedDate")] SalesPersonForCreateDto salesPerson)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(salesPerson);
                await _context.SaveChangesAsync();*/
                _serviceContext.SalesPersonService.Insert(salesPerson);
                return RedirectToAction(nameof(Index));
            }
            var allTerritory = await _serviceContext.SalesTerritoryService.GetAllSalesTerritory(false);
            //ViewData["BusinessEntityId"] = new SelectList(_context.Employees, "BusinessEntityId", "Gender", salesPerson.BusinessEntityId);
            ViewData["TerritoryId"] = new SelectList(allTerritory, "TerritoryId", "CountryRegionCode", salesPerson.TerritoryId);
            return View(salesPerson);
        }

        // GET: SalesPersonsService/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var salesPerson = await _context.SalesPeople.FindAsync(id);*/
            var salesPerson = await _serviceContext.SalesPersonService.GetSalesPersonById((int)id, true);
            if (salesPerson == null)
            {
                return NotFound();
            }
            var allTerritory = await _serviceContext.SalesTerritoryService.GetAllSalesTerritory(false);
            //ViewData["BusinessEntityId"] = new SelectList(_context.Employees, "BusinessEntityId", "Gender", salesPerson.BusinessEntityId);
            ViewData["TerritoryId"] = new SelectList(allTerritory, "TerritoryId", "CountryRegionCode", salesPerson.TerritoryId);
            return View(salesPerson);
        }
        //test
        // POST: SalesPersonsService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessEntityId,TerritoryId,SalesQuota,Bonus,CommissionPct,SalesYtd,SalesLastYear,Rowguid,ModifiedDate")] SalesPersonDto salesPerson)
        {
            if (id != salesPerson.BusinessEntityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(salesPerson);
                    await _context.SaveChangesAsync();*/
                    _serviceContext.SalesPersonService.Edit(salesPerson);
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!SalesPersonExists(salesPerson.BusinessEntityId))
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
            var allTerritory = await _serviceContext.SalesTerritoryService.GetAllSalesTerritory(false);
            //ViewData["BusinessEntityId"] = new SelectList(_context.Employees, "BusinessEntityId", "Gender", salesPerson.BusinessEntityId);
            ViewData["TerritoryId"] = new SelectList(allTerritory, "TerritoryId", "CountryRegionCode", salesPerson.TerritoryId);
            return View(salesPerson);
        }

        // GET: SalesPersonsService/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var salesPerson = await _context.SalesPeople
                .Include(s => s.BusinessEntity)
                .Include(s => s.Territory)
                .FirstOrDefaultAsync(m => m.BusinessEntityId == id);*/
            var salesPerson = await _serviceContext.SalesPersonService.GetSalesPersonById((int)id, false);
            if (salesPerson == null)
            {
                return NotFound();
            }

            return View(salesPerson);
        }

        // POST: SalesPersonsService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var salesPerson = await _context.SalesPeople.FindAsync(id);
            _context.SalesPeople.Remove(salesPerson);
            await _context.SaveChangesAsync();*/
            var salesPerson = await _serviceContext.SalesPersonService.GetSalesPersonById((int)id, false);
            _serviceContext.SalesPersonService.Remove(salesPerson);
            return RedirectToAction(nameof(Index));
        }

        /*private bool SalesPersonExists(int id)
        {
            return _context.SalesPeople.Any(e => e.BusinessEntityId == id);
        }*/
    }
}
