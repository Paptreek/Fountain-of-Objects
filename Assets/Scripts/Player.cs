using UnityEngine;
using Assets.Scripts;

public class Player : MonoBehaviour
{ 
    public Location Location { get; private set; }
    
    void Start()
    {
        Debug.Log("Debug Log: Player has joined the game.");
        Debug.Log($"The player's starting location is ({Location.X}, {Location.Y})");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLocation(Location location) => Location = location;
}
