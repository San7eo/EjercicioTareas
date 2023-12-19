namespace EjercicioTareas.Repository
{
    public class BddService
    {
        public readonly ToDOContext _todoContext;

        public BddService(ToDOContext context)
        {
            _todoContext = context;
        }
    }
}
