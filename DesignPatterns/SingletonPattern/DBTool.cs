using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBank.Models.Context;

namespace WebAPIBank.DesignPatterns.SingletonPattern
{
    public class DBTool
    {
        DBTool(){}

         static MyContext _dbInstance;

         public static MyContext DBInstance
         {
             get
             {
                 if (_dbInstance==null)
                 {
                     _dbInstance = new MyContext();

                 }

                 return _dbInstance;
             }
         }
    }
}