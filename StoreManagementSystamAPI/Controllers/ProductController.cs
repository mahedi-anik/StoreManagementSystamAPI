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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet(nameof(GetAllProduct))]
        public async Task<ActionResult<IEnumerable<TProduct>>> GetAllProduct()
        {
            try
            {
                return (await productRepository.GetAllProducts()).ToList();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TProduct>> GetProduct(int id)
        {
            try
            {
                var result = await productRepository.GetProduct(id);
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
        [HttpPost(nameof(AddNewProduct))]
        public async Task<ActionResult<TProduct>> AddNewProduct(TProduct product)
        {
            try
            {
                if(product==null)
                {
                    return BadRequest();
                }
                var AddNewProduct = await productRepository.AddNewProduct(product);
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, AddNewProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TProduct>> UpdateProduct(int id,TProduct product)
        {
            try
            {
                if(id!=product.Id)
                {
                    return BadRequest("ID Mismatch");
                }
                var UpdateProduct = await productRepository.GetProduct(id);
                if(product==null)
                {
                    return NotFound();
                }
                return await productRepository.UpdateProduct(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TProduct>> DeleteProduct(int id)
        {
            try
            {
                var DeleteProduct = await productRepository.GetProduct(id);
                if(DeleteProduct==null)
                {
                    return NotFound();
                }
                return await productRepository.DeleteProduct(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }


    }
}
