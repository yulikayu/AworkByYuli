using AWork.Contracts.Dto.Production;
using AWork.Persistence;
using AWork.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Web.Controllers.Production
{
    public class UnitMeasuresServiceController : Controller
    {
        private readonly AdventureWorks2019Context _context;

        private readonly IProductionServiceManager _productionServiceContext;

        public UnitMeasuresServiceController(AdventureWorks2019Context context, IProductionServiceManager productionServiceContext = null)
        {
            _context = context;
            _productionServiceContext = productionServiceContext;
        }

        // GET: UnitMeasuresService
        public async Task<IActionResult> Index()
        {
            var unitMeasure = await _context.UnitMeasures.ToListAsync();
            var unitMeasureDto = await _productionServiceContext.UnitMeasureservice.GetAllUnitMeasure(false);

            return View(unitMeasureDto);
            /*return View(await _context.UnitMeasures.ToListAsync());*/
        }

        // GET: UnitMeasuresService/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitMeasure = await _context.UnitMeasures
                .FirstOrDefaultAsync(m => m.UnitMeasureCode == id);
            if (unitMeasure == null)
            {
                return NotFound();
            }

            return View(unitMeasure);
        }

        // GET: UnitMeasuresService/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitMeasuresService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitMeasureCode,Name,ModifiedDate")] UnitMeasureForCreateDto unitMeasureForCreateDto)
        //public async Task<IActionResult> Create([Bind("UnitMeasureCode,Name,ModifiedDate")] UnitMeasure unitMeasure
        {
            if (ModelState.IsValid)
            {
                _productionServiceContext.UnitMeasureservice.Insert(unitMeasureForCreateDto);
                return RedirectToAction(nameof(Index));
                /*_context.Add(unitMeasure);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));*/
            }
            return View(unitMeasureForCreateDto);
            //return View(unitMeasure);
        }

        // GET: UnitMeasuresService/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var unitMeasure = await _productionServiceContext.UnitMeasureservice.GetUnitAllMeasureById((string)id, true);
            if (unitMeasure == null)
            {
                return NotFound();
            }
            return View(unitMeasure);
        }

        // POST: UnitMeasuresService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UnitMeasureCode,Name,ModifiedDate")] UnitMeasureDto unitMeasureDto)
        {
            if (id != unitMeasureDto.UnitMeasureCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /* _context.Update(unitMeasure);
                     await _context.SaveChangesAsync();*/
                    _productionServiceContext.UnitMeasureservice.Edit(unitMeasureDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitMeasureExists(unitMeasureDto.UnitMeasureCode))
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
            return View(unitMeasureDto);
        }

        // GET: UnitMeasuresService/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            /*
                        var unitMeasure = await _context.UnitMeasures
                            .FirstOrDefaultAsync(m => m.UnitMeasureCode == id);*/
            var unitMeasure = await _productionServiceContext.UnitMeasureservice.GetUnitAllMeasureById((string)id, false);
            if (unitMeasure == null)
            {
                return NotFound();
            }

            return View(unitMeasure);
        }

        // POST: UnitMeasuresService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var unitMeasureModel = await _productionServiceContext.UnitMeasureservice.GetUnitAllMeasureById((string)id, false);
            _productionServiceContext.UnitMeasureservice.Remove(unitMeasureModel);
            /*var unitMeasure = await _context.UnitMeasures.FindAsync(id);
            _context.UnitMeasures.Remove(unitMeasure);
            await _context.SaveChangesAsync();*/
            return RedirectToAction(nameof(Index));
        }

        private bool UnitMeasureExists(string id)
        {
            return _context.UnitMeasures.Any(e => e.UnitMeasureCode == id);
        }
    }
}
