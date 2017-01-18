using UnityEngine;
using System.Collections;

public class PauseMenuBehaviour : MainMenuBehaviour {

	public static bool isPaused;
	public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		isPaused = false;
		pauseMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp ("escape")) {
			isPaused = !isPaused;
			Time.timeScale = (isPaused) ? 0 : 1;
			pauseMenu.SetActive (isPaused);
		}
	}

	public void ResumeGame() {
		isPaused = false;
		pauseMenu.SetActive (false);
		Time.timeScale = 1;
	}
}
