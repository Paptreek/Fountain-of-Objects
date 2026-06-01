using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private InputAction _moveAction;
    private InputAction _mapAction;
    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private GameObject _mapCamera;
    private GameObject _currentCamera;

    public void Awake()
    {
        _currentCamera = _playerCamera;
    }

    public void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _mapAction = InputSystem.actions.FindAction("OpenMap");
    }

    public void Update()
    {
        if (_moveAction != null && _moveAction.WasPressedThisFrame())
        {
            Vector2 moveValue = _moveAction.ReadValue<Vector2>();

            if (moveValue.x == 1)
            {
                transform.position = new Vector2(transform.position.x + 2, transform.position.y);
            }
            else if (moveValue.x == -1)
            {
                transform.position = new Vector2(transform.position.x - 2, transform.position.y);
            }
            else if (moveValue.y == 1)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 2);
            }
            else if (moveValue.y == -1)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 2);
            }
        }

        if (_mapAction.WasPressedThisFrame())
        {
            _currentCamera.SetActive(false);
            _currentCamera = _currentCamera == _playerCamera ? _mapCamera : _playerCamera;
            _currentCamera.SetActive(true);
            Debug.Log("Camera Swapped");
        }
    }
}
