using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {
	public float mouseSensitivity = 1000.0f;
	public float clampAngle = 80.0f;

	float rotY = 0.0f;
	float rotX = 0.0f;

	void Start() {
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
	}

	void Update() {
		float mouseX = Input.GetAxis ("MouseX");
		float mouseY = - Input.GetAxis ("MouseY"); 

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0.0f);
		transform.rotation = localRotation;
	}
}
