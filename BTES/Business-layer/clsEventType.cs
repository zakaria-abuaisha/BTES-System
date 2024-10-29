using BTES.Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Business_layer
{

    public class clsEventType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int eventTypeID { set; get; }
        public string eventTypeName { set; get; }


        public clsEventType()
        {
            this.eventTypeID = -1;
            this.eventTypeName = "";

            Mode = enMode.AddNew;
        }

        private clsEventType(int EventType_ID, string EventType_Name)
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


        public static clsEventType FindbyEventType_ID(int eventTypeID)
        {
            string eventTypeName = ""; ;

            if (clsEventTypeData.FindByEventType_ID(eventTypeID, ref eventTypeName))

                return new clsEventType(eventTypeID, eventTypeName);
            else
                return null;
        }

        private bool _AddNewclsEventType()
        {
            //call DataAccess Layer 

            this.eventTypeID = clsEventTypeData.InsertRecord(this.eventTypeName);

            return (this.eventTypeID != -1);
        }

        private bool _UpdateclsEventType()
        {
            //call DataAccess Layer 

            return clsEventTypeData.UpdateRecord(this.eventTypeID, this.eventTypeName);
        }

        public static bool DeleteRecord(int EventType_ID)
        {
            return clsEventTypeData.DeleteEventType(EventType_ID);
        }

        public static DataTable GetAllRecord()
        {
            return clsEventTypeData.GetAllRecords();

        }
    }
}