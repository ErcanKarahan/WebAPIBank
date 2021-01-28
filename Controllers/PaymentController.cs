using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIBank.DesignPatterns.SingletonPattern;
using WebAPIBank.DTOClasses;
using WebAPIBank.Models.Context;
using WebAPIBank.Models.Entities;

namespace WebAPIBank.Controllers
{
    public class PaymentController : ApiController
    {
        MyContext _db;

        public PaymentController()
        {
            _db = DBTool.DBInstance;
        }

        public List<PaymentVM> GetAll()
        {
            return _db.Cards.Select(x => new PaymentVM
            {
                CardUserName = x.CardUserName
            }).ToList();
        }
        //https://localhost:44391/api/Payment/RecivePayment

        [HttpPost]
        public IHttpActionResult RecivePayment(PaymentVM item)
        {
            CardInfo cif = _db.Cards.FirstOrDefault(x =>
                x.CardNumber == item.CardNumber && x.SecurityNumber == item.SecurityNumber &&
                x.CardUserName == item.CardUserName && x.CardExpiryMonth == item.CardExpiryMonth &&
                x.CardExpiryYear == item.CardExpiryYear);
            if (cif != null)
            {
                if (cif.CardExpiryYear < DateTime.Now.Year)
                {
                    return BadRequest("Expired Year");

                }
                else if (cif.CardExpiryYear == DateTime.Now.Year)
                {
                    if (cif.CardExpiryMonth < DateTime.Now.Month)
                    {
                        return BadRequest("Expired Card");

                    }

                    if (cif.Balance >= item.TicketPrice)
                    {
                        cif.Balance -= item.TicketPrice;
                        return Ok();

                    }
                    else
                    {
                        return BadRequest("Balance Exceeded");

                    }
                }


                if (cif.Balance >= item.TicketPrice)
                {
                    cif.Balance -= item.TicketPrice;//İlgili Kartın Bakiyesini Bilet fiyatı kadar Düşürüyoruz.
                    return Ok();
                }
                else
                {
                    return BadRequest("Balance Exceeded");

                }
            }
            else
            {
                return BadRequest("Card Not Found");// Card Bulunamadı.

            }


        }

    }
}

