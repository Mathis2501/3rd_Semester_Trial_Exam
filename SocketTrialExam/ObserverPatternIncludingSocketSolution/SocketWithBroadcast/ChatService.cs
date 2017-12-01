using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketWithBroadcast
{
    public class ChatService //this is the subject
    {
        public delegate void BroardCastEventHandler(string msg);
        public event BroardCastEventHandler BroardCastEvent;

        public ChatService(string name)
        {
            this.name = name;
        }

        private string name;

        public string Name
        {
            get { return name; }
        }

        public void BroadCastMessage(string msg)
        {
            if (this.BroardCastEvent != null)
                BroardCastEvent(msg); //fire the event (whatever it was) to all subscribers
        }

    }
}
