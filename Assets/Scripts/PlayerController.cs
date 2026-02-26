using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    //This script handles players inputs using the PlayerControls InputActions Asset.
    public class PlayerController : MonoBehaviour
    {
        //SerializedField property before a private type exposes it to the editor
        [SerializeField] private float _speed = 1.0f;
        [SerializeField] private Vector2 _moveInput;

        private CharacterController _controller;

        // Awake is called before Start. I want the char controller to be assigned before anything can execute code.
        void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
            Debug.Log($"Input: {_moveInput} Context: {context}");
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            //Put things here
            Debug.Log($"Selecting: {context.performed}");
        }

        public void Update()
        {
            //Movement happens here
            Vector2 _move = new Vector2(_moveInput.x, _moveInput.y);
            _controller.Move(_move * _speed * Time.deltaTime);
        }
    }
}