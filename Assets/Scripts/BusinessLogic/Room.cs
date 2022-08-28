using System.Collections.Generic;
using core.Networking.Generated;
using Events;
using UnityEngine;

namespace NetworkingRealTime.BusinessLogic
{
    public class Room
    {
        public void OnConnect(PckConnectResult result)
        {
            Debug.Log(result.Result.ToString());
#if !UNITY_EDITOR
            Model.Instance.RealtimeController.Stat?.Invoke(result.Result.ToString());
#endif
        }
        
        public void OnStat1(PckSendStat1 stat1)
        {
            new OnStat1Event(stat1.Stat).Dispatch();
        }

        public void OnStat2(PckSendStat2 stat2)
        {
            new OnStat2Event(stat2.Stat).Dispatch();
        }

        public void OnStat3(PckSendStat3 stat3)
        {
            var q = new BigStatEvent(stat3.Stat.Stat1, stat3.Stat.Stat2, stat3.Stat.Stat3);
            new OnStat3Event(q).Dispatch();
        }

        public void OnStat4(PckSendStat4 stat4)
        {
            var q = new BigStatEvent(stat4.Stat1.Stat1, stat4.Stat1.Stat2, stat4.Stat1.Stat3);
            new OnStat4Event(q, stat4.Stat2).Dispatch();
        }
    }
}