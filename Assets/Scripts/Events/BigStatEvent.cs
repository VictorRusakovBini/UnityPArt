using Events.Base;

namespace Events
{
    public class BigStatEvent
    {
        public int Stat1;
        public float Stat2;
        public string Stat3;

        public BigStatEvent(int stat1, float stat2, string stat3)
        {
            Stat1 = stat1;
            Stat2 = stat2;
            Stat3 = stat3;
        }
    }
}