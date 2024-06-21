using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script for handling the non-Cinemachine camera.

Source of most of the code in this script: this file from a Brackey's tutorial:
https://github.com/Brackeys/RPG-Tutorial/blob/master/Finished%20Project/Assets/Scripts/Controllers/CameraController.cs
*/

public class CameraController : MonoBehaviour {

	public Transform target;

	public Vector3 offset;

	public float zoomSpeed = 4f;

	// public float smoothSpeed = 2f;

	public float currentZoom = 10f;

    public float pitch = 2f;
	public float maxZoom = 3f;
	public float minZoom = .3f;
	public float yawSpeed = 100f;

	public float currentYaw = 0f;
	// public float yawSpeed = 70;
	// public float zoomSensitivity = .7f;
	// float dst;

	// float zoomSmoothV;
	// float targetZoom;

	// void Start() {
	// 	dst = offset.magnitude;
	// 	transform.LookAt (target);
	// 	targetZoom = currentZoom;
	// }

	void Update ()
	{
		// float scroll = Input.GetAxisRaw("Mouse ScrollWheel") * zoomSensitivity;
		currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

		// if (scroll != 0f)
		// {
		// 	targetZoom = Mathf.Clamp(targetZoom - scroll, minZoom, maxZoom);
		// }
		// currentZoom = Mathf.SmoothDamp (currentZoom, targetZoom, ref zoomSmoothV, .15f);
		currentZoom = Mathf.Clamp (currentZoom, minZoom, maxZoom);

		currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
	}

	void LateUpdate () {

        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

		// transform.position = target.position - transform.forward * dst * currentZoom;
		// transform.LookAt(target.position);

		// float currentYaw = Input.GetAxisRaw ("Horizontal");
		// transform.RotateAround (target.position, Vector3.up, -currentYaw * yawSpeed * Time.deltaTime);
		transform.RotateAround(target.position, Vector3.up, currentYaw);
	}

}




// /* This script will allow you to rotate the camera by moving the mouse (source: ChatGPT 4.0).
 
// */

// public class CameraController : MonoBehaviour
// {
//     public Transform player; // Player's Transform to follow
//     public float mouseSensitivity = 100f; // Mouse sensitivity
//     private float xRotation = 0f; // Rotation around the x-axis


//     // Start is called before the first frame update
//     void Start()
//     {
//         Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
//         float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

//         xRotation -= mouseY;
//         xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp vertical rotation

//         transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
//         player.Rotate(Vector3.up * mouseX);

//     }
// }
