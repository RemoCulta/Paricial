using modelo;
using seguros.model;

namespace seguros.data.repositorio
{
    public interface iEmpleadosRepository
    {
        
        
            Task<IEnumerable<Empleados>> getEmpleados();
            Task<Empleados> GetEmpleadosById(int id);
            Task<bool> insertEmpleados(Empleados empleados);
            Task<bool> UpdateEmpleados(Empleados empleados);
            Task<bool> DeleteEmpleados(int id);
     }
}
