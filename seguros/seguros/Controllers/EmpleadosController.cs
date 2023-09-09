using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modelo;
using seguros.data.repositorio;
using seguros.model;

namespace seguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        public readonly iEmpleadosRepository _empleadosRepsitory;

        public EmpleadosController(iEmpleadosRepository empleadosRepsitory)
        {
            _empleadosRepsitory = empleadosRepsitory;
        }
        [HttpGet]
        public async Task<IActionResult> getEmpleados()
        {
            return Ok(await _empleadosRepsitory.getEmpleados());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpleadosById(int id)
        {
            return Ok(await _empleadosRepsitory.GetEmpleadosById(id));
        }
        [HttpPost]
        public async Task<IActionResult> insertEmpleados([FromBody] Empleados empleados)


        {
            if (empleados == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _empleadosRepsitory.insertEmpleados(empleados);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmpleados([FromBody] Empleados empleados)

        {
            if (empleados == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var update = await _empleadosRepsitory.UpdateEmpleados(empleados);
            return Ok(update);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmpleados(int id)

        {
            return Ok(await _empleadosRepsitory.DeleteEmpleados(id));

        }
    }
}