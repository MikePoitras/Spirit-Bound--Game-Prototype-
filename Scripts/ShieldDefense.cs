using UnityEngine;
using System.Collections;

public class ShieldDefense : MonoBehaviour {

	public AudioClip DefenseSound;
	
	private AudioSource source;
//	private PlayerController player;
	private float vol = 1f;
	
	
	void Awake () {
		source = GetComponent<AudioSource>();
//		player = FindObjectOfType<PlayerController> ();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)){
			gameObject.GetComponent<Renderer> ().enabled = true;
			gameObject.GetComponent<Collider2D> ().enabled = true;
			source.PlayOneShot (DefenseSound, vol);
		}
		else if(Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.DownArrow)){
			gameObject.GetComponent<Renderer> ().enabled = false;
			gameObject.GetComponent<Collider2D> ().enabled = false;
		}
	}
}
