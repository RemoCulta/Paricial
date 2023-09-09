using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modelo;
using MySqlX.XDevAPI;

namespace seguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly iClienteRepository _clienteRepsitory;

        public ClienteController(iClienteRepository clienteRepsitory)
        {
            _clienteRepsitory = clienteRepsitory;
        }
        [HttpGet]
        public async Task<IActionResult> getClientes()
        {
            return Ok( await _clienteRepsitory.getClientes());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getClientesByid(int id)
        {
            return Ok(await _clienteRepsitory.GetClienteById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertClientes([FromBody] Clientes cliente)


        {
            if (cliente == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _clienteRepsitory.insertCliente(cliente);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateClientes([FromBody] Clientes cliente)

        {
            if (cliente == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var update = await _clienteRepsitory.UpdateCliente(cliente);
            return Ok(update);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteClientesById(int id)

        {
            return Ok(await _clienteRepsitory.DeleteCliente(id));

        }
    }
}