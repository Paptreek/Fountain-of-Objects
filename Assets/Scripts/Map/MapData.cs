using Assets.Scripts.Enums;

namespace Assets.Scripts.Map
{
    public class MapData
    {
        private RoomData[,] _rooms;

        public int Height { get; }
        public int Width { get; }
        public Location PlayerSpawn { get; private set; }
        public Location ObjectiveSpawn { get; private set; }
        public Location EntranceSpawn { get; private set; }
        public RoomData CenterRoom { get; private set; }
        public MapSize Size { get; }

        public MapData(MapSize size)
        {
            int dimensions = size switch
            {
                MapSize.Small => 5,
                MapSize.Medium => 7,
                MapSize.Large => 9,
                _ => 5
            };

            Height = dimensions;
            Width = dimensions;
            Size = size;
            _rooms = new RoomData[Height, Width];

            InitializeEmptyRooms();

            CenterRoom = _rooms[Height / 2, Width / 2];
            
            SetEntranceSpawn();
            SetPlayerSpawn();
            SetObjectiveSpawn();
        }

        private void InitializeEmptyRooms()
        {
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    _rooms[x, y] = new RoomData(new Location(x, y));
                }
            }
        }

        public RoomData GetRoomAt(Location location) => _rooms[location.X, location.Y];

        private void SetObjectiveSpawn()
        {
            Location spawn = new(Height - 1, Width - 1);
            ObjectiveSpawn = spawn;
        }
        private void SetPlayerSpawn()
        {
            Location spawn = new(0, 0);
            PlayerSpawn = spawn;
        }

        private void SetEntranceSpawn()
        {
            Location spawn = new(0, 0);
            EntranceSpawn = spawn;

        }
    }
}
