using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class facility
    {
        [Key]
        public int fID2 { get; set; }
        public string fName2 { get; set; }
        public string fModel2 { get; set; }
        public string fDesc2 { get; set; }
        public int fPrice2 { get; set; }       
    }
}