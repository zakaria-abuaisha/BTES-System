using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTES.Business_layer.Discounts;
using BTES.Data_Access.Discounts;
using BTES.Data_Access.Tickets;

namespace BTES.Business_layer.Tickets
{
    public class clsWaitingList
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int WaitingListID { set; get; }
        public int EventID { set; get; }
        public int CustomerID { set; get; }
        public DateTime JoinDate { set; get; }
        public int PaymentMethod { set; get; }
        public string AccountID { set; get; }
        public string Password { set; get; }
        public string TicketType { set; get; } 

        public clsWaitingList()
        {
            this.WaitingListID = -1;
            this.EventID = -1;
            this.CustomerID = -1;
            this.JoinDate = DateTime.Now;
            this.PaymentMethod = -1;
            this.AccountID = "";
            this.Password = "";
            this.TicketType = "";
            Mode = enMode.AddNew;
        }

        private clsWaitingList(int WaitingListID, int EventID, int CustomerID, DateTime JoinDate, int PaymentMethod, string AccountID, string Password, string TicketType)
        {
            this.WaitingListID = WaitingListID;
            this.EventID = EventID;
            this.CustomerID = CustomerID;
            this.JoinDate = JoinDate;
            this.PaymentMethod = PaymentMethod;
            this.AccountID = AccountID;
            this.Password = Password;
            this.TicketType = TicketType;
            Mode = enMode.Update;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewclsWaitingList())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateclsWaitingList();
            }
            return false;
        }

        public static clsWaitingList GetFirstRecordBy(int EventID, string TicketType)
        {
            int WaitingList_ID = -1; int Customer_ID = -1; DateTime JoinDate = DateTime.Now; int Payment_Method = -1; string Account_ID = ""; string Password = "";
            if (clsWaitingListData.GetFirstRecordBy(ref WaitingList_ID, EventID, ref Customer_ID, ref JoinDate, ref Payment_Method, ref Account_ID, ref Password, TicketType))
                return new clsWaitingList(WaitingList_ID, EventID, Customer_ID, JoinDate, Payment_Method, Account_ID, Password, TicketType);
            else
                return null;
        }

        private bool _AddNewclsWaitingList()
        {
            //call DataAccess Layer 
            this.WaitingListID = clsWaitingListData.InsertRecord(this.EventID, this.CustomerID, this.JoinDate, this.PaymentMethod, this.AccountID, this.Password, this.TicketType);
            return (this.WaitingListID != -1);
        }

        private bool _UpdateclsWaitingList()
        {
            //call DataAccess Layer 
            return clsWaitingListData.UpdateRecord(this.WaitingListID, this.EventID, this.CustomerID, this.JoinDate, this.PaymentMethod, this.AccountID, this.Password, this.TicketType);
        }

        public static bool DeleteRecord(int WaitingList_ID)
        {
            return clsWaitingListData.DeleteRecord(WaitingList_ID);
        }

        public bool PurshaseTickit(ClsEvent Event)
        {
            ClsPurchasedTicket purchasedTicket = new ClsPurchasedTicket();
            ClsDiscount discount = ClsDiscount.Find(CustomerID);

            purchasedTicket.TicketType = this.TicketType;
            purchasedTicket.Event = Event;
            purchasedTicket.Customer = ClsCustomer.Find(this.CustomerID);
            purchasedTicket.Purchase_Date = DateTime.Now;


            if(TicketType == "Regular")
            {
                purchasedTicket.Fees = discount != null?
                    Event.regularPrice * ClsDiscountTypes.DiscountTypes[discount.DiscountType - 1].value : Event.regularPrice;
            }
            else if(TicketType == "VIP")
            {
                purchasedTicket.Fees = discount != null ?
                    Event.VIPprice * ClsDiscountTypes.DiscountTypes[discount.DiscountType - 1].value : Event.VIPprice;
            }


            return purchasedTicket.Purchase(AccountID, Password);            
        }
    }
}