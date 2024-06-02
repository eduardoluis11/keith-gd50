using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerBrackeys : MonoBehaviour
{

    public Transform target; // The target that the camera will follow

    public Vector3 offset; // The offset of the camera from the target

    public float pitch = 2f; // The pitch of the camera

    private float currentZoom = 10f; // The current zoom of the camera

    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom; // Set the position of the camera to the target position minus the offset times the current zoom
        transform.LookAt(target.position + Vector3.up * pitch); // Look at the target
    }
}
