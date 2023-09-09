using seguros.model;

namespace seguros.data.repositorio
{
    public interface iVentasRepository
    {
        Task<IEnumerable<Ventas>> getVentas();
        Task<bool> insertVentas(Ventas ventas);
        
       
    }
}
