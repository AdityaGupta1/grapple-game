using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public bool dead = false;

	void Update()
	{
		if (gameObject.transform.position.y < -10 && !dead) {
			dead = true;
			Die();
		}
	}

	void Die() {
		SceneManager.LoadScene("Main");
	}
}
