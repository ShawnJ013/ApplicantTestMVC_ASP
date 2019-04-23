using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicantTestMVC.Models
{
    public class stock
    {
        [Key]
        public int stock_id { get; set; }

        public string description { get; set; }

        //many to many stock and unit
        public virtual ICollection<unit>units { get; set; }

        //one to many with line_item
        public virtual ICollection<line_item> line_item { get; set; }
    }
}