using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	// Time related
	public float time_until_spawn_change;
	public float restrictDist;
	public float min_time_between_spawns;
	public bool constant_time = true;
	// Spawn position
	public int min_spawn_x_pos = 0;
	public int max_spawn_x_pos = 0;
	private float previous_x_pos; //we will use this to make sure next obj spawn isn't near the last obj's location
	private float next_spawn_time;

	public GameObject Structure;

	public float obj_scroll_speed = 0f;


	void Start ()
	{
		next_spawn_time = 0;
	}

	void Update ()
	{
		

		if (Time.time > next_spawn_time)
		{
			SpawnItem ();
			if (constant_time == false && time_until_spawn_change > min_time_between_spawns)
			{
				time_until_spawn_change = time_until_spawn_change - 0.05f;
			}
		}
	}

	void SpawnItem()
	{
		int new_x_pos = Random.Range (min_spawn_x_pos, max_spawn_x_pos);
		while (previous_x_pos == new_x_pos) // never spawn obstacle in same position twice
		{
			new_x_pos = Random.Range (min_spawn_x_pos, max_spawn_x_pos);	
		}
		previous_x_pos = new_x_pos;
		transform.position = new Vector3 (new_x_pos, transform.position.y);

		next_spawn_time = Time.time + time_until_spawn_change; //update time until next spawn

		GameObject spawnedGarbage = (GameObject)Instantiate(Structure, transform.position, transform.rotation);
		//	set obj move speed
		FloatingObject float_obj = spawnedGarbage.GetComponent<FloatingObject> ();
		float_obj.mov_speed = obj_scroll_speed;
	}

}
