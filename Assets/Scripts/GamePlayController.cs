using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GamePlayController : MonoBehaviour 
{
	public GameObject DisplayTextObject;
	public GameObject RemainingTextObject;
	public List<FlashCard> FlashCards;
	public GameObject TimerParent;
	public GameObject Timer;
	public GameObject YesButton;

	private Text displayText;
	private Text remainingText;
	private int total;
	private List<FlashCard> yesPile;
	private List<FlashCard> noPile;
	private FlashCard currentCard;
	private FlashCard lastCard;
	private float startTime;
	private float elapsedTime;
	private Image timer;

	// Use this for initialization
	void Start () 
	{
		timer = Timer.GetComponent<Image>();

		if(MenuController.TimerSeconds == 0)
		{
			TimerParent.SetActive(false);
		}

		if(MenuController.FlashCards != null && MenuController.FlashCards.Count > 0)
		{
			FlashCards = new List<FlashCard>();
			FlashCards.AddRange(MenuController.FlashCards);
		}

		displayText = DisplayTextObject.GetComponent<Text>();
		remainingText = RemainingTextObject.GetComponent<Text>();

		total = FlashCards.Count;

		yesPile = new List<FlashCard>();
		noPile = new List<FlashCard>();
		
		NextCard();

		startTime = Time.time;
	}

	void Update()
	{
		if(YesButton.activeSelf)
		{
			elapsedTime = Time.time - startTime;
			timer.fillAmount = elapsedTime / MenuController.TimerSeconds;
			
			if(MenuController.TimerSeconds > 0 && elapsedTime > MenuController.TimerSeconds)
			{
				No();
			}
		}
	}

    public void ChooseDeck()
	{
		SceneManager.LoadScene("01Menu");
	}	

	public void Yes()
	{
		if(FlashCards.Count == 0) return;

		yesPile.Add(currentCard);
		RemoveCurrentCard();
		
		NextCard();
	}

	public void No()
    {
		if(YesButton.activeSelf == false)
		{
			YesButton.SetActive(true);
			NextCard();
			return;
		}

        if (FlashCards.Count == 0) return;

        noPile.Add(currentCard);
        RemoveCurrentCard();

        ShowAnswer();
    }

    private void RemoveCurrentCard()
    {
        FlashCards = FlashCards.Where(f => f.CardId != currentCard.CardId).ToList();
    }

	private void ShowAnswer()
	{
		if(string.IsNullOrEmpty(currentCard.Answer))
		{
			print("no answer");
			NextCard();
		}
		else
		{
			YesButton.SetActive(false);
			print(currentCard.Answer);
			displayText.text = currentCard.Answer;
		}
	}

	private void NextCard()
    {
        ReloadDeck(); 
        if(CheckForGameOver()) return;

		lastCard = currentCard;

        FlashCard nextCard = FlashCards[0];
		if (FlashCards.Count > 1 && MenuController.RandomizeFlashCards)
        {
            nextCard = GetRandomCard();

			while(lastCard != null && lastCard.CardId == nextCard.CardId)
			{
				nextCard = GetRandomCard();
			}
        }
        
        currentCard = nextCard;

        displayText.text = currentCard.Question;
        remainingText.text = "Remaining: " + CardsRemaining() + " of " + total;
		startTime = Time.time;
    }

	private int CardsRemaining()
	{
		return FlashCards.Count + noPile.Count;
	}

    private FlashCard GetRandomCard()
    {
        return FlashCards[Random.Range(0, FlashCards.Count)];
    }

    private void ReloadDeck()
    {
        if (FlashCards.Count > 0) return;
        
		// Reload the cards from the no pile
		FlashCards.AddRange(noPile);
		noPile.Clear();
    }

    private bool CheckForGameOver()
    {
        if (FlashCards.Count > 0) return false;

        // If there are no more cards then we are done
		SceneManager.LoadScene("03GameOver");

		return true;
    }
}
