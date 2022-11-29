using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystamAPI.IRepositories;
using StoreManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        [HttpGet(nameof(GatAllProductCategory))]
        public async Task<ActionResult<IEnumerable<TProductCategory>>> GatAllProductCategory()
        {
            try
            {
                return (await productCategoryRepository.GetAllProductCategories()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TProductCategory>> GetProductCategory(int id)
        {
            try
            {
                var result = await productCategoryRepository.GetProductCategory(id);
                if(result==null)
                {
                    return NotFound();
                }
                return result;
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }

        [HttpPost(nameof(AddNewProductCategory))]
        public async Task<ActionResult<TProductCategory>> AddNewProductCategory(TProductCategory productCategory)
        {
            try
            {
                if(productCategory==null)
                {
                    return BadRequest();
                }
                var AddNewProductCategory = await productCategoryRepository.AddNewProductCategory(productCategory);
                return CreatedAtAction(nameof(GetProductCategory), new { id = productCategory.ProductCategoryId }, AddNewProductCategory);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error in retrieving data from database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TProductCategory>> UpdateProductCategory(int id,TProductCategory productCategory)
        {
            try
            {
                if(id!=productCategory.ProductCategoryId)
                {
                    return BadRequest("ID Mismatch");
                }
                var UpdateProductCategory = await productCategoryRepository.GetProductCategory(id);
                if(productCategory==null)
                {
                    return NotFound();
                }
                return await productCategoryRepository.UpdateProductCategory(productCategory);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error in retrieving data from database");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TProductCategory>> DeleteProductCategory(int id)
        {
            try
            {
                var DeleteProductCategory = await productCategoryRepository.GetProductCategory(id);
                if(DeleteProductCategory==null)
                {
                    return NotFound();
                }
                return await productCategoryRepository.DeleteProductCategory(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error in retrieving data from database");
            }
        }



    }
        
}
