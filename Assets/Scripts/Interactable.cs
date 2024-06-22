using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.

    Source for most of this code: This file from a Brackeys tutorial:
    https://github.com/Brackeys/RPG-Tutorial/blob/master/Finished%20Project/Assets/Scripts/Interactables/Interactable.cs


*/

/* This script will allow the player to interact with objects in the game, WHICH includes enemies
(such as the boss.) 

Source of most of this code: Brackey's tutorial from: 
https://youtu.be/9tePzyL6dgc?si=i6dSdIY29xrdMJVN 
*/



/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/

public class Interactable : MonoBehaviour {

	public float radius = 3f;				// How close do we need to be to interact?
	public Transform interactionTransform;	// The transform from where we interact in case you want to offset it

	bool isFocus = false;	// Is this interactable currently being focused?
	Transform player;		// Reference to the player transform

	bool hasInteracted = false;	// Have we already interacted with the object?

	public virtual void Interact ()
	{
		// This method is meant to be overwritten
		//Debug.Log("Interacting with " + transform.name);
	}

	void Update ()
	{
		// If we are currently being focused
		// and we haven't already interacted with the object
		if (isFocus && !hasInteracted)
		{
			// If we are close enough
			float distance = Vector3.Distance(player.position, interactionTransform.position);
			if (distance <= radius)
			{
				// Interact with the object
				Interact();
				hasInteracted = true;
			}
		}
	}

	// Called when the object starts being focused
	public void OnFocused (Transform playerTransform)
	{
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
	}

	// Called when the object is no longer focused
	public void OnDefocused ()
	{
		isFocus = false;
		player = null;
		hasInteracted = false;
	}

	// Draw our radius in the editor
	void OnDrawGizmosSelected ()
	{
		if (interactionTransform == null)
			interactionTransform = transform;

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

}

// public class Interactable : MonoBehaviour
// {

//     public float radius = 3f;
//     public Transform interactionTransform;

//     bool isFocus = false;
//     Transform player;

//     bool hasInteracted = false;

//     public virtual void Interact()
//     {
//         // This method is meant to be overwritten
//         // Debug.Log("Interacting with " + transform.name);
//     }

//     void Update()
//     {
//         if (isFocus && !hasInteracted)
//         {
//             float distance = Vector3.Distance(player.position, interactionTransform.position);
//             if (distance <= radius)
//             {
//                 Interact();
//                 hasInteracted = true;
//             }
//         }
//     }

//     public void OnFocused(Transform playerTransform)
//     {
//         isFocus = true;
//         player = playerTransform;
//         hasInteracted = false;
//     }

//     public void OnDefocused()
//     {
//         isFocus = false;
//         player = null;
//         hasInteracted = false;
//     }

//     void OnDrawGizmosSelected()
//     {
//         Gizmos.color = Color.yellow;
//         Gizmos.DrawWireSphere(interactionTransform.position, radius);
//     }


// }


// // [RequireComponent(typeof(ColorOnHover))]
// public class Interactable : MonoBehaviour {

// 	public float radius = 3f;
// 	public Transform interactionTransform;

// 	bool isFocus = false;	// Is this interactable currently being focused?
// 	Transform player;		// Reference to the player transform

// 	bool hasInteracted = false;	// Have we already interacted with the object?

// 	// This method is meant to be overwritten
// 	public virtual void Interact ()
// 	{
// 		Debug.Log("Interacting with " + transform.name);
// 	}


// 	void Update ()
// 	{
// 		if (isFocus && !hasInteracted)	// If currently being focused
// 		{
// 			// float distance = Vector3.Distance(player.position, interactionTransform.position);

// 			float distance = Vector3.Distance(player.position, interactionTransform.position);
// 			// If we haven't already interacted and the player is close enough
// 			// if (!hasInteracted && distance <= radius)
// 			if (distance <= radius)
// 			{
// 				// // Interact with the object
// 				hasInteracted = true;
// 				Interact();

// 				// Debug.Log("Interact");
// 			}
// 		}
// 	}

// 	// Called when the object starts being focused
// 	public void OnFocused (Transform playerTransform)
// 	{
// 		isFocus = true;
// 		hasInteracted = false;
// 		player = playerTransform;
//     }

// 	// Called when the object is no longer focused
// 	public void OnDefocused ()
// 	{
// 		isFocus = false;
// 		hasInteracted = false;
// 		player = null;
// 	}


// 	void OnDrawGizmosSelected ()
// 	{
// 		Gizmos.color = Color.yellow;
// 		Gizmos.DrawWireSphere(interactionTransform.position, radius);
//         // Gizmos.DrawWireSphere(transform.position, radius);
// 	}

// }