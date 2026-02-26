using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class MapManager : MonoBehaviour
    {
        private readonly float _roomSpacing = 1.1f;

        [SerializeField] private GameObject _roomPrefab;

        public MapData GenerateMap(MapSize size)
        {
            MapData map = new(size);
            return map;
        }


        /// <summary>
        /// Displays all rooms defined in the specified map by instantiating room prefabs at their corresponding
        /// positions in the scene.
        /// </summary>
        /// <remarks>This method iterates through each coordinate in the map, creates a room GameObject at
        /// the appropriate world position, and initializes its presenter with the associated room data. The
        /// instantiated GameObjects are linked to their corresponding room data for further interaction.</remarks>
        /// <param name="map">The map data containing the dimensions and room information to be displayed. Cannot be null.</param>
        public void DisplayRooms(MapData map)
        {
            for (int i = 0; i < map.Width; i++)
            {
                for (int j = 0; j < map.Height; j++)
                {
                    // Create model coordinate for this Room and get its RoomData
                    Location roomLoc = new(i, j);
                    RoomData roomData = map.GetRoomAt(roomLoc);

                    // Compute world position from grid coordinates and spacing
                    Vector2 position = new(roomLoc.X * _roomSpacing, roomLoc.Y * _roomSpacing);

                    // Instantiate the room prefab at the computed position
                    GameObject roomObj = Instantiate(_roomPrefab, position, transform.rotation);

                    // Attach the instantiated GameObject to the model
                    roomData.RoomObject = roomObj;

                    // Get the scene component and pass the model to it
                    RoomPresenter presenter = roomObj.GetComponent<RoomPresenter>();
                    presenter.Initialize(roomData);
                }
            }
        }
    }
}