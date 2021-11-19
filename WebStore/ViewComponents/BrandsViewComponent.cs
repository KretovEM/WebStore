using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.Filters;
using WebStore.Infrastructure.Interface;
using WebStore.Models;

namespace WebStore.ViewComponents
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public BrandsViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = GetBrands();
            return View(brands);
        }

        private List<BrandViewModel> GetBrands()
        {
            var result = new List<BrandViewModel>();
            var brands = _productService.GetBrands();
            var products = _productService.GetProducts(new ProductFilter()).ToList();

            foreach (var brand in brands)
            {
                result.Add(new BrandViewModel
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    Order = brand.Order,
                    Count = products.Count(x=>x.BrandId == brand.Id)
                });
            }

            result = result.OrderBy(x => x.Order).ToList();
            return result;
        }
    }
}
