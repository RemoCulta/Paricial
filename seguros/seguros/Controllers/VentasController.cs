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
    public class VentasController : ControllerBase
    {
        
        public readonly iVentasRepository _ventasRepsitory;

        public VentasController(iVentasRepository ventasRepsitory)
        {
            _ventasRepsitory = ventasRepsitory;
        }
        [HttpGet]
        public async Task<IActionResult> getVentas()
        {
            return Ok(await _ventasRepsitory.getVentas());
        }
        [HttpPost]
        public async Task<IActionResult> InsertVentas([FromBody] Ventas ventas)


        {
            if (ventas == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _ventasRepsitory.insertVentas(ventas);
            return Ok(created);
        }
    }
}
