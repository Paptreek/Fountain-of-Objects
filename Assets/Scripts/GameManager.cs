using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2 _playerStartingPosition = new(0,0);
    private GameObject _playerObj;

    [SerializeField] private GameObject _roomPrefab;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _roomsManager;
    [SerializeField] private Camera _camera;
    [SerializeField] private Room[,] _rooms;
    [SerializeField] private int _roomsHeight;
    [SerializeField] private int _roomsWidth;
    [SerializeField] private float _spacing;

    public Player Player => _playerObj.GetComponent<Player>();

    void Start()
    {
        _playerObj = Instantiate(_playerPrefab, _playerStartingPosition, Quaternion.identity);
        _rooms = new Room[_roomsHeight, _roomsWidth];
        Debug.Log("Board is building");
        BuildRooms();
        SpawnPlayer();
        _camera.SetFocus(_rooms[2, 2].gameObject);
    }
    public void BuildRooms()
    {
        for (int i = 0; i < _roomsWidth; i++)
        {
            for (int j = 0; j < _roomsHeight; j++)
            {
                Vector2 position = new(i * _spacing, j * _spacing);
                GameObject roomObj = Instantiate(_roomPrefab, position, Quaternion.identity, _roomsManager.transform);
                Room room = roomObj.GetComponent<Room>();
                _rooms[i, j] = room;
                Debug.Log($"New room placed at ({position})");
            }
        }
    }

    public void SpawnPlayer()
    {
        Player.Move(_playerStartingPosition.x, _playerStartingPosition.y);
    }
}

