using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Controller for the non-Cinemachine camera (source of most of this code: This tutorial from Brackeys: 
https://youtu.be/S2mK6KFdv0I?si=w7VLbjjdatl6M92g .)

*/

public class CameraControllerBrackeys : MonoBehaviour
{

    public Transform target; // The target that the camera will follow

    public Vector3 offset; // The offset of the camera from the target


    public float zoomSpeed = 4f; // The speed at which the camera will zoom
    public float minZoom = 5f; // The minimum zoom of the camera
    public float maxZoom = 15f; // The maximum zoom of the camera

    public float pitch = 2f; // The pitch of the camera

    private float currentZoom = 10f; // The current zoom of the camera

    public float yawSpeed = 100f; // The speed at which the camera will rotate

    private float currentYaw = 0f; // The input for the yaw of the camera

    void Update () {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed; // Get the input from the mouse scroll wheel
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom); // Clamp the current zoom between the minimum and maximum zoom values 

        // This will let me rotate the camera to the left and right by pressing the left and right arrow / A and D keys
        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime; // Get the input for the yaw of the camera
    }

    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom; // Set the position of the camera to the target position minus the offset times the current zoom
        transform.LookAt(target.position + Vector3.up * pitch); // Look at the target

        transform.RotateAround(target.position, Vector3.up, currentYaw); // Rotate around the target
    }
}
