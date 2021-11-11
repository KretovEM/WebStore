using System.Collections.Generic;
using WebStore.Domain.Entities.Base;

namespace WebStore.Infrastructure.Interface
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();
    }
}
