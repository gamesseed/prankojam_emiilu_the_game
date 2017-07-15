using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float mspeed = 7.0f;
	public float sspeed = 7.0f;

	private bool IsGrounded;

	public static int esc = 0;

	void Update () {
		
		Rigidbody rb = GetComponent<Rigidbody> ();

		var x = - Input.GetAxis("Horizontal") * Time.deltaTime * sspeed; //movement
		var z = - Input.GetAxis("Vertical") * Time.deltaTime * mspeed; //movement

		transform.Translate(x, 0, 0); //movement
		transform.Translate(0, 0, z); //movement

		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.W)) {
			mspeed = 13.0f;  				//sprint
		} else {
			mspeed = 7.0f;
		}
			
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			transform.localScale -= new Vector3 (0, 0.5f, 0);
		} 														//crouch
		if (Input.GetKeyUp (KeyCode.LeftControl)) {
			mspeed = 7.0f;
			sspeed = 7.0f;
			transform.localScale += new Vector3 (0, 0.5f, 0);
		}
		if (Input.GetKey (KeyCode.LeftControl)) {
			mspeed = 3.0f;
			sspeed = 3.0f;
		}

		if (Input.GetKeyDown (KeyCode.Space) && IsGrounded) {
			rb.AddForce(Vector3.up * 2000);
		}

		if(Input.GetKey(KeyCode.Escape)) {
			Application.Quit ();
		}
	}

	void OnCollisionStay (Collision collisionInfo) {

		IsGrounded = true;
	}

	void OnCollisionExit (Collision collisionInfo) {

		IsGrounded = false;
	}
}
