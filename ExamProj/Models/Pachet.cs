using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamProj.Models
{
    public class Pachet
    {
        public int Id { get; set; }
        public string TaraOrigine { get; set; }
        public string Expeditor { get; set; }
        public string TaraDestinatie { get; set; }
        public string Destinatar { get; set; }
        public string Adresa { get; set; }
        public double Cost { get; set; }
        public string CodTracking { get; set; }
        public User Owner { get; set; }


    }
}
