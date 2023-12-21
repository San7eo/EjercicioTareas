using EjercicioTareas.Domain.DTO;
using EjercicioTareas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EjercicioTareas.Repository.Interfaces
{
    public class TareaRepository : ITareaRepository
    {
        private readonly ToDOContext _todoContext;

        public TareaRepository(ToDOContext context)
        {
            _todoContext = context;
        }

        public async Task<List<Tarea>> GetAllTareasAsync()
        {
            return await _todoContext.Tareas
                                            .Where(w => w.Activo)
                                            .ToListAsync();
        }

        public async Task<List<Tarea>> GetTareasEliminadasAsync()
        {
            return await _todoContext.Tareas
                                .Where(w => !w.Activo)
                                .ToListAsync();
        }

        public async Task<List<Tarea>> GetTareasPendientesAsync()
        {
            return await _todoContext.Tareas
                                .Where(w => w.Activo && w.Estado.ToUpper() == "PENDIENTE")
                                .ToListAsync();
        }

        public async Task<List<Tarea>> GetTareasEnCursoAsync()
        {
            return await _todoContext.Tareas
                                .Where(w => w.Activo && w.Estado.ToUpper() == "EN CURSO")
                                .ToListAsync();
        }

        public async Task<List<Tarea>> GetTareasFinalizadasAsync()
        {
            return await _todoContext.Tareas
                                .Where(w => w.Activo && w.Estado.ToUpper() == "FINALIZADO")
                                .ToListAsync();
        }

        public async Task<bool> AddTareaAsync(TareaDTO tarea)
        {
            var newTarea = new Tarea();
            int rows = 0;

            if (!tarea.Titulo.Trim().IsNullOrEmpty() && !tarea.Descripcion.Trim().IsNullOrEmpty())
            {

                newTarea.Titulo = tarea.Titulo;

                newTarea.Descripcion = tarea.Descripcion;

                newTarea.Activo = true;

                newTarea.FechaAlta = DateTime.Now;

                newTarea.FechaModificacion = DateTime.Now;

                if (Comprobacion(tarea.Estado))
                {
                    newTarea.Estado = tarea.Estado.ToUpper();
                }
                else if (tarea.Estado.ToLower().Trim().IsNullOrEmpty())
                {
                    newTarea.Estado = "PENDIENTE";
                }

                await _todoContext.Tareas.AddAsync(newTarea);
                rows = await _todoContext.SaveChangesAsync();
            }
            return rows > 0;
        }

        public async Task<bool> UpdateTareaAsync(int id, string estado)
        {
            int rows = 0;
            var tareaMatch = await _todoContext.Tareas.FirstOrDefaultAsync(t => t.Id == id);

            if (tareaMatch == null) return false;

            if (Comprobacion(estado))
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



        public bool Comprobacion(string estado)
        {
            bool valido = false;

            if ((estado.ToLower().Trim() == "pendiente" || estado.ToLower().Trim() == "en curso" || estado.ToLower().Trim() == "finalizado"))
            {
                valido = true;
            }

            return valido;
        }


    }
}
