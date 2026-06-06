using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Input actions
    private InputAction _moveAction;
    private InputAction _mapAction;

    [Header ("Camera Manager")]
    [SerializeField] private CameraManager _cameraManager;

    [Header ("Smooth Movement")]
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _scaleMultiplier;
    private bool _isMoving = false;
    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private float _elaspedTime = 0f;
    private Vector3 _originScale;

    public void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _mapAction = InputSystem.actions.FindAction("OpenMap");
        _originScale = transform.localScale;
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
                _targetPosition = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
            }
            else if (moveValue.x == -1)
            {
                _startPosition = transform.position;
                _targetPosition = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
            }
            else if (moveValue.y == 1)
            {
                _startPosition = transform.position;
                _targetPosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            }
            else if (moveValue.y == -1)
            {
                _startPosition = transform.position;
                _targetPosition = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
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
            float t = _elaspedTime / _moveDuration;
            transform.position = Vector3.Lerp(_startPosition, _targetPosition, t);
            transform.position.Scale(transform.localScale * t);

            //scalePulse multiplies t by Pi inside a sine function. 
            //This maps the duration of t (from 0 to 1) to a half-circle, causing the pulse to smoothly go from 0 to 1 and back to 0.
            float scalePulse = Mathf.Sin(t * Mathf.PI);
            transform.localScale = _originScale * (1f + scalePulse * _scaleMultiplier);
        }
        else
        {
            transform.position = _targetPosition;
            transform.localScale = _originScale;
            _elaspedTime = 0f;
            _isMoving = false;
        }
    }
}
