using EjercicioTareas.Domain.Entities;
using EjercicioTareas.Domain.Request;
using EjercicioTareas.Service.InterfazService;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioTareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private ITareasService _tareasService;
        public TareasController(ITareasService tareasService) 
        { 
            _tareasService = tareasService;
        }

        [HttpGet]

        public async Task<IActionResult> GetTareas()
        {
            var result = await _tareasService.GetAllTareasAsync();

            return Ok(result);  

        }

        [HttpPost]
        public async Task<IActionResult> AddTarea([FromBody] Tarea request )
        {
            var result = await _tareasService.AddTareaAsync(request);

            if (!result) return BadRequest(new { Message = "No ha rechazado la tarea!"});
            return Created("", new { Message = "Se a creado la tarea correctamente" });
        }

        [HttpPut]

        public async Task<IActionResult> UpdateTarea([FromBody] UpdateTareaRequest request)
        {
            var result = await _tareasService.UpdateTareaAsync(request.Id, request.InfoTarea);

            if (!result) return BadRequest(new { Message = "No se pudo modificar la tarea" });

            return Ok(new { Message = " Modificada la tarea correctamente " });
        }
    }
}
