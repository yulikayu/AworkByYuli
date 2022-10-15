using AWork.Domain.Base;
using AWork.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWork.Web.Controllers.Sales
{
    public class CustomersRepoController : Controller
    {
        //private readonly AdventureWorks2019Context _context;
        private readonly ISalesRepositoryManager _context;

        public CustomersRepoController(ISalesRepositoryManager context)
        {
            _context = context;
        }

        // GET: CustomersRepo
        public async Task<IActionResult> Index()
        {
            //var adventureWorks2019Context = _context.Customers.Include(c => c.Person).Include(c => c.Store).Include(c => c.Territory);
            return View(await _context.CustomerRepository.GetAllCustomer(false));
        }

        // GET: CustomersRepo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var customer = await _context.Customers
                .Include(c => c.Person)
                .Include(c => c.Store)
                .Include(c => c.Territory)
                .FirstOrDefaultAsync(m => m.CustomerId == id);*/
            var customer = await _context.CustomerRepository.GetCustomerById((int)id, false);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: CustomersRepo/Create
        public IActionResult Create()
        {
            //ViewData["PersonId"] = new SelectList(_context.People, "BusinessEntityId", "FirstName");
            //ViewData["StoreId"] = new SelectList(_context.Stores, "BusinessEntityId", "Name");
            //ViewData["TerritoryId"] = new SelectList(_context.SalesTerritories, "TerritoryId", "CountryRegionCode");
            return View();
        }

        // POST: CustomersRepo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,PersonId,StoreId,TerritoryId,AccountNumber,Rowguid,ModifiedDate")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(customer);
                await _context.SaveChangesAsync();*/
                _context.CustomerRepository.Insert(customer);
                await _context.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["PersonId"] = new SelectList(_context.People, "BusinessEntityId", "FirstName", customer.PersonId);
            //ViewData["StoreId"] = new SelectList(_context.Stores, "BusinessEntityId", "Name", customer.StoreId);
            //ViewData["TerritoryId"] = new SelectList(_context.SalesTerritories, "TerritoryId", "CountryRegionCode", customer.TerritoryId);
            return View(customer);
        }

        // GET: CustomersRepo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var customer = await _context.Customers.FindAsync(id);*/
            var customer = await _context.CustomerRepository.GetCustomerById((int)id, true);
            if (customer == null)
            {
                return NotFound();
            }
            /*ViewData["PersonId"] = new SelectList(_context.People, "BusinessEntityId", "FirstName", customer.PersonId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "BusinessEntityId", "Name", customer.StoreId);
            ViewData["TerritoryId"] = new SelectList(_context.SalesTerritories, "TerritoryId", "CountryRegionCode", customer.TerritoryId);*/
            return View(customer);
        }

        // POST: CustomersRepo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,PersonId,StoreId,TerritoryId,AccountNumber,Rowguid,ModifiedDate")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(customer);
                    await _context.SaveChangesAsync();*/
                    _context.CustomerRepository.Edit(customer);
                    await _context.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!CustomerExists(customer.CustomerId))
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
            /*ViewData["PersonId"] = new SelectList(_context.People, "BusinessEntityId", "FirstName", customer.PersonId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "BusinessEntityId", "Name", customer.StoreId);
            ViewData["TerritoryId"] = new SelectList(_context.SalesTerritories, "TerritoryId", "CountryRegionCode", customer.TerritoryId);*/
            return View(customer);
        }

        // GET: CustomersRepo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var customer = await _context.Customers
                .Include(c => c.Person)
                .Include(c => c.Store)
                .Include(c => c.Territory)
                .FirstOrDefaultAsync(m => m.CustomerId == id);*/
            var customer = await _context.CustomerRepository.GetCustomerById((int)id, false);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: CustomersRepo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();*/
            var customer = await _context.CustomerRepository.GetCustomerById((int)id, false);
            _context.CustomerRepository.Remove(customer);
            await _context.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        /*private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }*/
    }
}
