using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float baseSpeed = 10;
	private float speed = 10;
	private bool facingRight = true;
	public int jumpPower = 1000;
	private float moveX;
	private bool isOnGround;

	void Update()
	{
		PlayerMove();
	}

	void PlayerMove()
	{
		// controls
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump")) {
			Jump();
		}

		// animations

		// player direction
		if ((moveX < 0 && facingRight) || (moveX > 0 && !facingRight)) {
			Flip();
		}

		// physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
		speed = baseSpeed / 2 + (isOnGround ? baseSpeed / 2 : 0);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		string tag = collision.gameObject.tag;
		if (tag == "Terrain" || tag == "Ground") {
			isOnGround = true;
		}
	}

	void Jump()
	{
		if (isOnGround) {
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
			isOnGround = false;
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
}
