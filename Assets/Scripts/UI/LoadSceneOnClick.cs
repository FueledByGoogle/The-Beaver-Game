﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadSceneByIndex(int scene_index)
	{
		SceneManager.LoadScene (scene_index);
	}
}
