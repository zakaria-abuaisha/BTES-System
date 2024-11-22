using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTES.Data_Access.Event_Management;

namespace BTES.Business_layer.Event_Management
{

    public class clsEventRate
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int EventRate_ID { set; get; }
        public int Event_ID { set; get; }
        public int Customer_ID { set; get; }
        public int Rate { set; get; }
        public string Comment { set; get; }


        public clsEventRate()
        {
            this.EventRate_ID = -1;
            this.Event_ID = -1;
            this.Customer_ID = -1;
            this.Rate = -1;
            this.Comment = "";

            Mode = enMode.AddNew;
        }

        private clsEventRate(int EventRate_ID, int Event_ID, int Customer_ID, int Rate, string Comment)
        {
            this.EventRate_ID = EventRate_ID;
            this.Event_ID = Event_ID;
            this.Customer_ID = Customer_ID;
            this.Rate = Rate;
            this.Comment = Comment;

            Mode = enMode.Update;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewclsEventRate())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateclsEventRate();

            }

            return false;
        }


        public static clsEventRate Findby()
        {
            int EventRate_ID = -1; int Event_ID = -1; int Customer_ID = -1; int Rate = -1; string Comment = ""; ;
            if (clsEventRateData.FindByEventRate_ID(EventRate_ID, ref Event_ID, ref Customer_ID, ref Rate, ref Comment))

                return new clsEventRate(EventRate_ID, Event_ID, Customer_ID, Rate, Comment);
            else
                return null;
        }

        private bool _AddNewclsEventRate()
        {
            //call DataAccess Layer 

            this.EventRate_ID = clsEventRateData.InsertRecord(this.Event_ID, this.Customer_ID, this.Rate, this.Comment);

            return (this.EventRate_ID != -1);
        }

        private bool _UpdateclsEventRate()
        {
            //call DataAccess Layer 

            return clsEventRateData.UpdateRecord(this.EventRate_ID, this.Event_ID, this.Customer_ID, this.Rate, this.Comment);
        }

        public static bool DeleteRecord(int EventRate_ID)
        {
            return clsEventRateData.DeleteRecord(EventRate_ID);
        }

        public static DataTable Get_Record()
        {
            return clsEventRateData.GetRecords();

        }

    }
}