using BTES.Business_layer.Tickets;
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


        public ClsCustomer Customer { set; get; }
        public ClsEvent Event { set; get; }
        public bool Status { set; get; }
        public string TicketType { set; get; }


        public ClsPurchasedTicket()
        {
            this.PurchasedTicket_ID = -1;

            this.Customer = new ClsCustomer();
            this.Event = new ClsEvent();
            this.Purchase_Date = DateTime.Now;
            this.Fees = 0;

            this.TicketType = "";


        }

        public ClsPurchasedTicket(int PurchasedTicket_ID, ClsEvent Event, ClsCustomer Customer, DateTime Purchase_Date, float Fees, enPaymentMethod Payment_Gateway, bool Status, string TicketType)
        {
            this.PurchasedTicket_ID = PurchasedTicket_ID;
            this.Event = Event;
            this.Customer = Customer;
            this.Purchase_Date = Purchase_Date;
            this.Fees = Fees;
            this.PaymentGateway = Payment_Gateway;
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
                            ClsDebtCard DebtCard = new ClsDebtCard();
                            DebtCard.accountID = accountID;
                            DebtCard.password = password;
                            DebtCard.Fees = Fees;
                            DebtCard.Authenticate();
                            DebtCard.Pay_For_Ticket();

                            break;
                        }
                    case enPaymentMethod.MobyCash:
                        {
                            clsMobyCash MobyCash = new clsMobyCash();
                            MobyCash.accountID = accountID;
                            MobyCash.password = password;
                            MobyCash.Fees = Fees;
                            MobyCash.Authenticate();
                            MobyCash.Pay_For_Ticket();

                            break;
                        }
                    case enPaymentMethod.Saddad:
                        {
                            ClsSaddad Saddad = new ClsSaddad();
                            Saddad.accountID = accountID;
                            Saddad.password = password;
                            Saddad.Fees = Fees;
                            Saddad.Authenticate();
                            Saddad.Pay_For_Ticket();

                            break;
                        }
                    case enPaymentMethod.Tadawul:
                        {
                            clsTadawul Tadawul = new clsTadawul();
                            Tadawul.accountID = accountID;
                            Tadawul.password = password;
                            Tadawul.Fees = Fees;
                            Tadawul.Authenticate();
                            Tadawul.Pay_For_Ticket();

                            break;
                        }
                    case enPaymentMethod.Edfali:
                        {
                            clsEdfali Edfali = new clsEdfali();
                            Edfali.accountID = accountID;
                            Edfali.password = password;
                            Edfali.Fees = Fees;
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

            this.PurchasedTicket_ID = ClsPurchasedTicketDA.Purchase_Ticket(this);
            return PurchasedTicket_ID != -1;
        }

        public static ClsPurchasedTicket Find(int PT_ID)
        {
            int Event_ID = -1;
            int Customer_ID = -1;
            DateTime Purchase_Date = DateTime.Now;
            float Fees = -1;
            int Payment_Gateway = -1;
            bool Status = false;
            string TicketType = "";

            if (ClsPurchasedTicketDA.GetPurchased_Tickets_Info_By_In_Purchased_Tickets(PT_ID, ref Event_ID, ref Customer_ID, ref Purchase_Date, ref Fees, ref Payment_Gateway, ref Status, ref TicketType))
                return new ClsPurchasedTicket(PT_ID, ClsEvent.FindEvent(Event_ID), ClsCustomer.Find(Customer_ID), Purchase_Date, Fees, (enPaymentMethod)Payment_Gateway, Status, TicketType);
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
                            ClsDebtCard DebtCard = new ClsDebtCard();
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
                            ClsSaddad Saddad = new ClsSaddad();
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

                return ClsPurchasedTicketDA.Refund_Ticket(this);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsRefundAllowed()
        {
            return ClsPurchasedTicketDA.IsRefundAllowed(PurchasedTicket_ID);
        }

        public static DataTable ViewPurchasedTicket(int CostumerID)
        {
            return ClsPurchasedTicketDA.GetAllRecords(CostumerID);
        }

        public static bool IsEventFull(int EventID, string TicketType)
        {
            return ClsPurchasedTicketDA.IsEventFull(EventID, TicketType);
        }

    }


}
