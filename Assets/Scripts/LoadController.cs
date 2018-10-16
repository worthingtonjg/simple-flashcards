using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class LoadController : MonoBehaviour 
{
	public GameObject FlashCardsTextObject;

	public static List<string> FlashCards;

	private InputField flashCardsText;

	void Start()
	{
		flashCardsText = FlashCardsTextObject.GetComponent<InputField>();
	}

	public void StartGame()
	{
		string delimited = flashCardsText.text;
		print(delimited);

		string[] stringSeparators = new string[] { "\n" };
		string[] lines = delimited.Split(stringSeparators, StringSplitOptions.None);

		FlashCards = lines.ToList();

		SceneManager.LoadScene("Main");
	}
}
