using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using System.Data;

namespace Repositorio
{
    public class CumpleanosRepositorio
    {
        public List<estructura_archivo> listarEstructuraArchivos(int id_archivo)
        {
            List<estructura_archivo> obj = new List<estructura_archivo>();

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_archivo", id_archivo);

                    obj = cn.Query<estructura_archivo>("[dbo].[listar_estructuras_archivo_by_id_archivo]", parameters, commandType: CommandType.StoredProcedure).ToList();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }

            return obj;
        }

        public List<aplicativo> listarAplicativosByPersonaJuridica(int id_persona_juridica, int inmediato = 0)
        {
            List<aplicativo> obj = new List<aplicativo>();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_persona_juridica", id_persona_juridica);
                    parameters.Add("@inmediato", inmediato);

                    obj = cn.Query<aplicativo>("[dbo].[prc_listar_aplicativos_by_persona_juridica]", parameters, commandType: CommandType.StoredProcedure).ToList();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }

            return obj;
        }

        public List<contacto> listarContactosEnvio()
        {
            List<contacto> obj = new List<contacto>();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();

                    obj = cn.Query<contacto>("[dbo].[prc_listar_contactos_cumpleanos]", parameters, commandType: CommandType.StoredProcedure).ToList();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }

            return obj;
        }

        public List<suscripcion_cancelada> listarSuscripcionesCanceladasActivas(int id_persona_juridica = 0, int id_area = 0)
        {
            List<suscripcion_cancelada> obj = new List<suscripcion_cancelada>();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_persona_juridica", id_persona_juridica);
                    parameters.Add("@id_area", id_area);
                    obj = cn.Query<suscripcion_cancelada>("[dbo].[prc_listar_suscripciones_canceladas_activas]", parameters, commandType: CommandType.StoredProcedure).ToList();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }

            return obj;
        }


        public List<envio_cumpleaños> listarEnviosCumplanosDia(DateTime fecha_envio)
        {
            List<envio_cumpleaños> obj = new List<envio_cumpleaños>();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@fecha", fecha_envio);

                    obj = cn.Query<envio_cumpleaños>("[dbo].[prc_listar_envios_cumpleanos_dia]", parameters, commandType: CommandType.StoredProcedure).ToList();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }

            return obj;
        }

        public int guardarEnvioCumpleanos(envio_cumpleaños model)
        {
            int obj = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@fecha", model.fecha_envio);
                    parameters.Add("@id_lista_contactos", model.id_lista_contactos);
                    parameters.Add("@email", model.email);
                    parameters.Add("@id_envio", model.id_envio);
                    obj = cn.Query<int>("[dbo].[prc_guardar_envio_cumpleanos]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }

            return obj;
        }
    }
}
