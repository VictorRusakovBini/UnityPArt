using Events.Base;

namespace Events
{
    public class OnStat2Event : BaseEvent
    {
        public int Stat;

        public OnStat2Event(int stat)
        {
            Stat = stat;
        }
    }
}