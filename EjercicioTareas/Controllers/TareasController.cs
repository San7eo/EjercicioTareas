using EjercicioTareas.Domain.DTO;
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

        [HttpGet("Lista-tareas")]
        public async Task<IActionResult> GetTareas()
        {
            var result = await _tareasService.GetTareasServiceAsync();

            return Ok(result);  

        }

        [HttpGet("tareas-Eliminadas")]
        public async Task<IActionResult> GetTareasEliminadas()
        {
            var result = await _tareasService.GetTareasEliminadasServiceAsync();

            return Ok(result);
        }

        [HttpGet("tareas-PENDIENTES")]
        public async Task<IActionResult> GetTareasPendientes()
        {
            var result = await _tareasService.GetTareasPendientesServiceAsync();

            return Ok(result);

        }

        [HttpGet("tareas-EN-CURSO")]
        public async Task<IActionResult> GetTareasEnCurso()
        {
            var result = await _tareasService.GetTareasEnCursoServiceAsync();

            return Ok(result);

        }

        [HttpGet("tareas-FINALIZADAS")]
        public async Task<IActionResult> GetTareasFinalizadas()
        {
            var result = await _tareasService.GetTareasFinalizadasServiceAsync();

            return Ok(result);

        }

        [HttpPost("Crear-Tarea")]
        public async Task<IActionResult> AddTarea([FromBody] TareaDTO request )
        {
            var result = await _tareasService.AddTareaServiceAsync(request);

            if (!result) return BadRequest(new { Message = "Se ha rechazado la tarea!"});

            return Created("", new { Message = "Se a creado la tarea correctamente" });
        }

        [HttpPut("Modificar-tarea")]
        public async Task<IActionResult> UpdateTarea([FromBody] UpdateTareaRequest request)
        {
            var result = await _tareasService.UpdateTareaServiceAsync(request.Id, request.Estado);

            if (!result) return BadRequest(new { Message = "No se pudo modificar la tarea" });

            return Ok(new { Message = " Modificada la tarea correctamente " });
        }

        [HttpDelete("Eliminar-tarea")]
        public async Task<IActionResult> DeleteTarea([FromBody] int id)
        {
            var result = await _tareasService.DeleteTareaServiceAsync(id);

            if (!result) return BadRequest(new { Message = "No se pudo eliminar la tarea correctamente" });

            return Ok(new {Message = " Se ha eliminado correctamente la tarea "});
        }
    }
}
