using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAction : MonoBehaviour {

	public enum HitDirection
	{
		Center,
		Back
	}

	public float LifeTime = 10f;
	public float HitForce = 1000f;

	public GameObject Effect;
	public float EffectLifeTime = 3f;

	public HitDirection Direction;

	void Start ()
	{
		Destroy (gameObject, LifeTime);
	}
	
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
			if (Effect) {
				var effect = Instantiate (Effect);
				effect.transform.position = collision.transform.position;
				Destroy (effect, EffectLifeTime);
			}
			Destroy (gameObject);
			Rigidbody rb = collision.gameObject.GetComponent<Rigidbody> ();
			Vector3 forceDirection = collision.transform.position;
			forceDirection = new Vector3 (-forceDirection.x, 0f, -forceDirection.z).normalized;
			if (Direction == HitDirection.Center) {
				rb.AddForce ((forceDirection + Vector3.up * 0.1f) * HitForce);
			} else if (Direction == HitDirection.Back) {
				var angle = Quaternion.AngleAxis (90, Vector3.up);
				rb.AddForce ((angle * forceDirection) * HitForce);
			} 
		}	
	}
}
