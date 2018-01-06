using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public HealthBar Health_bar;
	public float health;
	[HideInInspector]
	public bool super_beaver = false;

	void Start ()
	{
		Health_bar.max_health = (float)health;
		Health_bar.SetHealthUI ((float)health);
	}


	void Update ()
	{
		if (health <= 0)
		{
			Time.timeScale = 0;
		}
	}


	public void TakeDamage (int damage)
	{
		health = health - damage;
		Health_bar.SetHealthUI ((float)health);
	}
}