using Plants.REST.Models;
using Plants.REST.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Plants.REST.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
private readonly ICrudServiceAsync<Author> _service;


public AuthorsController(ICrudServiceAsync<Author> service)
{
_service = service;
}


[HttpGet]
public async Task<IActionResult> GetAll() => Ok(await _service.ReadAllAsync());


[HttpGet("{id}")]
public async Task<IActionResult> Get(Guid id)
{
var item = await _service.ReadAsync(id);
if (item == null) return NotFound();
return Ok(item);
}


[HttpPost]
public async Task<IActionResult> Create([FromBody] Author author)
{
if (!ModelState.IsValid) return BadRequest(ModelState);
var created = await _service.CreateAsync(author);
if (!created) return StatusCode(500);
return CreatedAtAction(nameof(Get), new { id = author.Id }, author);
}


[HttpPut("{id}")]
public async Task<IActionResult> Update(Guid id, [FromBody] Author author)
{
if (id != author.Id) return BadRequest();
var exists = await _service.ReadAsync(id);
if (exists == null) return NotFound();
var ok = await _service.UpdateAsync(author);
if (!ok) return StatusCode(500);
return NoContent();
}


[HttpDelete("{id}")]
public async Task<IActionResult> Delete(Guid id)
{
var item = await _service.ReadAsync(id);
if (item == null) return NotFound();
var ok = await _service.RemoveAsync(item);
if (!ok) return StatusCode(500);
return NoContent();
}
}
}
