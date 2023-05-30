using UnityEngine;

public class VRHandController : MonoBehaviour
{
    public Transform handTransform; // Transform tangan VR
    public float moveSpeed = 3f; // Kecepatan gerakan tangan
    public float rotationSpeed = 100f; // Kecepatan rotasi tangan

    private Vector3 moveDirection; // Arah gerakan tangan

    private void Update()
    {
        // Mendapatkan input dari mouse untuk gerakan tangan
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Mendapatkan input dari keyboard untuk rotasi tangan
        float rotationInput = Input.GetAxis("Rotation");

        // Menghitung vektor gerakan berdasarkan input mouse
        moveDirection = new Vector3(mouseX, 0f, mouseY).normalized;

        // Menggerakkan tangan berdasarkan vektor gerakan dan kecepatan
        Vector3 targetPosition = handTransform.position + moveDirection * moveSpeed * Time.deltaTime;
        handTransform.position = targetPosition;

        // Mengrotasi tangan berdasarkan input rotasi dan kecepatan rotasi
        Vector3 rotation = new Vector3(0f, rotationInput * rotationSpeed * Time.deltaTime, 0f);
        handTransform.Rotate(rotation);
    }
}
