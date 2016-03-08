using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health;

	void Update(){
		if (health < 1) {
			Destroy (gameObject);
		}
	}
}
