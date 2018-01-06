using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScroller: MonoBehaviour
{
	public float scroll_speed;
	public float tile_size_z;

	private Vector3 startPos;

	void Start ()
	{
		startPos = transform.position;
	}

	void Update ()
	{
		float newPos = Mathf.Repeat (Time.time * scroll_speed, tile_size_z);
		transform.position = startPos + Vector3.down * newPos;
	}

}
