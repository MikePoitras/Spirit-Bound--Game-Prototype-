using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {
//		public GameObject target;
	public float attackTimer;
	public float coolDown;
	public AudioClip attackSound;
	public GameObject attackObject; 

	private AudioSource source;
	private PlayerController player;


	void Awake () {
		source = GetComponent<AudioSource>();
		player = FindObjectOfType<PlayerController> ();
	}

	// Use this for initialization
	void Start () {
		attackTimer = 0;
		coolDown = 0.25f;
		gameObject.GetComponent<Renderer> ().enabled = false;
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;

		if (attackTimer < 0) {
			attackTimer = 0;
			gameObject.GetComponent<Renderer> ().enabled = false;
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (attackTimer == 0){
				if(player.GetComponent<PlayerController>().GetComponent<Rigidbody2D>().velocity.x > 0) {
					//gameObject.transform.localPosition = new Vector3 (.5f, 0f, 0f);
					//gameObject.transform.localRotation = new Quaternion (0f, 0f, 0f, 0f);
					gameObject.GetComponent<Renderer> ().enabled = true;
					gameObject.GetComponent<BoxCollider2D> ().enabled = true;
					Attack();
					attackTimer = coolDown;
				}
				else if(player.GetComponent<PlayerController>().GetComponent<Rigidbody2D>().velocity.x < 0) {
					//gameObject.transform.localPosition = new Vector3 (-.5f, 0f, 0f);
					//gameObject.transform.localRotation = new Quaternion (0f, 0f, 180f, 0f);
					gameObject.GetComponent<Renderer> ().enabled = true;
					gameObject.GetComponent<BoxCollider2D> ().enabled = true;
					Attack();
					attackTimer = coolDown;
				}
				else{
					gameObject.GetComponent<Renderer> ().enabled = true;
					gameObject.GetComponent<BoxCollider2D> ().enabled = true;
					Attack();
					attackTimer = coolDown;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			Destroy (other.gameObject);
		}
	}

	private void Attack(){
		float vol = 1.0f;
		source.PlayOneShot (attackSound, vol);
		Debug.Log ("Player Attack");
	}
}