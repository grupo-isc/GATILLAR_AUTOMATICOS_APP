using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;
using Entidades;
using Repositorio;
using System.Configuration;
using System.Linq;
using System.Diagnostics;


namespace Aplicacion
{

    public class EnvioAplicacion
    {
        public validador_envios_prueba getValidadorEnviosPrueba(int id_persona_juridica)
        {
            EnvioRepositorio er = new EnvioRepositorio();
            return er.getValidadorEnviosPrueba(id_persona_juridica);

        }
        public envio getUltimoEnvioByIdArchivoSinValidar(int id_archivo)
        {
            EnvioRepositorio er = new EnvioRepositorio();
            return er.getUltimoEnvioByIdArchivoSinValidar(id_archivo);

        }
        public List<envio> listarEnviosDetenidos()

        {
            EnvioRepositorio er = new EnvioRepositorio();
            return er.listarEnviosDetenidos();

        }


        public void guardarGatillarTest(int id_envio, int gatilla)
        {
            EnvioRepositorio er = new EnvioRepositorio();
            er.guardarGatillarTest(id_envio, gatilla);
        }
        public void guardarGatillar(int id_envio, int gatilla)
        {
            EnvioRepositorio er = new EnvioRepositorio();
            er.guardarGatillar(id_envio, gatilla);


        }

        public envio GetEnvioByID(int id_envio)
        {
            try
            {
                EnvioRepositorio envioRepositorio = new EnvioRepositorio();

                return envioRepositorio.getEnvioById(id_envio);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void guardarLogErrorGuardadoCola(int id_envio, string mensaje, string accion, int linea)
        {
            try
            {
                EnvioRepositorio envioRepositorio = new EnvioRepositorio();

                envioRepositorio.guardarLogErrorGuardadoCola(id_envio, mensaje, accion, linea);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public int guardarCola(int id_envio, int linea, string datos, int id_aplicativo)
        {
            try
            {
                EnvioRepositorio envioRepositorio = new EnvioRepositorio();

                return envioRepositorio.guardarCola(id_envio, linea, datos, id_aplicativo);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public int guardarDetalleEnvioDespacho(int id_envio, int id_area, int id_casilla, string to_email, string asunto, int id_estado_destinatario, int linea, int id_proceso, int id_tipo_envio, int id_persona_juridica, string err_mensaje)
        {
            try
            {
                EnvioRepositorio envioRepositorio = new EnvioRepositorio();
                return envioRepositorio.guardarDetalleEnvioDespacho(id_envio, id_area, id_casilla, to_email, asunto, id_estado_destinatario, linea, id_proceso, id_tipo_envio, id_persona_juridica, err_mensaje);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public List<envio_gatillado> ListarEnvioPorGatillar()
        {
            EnvioRepositorio er = new EnvioRepositorio();
            return er.ListarEnvioPorGatillar();
        }

        public void ActualizarEnvioGatillado(int id_envio, int gatillado)
        {
            EnvioRepositorio er = new EnvioRepositorio();
            er.ActualizarEnvioGatillado(id_envio, gatillado);
        }

        public void ActualizarEnvioGatilladoTest(int id_envio, int gatillado)
        {
            EnvioRepositorio er = new EnvioRepositorio();
            er.ActualizarEnvioGatilladoTest(id_envio, gatillado);
        }
    }
}
