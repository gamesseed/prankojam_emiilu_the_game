using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Startscreen : MonoBehaviour {

	[Header("Buttons")]
	public Button QuitB;
	public Button StartB;

	[Header("Music")]
	public AudioClip[] music;
	public AudioSource source;

	void Start() {
		int randaudio = Random.Range (0, music.Length);
		source.PlayOneShot(music[randaudio]);

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
