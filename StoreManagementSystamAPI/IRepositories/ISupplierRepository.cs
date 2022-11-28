using StoreManagementSystamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystamAPI.IRepositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<TSupplier>> GetAllSuppliers();
        Task<TSupplier> GetSupplier(int Id);
        Task<TSupplier> AddNewSupplier(TSupplier supplier);
        Task<TSupplier> UpdateSupplier(TSupplier supplier);
        Task<TSupplier> deleteSupplier(int Id);
    }
}
