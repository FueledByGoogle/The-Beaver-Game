using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
	[HideInInspector]
	public Rigidbody2D rigid_body_2D;

	[Range(0,1)]
	/*
	 *  0 = garbage (negatively impacts player)
	 *  1 = trees/branches (postively impacts player)
	 */
	public int objectType;
	public int damage_to_dam;
	public int score_point;

	void Start ()
	{
		rigid_body_2D = gameObject.GetComponent<Rigidbody2D> ();
	}
}