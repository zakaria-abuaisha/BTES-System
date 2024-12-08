using System.Data;
using BTES.Data_Access.Event_Management;

namespace BTES.Business_layer.Event_Management
{

    public class clsConcertEvent : ClsEvent
    {

        public int Concert_ID { set; get; }
        public string Band_Or_Artist { set; get; }


        public clsConcertEvent() : base()
        {
            this.Concert_ID = -1;
            this.Band_Or_Artist = "";

            Mode = enMode.AddNew;
        }

        public clsConcertEvent(ClsEvent Event) : base(Event)
        {
            this.Concert_ID = -1;
            this.Band_Or_Artist = "";

            Mode = enMode.AddNew;
        }

        private clsConcertEvent(int Concert_ID, string Band_Or_Artist, ClsEvent Event) : base(Event)
        {
            this.Concert_ID = Concert_ID;
            this.Band_Or_Artist = Band_Or_Artist;

            Mode = enMode.Update;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewclsConcertEvent())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateclsConcertEvent();

            }

            return false;
        }


        public static clsConcertEvent FindbyConcert_ID(int Concert_ID)
        {
            string Band_Or_Artist = "";
            ClsEvent Event = new ClsEvent();
            if (clsConcertEventData.FindByConcert_ID(Concert_ID, ref Band_Or_Artist, ref Event))

                return new clsConcertEvent(Concert_ID, Band_Or_Artist, Event);
            else
                return null;
        }

        public static clsConcertEvent FindbyEvent_ID(int Event_ID)
        {
            int Concert_ID = -1; string Band_Or_Artist = "";
            ClsEvent Event = new ClsEvent();
            if (clsConcertEventData.FindByEvent_ID(Event_ID, ref Concert_ID, ref Band_Or_Artist, ref Event))
                return new clsConcertEvent(Concert_ID, Band_Or_Artist, Event);
            else
                return null;
        }

        private bool _AddNewclsConcertEvent()
        {
            //call DataAccess Layer 
            int New_Event_ID = -1;
            this.Concert_ID = clsConcertEventData.InsertRecord(this, ref New_Event_ID);
            this.event_ID = New_Event_ID;
            return (this.Concert_ID != -1);
        }

        private bool _UpdateclsConcertEvent()
        {
            //call DataAccess Layer 

            return clsConcertEventData.UpdateRecord(this);
        }

        public static bool DeleteRecord(int Concert_ID)
        {
            return clsConcertEventData.DeleteRecord(Concert_ID);
        }

        public static DataTable GetAllRecord()
        {
            return clsConcertEventData.GetAllRecords();
            
        }
    }
}