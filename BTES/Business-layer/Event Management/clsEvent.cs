using BTES.Data_Access;
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
        public enum enEventType { NULL = 0, Sport = 1, Concert = 2 };
        public enEventType eventType { set; get; }
        public int regularTickets { set; get; }
        public int VIPTickets { set; get; }
        public float regularPrice { set; get; }
        public float VIPprice { set; get; }
        public string location { set; get; }
        public int createdByUserID { set; get; }

        public ClsEvent()
        {
            this.event_ID = -1;
            this.title = "";
            this.eventContent = "";
            this.eventDate = DateTime.Now;
            this.eventType = enEventType.NULL;
            this.regularTickets = -1;
            this.VIPTickets = -1;
            this.regularPrice = -1;
            this.VIPprice = -1;
            this.location = "";
            this.createdByUserID = -1;
            Mode = enMode.AddNew;
        }

        protected ClsEvent(ClsEvent Event)
        {
            this.event_ID = Event.event_ID;
            this.title = Event.title;
            this.eventContent = Event.eventContent;
            this.eventDate = Event.eventDate;
            this.eventType = Event.eventType;
            this.regularTickets = Event.regularTickets;
            this.VIPTickets = Event.VIPTickets;
            this.regularPrice = Event.regularPrice;
            this.VIPprice = Event.VIPprice;
            this.location = Event.location;
            this.createdByUserID = Event.createdByUserID;

            Mode = enMode.Update;
        }

        public static ClsEvent FindEvent(int Event_ID)
        {
            ClsEvent newEvent = new ClsEvent();
            if (ClsEventData.FindByEvent_ID(Event_ID, ref newEvent))

                return new ClsEvent(newEvent);
            else
                return null;
        }

        public static DataTable GetAllRecord()
        {
            return ClsEventData.GetAllRecords();

        }
    }
}
