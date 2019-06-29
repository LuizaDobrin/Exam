using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProj.Models;
using ExamProj.Services;
using ExamProj.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacheteController : ControllerBase
    {
        private IPachetService pachetService;
        private IUsersService usersService;

        public PacheteController(IPachetService pachetService,IUsersService usersService)
      
        {
            this.pachetService = pachetService;
            this.usersService = usersService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public PaginatedList<PachetGetModel> Get([FromQuery] int page = 1)
        {
            // TODO: make pagination work with /api/flowers/page/<page number>
            page = Math.Max(page, 1);
            return pachetService.GetAll(page);
           
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // GET: api/Entities/5
        //  [Authorize]
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetById(int id)
        {
            var found = pachetService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }


        ///<remarks>
        /// {
        /// "title": "Entity9",
        /// "description": "Description9",
        /// "genre": 1,
        /// "rating": 8,
        /// "date": "2019-06-06T00:00:00",
        /// "year": "2019",
        ///  }
        ///</remarks>
        /// <summary>
        /// Add entity to database.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // POST: api/Entities
        //  [Authorize(Roles = "Admin,Regular")]

        [HttpPost]

        public void Post([FromBody] PachetPostModel pachet)
        {


            User addedBy = usersService.GetCurrentUser(HttpContext);

             pachetService.Create(pachet, addedBy);

        }

        /// <summary>
        /// Update entity from database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // PUT: api/Entities/5
        // [Authorize(Roles = "Admin,Regular")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pachet pachet)
        {

            var result = pachetService.Upsert(id, pachet);
            return Ok(result);
        }


        /// <summary>
        /// Delete entity from database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // DELETE: api/ApiWithActions/5
        //  [Authorize(Roles = "Admin,Regular")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var result = pachetService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}