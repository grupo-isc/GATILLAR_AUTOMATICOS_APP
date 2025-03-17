using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Diagnostics;
using NLog;

namespace Repositorio
{
    public class EnvioRepositorio
    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /**
         * Llama al procedimiento almacenado que entrega los datos necesarios para detarminar si un envío de prueba puede ser generado.
         */
        public validador_envios_prueba getValidadorEnviosPrueba(int id_persona_juridica)
        {
            validador_envios_prueba obj = new validador_envios_prueba();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_persona_juridica", id_persona_juridica);
                    obj = cn.Query<validador_envios_prueba>("[dbo].[prc_get_validador_envios_prueba]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }

            return obj;
        }


        /**
         * Llama al procedimiento almacenado que retorna la información del último envío sin gatillas filtrado por id_archivo.
         */

        public envio getUltimoEnvioByIdArchivoSinValidar(int id_archivo)
        {
            envio obj = new envio();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_archivo", id_archivo);
                    obj = cn.Query<envio>("[dbo].[prc_get_ultimo_envio_by_id_archivo_sin_validar]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }

            return obj;
        }


        public List<envio> listarEnviosDetenidos()
        {
            List<envio> obj = new List<envio>();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    obj = cn.Query<envio>("[dbo].[prc_listar_envios_detenidos]", parameters, commandType: CommandType.StoredProcedure).ToList();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }

            return obj;
        }

        



        public void guardarGatillarTest(int id_envio, int gatilla)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_envio", id_envio);
                    parameters.Add("@gatilla", gatilla);


                    cn.Query("[dbo].[prc_guardar_gatillar_test]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }

        }



        public void guardarGatillar(int id_envio, int gatilla)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_envio", id_envio);
                    parameters.Add("@gatilla", gatilla);


                    cn.Query("[dbo].[prc_guardar_gatillar]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }

        }


        public envio getEnvioById(int id_envio)
        {
            envio obj = new envio();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_envio", id_envio);
                    obj = cn.Query<envio>("[dbo].[prc_get_envio_by_id]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }

            return obj;
        }

        public void guardarLogErrorGuardadoCola(int id_envio, string mensaje, string accion, int linea)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_envio", id_envio);
                    parameters.Add("@mensaje", mensaje);
                    parameters.Add("@accion", accion);
                    parameters.Add("@linea", linea);


                    cn.Query("[dbo].[prc_guardar_log_error_guardado_cola]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }

        }

        public int guardarCola(int id_envio, int linea, string datos, int id_aplicativo)
        {
            int dbResult = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_envio_test", null);
                    parameters.Add("@id_envio", id_envio);
                    parameters.Add("@estado", 1);
                    parameters.Add("@linea", linea);
                    parameters.Add("@datos", datos);
                    parameters.Add("id_aplicativo", id_aplicativo);
                    parameters.Add("@id_envio_test", null);
                    parameters.Add("@destinatario_test", null);
                    parameters.Add("@id_workflow", 0);

                    dbResult = cn.Query<int>("[dbo].[prc_guardar_lista_despacho]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }
            return dbResult;

        }

        public int guardarDetalleEnvioDespacho(int id_envio, int id_area, int id_casilla, string to_email, string asunto, int id_estado_destinatario, int linea, int id_proceso, int id_tipo_envio, int id_persona_juridica, string err_mensaje)
        {
            int dbResult = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();                    
                    parameters.Add("@id_envio", id_envio);
                    parameters.Add("@estado", 1);
                    parameters.Add("@linea", id_area);
                    parameters.Add("@id_casilla", id_casilla);
                    parameters.Add("@id_iron_port", null);
                    parameters.Add("@mid", 0);
                    parameters.Add("@to_email", to_email);
                    parameters.Add("@messajeId", null);
                    parameters.Add("@fecha_rec_irp", null);
                    parameters.Add("@asunto", asunto);
                    parameters.Add("@dominio_to", null);
                    parameters.Add("@id_estado_destinatario", id_estado_destinatario);
                    parameters.Add("@id_proceso", id_proceso);
                    parameters.Add("@id_tipo_envio", id_tipo_envio);
                    parameters.Add("@id_persona_juridica", id_persona_juridica);
                    parameters.Add("@err_mensaje", err_mensaje);
                    parameters.Add("@id_lista_despacho", null);

                    dbResult = cn.Query<int>("[dbo].[prc_guardar_lista_despacho]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }
            return dbResult;

        }

        public List<envio_gatillado> ListarEnvioPorGatillar()
        {
            List<envio_gatillado> obj = new List<envio_gatillado>();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    obj = cn.Query<envio_gatillado>("[dbo].[prc_listar_envio_por_gatillar]", parameters, commandType: CommandType.StoredProcedure).ToList();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"[GenerarLoteCorreo] Mensaje: {ex.Message} InnerException: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}");
                throw;
            }

            return obj;
        }

        public void ActualizarEnvioGatillado(int id_envio, int gatillado)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_envio", id_envio);
                    parameters.Add("@gatillado", gatillado);
                    cn.Query("[dbo].[prc_actualizar_envio_gatillado]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"[ActualizarEnvioGatillado] Mensaje: {ex.Message} InnerException: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}");
                throw;
            }
        }

        public void ActualizarEnvioGatilladoTest(int id_envio, int gatillado)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString))
                {
                    cn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_envio", id_envio);
                    parameters.Add("@gatillado", gatillado);
                    cn.Query("[dbo].[prc_actualizar_envio_gatillado_test]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"[ActualizarEnvioGatilladoTest] Mensaje: {ex.Message} InnerException: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}");
                throw;
            }
        }
    }
    
}
