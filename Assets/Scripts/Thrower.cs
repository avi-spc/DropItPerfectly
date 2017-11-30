using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thrower : MonoBehaviour {

	public Rigidbody2D thrower;
	int forcePower=100;
	public GameObject g;
	private GameScript gs;
	public GameObject restart;
	public AudioClip bouHit;
	// Use this for initialization

	void Start () {
		thrower = GetComponent<Rigidbody2D> ();
		gs = g.GetComponent<GameScript> ();
		restart.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		Fire ();
		MouseFacing ();
	}

	void Fire(){
		if (Input.GetKey (KeyCode.Space)) {
			thrower.AddForce(transform.up * forcePower);
		}
	}

	void MouseFacing(){
		Vector3 mouPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector2 mouPos2D = new Vector2 (mouPos.x - transform.position.x, mouPos.y - transform.position.y);

		transform.up = mouPos2D;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Boundaries")) {
			gs.hitsDone++;
			GetComponent<AudioSource> ().PlayOneShot (bouHit);
		}

		if (col.gameObject.CompareTag ("Boundaries") && gs.hitsDone == gs.ranNum) {
			gs.message.text = "Focus more";
			restart.SetActive (true);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (gs.hitsDone == gs.ranNum-1) {
			if (col.gameObject.CompareTag ("Target")) {
				gs.message.text = "You are fantastic";
				restart.SetActive (true);
				gs.hitsDone++;
				gs.hasWon = true;
				Destroy (gameObject);
			}
		} 

		else if (gs.hitsDone < gs.ranNum || gs.hitsDone > gs.ranNum) {
			if (col.gameObject.CompareTag ("Target")) {
				gs.message.text = "Focus more";
				restart.SetActive (true);
				gs.hasLost = true;
				Destroy (gameObject);
			}
			else if (!col.gameObject.CompareTag ("Target")) {
				gs.message.text = "Focus more";
				restart.SetActive (true);
			}
		}
	}
}
