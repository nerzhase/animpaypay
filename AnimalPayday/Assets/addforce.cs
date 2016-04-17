using UnityEngine;
using System.Collections;

public class addforce : MonoBehaviour {
	
	Rigidbody rb;
	Vector3 direction = Vector3.zero;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			direction = this.gameObject.transform.position - other.gameObject.transform.position;
			rb.AddForce (direction, ForceMode.Impulse);
		}
	
	}
}
