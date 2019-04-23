using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace ApplicantTestMVC.Models
{
    public class unit
    {
        [Key]
        public int unit_id { get; set; }

        public string name { get; set; }

        public decimal cost { get; set; }

        // many to many unit and stock
        public virtual ICollection<stock> stocks { get; set; }

        // one to many unit and line_item
        public virtual ICollection<line_item> line_item { get; set; }

    }
}