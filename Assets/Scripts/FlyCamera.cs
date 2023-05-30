using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float zoomSpeed = 5.0f;
    public float moveSpeed = 10.0f;
    public float gravity = 9.81f;

    private Transform cameraTransform;
    private CharacterController characterController;
    private float verticalVelocity = 0.0f;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Rotasi Kamera
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.Rotate(Vector3.up, mouseX, Space.World);
        cameraTransform.Rotate(Vector3.left, mouseY, Space.Self);

        // Zoom Kamera
        float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        cameraTransform.Translate(Vector3.forward * scroll, Space.Self);

        // Pergerakan Kamera
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        float vertical = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 moveDirection = (transform.right * horizontal) + (transform.forward * vertical);
        characterController.Move(moveDirection * Time.deltaTime);

        // Gravitasi
        if (!characterController.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        else
        {
            verticalVelocity = -0.5f;
        }

        Vector3 gravityVector = new Vector3(0, verticalVelocity, 0);
        characterController.Move(gravityVector * Time.deltaTime);
    }
}