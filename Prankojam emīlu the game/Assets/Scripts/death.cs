using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour {
	public AudioSource deathclip;

	void Start() {
		deathclip = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider collider) {
		deathfunc ();
		Debug.Log("OnTrigger");
	}

	void deathfunc() {
		deathclip.Play();
		Debug.Log ("deathfunc");
	}
}
