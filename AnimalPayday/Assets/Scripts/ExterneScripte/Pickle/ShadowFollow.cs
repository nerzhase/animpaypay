using UnityEngine;
using System.Collections;

//	Attach this script to the Main Camera.
//	This script will set the transform values for the GameObject it is attached to.
public class ShadowFollow : MonoBehaviour {

	public Transform projectile;        // The transform of the projectile to follow.
	public float koordinateX = 1;
	public float koordinateY = 1; 

	void Update () {
		// Store the position of the camera.
		Vector3 newPosition = transform.position;
		Quaternion newRotation = transform.rotation;


		newPosition.x = projectile.position.x + koordinateX;
		newPosition.y = projectile.position.y + koordinateY;
		newRotation = projectile.rotation;

		
		// Set the objects position to this stored position.
		transform.position = newPosition;
		transform.rotation = newRotation;
	}

}

