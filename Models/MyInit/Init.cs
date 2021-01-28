using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIBank.Models.Context;
using WebAPIBank.Models.Entities;


namespace WebAPIBank.Models.MyInit
{
    public class Init:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            CardInfo cif =new CardInfo();
            cif.CardUserName = "Ercan Karahan";
            cif.CardNumber = "1111 1111 1111 1111";
            cif.CardExpiryYear = 2022;
            cif.CardExpiryMonth = 12;
            cif.SecurityNumber = "123";
            cif.Limit = 20000;
            cif.Balance = 50000;
            context.Cards.Add(cif);
            context.SaveChanges();
        }
    }
}