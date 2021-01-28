using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIBank.Models.Entities
{
    public class CardInfo
    {
        public int ID { get; set; }
        public string CardUserName { get; set; }
        public string SecurityNumber { get; set; }
        public string CardNumber { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardExpiryYear { get; set; }
        public decimal Limit { get; set; }
        public decimal Balance { get; set; }

    }
}