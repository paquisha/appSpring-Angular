using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PruebaMVCVehiculos.Models;
using System.Data;

namespace PruebaMVCVehiculos.Datos
{
    public class VehiculoDatos
    {
        //listar vehiculos
        public List<Vehiculo> Listar()
        {
            var oLista = new List<Vehiculo>();

            var cn = new Conexion();

            using (var connexion = new SqlConnection(cn.getCadenaSql()))
            {
                connexion.Open();

                SqlCommand cmd = new SqlCommand("sp_Listar", connexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    try
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Vehiculo()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                codigo = dr["codigo"].ToString(),
                                chasis = dr["chasis"].ToString(),
                                marca = dr["marca"].ToString(),
                                modelo = dr["modelo"].ToString(),
                                anio_modelo = Convert.ToInt32(dr["anio_modelo"]),
                                color = dr["color"].ToString(),
                                estado = dr["estado"].ToString(),
                                fecha_registro = Convert.ToDateTime(dr["fecha_registro"])
                            });
                        }
                    }catch(IndexOutOfRangeException ioer)
                    {
                        Console.WriteLine("Error" + ioer.Message);
                    }
                }
            }
            return oLista;
        }

        //buscar por id
        public Vehiculo ObtenerPorId(int id)
        {
            Vehiculo vehiculo = new Vehiculo();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vehiculo.id = Convert.ToInt32(dr["id"]);
                        vehiculo.codigo = dr["codigo"].ToString();
                        vehiculo.chasis = dr["chasis"].ToString();
                        vehiculo.marca = dr["marca"].ToString();
                        vehiculo.modelo = dr["modelo"].ToString();
                        vehiculo.anio_modelo = Convert.ToInt32(dr["anio_modelo"]);
                        vehiculo.color = dr["color"].ToString();
                        vehiculo.estado = dr["estado"].ToString();
                        vehiculo.fecha_registro = Convert.ToDateTime(dr["fecha_registro"]);
                    }
                }
            }
            return vehiculo;
        }

        //Guardar Vehiculo
        public bool Guardar(Vehiculo vehiculo)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("codigo", vehiculo.codigo);
                    cmd.Parameters.AddWithValue("chasis", vehiculo.chasis);
                    cmd.Parameters.AddWithValue("marca", vehiculo.marca);
                    cmd.Parameters.AddWithValue("modelo", vehiculo.modelo);
                    cmd.Parameters.AddWithValue("anio_modelo", vehiculo.anio_modelo);
                    cmd.Parameters.AddWithValue("color", vehiculo.color);
                    cmd.Parameters.AddWithValue("estado", vehiculo.estado);
                    cmd.Parameters.AddWithValue("fecha_registro", vehiculo.fecha_registro);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                respuesta = false;
            }

            return respuesta;
        }

        //Editar por id
        public bool Editar(Vehiculo vehiculo)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("id", vehiculo.id);
                    cmd.Parameters.AddWithValue("codigo", vehiculo.codigo);
                    cmd.Parameters.AddWithValue("chasis", vehiculo.chasis);
                    cmd.Parameters.AddWithValue("marca", vehiculo.marca);
                    cmd.Parameters.AddWithValue("modelo", vehiculo.modelo);
                    cmd.Parameters.AddWithValue("anio_modelo", vehiculo.anio_modelo);
                    cmd.Parameters.AddWithValue("color", vehiculo.color);
                    cmd.Parameters.AddWithValue("estado", vehiculo.estado);
                    cmd.Parameters.AddWithValue("fecha_registro", vehiculo.fecha_registro);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                respuesta = false;
            }

            return respuesta;
        }

        //eliminar
        public bool eliminar(int id)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                respuesta = false;
            }

            return respuesta;
        }
    }
}
