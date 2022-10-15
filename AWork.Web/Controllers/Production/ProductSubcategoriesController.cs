using AWork.Contracts.Dto.Production;
using AWork.Domain.Models;
using AWork.Persistence;
using AWork.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Contracts.Dto.Category;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Web.Controllers.Production
{
    public class ProductSubcategoriesController : Controller
    {
        private readonly AdventureWorks2019Context _context;
        private readonly IProductionServiceManager _productionServiceContext;


        public ProductSubcategoriesController(AdventureWorks2019Context context, IProductionServiceManager productionServiceContext)
        {
            _context = context;
            _productionServiceContext = productionServiceContext;
        }
        public async Task<IActionResult> Index1(int? id,SelectProductSubCategoryDto selectProductSubCategoryDto)
        {
            var product = selectProductSubCategoryDto;
             

            return View(product);

        }

        // GET: ProductSubcategories
        public async Task<IActionResult> Index(int? id)
        {
            /* var adventureWorks2019Context = _context.ProductSubcategories.Include(p => p.ProductCategory);
             return View(await adventureWorks2019Context.ToListAsync());*/

            /*var prodcSubCategory = await _context.ProductSubcategories.ToListAsync();
            var proSubCateDto = await _productionServiceContext.ProductSubCategoryService.GetAllProdcSubCategory(false);
            return View(proSubCateDto);*/
            


            var proCategory = await _productionServiceContext.ProductCategoryService.GetAllProdcCategory(false);
            return View(proCategory);



            /* var viewMdl = _productionServiceContext.ProductCategoryService.GetAllProdcCategory(false);
            //var cateId = _productionServiceContext.ProductSubCategoryService.GetProcdSubCateById((int)id, false);



             return View(viewMdl);*/

        }



       /* public async IActionResult Index()
        {
            
         }*/


        public async Task<IActionResult> Select(int? id, SelectProductSubCategoryDto selectProductSubCategoryDto)
        {

            /*if (id == null)
            {
                return NotFound();
            }
            var viewModell = selectProductSubCategoryDto;
            var listpro = new List<ProductSubCategoryDto>();
            var select = await _productionServiceContext.ProductCategoryService.GetProcdCateById((int)id, false);
            var viewModel = _productionServiceContext.ProductSubCategoryService.GetProCateInSubByID(false);
            if (id != null)
            {
               
            }*/


            //with contex
            /*var viewModel = new SelectProductSubCategoryDto();
            viewModel.ProductCategory = _context.ProductCategories.Include(i => i.ProductSubcategories)
                .OrderBy(i => i.Name);

            if (id != null)
            {
                ViewBag.Id = id.Value;
                viewModel.ProductSubCategory = viewModel.ProductCategory
                    .Where(i => i.ProductCategoryId == id.Value).Single().ProductSubcategories;
            }
            return View(viewModel);*/

            //var viewModel = new SelectProductSubCategoryDto();
            var viewModel = _productionServiceContext.ProductSubCategoryService.GetAllProdcSubCategory(false);
            var subcate = _productionServiceContext.ProductSubCategoryService.GetAllProdcSubCategory(false);
            var viewSubcate = await _productionServiceContext.ProductSubCategoryService.GetProCateInSubByID((int)id, false);
            var proSubCateDto = await _productionServiceContext.ProductSubCategoryService.GetAllProdcSubCategory(false);
            
            /*if (id != null)
            {
                viewModel = _productionServiceContext.ProductSubCategoryService.GetProCateInSubByID((int)id, false);
            }
            var productView = new StaticPagedList<ProductSubCategoryDto>(viewModel, viewSubcate);*//*

            return View(viewModel);*/


            return View(viewSubcate);
        }

        // GET: ProductSubcategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubcategory = await _context.ProductSubcategories
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.ProductSubcategoryId == id);
            if (productSubcategory == null)
            {
                return NotFound();
            }

            return View(productSubcategory);
        }

        // GET: ProductSubcategories/Create
        public IActionResult Create()
        {
            List<ProductSubCategoryDto> Cgtdto = new List<ProductSubCategoryDto> { new ProductSubCategoryDto { Name = "" } };

            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IEnumerable<ProductSubCategoryForCreateDto> dto)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        public void Add(IEnumerable<ProductSubCategoryForCreateDto> dto)
        {
            foreach (ProductSubCategoryForCreateDto item in dto)
            {
                _productionServiceContext.ProductSubCategoryService.Insert(item);
            }
        }

        // POST: ProductSubcategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductSubcategoryId,ProductCategoryId,Name,Rowguid,ModifiedDate")] ProductSubcategory productSubcategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productSubcategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "Name", productSubcategory.ProductCategoryId);
            return View(productSubcategory);
        }

        // GET: ProductSubcategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubcategory = await _context.ProductSubcategories.FindAsync(id);
            if (productSubcategory == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "Name", productSubcategory.ProductCategoryId);
            return View(productSubcategory);
        }

        // POST: ProductSubcategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductSubcategoryId,ProductCategoryId,Name,Rowguid,ModifiedDate")] ProductSubcategory productSubcategory)
        {
            if (id != productSubcategory.ProductSubcategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSubcategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSubcategoryExists(productSubcategory.ProductSubcategoryId))
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
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "Name", productSubcategory.ProductCategoryId);
            return View(productSubcategory);
        }

        // GET: ProductSubcategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubcategory = await _context.ProductSubcategories
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.ProductSubcategoryId == id);
            if (productSubcategory == null)
            {
                return NotFound();
            }

            return View(productSubcategory);
        }

        // POST: ProductSubcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productSubcategory = await _context.ProductSubcategories.FindAsync(id);
            _context.ProductSubcategories.Remove(productSubcategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSubcategoryExists(int id)
        {
            return _context.ProductSubcategories.Any(e => e.ProductSubcategoryId == id);
        }
    }
}
