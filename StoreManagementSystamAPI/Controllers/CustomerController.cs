using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystamAPI.IRepositories;
using StoreManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet(nameof(GetAllCustomer))]
        public async Task<ActionResult<IEnumerable<TCustomer>>> GetAllCustomer()
        {
            try
            {
                return (await customerRepository.GetAllCustomers()).ToList();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TCustomer>> GetCustomer(int id)
        {
            try
            {
                var result = await customerRepository.GetCustomer(id);
                if(result==null)
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
        [HttpPost(nameof(AddNewCustomer))]
        public async Task<ActionResult<TCustomer>> AddNewCustomer(TCustomer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest();
                }
                var AddNewCustomer = await customerRepository.AddNewCustomer(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, AddNewCustomer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TCustomer>> UpdateCustomer(int id,TCustomer customer)
        {
            try
            {
                if(id!=customer.CustomerId)
                {
                    return BadRequest("ID Mismatch");
                }
                var UpdateCustomer = await customerRepository.GetCustomer(id);
                if(customer==null)
                {
                    return NotFound();
                }
                return await customerRepository.UpdateCustomer(customer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TCustomer>> DeleteCustomer(int id)
        {
            try
            {
                var DeleteCustomer = await customerRepository.GetCustomer(id);
                if(DeleteCustomer==null)
                {
                    return NotFound();
                }
                return await customerRepository.DeleteCustomer(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }

    }
}
