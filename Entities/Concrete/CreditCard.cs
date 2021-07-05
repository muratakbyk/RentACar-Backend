using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard:IEntity

    {
        public int Id  { get; set; }
        public int CardNumber  { get; set; }
        public int CustomerId  { get; set; }
        public string FirstName  { get; set; }
        public string LastName  { get; set; }
        public int ExpirationMonth  { get; set; }
        public int ExpirationYear  { get; set; }
        public int Cvv  { get; set; }
        




    }
}
