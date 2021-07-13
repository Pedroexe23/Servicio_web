using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_web_Model.DTO
{
   public class Horario_atencion
    {
        private string horario_rut;
        private DateTime hora_inicio;
        private DateTime hora_cierre;

        public DateTime Hora_inicio { get => hora_inicio; set => hora_inicio = value; }
        public DateTime Hora_cierre { get => hora_cierre; set => hora_cierre = value; }
        public string Horario_rut { get => horario_rut; set => horario_rut = value; }
    }
}
