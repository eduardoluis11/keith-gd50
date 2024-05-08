using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This file will let the Player (Fang) move, run, and jump (source: ChatGPT 4.0).

You can move around using the arrow keys or WASD keys.

I also added the ability for the player to rotate if the turn around / walk backwards (source: ChatGPT 4.0).

*/

public class PlayerMovement : MonoBehaviour
{

	public float speed = 5f;

    public float rotationSpeed = 720.0f; // Degrees per second. This will help me rotate to turn around.
	public float jumpForce = 300f;  // This will allow me to jump.
	private Rigidbody rb;

    // This will help me rotate to turn around (source: PlayerMovementInputController.cs file from Cinemachine tutorial).
    public Vector2 _look;
    public float rotationPower = 3f;
    public GameObject followTransform;
    // End of the variables for rotating the player based on region (source: PlayerMovementInputController.cs file from Cinemachine tutorial).



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Another form of rotating the player, which is based by region (source: PlayerMovementInputController.cs file from Cinemachine tutorial).
        #region Player Based Rotation
        
        //Move the player based on the X input on the controller
        transform.rotation *= Quaternion.AngleAxis(_look.x * rotationPower, Vector3.up);

        #endregion

        #region Vertical Rotation
        followTransform.transform.rotation *= Quaternion.AngleAxis(_look.y * rotationPower, Vector3.right);

        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;

        var angle = followTransform.transform.localEulerAngles.x;

        //Clamp the Up/Down rotation
        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if(angle < 180 && angle > 40)
        {
            angles.x = 40;
        }


        followTransform.transform.localEulerAngles = angles;
        #endregion
        // End of the code for rotating the player based on region (source: PlayerMovementInputController.cs file from Cinemachine tutorial).

        float moveHorizontal = Input.GetAxis("Horizontal");
    	float moveVertical = Input.GetAxis("Vertical");

        // Create movement vector
    	Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);




        //    // Check if movement vector is significant to avoid rotating when player is nearly stationary
        //    if (movement.magnitude > 0.1f)
        //    {

        //        //            // This lets the player rotate, but without causing the camera to shake (source: Copilot).
        //        //            movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * movement;

        //        // Create a rotation that looks along the forward vector
        //        Quaternion newRotation = Quaternion.LookRotation(movement);
        //        // Smoothly rotate towards the new rotation
        //        rb.rotation = Quaternion.RotateTowards(rb.rotation, newRotation, rotationSpeed * Time.deltaTime);
        //    }

        // Move the player. This makes the player move and rotate.
        // BUG: now the player moves way too slowly.
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);

        // // This is the old way to move the player. It moves the player quickly, but the player only moves forwards, but never backwards.
    	// transform.Translate(movement * speed * Time.deltaTime);  

        //Set the player rotation based on the look transform (source: PlayerMovementInputController.cs file from Cinemachine tutorial)
        transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);

        //reset the y rotation of the look transform (source: PlayerMovementInputController.cs file from Cinemachine tutorial)
        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);

        // This lets the Player jump while pressing the space bar.
        // BUG: The player can't jump yet.
    	if (Input.GetKeyDown(KeyCode.Space)) // Jumping
    	{
        	rb.AddForce(new Vector3(0, jumpForce, 0));
    	}
    }
}
