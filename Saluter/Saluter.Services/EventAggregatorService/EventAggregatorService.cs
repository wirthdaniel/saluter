using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saluter.Services.EventAggregatorService
{
    public static class EventAggregatorService
    {
        private static Prism.Events.EventAggregator EventAggregatorInstance;

        static EventAggregatorService()
        {
            EventAggregatorInstance = new Prism.Events.EventAggregator();
        }

        public static Prism.Events.EventAggregator GetInstance()
        {
            return EventAggregatorInstance;
        }
    }
}
