using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Serialization_lab6
{
    [Serializable]
    internal class Event
    {
        //Attribute for the class Event
        public int eventNumeber { get; set; }
        public string location { get; set; }
        
        //Constructor
        public Event()
        {

        }
        //Constructor
        public Event(int eventNumber, string location)
        {
            this.eventNumeber = eventNumber;
            this.location = location;
        }
  
    }
}
