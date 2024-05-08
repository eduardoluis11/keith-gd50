using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I needed to install Input System from the Package Manager in Unity to use this library (source: Copilot from VS Code).
using UnityEngine.InputSystem;


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
    // public float rotationPower = 3f;

    // This will allow the Cinemachine camera to follow the player around. The user will have to put the Empty
    // Game Object that is right behind the Player Object into the Follow Transform slot in the Unity Editor (source:
    // PlayerMovementInputController.cs file).
    public GameObject followTransform;

    // This will help me rotate to turn around (source: PlayerMovementInputController.cs file).
    public Quaternion nextRotation;

    // This will also help me move around. (source: PlayerMovementInputController.cs file).
    public Vector3 nextPosition;

    // This will affect the camera (source: PlayerMovementInputController.cs file).
    public Camera camera;

    // These 2 variables will also help me rotate to turn around (source: PlayerMovementInputController.cs file).
    public float rotationLerp = 0.6f;
    public float rotationPower = 4f;

    // This will modify the _look variable (source: PlayerMovementInputController.cs file).
    
    // I needed to install Input System from the Package Manager to use this "InputValue" (source: Copilot from VS Code).
    public void OnLook(InputValue value)
    {
        _look = value.Get<Vector2>();
    }

    // End of the variables for rotating the player based on region (source: PlayerMovementInputController.cs file.



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
        
        //        // This should only make the player move forward (source: PlayerMovementInputController.cs file).
        //        transform.rotation *= Quaternion.AngleAxis(_look.x * rotationPower, Vector3.up);

        #endregion

        #region Follow Transform Rotation

        // This will rotate the camera by moving the Empty Object behind the Player Object (source:
        // PlayerMovementInputController.cs file).
        followTransform.transform.rotation *= Quaternion.AngleAxis(_look.x * rotationPower, Vector3.up);

        #endregion


        // All of the below snippet of code is from the PlayerMovementInputController.cs file (source: Cinemachine
        // tutorial from Unity).
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

        nextRotation = Quaternion.Lerp(followTransform.transform.rotation, nextRotation, Time.deltaTime * rotationLerp);

        if (_move.x == 0 && _move.y == 0)
        {
            nextPosition = transform.position;

            // if (aimValue == 1)
            // {
            //     //Set the player rotation based on the look transform
            //     transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);
            //     //reset the y rotation of the look transform
            //     followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
            // }

            return;
        }
        float moveSpeed = speed / 100f;
        Vector3 position = (transform.forward * _move.y * moveSpeed) + (transform.right * _move.x * moveSpeed);
        nextPosition = transform.position + position;


        //Set the player rotation based on the look transform
        transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);
        //reset the y rotation of the look transform
        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
        // End of the code for rotating the player based on region (source: PlayerMovementInputController.cs file.

//        float moveHorizontal = Input.GetAxis("Horizontal");
//    	float moveVertical = Input.GetAxis("Vertical");
//
//        // Create movement vector
//    	Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
//
//
//
//
//        //    // Check if movement vector is significant to avoid rotating when player is nearly stationary
//        //    if (movement.magnitude > 0.1f)
//        //    {
//
//        //        //            // This lets the player rotate, but without causing the camera to shake (source: Copilot).
//        //        //            movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * movement;
//
//        //        // Create a rotation that looks along the forward vector
//        //        Quaternion newRotation = Quaternion.LookRotation(movement);
//        //        // Smoothly rotate towards the new rotation
//        //        rb.rotation = Quaternion.RotateTowards(rb.rotation, newRotation, rotationSpeed * Time.deltaTime);
//        //    }
//
//        // Move the player. This makes the player move and rotate.
//        // BUG: now the player moves way too slowly.
//        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
//
//        // // This is the old way to move the player. It moves the player quickly, but the player only moves forwards, but never backwards.
//    	// transform.Translate(movement * speed * Time.deltaTime);
//
//        //Set the player rotation based on the look transform (source: PlayerMovementInputController.cs file from Cinemachine tutorial)
//        transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);
//
//        //reset the y rotation of the look transform (source: PlayerMovementInputController.cs file from Cinemachine tutorial)
//        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);

        // This lets the Player jump while pressing the space bar.
        // BUG: The player can't jump yet.
    	if (Input.GetKeyDown(KeyCode.Space)) // Jumping
    	{
        	rb.AddForce(new Vector3(0, jumpForce, 0));
    	}
    }
}
