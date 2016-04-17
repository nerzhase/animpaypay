﻿using UnityEngine;

public class ProjectileDragging : MonoBehaviour {
	public float maxStretch = 2.0f;
	public LineRenderer catapultLineFront;
	public LineRenderer catapultLineBack;
	public Sprite Stretched;				//	The reference to our "damaged" sprite
	public Sprite Gurke;				//	The reference to our "damaged" sprite
	public SpriteRenderer Schattenobjekt;
	public Sprite DownShadow;
	public Sprite UpShadow;


	private SpringJoint2D spring;
	private Transform catapult;
	private Ray rayToMouse;
	private Ray leftCatapultToProjectile;
	private float maxStretchSqr;    
	private float circleRadius;
	private bool clickedOn;
	private Vector2 prevVelocity;
	private SpriteRenderer spriteRenderer;		//	The reference to this GameObject's sprite renderer
		
	void Awake () {
		spring = GetComponent <SpringJoint2D> ();
		catapult = spring.connectedBody.transform;
		spriteRenderer = GetComponent <SpriteRenderer> ();
	}
	
	void Start () {
		LineRendererSetup ();
		rayToMouse = new Ray(catapult.position, Vector3.zero);
		leftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
//		CircleCollider2D circle = GetComponent<Collider2D>() as CircleCollider2D;
		// circleRadius = circle.radius;
	}
	
	void Update () {
		if (clickedOn)
			Dragging ();
		
		if (spring != null) {
			if (!GetComponent<Rigidbody2D>().isKinematic && prevVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude) {
				Destroy (spring);
				GetComponent<Rigidbody2D>().velocity = prevVelocity;
			}
			
			if (!clickedOn)
				prevVelocity = GetComponent<Rigidbody2D>().velocity;
			
			LineRendererUpdate ();
			
		} else {
			catapultLineFront.enabled = false;
			catapultLineBack.enabled = false;
		}
	}
	
	void LineRendererSetup () {
		catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
		catapultLineBack.SetPosition(0, catapultLineBack.transform.position);
		
		catapultLineFront.sortingLayerName = "foreground";
		catapultLineBack.sortingLayerName = "foreground";
		
		catapultLineFront.sortingOrder = 3;
		catapultLineBack.sortingOrder = 1;
	}
	
	void OnMouseDown () {
		spring.enabled = false;
		clickedOn = true;
		//	Sprite-Wechsel, Gurke wird stretched
		spriteRenderer.sprite = Stretched;
		Schattenobjekt.sprite = DownShadow;
	}
	
	void OnMouseUp () {
		spring.enabled = true;
		GetComponent<Rigidbody2D>().isKinematic = false;
		clickedOn = false;
		//	Sprite-Wechsel again
		spriteRenderer.sprite = Gurke;
		Schattenobjekt.sprite = UpShadow;
	}

	void Dragging () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 catapultToMouse = mouseWorldPoint - catapult.position;
		
		if (catapultToMouse.sqrMagnitude > maxStretchSqr) {
			rayToMouse.direction = catapultToMouse;
			mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
		}
		
		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}

	void LineRendererUpdate () {
		Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
		leftCatapultToProjectile.direction = catapultToProjectile;
		Vector3 holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + circleRadius);
		catapultLineFront.SetPosition(1, holdPoint);
		catapultLineBack.SetPosition(1, holdPoint);
	}
}
