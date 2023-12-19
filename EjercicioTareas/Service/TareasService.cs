using EjercicioTareas.Domain.DTO;
using EjercicioTareas.Domain.Entities;
using EjercicioTareas.Repository;
using EjercicioTareas.Service.InterfazService;
using Microsoft.EntityFrameworkCore;

namespace EjercicioTareas.Service
{
    public class TareasService : ITareasService
    {
        BddService? _context;
        public async Task<List<Tarea>> GetAllTareasAsync()
        {
           return await _context._todoContext.Tareas.ToListAsync();
        }

        public async Task<bool> AddTareaAsync(Tarea tarea)
        {   
            await _context._todoContext.Tareas.AddAsync(tarea);
            int rows = await _context._todoContext.SaveChangesAsync();
             
            return rows > 0;
        }

        public async Task<bool> UpdateTareaAsync(int id, TareaDTO tarea)
        {
            var tareaMatch = await _context._todoContext.Tareas.FirstOrDefaultAsync(t => t.Id == id);

            if (tareaMatch == null) return false;

            tareaMatch.Estado = tarea.Estado;

            tareaMatch.Descripcion = tarea.Descripcion;

            tareaMatch.FechaModificacion = tarea.FechaModificacion;

            tareaMatch.Titulo = tarea.Titulo;

            int rows = await _context._todoContext.SaveChangesAsync();

            return rows > 0;
        }
    }
}
