using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script will allow you to rotate the camera by moving the mouse (source: ChatGPT 4.0).
 
*/

public class CameraController : MonoBehaviour
{
    public Transform player; // Player's Transform to follow
    public float mouseSensitivity = 100f; // Mouse sensitivity
    private float xRotation = 0f; // Rotation around the x-axis


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp vertical rotation

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

    }
}
