using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

	public int ranNum;
	public Text randomNum, hitsL, message;
	public int hitsDone;
	public AudioClip win,lose;
	public bool hasWon,hasLost;

	// Use this for initialization
	void Start () {
		ranNum = Random.Range (1, 20);
		randomNum.text = ranNum.ToString()+"th";
		hitsDone = 0;
		hasWon = false;
		hasLost = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (hasWon == true) {
			GetComponent<AudioSource> ().PlayOneShot (win);
			hasWon = false;
		}
		if (hasLost == true) {
			GetComponent<AudioSource> ().PlayOneShot (lose);
			hasLost = false;
		}
		hitsL.text = hitsDone.ToString();
	}
}
