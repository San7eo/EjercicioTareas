using EjercicioTareas.Domain.DTO;
using EjercicioTareas.Domain.Entities;
using EjercicioTareas.Repository;

namespace EjercicioTareas.Service.InterfazService
{
    public interface ITareasService
    {
        public Task<List<Tarea>> GetAllTareasAsync();

        public Task<List<Tarea>> GetAllTareasEliminadasAsync();

        public Task<List<Tarea>> GetAllTareasPendientesAsync();

        public Task<List<Tarea>> GetAllTareasEnCursoAsync();

        public Task<List<Tarea>> GetAllTareasFinalizadasAsync();

        public Task<bool> AddTareaAsync(TareaDTO tarea);

        public Task<bool> UpdateTareaAsync(int id, string estado);

        public Task<bool> DeleteTareaAsync(int id);

    }
}
