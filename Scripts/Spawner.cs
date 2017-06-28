using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject SpawnPrefab;
	public float SpawnTime = 5f;

	public GameObject EffectPrefab;
	public float EffectTime = 1f;

	void OnEnable ()
	{
		StartCoroutine ("Spawn");
	}

	IEnumerator Spawn() {
		while (gameObject.activeInHierarchy) {
			var obj = Instantiate (SpawnPrefab);
			obj.transform.position = transform.position;
			Destroy (obj, SpawnTime);
			yield return new WaitForSeconds (SpawnTime);

			obj = Instantiate (EffectPrefab);
			obj.transform.position = transform.position;
			Destroy (obj, EffectTime);
			yield return new WaitForSeconds (EffectTime);
		}
	}
}
