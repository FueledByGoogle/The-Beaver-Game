using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	[HideInInspector]
	public float max_health;

	public GameObject Health_bar; //used to scale the bar indicating charging.

	void Start ()
	{
		Health_bar.transform.localScale = new Vector3 (Health_bar.transform.localScale.x,
			0f,
			Health_bar.transform.localScale.z);
	}

	public void SetHealthUI (float new_health)
	{

		if (new_health == 0f)
		{
			Health_bar.transform.localScale = new Vector3 (Health_bar.transform.localScale.x,
				0f,
				Health_bar.transform.localScale.z);
		} else
		{
			//compenstates for offset of not starting from zero, so we get correcrt percentage calculation.
			float current_health_percentage = (new_health / max_health) * 1f;
			Health_bar.transform.localScale = new Vector3 ( Health_bar.transform.localScale.x,
															current_health_percentage,
															Health_bar.transform.localScale.z);
		}


	}
}