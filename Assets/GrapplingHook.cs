	using UnityEngine;
using System.Collections;

public class GrapplingHook : MonoBehaviour {

	public LineRenderer line;
	DistanceJoint2D joint;
	Vector3 targetPos;
	RaycastHit2D hit;
	public float distance = 10f;
	public bool hookEnabled = false;

	void Start () {
		joint = GetComponent<DistanceJoint2D>();
		joint.enabled = false;
		line.enabled = false;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPos.z = 0;

			hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance);
			if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null) {
				joint.enabled = true;
				joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
				joint.connectedAnchor = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
				joint.distance = Vector2.Distance(transform.position, hit.point);

				line.enabled = true;
				line.SetPosition(0, transform.position);
				line.SetPosition(1, hit.point);
			}
		}

		if (Input.GetKey(KeyCode.E)) {
			line.SetPosition(0, transform.position);
		}

		if (Input.GetKeyUp(KeyCode.E)) {
			joint.enabled = false;
			line.enabled = false;
		}

		hookEnabled = joint.enabled;
	}
}
