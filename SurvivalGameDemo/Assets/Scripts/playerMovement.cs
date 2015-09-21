using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	Rigidbody playerRigidbody;
	public float movementSpeed = 6;
	public float turnSpeed = 6;

	Animator playerAnimator;

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody>();
		playerAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float forwardMovement = Input.GetAxis ("Vertical");
		float turnMovement = Input.GetAxis ("Horizontal");

		Vector3 movement = forwardMovement * transform.forward;
		movement = movement.normalized * Time.deltaTime * movementSpeed; 

		playerRigidbody.MovePosition (transform.position + movement);

		float currRotation = transform.rotation.eulerAngles.y; 
		float targetAngle = currRotation + turnMovement * Time.deltaTime * turnSpeed;
		Quaternion newRotation = Quaternion.Euler (new Vector3 (0, targetAngle, 0));
		playerRigidbody.MoveRotation (newRotation);

		if (forwardMovement == 0 && turnMovement == 0) {
			playerAnimator.SetBool ("isWalking", false);
		} 
		else {
			playerAnimator.SetBool ("isWalking", true);
		}
	
	}
}
