using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Web.Controllers.Sales
{
    public class StoresController : Controller
    {
        //private readonly AdventureWorks2019Context _context;
        private readonly ISalesRepositoryManager _context;

        public StoresController(ISalesRepositoryManager context)
        {
            _context = context;
        }

        // GET: Stores
        public async Task<IActionResult> Index()
        {
            //var adventureWorks2019Context = _context.Stores.Include(s => s.BusinessEntity).Include(s => s.SalesPerson);
            return View(await _context.StoreRepository.GetAllAsync(false));
        }

        // GET: Stores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var store = await _context.Stores
                .Include(s => s.BusinessEntity)
                .Include(s => s.SalesPerson)
                .FirstOrDefaultAsync(m => m.BusinessEntityId == id);*/
            var store = await _context.StoreRepository.GetCurrencyByCode((int)id, false);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // GET: Stores/Create
        public IActionResult Create()
        {
            /*ViewData["BusinessEntityId"] = new SelectList(_context.BusinessEntities, "BusinessEntityId", "BusinessEntityId");
            ViewData["SalesPersonId"] = new SelectList(_context.SalesPeople, "BusinessEntityId", "BusinessEntityId");*/
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessEntityId,Name,SalesPersonId,Demographics,Rowguid,ModifiedDate")] Store store)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(store);
                await _context.SaveChangesAsync();*/
                _context.StoreRepository.Insert(store);
                await _context.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["BusinessEntityId"] = new SelectList(_context.BusinessEntities, "BusinessEntityId", "BusinessEntityId", store.BusinessEntityId);
            ViewData["SalesPersonId"] = new SelectList(_context.SalesPeople, "BusinessEntityId", "BusinessEntityId", store.SalesPersonId);*/
            return View(store);
        }

        // GET: Stores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var store = await _context.Stores.FindAsync(id);
            var store = await _context.StoreRepository.GetCurrencyByCode((int)id, true);
            if (store == null)
            {
                return NotFound();
            }
            /*ViewData["BusinessEntityId"] = new SelectList(_context.BusinessEntities, "BusinessEntityId", "BusinessEntityId", store.BusinessEntityId);
            ViewData["SalesPersonId"] = new SelectList(_context.SalesPeople, "BusinessEntityId", "BusinessEntityId", store.SalesPersonId);*/
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessEntityId,Name,SalesPersonId,Demographics,Rowguid,ModifiedDate")] Store store)
        {
            if (id != store.BusinessEntityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(store);
                    await _context.SaveChangesAsync();*/
                    _context.StoreRepository.Change(store);
                    await _context.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!StoreExists(store.BusinessEntityId))
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
            /*ViewData["BusinessEntityId"] = new SelectList(_context.BusinessEntities, "BusinessEntityId", "BusinessEntityId", store.BusinessEntityId);
            ViewData["SalesPersonId"] = new SelectList(_context.SalesPeople, "BusinessEntityId", "BusinessEntityId", store.SalesPersonId);*/
            return View(store);
        }

        // GET: Stores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var store = await _context.Stores
                .Include(s => s.BusinessEntity)
                .Include(s => s.SalesPerson)
                .FirstOrDefaultAsync(m => m.BusinessEntityId == id);*/
            var store = await _context.StoreRepository.GetCurrencyByCode((int)id, false);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var store = await _context.Stores.FindAsync(id);
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();*/
            var store = await _context.StoreRepository.GetCurrencyByCode((int)id, false);
            _context.StoreRepository.Remove(store);
            await _context.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        /*private bool StoreExists(int id)
        {
            return _context.Stores.Any(e => e.BusinessEntityId == id);
        }*/
    }
}
