using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystamAPI.IRepositories;
using StoreManagementSystamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private readonly IShelfRepository shelfRepository;
        public ShelfController(IShelfRepository shelfRepository)
        {
            this.shelfRepository = shelfRepository;
        }
        [HttpGet(nameof(GetAllShelf))]
        public async Task<ActionResult<IEnumerable<TShelf>>> GetAllShelf()
        {
            try
            {
                return (await shelfRepository.GetAllShelf()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from the database");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TShelf>> GetShelf(int id)
        {
            try
            {
                var result = await shelfRepository.GetShelf(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from the database");
            }
        }
        [HttpPost(nameof(AddNewShelf))]
        public async Task<ActionResult<TShelf>> AddNewShelf(TShelf shelf)
        {
            try
            {
                if(shelf == null)
                {
                    return BadRequest();
                }
                var AddNewShelf = await shelfRepository.AddNewShelf(shelf);
                return CreatedAtAction(nameof(GetShelf), new { id = shelf.ShelfId }, AddNewShelf);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from the database");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TShelf>> UpdateShelf(int id,TShelf shelf)
        {
            try
            {
                if(id!=shelf.ShelfId)
                {
                    return BadRequest("ID Mismatch");
                }
                var UpdateShelf = await shelfRepository.GetShelf(id);
                if (shelf == null)
                {
                    return NotFound();
                }
                return await shelfRepository.UpdateShelf(shelf);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from the database");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TShelf>> DeleteShelf(int id)
        {
            try
            {
                var DeleteShelf = await shelfRepository.GetShelf(id);
                if (DeleteShelf == null)
                {
                    return NotFound();
                }
                return await shelfRepository.DeleteShelf(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from the database");
            }
        }

    }
}
