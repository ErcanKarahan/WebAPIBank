using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIBank.Models.Entities;
using WebAPIBank.Models.MyInit;

namespace WebAPIBank.Models.Context
{
    public class MyContext:DbContext
    {
        public MyContext():base ("MyConnection")
        {
            Database.SetInitializer(new Init());

        }

        public DbSet<CardInfo> Cards { get; set; }

    }
}