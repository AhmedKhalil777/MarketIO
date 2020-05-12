using MarketIO.DAL.Repositories;
using MarketIO.Contracts.V1.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.MVC.Components
{
    public class CategoryBrandMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;

        public CategoryBrandMenu(ICategoryRepository categoryRepository,IBrandRepository brandRepository)
        {
            this._categoryRepository = categoryRepository;
            this._brandRepository = brandRepository;
        }

        public IViewComponentResult Invoke()
        {
            var CategoryBrandViewModel = new CategoryAndBrandViewModel
            {
                Categories = _categoryRepository.AllCategories.OrderBy(c => c.Cat_Name),
                Brands = _brandRepository.AllBrands.OrderBy(c => c.Brand_Name)
            };

            return View(CategoryBrandViewModel);
        }

        
    }
}
