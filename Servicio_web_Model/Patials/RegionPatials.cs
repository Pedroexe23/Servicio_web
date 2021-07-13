using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_web_Model.DTO
{
   public partial class Region 
    {
        public String Regiontxt
        {
            get
            {
                String texto ="";
                switch (Id_region)
                {
                    case 15:
                        texto = "Arica y Parinacota";
                        break;
                    case 1:
                        texto = "Tarapaca";
                        break;
                    case 2:
                        texto = "Antofagasta";
                        break;
                    case 3:
                        texto = "Atacama";
                        break;
                    case 4:
                        texto = "Coquimbo";
                        break;
                    case 5:
                        texto = "Valparaíso";
                        break;
                    case 13:
                        texto = "Metropolitana de Santiago";
                        break;
                    case 6:
                        texto = "Libertador General Bernardo O’Higgins";
                        break;
                    case 7:
                        texto = "Maule";
                        break;
                    case 8:
                        texto = "Biobío";
                        break;
                    case 9:
                        texto = "La Araucanía";
                        break;
                    case 10:
                        texto = "Los Lagos";
                        break;
                    case 11:
                        texto = "Aysén del General Carlos Ibáñez del Campo";
                        break;
                    case 12:
                        texto = "Magallanes y la Antártica Chilena.";
                        break;
                    case 14:
                        texto = "Los Ríos";
                        break;
                    case 16:
                        texto = "Ñuble";
                        break;
                }
                return texto;
            }
        }
    }
}
