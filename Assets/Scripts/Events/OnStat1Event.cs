using Events.Base;

namespace Events
{
    public class OnStat1Event : BaseEvent
    {
        public string Stat;

        public OnStat1Event(string stat)
        {
            Stat = stat;
        }
    }
}