using UnityEngine;
using System.Collections;

public class Resetter : MonoBehaviour {

	public Rigidbody2D projectile;			//	The rigidbody of the projectile
	public float resetSpeed = 0.25f;		//	The angular velocity threshold of the projectile, below which our game will reset
	public float forcedreset;				//  Time before reset if button pressed
	public float missedreset;				//  Time before reset

	private float resetSpeedSqr;			//	The square value of Reset Speed, for efficient calculation
	private SpringJoint2D spring;			//	The SpringJoint2D component which is destroyed when the projectile is launched
	
	void Start ()
	{
		//	Calculate the Resset Speed Squared from the Reset Speed
		resetSpeedSqr = resetSpeed * resetSpeed;

		//	Get the SpringJoint2D component through our reference to the GameObject's Rigidbody
		spring = projectile.GetComponent <SpringJoint2D>();
	}
	
	void Update () {
		//	If we hold down the "R" key...
		if (Input.GetKeyDown (KeyCode.R)) {
			//	... call the Reset() function
			Coroutine1 ();
		}

		//	If the spring had been destroyed (indicating we have launched the projectile) and our projectile's velocity is below the threshold...
		if (spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr) {
			//	... call the Reset() function
			Coroutine2 ();
		}
	}

	void Coroutine1 () {
		//	beginnt eine Ersatzroutine die den Reset verzögert
		StartCoroutine(Reset(forcedreset));
	}

	void Coroutine2 () {
		//	beginnt eine Ersatzroutine die den Reset verzögert
		StartCoroutine(Reset(missedreset));
	}
	

	IEnumerator Reset(float waitTime) {
		//Ersatzroutine die angegebenen Sekunden abwartet
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel (Application.loadedLevel);
	}
}
