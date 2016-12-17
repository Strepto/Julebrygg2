using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Julebrygg2.Models
{
    public class Drikke
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public string Bryggeri { get; set; }
        public double Abv { get; set; }
        public string Bilde { get; set; }
        public string Stil { get; set; }
        public double Pris { get; set; }
        public string Land { get; set; }
    }
}