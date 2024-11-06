using BTES.Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Business_layer
{

    public class ClsEventType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int eventTypeID { set; get; }
        public string eventTypeName { set; get; }


        public ClsEventType()
        {
            this.eventTypeID = -1;
            this.eventTypeName = "";

            Mode = enMode.AddNew;
        }

        private ClsEventType(int EventType_ID, string EventType_Name)
        {
            this.eventTypeID = EventType_ID;
            this.eventTypeName = EventType_Name;

            Mode = enMode.Update;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewclsEventType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateclsEventType();

            }

            return false;
        }


        public static ClsEventType FindbyEventType_ID(int eventTypeID)
        {
            string eventTypeName = ""; ;

            if (ClsEventTypeData.FindByEventType_ID(eventTypeID, ref eventTypeName))

                return new ClsEventType(eventTypeID, eventTypeName);
            else
                return null;
        }

        private bool _AddNewclsEventType()
        {
            //call DataAccess Layer 

            this.eventTypeID = ClsEventTypeData.InsertRecord(this.eventTypeName);

            return (this.eventTypeID != -1);
        }

        private bool _UpdateclsEventType()
        {
            //call DataAccess Layer 

            return ClsEventTypeData.UpdateRecord(this.eventTypeID, this.eventTypeName);
        }

        public static bool DeleteRecord(int EventType_ID)
        {
            return ClsEventTypeData.DeleteEventType(EventType_ID);
        }

        public static DataTable GetAllRecord()
        {
            return ClsEventTypeData.GetAllRecords();

        }
    }
}