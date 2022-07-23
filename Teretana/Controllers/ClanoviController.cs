using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teretana.Database;
using Teretana.Models;

namespace Teretana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClanoviController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILog _logiranje;

        public ClanoviController(ApplicationDbContext context, ILog logiranje)
        {
            _context = context;
            _logiranje = logiranje;
        }

        // GET: api/clanovi
        [HttpGet]
        public List<ClanoviModel> GetClanovi()
        {
            return _context.Clanovi.ToList();
        }

        // GET: api/clanovi/gratis
        [HttpGet]
        [Route("gratis")]
        public List<ClanoviModel> GetGratisClanovi()
        {
            var listaGratis = from clanovi in _context.Clanovi
                              where clanovi.Status == "Gratis"
                              select clanovi;

            return listaGratis.ToList();
        }

        // GET: api/clanovi/regular
        [HttpGet]
        [Route("regular")]
        public List<ClanoviModel> GetRegularClanovi()
        {
            var listaRegular = from clanovi in _context.Clanovi
                        where clanovi.Status == "Regular"
                        select clanovi;

            return listaRegular.ToList();
        }

        // GET: api/clanovi
        [HttpGet]
        [Route("{brojKartice}")]
        public List<ClanoviModel> GetClanaPoBrojuKartice(int brojKartice)
        {
            var pretrazivanje = from clanovi in _context.Clanovi
                                where clanovi.BrojKartice == brojKartice
                                select clanovi;

            return pretrazivanje.ToList();
        }

        // PUT: api/Clanovi/update
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutClanoviModel(int id, ClanoviModel clanoviModel)
        {
            if (id != clanoviModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(clanoviModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClanoviModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clanovi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClanoviModel>> PostClanoviModel(ClanoviModel clanoviModel)
        {
            _context.Clanovi.Add(clanoviModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClanoviModel", new { id = clanoviModel.ID }, clanoviModel);
        }

        // DELETE: api/Clanovi/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteClanoviModel(int id)
        {
            var clanoviModel = await _context.Clanovi.FindAsync(id);
            if (clanoviModel == null)
            {
                return NotFound();
            }

            _context.Clanovi.Remove(clanoviModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClanoviModelExists(int id)
        {
            return _context.Clanovi.Any(e => e.ID == id);
        }
    }
}
