﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	public void ReLoadScene() {
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		SceneManager.LoadScene(0);
	}
}