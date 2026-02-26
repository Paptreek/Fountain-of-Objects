using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public Location Location { get; private set; }

        void Start()
        {
            Debug.Log("Debug Log: Player has joined the game.");
        }

        public void SetLocation(Location location) => Location = location;
    }
}
