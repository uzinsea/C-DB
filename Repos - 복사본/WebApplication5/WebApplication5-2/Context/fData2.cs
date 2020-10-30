using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication5_2.Models;

namespace WebApplication5_2.Context
{
    public class fData2 : DbContext
    {
        public fData2() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\Source\Repos\Mytable.mdf;Integrated Security=True;Connect Timeout=30")
        { }
        public DbSet<sandwich> sandwichs { get; set; }
    }
}