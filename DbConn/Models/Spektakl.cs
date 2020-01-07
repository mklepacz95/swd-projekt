using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DbConn.Models
{
    [Table("spektakl")]
    public class Spektakl
    {
        [Key]
        public int id { get; set; }
        public String nazwa { get; set; }
        //[ForeignKey("Sala")]
        public int id_sala { get; set; }
    }

    public class SpektaklContext : DbContext
    {
        public SpektaklContext() : base("name=mySqlConnection")
        {

        }

        public DbSet<Spektakl> spektakls { get; set; }
    }
}