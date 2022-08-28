using System.Collections.Generic;

namespace NetworkingRealTime.BusinessLogic
{
    public class RoomProvider
    {
        private readonly Dictionary<string, Room> _rooms = new Dictionary<string, Room>();

        public Room GetRoom(string roomId)
        {
            if (!_rooms.ContainsKey(roomId))
            {
                _rooms.Add(roomId, new Room());
            }

            return _rooms[roomId];
        }
    }
}