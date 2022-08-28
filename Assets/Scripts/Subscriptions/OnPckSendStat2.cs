using core.Networking.Generated;
using NetworkingRealTime.BusinessLogic;
using NetworkingRealTime.Subscriptions.Core;

namespace NetworkingRealTime.Subscriptions
{
    public class OnPckSendStat2 : SubscriptionHandle<PckSendStat2>
    {
        public OnPckSendStat2(Account account) : base(account)
        {
        }

        protected override void Process(PckSendStat2 message)
        {
            Account.Room?.OnStat2(message);
        }
    }
}