using Assets.Scripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _mapHeight;
    private int _mapWidth;
    private int _squareSize => _mapSize switch
    {
        MapSize.Small => 5,
        MapSize.Medium => 7,
        MapSize.Large => 9,
        _ => 5
    };

    [SerializeField] private MapSize _mapSize;
    [SerializeField] private GameObject _roomPrefab;
    [SerializeField] private GameObject _player;
    [SerializeField] private Room[,] _rooms;
    [SerializeField] private Camera _mapCamera;
    [SerializeField] private float _roomSpacing = 2;

    void Start()
    {
        _mapHeight = _squareSize;
        _mapWidth = _squareSize;
        
        _roomSpacing = Mathf.Clamp(_roomSpacing, 1, 2);
        _rooms = new Room[_mapHeight, _mapWidth];

        Debug.Log("Board is building");
        BuildRooms();

        int centerX = _mapWidth / 2;
        int centerY = _mapHeight / 2;

        _mapCamera.orthographicSize = _squareSize;
        Vector3 centerRoom = _rooms[centerX, centerY].transform.position;
        _mapCamera.transform.position = new Vector3(centerRoom.x, centerRoom.y, -10);
    }
    private void BuildRooms()
    {
        for (int i = 0; i < _mapWidth; i++)
        {
            for (int j = 0; j < _mapHeight; j++)
            {
                Vector2 position = new(i * _roomSpacing, j * _roomSpacing);
                GameObject roomObj = Instantiate(_roomPrefab, position, Quaternion.identity);
                Room room = roomObj.GetComponent<Room>();
                room.SetLocation(new Location(i, j, _roomSpacing));
                _rooms[i, j] = room;
                Debug.Log($"New room placed at ({room.Location.GridX}, {room.Location.GridY})");
            }
        }
    }
}

