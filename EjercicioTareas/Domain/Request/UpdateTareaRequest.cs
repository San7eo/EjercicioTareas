using EjercicioTareas.Domain.DTO;

namespace EjercicioTareas.Domain.Request
{
    public class UpdateTareaRequest
    {
        public int Id { get; set; }

        public TareaDTO InfoTarea { get; set; }
    }
}
