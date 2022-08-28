namespace NetworkingRealTime.Subscriptions.Core
{
    public interface ISubscriptionHandleProxy 
    {
        void Subscribe();
        void Unsubscribe();
    }
}