﻿using Microsoft.EntityFrameworkCore;
using StoreManagementSystamAPI.IRepositories;
using StoreManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemAPI.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly StoreManagementSoftwareDBContext dBContext;
        public SupplierRepository(StoreManagementSoftwareDBContext context)
        {
            dBContext = context;
        }
        public async Task<TSupplier> AddNewSupplier(TSupplier supplier)
        {
            var result = await dBContext.TSuppliers.AddAsync(supplier);
            await dBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TSupplier> deleteSupplier(int Id)
        {
            var result = await dBContext.TSuppliers.Where(a => a.SupplierId == Id)
                .FirstOrDefaultAsync();
            if(result!=null)
            {
                dBContext.TSuppliers.Remove(result);
                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<TSupplier>> GetAllSuppliers()
        {
            return await dBContext.TSuppliers.ToListAsync();
        }

        public async Task<TSupplier> GetSupplier(int Id)
        {
            return await dBContext.TSuppliers.FirstOrDefaultAsync(a => a.SupplierId == Id);
        }

        public async Task<TSupplier> UpdateSupplier(TSupplier supplier)
        {
            var result = await dBContext.TSuppliers.FirstOrDefaultAsync(a => a.SupplierId == supplier.SupplierId);
            if(result!=null)
            {
                result.SupplierName = supplier.SupplierName;
                result.PhoneNo = supplier.PhoneNo;
                result.Email = supplier.Email;
                result.Address = supplier.Address;
                result.SupplierDescription = supplier.SupplierDescription;
                result.EntryBy = supplier.EntryBy;
                result.EntryDate = supplier.EntryDate;

                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
