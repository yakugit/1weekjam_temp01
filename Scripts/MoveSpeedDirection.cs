using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class MoveSpeedDirection : MonoBehaviour {

	Rigidbody rb;
	public GameCamera camera;

	public float dierctionScale = 5f;
	public float distance = 1f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate ()
	{
		if (enabled) {
			var vel = rb.velocity.magnitude;
			vel = Mathf.Clamp (vel / dierctionScale, 0, 1);

			camera.directionInfluence = vel * distance;
		}
	}
}
