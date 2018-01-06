using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

	private Transform player_root_transform; //move player based on root transform, save computing?
	private int touch_count = 0;

	/*
	 *  Hard coding how much player can move
	 */

	void Start ()
	{
		player_root_transform = transform.root.transform;
	
	}

	void Update ()
	{
		if (Input.touchCount == 1) // single finger press
		{
			Touch touch = Input.touches [0];
			TouchPhase touch_phase = touch.phase;

			switch (touch.phase)
			{
			// Record initial touch position.
			case TouchPhase.Began:
					if (touch.position.x < Screen.width / 2) // left
					{
						touch_count++;
						
						if (player_root_transform.position.x - 1 > -1.46) // hard code left boundary
						{
							player_root_transform.Translate (new Vector3 (-1, 0));
						}
					} else if (touch.position.x > Screen.width / 2) // right
					{
						touch_count++;
						if (player_root_transform.position.x + 1 < 2.53) // hard code right boundary
						{
							player_root_transform.Translate (new Vector3 (1, 0));
						}
					}
				break;

				// Determine direction by comparing the current touch position with the initial one.
			case TouchPhase.Moved:

				break;

				// Report that a direction has been chosen when the finger is lifted.
			case TouchPhase.Ended:

				break;
			}

		
		}

		if (Input.touchCount == 2)
		{
			Debug.Log ("two!");
		}
	}

}