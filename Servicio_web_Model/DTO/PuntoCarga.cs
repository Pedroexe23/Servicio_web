using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_web_Model.DTO
{
   public class PuntoCarga
    {
        private string punto_rut;
        private int id;
        private int tipo;
        private int capacidadmaxima;
        private DateTime fechavencimiento;

        public int Id { get => id; set => id = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public int Capacidadmaxima { get => capacidadmaxima; set => capacidadmaxima = value; }
        public DateTime Fechavencimiento { get => fechavencimiento; set => fechavencimiento = value; }
        public string Punto_rut { get => punto_rut; set => punto_rut = value; }
    }
}
