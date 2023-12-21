using EjercicioTareas.Domain.DTO;
using EjercicioTareas.Domain.Entities;

namespace EjercicioTareas.Repository.Interfaces
{
    public interface ITareaRepository
    {
        public Task<List<Tarea>> GetAllTareasAsync();

        public Task<List<Tarea>> GetTareasEliminadasAsync();

        public Task<List<Tarea>> GetTareasPendientesAsync();

        public Task<List<Tarea>> GetTareasEnCursoAsync();

        public Task<List<Tarea>> GetTareasFinalizadasAsync();

        public Task<bool> AddTareaAsync(TareaDTO tarea);

        public Task<bool> UpdateTareaAsync(int id, string estado);

        public Task<bool> DeleteTareaAsync(int id);
    }
}
