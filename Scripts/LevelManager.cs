using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	public float respawnDelay;

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		Debug.Log ("Player Respawn");
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		yield return new WaitForSeconds (respawnDelay);
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		player.GetComponent<Renderer>().enabled = true;
	}

}
