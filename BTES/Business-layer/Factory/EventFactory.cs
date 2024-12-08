using BTES.Business_layer;
using BTES.Business_layer.Event_Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Data_Access.Factory
{
    public class EventFactory
    {
        public enum enEventType { Sport, Concerts, Regular };

        public static ClsEvent CreateEvent(enEventType eventType)
        {
            switch (eventType) 
            {
                case enEventType.Sport:
                    {
                        return new clsSportEvent();
                    }
                case enEventType.Concerts:
                    {
                        return new clsConcertEvent();
                    }                
                case enEventType.Regular:
                    {
                        return new ClsEvent();
                    }
                default:
                    throw new Exception($"There Are No Evenets With Type {eventType}");

            }
        }        
        
        public static ClsEvent CreateEvent(enEventType eventType, ClsEvent Event)
        {
            switch (eventType) 
            {
                case enEventType.Sport:
                    {
                        return new clsSportEvent(Event);
                    }
                case enEventType.Concerts:
                    {
                        return new clsConcertEvent(Event);
                    }                
                case enEventType.Regular:
                    {
                        return new ClsEvent(Event);
                    }
                default:
                    throw new Exception($"There Are No Evenets With Type {eventType}");

            }
        }

        public static ClsEvent FindByEvent_ID(enEventType eventType, int id)
        {
            switch (eventType)
            {
                case enEventType.Sport:
                    {
                        return clsSportEvent.FindbyEvent_ID(id);
                    }
                case enEventType.Concerts:
                    {
                        return clsConcertEvent.FindbyEvent_ID(id);
                    }
                case enEventType.Regular:
                    {
                        return ClsEvent.FindEvent(id);
                    }
                default:
                    throw new Exception($"There Are No Evenets With Type {eventType}");

            }
        }


    }
}
