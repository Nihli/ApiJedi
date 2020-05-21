using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using API_StarWars.Data;
using API_StarWars.Models;

namespace API_StarWars.Controllers
{
    [ApiController]
    [Route("jedi")]
    public class JediController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Jedi>> GetJedi(
            [FromServices] DataContext dataContext,
            int id
        )
        {
            Jedi jedi = await dataContext.JediSet.FirstOrDefaultAsync(x => x.Id == id);
            if(jedi != null)
            {
                return Ok(jedi);
            }
            return NotFound("Jedi não encontrado!");
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Jedi>> CreateJedi(
            [FromServices] DataContext dataContext,
            [FromBody] Jedi jedi
        )
        {
            dataContext.JediSet.Add(jedi);
            await dataContext.SaveChangesAsync();
            return Ok(jedi);
        }

        [HttpGet]
        [Route("jediNoPlural")]
        public async Task<ActionResult<List<Jedi>>> GetJediNoPlural(
            [FromServices] DataContext dataContext
        )
        {
            List<Jedi> jediNoPlural = await dataContext.JediSet.ToListAsync();
            return Ok(jediNoPlural);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<ActionResult<string>> RemoveJedi([FromServices] DataContext dataContext, int id)
        {
            Jedi jedi = await dataContext.JediSet.FirstOrDefaultAsync(x => x.Id == id);
            
            if (jedi == null)
            {
                return BadRequest("Jedi não encontrado.");
            }

            dataContext.JediSet.Remove(jedi);
            await dataContext.SaveChangesAsync();

            return Ok("Jedi eliminado.");
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Jedi>> UpdateJedi(
            [FromServices] DataContext dataContext,
            [FromBody] Jedi jedi
        )
        {
            Jedi jedi2 = await dataContext.JediSet.FirstOrDefaultAsync(x => x.Id == jedi.Id);

            if (jedi2 == null)
            {
                return NotFound("Jedi não encontrado.");
            }

            dataContext.Entry(jedi2).CurrentValues.SetValues(jedi);
            await dataContext.SaveChangesAsync();

            return Ok(jedi);
        }
    }
}