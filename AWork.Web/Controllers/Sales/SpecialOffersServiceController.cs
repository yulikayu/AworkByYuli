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
using AWork.Contracts.Dto.Sales.SpecialOffer;

namespace AWork.Web.Controllers.Sales
{
    public class SpecialOffersServiceController : Controller
    {
        private readonly ISalesServiceManager _serviceContext;

        public SpecialOffersServiceController(ISalesServiceManager serviceContext)
        {
            _serviceContext = serviceContext;
        }

        // GET: SpecialOffersService
        public async Task<IActionResult> Index()
        {
            var specialOfferDto = await _serviceContext.SpecialOfferService.GetAllSpecialOffer(false);
            return View(specialOfferDto);
        }

        // GET: SpecialOffersService/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialOffer = await _serviceContext.SpecialOfferService.GetSpecialOfferById((int)id, false);
            if (specialOffer == null)
            {
                return NotFound();
            }

            return View(specialOffer);
        }

        // GET: SpecialOffersService/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpecialOffersService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecialOfferId,Description,DiscountPct,Type,Category,StartDate,EndDate,MinQty,MaxQty,Rowguid,ModifiedDate")] SpecialOfferForCreateDto specialOffer)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(specialOffer);
                await _context.SaveChangesAsync();*/
                _serviceContext.SpecialOfferService.Insert(specialOffer);
                return RedirectToAction(nameof(Index));
            }
            return View(specialOffer);
        }

        // GET: SpecialOffersService/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialOffer = await _serviceContext.SpecialOfferService.GetSpecialOfferById((int)id, true);
            if (specialOffer == null)
            {
                return NotFound();
            }
            return View(specialOffer);
        }

        // POST: SpecialOffersService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecialOfferId,Description,DiscountPct,Type,Category,StartDate,EndDate,MinQty,MaxQty,Rowguid,ModifiedDate")] SpecialOfferDto specialOffer)
        {
            if (id != specialOffer.SpecialOfferId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(specialOffer);
                    await _context.SaveChangesAsync();*/
                    _serviceContext.SpecialOfferService.Edit(specialOffer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!SpecialOfferExists(specialOffer.SpecialOfferId))
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
            return View(specialOffer);
        }

        // GET: SpecialOffersService/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var specialOffer = await _context.SpecialOffers
                .FirstOrDefaultAsync(m => m.SpecialOfferId == id);*/
            var specialOffer = await _serviceContext.SpecialOfferService.GetSpecialOfferById((int)id, false);
            if (specialOffer == null)
            {
                return NotFound();
            }

            return View(specialOffer);
        }

        // POST: SpecialOffersService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var specialOffer = await _context.SpecialOffers.FindAsync(id);
            _context.SpecialOffers.Remove(specialOffer);
            await _context.SaveChangesAsync();*/
            var specialOffer = await _serviceContext.SpecialOfferService.GetSpecialOfferById((int)id, false);
            _serviceContext.SpecialOfferService.Remove(specialOffer);
            return RedirectToAction(nameof(Index));
        }

        /*private bool SpecialOfferExists(int id)
        {
            return _context.SpecialOffers.Any(e => e.SpecialOfferId == id);
        }*/
    }
}
