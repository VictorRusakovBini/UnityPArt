using core.Networking;
using Google.Protobuf;
using NetworkingRealTime.BusinessLogic;

namespace NetworkingRealTime.Subscriptions.Core
{
    public abstract class SubscriptionHandle<T> : ISubscriptionHandleProxy where T : IMessage
    {
        protected Account Account { get; }

        protected void Send(IMessage message)
        {
            Account.Client.Send(message);
        }

        protected SubscriptionHandle(Account account)
        {
            Account = account;
        }

        public void Subscribe()
        {
            Account.Client.RegisterListener<T>(Handle);
        }

        public void Unsubscribe()
        {
            Account.Client.RemoveListener<T>(Handle);
        }

        private void Handle(IMessage message)
        {
            Process((T)message);
        }

        protected abstract void Process(T message);
    }
}