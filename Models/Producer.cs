using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex._1_Laborator18_.Models
{
    public class Producer
    {
        /*
         • Producatorul va avea
• Id:int
• Nume
• Adresa:string
         */
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Adresse { get; set; }
        public List<Automobile> Automobiles { get; set; }=new List<Automobile> (){ };
        //public int? AutomobilesId { get; set; }
    }
}
