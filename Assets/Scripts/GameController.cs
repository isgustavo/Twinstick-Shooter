using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Transform enemy;

	[Header("Wave Properties")]
	public float timeBeforeSwaning = 1.5f;
	public float timeBetweenEnemies = .25f;
	public float timeBeforeWaves = 2.0f;

	public int enemiesPerWave = 10;
	public int currentNumberOfEnemies = 0;

	void Start () {
		StartCoroutine (SpawnEnemies ());
	}

	IEnumerator SpawnEnemies() {

		yield return new WaitForSeconds (timeBeforeSwaning);

		while (true) {

			if (currentNumberOfEnemies <= 0) {

				for (int i = 0; i < enemiesPerWave; i++) {

					float randDistance = Random.Range (10, 25);

					Vector2 randDirection = Random.insideUnitCircle;
					Vector3 enemyPos = this.transform.position;

					enemyPos.x += randDirection.x * randDistance;
					enemyPos.y += randDirection.y * randDistance;

					Instantiate (enemy, enemyPos, this.transform.rotation);
					currentNumberOfEnemies += 1;

					yield return new WaitForSeconds (timeBetweenEnemies);

				}
			}

			yield return new WaitForSeconds (timeBeforeWaves);

		}

	}

	public void KilledEnemy() {

		currentNumberOfEnemies -= 1;

	}
}
