using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Variables
	public float moveSpeed;
	public float jumpHeight;

	public Transform groundCheck;
	public AudioClip jumpSound;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool isFireObjectPickup;

	public float jumpForce = 500f;

	Animator anim;

	private bool grounded;	
	private AudioSource source;
	private bool doubleJumped;
	private float moveVelocity;

	void Awake () {
		source = GetComponent<AudioSource>();
		isFireObjectPickup = false;
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void FixedUpdate(){
		anim.SetBool("Ground", grounded);
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}



	// Update is called once per frame
	void Update () {
	    //In Unity5 its GetComponent<RigidBody2d>().velocity
		if (grounded)
			doubleJumped = false;

		moveVelocity = 0f;

		//Jumping Up and down
		if (Input.GetKeyDown (KeyCode.UpArrow) && grounded || Input.GetKeyDown (KeyCode.W) && grounded) {
			float vol = 1.0f;
			GetComponent<Rigidbody2D>().velocity = new Vector2( GetComponent<Rigidbody2D>().velocity.x, jumpHeight );
			source.PlayOneShot(jumpSound,vol);
			anim.SetBool("Ground", false);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
		} 

		//Double jump
		if (Input.GetKeyDown (KeyCode.UpArrow) && !doubleJumped && !grounded || Input.GetKeyDown (KeyCode.W) && !doubleJumped && !grounded) {
			float vol = 0.5f;
			GetComponent<Rigidbody2D>().velocity = new Vector2( GetComponent<Rigidbody2D>().velocity.x, jumpHeight );
			doubleJumped = true;
			source.PlayOneShot(jumpSound,vol);
		} 


		//Moving Right
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)){
			if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)){
				moveVelocity = 0f;}
			else{
					moveVelocity = moveSpeed;}
		} 

		//Moving Left
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)){
				moveVelocity = 0f;}
			else{
				moveVelocity = -moveSpeed;}
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		//Player Flipping
		if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
			transform.localScale = new Vector3 (1.75f, 1.75f, 1f);

		}
		else if (GetComponent<Rigidbody2D> ().velocity.x < 0) {
			transform.localScale = new Vector3 (-1.75f, 1.75f, 1f);
			//GetComponentInChildren<Transform>().localPosition = new Vector3 (-1f, 1f, 1f);
		}
	}
}