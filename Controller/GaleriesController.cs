using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperGalerieInfinie.Data;
using SuperGalerieInfinie.Models;

namespace SuperGalerieInfinie.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class GaleriesController : ControllerBase
    {
        private readonly SuperGalerieInfinieContext _context;

        public GaleriesController(SuperGalerieInfinieContext context)
        {
            _context = context;
        }

        // GET: api/Galeries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galerie>>> GetGaleries()
        {
            if (_context.Galeries == null)
            {
                return NotFound();
            }
            /// trouver le user
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                return user.Galeries;
            }

            return StatusCode(StatusCodes.Status400BadRequest,
                new { Messsage = "Utilisateur non trouver" });

        }

        // GET: api/Galeries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Galerie>> GetGalerie(int id)
        {
            if (_context.Galeries == null)
            {
                return NotFound();
            }
            var galerie = await _context.Galeries.FindAsync(id);

            if (galerie == null)
            {
                return NotFound();
            }

            return galerie;
        }

        // PUT: api/Galeries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalerie(int id, Galerie galerie)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            if (id != galerie.Id)
            {
                return BadRequest();
            }

            Galerie? oldGalerie = await _context.Galeries.FindAsync(id);

            if(user == null || _context.Galeries == null || oldGalerie == null)
            {
                return NotFound();
            }

            if (!user.Galeries.Contains(oldGalerie)) // utilisateur pas proprio
            {
                return Unauthorized(new { Message = "Hey dont touch it, its not yours!" });
            }

            // Remplace ancien galerie avec l'id par la Galerie galrie recue

            oldGalerie.Publique = galerie.Publique;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await _context.Galeries.AnyAsync(x => x.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { Message = "Galerie modifiee"});
        }

        // POST: api/Galeries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Galerie>> PostGalerie(Galerie galerie)
        {
            if (_context.Galeries == null)
            {
                return Problem("Entity set 'SuperGalerieInfinieContext.Galeries'  is null.");
            }

            //Trouver le user
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                //remplit les refenreces de relation
                galerie.Utilisateurs = new List<User>();
                galerie.Utilisateurs.Add(user);

                user.Galeries.Add(galerie);

                // on a ajoute l'objet dans la bd
                _context.Galeries.Add(galerie);
                await _context.SaveChangesAsync();
                return CreatedAtAction("PostGalerie", new { id = galerie.Id }, galerie);

            }

            return StatusCode(StatusCodes.Status400BadRequest,
                new { Message = "Utilisateur non trouver" });
        }

        // DELETE: api/Galeries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalerie(int id)
        {

            //Trouver le user
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            var galerie = await _context.Galeries.FindAsync(id);

            if (_context.Galeries == null || user == null || galerie == null)
            {
                return NotFound();
            }
            
            // pas priopo de la galerie
            if (!user.Galeries.Contains(galerie))
            {
                return Unauthorized(new { Message = "Hey dont touch it, its not yours!" });
            }

            //supprimer
            _context.Galeries.Remove(galerie);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Galerie deleted" });
        }

        private bool GalerieExists(int id)
        {
            return (_context.Galeries?.Any(e => e.Id == id)).GetValueOrDefault();


        }


        [HttpGet]
        [Route("/api/Galeries/GetPublicGaleries")]
        public async Task<ActionResult<IEnumerable<Galerie>>> GetPublicGaleries()
        {

            return await _context.Galeries.Where(p=> p.Publique.Equals(true)).ToListAsync();

        }
    


    }


}
