using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFirstAzureWebApp.Models
{
    public class ViewDTO
    {
        public string imageURl { get; set; }
        public ZomatoDOT restaurant1 { get; set; }
        public ZomatoDOT restaurant2 { get; set; }
        public ZomatoDOT restaurant3 { get; set; }
    }
}