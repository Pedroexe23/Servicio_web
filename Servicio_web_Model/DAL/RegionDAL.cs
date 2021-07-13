
using Servicio_web_Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_web_Model.DAL
{
    public class RegionDAL
    {
        private static List<Region> Regiones = new List<Region>();
         public void Agregar(Region r)
        {
            Regiones.Add(r);
        }
        public List<Region> GetRegiones()
        {
            return Regiones;
        }
         public void eliminar(String Rut) 
        {
            Region r = Regiones.Find(region => region.Region_rut == Rut);
            Regiones.Remove(r);
        }
    }
}
