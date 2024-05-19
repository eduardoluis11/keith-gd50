using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System.Collections.Generic;


/* This will allow Fang to move around when pressing the WASD or arrow keys (source: Cinemachine Unity tutorial from Youtube).

Source of most of this code: PlayerLocomotionsInputController.cs file from the Official Unity Cinemachine Tutorial.

EDIT LATER TO MAKE THE CODE MORE ORIGINAL.
 */ 

/* This will  let the Player Move Around when combined with the PlayerMovement.cs script.

The PlayerMovement.cs script only lets the player move the camera around, but not the player itself, sicne I used Unity's Player Input System.
So, to finish letting the player be moved around by using the WASD keys, I created this script (source: Source of most of this code: 
PlayerLocomotionsInputController.cs file from the Official Unity Cinemachine Tutorial.)
*/
public class PlayerLocomotion : MonoBehaviour
{

    private PlayerMovement _playerMovement;



    // The Unity Editor needs this to get the Skeleton with the Animator Component to let me move.
    private Animator _playerAnimator;



    // This should modify the player's velocity.
    public Vector2 playersVelocity = Vector2.zero;


    public float velocitysMagnitude = 0.26f;



    private Vector2 smoothDeltaPosition = Vector2.zero;


    // This should get the Animator Component from the Unity Editor, as well as the player's movement.
    private void OnEnable()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }



    public bool playerShouldMove;

    // BOOKMARK (change the rest of the variables' names to make this script more original and less like the PlacerLocomotionInputController.cs script from)


    public GameObject look;




    public void Update()
    {
        Vector3 worldDeltaPosition = _playerMovement.nextPosition - transform.position;

        // This should re-position the player in the game's world while moving.
        float dY = Vector3.Dot(transform.forward, worldDeltaPosition);
        float dX = Vector3.Dot(transform.right, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dX, dY);

  

        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.16f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        if (Time.deltaTime > 1e-6f)
        {
            playersVelocity = smoothDeltaPosition / Time.deltaTime;
        }

        playerShouldMove = playersVelocity.magnitude > velocitysMagnitude;

 
        // These lines generate me a ton of DEBUG messages on the Unity Editor, so I commented them out.
        // _playerAnimator.SetFloat("playersVelocityX", playersVelocity.x);
        // _playerAnimator.SetBool("IsMoving", playerShouldMove);
        // _playerAnimator.SetFloat("playersVelocityY", Mathf.Abs(playersVelocity.y));

    }


    private void OnAnimatorMove()
    {
        // This will modify the player's position according to the position in which the player should be next
        transform.position = _playerMovement.nextPosition;
    }

    // // I think this is for firing arrows, SO I MIGHT NEED TO DELETE THIS LATER.
    // [SerializeField]

    // Bookmark (DONE!)

}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// /* This will allow Fang to move around when pressing the WASD or arrow keys (source: Cinemachine Unity tutorial from Youtube). */ 

// public class PlayerLocomotion : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
