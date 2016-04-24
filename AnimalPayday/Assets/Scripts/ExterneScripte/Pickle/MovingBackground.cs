using UnityEngine;
using System.Collections;

//	Attach this script to the Main Camera.
//	This script will set the transform values for the GameObject it is attached to.
public class MovingBackground : MonoBehaviour {

	public Transform camera;        // The transform of the projectile to follow.
	public float factor = 1;

	private float cameraStartPosition;
	private float cameracurrentPosition;
	private float deltaCameraX;
	private Vector3 targetposition;
	private Vector3 bgStartposition;


	void Awake () {
		cameraStartPosition = camera.position.x;
		bgStartposition = transform.position;
		print ("bgStart: "+bgStartposition);
	}

	void Update () {

		cameracurrentPosition = camera.position.x;
		deltaCameraX = cameraStartPosition - cameracurrentPosition;

		targetposition.x = bgStartposition.x + deltaCameraX * factor;
		targetposition.y = bgStartposition.y;
		transform.position = targetposition;

		print("Delta"+deltaCameraX);
		print("transform + Delta : "+targetposition.x);

	}

}

