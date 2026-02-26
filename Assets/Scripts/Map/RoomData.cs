using UnityEngine;
using Assets.Scripts.Enums;

namespace Assets.Scripts.Map
{
    public class RoomData
    {
        public Location Location { get; private set; }
        public RoomType RoomType { get; private set; }

        public GameObject RoomObject { get; set; }

        public RoomData(Location location)
        {
            Location = location;
            RoomType = RoomType.Empty;
            Debug.Log($"Room Created: (Location: {Location}; Room Type: {RoomType})");
        }

        public void SetLocation(Location location) => Location = location;
        public void SetRoomType(RoomType roomType) => RoomType = roomType;
    }
}
