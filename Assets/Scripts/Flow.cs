using Events;
using Events.Base;

namespace NetworkingRealTime
{
    public class Flow : BaseUnit
    {
        public override void OnEvent(BaseEvent e)
        {
            switch (e)
            {
                case OnStat1Event stat1Event:
                    Model.Instance.RealtimeController.RoomActions.LogStat1(stat1Event);
                    break;
                case OnStat2Event stat2Event:
                    Model.Instance.RealtimeController.RoomActions.LogStat2(stat2Event);
                    break;
                case OnStat3Event stat3Event:
                    Model.Instance.RealtimeController.RoomActions.LogStat3(stat3Event);
                    break;
                case OnStat4Event stat4Event:
                    Model.Instance.RealtimeController.RoomActions.LogStat4(stat4Event);
                    break;
            }
        }
    }
}