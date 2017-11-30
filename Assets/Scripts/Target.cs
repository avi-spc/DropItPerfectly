using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	public Transform[] movePoints;
	int tspeed = 4, rspeed = 5, r;

	// Use this for initialization
	void Start () {
		
		r = Random.Range (1,9); 
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0,0,45) * rspeed * Time.deltaTime);
		if (transform.position != movePoints [r].position) {
			Vector2 pos = Vector2.MoveTowards (transform.position, movePoints [r].position, tspeed * Time.deltaTime);
			GetComponent<Rigidbody2D> ().MovePosition (pos);
		}

		else if((transform.position - movePoints [r].position).magnitude<0.01f){
			r = Random.Range (1, 9);
		}
	}
}

	

