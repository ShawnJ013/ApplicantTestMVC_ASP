using ApplicantTestMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantTestMVC.ViewModels
{
    public class OrderVM
    {
        public order order { get; set; }
        public user user { get; set; }
        public List<line_item> line_items { get; set; }
    }
}