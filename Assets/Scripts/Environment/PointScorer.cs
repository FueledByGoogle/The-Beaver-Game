using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointScorer : MonoBehaviour
{
	public Text curr_score_text;
	public Text high_score_text;

	private int curr_score = 0;
	private DataController data_controller;

	void Start ()
	{
		data_controller = GameObject.Find ("DataController").GetComponent<DataController> ();
		if (data_controller == null)
		{
			Debug.Log ("Data controller could not be found. Stopping game");
			Time.timeScale = 0;
		}
		high_score_text.text = string.Concat ("Highscore: ", data_controller.high_score);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		FloatingObject floating_item = other.gameObject.GetComponent<FloatingObject> ();
		if (floating_item != null){
			// We only give a point if object is an obstacle, not a power boost item
			if (floating_item.tag.Equals("Obstacle"))
			{
				data_controller.UpdateScore (1);
				curr_score++;
				curr_score_text.text = string.Concat ("Current Score: ", curr_score);
			}
		}
		Destroy (other.gameObject);
	}

}