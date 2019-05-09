﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main_menu_buttons : MonoBehaviour {
	public Button Start;
	public Button Exit;
	public void Update() {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Start.onClick.AddListener(PlayGame);
		Exit.onClick.AddListener(ExitGame);
	}
	public void PlayGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void ExitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
		#else
        Application.Quit ();
		#endif
 	}
}
