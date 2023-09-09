namespace seguros.model
{
    public class Ventas
    {
        public int id { get; set; }
        public string Fecha_venta { get; set; }
        public int Empleados_idEmpleados { get; set; }
        public int Productos_idProductos { get; set; }
        public int Cliente_idCliente { get; set; }
        public bool ventas  { get; set; }
    }
}
