using Assets.Scripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2 _playerStartingPosition = new(0, 0);

    //What is this Game Object's purpose? 
    private GameObject _playerObj;
    private int _mapHeight;
    private int _mapWidth;
    private int _squareSize => _mapSize switch
    {
        MapSize.Small => 5,
        MapSize.Medium => 7,
        MapSize.Large => 9
    };

    [SerializeField] private MapSize _mapSize;
    [SerializeField] private GameObject _roomPrefab;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _roomsManager;
    [SerializeField] private Camera _camera;
    [SerializeField] private Room[,] _rooms;

    // This should likely default to 2. -MATT
    // I would argue that the type should be changed to an int and min clamped at 1. -MATT 
    [SerializeField] private float _roomSpacing = 2;

    public Player Player => _playerObj.GetComponent<Player>();
    public MapSize MapSize => _mapSize;
    public float RoomSpacing { get; }
    public Vector2 PlayerStartingPosition { get; }
    public int GridSize => _squareSize;


    void Start()
    {
        _mapHeight = _squareSize;
        _mapWidth = _squareSize;

        //Clamp room spacing so we cannot have insane boards
        // Should this even go above 2?
        _roomSpacing = Mathf.Clamp(_roomSpacing, 1, 2);

        _playerObj = Instantiate(_playerPrefab, _playerStartingPosition, Quaternion.identity);
        _rooms = new Room[_mapHeight, _mapWidth];
        Debug.Log("Board is building");
        BuildRooms();
        SpawnPlayer();

        int centerX = _mapWidth / 2;
        int centerY = _mapHeight / 2;
        _camera.SetFocus(_rooms[centerX, centerY].gameObject);
    }
    public void BuildRooms()
    {
        for (int i = 0; i < _mapWidth; i++)
        {
            for (int j = 0; j < _mapHeight; j++)
            {
                Vector2 position = new(i * _roomSpacing, j * _roomSpacing);
                GameObject roomObj = Instantiate(_roomPrefab, position, Quaternion.identity, _roomsManager.transform);
                Room room = roomObj.GetComponent<Room>();
                room.SetLocation(new Location(i, j, _roomSpacing));
                _rooms[i, j] = room;
                Debug.Log($"New room placed at ({room.Location.GridX}, {room.Location.GridY})");
            }
        }
    }

    public void SpawnPlayer()
    {
        Location startLocation = new(_playerStartingPosition.x, _playerStartingPosition.y, _roomSpacing);
        Player.SetLocation(startLocation);
    }

    public void MovePlayer(Vector2 position)
    {
        Location newLocation = new(position.x, position.y, _roomSpacing);
        Player.SetLocation(newLocation);
    }

    public Location ReturnRoomLocation(Vector2 targetRoom)
    {
        return _rooms[(int)targetRoom.x, (int)targetRoom.y].Location;
    }
}

