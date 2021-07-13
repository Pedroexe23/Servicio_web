using Servicio_web_Model.DAL;
using Servicio_web_Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicio_web.Estaciones_de_Servicio
{
    public partial class VisualizarEstacion : System.Web.UI.Page
    {

        /*crear una tabla de datos*/
        DataTable dt = new DataTable();



        private void Cargar_tablas()
        {
            List<Direccion> direccions = new DireccionDAL().GetDirecciones();
            List<Estacion> estaciones = new EstacionDAL().GetEstacions();
            List<Horario_atencion> horario = new HoraDAL().GetHorario();
            List<Region> regiones = new RegionDAL().GetRegiones();


            dt.Columns.AddRange(new DataColumn[6]{
                /*Crear las colummas de la Tabla de datos*/
            new DataColumn("Rut", typeof(string)),
            new DataColumn("Capacidad", typeof(int)),
            new DataColumn("Horario Inicio", typeof(string)),
            new DataColumn("Horario Cierre", typeof(string)),
            new DataColumn("Direcion", typeof(string)),
            new DataColumn("Region", typeof(string))
            });
            string Rut = "", direccion = "", region = "";
            int capacidad = 0, id = 99;
            string Hi = DateTime.Now.ToString("H:m"), HC = DateTime.Now.ToString("H:m");

            for (int i = 0; i < estaciones.Count; i++)
            {
                Estacion e = new Estacion();
                e.Rut = estaciones[i].Rut;
                e.Capacidad = estaciones[i].Capacidad;
                for (int j = 0; j < horario.Count; j++)
                {
                    Horario_atencion h = new Horario_atencion();
                    h.Horario_rut = horario[j].Horario_rut;
                    h.Hora_inicio = horario[j].Hora_inicio;
                    h.Hora_cierre = horario[j].Hora_cierre;
                    if (h.Horario_rut == e.Rut)
                    {
                        /*si la clave primaria de la estacion es igual que la clave foranea del horario de atencion
                         * se almacena los datos de la estacion y las horas de atencion en string en 
                         * foramto de hora */
                        Rut = e.Rut;
                        capacidad = e.Capacidad;
                        Hi = h.Hora_inicio.ToString("H:m");
                        HC = h.Hora_cierre.ToString("H:m");

                    }


                }
                for (int k = 0; k < direccions.Count; k++)
                {
                    Direccion d = new Direccion();
                    d.Direccion_rut = direccions[k].Direccion_rut;
                    d.Descripcion = direccions[k].Descripcion;
                    d.Direccion_id_region = direccions[k].Direccion_id_region;
                    if (d.Direccion_rut == Rut)
                    {
                        /*si la clave primaria de la estacion es igual que la clave foranea de la direccion
                       * se almacena  los datos de la direccion con la clave foranea de la region */
                        direccion = d.Descripcion;
                        id = d.Direccion_id_region;
                    }

                }

                for (int l = 0; l < regiones.Count; l++)
                {
                    Region r = new Region();
                    r.Id_region = regiones[l].Id_region;
                    r.Nombre = regiones[l].Nombre;
                    r.Region_rut = regiones[l].Region_rut;
                    if (r.Region_rut == Rut && r.Id_region == id)
                    {
                        /*si la clave primaria de la estacion y la clave foranea de la direccion es igual que la clave foranea y clave primaria de la region
                          * se almacena  los datos de la  region */
                        region = (r.Nombre + r.Regiontxt).Trim();
                    }
                }
                DataRow row = dt.NewRow();
                /*los datos se almacenados se guardaran en celdas por filas */
                row["Rut"] = Rut;
                row["Capacidad"] = capacidad;
                row["Horario Inicio"] = Hi;
                row["Horario Cierre"] = HC;
                row["Direcion"] = direccion;
                row["Region"] = region;
                dt.Rows.Add(row);


            }

            /*se mostraran los datos guardados de la filas por colummnas en el Gridview */
            EstacionGrid.DataSource = dt;
            EstacionGrid.DataBind();


        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                Cargar_tablas();


            }

        }

        protected void EstacionGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {

                String eliminarut = e.CommandArgument.ToString();
                new DireccionDAL().Eliminar(eliminarut);
                new RegionDAL().eliminar(eliminarut);
                new HoraDAL().Borrar(eliminarut);
                new EstacionDAL().Eliminar(eliminarut);
                Cargar_tablas();

            }

        }

    }
}