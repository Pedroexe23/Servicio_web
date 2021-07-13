
using Servicio_web_Model.DAL;
using Servicio_web_Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicio_web.Puntos_de_Carga
{
    public partial class VisualizarPunto : System.Web.UI.Page
    {
        /*crear una tabla de datos*/
        DataTable dt = new DataTable();
        private void cargarTabla()
        {
            string Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            string tipo = "";
            List<PuntoCarga> Puntos_de_Cargas = new PuntoDAL().GetPuntoCargas();
            dt.Columns.AddRange(new DataColumn[5] {
          /*Crear las colummas de la Tabla de datos*/
              new DataColumn("Rut", typeof(string)),
            new DataColumn("Id", typeof(int)),
            new DataColumn("Tipo", typeof(string)),
            new DataColumn("capacidadmaxima", typeof(int)),
            new DataColumn("fechavencimiento", typeof(string))
            });
            for (int i = 0; i < Puntos_de_Cargas.Count; i++)
            {
                PuntoCarga PC = new PuntoCarga();
                PC.Punto_rut = Puntos_de_Cargas[i].Punto_rut;
                PC.Id = Puntos_de_Cargas[i].Id;
                PC.Tipo = Puntos_de_Cargas[i].Tipo;
                PC.Capacidadmaxima = Puntos_de_Cargas[i].Capacidadmaxima;
                PC.Fechavencimiento = Puntos_de_Cargas[i].Fechavencimiento;
                Fecha = PC.Fechavencimiento.ToString("dd/MM/yyyy");
                if (PC.Tipo == 1)
                {
                    tipo = "Trafico";
                }
                else
                {
                    tipo = "Consumo";

                }
                DataRow row = dt.NewRow();
                /*los datos se almacenados de cada punto de carga se guardaran en celdas por filas */
                row["Rut"] = PC.Punto_rut;
                row["Id"] = PC.Id;
                row["Tipo"] = tipo;
                row["capacidadmaxima"] = PC.Capacidadmaxima;
                row["fechavencimiento"] = Fecha;
                dt.Rows.Add(row);


            }
            PuntoGrid.DataSource = dt;
            PuntoGrid.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                cargarTabla();
            }


        }

        protected void PuntoGrid_SelectedIndexChanged(object sender, EventArgs e)
        { /* al a ver presionado el boton de editar se extraera
           * los datos del rut y de la Id y se copiara en texbox
           * correspondientes*/
            Ruttxt.Text = ((GridView)sender).SelectedRow.Cells[0].Text;
            IDnumCarga.Text = ((GridView)sender).SelectedRow.Cells[1].Text;
        }

        protected void EditarBtn_Click(object sender, EventArgs e)
        {
            /*este metodo es casi parecido al metodo de registrar con los mismos parametros,
             * pero edita los datos guardados pero no cambia el ID y el Rut*/
            List<String> errores = new List<string>();
            LimpiarNotificacion();
            string Rut = Ruttxt.Text.Trim();
            int Id = Convert.ToInt32(IDnumCarga.Text.Trim());
            int tipo = Convert.ToInt32(TiposRd.SelectedValue);
            int capacidad = 0;
            DateTime fecha = DateTime.Now;
            try
            {
                capacidad = Convert.ToInt32(Capacidadtxt.Text.Trim());
            }
            catch (Exception)
            {
                errores.Add("la Capacidad es en solo en numeros");
            }
            try
            {
                fecha = Convert.ToDateTime(Fechatxt.Text.Trim());
            }
            catch (Exception)
            {

                errores.Add("Ingrese la fecha nuevamente");
            }
            if (!errores.Any())
            {
                PuntoCarga PC = new PuntoCarga();
                PC.Punto_rut = Rut;
                PC.Id = Id;
                PC.Tipo = tipo;
                PC.Capacidadmaxima = capacidad;
                PC.Fechavencimiento = fecha;
                new PuntoDAL().editar(PC);
                Limpiar();
                cargarTabla();
            }
            else
            {
                ErroresGrid.DataSource = errores;
                ErroresGrid.DataBind();

            }

        }
        private void LimpiarNotificacion()
        {
            ErroresGrid.DataSource = null;
            ErroresGrid.DataBind();
        }
        private void Limpiar()
        {
            Ruttxt.Text = "";
            IDnumCarga.Text = "";
            Capacidadtxt.Text = "";
            Fechatxt.Text = "";
            TiposRd.SelectedValue = "1";

        }

        protected void FechaCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            String Fecha = Fechatxt.Text.Trim();
            int conteo = 0;
            if (Fecha == string.Empty)
            {
                FechaCV.ErrorMessage = "Debe ingresar el Fecha";
                args.IsValid = false;
            }
            else
            {
                String[] FechaArray;
                if (!Fecha.Contains("-"))
                {
                    conteo = conteo + 1;
                }
                else
                {
                    FechaArray = Fecha.Split('-');
                    if (FechaArray.Length == 3)
                    {
                        if (FechaArray[2].Length <= 3)
                        {
                            FechaCV.ErrorMessage = "El año de la fecha no esta bien ingresado ";
                            args.IsValid = false;
                        }
                        else
                        {
                            args.IsValid = true;

                        }

                    }
                    else
                    {
                        FechaCV.ErrorMessage = "las fechas deberia tener guion o Flash";
                    }
                }
                if (!Fecha.Contains("/"))
                {
                    conteo = conteo + 1;
                }
                else
                {
                    FechaArray = Fecha.Split('/');
                    if (FechaArray.Length == 3)
                    {
                        if (FechaArray[2].Length <= 3)
                        {
                            FechaCV.ErrorMessage = "El año de la fecha no esta bien ingresado ";
                            args.IsValid = false;
                        }
                        else
                        {
                            args.IsValid = true;

                        }

                    }
                    else
                    {
                        FechaCV.ErrorMessage = "las fechas deberia tener guion o Flash";
                    }
                }
            }
            if (conteo == 2)
            {
                FechaCV.ErrorMessage = "El formato de la fecha no esta bien ingresado ";
                args.IsValid = false;
            }

        }

        protected void Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Elemento = Convert.ToInt32(Filtrord.SelectedValue);
            string Fecha = "";
            string tipo = "";
            List<PuntoCarga> Puntos_de_Cargas = new PuntoDAL().GetPuntoCargas();
            dt.Columns.AddRange(new DataColumn[5] {
              new DataColumn("Rut", typeof(string)),
            new DataColumn("Id", typeof(int)),
            new DataColumn("Tipo", typeof(string)),
            new DataColumn("capacidadmaxima", typeof(int)),
            new DataColumn("fechavencimiento", typeof(string))
            });
            for (int i = 0; i < Puntos_de_Cargas.Count; i++)
            {
                PuntoCarga PC = new PuntoCarga();
                PC.Punto_rut = Puntos_de_Cargas[i].Punto_rut;
                PC.Id = Puntos_de_Cargas[i].Id;
                PC.Tipo = Puntos_de_Cargas[i].Tipo;
                PC.Capacidadmaxima = Puntos_de_Cargas[i].Capacidadmaxima;
                PC.Fechavencimiento = Puntos_de_Cargas[i].Fechavencimiento;
                Fecha = Puntos_de_Cargas[i].Fechavencimiento.ToString("dd/MM/yyyy");
                if (PC.Tipo == 1)
                {
                    tipo = "Trafico";
                }
                else
                {
                    tipo = "Consumo";

                }
                if (Elemento == PC.Tipo)
                {
                    DataRow row = dt.NewRow();
                    row["Rut"] = PC.Punto_rut;
                    row["Id"] = PC.Id;
                    row["Tipo"] = tipo;
                    row["capacidadmaxima"] = PC.Capacidadmaxima;
                    row["fechavencimiento"] = Fecha;
                    dt.Rows.Add(row);

                }
                else if (Elemento == 0)
                {
                    DataRow row = dt.NewRow();
                    row["Rut"] = PC.Punto_rut;
                    row["Id"] = PC.Id;
                    row["Tipo"] = tipo;
                    row["capacidadmaxima"] = PC.Capacidadmaxima;
                    row["fechavencimiento"] = Fecha;
                    dt.Rows.Add(row);

                }



            }
            PuntoGrid.DataSource = dt;
            PuntoGrid.DataBind();
        }
    }
}