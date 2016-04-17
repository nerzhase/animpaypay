using UnityEngine;
using System.Collections;

public class TargetDamage : MonoBehaviour {
	
	public float damageImpactSpeed;				//	The speed threshold of colliding objects before the target takes damage

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
		if (collision.collider.tag != "Pickle")
			return;
		
		//	Check the colliding object's velocity's Square Magnitude, and if it is less than the threshold, exit this function
		if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr)
			return;

		//	... and Play the particle system
		GetComponent<ParticleSystem>().Play();
	}
	


}
