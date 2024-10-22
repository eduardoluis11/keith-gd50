using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

/* Controls the player. Here we chose our "focus" and where to move.

Most of this script comes from this tutorial from this repo from a Brackeys tutorial:
https://github.com/Brackeys/RPG-Tutorial/blob/master/Finished%20Project/Assets/Scripts/Controllers/PlayerController.cs
*/

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	// public delegate void OnFocusChanged(Interactable newFocus);
	// public OnFocusChanged onFocusChangedCallback;

	public Interactable focus;	// Our current focus: Item, Enemy etc.

	public LayerMask movementMask;		// The ground
	// public LayerMask interactionMask;	// Everything we can interact with

	PlayerMotor motor;		// Reference to our motor

	// I changed this variable's name
	Camera playerCam;				// Reference to our camera

	// Get references
	void Start ()
	{
		motor = GetComponent<PlayerMotor>();
		playerCam = Camera.main;
	}

	// Update is called once per frame
	void Update () {

		// if (EventSystem.current.IsPointerOverGameObject())
		// 	return;

		// If we press left mouse
		if (Input.GetMouseButtonDown(0))
		{
			// Shoot out a ray
			Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// If we hit
			// if (Physics.Raycast(ray, out hit, movementMask))
            if (Physics.Raycast(ray, out hit, 100, movementMask))
			{
                // Debug.Log("We hit " + hit.collider.name + " " + hit.point);

				motor.MoveToPoint(hit.point);

				RemoveFocus();

				// SetFocus(null);
			}
		}

		// If we press right mouse
		if (Input.GetMouseButtonDown(1))
		{
			// Shoot out a ray
			Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// If we hit
			// if (Physics.Raycast(ray, out hit, 100f, interactionMask))
            if (Physics.Raycast(ray, out hit, 100))
			{
				// SetFocus(hit.collider.GetComponent<Interactable>());
				Interactable interactable = hit.collider.GetComponent<Interactable>();

				if (interactable != null)
				{
					SetFocus(interactable);
				}

			}
		}

	}

	// Set our focus to a new focus
	void SetFocus (Interactable newFocus)
	{



	// 	if (onFocusChangedCallback != null)
	// 		onFocusChangedCallback.Invoke(newFocus);

	// 	// If our focus has changed
	// 	if (focus != newFocus && focus != null)
	// 	{
	// 		// Let our previous focus know that it's no longer being focused
	// 		focus.OnDefocused();
	// 	}

		if (newFocus != focus)
		{

			if (focus != null)
				focus.OnDefocused();
			focus = newFocus;
			motor.FollowTarget(newFocus);

		}

		// Set our focus to what we hit
		// If it's not an interactable, simply set it to null

		newFocus.OnFocused(transform);


	// 	if (focus != null)
	// 	{
	// 		// Let our focus know that it's being focused
	// 		focus.OnFocused(transform);
	// 	}

	}

	void RemoveFocus ()
	{
		if (focus != null)
			focus.OnDefocused();
		focus = null;
		motor.StopFollowingTarget();
	}

}