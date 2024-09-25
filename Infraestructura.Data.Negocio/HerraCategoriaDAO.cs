using Dominio.Entidad.Negocios.Abstraccion;
using Dominio.Entidad.Negocios.Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data.Negocio
{
    public class HerraCategoriaDAO : IHerraCategoria
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        public IEnumerable<HerraCategoria> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HerraCategoria> GetXCategoria(int? idcat)
        {
            var listado = new List<HerraCategoria>();
            var sp = "usp_select_herramientas_ninalaya_crhistian";

            try
            {
                using (SqlConnection cone = new SqlConnection(cadena))
                {
                    cone.Open();
                    SqlCommand cmd = new SqlCommand(sp, cone) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@idcat",(object)idcat ?? DBNull.Value);


                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        int idHerramienta = dr.GetOrdinal("IdHerramienta");
                        int desHerramienta = dr.GetOrdinal("DesHerramienta");
                        int medida = dr.GetOrdinal("MedHerramienta");
                        int nomCategoria = dr.GetOrdinal("NomCategoria");
                        int precio = dr.GetOrdinal("PreUni");
                        int stock = dr.GetOrdinal("Stock");
                        HerraCategoria herramienta = new HerraCategoria()
                        {
                            IdHer = dr.GetString(idHerramienta),
                            DesHer = dr.GetString(desHerramienta),
                            MedHer = dr.GetString(medida),
                            NomCategoria = dr.GetString(nomCategoria),
                            PreUni = dr.GetDecimal(precio),
                            Stock = dr.GetInt32(stock)
                        };
                        listado.Add(herramienta);
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
    }
}
