using Microsoft.EntityFrameworkCore;
using StoreManagementSystamAPI.IRepositories;
using StoreManagementSystamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystamAPI.Repositories
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly StoreManagementDBContext dBContext;
        public ShelfRepository(StoreManagementDBContext context)
        {
            dBContext = context;
        }
        public async Task<TShelf> AddNewShelf(TShelf shelf)
        {
            var result = await dBContext.TShelves.AddAsync(shelf);
            await dBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TShelf> DeleteShelf(int Id)
        {
            var result = await dBContext.TShelves.Where(a => a.ShelfId == Id)
                .FirstOrDefaultAsync();
            if(result!=null)
            {
                dBContext.TShelves.Remove(result);
                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<TShelf>> GetAllShelf()
        {
            return await dBContext.TShelves.ToListAsync();
        }

        public async Task<TShelf> GetShelf(int Id)
        {
            return await dBContext.TShelves
                .FirstOrDefaultAsync(a => a.ShelfId == Id);
        }

        public async Task<TShelf> UpdateShelf(TShelf shelf)
        {
            var result = await dBContext.TShelves
                .FirstOrDefaultAsync(a => a.ShelfId == shelf.ShelfId);

            if(result!=null)
            {
                result.ShelfName = shelf.ShelfName;
                result.NumericNo = shelf.NumericNo;
                result.ShelfDescription = shelf.ShelfDescription;
                result.EntryBy = shelf.EntryBy;
                result.EntryDate = shelf.EntryDate;

                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

    }
}
