using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public void Update()
    {
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            transform.position = new Vector2(transform.position.x + 2, transform.position.y);
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            transform.position = new Vector2(transform.position.x - 2, transform.position.y);
        }
        else if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 2);
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 2);
        }
    }
}
