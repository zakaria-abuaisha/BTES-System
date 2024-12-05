using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public int AccountID { set; get; }
        public string Password { set; get; }


        public clsWaitingList()
        {
            this.WaitingListID = -1;
            this.EventID = -1;
            this.CustomerID = -1;
            this.JoinDate = DateTime.Now;
            this.PaymentMethod = -1;
            this.AccountID = -1;
            this.Password = "";

            Mode = enMode.AddNew;
        }

        private clsWaitingList(int WaitingListID, int EventID, int CustomerID, DateTime JoinDate, int PaymentMethod, int AccountID, string Password)
        {
            this.WaitingListID = WaitingListID;
            this.EventID = EventID;
            this.CustomerID = CustomerID;
            this.JoinDate = JoinDate;
            this.PaymentMethod = PaymentMethod;
            this.AccountID = AccountID;
            this.Password = Password;

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


        public static clsWaitingList Findby(int WaitingList_ID)
        {
            int Event_ID = -1; int Customer_ID = -1; DateTime JoinDate = DateTime.Now; int Payment_Method = -1; int Account_ID = -1; string Password = ""; ;
            if (clsWaitingListData.FindByID(WaitingList_ID, ref Event_ID, ref Customer_ID, ref JoinDate, ref Payment_Method, ref Account_ID, ref Password))

                return new clsWaitingList(WaitingList_ID, Event_ID, Customer_ID, JoinDate, Payment_Method, Account_ID, Password);
            else
                return null;
        }

        private bool _AddNewclsWaitingList()
        {
            //call DataAccess Layer 

            this.WaitingListID = clsWaitingListData.InsertRecord(this.EventID, this.CustomerID, this.JoinDate, this.PaymentMethod, this.AccountID, this.Password);

            return (this.WaitingListID != -1);
        }

        private bool _UpdateclsWaitingList()
        {
            //call DataAccess Layer 

            return clsWaitingListData.UpdateRecord(this.WaitingListID, this.EventID, this.CustomerID, this.JoinDate, this.PaymentMethod, this.AccountID, this.Password);
        }

        public static bool DeleteRecord(int WaitingList_ID)
        {
            return clsWaitingListData.DeleteRecord(WaitingList_ID);
        }
    }
}
