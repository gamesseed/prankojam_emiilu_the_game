using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Startscreen : MonoBehaviour {

	public Button QuitB;
	public Button StartB;

	void Start() {
		Cursor.visible = true;

		Button quit = QuitB.GetComponent<Button> ();
		quit.onClick.AddListener (Quit);

		Button start = StartB.GetComponent<Button> ();
		start.onClick.AddListener (StartGame);
	}

	void Quit() {
		Application.Quit ();
	}
	void StartGame() {
		SceneManager.LoadScene ("game");
	}
}
