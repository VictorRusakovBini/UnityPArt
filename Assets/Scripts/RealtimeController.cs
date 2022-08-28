using System;
using System.Net.Sockets;
using core.Networking.Generated;
using Google.Protobuf;
using NetworkingRealTime.BusinessLogic;
using NetworkingRealTime.Subscriptions.Core;
using UnityEngine;

namespace NetworkingRealTime
{
    public class RealtimeController : MonoBehaviour
    {
        [SerializeField]
        private float reconnectAttemptTime;

        public RoomActions RoomActions { get; private set; }
        
        public Room Room => _account?.Room;
        
        private readonly RoomProvider _roomProvider = new RoomProvider();
        private Account _account;
        private bool _roomJoined;
        private string _roomId;
        
        public int UserId { get; private set; }

        private float _nextReconnect;
        
        private string _rtServer;
        private int _rtPort;
        
        public Action<string> Stat;
        
        public void Initialize(string rtServer, int rtPort)
        {
            _rtServer = rtServer;
            _rtPort = rtPort;
        }
        
        public void JoinRoom(string roomId, int userId)
        {
            Debug.Log($"attempt connect to {_rtServer}:{_rtPort}");
            
            _roomId = roomId;
            UserId = userId;
            try
            {
                var tcp = new NetworkClient(new TcpClient(_rtServer, _rtPort));
                tcp.Start();
                _account = new Account(UserId, tcp, this);
                NetworkSubscriptionManager.Subscribe(_account);
                tcp.OnConnectionBroken += OnDisconnect;
                _account.SetRoom(_roomProvider.GetRoom(_roomId));
                RoomActions = new RoomActions(this);
                _account.Client.Send(new PckConnect
                {
                    UserId = userId,
                    RoomId = roomId
                });
            }
            catch
            {
                OnDisconnect();
            }
            
            _roomJoined = true;
        }

        public void LeftRoom()
        {
            _roomJoined = false;
            _account?.Client.Disconnect(false);
            _account = null;
        }

        private void Update()
        {
            if (_roomJoined && (_account == null || !_account.Client.Active) && Time.time > _nextReconnect)
            {
                JoinRoom(_roomId, UserId);
                return;
            }
        }
        
        private void OnDisconnect()
        {
            if (_roomJoined)
            {
                _nextReconnect = Time.time + reconnectAttemptTime;
            }
        }

        private void OnDestroy()
        {
            _account?.Client?.Disconnect(false);
        }

        public void Send(IMessage message)
        {
            _account?.Client?.Send(message);
        }
    }
}