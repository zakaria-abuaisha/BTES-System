﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Business_layer
{
    public class clsTadawul : IPaymentGateway
    {
        public string accountID;
        public string password;
        public float Fees;
        public void Authenticate()
        {
            // Implement specific logic for processing payments via Tadawul

        }

        public void Pay_For_Ticket()
        {
            // Implement specific logic for processing payments via Tadawul

        }

        public void Refund()
        {
            // Implement specific logic for processing payments via Tadawul

        }
    }
}