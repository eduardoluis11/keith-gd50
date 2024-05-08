using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* This will allow Fang to move around when pressing the WASD or arrow keys (source: Cinemachine Unity tutorial from Youtube).

Source of most of this code: PlayerLocomotionsInputController.cs file from the Official Unity Cinemachine Tutorial.

EDIT LATER TO MAKE THE CODE MORE ORIGINAL.
 */ 

public class PlayerLocomotion : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _movement;

    private Vector2 smoothDeltaPosition = Vector2.zero;
    public Vector2 velocity = Vector2.zero;
    public float magnitude = 0.25f;

    private void OnEnable()
    {
        _movement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }
    public bool shouldMove;
    public bool shouldTurn;
    public float turn;

    public GameObject look;

    public GameObject arrow;

    public Transform arrowBone;
    public GameObject arrowPrefab;

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

        // bool isAiming = (_movement.aimValue == 1f);

        // if (isAiming)
        // {
        //     if ((_movement.fireValue == 1f))
        //     {
        //         _animator.SetTrigger("Fire");
        //         arrow.SetActive(false);
        //         StartCoroutine(FireArrow());
        //     }


        //     if (_animator.GetCurrentAnimatorStateInfo(2).IsName("Fire"))
        //     {
        //         arrow.SetActive(false);
        //     }
        //     else
        //     {
        //         arrow.SetActive(true);
        //     }

         

            
        //     _movement.fireValue = 0f;
        // }
        // _animator.SetBool("IsAiming", isAiming);
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

    IEnumerator FireArrow()
    {
        GameObject projectile = Instantiate(arrowPrefab);
        projectile.transform.forward = look.transform.forward;
        projectile.transform.position = fireTransform.position + fireTransform.forward;
        //Wait for the position to update
        yield return new WaitForSeconds(0.1f);

        // projectile.GetComponent<ArrowProjectile>().Fire();
        
    }



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
