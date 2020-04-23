using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour 
{
	public static string SelectedDeck;

	public static List<FlashCard> FlashCards;

	public static bool RandomizeFlashCards = false;

	public static int TimerSeconds;

	public GameObject PrebuiltFlashCardsDropDown;	

	public GameObject RandomizeCheckbox;

	public GameObject TimerCheckbox;

	public GameObject TimerInput;

	public GameObject CustomFlashCardsTextObject;

	public GameObject Timer;

	public int timerDefault = 5;

	public Dictionary<string, List<string>> PrebuiltDecks;

	private Dropdown prebuiltFlashCardsDropDown;

	private Toggle randomizeCheckbox;

	private Toggle timerCheckbox;

	private InputField timerInput;

	private InputField customFlashCardsText;

	void Start()
    {
        PrebuiltDecks = new Dictionary<string, List<string>>();

        prebuiltFlashCardsDropDown = PrebuiltFlashCardsDropDown.GetComponent<Dropdown>();
        randomizeCheckbox = RandomizeCheckbox.GetComponent<Toggle>();
        timerCheckbox = TimerCheckbox.GetComponent<Toggle>();
        timerInput = TimerInput.GetComponent<InputField>();
        customFlashCardsText = CustomFlashCardsTextObject.GetComponent<InputField>();

        LoadPrebuiltCards();
		RestorePrebuiltDeckSelection();
		randomizeCheckbox.isOn = RandomizeFlashCards;
		timerCheckbox.isOn = TimerSeconds > 0;
		timerInput.text = TimerSeconds == 0 ? timerDefault.ToString() : TimerSeconds.ToString();
		TimerInput.SetActive(timerCheckbox.isOn);;
        CustomFlashCardsTextObject.SetActive(SelectedDeck == "Custom");
    }

    private void RestorePrebuiltDeckSelection()
    {
        if (!string.IsNullOrEmpty(SelectedDeck))
        {
            var option = prebuiltFlashCardsDropDown.options.FirstOrDefault(o => o.text == SelectedDeck);
            if (option != null)
            {
				prebuiltFlashCardsDropDown.value = prebuiltFlashCardsDropDown.options.IndexOf(option);
            }
        }
    }

    public void RandomizeCheckboxChanged()
	{
		RandomizeFlashCards = randomizeCheckbox.isOn;
	}

	public void TimerCheckboxChanged()
	{
		TimerInput.SetActive(timerCheckbox.isOn);;
	}

	public void PrebuiltDeckChanged()
	{
		string selectedDeck = prebuiltFlashCardsDropDown.options[prebuiltFlashCardsDropDown.value].text;
		CustomFlashCardsTextObject.SetActive(selectedDeck == "Custom");
	}

	public void StartGame()
	{
		string selectedDeck = prebuiltFlashCardsDropDown.options[prebuiltFlashCardsDropDown.value].text;
		SelectedDeck = selectedDeck;

		string questionsDelimited = string.Empty;
		string answersDelimited = string.Empty;

		if(selectedDeck == "Custom")
		{
			questionsDelimited = customFlashCardsText.text;				
		}
		else
		{
			questionsDelimited = PrebuiltDecks[selectedDeck][0];
			answersDelimited =  PrebuiltDecks[selectedDeck][1];
		}
		
		if(timerCheckbox.isOn && !string.IsNullOrEmpty(timerInput.text))
		{
			int timeInSeconds = 0;
			int.TryParse(timerInput.text, out timeInSeconds);
			if(timeInSeconds < 0) timeInSeconds = 0;
			TimerSeconds = timeInSeconds;
		}
		else
		{
			TimerSeconds = 0;
		}
		
		print(TimerSeconds);

		if(string.IsNullOrEmpty(questionsDelimited)) return;
		
		string[] stringSeparators = new string[] { "\n" };
		var questions = questionsDelimited.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();
		var answers = new List<string>();
		
		if(!string.IsNullOrEmpty(answersDelimited))
		{
			answers = answersDelimited.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();
		}
		
		FlashCards = new List<FlashCard>();
		for(int i = 0; i < questions.Count; i++)
		{
			if(i < answers.Count)
			{
				FlashCards.Add(new FlashCard(questions[i].Trim(), answers[i].Trim()));
				print($"q: {questions[i]} a: {answers[i]}");
			}
			else
			{
				FlashCards.Add(new FlashCard(questions[i], null));
			}
		}
		
		SceneManager.LoadScene("02GamePlay");
	}

	private void LoadPrebuiltCards()
	{
		Alphabet();
		SightWords();
		Numbers();
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
		PrebuiltDecks.Add("Custom", new List<string> { string.Empty });
	}	

	private void AppendResult(Dictionary<string, List<string>> dictionary)
	{
		foreach(var kvp in dictionary)
		{
			PrebuiltDecks.Add(kvp.Key, kvp.Value);
		}
	}
}
