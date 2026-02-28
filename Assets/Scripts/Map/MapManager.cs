using UnityEngine;

namespace Assets.Scripts.Map
{
    public class MapManager : MonoBehaviour
    {
        private readonly float _roomSpacing = 1.1f;

        [SerializeField] private GameObject _roomPrefab;


        public void InstantiateRooms(MapData map)
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