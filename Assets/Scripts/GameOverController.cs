﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour 
{
	public void NewGame()
	{
		SceneManager.LoadScene("01Menu");
	}

	public void PlayAgain()
	{
		SceneManager.LoadScene("02GamePlay");
	}
	
}
