using System.Data;
using BTES.Data_Access;
using BTES.Data_Access.Event_Management;

namespace BTES.Business_layer.Event_Management
{

    public class clsSportEvent
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int Sport_ID { set; get; }
        public int Event_ID { set; get; }
        public string Team_VS_Team { set; get; }


        public clsSportEvent()
        {
            this.Sport_ID = -1;
            this.Event_ID = -1;
            this.Team_VS_Team = "";

            Mode = enMode.AddNew;
        }

        private clsSportEvent(int Sport_ID, int Event_ID, string Team_VS_Team)
        {
            this.Sport_ID = Sport_ID;
            this.Event_ID = Event_ID;
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
            int Event_ID = -1; string Team_VS_Team = "";
            if (clsSportEventData.FindBySport_ID(Sport_ID, ref Event_ID, ref Team_VS_Team))

                return new clsSportEvent(Sport_ID, Event_ID, Team_VS_Team);
            else
                return null;
        }


        private bool _AddNewclsSportEvent()
        {
            //call DataAccess Layer 

            this.Sport_ID = clsSportEventData.InsertRecord(this.Event_ID, this.Team_VS_Team);

            return (this.Sport_ID != -1);
        }

        private bool _UpdateclsSportEvent()
        {
            //call DataAccess Layer 

            return clsSportEventData.UpdateRecord(this.Sport_ID, this.Event_ID, this.Team_VS_Team);
        }

        public static bool DeleteRecord(int Sport_ID)
        {
            return clsSportEventData.DeleteRecord(Sport_ID);
        }

        public static bool isRecordExist(int Sport_ID)
        {
            return clsSportEventData.IsRecordExist(Sport_ID);
        }
        public static DataTable GetAllRecord()
        {
            return clsSportEventData.GetRecords();

        }

    }
}