using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float mspeed = 20.0f;

	void Start() {
		Cursor.visible = false;
	}

	void Update () {
		var x = - Input.GetAxis("Horizontal") * Time.deltaTime * 15.0f;
		var z = - Input.GetAxis("Vertical") * Time.deltaTime * mspeed;

		transform.Translate(x, 0, 0);
		transform.Translate(0, 0, z);

		if (Input.GetKey (KeyCode.LeftShift)) {
			mspeed = 40.0f;
		} else {
			mspeed = 20.0f;
		}

		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
