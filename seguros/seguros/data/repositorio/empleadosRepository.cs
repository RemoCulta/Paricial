using Dapper;
using data;
using Microsoft.AspNetCore.Mvc;
using modelo;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using seguros.model;

namespace seguros.data.repositorio
{
    public class empleadosRepository : iEmpleadosRepository
    {
        public readonly mysql _connection;
        public empleadosRepository(mysql connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }
        public async Task<bool> DeleteEmpleados(int id)
        {
            var db = dbConnection();
            var sql = @"delete from empleados where idEmpleados=@Id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public Task<IEnumerable<Empleados>> getEmpleados()
        {
            var db = dbConnection();
            var consulta = @"select * from empleados ";
            return db.QueryAsync<Empleados>(consulta);
        }

        public Task<Empleados> GetEmpleadosById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from empleados where idEmpleados=@Id";
            return db.QueryFirstOrDefaultAsync<Empleados>(consulta, new { Id = id });
        }

        public async Task<bool> insertEmpleados(Empleados empleados)
        {
            var db = dbConnection();
            var sql = @"insert into empleados(Nombre,Rol,Documento) values(@Nombre,@Rol,@Documento)";
            var result = await db.ExecuteAsync(sql, new { empleados.Nombre, empleados.Rol, empleados.Documento });
            return result > 0;
        }

        
        public async Task<bool> UpdateEmpleados(Empleados empleados)
        {
            var db = dbConnection();
            var sql = @"update empleados set Nombre =@Nombre,Rol =@Rol,Documento= @Documento  where idEmpleados=@Id ";
            var result = await db.ExecuteAsync(sql, new {empleados.Nombre, empleados.Rol, empleados.Documento , empleados.id });
            return result > 0;
        }

    }
}
       
  

