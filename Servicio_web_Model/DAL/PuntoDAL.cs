
using Servicio_web_Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_web_Model.DAL
{
    public class PuntoDAL
    {
        private static List<PuntoCarga> Cargas = new List<PuntoCarga>();
        public void CrearPunto(PuntoCarga p)
        {
            Cargas.Add(p);

        }
        public void editar(PuntoCarga p)
        {
            List<PuntoCarga> puntos_de_Cargas = GetPuntoCargas();
            for (int i = 0; i < puntos_de_Cargas.Count; i++)
            {
                if (puntos_de_Cargas[i].Id==p.Id && puntos_de_Cargas[i].Punto_rut==p.Punto_rut)
                {
                    puntos_de_Cargas[i].Tipo = p.Tipo;
                    puntos_de_Cargas[i].Fechavencimiento = p.Fechavencimiento;
                        puntos_de_Cargas[i].Capacidadmaxima = p.Capacidadmaxima;

                }
                

            }
        }
        public List<PuntoCarga> GetPuntoCargas()
        {
            return Cargas;
        }

    }
}
