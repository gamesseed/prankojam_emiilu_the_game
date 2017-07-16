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

	public Button button;

	void Start() {

		menu.SetActive(false);


		Cursor.visible = false;

		itemName = "None";
		currentObj.text = "Item: " + itemName;

		pause.enabled = false;
		sensitivity.enabled = false;

		Button quit = button.GetComponent<Button> ();
		quit.onClick.AddListener (quitfunc);
	}

	void Update() {

		currentObj.text = "Item: " + itemName;

		if (Input.GetKey(KeyCode.Escape)) {
			Time.timeScale = 0;
			Cursor.visible = true;

			isShowing = true;
			menu.SetActive(isShowing);

			pause.enabled = true;
			sensitivity.enabled = true;
		}
		else {
			Time.timeScale = 1;
			Cursor.visible = false;

			isShowing = false;
			menu.SetActive(isShowing);

			pause.enabled = false;
			sensitivity.enabled = false;
		} 
	}

	void quitfunc() {
		Application.Quit ();
	}
}
