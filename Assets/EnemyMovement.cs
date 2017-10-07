using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public int speed = 4;
	public int xDirection = -1;

	void Update() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xDirection, 0));
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xDirection, 0) * speed;
		if (hit.distance < 0.7f) {
			Flip();
		}
	}

	void Flip() {
		xDirection *= -1;
	}
}
