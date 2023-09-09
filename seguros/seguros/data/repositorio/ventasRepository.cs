using Dapper;
using data;
using modelo;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using seguros.model;

namespace seguros.data.repositorio
{
  
        public class ventasRepository : iVentasRepository
        {
            public readonly mysql _connection;
            public ventasRepository(mysql connection)
            {
                _connection = connection;
            }
            protected MySqlConnection dbConnection()
            {
                return new MySqlConnection(_connection._connectionString);
            }

            public  Task<IEnumerable<Ventas>> getVentas()
            {
                var db = dbConnection();
                var consulta = @"select * from ventas ";
                return db.QueryAsync<Ventas>(consulta);
            }

            public async Task<bool> insertVentas(Ventas ventas)
            {
            var db = dbConnection();
            var sql = @"insert into ventas (Fecha_venta,Empleados_idEmpleados,Productos_idProductos,Cliente_idCliente,ventas) values(@Fecha_venta,@Empleados_idEmpleados,@Productos_idProductos,@Cliente_idCliente,@ventas)";
            var result = await db.ExecuteAsync(sql, new { ventas.Fecha_venta, ventas.Empleados_idEmpleados,ventas.Productos_idProductos,ventas.Cliente_idCliente,ventas.ventas});
            return result > 0;
        }
    }
    
}