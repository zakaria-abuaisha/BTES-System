﻿using BTES.Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Business_layer
{

    public class ClsEvent
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int event_ID { set; get; }
        public string title { set; get; }
        public string eventContent { set; get; }
        public DateTime eventDate { set; get; }
        public int eventTypeID { set; get; }
        public int regularTickets { set; get; }
        public int VIPTickets { set; get; }
        public float regularPrice { set; get; }
        public float VIPprice { set; get; }
        public string location { set; get; }
        public int createdByUserID { set; get; }

        public ClsEventType eventType { set; get; }
        public ClsEvent()
        {
            this.event_ID = -1;
            this.title = "";
            this.eventContent = "";
            this.eventDate = DateTime.Now;
            this.eventTypeID = -1;
            this.regularTickets = -1;
            this.VIPTickets = -1;
            this.regularPrice = -1;
            this.VIPprice = -1;
            this.location = "";
            this.createdByUserID = -1;
            this.eventType = null;
            Mode = enMode.AddNew;
        }

        private ClsEvent(int Event_ID, string Title, string Event_Content, DateTime Event_Date, int EventType_ID, int Regular_Tickets, int VIP_Tickets, float Regular_Price, float VIP_Price, string Location, int Created_By)
        {
            this.event_ID = Event_ID;
            this.title = Title;
            this.eventContent = Event_Content;
            this.eventDate = Event_Date;
            this.eventTypeID = EventType_ID;
            this.regularTickets = Regular_Tickets;
            this.VIPTickets = VIP_Tickets;
            this.regularPrice = Regular_Price;
            this.VIPprice = VIP_Price;
            this.location = Location;
            this.createdByUserID = Created_By;
            this.eventType = ClsEventType.FindbyEventType_ID(EventType_ID);
            Mode = enMode.Update;
        }

        private bool _UpdateclsEvent()
        {
            //call DataAccess Layer 

            return ClsEventData.UpdateRecord(this.event_ID, this.title, this.eventContent, this.eventDate, this.eventTypeID, this.regularTickets, this.VIPTickets, this.regularPrice, this.VIPprice, this.location, this.createdByUserID);
        }

        private bool _AddNewclsEvent()
        {
            //call DataAccess Layer 

            this.event_ID = ClsEventData.InsertRecord(this.title, this.eventContent, this.eventDate, this.eventTypeID, this.regularTickets, this.VIPTickets, this.regularPrice, this.VIPprice, this.location, this.createdByUserID);

            return (this.event_ID != -1);
        }

        public static bool DeleteRecord(int event_ID)
        {
            return ClsEventData.DeleteEvent(event_ID);
        }

        public static ClsEvent FindEvent(int Event_ID)
        {
            string title = ""; string eventContent = ""; DateTime eventDate = DateTime.Now; int eventTypeID = -1; int regularTickets = -1; int VIPTickets = -1; float regularPrice = -1; float VIPprice = -1; string location = ""; int createdByUserID = -1; ;
            if (ClsEventData.FindByEvent_ID(Event_ID, ref title, ref eventContent, ref eventDate, ref eventTypeID, ref regularTickets, ref VIPTickets, ref regularPrice, ref VIPprice, ref location, ref createdByUserID))

                return new ClsEvent(Event_ID, title, eventContent, eventDate, eventTypeID, regularTickets, VIPTickets, regularPrice, VIPprice, location, createdByUserID);
            else
                return null;
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewclsEvent())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateclsEvent();

            }

            return false;
        }


        public static DataTable GetAllRecord()
        {
            return ClsEventData.GetAllRecords();

        }
    }
}
