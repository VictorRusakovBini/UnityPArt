using core.Networking.Generated;
using NetworkingRealTime.BusinessLogic;
using NetworkingRealTime.Subscriptions.Core;

namespace NetworkingRealTime.Subscriptions
{
    public class OnPckSendStat4 : SubscriptionHandle<PckSendStat4>
    {
        public OnPckSendStat4(Account account) : base(account)
        {
        }

        protected override void Process(PckSendStat4 message)
        {
            Account.Room?.OnStat4(message);
        }
    }
}