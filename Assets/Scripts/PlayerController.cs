using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform orientation;
    private Rigidbody rb;
    private Vector3 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveZ = Input.GetAxisRaw("Vertical");

            Vector3 forward = Vector3.ProjectOnPlane(orientation.forward, Vector3.up).normalized;
            Vector3 right = Vector3.ProjectOnPlane(orientation.right, Vector3.up).normalized;

            movement = (forward * moveZ + right * moveX).normalized;
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
