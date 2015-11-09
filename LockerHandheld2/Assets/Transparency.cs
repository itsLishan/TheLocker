using UnityEngine;
using System.Collections;

public class Transparency : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		//gameObject.GetComponent<Renderer> ().material.color.a = 1.0f;
		for (float f = 1f; f >= 0; f -= 0.1f) {
			Color c = gameObject.GetComponent<Renderer> ().material.color;
			c.a = f;
			gameObject.GetComponent<Renderer> ().material.color = c;
		}
	}
}
