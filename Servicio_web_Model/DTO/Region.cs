using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_web_Model.DTO
{
    public partial class Region
    {
        private string region_rut;
        private int id_region;
        private string nombre;
        public int Id_region { get => id_region; set => id_region = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Region_rut { get => region_rut; set => region_rut = value; }
    }
}
