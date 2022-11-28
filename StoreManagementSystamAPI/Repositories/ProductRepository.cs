using Microsoft.EntityFrameworkCore;
using StoreManagementSystamAPI.IRepositories;
using StoreManagementSystamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystamAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreManagementDBContext dBContext;
        public ProductRepository(StoreManagementDBContext Context)
        {
            dBContext = Context;
        }
        public async Task<TProduct> AddNewProduct(TProduct product)
        {
            var result = await dBContext.TProducts.AddAsync(product);
            await dBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TProduct> DeleteProduct(int Id)
        {
            var result = await dBContext.TProducts.Where(a => a.Id == Id)
                .FirstOrDefaultAsync();
            if(result!=null)
            {
                dBContext.TProducts.Remove(result);
                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<TProductCategory>> GetAllProductCategories()
        {
            return await dBContext.TProductCategories.ToListAsync();
        }

        public async Task<IEnumerable<TProduct>> GetAllProducts()
        {
            return await dBContext.TProducts.ToListAsync();
        }

        public async Task<IEnumerable<TShelf>> GetAllshelf()
        {
            return await dBContext.TShelves.ToListAsync();
        }

        public async Task<IEnumerable<TSupplier>> GetAllSuppliers()
        {
            return await dBContext.TSuppliers.ToListAsync();
        }

        public async Task<TProduct> GetProduct(int Id)
        {
            return await dBContext.TProducts
                .FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<TProduct> UpdateProduct(TProduct product)
        {
            var result = await dBContext.TProducts
                .FirstOrDefaultAsync(a => a.Id == product.Id);
            if(result!=null)
            {
                result.ProductCategoryId = product.ProductCategoryId;
                result.ShelfId = product.ShelfId;
                result.ProductName = product.ProductName;
                result.BatchNo = product.BatchNo;
                result.SupplierId = product.SupplierId;
                result.BuyingPrice = product.BuyingPrice;
                result.SellingPrice = product.SellingPrice;
                result.EntryBy = product.EntryBy;
                result.EntryDate = product.EntryDate;

                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
