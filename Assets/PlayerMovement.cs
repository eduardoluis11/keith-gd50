using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This file will let the Player (Fang) move, run, and jump.

You can move around using the arrow keys or WASD keys.
*/

public class PlayerMovement : MonoBehaviour
{

	public float speed = 5f;
	public float jumpForce = 300f;
	private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
    	float moveVertical = Input.GetAxis("Vertical");

    	Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
    	transform.Translate(movement * speed * Time.deltaTime);

        // This lets the Player jump while pressing the space bar.
        // BUG: The player can't jump yet.
    	if (Input.GetKeyDown(KeyCode.Space)) // Jumping
    	{
        	rb.AddForce(new Vector3(0, jumpForce, 0));
    	}
    }
}
