using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public Transform explosion;
	public int health = 2;

	public AudioClip hitSound;

	void OnCollisionEnter2D(Collision2D theCollision) {

		Debug.Log ("Hit" + theCollision.gameObject.name);

		if (theCollision.gameObject.name.Contains ("Laser")) {
			LaserBehaviour laser = theCollision.gameObject.GetComponent ("LaserBehaviour") 
				as LaserBehaviour;

			health -= laser.damage;
			Destroy (theCollision.gameObject);
			GetComponent<AudioSource> ().PlayOneShot (hitSound);
			GameController controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
			controller.KilledEnemy ();
			controller.IncreaseScore (10);
		}

		if (health <= 0) {

			Destroy (gameObject);
			GameObject exploder = ((Transform)Instantiate (explosion, 
				                      this.transform.position,
				                      this.transform.rotation)).gameObject;

			Destroy (exploder, 2.0f);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
