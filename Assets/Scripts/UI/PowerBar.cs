using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour
{
	[HideInInspector]
	public float min_power, max_power;

	public GameObject Power_Bar; //used to scale the bar indicating charging.

	void Start ()
	{
		Power_Bar.transform.localScale = new Vector3 (Power_Bar.transform.localScale.x,
													 0f,
													 Power_Bar.transform.localScale.z);
	}

	public void SetPower (float new_power)
	{

		if (new_power == 0f)
		{
			Power_Bar.transform.localScale = new Vector3 (Power_Bar.transform.localScale.x,
														 0f,
														 Power_Bar.transform.localScale.z);
		} else
		{
			//compenstates for offset of not starting from zero, so we get correcrt percentage calculation.
			float percentage_full = (new_power - min_power) / (max_power - min_power) * 1f;
			Power_Bar.transform.localScale = new Vector3 (Power_Bar.transform.localScale.x, 
														 percentage_full, 
														 Power_Bar.transform.localScale.z);	
		}


	}
}
