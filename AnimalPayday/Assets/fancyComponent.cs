using UnityEngine;
using System.Collections;

public class fancyComponent : MonoBehaviour {


	// Update is called once per frame
	void OnMouseDown () {
		Debug.Log ("MouseDown");
		GetComponent<ParticleSystem>().Play();
	}

	void OnMouseUp () {
		Debug.Log ("MouseUp");
		GetComponent<ParticleSystem>().Stop();
	}
}
