﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Julebrygg2.Models
{
    public class Bruker : BaseEntity
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        
        public string Kodeord { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}