using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
	[HideInInspector]
	public Rigidbody2D rigid_body_2D;
	[HideInInspector]
	public bool hit_by_player; // used to determine whether when coming in contact with other garbage to explode.

	[Range(0,1)]
	public int floating_obj_type;
	/* 0 = garbage
	 * 
	 */

	public int damage_to_dam;
	public int score_point;



	void Start ()
	{
		hit_by_player = false;
		rigid_body_2D = gameObject.GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		// used for when two garbage collide from player's ability
		if (hit_by_player && other.transform.tag == "Garbage")
		{
			FloatingObject other_garbage_hit = other.gameObject.GetComponent<FloatingObject> ();
			DataController.data_controller.UpdateCurrentScore ((other_garbage_hit.score_point + score_point) * 2);
			Destroy (other.gameObject, 0.2f);
			Destroy (this.gameObject, 0.2f);
		}
	}
}