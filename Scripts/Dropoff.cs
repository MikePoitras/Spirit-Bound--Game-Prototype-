using UnityEngine;
using System.Collections;

public class Dropoff : MonoBehaviour {

	public GameObject DropOff;

	private PlayerController player;
	
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		DropOff.GetComponent<Renderer>().enabled = false;
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null)
			return;

		if(player.isFireObjectPickup == true){
			DropOff.GetComponent<Renderer>().enabled = true;
		}
	}
}
