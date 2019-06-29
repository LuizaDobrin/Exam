using ExamProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamProj.ViewModels
{
    public class PachetPostModel
    {
        public string TaraOrigine { get; set; }
        public string Expeditor { get; set; }
        public string TaraDestinatie { get; set; }
        public string Destinatar { get; set; }
        public string Adresa { get; set; }
        public double Cost { get; set; }
        public string CodTracking { get; set; }

        public static Pachet ToPachet(PachetPostModel pachet)
        {
          
        return new Pachet
            {
            TaraOrigine = pachet.TaraOrigine,
            Expeditor = pachet.Expeditor,
            TaraDestinatie = pachet.TaraDestinatie,
            Destinatar = pachet.Destinatar,
            Adresa = pachet.Adresa,
            Cost = pachet.Cost,
            CodTracking = pachet.CodTracking

        };

        }
    }
}
