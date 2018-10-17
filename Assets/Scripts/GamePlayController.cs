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
	
	private Text displayText;
	private Text remainingText;
	private int total;
	private List<FlashCard> yesPile;
	private List<FlashCard> noPile;
	public FlashCard currentCard;
	public FlashCard lastCard;

	// Use this for initialization
	void Start () 
	{
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
        if (FlashCards.Count == 0) return;

        noPile.Add(currentCard);
        RemoveCurrentCard();

        NextCard();
    }

    private void RemoveCurrentCard()
    {
        FlashCards = FlashCards.Where(f => f.CardId != currentCard.CardId).ToList();
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

        displayText.text = currentCard.Text;
        remainingText.text = "Remaining: " + CardsRemaining() + " of " + total;
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
