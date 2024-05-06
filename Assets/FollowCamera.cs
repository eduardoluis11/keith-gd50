using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script that makes the Camera follow the player in a 3rd-person perspective (source: ChatGPT 4.0). 

Target: Drag your player character from the Hierarchy into the Target field of the camera script component. 
This tells the camera which object to follow.

Offset: Adjust the offset to change where the camera is positioned relative to the player.

Smooth Speed: Adjust this value to make the camera movement faster or slower.
*/

public class FollowCamera : MonoBehaviour
{
    
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 0.125f;
    private Vector3 velocity = Vector3.zero;

// This makes the camera has less lag and be more smooth, but the camera angle is horrible (source: Copilot).
//    IEnumerator SmoothMove(Vector3 targetPosition, float duration)
//{
//    float time = 0;
//    Vector3 startPosition = transform.position;
//
//    while (time < duration)
//    {
//        transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
//        time += Time.deltaTime;
//        yield return null; // Wait for the next frame
//    }
//    transform.position = targetPosition;
//}
//
//void LateUpdate()
//{
//    // This will make it so that the camera is always behind the player
//    Vector3 desiredPosition = target.position + offset;
//
//
//
//    StartCoroutine(SmoothMove(desiredPosition, smoothSpeed));
//    transform.LookAt(target);
//}

    // This makes the camera to always follow the player from behind.
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        // Original code for making the camera follow the player in 3rd-person perspective (source: ChatGPT 4.0).
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        // Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;

        // Code for trying to remove the camera shaking effect, but with a weird bug that makes the camera
        // not follow the player all that well.
        //        Vector3 velocity = Vector3.zero;
        //        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

        // This makes the Camera Follow the Player
        transform.LookAt(target);
    }

     // Start is called before the first frame update
     void Start()
     {
        
     }

     // Update is called once per frame
     void Update()
     {
        
     }
}
