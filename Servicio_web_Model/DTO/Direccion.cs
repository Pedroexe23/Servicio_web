using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_web_Model.DTO
{
   public class Direccion
    {
      

        private string descripcion;
        private int direccion_id_region;
        private string direccion_rut;


        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Direccion_rut { get => direccion_rut; set => direccion_rut = value; }
        public int Direccion_id_region { get => direccion_id_region; set => direccion_id_region = value; }
    }
}
