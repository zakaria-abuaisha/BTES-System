using BTES.Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTES.Business_layer
{
    public class ClsPurchasedTicket
    {
        public enum enPaymentMethod { DebtCard = 1, MobyCash = 2, Saddad = 3, Tadawul = 4, Edfali = 5 };
        public enPaymentMethod PaymentGateway = enPaymentMethod.DebtCard;

        public int PurchasedTicket_ID { set; get; }
        public DateTime Purchase_Date { set; get; }
        public float Fees { set; get; }
 

        public clsCustomer Customer { set; get; }
        public clsEvent Event { set; get; }
        public bool Status { set; get; }
        public string TicketType { set; get; }


        public ClsPurchasedTicket()
        {
            this.PurchasedTicket_ID = -1;
      
            this.Customer = new clsCustomer();
            this.Event = new clsEvent();
            this.Purchase_Date = DateTime.Now;
            this.Fees = 0;
     
            this.TicketType = "";

    
        }

        private ClsPurchasedTicket(int PurchasedTicket_ID, int Event_ID, int Customer_ID, DateTime Purchase_Date, float Fees, int Payment_Gateway, bool Status, string TicketType)
        {
            this.PurchasedTicket_ID = PurchasedTicket_ID;
            this.Event = clsEvent.FindbyEvent(Event_ID);
            this.Customer = clsCustomer.Find(Customer_ID);
            this.Purchase_Date = Purchase_Date;
            this.Fees = Fees;
            this.PaymentGateway = (enPaymentMethod)Payment_Gateway;
            this.Status = Status;
            this.TicketType = TicketType;

        }

        public bool Purchase(string accountID, string password)
        {
            try
            {
                switch (PaymentGateway)
                {
                    case enPaymentMethod.DebtCard:
                        {
                            clsDebtCard DebtCard = new clsDebtCard();
                            DebtCard.accountID = accountID;
                            DebtCard.password = password;
                            DebtCard.Authenticate();
                            DebtCard.Pay_For_Ticket();

                            break;
                        }
                    case enPaymentMethod.MobyCash:
                        {
                            clsMobyCash MobyCash = new clsMobyCash();
                            MobyCash.accountID = accountID;
                            MobyCash.password = password;
                            MobyCash.Authenticate();
                            MobyCash.Pay_For_Ticket();

                            break;
                        }
                    case enPaymentMethod.Saddad:
                        {
                            clsSaddad Saddad = new clsSaddad();
                            Saddad.accountID = accountID;
                            Saddad.password = password;
                            Saddad.Authenticate();
                            Saddad.Pay_For_Ticket();

                            break;
                        }
                    case enPaymentMethod.Tadawul:
                        {
                            clsTadawul Tadawul = new clsTadawul();
                            Tadawul.accountID = accountID;
                            Tadawul.password = password;
                            Tadawul.Authenticate();
                            Tadawul.Pay_For_Ticket();

                            break;
                        }
                    case enPaymentMethod.Edfali:
                        {
                            clsEdfali Edfali = new clsEdfali();
                            Edfali.accountID = accountID;
                            Edfali.password = password;
                            Edfali.Authenticate();
                            Edfali.Pay_For_Ticket();

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            this.PurchasedTicket_ID = ClsPurchasedTicketDA.Purchase_Ticket(Event.event_ID, Customer.Customer_ID, Fees, (int)PaymentGateway, TicketType);
            return PurchasedTicket_ID != -1;
        }

        public static ClsPurchasedTicket Find(int PT_ID)
        {
            int Event_ID = -1;
            int Customer_ID = -1;
            DateTime Purchase_Date = DateTime.Now;
            float Fees = -1;
            int Payment_Gateway = -1;
            bool Status = false ;
            string TicketType = "";

            if (ClsPurchasedTicketDA.GetPurchased_Tickets_Info_By_In_Purchased_Tickets(PT_ID, ref Event_ID, ref Customer_ID, ref Purchase_Date, ref Fees, ref Payment_Gateway, ref Status, ref TicketType))
                return new ClsPurchasedTicket(PT_ID, Event_ID, Customer_ID, Purchase_Date, Fees, Payment_Gateway, Status, TicketType);
            else
                return null;
        }

        public bool Refund(string accountID, string password)
        {
            try
            {
                switch (PaymentGateway)
                {
                    case enPaymentMethod.DebtCard:
                        {
                            clsDebtCard DebtCard = new clsDebtCard();
                            DebtCard.accountID = accountID;
                            DebtCard.password = password;
                            DebtCard.Authenticate();
                            DebtCard.Refund();

                            break;
                        }
                    case enPaymentMethod.MobyCash:
                        {
                            clsMobyCash MobyCash = new clsMobyCash();
                            MobyCash.accountID = accountID;
                            MobyCash.password = password;
                            MobyCash.Authenticate();
                            MobyCash.Refund();

                            break;
                        }
                    case enPaymentMethod.Saddad:
                        {
                            clsSaddad Saddad = new clsSaddad();
                            Saddad.accountID = accountID;
                            Saddad.password = password;
                            Saddad.Authenticate();
                            Saddad.Refund();

                            break;
                        }
                    case enPaymentMethod.Tadawul:
                        {
                            clsTadawul Tadawul = new clsTadawul();
                            Tadawul.accountID = accountID;
                            Tadawul.password = password;
                            Tadawul.Authenticate();
                            Tadawul.Refund();

                            break;
                        }
                    case enPaymentMethod.Edfali:
                        {
                            clsEdfali Edfali = new clsEdfali();
                            Edfali.accountID = accountID;
                            Edfali.password = password;
                            Edfali.Authenticate();
                            Edfali.Refund();

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return ClsPurchasedTicketDA.Refund_Ticket(PurchasedTicket_ID, Event.event_ID, TicketType);

        }

        public static bool IsRefundAllowed(int PurchasedTicket_ID)
        {
            return ClsPurchasedTicketDA.IsRefundAllowed(PurchasedTicket_ID);
        }

        public static DataTable ViewPurchasedTicket(int CostumerID)
        {
            return ClsPurchasedTicketDA.GetAllRecords(CostumerID);
        }
    }

    
}
