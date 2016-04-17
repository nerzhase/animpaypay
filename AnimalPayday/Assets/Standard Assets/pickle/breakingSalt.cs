using UnityEngine;
using System.Collections;

public class breakingSalt: MonoBehaviour {
	
	public float damageImpactSpeed;				//	The speed threshold of colliding objects before the target takes damage
	public GameObject oben;						//	upper gameobject - child
	public GameObject unten;					//	lower gameobject - child

	private float damageImpactSpeedSqr;			//	The square value of Damage Impact Speed, for efficient calculation
	private SpriteRenderer spriteRenderer;		//	The reference to this GameObject's sprite renderer


	void Start () {
		//	Get the SpriteRenderer component for the GameObject's Rigidbody
		spriteRenderer = GetComponent <SpriteRenderer> ();
		
		//	Calculate the Damage Impact Speed Squared from the Damage Impact Speed
		damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		//	Check the colliding object's tag, and if it is not "Damager", exit this function
		if (collision.collider.tag != "Damager")
		// der tag unserer Gurke - soll ja auch schaden machen
		if (collision.collider.tag != "Pickle")
			return;
		
		//	Check the colliding object's velocity's Square Magnitude, and if it is less than the threshold, exit this function
		if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr)
			return;
		//	We have taken damage, so sprite is not needed anymore
		spriteRenderer.enabled = false;

		//	collider und rigidbody are not needed anymore
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Rigidbody2D>().isKinematic = true;

		//	spriterenderer of children are activated
		oben.GetComponent<SpriteRenderer>().enabled = true;
		unten.GetComponent<SpriteRenderer>().enabled = true;

		//	collider of children are activated
		oben.GetComponent<Collider2D>().enabled = true;
		unten.GetComponent<Collider2D>().enabled = true;

		//	kinematic is turned off
		oben.GetComponent<Rigidbody2D>().isKinematic = false;
		unten.GetComponent<Rigidbody2D>().isKinematic = false;

		//	children are not the children of "salt" anymore -> null parents
		oben.transform.parent = null;
		unten.transform.parent = null;

	
	}

}
