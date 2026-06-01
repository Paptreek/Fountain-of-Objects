using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private GameObject _mapCamera;

    private void Start()
    {
        _mapCamera.SetActive(false);
    }

    public void ToggleCamera()
    {
        _playerCamera.SetActive(!_playerCamera.activeSelf);
        _mapCamera.SetActive(!_mapCamera.activeSelf);
    }
}
