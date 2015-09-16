using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movement : MonoBehaviour {
	private Rigidbody rBody; //variable for sphere
	public int speed; //makes ball speed changeable
	private int score; //establishes score variable
	public Text showScore; //creates visible score
	public Text timer; //shows time
	private int playTime; //counts the time

	// Use this for initialization
	void Start () {
		rBody = GetComponent <Rigidbody> ();
		playTime = 0;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float xMovement = Input.GetAxis ("Horizontal");
		float zMovement = Input.GetAxis ("Vertical");

		rBody.AddForce (new Vector3 (xMovement, 0, zMovement)*speed); //this makes ball move along x and z axis

	}

	void OnTriggerEnter (Collider trigger) {
		score = score + 1; //increases score by one
		showScore.text = score + " out of 4 collected"; //displays score
		trigger.gameObject.SetActive(false); //makes disappear when hit
		if(score >= 4) {
			showScore.text = "You win!"; //adds win condition
		}
	}

	void Update (){
		if (score < 4) { //only does this if score is under 4
			new WaitForSeconds (1);
			playTime = playTime + 1; //makes playTime increase every millisecond
		} 
		else {
			Time.timeScale = 0; //if score is 4 or above, it stops the game
		}
	}

	void OnGUI() {
		timer.text = "Score is " + playTime; //displays time
	}
}
