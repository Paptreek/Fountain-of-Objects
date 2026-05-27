using System;
using UnityEngine;
using UnityEngine.InputSystem;

//This script handles players inputs using the PlayerControls InputActions Asset.
public class PlayerController : MonoBehaviour
{
    //SerializedField property before a private type exposes it to the editor
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private bool _allowDiagonalMovement = false;
    private Vector2 _performedMoveInput;
    private Vector2 _releasedMoveInput;
    private GameManager _gameManager;

    //These values represent the player's current grid position rooms.
    private float _currentX;
    private float _currentY;

    private CharacterController _controller;

    // Awake is called before Start. I want the char controller to be assigned before anything can execute code.
    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _gameManager = FindFirstObjectByType<GameManager>();
        _currentX = _gameManager.PlayerStartingPosition.x;
        _currentY = _gameManager.PlayerStartingPosition.y;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _performedMoveInput = context.ReadValue<Vector2>();
            Debug.Log($"Pressed: {_performedMoveInput}");
        }
        if (context.canceled)
        {
            _releasedMoveInput = _performedMoveInput;
            Debug.Log($"Released: {_releasedMoveInput}");
        }
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        //Put things here
        Debug.Log($"Selecting: {context.performed}");
    }

    public void Update()
    {
        //Prepare the Vector2
        Vector2 _move = new Vector2(_releasedMoveInput.x, _releasedMoveInput.y);
        if (_allowDiagonalMovement)
        {
            throw new System.Exception("Diagonal movement is not implemented!");
        }
        else
        {
            if (_move.x != 0 || _move.y != 0)
            {
                HandleNonDiagonalMovement(_gameManager, _move);
                _releasedMoveInput = Vector2.zero;
            }
        }

        //There likely is a better way to tie current room to player movement. 
        //_controller.Move( _move * _speed * _gameManager.RoomSpacing * Time.deltaTime );
    }

    private void HandleNonDiagonalMovement(GameManager gameManager, Vector2 movement)
    {
        if (movement.x == 1)
        {
            if (_currentX < _gameManager.GridSize - 1) _currentX += 1;
        }
        else if (movement.x == -1)
        {
            if (_currentX > 0) _currentX -= 1;
        }
        else if (movement.y == 1)
        {
            if (_currentY < _gameManager.GridSize - 1) _currentY += 1;
        }
        else if (movement.y == -1)
        {
            if (_currentY > 0) _currentY -= 1;
        }


        _gameManager.Player.SetLocation(_gameManager.ReturnRoomLocation(new Vector2(_currentX, _currentY)));
        _gameManager.Player.transform.position = new Vector3(_gameManager.Player.Location.WorldX, _gameManager.Player.Location.WorldY, 0);

        Debug.Log($"PLAYER: X {_currentX}, Y {_currentY}");
        Debug.Log($"GridSize: {_gameManager.GridSize}");

    }
}
