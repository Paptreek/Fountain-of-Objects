using UnityEngine;
using Assets.Scripts;


public class Room : MonoBehaviour
{
    public Location Location { get; private set; }

    public Room(Location location)
    {
        Location = location;
    }

    public void SetLocation(Location location) => Location = location;
} 
