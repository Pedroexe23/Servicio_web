
using Servicio_web_Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Servicio_web_Model.DAL
{
    public class EstacionDAL
    {
        private static List<Estacion> Estaciones = new List<Estacion>();
        
        public void agregarestacion(Estacion c)
        {
            Estaciones.Add(c);
        }
        public List<Estacion> GetEstacions()
        {
            return Estaciones;
        }

        public void Eliminar(String Rut)
        {
            Estacion c = Estaciones.Find(estacion => estacion.Rut == Rut);
            Estaciones.Remove(c);
        }
           
    }
}
