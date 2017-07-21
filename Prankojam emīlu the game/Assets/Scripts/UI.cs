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

	public Slider slider;

	private string itemName;

	public bool isShowing;

	public GameObject menu;

	public Button button;

	public Transform obj_pickup; //a
	public Transform obj_pos; //b

	void Start() {

		menu.SetActive(false);


		Cursor.visible = false;

		itemName = "None";
		currentObj.text = "Item: " + itemName;

		pause.enabled = false;
		sensitivity.enabled = false;
		pickUp.enabled = false;

		pickUp.text = "Pick up";

		Button quit = button.GetComponent<Button> ();
		quit.onClick.AddListener (quitfunc);
	}

	void Update() {

		Ray ray = cam.ScreenPointToRay(Input.mousePosition); 
		RaycastHit hit;


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
			pickUp.enabled = false;
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
