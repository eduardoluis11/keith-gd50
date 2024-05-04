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

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
