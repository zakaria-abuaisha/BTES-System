﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Business_layer
{
    public class Saddad : IPaymentGateway
    {
        public string accountID;
        public string password;
        public void Authenticate()
        {
            // Implement specific logic for processing payments via Saddad

        }

        public void Pay_For_Ticket()
        {
            // Implement specific logic for processing payments via Saddad

        }

        public void Refund()
        {
            // Implement specific logic for processing payments via Saddad

        }
    }
}