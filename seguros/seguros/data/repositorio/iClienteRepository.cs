using modelo;
using MySqlX.XDevAPI;
using System;

namespace data.repositorio
{
	public interface iClienteRepository
    {
        Task<IEnumerable<Clientes>> getClientes();
        Task<Clientes> GetClienteById(int id);
        Task<bool> insertCliente(Clientes cliente);
        Task<bool> UpdateCliente(Clientes cliente);
        Task<bool> DeleteCliente(int id);
    }
}
