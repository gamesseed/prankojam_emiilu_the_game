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

	public bool isShowing = false;

	public GameObject menu;

	void Start() {

		menu.SetActive(false);


		Cursor.visible = false;

		itemName = "Nothing";
		currentObj.text = "Item: " + itemName;

		pause.enabled = false;
		sensitivity.enabled = false;
		slider.enabled = false;
	}

	void Update() {

		if (Input.GetKey (KeyCode.Escape)) {
			Time.timeScale = 0;
			Cursor.visible = true;

			Debug.Log ("Pause");

			isShowing = !isShowing;
			menu.SetActive(isShowing);
		}
		/*if(Input.GetKeyDown(KeyCode.Escape)) {
			Time.timeScale = 1;
			Cursor.visible = false;

			Debug.Log ("Unpause");

			isShowing = !isShowing;
			menu.SetActive(isShowing);
		} */
	}
}
