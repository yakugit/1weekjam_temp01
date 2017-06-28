using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAction : MonoBehaviour {

	public float HitForce = 1000f;
	public Vector3 forceDirection;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionStay (Collision collision)
	{
		AddForce (collision);
	}

	void OnCollisionEnter (Collision collision)
	{
		AddForce (collision);
	}
	
	void AddForce(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			Destroy (gameObject);
			Rigidbody rb = collision.gameObject.GetComponent<Rigidbody> ();
			rb.AddForce (forceDirection * HitForce);
		}	
	}
}
