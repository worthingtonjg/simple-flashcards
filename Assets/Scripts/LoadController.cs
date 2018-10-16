using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class LoadController : MonoBehaviour 
{
	public static List<string> FlashCards;

	public static bool RandomizeFlashCards;

	public GameObject CustomFlashCardsTextObject;

	public GameObject PrebuiltFlashCardsDropDown;	

	public GameObject RandomizeCheckbox;

	private InputField customFlashCardsText;

	private Dropdown prebuiltFlashCardsDropDown;

	private Toggle randomizeCheckbox;

	public Dictionary<string, string> PrebuiltDecks;

	void Start()
	{
		PrebuiltDecks = new Dictionary<string, string>();
		RandomizeFlashCards = true;

		customFlashCardsText = CustomFlashCardsTextObject.GetComponent<InputField>();
		prebuiltFlashCardsDropDown = PrebuiltFlashCardsDropDown.GetComponent<Dropdown>();
		randomizeCheckbox = RandomizeCheckbox.GetComponent<Toggle>();

		CustomFlashCardsTextObject.SetActive(false);

		LoadPrebuiltCards();
	}

	public void RandomizeCheckboxChanged()
	{
		RandomizeFlashCards = randomizeCheckbox.isOn;
	}

	public void PrebuiltDeckChanged()
	{
		string selectedDeck = prebuiltFlashCardsDropDown.options[prebuiltFlashCardsDropDown.value].text;
		CustomFlashCardsTextObject.SetActive(selectedDeck == "Custom");
	}

	public void StartGame()
	{
		string selectedDeck = prebuiltFlashCardsDropDown.options[prebuiltFlashCardsDropDown.value].text;

		string delimited = string.Empty;

		if(selectedDeck == "Custom")
		{
			delimited = customFlashCardsText.text;				
		}
		else
		{
			delimited = PrebuiltDecks[selectedDeck];
		}
		
		print(delimited);

		if(string.IsNullOrEmpty(delimited)) return;
		
		string[] stringSeparators = new string[] { "\n" };
		string[] lines = delimited.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
		FlashCards = lines.Select(s => s.Trim()).ToList();
	
		SceneManager.LoadScene("Main");
	}

	private void LoadPrebuiltCards()
	{
		Alphabet();
		Numbers();
		SightWords();
		Math();
		Custom();

		prebuiltFlashCardsDropDown.ClearOptions();
		prebuiltFlashCardsDropDown.AddOptions(PrebuiltDecks.Keys.ToList());
	}

	private void Alphabet()
	{
		var prebuiltAlphabet = new PrebuiltAlphabet();
		AppendResult(prebuiltAlphabet.Result);
	}

	private void Numbers()
	{
		var prebuiltNumbers = new PrebuiltNumbers();
		AppendResult(prebuiltNumbers.Result);
	}

	private void SightWords()
	{
		var prebuiltSightwords = new PrebuiltSightwords();
		AppendResult(prebuiltSightwords.Result);
	}

	private void Math()
	{
		var prebuiltMath = new PrebuiltMath();
		AppendResult(prebuiltMath.Result);
	}

	private void Custom()
	{
		PrebuiltDecks.Add("Custom", string.Empty);
	}	

		private void AppendResult(Dictionary<string, string> dictionary)
	{
		foreach(var kvp in dictionary)
		{
			PrebuiltDecks.Add(kvp.Key, kvp.Value);
		}
	}
}
