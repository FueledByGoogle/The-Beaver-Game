using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataController : MonoBehaviour
{

	public static DataController data_controller;

	[HideInInspector]
	public int curr_score = 0;

	public int high_score = 0;


	void Awake ()
	{
		// Singleton design pattern
		if (data_controller == null)
		{
			data_controller = this;
			DontDestroyOnLoad (gameObject);
			Load ();
		}
		else if (data_controller != this)
		{
			Destroy (gameObject);
		}
	}

	void Start ()
	{
		
	}


	public void Save ()
	{
		
		BinaryFormatter bf = new BinaryFormatter ();
		// Store into our serializable class and put into a file
		PlayerData player_data = new PlayerData ();
		player_data.SetHighScore (high_score);

		// If data exists we should pull data and merge data, if not we create file and write.
		if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			// You can also first pull data, change the ones that need to be changed, and then write to file.
			bf.Serialize (file, player_data);
			file.Close (); // Don't forget to close the file!!
		} else
		{
			// Application.persistentDataPath is like AppData, used for storing game files where user can't get to easily.
			FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat"); // Can be .dat .banana doesn't matter!
			bf.Serialize (file, player_data);
			file.Close (); // Don't forget to close the file!!
		}

	}

	public void Load ()
	{
		// We have to make sure file exists and then attempt to read it.
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData loaded_player_data = (PlayerData)bf.Deserialize (file); // We don't know what file this is, so we need to cast it by doing (PlayerData)
			file.Close ();

			high_score = loaded_player_data.GetHighScore ();
		}
	}

	public void UpdateScore (int point)
	{
		curr_score += point;
		if (curr_score > high_score)
		{
			high_score = curr_score;
		}
	}

	public int GetHighestPlayerScore ()
	{
		return high_score;
	}

}


/* 
 * Need an object to write to a file, can't use the class above to write because it is a monobehaviour,
 * which can lead to some weird errors.
 * To solve this we the new private class that will just contain the data, specifically for this file to use.
 * 
 * This class is going to be serialized, in a nut-shell means how the system is going to organize the data
 * so it easily fits into a binary format, so this class needs to be SERIALIZABLE.
*/
[Serializable] // Tells Unity can save this to a file.
class PlayerData
{
	// All CHILD classes MUST ALSO be SERIALIZABLE.

	// For data security and good practice we use methods to do get/set.
	private int high_score;


	// We can also create constructors etc

	public void SetHighScore (int new_high_score)
	{
		high_score = new_high_score;
	}

	public int GetHighScore ()
	{
		return high_score;
	}
}
