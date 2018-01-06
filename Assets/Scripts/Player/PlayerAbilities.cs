using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAbilities : MonoBehaviour
{
//	[HideInInspector]
//	public float curr_tail_whip_power;
//
//
//	public float min_tail_whip_power;
//	public float max_tail_whip_power;
//	public int super_beaver_charge;
//	public PowerBar Power_Bar;
//	public Transform Selected_garbage_transform; // transform of marker that's displayed over garbage, might be better
//												 // in the future to have each garbage have its own marker that's turned on/off
//	int num_of_obj_in_hitbox = 0; // used to prevent case when two garbage enter trigger and one leaves first disabling controls
//	bool in_contact_with_garbage = false;
//	FloatingObject Garbage_hit; // stored object of garbage that enters player's hitbox.
//
//	void Start ()
//	{
//		Garbage_hit = null;
//		curr_tail_whip_power = min_tail_whip_power; // starting power
//		Power_Bar.max_power = max_tail_whip_power;
//		Power_Bar.min_power = min_tail_whip_power;
//	}
//
//	void Update ()
//	{
//		// charging tail whip ability
//		if (CrossPlatformInputManager.GetButton ("TailWhip"))
//		{
//			if (curr_tail_whip_power <= max_tail_whip_power)
//			{
//				curr_tail_whip_power += 0.15F;
//			}
//			Power_Bar.SetPower (curr_tail_whip_power);
//		}
//		SetSelectedGarbageMarker ();
//	}
//
//	void FixedUpdate ()
//	{
//		if (in_contact_with_garbage && CrossPlatformInputManager.GetButtonUp ("TailWhip") && Garbage_hit != null)
//		{
//			Garbage_hit.Rigid_body_2D.AddForce (transform.up * curr_tail_whip_power);
//
//			// reset values to starting values
//			in_contact_with_garbage = false; // makes sure force is added in only one frame
//			Garbage_hit = null;
//			curr_tail_whip_power = min_tail_whip_power; // reset tailwhip strength
//			Power_Bar.SetPower (0f);
//		}
//	}
//
//	void SetSelectedGarbageMarker () // Sets marker showing selected garbage
//	{
//		if (in_contact_with_garbage && Garbage_hit != null)
//		{
//			Selected_garbage_transform.transform.position = new Vector3 (Garbage_hit.transform.position.x,
//																		 Garbage_hit.transform.position.y + 0.5f,
//																		 Garbage_hit.transform.position.z);
//			// line below can be used for arrow pointing in direction object will be hit!!
//			//	selected_garbage_transform.transform.Rotate (new Vector3 (0f, 0f, 0f), Space.World);
//			Selected_garbage_transform.eulerAngles = new Vector3 (0f, 0f, 0f); //set rotation in world space so arrow is always straight.
//			Selected_garbage_transform.gameObject.SetActive (true);
//		} else
//		{ // disable selected garbage marker
//			Selected_garbage_transform.gameObject.SetActive (false);
//		}
//	}
//
//	void OnTriggerEnter2D (Collider2D other)
//	{
//		if (other.gameObject.tag == "Garbage")
//		{
//			Garbage_hit = other.gameObject.GetComponent<FloatingObject> ();
//			if (Garbage_hit != null)
//			{
//				num_of_obj_in_hitbox++;
//				in_contact_with_garbage = true;
//			}
//		}
//	}
//
//	void OnTriggerExit2D (Collider2D other)
//	{
//		num_of_obj_in_hitbox--;
//		if (num_of_obj_in_hitbox == 0)
//		{
//			in_contact_with_garbage = false;
//		}
//		Garbage_hit = null;
//	}
//

}