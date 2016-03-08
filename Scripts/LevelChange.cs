using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {

	private PlayerController player;

	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null)
			return;
	
		Application.LoadLevel ("Level_2");   
	}
}

