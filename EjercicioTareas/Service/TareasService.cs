using EjercicioTareas.Domain.DTO;
using EjercicioTareas.Domain.Entities;
using EjercicioTareas.Repository;
using EjercicioTareas.Repository.Interfaces;
using EjercicioTareas.Service.InterfazService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Threading;

namespace EjercicioTareas.Service
{
    public class TareasService : ITareasService
    {
        private readonly ITareaRepository _tareaRepository;

        public TareasService(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }
        public async Task<List<Tarea>> GetTareasServiceAsync()
        {
           var result = await _tareaRepository.GetAllTareasAsync();
           return result;
        }
        public async Task<List<Tarea>> GetTareasEliminadasServiceAsync()
        {
            var result = await _tareaRepository.GetTareasEliminadasAsync();
            return result;
        }
        public async Task<List<Tarea>> GetTareasPendientesServiceAsync()
        {
            var result = await _tareaRepository.GetTareasPendientesAsync();
            return result;
        }

        public async Task<List<Tarea>> GetTareasEnCursoServiceAsync()
        {
            var result = await _tareaRepository.GetTareasEnCursoAsync();
            return result;
        }

        public async Task<List<Tarea>> GetTareasFinalizadasServiceAsync()
        {
            var result = await _tareaRepository.GetTareasFinalizadasAsync();
            return result;
        }


        public async Task<bool> AddTareaServiceAsync(TareaDTO tarea)
        {
            var result = await _tareaRepository.AddTareaAsync(tarea);
            return result;
        }

        public async Task<bool> UpdateTareaServiceAsync(int id, string estado)
        {
            var result = await _tareaRepository.UpdateTareaAsync(id,estado);
            return result;
        }

        public async Task<bool> DeleteTareaServiceAsync(int id)
        {
            var result = await _tareaRepository.DeleteTareaAsync(id);
            return result;
        }


    }
}
