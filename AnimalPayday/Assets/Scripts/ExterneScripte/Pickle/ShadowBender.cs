using UnityEngine;
using System.Collections;

public class ShadowBender : MonoBehaviour {

	public Sprite MouseDown;
	public Sprite MouseUp;

	private SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = GetComponent <SpriteRenderer> ();

	}

	void OnMouseDown () {
		spriteRenderer.sprite = MouseDown;
		print ("mouse down");
	}
	
	void OnMouseUp () {
		spriteRenderer.sprite = MouseUp;
		print ("mouse up");
	}

}
