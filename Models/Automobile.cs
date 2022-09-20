using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex._1_Laborator18_.Models
{
    public class Automobile
    {
        /*
         • Un autovehicul este caracterizat de urmatoarele proprietati
• Id:int
• Nume
• Producator
• Un numar variabil de chei (de la una la oricate)
• O carte tehnica
         */
        public int? Id { get; set; }
        public string Name { get; set; }
        public Producer Producer { get; set; }
        public int? ProducerId { get; set; }
        public TechnicalBook TechnicalBook { get; set; }
        public List<Key> Keys { get; set; }= new List<Key>();

    }
}
