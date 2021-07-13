using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_web_Model.DTO
{
   public  class Estacion
    {
        private string rut;
        private int capacidad;

        public string Rut { get => rut; set => rut = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
    }
}
