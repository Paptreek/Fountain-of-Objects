using Assets.Scripts.Enums;
using Assets.Scripts.Map;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private GameObject _playerObj;
        private MapData _map;

        [SerializeField] private MapManager _mapManager;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Camera _camera;
        [SerializeField] private MapSize _mapSize;
        public Player Player { get; private set; }

        void Start()
        {
            // Create a map with the desired size
            _map = _mapManager.GenerateMap(_mapSize);

            Vector2 playerSpawnPosition = new Vector2(_map.PlayerSpawn.X, _map.PlayerSpawn.Y);
            _playerObj = Instantiate(_playerPrefab, playerSpawnPosition, Quaternion.identity);
            Player = _playerObj.GetComponent<Player>();

            GameObject centerRoomObj = _map.CenterRoom.RoomObject;
            _camera.SetFocus(centerRoomObj);
        }
    }
}

