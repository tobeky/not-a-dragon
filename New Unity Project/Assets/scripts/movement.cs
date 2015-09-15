using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movement : MonoBehaviour {
	private Rigidbody rbody; //variable for sphere
	public int speed; //makes ball speed changeable
	private int score; //establishes score variable
	public Text scoreshow; //creates visible score
	public Text timer; //manipulate time
	private int playtime;

	// Use this for initialization
	void Start () {
		rbody = GetComponent <Rigidbody> ();
		playtime = 0;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float xMovement = Input.GetAxis ("Horizontal");
		float zMovement = Input.GetAxis ("Vertical");

		rbody.AddForce (new Vector3 (xMovement, 0, 0)*speed); //this makes ball move along x axis
		rbody.AddForce (new Vector3 (0, 0, zMovement)*speed); //this makes ball move along z axis


	}

	void OnTriggerEnter (Collider trigger) {
		score = score + 1; //increases score by one
		scoreshow.text = score + " out of 4 collected"; //displays score
		trigger.gameObject.SetActive(false); //makes disappear when hit
		if(score >= 4) {
			scoreshow.text = "You win!";
		}
	}

	void Update (){
		if (score < 4) {
			new WaitForSeconds (1);
			playtime = playtime + 1;
		} 
		else {
			Time.timeScale = 0;
		}
	}

	void OnGUI() {
		timer.text = "Score is " + playtime;
	}
}
