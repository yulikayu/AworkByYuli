using AWork.Contracts.Dto.Production;
using AWork.Domain.Models;
using AWork.Persistence;
using AWork.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Web.Controllers.Production
{
    public class LocationsServiceController : Controller
    {
        private readonly AdventureWorks2019Context _context;
        private readonly IProductionServiceManager _productionServiceManager;

        public LocationsServiceController(AdventureWorks2019Context context, IProductionServiceManager productionServiceManager = null)
        {
            //_context = context;
            _productionServiceManager = productionServiceManager;
        }
        // GET: Locations
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Locations.ToListAsync());
            //var location = await _context.Locations.ToListAsync();
            var locationDto = await _productionServiceManager.LocationService.GetAllLocation(false);
            return View(locationDto);
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationId == id);*/
            var location = await _productionServiceManager.LocationService.GetLocationById((short)id, false);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,Name,CostRate,Availability,ModifiedDate")] LocationForCreateDto locationForCreateDto)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(locationForCreateDto);
                await _context.SaveChangesAsync();*/
                _productionServiceManager.LocationService.Insert(locationForCreateDto);
                return RedirectToAction(nameof(Index));
            }
            return View(locationForCreateDto);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var location = await _context.Locations.FindAsync(id);
            var location = await _productionServiceManager.LocationService.GetLocationById((short)id, true);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("LocationId,Name,CostRate,Availability,ModifiedDate")] LocationDto locationDto)
        {
            if (id != locationDto.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(locationForEdit);
                    await _context.SaveChangesAsync();*/
                    _productionServiceManager.LocationService.Edit(locationDto);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(locationDto.LocationId))
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
            return View(locationDto);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationId == id);*/
            var locationGet = await _productionServiceManager.LocationService
                .GetLocationById((short)id, false);
            if (locationGet == null)
            {
                return NotFound();
            }

            return View(locationGet);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            /*var location = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();*/
            var locationModel = await _productionServiceManager.LocationService
                .GetLocationById(id, false);
            _productionServiceManager.LocationService.Remove(locationModel);
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(short id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }
    }
}
