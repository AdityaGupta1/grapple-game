﻿using UnityEngine;
using System.Collections;

public class GrapplingHook : MonoBehaviour {

	DistanceJoint2D joint;
	Vector3 targetPos;
	RaycastHit2D hit;
	public float distance = 10f;

	void Start () {
		joint = GetComponent<DistanceJoint2D>();
		joint.enabled = false;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPos.z = 0;

			hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance);
			if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null) {
				joint.enabled = true;
				joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
				joint.distance = Vector2.Distance(transform.position, hit.point);
			}
		}

		if (Input.GetKeyUp(KeyCode.E)) {
			joint.enabled = false;
		}
	}
}
