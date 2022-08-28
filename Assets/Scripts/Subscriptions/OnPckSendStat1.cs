using core.Networking.Generated;
using NetworkingRealTime.BusinessLogic;
using NetworkingRealTime.Subscriptions.Core;

namespace NetworkingRealTime.Subscriptions
{
    public class OnPckSendStat1: SubscriptionHandle<PckSendStat1>
    {
        public OnPckSendStat1(Account account) : base(account)
        {
        }

        protected override void Process(PckSendStat1 message)
        {
            Account.Room?.OnStat1(message);
        }
    }
}