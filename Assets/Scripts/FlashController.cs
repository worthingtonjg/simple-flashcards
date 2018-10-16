using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlashController : MonoBehaviour 
{
	public GameObject DisplayTextObject;
	public GameObject RemainingTextObject;
	public List<string> FlashCards;
	
	private Text displayText;
	private Text remainingText;
	private int currentCard;
	private int total;
	private List<string> yesPile;

	private List<string> noPile;


	// Use this for initialization
	void Start () 
	{
		if(LoadController.FlashCards != null && LoadController.FlashCards.Count > 0)
		{
			FlashCards = new List<string>();
			FlashCards.AddRange(LoadController.FlashCards);
		}

		displayText = DisplayTextObject.GetComponent<Text>();
		remainingText = RemainingTextObject.GetComponent<Text>();

		total = FlashCards.Count;

		yesPile = new List<string>();
		noPile = new List<string>();
		
		NextCard();
	}

	public void Yes()
	{
		if(FlashCards.Count == 0) return;

		yesPile.Add(FlashCards[currentCard]);
		FlashCards.RemoveAt(currentCard);
		
		NextCard();
	}

	public void No()
	{
		if(FlashCards.Count == 0) return;

		noPile.Add(FlashCards[currentCard]);
		FlashCards.RemoveAt(currentCard);
		
		NextCard();
	}

	private bool NextCard()
	{
		if(FlashCards.Count == 0) 
		{
			FlashCards.AddRange(noPile);
			noPile.Clear();
		}

		remainingText.text = "Remaining: " + (FlashCards.Count + noPile.Count) + " of " + total;

		if(FlashCards.Count == 0) 
		{
			SceneManager.LoadScene("Completed");
			return false;
		}

		if(LoadController.RandomizeFlashCards)
		{
			Random rand = new Random();
			currentCard = Random.Range(0, FlashCards.Count);
		}
		else
		{
			currentCard = 0;
		}

		print(currentCard);
		print(FlashCards[currentCard]);
		displayText.text = FlashCards[currentCard];

		return true;
	}

	public void ChooseDeck()
	{
		SceneManager.LoadScene("Load");
	}
}
