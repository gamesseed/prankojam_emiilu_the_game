using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

	[Header("Camera")]
	public Camera cam;

	[Header("Text")]
	public Text currentObj;
	public Text sensitivity;
	public Text pause;
	public Text pickUp;
	public Text fpsDisplay;
	public Text throwtext;

	[Header("Misc")]
	public Slider slider;
	public Toggle fpsToggle;
	public GameObject phone;
	public GameObject phoneS;
	public float raycast_distance;

	[Header("Buttons")]
	public Button button;
	public Button buttonToTitle;

	[Header("Booleans")]
	private bool showfps;


	private float fps;
	private string fpsString;
	private string itemName;
	private bool isThrowable = true;

	void Start() {
		phoneS.GetComponent<throwphone> ();

		phone.SetActive(false);

		showfps = fpsToggle.isOn;

		Cursor.visible = false;

		itemName = "None";
		currentObj.text = "Item: " + itemName;

		throwtext.enabled = false;
		pause.enabled = false;
		sensitivity.enabled = false;
		pickUp.enabled = false;
		fpsDisplay.enabled = false;

		button.gameObject.SetActive(false);
		buttonToTitle.gameObject.SetActive(false);

		fpsToggle.gameObject.SetActive (false);

		slider.gameObject.SetActive (false);

		Button quit = button.GetComponent<Button> ();
		quit.onClick.AddListener (quitfunc);
		Button toTitle = buttonToTitle.GetComponent<Button> ();
		toTitle.onClick.AddListener (Title);
	}

	void Update() {

		Vector3 rayOrigin = cam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

		RaycastHit hit;

		if (Physics.Raycast (rayOrigin, cam.transform.forward, out hit, raycast_distance)) {
			if (hit.collider.tag == "pickup") {
				pickUp.enabled = true;
				if (Input.GetKeyDown(KeyCode.E)) {
					phone.SetActive(true);
					hit.transform.gameObject.SetActive(false);
					throwtext.enabled = true;
				}
			}
			if (hit.collider.tag != "pickup") {
				pickUp.enabled = false;
			}
		}
		if (Input.GetButtonDown("Throw") && phone.activeSelf && isThrowable) {
			phoneS.GetComponent<throwphone>().Throw();	
			isThrowable = !isThrowable;
			throwtext.enabled = false;
		}

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
			pause.enabled = false;
			sensitivity.enabled = false;
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
		Cursor.visible = true;
	}
}
