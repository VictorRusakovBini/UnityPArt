namespace NetworkingRealTime.BusinessLogic
{
    public class Account
    {
        public NetworkClient Client { get; }
        public RealtimeController Manager { get; }
        public Room Room { get; private set; }
        public int UserId { get; }

        public Account(int userId, NetworkClient client, RealtimeController manager)
        {
            UserId = userId;
            Client = client;
            Manager = manager;
        }

        public void SetRoom(Room room)
        {
            Room = room;
        }
    }
}