using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	
	public Text currentObj;

	public string itemName;

	void Start() {

		if (itemName == "") {
			itemName = "Nothing";
		}

		currentObj.text = "Item: " + itemName;
	}
}
