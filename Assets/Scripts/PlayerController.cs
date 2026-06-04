using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Input actions
    private InputAction _moveAction;
    private InputAction _mapAction;

    [Header("Camera Manager")]
    [SerializeField] private CameraManager _cameraManager;

    [Header ("Smooth Movement")]
    [SerializeField] private float _moveDuration;
    private bool _isMoving = false;
    private Vector2 _startPosition;
    private Vector2 _targetPosition;
    private float _elaspedTime = 0f;

    public void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _mapAction = InputSystem.actions.FindAction("OpenMap");

    }

    public void Update()
    {
        //Handle Movement
        #region Movement Handling
        if (!_isMoving)
        {
            CheckForMovementInput();
        }
        else
        {
            CalculateSmoothMovement();
        }
        #endregion

        //Handle Map Actions
        CheckForMapInput();
    }

    private void CheckForMovementInput()
    {

        if (_moveAction != null && _moveAction.WasPressedThisFrame())
        {
            Vector2 moveValue = _moveAction.ReadValue<Vector2>();

            //Ensure that we only move forward here when movement is non-zero. 
            if (moveValue == Vector2.zero) return;

            if (moveValue.x == 1)
            {
                _startPosition = transform.position;
                _targetPosition = new Vector2(transform.position.x + 2, transform.position.y);
            }
            else if (moveValue.x == -1)
            {
                _startPosition = transform.position;
                _targetPosition = new Vector2(transform.position.x - 2, transform.position.y);
            }
            else if (moveValue.y == 1)
            {
                _startPosition = transform.position;
                _targetPosition = new Vector2(transform.position.x, transform.position.y + 2);
            }
            else if (moveValue.y == -1)
            {
                _startPosition = transform.position;
                _targetPosition = new Vector2(transform.position.x, transform.position.y - 2);
            }
            _isMoving = true;
        }
    }

    private void CheckForMapInput()
    {
        if (_mapAction != null && _mapAction.WasPressedThisFrame())
        {
            _cameraManager.ToggleCamera();
        }
    }

    private void CalculateSmoothMovement()
    {
        _elaspedTime += Time.deltaTime;

        if (_elaspedTime <= _moveDuration)
        {
            transform.position = Vector2.Lerp(_startPosition, _targetPosition, _elaspedTime / _moveDuration);
        }
        else
        {
            transform.position = _targetPosition;
            _elaspedTime = 0f;
            _isMoving = false;
        }
    }
}
