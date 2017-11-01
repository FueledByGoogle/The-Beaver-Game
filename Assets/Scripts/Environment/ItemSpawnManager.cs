using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
	private Vector3 originWorld;
	private Vector3 tempVector;
	private float lastXSpawnPosition; //we will use this to make sure next obj spawn isn't near the last obj's location
	private float timeUntilNextSpawn;

	//Time related
	public float timeUntilSpawnChange;
	public float moveDistance;
	public float restrictDist;

	public GameObject garbagePrefab;

	void Start () {
		timeUntilNextSpawn = 0;
		originWorld = transform.position;
	}

	void Update () {
		
		if (Time.time > timeUntilNextSpawn) {

			float newXPos = Random.Range (originWorld.x, originWorld.x + moveDistance);

			//randomize point until further than "restridctDist + lastXSpawnPosition"
			while (newXPos == lastXSpawnPosition  || newXPos > (lastXSpawnPosition - restrictDist) && newXPos < (lastXSpawnPosition + restrictDist))
			{
				newXPos = Random.Range (originWorld.x, originWorld.x + moveDistance);
			}
			lastXSpawnPosition = newXPos;

			transform.position = new Vector3 (newXPos, transform.position.y, transform.position.z); //update new position
			timeUntilNextSpawn = Time.time + timeUntilSpawnChange; //update time until next spawn

			GameObject spawnedGarbage = (GameObject)Instantiate(garbagePrefab, transform.position, transform.rotation);
		}
	}

}
