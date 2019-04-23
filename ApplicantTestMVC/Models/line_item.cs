using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApplicantTestMVC.Models
{
    public class line_item
    {
        public line_item() { }

        [Key]
        public int line_item_id { get; set; }

        [ForeignKey("order")]
        public int order_id { get; set; }

        [ForeignKey("stock")]
        public int stock_id { get; set; }

        public string description { get; set; }

        public int qty { get; set; }

        public DateTime date_added { get; set; }

        [ForeignKey("unit")]
        public int unit_id { get; set; }

        public unit unit { get; set; }

        public order order { get; set; }

        public stock stock { get; set; }

    }
}