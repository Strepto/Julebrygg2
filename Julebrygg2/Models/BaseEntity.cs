using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Julebrygg2.Models
{
    public class BaseEntity
    {
        public DateTimeOffset? ModifiedDate { get; set; }
        public DateTimeOffset? CreateDate { get; set; }
    }
}