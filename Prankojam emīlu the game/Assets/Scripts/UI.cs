using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Text currentObj;
	public Text sensitivity;
	public Text pause;

	public Slider slider;

	private string itemName;

	public bool isShowing;

	public GameObject menu;

	void Start() {

		menu.SetActive(false);


		Cursor.visible = false;

		itemName = "Nothing";
		currentObj.text = "Item: " + itemName;

		pause.enabled = false;
		sensitivity.enabled = false;

		Debug.Log (isShowing);
	}

	void Update() {

		if (Input.GetKey(KeyCode.Escape)) {
			Time.timeScale = 0;
			Cursor.visible = true;

			Debug.Log ("Pause");

			isShowing = true;
			menu.SetActive(isShowing);

			pause.enabled = true;
			sensitivity.enabled = true;
		}
		else {
			Time.timeScale = 1;
			Cursor.visible = false;

			Debug.Log ("Unpause");

			isShowing = false;
			menu.SetActive(isShowing);

			pause.enabled = false;
			sensitivity.enabled = false;
		} 
	}
}
