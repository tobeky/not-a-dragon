using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	Rigidbody nyoom; //variable for sphere
	int speed;
	// Use this for initialization
	void Start () {
		nyoom = GetComponent <Rigidbody> ();
		speed = 3;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float xMovement = Input.GetAxis ("Horizontal");
		float zMovement = Input.GetAxis ("Vertical");

		nyoom.AddForce (new Vector3 (xMovement, 0, 0)*speed); //this makes ball move along x axis
		nyoom.AddForce (new Vector3 (0, 0, zMovement)*speed); //this makes ball move along z axis
	}
}
