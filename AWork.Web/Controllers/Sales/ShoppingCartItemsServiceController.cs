using AWork.Contracts.Dto.Sales.ShoppingCartItem;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWork.Web.Controllers.Sales
{
    public class ShoppingCartItemsServiceController : Controller
    {
        //private readonly AdventureWorks2019Context _context;
        private readonly ISalesServiceManager _context;

        public ShoppingCartItemsServiceController(ISalesServiceManager context)
        {
            _context = context;
        }

        // GET: ShoppingCartItemsRepository
        public async Task<IActionResult> Index()
        {
            //var adventureWorks2019Context = _context.ShoppingCartItems.Include(s => s.Product);
            return View(await _context.ShoppingCartItemService.GetAllShopCartItem(false));
        }

        // GET: ShoppingCartItemsRepository/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var shoppingCartItem = await _context.ShoppingCartItems
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.ShoppingCartItemId == id);*/
            var shoppingCartItem = await _context.ShoppingCartItemService.GetShopCartItemById((int)id, false);
            if (shoppingCartItem == null)
            {
                return NotFound();
            }

            return View(shoppingCartItem);
        }

        // GET: ShoppingCartItemsRepository/Create
        public IActionResult Create()
        {
            //ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name");
            return View();
        }

        // POST: ShoppingCartItemsRepository/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingCartItemId,ShoppingCartId,Quantity,ProductId,DateCreated,ModifiedDate")] ShoppingCartItemForCreateDto shoppingCartItem)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(shoppingCartItem);
                await _context.SaveChangesAsync();*/
                _context.ShoppingCartItemService.Insert(shoppingCartItem);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", shoppingCartItem.ProductId);
            return View(shoppingCartItem);
        }

        // GET: ShoppingCartItemsRepository/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var shoppingCartItem = await _context.ShoppingCartItems.FindAsync(id);*/
            var shoppingCartItem = await _context.ShoppingCartItemService.GetShopCartItemById((int)id, true);
            if (shoppingCartItem == null)
            {
                return NotFound();
            }
            //ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", shoppingCartItem.ProductId);
            return View(shoppingCartItem);
        }

        // POST: ShoppingCartItemsRepository/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingCartItemId,ShoppingCartId,Quantity,ProductId,DateCreated,ModifiedDate")] ShoppingCartItemDto shoppingCartItem)
        {
            if (id != shoppingCartItem.ShoppingCartItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(shoppingCartItem);
                    await _context.SaveChangesAsync();*/
                    _context.ShoppingCartItemService.Edit(shoppingCartItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!ShoppingCartItemExists(shoppingCartItem.ShoppingCartItemId))
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
            //ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", shoppingCartItem.ProductId);
            return View(shoppingCartItem);
        }

        // GET: ShoppingCartItemsRepository/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var shoppingCartItem = await _context.ShoppingCartItems
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.ShoppingCartItemId == id);*/
            var shoppingCartItem = await _context.ShoppingCartItemService.GetShopCartItemById((int)id, false);
            if (shoppingCartItem == null)
            {
                return NotFound();
            }

            return View(shoppingCartItem);
        }

        // POST: ShoppingCartItemsRepository/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var shoppingCartItem = await _context.ShoppingCartItems.FindAsync(id);
            _context.ShoppingCartItems.Remove(shoppingCartItem);
            await _context.SaveChangesAsync();*/
            var shoppingCartItem = await _context.ShoppingCartItemService.GetShopCartItemById((int)id, false);
            _context.ShoppingCartItemService.Remove(shoppingCartItem);
            return RedirectToAction(nameof(Index));
        }

        /*private bool ShoppingCartItemExists(int id)
        {
            return _context.ShoppingCartItems.Any(e => e.ShoppingCartItemId == id);
        }*/
    }
}
