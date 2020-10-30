using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.context
{
    public class fData :DbContext

    {
        public fData() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\Source\Repos\Mytable.mdf;Integrated Security=True;Connect Timeout=30")
        { }
        public DbSet<facility> Facilities2 { get; set; }
    }
}