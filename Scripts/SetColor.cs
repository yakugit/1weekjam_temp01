using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColor : MonoBehaviour {

	Image image;

	void Awake ()
	{
		image = GetComponent<Image> ();
	}

	public void SetImageColor(Color color) {
		image.color = color;
	}
}
