using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private Vector2 _playerStartingPosition = new Vector2(0, 0);

    public GameObject RoomPrefab;
    public GameObject PlayerPrefab;
    public GameObject RoomsManager;
    public Camera Camera;
    public Room[,] Rooms;
    public int RoomsHeight;
    public int RoomsWidth;
    public float Spacing;


    void Start()
    {
        _player = Instantiate(PlayerPrefab, _playerStartingPosition, Quaternion.identity);
        Camera.SetFocus(_player);
        Debug.Log("Board is building");
        Rooms = new Room[RoomsHeight, RoomsWidth];
        BuildRooms();
    }
    public void BuildRooms()
    {

        for (float i = 0; i < RoomsWidth; i++)
        {
            for (float j = 0; j < RoomsHeight; j++)
            {
                Vector2 position = new(i * Spacing, j * Spacing);
                GameObject room = Instantiate(RoomPrefab, position, Quaternion.identity, RoomsManager.transform);
                Debug.Log($"New room placed at ({position})");
            }
        }
    }
}

