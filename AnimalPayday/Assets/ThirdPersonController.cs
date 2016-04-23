using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour {

	private Vector3 moveDirection = Vector3.zero;


	float gravity = 9.81f;
	CharacterController controller;
	[SerializeField]
	float speed = 5f;
	[SerializeField]
	float rotationspeed = 3f;


	void Start () {
		controller = GetComponent<CharacterController> ();
	}

	void Update () {
		
		if (controller.isGrounded) {
			moveDirection = new Vector3 (0, -1, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;

			transform.Rotate(0, Input.GetAxis("Horizontal") * rotationspeed, 0);

			}	

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
		}

}
