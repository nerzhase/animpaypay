using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour {

	private Vector3 moveDirection = Vector3.zero;

	[SerializeField]
	float speed = 5;
	[SerializeField]
	float rotationspeed = 3f;
	float gravity = 9.81f;

	[SerializeField]
	Mesh newmesh;


	void Start () {
	}

	void Update () {

		CharacterController controller = GetComponent<CharacterController> ();

		if (controller.isGrounded) {

			moveDirection = new Vector3 (0, -1, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;

			transform.Rotate(0, Input.GetAxis("Horizontal") * rotationspeed, 0);

			}	

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	
		}

	void OnMouseDown () {
		GetComponent<MeshFilter>().mesh = newmesh;
	}
}
