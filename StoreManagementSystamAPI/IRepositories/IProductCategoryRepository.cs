using StoreManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystamAPI.IRepositories
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<TProductCategory>> GetAllProductCategories();
        Task<TProductCategory> GetProductCategory(int Id);
        Task<TProductCategory> AddNewProductCategory(TProductCategory productCategory);
        Task<TProductCategory> UpdateProductCategory(TProductCategory productCategory);
        Task<TProductCategory> DeleteProductCategory(int Id);
    }
}
