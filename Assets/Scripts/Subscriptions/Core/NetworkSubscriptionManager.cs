using System;
using System.Collections.Generic;
using System.Linq;
using core.Networking;
using NetworkingRealTime.BusinessLogic;

namespace NetworkingRealTime.Subscriptions.Core
{
    public class NetworkSubscriptionManager
    {
        private static readonly List<Type> Types; 
        
        static NetworkSubscriptionManager()
        {
            var type = typeof(SubscriptionHandle<>);
            Types = type.Assembly.GetTypes()
                .Where(t => t.BaseType?.Name == type.Name).ToList();
        }

        public static void Subscribe(Account account)
        {
            foreach (var type in Types)
            {
                var a = (ISubscriptionHandleProxy)Activator.CreateInstance(type, account);
                account.Client.RegisterSubscriptionHandler(a);
            }
        }
    }
}