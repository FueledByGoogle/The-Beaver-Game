using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dam : MonoBehaviour
{

	public int dam_health;

	void Start ()
	{
		
	}
	
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Garbage")
		{

			FloatingObject object_hit = other.gameObject.GetComponent<FloatingObject> ();
			if (object_hit != null)
			{
				dam_health -= object_hit.damage_to_dam;
				if (dam_health <= 0) //game over, freeze time.
				{
					dam_health = 0;
					Time.timeScale = 0f;
					//reset current score for next play through.
					DataController.data_controller.curr_score = 0;
					DataController.data_controller.Save ();
				}
			}
			Destroy (other.gameObject);
		}
	}

}
