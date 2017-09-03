using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointScorer : MonoBehaviour
{

	public Text curr_score_text;

	void Start ()
	{
		curr_score_text.text = "Score: " + DataController.data_controller.GetHighestPlayerScore ().ToString ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "garbage")
		{
			FloatingObject garbage_hit = other.gameObject.GetComponent<FloatingObject> ();

			if (garbage_hit != null) //score updating
			{
				DataController.data_controller.UpdateCurrentScore (garbage_hit.score_point);
				if (curr_score_text != null)
				{
					curr_score_text.text = "Score: " + DataController.data_controller.curr_score.ToString ();
				}
			}
		}
		if (other.transform.root.tag != "Player") //prevents player from being destroyed by accident if it touches trigger
		{
			Destroy (other.gameObject, 2f);
		}
	}
}
