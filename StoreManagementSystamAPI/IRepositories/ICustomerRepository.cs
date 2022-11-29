using StoreManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystamAPI.IRepositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<TCustomer>> GetAllCustomers();
        Task<TCustomer> GetCustomer(int Id);
        Task<TCustomer> AddNewCustomer(TCustomer customer);
        Task<TCustomer> UpdateCustomer(TCustomer customer);
        Task<TCustomer> DeleteCustomer(int Id);
    }
}
