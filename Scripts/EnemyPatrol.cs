using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {
	//See Part 7 Time: 10:05	
	public float moveSpeed;
	public bool moveRight;
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	public Transform edgeCheck;

	private bool hittingWall;
	private bool notAtEdge;

	void Start(){

	}

	void Update (){
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
		notAtEdge =  Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall || !notAtEdge)
			moveRight = !moveRight;


		if (moveRight) {
			transform.localScale = new Vector3 (-0.08f, 0.08f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
		else {
			transform.localScale = new Vector3 (0.08f, 0.08f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}

}
