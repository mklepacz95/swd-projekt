using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DbConn.Models
{
    public class Sala
    {
        [Key]
        public int id { get; set; }
        public int ilosc_miejsc { get; set; }
    }
}