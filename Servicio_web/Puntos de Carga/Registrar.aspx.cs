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
    public partial class Registrar : System.Web.UI.Page
    {
        List<Estacion> Estaciones = new EstacionDAL().GetEstacions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }
        /*el proceso de Limpiarnotificacion es solo para limpar el label que esta  */
        private void Limpiarnotificacion()
        {

            RegistroLabel.Text = "";
            ErroresGrid.DataSource = null;
            ErroresGrid.DataBind();

        }
        private void limpiar()
        {
            rutxt.Text = "";
            direcciontxt.Text = "";
            RegionTxt.SelectedIndex = 0;
            capacidadTxt.Text = "";
            HoraITxt.Text = "";
            HoraFTxt.Text = "";
        }

        protected void HCCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string Hora = HoraFTxt.Text.Trim();
            if (string.IsNullOrEmpty(Hora))
            { /*Caso que la hora venga vacía */
                HCCV.ErrorMessage = "Debe ingresar hora";
                args.IsValid = false;
            }
            else
            {
                /*Hora valida 09:21*/
                string[] HoraArray = Hora.Split(':');
                /*
          * 
          * HoraArray[0]=09
            HoraArray[1]=21
          */
                if (HoraArray.Length == 2)
                {
                    int a = Convert.ToInt32(HoraArray[0].Trim());
                    int b = Convert.ToInt32(HoraArray[1].Trim());
                    if (a >= 0 && a <= 23)
                    {
                        /*Si la hora es mayor o igual a 0 y menor o igual a 23 para da formato la hora*/
                        if (b >= 0 && b <= 59)
                        {
                            /*Si la hora es mayor o igual a 0 y menor o igual a 59
  * para da formato en minutos el argumento es valido*/
                            args.IsValid = true;
                        }
                        else
                        {

                            /*en caso que los minutos no cumplan*/
                            HCCV.ErrorMessage = "Error de minutos ingrese nuevamente";
                            args.IsValid = false;
                        }

                    }
                    else
                    {
                        /*en caso que la hora no cumplan*/
                        HCCV.ErrorMessage = "Error de Hora ingrese nuevamente";
                        args.IsValid = false;
                    }

                }
                else
                {
                    /*Caso de que la hora no tiene doble punto*/
                    HCCV.ErrorMessage = "Error de hora";
                    args.IsValid = false;
                }

            }

        }

        protected void HICV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string Hora = HoraITxt.Text.Trim();
            if (string.IsNullOrEmpty(Hora))
            { /*Caso que la hora venga vacía */
                HICV.ErrorMessage = "Debe ingresar hora";
                args.IsValid = false;
            }
            else
            {
                /*Hora valida 09:21*/
                string[] HoraArray = Hora.Split(':');
                /*
                 * 
                 * HoraArray[0]=09
                   HoraArray[1]=21
                 */
                if (HoraArray.Length == 2)
                {

                    int a = Convert.ToInt32(HoraArray[0].Trim());
                    int b = Convert.ToInt32(HoraArray[1].Trim());

                    if (a >= 0 && a <= 23)
                    {
                        /*Si la hora es mayor o igual a 0 y menor o igual a 23 para da formato la hora*/
                        if (b >= 0 && b <= 59)
                        {
                            /*Si la hora es mayor o igual a 0 y menor o igual a 59
                             * para da formato en minutos el argumento es valido*/
                            args.IsValid = true;
                        }
                        else
                        {
                            /*en caso que los minutos no cumplan*/
                            HICV.ErrorMessage = "Error de minutos ingrese nuevamente";
                            args.IsValid = false;
                        }

                    }
                    else
                    {
                        /*en caso que la hora no cumplan*/
                        HICV.ErrorMessage = "Error de Hora ingrese nuevamente";
                        args.IsValid = false;
                    }

                }
                else
                { /*Caso de que la hora no tiene doble punto*/
                    HICV.ErrorMessage = "Error de hora";
                    args.IsValid = false;
                }

            }

        }


        protected void rutCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            String rut = rutxt.Text.Trim();

            if (rut == string.Empty)
            {
                /*Caso que el rut venga vacío */
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



        protected void ingresarBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Limpiarnotificacion();
                /*la lista de errores  es una lista dinamica que se guardara los errores que comentan cuando intente ingresar 
                 * el formulario*/
                List<string> Errores = new List<string>();
                string rut = rutxt.Text.Trim();
                string direccion = direcciontxt.Text.Trim();
                int id_Region = Convert.ToInt32(RegionTxt.SelectedValue);
                int capacidad = 0;
                DateTime horaI = DateTime.Now;
                DateTime horaF = DateTime.Now;
                /*Comienza a revisar en la base de datos de Estacion DAL 
                 * si existe un Rut igual al que se a escrito entonces se va guardar
                 * un error por que ya existe este Rut  */
                for (int i = 0; i < Estaciones.Count; i++)
                {
                    if (rut == Estaciones[i].Rut)
                    {
                        Errores.Add("este Rut ya esta ingresado ingrese otro");
                    }
                }
                /* en caso use un try catch para evitar que en el texbox se escriba en letras y
                 * si es el caso se añade un error a la lista */
                try
                {
                    capacidad = Convert.ToInt32(capacidadTxt.Text.Trim());

                }
                catch (Exception)
                {
                    Errores.Add("no se ingresado la capacidad ingrese nuevamente");
                }
                /* al igual con los numeros con las Horas un try catch 
                 * para evitar que en el texbox se escriba en letras y cumplas con las normativas de la hora si no las cumple
                 * se agregara un error a la lista  */
                try
                {
                    horaI = Convert.ToDateTime(HoraITxt.Text.Trim());
                }
                catch (Exception)
                {
                    Errores.Add("La hora de inicio no esta ingresado ");

                }
                try
                {

                    horaF = Convert.ToDateTime(HoraFTxt.Text.Trim());
                }
                catch (Exception)
                {
                    Errores.Add("La hora de cierre no esta ingresado ");

                }
                /*si no hay ningun en la lista de Errores entonces se creara las clases Estacion, Region,
                 * Direccion y Horario de atencion, con cada uno con sus variable de la clase 
                 * ya que la Clave primaria es el Rut ya que es la clave principal en estacion
                 * pero en las demas clases es clave foranea, se guardaran en sus "Tablas" en la base de datos y se limpiará 
                 * sus textbox además el DropDownList volvera a su lugar preterminado*/
                if (!Errores.Any())
                {
                    Estacion esta = new Estacion()
                    {
                        Rut = rut,
                        Capacidad = capacidad
                    };
                    new EstacionDAL().agregarestacion(esta);
                    Region r = new Region()
                    {
                        Id_region = id_Region,
                        Region_rut = rut

                    };
                    new RegionDAL().Agregar(r);
                    Direccion d = new Direccion()
                    {
                        Direccion_id_region = id_Region,
                        Direccion_rut = rut,
                        Descripcion = direccion

                    };
                    new DireccionDAL().Agregar(d);
                    Horario_atencion H = new Horario_atencion()
                    {
                        Horario_rut = rut,
                        Hora_inicio = horaI,
                        Hora_cierre = horaF
                    };
                    new HoraDAL().Agregar(H);
                    RegistroLabel.Text = "Estacion Registrado";
                    limpiar();
                }
                /*en caso de que hay errores en la lista se mostrarán en una tabla y el Registro label no se mostrará   */
                else
                {
                    ErroresGrid.DataSource = Errores;
                    ErroresGrid.DataBind();
                }

            }


        }

    }
}