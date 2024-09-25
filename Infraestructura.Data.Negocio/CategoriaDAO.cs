using Dominio.Entidad.Negocios.Abstraccion;
using Dominio.Entidad.Negocios.Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Infraestructura.Data.Negocio
{
    public class CategoriaDAO : ICategoria
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        public IEnumerable<Categoria> GetAll()
        {
            var listado = new List<Categoria>();
            var sp = "usp_select_categorias_ninalaya_crhistian";

            try
            {
                using (SqlConnection cone = new SqlConnection(cadena))
                {
                    cone.Open();
                    SqlCommand cmd = new SqlCommand(sp, cone);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        int idCategoria = dr.GetOrdinal("IdCategoria");
                        int nomCategoria = dr.GetOrdinal("NomCategoria");
                        Categoria categoria = new Categoria()
                        {
                            IdCategoria = dr.GetInt32(idCategoria),
                            NomCategoria = dr.GetString(nomCategoria),
                        };
                        listado.Add(categoria);
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listado;
        }

        public IEnumerable<Categoria> GetXCategoria(int? idcat)
        {
            throw new NotImplementedException();
        }
    }
}
