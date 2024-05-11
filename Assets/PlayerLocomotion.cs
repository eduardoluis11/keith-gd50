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

    private PlayerMovement _movement;

    // The Unity Editor needs this to get the Skeleton with the Animator Component to let me move.
    private Animator _animator;


    // This should modify the player's velocity.
    public Vector2 velocity = Vector2.zero;
    public float magnitude = 0.26f;
    private Vector2 smoothDeltaPosition = Vector2.zero;


    // This should get the Animator Component from the Unity Editor, as well as the player's movement.
    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
    }

    // BOOKMARK

    
    public bool shouldMove;
    public float turn;
    public bool shouldTurn;


    public GameObject look;

    // BOOKMARK


    public void Update()
    {
        Vector3 worldDeltaPosition = _movement.nextPosition - transform.position;

        //Map to local space
        float dX = Vector3.Dot(transform.right, worldDeltaPosition);
        float dY = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dX, dY);

        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        if (Time.deltaTime > 1e-5f)
        {
            velocity = smoothDeltaPosition / Time.deltaTime;
        }

        shouldMove = velocity.magnitude > magnitude;

 

        _animator.SetBool("IsMoving", shouldMove);
        _animator.SetFloat("VelocityX", velocity.x);
        _animator.SetFloat("VelocityY", Mathf.Abs(velocity.y));

    }

    private void OnAnimatorMove()
    {
        //Update the position based on the next position;
        transform.position = _movement.nextPosition;
    }

    [SerializeField]
    private Transform fireTransform;


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
