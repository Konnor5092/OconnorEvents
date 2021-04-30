﻿using OconnorEvents.MessagingBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket.Dtos
{
    public class BasketCheckoutMessageDto : IntegrationBaseMessage
    {
        public Guid BasketId { get; set; }

        //user info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        //payment information
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpiration { get; set; }

        //order info
        public List<BasketLineMessageDto> BasketLines { get; set; }
        public int BasketTotal { get; set; }
    }
}
