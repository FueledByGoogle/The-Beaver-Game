using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
	[HideInInspector]
	public float mov_speed = 0f;

	public int damage = 0;

	void Update ()
	{
		transform.Translate (new Vector3 (0, -mov_speed));
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// used for when two garbage collide from player's ability
		if (other.gameObject.tag == "Player")
		{
			Player player = other.gameObject.GetComponent<Player> ();
			if (player != null)
			{
				player.TakeDamage (damage);
			}
		}
	}
}