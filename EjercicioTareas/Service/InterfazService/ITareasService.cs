using EjercicioTareas.Domain.DTO;
using EjercicioTareas.Domain.Entities;
using EjercicioTareas.Repository;

namespace EjercicioTareas.Service.InterfazService
{
    public interface ITareasService
    {
        public Task<List<Tarea>> GetTareasServiceAsync();

        public Task<List<Tarea>> GetTareasEliminadasServiceAsync();

        public Task<List<Tarea>> GetTareasPendientesServiceAsync();

        public Task<List<Tarea>> GetTareasEnCursoServiceAsync();

        public Task<List<Tarea>> GetTareasFinalizadasServiceAsync();

        public Task<bool> AddTareaServiceAsync(TareaDTO tarea);

        public Task<bool> UpdateTareaServiceAsync(int id, string estado);

        public Task<bool> DeleteTareaServiceAsync(int id);

    }
}
