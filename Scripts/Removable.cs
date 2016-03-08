using UnityEngine;
using System.Collections;

public class Removable : MonoBehaviour {

	private Dropoff dropOff;

	// Use this for initialization
	void Start () {
		dropOff = FindObjectOfType<Dropoff> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dropOff.GetComponent<Renderer> ().enabled == true) {
			Destroy (gameObject);
		}
	}
}
