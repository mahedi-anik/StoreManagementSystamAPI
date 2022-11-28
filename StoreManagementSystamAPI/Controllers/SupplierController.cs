using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystamAPI.IRepositories;
using StoreManagementSystamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository supplierRepository;
        public SupplierController(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        [HttpGet(nameof(GetAllSuppliers))]
        public async Task<ActionResult<IEnumerable<TSupplier>>> GetAllSuppliers()
        {
            try
            {
                return (await supplierRepository.GetAllSuppliers()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TSupplier>> GetSupplier(int id)
        {
            try
            {
                var result = await supplierRepository.GetSupplier(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }
        [HttpPost(nameof(AddNewSupplier))]
        public async Task<ActionResult<TSupplier>> AddNewSupplier(TSupplier supplier)
        {
            try
            {
                if (supplier == null)
                {
                    return BadRequest();
                }
                var AddNewSupplier = await supplierRepository.AddNewSupplier(supplier);
                return CreatedAtAction(nameof(GetSupplier), new { id = supplier.Id }, AddNewSupplier);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TSupplier>> UpdateSupplier(int id, TSupplier supplier)
        {
            try
            {
                if (id != supplier.Id)
                {
                    return BadRequest("ID Mismatch");
                }
                var UpdateSupplier = await supplierRepository.GetSupplier(id);
                if (supplier == null)
                {
                    return NotFound();
                }
                return await supplierRepository.UpdateSupplier(supplier);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TSupplier>> DeleteSupplier(int id)
        {
            try
            {
                var DeleteSupplier = await supplierRepository.GetSupplier(id);
                if (DeleteSupplier == null)
                {
                    return NotFound();
                }
                return await supplierRepository.deleteSupplier(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }


        }
    }
}
