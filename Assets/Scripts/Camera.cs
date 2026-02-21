using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject _focusTarget;
    private Vector3 _offsetAmount = new(0, 0, -10);
    void Update()
    {
        transform.position = _focusTarget.transform.position;
    }

    public void SetFocus(GameObject focusTarget)
    {
        _focusTarget = focusTarget;
        transform.position = focusTarget.transform.position - _offsetAmount;
    }
}
