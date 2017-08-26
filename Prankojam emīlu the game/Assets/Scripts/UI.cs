using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

	public Camera cam;

	public Text currentObj;
	public Text sensitivity;
	public Text pause;
	public Text pickUp;
	public Text fpsDisplay;

	public Slider slider;

	public Toggle fpsToggle;

	private string itemName;

	public bool isShowing;

	public GameObject menu;

	public Button button;
	public Button buttonToTitle;

	public Transform obj_pickup;
	public Transform obj_pos;

	private float fps;
	private string fpsString;

	private bool showfps;

	void Start() {

		menu.SetActive(false);

		showfps = fpsToggle.isOn;

		Cursor.visible = false;

		itemName = "None";
		currentObj.text = "Item: " + itemName;

		pause.enabled = false;
		sensitivity.enabled = false;
		pickUp.enabled = false;
		fpsDisplay.enabled = false;

		button.gameObject.SetActive(false);
		buttonToTitle.gameObject.SetActive(false);

		fpsToggle.gameObject.SetActive (false);

		slider.gameObject.SetActive (false);

		pickUp.text = "Pick up";

		Button quit = button.GetComponent<Button> ();
		quit.onClick.AddListener (quitfunc);
		Button toTitle = buttonToTitle.GetComponent<Button> ();
		toTitle.onClick.AddListener (Title);
	}

	void Update() {

		fps = 1.0f / Time.deltaTime;
		fpsString = fps.ToString ("F0");
		fpsDisplay.text = fpsString;

		currentObj.text = "Item: " + itemName;

		showfps = fpsToggle.isOn;

		if (showfps == true) {
			fpsDisplay.enabled = true;
		} if (showfps == false) {
			fpsDisplay.enabled = false;
		}

		if (Input.GetKey(KeyCode.Escape)) {
			Time.timeScale = 0;
			Cursor.visible = true;

			isShowing = true;
			menu.SetActive(isShowing);

			pause.enabled = true;
			sensitivity.enabled = true;
			currentObj.enabled = false;

			button.gameObject.SetActive(true);
			buttonToTitle.gameObject.SetActive(true);

			fpsToggle.gameObject.SetActive (true);

			slider.gameObject.SetActive (true);

			fpsString = "Paused";
			fpsDisplay.text = fpsString;
		}
		else {
			Time.timeScale = 1;
			Cursor.visible = false;

			isShowing = false;
			menu.SetActive(isShowing);

			pause.enabled = false;
			sensitivity.enabled = false;
			pickUp.enabled = false;
			currentObj.enabled = true;

			button.gameObject.SetActive(false);
			buttonToTitle.gameObject.SetActive(false);

			fpsToggle.gameObject.SetActive (false);

			slider.gameObject.SetActive (false);
		} 
	}

	void quitfunc() {
		Application.Quit ();
	}
	void Title() {
		SceneManager.LoadScene ("startscreen");
	}

	void PickUp() {
		obj_pickup.position = obj_pos.position;
		obj_pickup.parent = obj_pos;
	}
}
