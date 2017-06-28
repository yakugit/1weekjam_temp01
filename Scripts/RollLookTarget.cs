using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollLookTarget : MonoBehaviour {

	public GameObject FollowTarget;

	Vector3 previousPosition;

	void FixedUpdate ()
	{
		var diffPosition = FollowTarget.transform.position - transform.position;
		transform.position = FollowTarget.transform.position;

		var look = Quaternion.LookRotation (diffPosition);
		Vector3 originPoisition = new Vector3 (-transform.position.x, 0f, -transform.position.z);
		var origin = Quaternion.LookRotation (originPoisition.normalized);


		Quaternion circlelook;

		if (originPoisition.sqrMagnitude > 25f) {
			circlelook = Quaternion.Slerp (look, origin, 0.1f);
		} else {
			circlelook = look;
		}
		transform.rotation = Quaternion.Slerp (transform.rotation, circlelook, 0.1f);

	}
}
