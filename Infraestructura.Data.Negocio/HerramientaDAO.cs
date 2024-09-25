using Dominio.Entidad.Negocios.Abstraccion;
using Dominio.Entidad.Negocios.Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data.Negocio
{
    public class HerramientaDAO : IHerramienta
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        public string Add(Herramienta registro)
        {
            var sp = "usp_merge_herramienta_ninalaya_crhistian";
            string mensaje = "";
            using (SqlConnection con = new SqlConnection(cadena))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sp, con) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("@idHer", registro.IdHer);
                    cmd.Parameters.AddWithValue("@desHer", registro.DesHer);
                    cmd.Parameters.AddWithValue("@medHer", registro.MedHer);
                    cmd.Parameters.AddWithValue("@idcategoria", registro.IdCategoria);
                    cmd.Parameters.AddWithValue("@preUni", registro.PreUni);
                    cmd.Parameters.AddWithValue("@stock", registro.Stock);

                    int c = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha insertado {c} herramienta";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
                finally { con.Close(); }
            }
            return mensaje;
        }

        public string Delete(string registro)
        {
            var sp = "usp_delete_herramienta_ninalaya_crhistian";
            string mensaje = "";
            using (SqlConnection con = new SqlConnection(cadena))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sp, con) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("@idHer", registro);                    

                    int c = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha borrado {c} herramienta";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
                finally { con.Close(); }
            }
            return mensaje;
        }

        public Herramienta Find(string IdHer)
        {            
            var sp = "usp_find_herramienta_ninalaya_crhistian";
            Herramienta herramienta = null;
            try
            {
                using (SqlConnection cone = new SqlConnection(cadena))
                {
                    cone.Open();
                    SqlCommand cmd = new SqlCommand(sp, cone) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@idher", IdHer);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        int idHerramienta = dr.GetOrdinal("IdHerramienta");
                        int desHerramienta = dr.GetOrdinal("DesHerramienta");
                        int medida = dr.GetOrdinal("MedHerramienta");
                        int idCategoria = dr.GetOrdinal("IdCategoria");
                        int precio = dr.GetOrdinal("PreUni");
                        int stock = dr.GetOrdinal("Stock");
                        herramienta = new Herramienta()
                        {
                            IdHer = dr.GetString(idHerramienta),
                            DesHer = dr.GetString(desHerramienta),
                            MedHer = dr.GetString(medida),
                            IdCategoria = dr.GetInt32(idCategoria),
                            PreUni = dr.GetDecimal(precio),
                            Stock = dr.GetInt32(stock)
                        };                        
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return herramienta;
        }



        public string Update(Herramienta registro)
        {
            var sp = "usp_merge_herramienta_ninalaya_crhistian";
            string mensaje = "";
            using (SqlConnection con = new SqlConnection(cadena))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sp, con) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("@idHer", registro.IdHer);
                    cmd.Parameters.AddWithValue("@desHer", registro.DesHer);
                    cmd.Parameters.AddWithValue("@medHer", registro.MedHer);
                    cmd.Parameters.AddWithValue("@idcategoria", registro.IdCategoria);
                    cmd.Parameters.AddWithValue("@preUni", registro.PreUni);
                    cmd.Parameters.AddWithValue("@stock", registro.Stock);

                    int c = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha actualizado {c} herramienta";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
                finally { con.Close(); }
            }
            return mensaje;
        }
    }
}
