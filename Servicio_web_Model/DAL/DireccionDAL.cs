
using Servicio_web_Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Servicio_web_Model.DAL
{
    public class DireccionDAL
    {
        private static List<Direccion> direcciones = new List<Direccion>();
        public void Agregar(Direccion d)
        {
            direcciones.Add(d);
        }
        public List<Direccion> GetDirecciones()
        {
            return direcciones;
        }
        public void Eliminar(String Rut)
        {
            Direccion d = direcciones.Find(direccion => direccion.Direccion_rut == Rut);
            direcciones.Remove(d);
        }
    }
}
