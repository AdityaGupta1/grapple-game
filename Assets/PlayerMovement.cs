using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public int speed = 10;
	private bool facingRight = true;
	public int jumpPower = 1200;
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
		if (moveX < 0 && facingRight) {
			FlipPlayer();
		} else if (moveX > 0 && !facingRight) {
			FlipPlayer();
		}

		// physics
		Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();
		rigidbody.velocity = new Vector2(moveX * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
		rigidbody.freezeRotation = true;
		speed = 5 + (isOnGround ? 5 : 0);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Terrain") {
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

	void FlipPlayer()
	{
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
}
