using Microsoft.EntityFrameworkCore;
using StoreManagementSystamAPI.IRepositories;
using StoreManagementSystamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreManagementDBContext dBContext;
        public CustomerRepository(StoreManagementDBContext context)
        {
            dBContext = context;
        }
        public async Task<TCustomer> AddNewCustomer(TCustomer customer)
        {
            var result = await dBContext.TCustomers.AddAsync(customer);
            await dBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TCustomer> DeleteCustomer(int Id)
        {
            var result = await dBContext.TCustomers.Where(a => a.CustomerId == Id)
                .FirstOrDefaultAsync();
            if (result != null)
            {
                dBContext.TCustomers.Remove(result);
                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<TCustomer>> GetAllCustomers()
        {
            return await dBContext.TCustomers.ToListAsync();
        }

        public async Task<TCustomer> GetCustomer(int Id)
        {
            return  await dBContext.TCustomers
                .FirstOrDefaultAsync(a => a.CustomerId == Id);
        }

        public async Task<TCustomer> UpdateCustomer(TCustomer customer)
        {
            var result=await dBContext.TCustomers
                .FirstOrDefaultAsync(a => a.CustomerId == customer.CustomerId);
            if(result!=null)
            {
                result.CustomerName = customer.CustomerName;
                result.PhoneNo = customer.PhoneNo;
                result.Email = customer.Email;
                result.Address = customer.Address;
                result.Remarks = customer.Remarks;

                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
