using EjercicioTareas.Domain.DTO;
using EjercicioTareas.Domain.Entities;
using EjercicioTareas.Repository;

namespace EjercicioTareas.Service.InterfazService
{
    public interface ITareasService
    {
        public Task<List<Tarea>> GetAllTareasAsync();

        public Task<bool> AddTareaAsync(Tarea tarea);

        public Task<bool> UpdateTareaAsync(int id, TareaDTO tarea);
    }
}
