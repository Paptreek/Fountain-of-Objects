using UnityEngine;

namespace Assets.Scripts.Map
{
    public class RoomPresenter : MonoBehaviour
    {
        private SpriteRenderer _sprite;
        public RoomData Data { get; private set; }

        void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void Initialize(RoomData data)
        {
            Data = data;
        }
    }
}