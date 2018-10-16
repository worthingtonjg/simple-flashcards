using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedController : MonoBehaviour 
{
	public void NewGame()
	{
		SceneManager.LoadScene("Load");
	}

	public void PlayAgain()
	{
		SceneManager.LoadScene("Main");
	}
	
}
