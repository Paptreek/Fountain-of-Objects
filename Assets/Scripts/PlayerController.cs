using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction _moveAction;

    public void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    public void Update()
    {
        if (_moveAction.WasPressedThisFrame())
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
    }
}
