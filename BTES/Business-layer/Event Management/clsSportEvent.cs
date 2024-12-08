using System.Data;
using BTES.Data_Access;
using BTES.Data_Access.Event_Management;

namespace BTES.Business_layer.Event_Management
{

    public class clsSportEvent : ClsEvent
    {
        public int Sport_ID { set; get; }
        public string Team_VS_Team { set; get; }


        public clsSportEvent() : base()
        {
            this.Sport_ID = -1;
            this.event_ID = -1;
            this.Team_VS_Team = "";

            Mode = enMode.AddNew;
        }

        public clsSportEvent(ClsEvent Event) : base(Event)
        {
            this.Sport_ID = -1;
            this.Team_VS_Team = "";

            Mode = enMode.AddNew;
        }

        private clsSportEvent(int Sport_ID, string Team_VS_Team, ClsEvent Event) : base(Event)
        {
            this.Sport_ID = Sport_ID;
            this.Team_VS_Team = Team_VS_Team;

            Mode = enMode.Update;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewclsSportEvent())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateclsSportEvent();

            }

            return false;
        }

        public static clsSportEvent FindbySport_ID(int Sport_ID)
        {
            string Team_VS_Team = "";
            ClsEvent Event = new ClsEvent();
            if (clsSportEventData.FindBySport_ID(Sport_ID, ref Team_VS_Team, ref Event))
                return new clsSportEvent(Sport_ID, Team_VS_Team, Event);
            else
                return null;
        }

        public static clsSportEvent FindbyEvent_ID(int Event_ID)
        {
            int Sport_ID = -1; string Team_VS_Team = "";
            ClsEvent Event = new ClsEvent();
            if (clsSportEventData.FindByEvent_ID(Event_ID , ref Sport_ID, ref Team_VS_Team, ref Event))

                return new clsSportEvent(Sport_ID, Team_VS_Team, Event);
            else
                return null;
        }

        private bool _AddNewclsSportEvent()
        {
            //call DataAccess Layer 
            int New_Event_ID = -1;
            this.Sport_ID = clsSportEventData.InsertRecord(this, ref New_Event_ID);
            this.event_ID = New_Event_ID;
            return (this.Sport_ID != -1);
        }

        private bool _UpdateclsSportEvent()
        {
            //call DataAccess Layer 

            return clsSportEventData.UpdateRecord(this);
        }

        public static bool DeleteRecord(int Sport_ID)
        {
            return clsSportEventData.DeleteRecord(Sport_ID);
        }

        public static DataTable GetAllRecord()
        {
            return clsSportEventData.GetRecords();

        }

    }
}