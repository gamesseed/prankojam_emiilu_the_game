using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	
	public Text currentObj;
	public Text quit;

	public string itemName;

	void Start() {

		quit.enabled = false;

		if(Input.GetKey(KeyCode.Escape)) {
			quit.enabled = true;
		}

		if (itemName == "") {
			itemName = "Nothing";
		}

		currentObj.text = "Item: " + itemName;
	}
}
