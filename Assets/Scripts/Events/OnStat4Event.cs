using Events.Base;

namespace Events
{
    public class OnStat4Event : BaseEvent
    {
        public BigStatEvent BigStat;
        public int Stat;

        public OnStat4Event(BigStatEvent stat1, int stat2)
        {
            BigStat = stat1;
            Stat = stat2;
        }
    }
}