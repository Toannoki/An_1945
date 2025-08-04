using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    // Giới hạn góc xoay dọc (pitch) và ngang (yaw)
    public float minPitchAngle = -90f; // Giới hạn nhìn lên
    public float maxPitchAngle = 90f;  // Giới hạn nhìn xuống
    public float minYawAngle = -360f;
    public float maxYawAngle = 360f;

    private float xRotation = 0f; // pitch
    private float yRotation = 0f; // yaw

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 1f) * 100;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY; // Trừ vì trục dọc trong Unity ngược chiều với chuột

        // Giới hạn góc xoay dọc (nhìn lên/xuống)
        xRotation = Mathf.Clamp(xRotation, minPitchAngle, maxPitchAngle);

        // Giới hạn góc xoay ngang nếu cần
        yRotation = Mathf.Clamp(yRotation, minYawAngle, maxYawAngle);

        // Áp dụng xoay: pitch (trục X), yaw (trục Y)
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
