using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Teretana.Database;
using Teretana.Models;

namespace Teretana.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreneriController : ControllerBase
    {
        private ILog _logiranje;
        private ApplicationDbContext _context;

        public TreneriController(ILog logiranje, ApplicationDbContext context)
        {
            _logiranje = logiranje;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var listaTrenera = new List<TreneriModel>();

            var trenerJedan = new TreneriModel { ID = 1, Ime = "Amar", Prezime = "Čizmić"};
            var trenerDva = new TreneriModel { ID = 2, Ime = "Irena", Prezime = "Katz" };
            var trenerTri = new TreneriModel { ID = 3, Ime = "Saudin", Prezime = "Mulabdić" };
            var trenerCetiri = new TreneriModel { ID = 4, Ime = "Sabina", Prezime = "Vilogorac" };
            var trenerPet = new TreneriModel { ID = 5, Ime = "Aldin", Prezime = "Kahriman" };

            listaTrenera.Add(trenerJedan);
            listaTrenera.Add(trenerDva);
            listaTrenera.Add(trenerTri);
            listaTrenera.Add(trenerCetiri);
            listaTrenera.Add(trenerPet);

            try
            {
                return Ok(listaTrenera);
            }
            catch (System.Exception)
            {
                var greska = "Desila se greska";
                return Problem(detail: greska);
            }
        }

        [HttpPost]
        public IActionResult Post(TreneriModel noviTrener)
        {
            _context.Treneri.Add(noviTrener);
            _context.SaveChanges();

            return Ok();
        }

    }
}
