using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

		pickUp.text = "Pick up";

		Button quit = button.GetComponent<Button> ();
		quit.onClick.AddListener (quitfunc);
	}

	void Update() {

		Ray ray = cam.ScreenPointToRay(Input.mousePosition); 
		RaycastHit hit;

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
		} 

		if (Physics.Raycast (ray, out hit, 10)) {
			if (( hit.collider.gameObject.tag == "able_to_pickup" ) ) {
				Debug.Log ("hit something");
				pickUp.enabled = true;
				//obj_pickup = hit.collider.gameObject;

				if (Input.GetKey(KeyCode.E)) {
					PickUp ();
				}
			}
		}
	}

	void quitfunc() {
		Application.Quit ();
	}

	void PickUp() {
		obj_pickup.position = obj_pos.position;
		obj_pickup.parent = obj_pos;
	}
}
