using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToGame(){
		SceneManager.LoadScene ("GamePlay");
	}

	public void ToMainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void Quit(){
		Application.Quit ();
	}
}
