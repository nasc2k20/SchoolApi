using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly SchoolContext dbContext;

        public GradeController(SchoolContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetGrade()
        {
            return Ok(await dbContext.Grade.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Getgrade([FromRoute] int id)
        {
            var oGrade = dbContext.Grade.FindAsync(id);

            if (oGrade == null)
            {
                return NotFound();
            }

            return Ok(oGrade);
        }

        [HttpPost]
        public async Task<IActionResult> AddGrade(AddGradeModel model)
        {
            var oGrade = new GradeModel()
            {
                Id = model.Id,
                Name = model.Name.ToUpper()
            };

            await dbContext.Grade.AddAsync(oGrade);
            await dbContext.SaveChangesAsync();

            return Ok(oGrade);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateContact([FromRoute] int id, UpdateGradeModel model)
        {
            var oGrade = await dbContext.Grade.FindAsync(id);

            if(oGrade!= null)
            {
                oGrade.Id = model.Id;
                oGrade.Name = model.Name;

                await dbContext.SaveChangesAsync();

                return Ok(oGrade);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            var oGrade = await dbContext.Grade.FindAsync(id);
            if(oGrade != null)
            {
                dbContext.Remove(oGrade);
                await dbContext.SaveChangesAsync();

                return Ok(oGrade);
            }

            return NotFound();
        }
        /*
        public async Task<ActionResult<IEnumerable<GradeModel>>> GetGrade()
        {
            return await dbContext.Grade.ToListAsync();
        }
        */
    }
}
