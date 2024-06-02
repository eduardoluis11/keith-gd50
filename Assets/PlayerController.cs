using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This is a Script that will let me Move the Cube version of the Player.

Most of this code is taken from this tutorial from Brackeys: https://youtu.be/S2mK6KFdv0I?si=Me2B0Dru_yU9PCLc


*/

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    public LayerMask movementMask; // The layer mask that will be used to determine where the player can move to

    // Source: Brackeys: https://youtu.be/S2mK6KFdv0I?si=Me2B0Dru_yU9PCLc
    Camera cam;
    PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        // Source: Brackeys: https://youtu.be/S2mK6KFdv0I?si=Me2B0Dru_yU9PCLc
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Source: Brackeys: https://youtu.be/S2mK6KFdv0I?si=Me2B0Dru_yU9PCLc
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // Source: Brackeys: https://youtu.be/S2mK6KFdv0I?si=Me2B0Dru_yU9PCLc

                motor.MoveToPoint(hit.point);

                // Debug.Log("We hit " + hit.collider.name + " " + hit.point);

                // // Move our player to what we hit
                // MovePlayer(hit.point);
            }
        }
    }
}
