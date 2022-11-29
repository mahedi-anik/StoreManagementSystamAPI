using Microsoft.EntityFrameworkCore;
using StoreManagementSystamAPI.IRepositories;
using StoreManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystamAPI.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly StoreManagementSoftwareDBContext dBContext;
        public ProductCategoryRepository(StoreManagementSoftwareDBContext context)
        {
            dBContext = context;
        }
        public async Task<TProductCategory> AddNewProductCategory(TProductCategory productCategory)
        {
            var result = await dBContext.TProductCategories.AddAsync(productCategory);
            await dBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TProductCategory> DeleteProductCategory(int Id)
        {
            var result = await dBContext.TProductCategories.Where(a => a.ProductCategoryId == Id)
                .FirstOrDefaultAsync();
            if(result!=null)
            {
                dBContext.TProductCategories.Remove(result);
                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<TProductCategory>> GetAllProductCategories()
        {
            return await dBContext.TProductCategories.ToListAsync();
        }

        public async Task<TProductCategory> GetProductCategory(int Id)
        {
            return await dBContext.TProductCategories
                .FirstOrDefaultAsync(a => a.ProductCategoryId == Id);
        }

        public async Task<TProductCategory> UpdateProductCategory(TProductCategory productCategory)
        {
            var result = await dBContext.TProductCategories
                .FirstOrDefaultAsync(a => a.ProductCategoryId == productCategory.ProductCategoryId);

            if(result!=null)
            {
                result.ProductCategoryName = productCategory.ProductCategoryName;
                result.ProductCategoryDescription = productCategory.ProductCategoryDescription;
                result.EntryBy = productCategory.EntryBy;
                result.EntryDate = productCategory.EntryDate;

                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
