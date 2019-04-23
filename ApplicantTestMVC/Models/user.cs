using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicantTestMVC.Models
{
    public class user
    {
        [Key]
        public int user_id { get; set; }

        public string userName { get; set; }

        public string address { get; set; }

        //one user can have many orders
        public virtual ICollection<order> order { get; set; }

    }
}