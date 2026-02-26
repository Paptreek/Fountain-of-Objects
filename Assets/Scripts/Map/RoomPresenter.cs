using UnityEngine;

namespace Assets.Scripts.Map
{
    public class RoomPresenter : MonoBehaviour
    {
        public RoomData Data { get; private set; }


        public void Initialize(RoomData data)
        {
            Data = data;
        }
    }
}