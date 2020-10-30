using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5_2.Models
{
    public class sandwich
    {
        [Key]
        public int fid { get; set; }
        public string fname { get; set; }
        public string fNumber { get; set; }
        public string fDesc { get; set; }
        public int fPrice { get; set; }


    }
}