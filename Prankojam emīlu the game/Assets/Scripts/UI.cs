using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	
	public Text currentObj;

	void Start() {
		currentObj = GetComponent<Text> ();
		currentObj.text = "None";
	}
}
