using Dapper;
using data;
using data.repositorio;
using Microsoft.AspNetCore.Mvc;
using modelo;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace seguros.data.repositorio
{
    
    public class clienteRepository : iClienteRepository
    {
        public readonly mysql _connection;
        public clienteRepository(mysql connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }
        public async Task<bool> DeleteCliente(int id)
        {
            var db = dbConnection();
            var sql = "@delete from cliente where idCliente=@Id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public  Task<Clientes> GetClienteById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from cliente where idCliente=@Id";
            return db.QueryFirstOrDefaultAsync<Clientes>(consulta, new { Id = id });
        }

        public Task<IEnumerable<Clientes>> getClientes()
        {
            var db = dbConnection();
            var consulta = @"select * from cliente ";
            return db.QueryAsync<Clientes>(consulta);
        }

        public async Task<bool> insertCliente(Clientes cliente)
        {
            var db = dbConnection();
            var sql = @"insert into cliente(Nombre,Documento) values(@Nombre,@Documento)";
            var result = await db.ExecuteAsync(sql, new { cliente.Nombre, cliente.Documento });
            return result > 0;
        }

        public async Task<bool> UpdateCliente(Clientes cliente)
        {
            var db = dbConnection();
            var sql = @"update cliente set Nombre =@Nombre,Documento= @Documento  where idCliente=@Id ";
            var result = await db.ExecuteAsync(sql, new { cliente.Nombre, cliente.Documento, cliente.id });
            return result > 0;
        }
    }
}   
