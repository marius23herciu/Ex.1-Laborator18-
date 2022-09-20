using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex._1_Laborator18_.Models
{
    public class Key
    {
        /*
         • O cheie va avea urmatoarele caracteristici
• Id (int)
• Cod de acces : Guid unic.
         */
        public int Id { get; set; }
        public Guid AccessCode { get; set; }
        public int AutomobileId { get; set; }
        public Automobile Automobile { get; set; }
    }
}
