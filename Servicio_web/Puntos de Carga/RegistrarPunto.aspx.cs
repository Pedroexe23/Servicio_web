using Servicio_web_Model.DAL;
using Servicio_web_Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicio_web.Puntos_de_Carga
{
    public partial class RegistrarPunto : System.Web.UI.Page
    {
        List<Estacion> estaciones = new EstacionDAL().GetEstacions();
        List<PuntoCarga> Punto_de_Cargas = new PuntoDAL().GetPuntoCargas();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registrarbtn_Click(object sender, EventArgs e)
        {
            int Capacidad_de_Estacion = 0;
            LimpiarNotificacion();
            List<string> errores = new List<string>();
            int count = 0;
            string punto_rut = Ruttxt.Text.Trim();
            int id = -1;
            int tipo = Convert.ToInt32(TiposRd.SelectedValue);
            int capacidadmaxima = -1;
            DateTime fechavencimiento = DateTime.Now;
            /*en caso use un try catch para evitar que en el texbox se escriba en letras y
                 * si es el caso se añade un error a la lista */
            try
            {
                id = Convert.ToInt32(numCarga.Text.Trim());
            }
            catch (Exception)
            {
                errores.Add("Error de numero ingrese nuevamente");

            }
            /* en caso use un try catch para evitar que en el texbox se escriba en letras y
             * si es el caso se añade un error a la lista */
            try
            {
                capacidadmaxima = Convert.ToInt32(Capacidad.Text.Trim());

            }
            catch (Exception)
            {
                errores.Add("Error de capacidad Ingrese nuevamente");
            }
            /* al igual con los numeros con las fechas un try catch 
                  * para evitar que en el texbox se escriba en letras y cumplas con las normativas de la hora si no las cumple
                  * se agregara un error a la lista  */
            try
            {
                fechavencimiento = Convert.ToDateTime(Fechatxt.Text.Trim());
            }
            catch (Exception)
            {
                errores.Add("Error de Fecha de Vecimiento");
            }
            for (int i = 0; i < estaciones.Count; i++)
            {
                Estacion estacion = new Estacion();
                estacion.Rut = estaciones[i].Rut;
                if (count == -1)
                {
                    break;
                }
                if (punto_rut == estacion.Rut)
                {
                    /*si existe el rut en la base de datos entonces solo se extrae la capacidad de la estacion */
                    count = -1;
                    Capacidad_de_Estacion = estaciones[i].Capacidad;
                }
                else
                {
                    count = count + 1;
                }


            }
            if (count >= estaciones.Count)
            {  /*en caso de que no exista el rut entonces se añade un error */
                errores.Add(" Error no se ha encotrado el Rut en nuestra base de datos");

            }
            count = 0;
            for (int i = 0; i < Punto_de_Cargas.Count; i++)
            {
                PuntoCarga PC = new PuntoCarga();
                PC.Id = Punto_de_Cargas[i].Id;

                if (count == -1)
                {
                    break;
                }
                if (PC.Id == id)
                {
                    /*si una Id del punto de carga existe entonces se agregara un error */
                    count = -1;
                }
                else
                {
                    count = count + 1;
                }


            }
            if (count == -1)
            { /*con dije anteriomente si existe una id como la que escribimos entonces se agregara el error*/
                errores.Add("El Id esta repetido ingrese otro nuevamente");

            }

            int almacenamineto = 0;
            /*la variable de almacenamiento es una variable que almacena
             * las capacidades de cada punto de carga de la estacion */
            for (int i = 0; i < Punto_de_Cargas.Count; i++)
            {
                if (punto_rut == Punto_de_Cargas[i].Punto_rut)
                { /* La variable almacenamiento  almacena la capacidades de cada punto de carga de la estacion*/
                    almacenamineto = Punto_de_Cargas[i].Capacidadmaxima + almacenamineto;
                }

            }

            if (Capacidad_de_Estacion - (capacidadmaxima + almacenamineto) <= 0)
            {
                /*si la capacidad de cada punto de cargar mas con la capacidad
                 * que escribimos supera a limite de la estacion entonces se agregara un error */
                errores.Add("La Capacida minima para crear el punto de carga en esta estacion es: " + (Capacidad_de_Estacion - almacenamineto));
            }

            if (!errores.Any())
            {
                /*si no hay errores entonces se guardara el objecto con las variable que escribimos
                 * a la base de datos */
                PuntoCarga pc = new PuntoCarga()
                {
                    Punto_rut = punto_rut,
                    Id = id,
                    Capacidadmaxima = capacidadmaxima,
                    Fechavencimiento = fechavencimiento,
                    Tipo = tipo
                };
                new PuntoDAL().CrearPunto(pc);
                Limpiar();
                Registrotxt.Text = "Punto de carga registrado";
            }
            else
            {
                /*si hay errores se mostraran el una tabla*/
                ErroresGrid.DataSource = errores;
                ErroresGrid.DataBind();
            }

        }

        private void LimpiarNotificacion()
        {
            Registrotxt.Text = "";
            ErroresGrid.DataSource = null;
            ErroresGrid.DataBind();
        }
        private void Limpiar()
        {

            Fechatxt.Text = "";
            Capacidad.Text = "";
            numCarga.Text = "";
            Ruttxt.Text = "";
            TiposRd.SelectedValue = "1";
        }

        protected void FechaCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            String Fecha = Fechatxt.Text.Trim();
            int conteo = 0;
            if (Fecha == string.Empty)
            { /*en caso de que la fecha no tenga nada */
                FechaCV.ErrorMessage = "Debe ingresar el Fecha";
                args.IsValid = false;
            }
            else
            {
                String[] FechaArray;
                if (!Fecha.Contains("-"))
                { /*en caso no contenga "-" se agregara un conteo si tiene dos conteos
                   * entonces se agregara un error de mensaje */
                    conteo = conteo + 1;
                }
                else
                {/**/
                    FechaArray = Fecha.Split('-');
                    if (FechaArray.Length == 3)
                    {
                        if (FechaArray[2].Length <= 3)
                        {
                            /*si el año es de largo 3 entonces en enviara un mensaje de error*/
                            FechaCV.ErrorMessage = "El año de la fecha no esta bien ingresado ";
                            args.IsValid = false;
                        }
                        else
                        {
                            /*si cumple con las normas*/
                            args.IsValid = true;

                        }

                    }
                    else
                    { /*Caso en que la fecha no tiene un solo guión o flash*/
                        FechaCV.ErrorMessage = "las fechas deberia tener guion o Flash";
                        args.IsValid = false;
                    }
                }
                if (!Fecha.Contains("/"))
                {
                    /*en caso no contenga "/" se agregara un conteo si tiene dos conteos
                   * entonces se agregara un error de mensaje */
                    conteo = conteo + 1;
                }
                else
                {
                    FechaArray = Fecha.Split('/');
                    if (FechaArray.Length == 3)
                    {
                        if (FechaArray[2].Length <= 3)
                        {
                            /*si el año es de largo 3 entonces en enviara un mensaje de error*/
                            FechaCV.ErrorMessage = "El año de la fecha no esta bien ingresado ";
                            args.IsValid = false;
                        }
                        else
                        {
                            /*si cumple con las normas*/
                            args.IsValid = true;

                        }

                    }
                    else
                    {
                        /*Caso en que la fecha no tiene un solo guión o flash*/
                        FechaCV.ErrorMessage = "las fechas deberia tener guion o Flash";
                        args.IsValid = false;
                    }
                }
            }
            if (conteo == 2)
            {
                /*si no tuvo contiene "/" o "-" se enviara un error*/
                FechaCV.ErrorMessage = "El formato de la fecha no esta bien ingresado ";
                args.IsValid = false;
            }


        }

        protected void rutCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string rut = Ruttxt.Text.Trim();

            if (rut == string.Empty)
            {
                //Caso que el rut venga vacío
                rutCV.ErrorMessage = "Debe ingresar el Rut";
                args.IsValid = false;
            }
            else
            {
                /* Rut válido es de la forma 12345678-9*/

                String[] rutArray = rut.Split('-');


                if (rutArray.Length == 2)
                {
                    if (rutArray[1].Length != 1)
                    {
                        /*Caso que el digito verificador tiene mas de 1 caracter*/
                        rutCV.ErrorMessage = "El dígito verificador debe tener un caracter";
                        args.IsValid = false;
                    }
                    else
                    {
                        /*Caso que cumple formato*/
                        args.IsValid = true;
                    }
                }
                else
                {
                    /*Caso en que rut no tiene un solo guión*/
                    rutCV.ErrorMessage = "El Rut debe poseer un guión";
                    args.IsValid = false;
                }
            }

        }
    }
}