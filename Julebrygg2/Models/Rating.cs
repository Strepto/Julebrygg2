using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Julebrygg2.Models
{
    public class Rating : BaseEntity
    {
        public int ID { get; set; }
        public int DrikkeID { get; set; }
        public virtual Drikke Drikke { get; set; }
        public int BrukerID { get; set; }
        public virtual Bruker Bruker { get; set; }
        public string Bilde { get; set; }
        public int Karakter { get; set; }
        public string Nokkelord { get; set; }
        public bool SmakerJul { get; set; }

    }
}