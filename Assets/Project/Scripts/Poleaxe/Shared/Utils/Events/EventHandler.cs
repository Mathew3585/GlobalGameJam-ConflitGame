using System;

namespace Poleaxe.Utils.Events
{
    public delegate void EventHandler();
    public delegate void EventHandler<t>(object sender, EventData<t> data);

    public class EventData<t> : EventArgs
    {
        public EventData(t d) { Data = d; }
        public t Data { get; private set; }
    }
}