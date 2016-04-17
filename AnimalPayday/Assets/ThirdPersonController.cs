using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour {

	private Vector3 moveDirection = Vector3.zero;

	[SerializeField]
	float speed = 5;
	[SerializeField]
	float rotationspeed = 3f;
	float gravity = 9.81f;
	Vector3 velocity;
	[SerializeField]
	float velocitystrength = 0f;

	[SerializeField]
	Mesh newmesh;


	void Start () {
	}

	void Update () {

		CharacterController controller = GetComponent<CharacterController> ();

		if (controller.isGrounded) {
			velocity = new Vector3 (0, 0, controller.velocity.z * velocitystrength);
			velocity = transform.TransformDirection (velocity);

			moveDirection = new Vector3 (0, -1, Input.GetAxis ("Vertical")) - velocity;
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;

			transform.Rotate(0, Input.GetAxis("Horizontal") * rotationspeed, 0);

			}	

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
		Debug.Log(velocity);
	
		}

	void OnMouseDown () {
		GetComponent<MeshFilter>().mesh = newmesh;
	}
}
