using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantsApp.Identity;
using PlantsApp.Entities;
using System.Security.Claims;

namespace PlantsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PlantsController(ApplicationDbContext db) => _db = db;

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetPlants() => Ok(_db.Plants.ToList());

        [HttpPost("{id}/care")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddPlantCare(int id, [FromBody] string notes)
        {
            var plant = await _db.Plants.FindAsync(id);
            if (plant == null) return NotFound();

            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var care = new PlantCare { PlantId = id, UserId = userId, CareDate = DateTime.UtcNow, Notes = notes };
            _db.PlantCares.Add(care);
            await _db.SaveChangesAsync();

            return Ok(new { message = "Plant care added" });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Gardener")]
        public async Task<IActionResult> UpdatePlant(int id, [FromBody] Plant updated)
        {
            var plant = await _db.Plants.FindAsync(id);
            if (plant == null) return NotFound();

            plant.Name = updated.Name;
            plant.Species = updated.Species;
            await _db.SaveChangesAsync();

            return Ok(plant);
        }
    }
}
