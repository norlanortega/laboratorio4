using ejemploSProyB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

public class Conexion
{
    private static string cadenaConexion = "Server=localhost; Database=productosdb; Uid=root;pwd=@Soylucasperri01";

    public static MySqlConnection ObtenerConexion()
    {
        try
        {
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            return (conexion);
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al conectar: " + ex.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error inesperado al conectar: " + ex.Message);
            return null;
        }
    }

    // =========================
    // SELECT
    // =========================
    public static List<Producto> GetProductos(string filtro)
    {
        List<Producto> listaProductos = new List<Producto>();
        string query = "SELECT id, nombre, precio, cantidad, imagen FROM productos";
        if (!string.IsNullOrEmpty(filtro))
        {
            query += " WHERE id LIKE @filtro OR nombre LIKE @filtro " +
            " OR precio LIKE @filtro OR cantidad LIKE @filtro";
        }

        try
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                if (conn == null) return listaProductos;

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    }

                    using (MySqlDataReader mReader = cmd.ExecuteReader())
                    {
                        while (mReader.Read())
                        {
                            Producto prod = new Producto();

                            prod.Id = Convert.ToInt32(mReader["id"]);
                            prod.Nombre = mReader["nombre"].ToString();
                            prod.Precio = Convert.ToDecimal(mReader["precio"]);
                            prod.Cantidad = Convert.ToInt32(mReader["cantidad"]);
                            prod.Imagen = mReader["imagen"] != DBNull.Value ? (byte[])mReader["imagen"] : null;

                            listaProductos.Add(prod);
                        }
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al obtener productos: " + ex.Message);
        }

        return listaProductos;
    }

    // =========================
    // INSERT
    // =========================
    public static bool InsertarProducto(Producto p)
    {
        string query = "INSERT INTO productos (id, nombre, precio, cantidad, imagen) " +
                       "VALUES (@id, @nombre, @precio, @cantidad, @imagen)";

        try
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                if (conn == null) return false;

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@precio", p.Precio);
                    cmd.Parameters.AddWithValue("@cantidad", p.Cantidad);
                    cmd.Parameters.AddWithValue("@imagen", (object)p.Imagen ?? DBNull.Value);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al insertar producto: " + ex.Message);
            return false;
        }
    }

    // =========================
    // UPDATE
    // =========================
    public static bool ModificarProducto(Producto p)
    {
        // Si el usuario no cambió la imagen, no la sobreescribimos con null
        string query = p.Imagen != null
            ? "UPDATE productos SET nombre=@nombre, precio=@precio, cantidad=@cantidad, imagen=@imagen WHERE id=@id"
            : "UPDATE productos SET nombre=@nombre, precio=@precio, cantidad=@cantidad WHERE id=@id";

        try
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                if (conn == null) return false;

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@precio", p.Precio);
                    cmd.Parameters.AddWithValue("@cantidad", p.Cantidad);

                    if (p.Imagen != null)
                        cmd.Parameters.AddWithValue("@imagen", p.Imagen);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al modificar producto: " + ex.Message);
            return false;
        }
    }

    // =========================
    // DELETE
    // =========================
    public static bool EliminarProducto(int id)
    {
        string query = "DELETE FROM productos WHERE id=@id";

        try
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                if (conn == null) return false;

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al eliminar producto: " + ex.Message);
            return false;
        }
    }

    // =========================
    // Verificar si un ID ya existe (para btnGuardar)
    // =========================
    public static bool ExisteId(int id)
    {
        string query = "SELECT COUNT(*) FROM productos WHERE id=@id";

        try
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                if (conn == null) return false;

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al verificar id: " + ex.Message);
            return false;
        }
    }
}