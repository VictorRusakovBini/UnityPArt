using Events.Base;

namespace Events
{
    public class OnStat3Event : BaseEvent
    {
        public BigStatEvent BigStat;

        public OnStat3Event(BigStatEvent bigStat)
        {
            BigStat = bigStat;
        }
    }
}