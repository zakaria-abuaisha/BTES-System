using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Business_layer
{
    public interface IPaymentGateway
    {
        void Authenticate();

        void Pay_For_Ticket();

        void Refund();
    }
}
