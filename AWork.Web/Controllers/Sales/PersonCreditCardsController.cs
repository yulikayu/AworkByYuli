using AWork.Contracts.Dto.Sales.PersonCreditCard;
using AWork.Domain.Models;
using AWork.Persistence;
using AWork.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Web.Controllers.Sales
{
    public class PersonCreditCardsController : Controller
    {
        //private readonly AdventureWorks2019Context _context;
        private readonly ISalesServiceManager _context;

        public PersonCreditCardsController(ISalesServiceManager context)
        {
            _context = context;
        }

        // GET: PersonCreditCards
        public async Task<IActionResult> Index()
        {
            var personCreditCard = await _context.PersonCreditCardService.GetAllPersonCreditCards(false);
            return View(personCreditCard);
        }

        // GET: PersonCreditCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var personCreditCard = await _context.PersonCreditCards
                .Include(p => p.BusinessEntity)
                .Include(p => p.CreditCard)
                .FirstOrDefaultAsync(m => m.BusinessEntityId == id);*/
            var personCreditCard = await _context.PersonCreditCardService.GetPersonCreditCardById((int)id, false);
            if (personCreditCard == null)
            {
                return NotFound();
            }

            return View(personCreditCard);
        }

        // GET: PersonCreditCards/Create
        public IActionResult Create()
        {
           /* ViewData["BusinessEntityId"] = new SelectList(_context.People, "BusinessEntityId", "FirstName");
            ViewData["CreditCardId"] = new SelectList(_context.CreditCards, "CreditCardId", "CardNumber");*/
            return View();
        }

        // POST: PersonCreditCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessEntityId,CreditCardId,ModifiedDate")] PersonCreditCardForCreateDto personCreditCard)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(personCreditCard);
                await _context.SaveChangesAsync();*/
                _context.PersonCreditCardService.Insert(personCreditCard);
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["BusinessEntityId"] = new SelectList(_context.People, "BusinessEntityId", "FirstName", personCreditCard.BusinessEntityId);
            ViewData["CreditCardId"] = new SelectList(_context.CreditCards, "CreditCardId", "CardNumber", personCreditCard.CreditCardId);*/
            return View(personCreditCard);
        }

        // GET: PersonCreditCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var personCreditCard = await _context.PersonCreditCards.FindAsync(id);*/
            var personCreditCard = await _context.PersonCreditCardService.GetPersonCreditCardById((int)id, true);
            if (personCreditCard == null)
            {
                return NotFound();
            }
            /*ViewData["BusinessEntityId"] = new SelectList(_context.People, "BusinessEntityId", "FirstName", personCreditCard.BusinessEntityId);
            ViewData["CreditCardId"] = new SelectList(_context.CreditCards, "CreditCardId", "CardNumber", personCreditCard.CreditCardId);*/
            return View(personCreditCard);
        }

        // POST: PersonCreditCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessEntityId,CreditCardId,ModifiedDate")] PersonCreditCardDto personCreditCard)
        {
            if (id != personCreditCard.BusinessEntityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(personCreditCard);
                    await _context.SaveChangesAsync();*/
                    _context.PersonCreditCardService.Edit(personCreditCard);
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!PersonCreditCardExists(personCreditCard.BusinessEntityId))
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
            /*ViewData["BusinessEntityId"] = new SelectList(_context.People, "BusinessEntityId", "FirstName", personCreditCard.BusinessEntityId);
            ViewData["CreditCardId"] = new SelectList(_context.CreditCards, "CreditCardId", "CardNumber", personCreditCard.CreditCardId);*/
            return View(personCreditCard);
        }

        // GET: PersonCreditCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var personCreditCard = await _context.PersonCreditCards
                .Include(p => p.BusinessEntity)
                .Include(p => p.CreditCard)
                .FirstOrDefaultAsync(m => m.BusinessEntityId == id);*/
            var personCreditCard = await _context.PersonCreditCardService.GetPersonCreditCardById((int)id, false);
            if (personCreditCard == null)
            {
                return NotFound();
            }

            return View(personCreditCard);
        }

        // POST: PersonCreditCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var personCreditCard = await _context.PersonCreditCards.FindAsync(id);
            _context.PersonCreditCards.Remove(personCreditCard);
            await _context.SaveChangesAsync();*/
            var personCreditCard = await _context.PersonCreditCardService.GetPersonCreditCardById((int)id, false);
            _context.PersonCreditCardService.Remove(personCreditCard);
            return RedirectToAction(nameof(Index));
        }

        /*private bool PersonCreditCardExists(int id)
        {
            return _context.PersonCreditCards.Any(e => e.BusinessEntityId == id);
        }*/
    }
}
