using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	//Directional movement
	public float playerSpeed = 4.0f;

	//Current speed
	public float currentSpeed = 0.0f;

	//Last movement
	public Vector3 lastMovement = new Vector3();

	
	// Update is called once per frame
	void Update () {
	
		Rotation ();
		Movement ();

	}

	//Rotate player to face mouse
	private void Rotation() {

		Vector3 worldPos = Input.mousePosition;
		worldPos = Camera.main.ScreenToWorldPoint(worldPos);

		float dx = this.transform.position.x - worldPos.x;
		float dy = this.transform.position.y - worldPos.y;

		float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

		Quaternion rot = Quaternion.Euler(new Vector3(0,0, angle + 90));

		this.transform.rotation = rot;
	}

	//Move the player based off of keys pressed
	private void Movement() {

		Vector3 movement = new Vector3 ();

		movement.x += Input.GetAxis ("Horizontal");
		movement.y += Input.GetAxis ("Vertical");

		movement.Normalize ();

		if (movement.magnitude > 0) {

			this.currentSpeed = playerSpeed;
			this.transform.Translate (movement * Time.deltaTime * playerSpeed, Space.World);
			this.lastMovement = movement;
		} else {

			this.transform.Translate (lastMovement * Time.deltaTime * currentSpeed, Space.World);

			this.currentSpeed *= .9f;


		}

	}
}
