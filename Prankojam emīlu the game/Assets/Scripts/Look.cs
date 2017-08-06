using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look : MonoBehaviour {

	public float mouseSensitivity = 1000.0f;
	public float clampAngle = 80.0f;

	public Slider slider;

	float rotY = 0.0f;
	float rotX = 0.0f;

	void Start() {
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
	}

	void Update() {

		Rigidbody rb = GetComponent<Rigidbody> ();

		float mouseX = Input.GetAxis ("MouseX");
		float mouseY = - Input.GetAxis ("MouseY"); 

		rotY += mouseX * slider.value * Time.deltaTime;
		rotX += mouseY * slider.value * Time.deltaTime;

		rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0.0f);
		transform.rotation = localRotation;

		if (rb) {
			rb.freezeRotation = true;
		}
	}
}
