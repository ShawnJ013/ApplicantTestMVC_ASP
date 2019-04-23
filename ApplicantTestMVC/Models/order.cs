using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApplicantTestMVC.Models
{
    public class order
    {
        [Key]
        public int order_id { get; set; }

        public DateTime date_created { get; set; }

        public DateTime? date_ordered { get; set; }

        public DateTime date_updated { get; set; }

        public string note { get; set; }

        [ForeignKey("user")]
        public int user_id { get; set; }

        //one order to many with line_items 
        public virtual ICollection<line_item> line_item { get; set; }

        //one to many with user
        public user user { get; set; }


    }
}