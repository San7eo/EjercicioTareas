using EjercicioTareas.Domain.DTO;
using EjercicioTareas.Domain.Entities;
using EjercicioTareas.Repository;
using EjercicioTareas.Service.InterfazService;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace EjercicioTareas.Service
{
    public class TareasService : ITareasService
    {
        private readonly ToDOContext _todoContext;

        public TareasService(ToDOContext context)
        {
            _todoContext = context;
        }
        public async Task<List<Tarea>> GetAllTareasAsync()
        {
           return await _todoContext.Tareas
                                            .Where(w=> w.Activo)
                                            .ToListAsync();
        }

        public async Task<List<Tarea>> GetAllTareasPendientesAsync()
        {
            return await _todoContext.Tareas
                                            .Where (w=> w.Activo && w.Estado == "PENDIENTE")
                                            .ToListAsync();
        }

        public async Task<List<Tarea>> GetAllTareasEnCursoAsync()
        {
            return await _todoContext.Tareas
                                            .Where(w => w.Activo && w.Estado == "EN CURSO")
                                            .ToListAsync();
        }

        public async Task<List<Tarea>> GetAllTareasFinalizadasAsync()
        {
            return await _todoContext.Tareas
                                            .Where(w => w.Activo && w.Estado == "FINALIZADO")
                                            .ToListAsync();
        }

        public async Task<List<Tarea>> GetAllTareasEliminadasAsync()
        {
            return await _todoContext.Tareas
                                            .Where(w => !w.Activo)
                                            .ToListAsync();
        }
        public async Task<bool> AddTareaAsync(TareaDTO tarea)
        {
            var newTarea = new Tarea();
            int rows = 0;

            if ( tarea.Titulo.Trim() != "" && tarea.Descripcion.Trim() != "" )    
            {
                
                newTarea.Titulo = tarea.Titulo;

                newTarea.Descripcion = tarea.Descripcion;

                newTarea.Activo = true;

                newTarea.FechaAlta = DateTime.Now;

                newTarea.FechaModificacion = DateTime.Now;

                if ((tarea.Estado.ToLower().Trim() == "pendiente" || tarea.Estado.ToLower().Trim() == "en curso" || tarea.Estado.ToLower().Trim() == "finalizado"))
                {   

                    newTarea.Estado = tarea.Estado.ToUpper();

                    await _todoContext.Tareas.AddAsync(newTarea);

                    rows = await _todoContext.SaveChangesAsync();
                }
                else if (tarea.Estado.ToLower().Trim() == "" )
                {
                    newTarea.Estado = "PENDIENTE";

                    await _todoContext.Tareas.AddAsync(newTarea);

                    rows = await _todoContext.SaveChangesAsync();
                }

            }
            return rows > 0;
        }

        public async Task<bool> UpdateTareaAsync(int id, string estado)
        {   
            int rows = 0;
            var tareaMatch = await _todoContext.Tareas.FirstOrDefaultAsync(t => t.Id == id);

            if (tareaMatch == null) return false;

            if ((estado.ToLower().Trim() == "pendiente" || estado.ToLower().Trim() == "en curso" || estado.ToLower().Trim() == "finalizado"))
            {
                tareaMatch.Estado = estado;
                tareaMatch.FechaModificacion = DateTime.Now;
                rows = await _todoContext.SaveChangesAsync();
            }
         
            return rows > 0;
        }

        public async Task<bool> DeleteTareaAsync(int id)
        {
            int rows = 0;
            var tareaMatch = await _todoContext.Tareas.FirstOrDefaultAsync(t => t.Id == id);

            if (tareaMatch == null) { return false; }

            tareaMatch.Activo = false;
            rows = await _todoContext.SaveChangesAsync();

            return rows > 0;
        }
    }
}
