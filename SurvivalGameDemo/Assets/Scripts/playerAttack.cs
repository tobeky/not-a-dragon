using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {

	LineRenderer bulletLine;
	Ray shootRay;
	public float timeBetweenBullets = 0.15f;
	float timer;
	AudioSource gunSound;

	// Use this for initialization
	void Start () {
		bulletLine = GetComponent<LineRenderer> ();
		gunSound = GetComponent<AudioSource> ();
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime; //gives however long it's been since the last update call
		if (Input.GetButton ("Fire") && timer >= timeBetweenBullets) {
			Shoot ();
		} else {
			DisableEffects ();
		}

	}

	void DisableEffects () {
		bulletLine.enabled = false;
	}

	void Shoot () {
		timer = 0f;
		bulletLine.enabled = true;

		gunSound.Play ();

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		RaycastHit shootHit;

		bulletLine.SetPosition (0, transform.position);

		if (Physics.Raycast (shootRay, out shootHit)) {
			//enemy takes damage
			bulletLine.SetPosition (1, shootHit.point);
		} else {
			bulletLine.SetPosition(1, shootRay.origin + shootRay.direction * 1000);
		}
	}
}
