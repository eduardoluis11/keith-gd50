using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This is a Script that will let me Move the Cube version of the Player.

Most of this code is taken from this tutorial from Brackeys: https://youtu.be/S2mK6KFdv0I?si=Me2B0Dru_yU9PCLc


*/

public class PlayerController : MonoBehaviour
{

    // Source: Brackeys: https://youtu.be/S2mK6KFdv0I?si=Me2B0Dru_yU9PCLc
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // Source: Brackeys: https://youtu.be/S2mK6KFdv0I?si=Me2B0Dru_yU9PCLc
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Source: Brackeys: https://youtu.be/S2mK6KFdv0I?si=Me2B0Dru_yU9PCLc
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Source: Brackeys: https://youtu.be/S2mK6KFdv0I?si=Me2B0Dru_yU9PCLc

                Debug.Log("We hit " + hit.collider.name + " " + hit.point);

                // // Move our player to what we hit
                // MovePlayer(hit.point);
            }
        }
    }
}
