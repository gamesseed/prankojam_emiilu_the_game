using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwphone : MonoBehaviour {
	public Rigidbody phonerb;
	public float force;

	void Start() {
		phonerb = GetComponent<Rigidbody> ();
		phonerb.isKinematic = true;
	}
	public void Throw() {
		transform.parent = null;
		phonerb.isKinematic = false;
		phonerb.AddForce (Camera.main.transform.forward * force);
	}
}
