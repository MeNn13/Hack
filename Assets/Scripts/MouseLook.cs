using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float sensitivity = 100f;

    [Header("Unity Setup Reference")]
    [SerializeField] private Transform player;

    private float _xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation , -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
