using System.Data;
using BTES.Data_Access.Event_Management;

namespace BTES.Business_layer.Event_Management
{

    public class clsConcertEvent
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int Concert_ID { set; get; }
        public int Event_ID { set; get; }
        public string Band_Or_Artist { set; get; }


        public clsConcertEvent()
        {
            this.Concert_ID = -1;
            this.Event_ID = -1;
            this.Band_Or_Artist = "";

            Mode = enMode.AddNew;
        }

        private clsConcertEvent(int Concert_ID, int Event_ID, string Band_Or_Artist)
        {
            this.Concert_ID = Concert_ID;
            this.Event_ID = Event_ID;
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
            int Event_ID = -1; string Band_Or_Artist = ""; ;
            if (clsConcertEventData.FindByConcert_ID(Concert_ID, ref Event_ID, ref Band_Or_Artist))

                return new clsConcertEvent(Concert_ID, Event_ID, Band_Or_Artist);
            else
                return null;
        }

        private bool _AddNewclsConcertEvent()
        {
            //call DataAccess Layer 

            this.Concert_ID = clsConcertEventData.InsertRecord(this.Event_ID, this.Band_Or_Artist);

            return (this.Concert_ID != -1);
        }

        private bool _UpdateclsConcertEvent()
        {
            //call DataAccess Layer 

            return clsConcertEventData.UpdateRecord(this.Concert_ID, this.Event_ID, this.Band_Or_Artist);
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