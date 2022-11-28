using StoreManagementSystamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystamAPI.IRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<TProduct>> GetAllProducts();
        Task<IEnumerable<TProductCategory>> GetAllProductCategories();
        Task<IEnumerable<TSupplier>> GetAllSuppliers();
        Task<IEnumerable<TShelf>> GetAllshelf();
        Task<TProduct> GetProduct(int Id);
        Task<TProduct> AddNewProduct(TProduct product);
        Task<TProduct> UpdateProduct(TProduct product);
        Task<TProduct> DeleteProduct(int Id);
    }
}
