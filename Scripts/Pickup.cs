using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	private PlayerController player;

	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null)
			return;

		player.isFireObjectPickup = true;
		Destroy (gameObject);	
	}
}
