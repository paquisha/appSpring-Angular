using CrudMVCCore.Models;
using System.Data.SqlClient;
using System.Data;

namespace CrudMVCCore.Datos
{
    public class ContactoDatos
    {
        public List<Contacto> Listar()
        {
            var oLista = new List<Contacto>();

            var cn = new Conexion();
            using (var connexion = new SqlConnection(cn.getCadenaSql()))
            {
                connexion.Open();

                SqlCommand cmd = new SqlCommand("sp_Listar", connexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Contacto() {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }
        }
    }
}
