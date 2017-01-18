using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public int health = 2;

	void OnCollisionEnter2D(Collision2D theCollision) {

		Debug.Log ("Hit" + theCollision.gameObject.name);

		if (theCollision.gameObject.name.Contains ("Laser")) {
			LaserBehaviour laser = theCollision.gameObject.GetComponent ("LaserBehaviour") 
				as LaserBehaviour;

			health -= laser.damage;
			Destroy (theCollision.gameObject);
			GameController controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
			controller.KilledEnemy ();
		}

		if (health <= 0) {

			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
