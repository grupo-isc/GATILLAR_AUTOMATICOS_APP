
using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class CumpleanosAplicacion
    {
        public List<estructura_archivo> listar_estructuras(int id_archivo)
        {
			try
			{
				CumpleanosRepositorio cumpleanosRepositorio = new CumpleanosRepositorio();

				return cumpleanosRepositorio.listarEstructuraArchivos(id_archivo);
			}
			catch (Exception e)
			{

				throw;
			}
        }

		public List<aplicativo> listar_aplicativos(int id_pesona_juridica)
		{
			try
			{
				CumpleanosRepositorio cumpleanosRepositorio = new CumpleanosRepositorio();

				return cumpleanosRepositorio.listarAplicativosByPersonaJuridica(id_pesona_juridica);
			}
			catch (Exception e)
			{

				throw;
			}
		}

		public List<contacto> listar_contactos_envio()
		{
			try
			{
				CumpleanosRepositorio cumpleanosRepositorio = new CumpleanosRepositorio();

				return cumpleanosRepositorio.listarContactosEnvio();
			}
			catch (Exception e)
			{

				throw;
			}
		}

		public List<suscripcion_cancelada> suscripciones_canceladas(int id_persona_juridica, int id_area)
		{
			try
			{
				CumpleanosRepositorio cumpleanosRepositorio = new CumpleanosRepositorio();

				return cumpleanosRepositorio.listarSuscripcionesCanceladasActivas(id_persona_juridica, id_area);
			}
			catch (Exception e)
			{

				throw;
			}
		}

		public List<envio_cumpleaños> listar_envios_cumpleanos_dia_realizados(DateTime fecha_envio)
		{
			try
			{
				CumpleanosRepositorio cumpleanosRepositorio = new CumpleanosRepositorio();

				return cumpleanosRepositorio.listarEnviosCumplanosDia(fecha_envio);
			}
			catch (Exception e)
			{

				throw;
			}
		}

		public int guardarEnvioCumpleanos(envio_cumpleaños model)
		{
			try
			{
				CumpleanosRepositorio cumpleanosRepositorio = new CumpleanosRepositorio();

				return cumpleanosRepositorio.guardarEnvioCumpleanos(model);
			}
			catch (Exception e)
			{

				throw;
			}
		}

        public void registrarEnviosCumpleanos()
        {
            EnvioAplicacion envioAplicacion = new EnvioAplicacion();            

            List<contacto> contactos = listar_contactos_envio();

            List<envio_cumpleaños> enviosDiaCumpleanos = listar_envios_cumpleanos_dia_realizados(DateTime.Today);

            for (int i = 0; i < contactos.Count; i++)
            {
                envio oEnvio = envioAplicacion.GetEnvioByID(contactos[i].id_envio);
                aplicativo oAplicativo = listar_aplicativos(oEnvio.id_persona_juridica).FirstOrDefault();
                List<estructura_archivo> estructura = listar_estructuras(oEnvio.id_archivo);
                List<suscripcion_cancelada> suscripciones = suscripciones_canceladas(oEnvio.id_persona_juridica, oEnvio.id_area);


                string email = "";

                try
                {
                    if (!string.IsNullOrEmpty(contactos[i].datos) && contactos[i].datos.Trim() != "")
                    {
                        string[] ln_sep = contactos[i].datos.Split(';');
                        if (ln_sep.Where(w => w.Trim() != "").Count() == 0)
                        {
                            continue;
                        }
                        bool verif = true;
                        string men_verif = "";
                        if (ln_sep.Count() > estructura.Select(r => r.numero_columna).Max() && oEnvio.id_fuente == 0)
                        {
                            ///////////

                            verif = false;
                            men_verif += "La linea " + contactos[i].linea + " no posee el formato acorde con la estructura de archivo indicada  \n";
                        }
                        else
                        {
                            for (int s = 0; s < estructura.Count(); s++)
                            {

                                if (estructura[s].tipo_dato == 2)
                                {
                                    if (!(int.TryParse(ln_sep[(estructura[s].numero_columna) - 1].Trim(), out int verf_enr)))
                                    {
                                        verif = false;
                                        men_verif += "La linea " + contactos[i].linea + " no posee un formato de numero entero para la columna " + (estructura[s].numero_columna) + " \n";
                                    }
                                }

                                if (estructura[s].tipo_dato == 3)
                                {
                                    if (!(DateTime.TryParse(ln_sep[(estructura[s].numero_columna) - 1].Trim(), out DateTime verf_date)))
                                    {
                                        verif = false;
                                        men_verif += "La linea " + contactos[i].linea + " no posee un formato de fecha para la columna " + (estructura[s].numero_columna) + " \n";
                                    }
                                }
                                if (estructura[s].tipo_dato == 4)
                                {
                                    if (string.IsNullOrEmpty(ln_sep[(estructura[s].numero_columna) - 1].Trim()) || !(ValidFileName(ln_sep[(estructura[s].numero_columna) - 1].Trim())) || (ln_sep[(estructura[s].numero_columna) - 1].Trim().Split('.').Count() == 1))
                                    {
                                        verif = false;
                                        men_verif += "La linea " + contactos[i].linea + " no posee un formato de nombre de archivo para la columna " + (estructura[s].numero_columna) + " \n";
                                    }
                                }
                                if (estructura[s].tipo_dato == 5)
                                {
                                    email = ln_sep[(estructura[s].numero_columna) - 1].Trim().ToLower();
                                    if (string.IsNullOrEmpty(email) || !(validFormatMail(email)))
                                    {
                                        verif = false;
                                        men_verif += "La linea " + contactos[i].linea + " no posee un formato de Email para la columna " + (estructura[s].numero_columna) + " \n";
                                    }
                                    else if (suscripciones.Count() > 0)
                                    {
                                        if (oEnvio.id_clasificacion_envio == 2)
                                        {

                                            suscripcion_cancelada oSuscripcion = suscripciones.FirstOrDefault(e => e.email.Trim().ToLower() == email);

                                            //if (scs.Any(e => e.email.Trim().ToLower() == email))
                                            //{
                                            //    verif = false;
                                            //    men_verif += "En la linea " + linea + " se indica un destinatario con suscripcion cancelada para la columna " + (estructura[s].numero_columna) + " \n";
                                            //}

                                            if (oSuscripcion != null)
                                            {
                                                if (oSuscripcion.id_tipo_bloqueo == 1)
                                                {
                                                    verif = false;
                                                    men_verif += "En la linea " + contactos[i].linea + " se indica un destinatario con suscripcion cancelada para la columna " + (estructura[s].numero_columna) + " \n";
                                                }
                                                if (oSuscripcion.id_tipo_bloqueo == 2)
                                                {
                                                    verif = false;
                                                    men_verif += "En la linea " + contactos[i].linea + " se indica un destinatario marcado como lista negra para la columna " + (estructura[s].numero_columna) + " \n";
                                                }
                                                if (oSuscripcion.id_tipo_bloqueo == 3)
                                                {
                                                    verif = false;
                                                    men_verif += "En la linea " + contactos[i].linea + " se indica un destinatario marcado como spam para la columna " + (estructura[s].numero_columna) + " \n";
                                                }
                                            }
                                        }

                                    }
                                }

                            }
                        }
                        if (!enviosDiaCumpleanos.Any(d => d.email == email && d.fecha_envio == DateTime.Today && d.id_envio == oEnvio.id_envio && d.id_lista_contactos == oEnvio.id_lista_de_contactos))
                        {
                            if (verif)
                            {
                                envioAplicacion.guardarCola(oEnvio.id_envio, contactos[i].linea, contactos[i].datos, oAplicativo.id_aplicativo);

                                envio_cumpleaños oCumple = new envio_cumpleaños();
                                oCumple.email = email;
                                oCumple.fecha_envio = DateTime.Today;
                                oCumple.id_envio = oEnvio.id_envio;
                                oCumple.id_lista_contactos = oEnvio.id_lista_de_contactos;

                                guardarEnvioCumpleanos(oCumple);
                            }
                            else
                            {
                                envioAplicacion.guardarDetalleEnvioDespacho(oEnvio.id_envio, oEnvio.id_area, oEnvio.id_casilla, email, oEnvio.asunto, 7, contactos[i].linea, oEnvio.id_proceso.Value, oEnvio.id_tipo_envio.Value, oEnvio.id_persona_juridica, men_verif);

                                envioAplicacion.guardarLogErrorGuardadoCola(oEnvio.id_envio, men_verif, "Guardar Cola", contactos[i].linea);


                            }
                        }
                    }

                }
                catch (Exception e)
                {
                    envioAplicacion.guardarDetalleEnvioDespacho(oEnvio.id_envio, oEnvio.id_area, oEnvio.id_casilla, email, oEnvio.asunto, 7, contactos[i].linea, oEnvio.id_proceso.Value, oEnvio.id_tipo_envio.Value, oEnvio.id_persona_juridica, e.Message);
                    envioAplicacion.guardarLogErrorGuardadoCola(oEnvio.id_envio, e.ToString(), "Guardar Cola", contactos[i].linea);

                }


            }
        }


        private bool ValidFileName(string filename)
        {
            // Tharwat 27.05.2015 < My first Public Method in C# >    
            // A method to check if the entered file name is valid to use. 
            // The method should return true / false as an output
            bool valid = true;
            List<string> Pattern = new List<string> { "^", "<", ">", ";", "|", "'", "/", ",", "\\", ":", "=", "?", "\"", "*" };
            for (int i = 0; i < Pattern.Count; i++)
            {
                if (filename.Contains(Pattern[i]))
                {
                    valid = false;
                    break;
                }
            }
            return valid;
        }



        private Boolean validFormatMail(String email)
        {

            try
            {
                if (email.Length > 0 && email.Split('@').Count() == 2 && email.Substring(0, 1) != "." && email.Substring(0, 1) != "-")
                {
                    //var addr = new System.Net.Mail.MailAddress(email);
                    //return addr.Address == email;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
