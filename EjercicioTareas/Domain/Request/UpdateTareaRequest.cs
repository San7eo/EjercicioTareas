using EjercicioTareas.Domain.DTO;

namespace EjercicioTareas.Domain.Request
{
    public class UpdateTareaRequest
    {
        public int Id { get; set; }

        public string Estado { get; set; } = string.Empty;
    }
}
