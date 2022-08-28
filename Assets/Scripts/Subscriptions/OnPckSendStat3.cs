using core.Networking.Generated;
using NetworkingRealTime.BusinessLogic;
using NetworkingRealTime.Subscriptions.Core;

namespace NetworkingRealTime.Subscriptions
{
    public class OnPckSendStat3 : SubscriptionHandle<PckSendStat3>
    {
        public OnPckSendStat3(Account account) : base(account)
        {
        }

        protected override void Process(PckSendStat3 message)
        {
            Account.Room?.OnStat3(message);
        }
    }
}