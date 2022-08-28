using System;
using Events;

namespace NetworkingRealTime.BusinessLogic
{
    public class RoomActions
    {
        private readonly RealtimeController _manager;
        
        
        public RoomActions(RealtimeController manager)
        {
            _manager = manager;
        }

        public void LogStat1(OnStat1Event e)
        {
            _manager.Stat?.Invoke($"stat1 {e.Stat}");
        }
        
        public void LogStat2(OnStat2Event e)
        {
            _manager.Stat?.Invoke($"stat2 {e.Stat}");

        }
        
        public void LogStat3(OnStat3Event e)
        {
            _manager.Stat?.Invoke($"big stat {e.BigStat.Stat1}, {e.BigStat.Stat2}, {e.BigStat.Stat3}");

        }
        
        public void LogStat4(OnStat4Event e)
        {
            _manager.Stat?.Invoke($"big stat {e.BigStat.Stat1}, {e.BigStat.Stat2}, {e.BigStat.Stat3}, small stat {e.Stat}");
        }

    }
}