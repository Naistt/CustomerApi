using CustomerApi.Application.DTO;
using CustomerApi.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ClienteService service, ILogger<ClienteController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _service.GetByIdAsync(id);
            return customer is null ? NotFound() : Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteDTO dto)
        {
            if (dto is null)
            {
                _logger.LogWarning("Tentativa de criar cliente com dados nulos.");
                return BadRequest("Dados do cliente não podem ser nulos.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Dados do cliente inválidos.");
                return BadRequest(ModelState);
            }

            try
            {
                var created = await _service.CreateAsync(dto);
                _logger.LogInformation("Cliente {Name} criado com sucesso: ", created.Nome);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Erro ao criar cliente: {Message}", ex.Message);
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ClienteDTO dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException) { return NotFound(); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException) { return NotFound(); }
        }
    }

}
