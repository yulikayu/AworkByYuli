using AWork.Contracts.Dto.Sales.CreditCard;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWork.Web.Controllers.Sales
{
    public class CreditCardsController : Controller
    {
        /*        private readonly AdventureWorks2019Context _context;
        */
        private readonly ISalesServiceManager _context;

        public CreditCardsController(ISalesServiceManager context)
        {
            _context = context;
        }

        // GET: CreditCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.CreditCardService.GetAllCreditCard(false));
        }

        // GET: CreditCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*    var creditCard = await _context.CreditCards
                    .FirstOrDefaultAsync(m => m.CreditCardId == id);*/
            var creditCard = await _context.CreditCardService.GetAllCreditCardById((int)id, false);
            if (creditCard == null)
            {
                return NotFound();
            }

            return View(creditCard);
        }

        // GET: CreditCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CreditCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreditCardId,CardType,CardNumber,ExpMonth,ExpYear,ModifiedDate")] CreditCardForCreateDto creditCard)
        {
            if (ModelState.IsValid)
            {
                /*      _context.Add(creditCard);
                      await _context.SaveChangesAsync();*/
                _context.CreditCardService.Insert(creditCard);

                return RedirectToAction(nameof(Index));
            }
            return View(creditCard);
        }

        // GET: CreditCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*            var creditCard = await _context.CreditCardRepository.FindAsync(id);
            */
            var creditCard = await _context.CreditCardService.GetAllCreditCardById((int)id, true);
            if (creditCard == null)
            {
                return NotFound();
            }
            return View(creditCard);
        }

        // POST: CreditCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreditCardId,CardType,CardNumber,ExpMonth,ExpYear,ModifiedDate")] CreditCardDto creditCard)
        {
            if (id != creditCard.CreditCardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*       _context.Update(creditCard);
                           await _context.SaveChangesAsync();*/
                    _context.CreditCardService.Edit(creditCard);
                }
                catch (DbUpdateConcurrencyException)
                {
                    /* if (!CreditCardExists(creditCard.CreditCardId))
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
            return View(creditCard);
        }

        // GET: CreditCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*        var creditCard = await _context.CreditCards
                        .FirstOrDefaultAsync(m => m.CreditCardId == id);*/

            var creditCard = await _context.CreditCardService.GetAllCreditCardById((int)id, false);
            if (creditCard == null)
            {
                return NotFound();
            }

            return View(creditCard);
        }

        // POST: CreditCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*   var creditCard = await _context.CreditCards.FindAsync(id);
               _context.CreditCards.Remove(creditCard);
               await _context.SaveChangesAsync();*/
            var creditCard = await _context.CreditCardService.GetAllCreditCardById((int)id, false);
            _context.CreditCardService.Remove(creditCard);
            return RedirectToAction(nameof(Index));
        }

        /* private bool CreditCardExists(int id)
         {
             return _context.CreditCards.Any(e => e.CreditCardId == id);
         }*/
    }
}
