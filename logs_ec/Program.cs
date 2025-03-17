using Aplicacion;
using Entidades;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace logs_ec
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {

            logger.Info($"[Main] Inicio  Gatillar Automatico");
            DateTime horaBreak = DateTime.Now.AddMinutes(4.5);
            DateTime horaActual = DateTime.Now;
            logger.Info($"[Main] Comienza proceso => Hora tope: {horaBreak}");

            int cantidad_envios_prueba_isc = Convert.ToInt32(ConfigurationManager.AppSettings["cantidad_envios_prueba_isc"]);
            int cantidad_envios_prueba_externos = Convert.ToInt32(ConfigurationManager.AppSettings["cantidad_envios_prueba_externos"]);

            EnvioAplicacion ea = new EnvioAplicacion();
            while (horaActual < horaBreak)
            {
               
                //CumpleanosAplicacion cumpleanosAplicacion = new CumpleanosAplicacion();
                List<envio_gatillado> en = ea.ListarEnvioPorGatillar();

                //cumpleanosAplicacion.registrarEnviosCumpleanos();

                for (int i = 0; i < en.Count(); i++)
                {
                    logger.Info($"[Main] Procesar => Idenvio: {en[i].id_envio}");
                    if (en[i].id_estado_envio == 11 && en[i].es_automatico == 1 && en[i].gatillado_test == 0)
                    {
                        validador_envios_prueba va = ea.getValidadorEnviosPrueba(en[i].id_persona_juridica);
                        if (va.cantidad_dominios_test < cantidad_envios_prueba_isc && va.cantidad_no_dominios_test < cantidad_envios_prueba_externos && va.envios_activos == 0)
                        {
                            generarEnvio(en[i].id_envio, 0);
                            ea.ActualizarEnvioGatilladoTest(en[i].id_envio, 1);
                            logger.Info($"[Main] GenerarEnvio => Gatillada la prueba => Idenvio: {en[i].id_envio} IdEstadoEnvio:{en[i].id_estado_envio}");
                        }
                    }

                    else if (en[i].id_estado_envio == 10 && en[i].es_automatico == 1 && en[i].validado_automatico == 1 && en[i].gatillado == 0)
                    {
                        if (en[i].programado == 0 || (en[i].programado == 1 && en[i].fecha_programado <= DateTime.Now))
                        {
                            generarEnvio(en[i].id_envio, 1);
                            ea.ActualizarEnvioGatillado(en[i].id_envio, 1);
                            logger.Info($"[Main] GenerarEnvio => Gatillado el envio automatico => Idenvio: {en[i].id_envio} IdEstadoEnvio:{en[i].id_estado_envio}");
                        }
                    }

                    else if (en[i].id_estado_envio == 12 && en[i].programado == 1 && en[i].fecha_programado <= DateTime.Now && en[i].gatillado == 0)
                    {
                        generarEnvio(en[i].id_envio, 1);
                        ea.ActualizarEnvioGatillado(en[i].id_envio, 1);
                        logger.Info($"[Main] GenerarEnvio => Gatillado el envio programado => Idenvio: {en[i].id_envio} IdEstadoEnvio:{en[i].id_estado_envio}");
                    }
                }
                // Console.ReadLine();
                Thread.Sleep(10000);
                horaActual = DateTime.Now;
            }
            logger.Info($"[Main] Termina proceso => Hora: {horaActual}");

            logger.Info($"[Main] Termino  Gatillar Automatico");
        }

        public static bool generarEnvio(int idEnvio, int prod)
        {
            logger.Info($"[generarEnvio] Idenvio: {idEnvio} prod:{prod}");

            try
            {
                
                EnvioAplicacion ea = new EnvioAplicacion();
                string url = ConfigurationManager.AppSettings["url_ws"].ToString();
                string token_ws = ConfigurationManager.AppSettings["token_ws"].ToString();
                logger.Info($"[generarEnvio] Idenvio: {idEnvio} prod:{prod} url:{url} token:{token_ws}");

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("Authorization", token_ws.ToString());
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                string postData = "id_envio=" + idEnvio + "&productivo=" + prod;
                byte[] bytes = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = bytes.Length;
                logger.Info($"[generarEnvio] Idenvio: {idEnvio} prod:{prod} url:{url} token:{token_ws} postdata:{postData}");
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                string result = reader.ReadToEnd().ToString();
                Console.WriteLine(result);
                logger.Info($"[generarEnvio] EjecutaGuardado => Idenvio: {idEnvio} prod:{prod} result:{result}");
                stream.Dispose();
                reader.Dispose();
                if (result.Trim() == "")
                {
                    return true;
                }
                {
                    return false;
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;

            }


        }

    }
}
