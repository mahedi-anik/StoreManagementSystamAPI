using StoreManagementSystamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystamAPI.IRepositories
{
    public interface IShelfRepository
    {
        Task<IEnumerable<TShelf>> GetAllShelf();
        Task<TShelf> GetShelf(int Id);
        Task<TShelf> AddNewShelf(TShelf shelf);
        Task<TShelf> UpdateShelf(TShelf shelf);
        Task<TShelf> DeleteShelf(int Id);

    }
}
