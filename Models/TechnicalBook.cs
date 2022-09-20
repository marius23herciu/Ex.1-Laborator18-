using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex._1_Laborator18_.Models
{
    public class TechnicalBook
    {
        /*
         • Cartea tehnica va avea urmatoarele:
• Id:int
• Capacitate cilindrica :int
• An de fabricatie :int
• Serie de sasiu: string
         */
        public int Id { get; set; }
        public int CylinderCapacity { get; set; }
        public int YearOfProduction { get; set; }
        public string VINnumber { get; set; }
        public int AutomobileId { get; set; }
        public Automobile Automobile { get; set; }
    }
}
