using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float mspeed = 7.0f;

	void Start() {
		Cursor.visible = false; //disables the cursor
	}

	void Update () {

		var x = - Input.GetAxis("Horizontal") * Time.deltaTime * 7.0f; //movement
		var z = - Input.GetAxis("Vertical") * Time.deltaTime * mspeed; //movement

		transform.Translate(x, 0, 0); //movement
		transform.Translate(0, 0, z); //movement

		if (Input.GetKey (KeyCode.LeftShift)) {
			mspeed = 13.0f;  				//sprint
		} else {
			mspeed = 7.0f;
		}

		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();				//quit
		}
	}
}
