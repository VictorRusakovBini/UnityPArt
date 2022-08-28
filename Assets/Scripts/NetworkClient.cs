using System;
using System.Net.Sockets;
using Google.Protobuf;
using UnityEngine;

namespace NetworkingRealTime
{
    public class NetworkClient : NetworkClientBase
    {
        private PacketsHandler _packetsHandler;
        private readonly TcpClient _tcpClient;

        public NetworkClient(TcpClient clt)
        {
            _tcpClient = clt;
            _tcpClient.NoDelay = true;
            Active = true;
        }

        private void OnMessage(IMessage message)
        {
            lock (Listeners)
            {
                try
                {
                    var T =  message.GetType();
                    if (Listeners.ContainsKey(T))
                    {
                        ProcessActionsList(message, Listeners[T]);
                    }
                }
                catch (Exception e)
                {
                   Debug.LogException(e);
                }
            }
        }

        public void OnDisconnect(bool fireCallback)
        {
            if (Active)
            {
                Active = false;
                Debug.LogWarning($"disconnect");
                if(fireCallback) InvokeOnConnectionBroken();
            }
        }

        public virtual void Start()
        {
            _packetsHandler = new PacketsHandler(this, _tcpClient.GetStream(), OnDisconnect, OnMessage );
        }

        public override void Send(IMessage message)
        {
            if (!Active || message == null) return;

            _packetsHandler.Send(message);
        }

        public override void Send(byte[] message, Type messageType = null)
        {
            if (!Active && message == null) return;

            _packetsHandler.Send(message);
        }

       

        public override void Disconnect(bool fireCallback)
        {
            OnDisconnect(fireCallback);
            _tcpClient.Close();

            base.Disconnect(fireCallback);
        }
    }
}
