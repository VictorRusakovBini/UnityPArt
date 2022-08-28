using core.Networking.Generated;
using NetworkingRealTime.BusinessLogic;
using NetworkingRealTime.Subscriptions.Core;

namespace NetworkingRealTime.Subscriptions
{
    public class OnPckConnect : SubscriptionHandle<PckConnectResult>
    {
        public OnPckConnect(Account account) : base(account)
        {
        }

        protected override void Process(PckConnectResult message)
        {
            Account.Room?.OnConnect(message);
        }
    }
}