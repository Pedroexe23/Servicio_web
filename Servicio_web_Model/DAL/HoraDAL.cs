
using Servicio_web_Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_web_Model.DAL
{
    public class HoraDAL
    {
        private static List<Horario_atencion> horarios = new List<Horario_atencion>();
        public void Agregar(Horario_atencion h) 
        {
            horarios.Add(h);
        }
        public List<Horario_atencion> GetHorario()
        {
            return horarios;
        }
        public void Borrar(String Rut)
        {
            Horario_atencion h = horarios.Find(horario=> horario.Horario_rut== Rut);
            horarios.Remove(h);
        }
    }
}
