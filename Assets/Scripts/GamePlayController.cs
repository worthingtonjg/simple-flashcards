using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GamePlayController : MonoBehaviour 
{
	public GameObject DisplayTextObject;
	public InputField AnswerInput;
	public GameObject RemainingTextObject;
	public List<FlashCard> FlashCards;
	public GameObject TimerParent;
	public GameObject Timer;
	public GameObject YesButton;
	public GameObject MathPanel;

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

	public void MathValue(int value)
	{
		AnswerInput.text += value.ToString();
	}

	public void ResetAnswer()
	{
		AnswerInput.text = string.Empty;
	}

	public void Yes()
	{
		if(FlashCards.Count == 0) return;

		bool correct = true;
		if(MathPanel.activeSelf)
		{
			if(!string.IsNullOrEmpty(AnswerInput.text) && int.Parse(AnswerInput.text) == int.Parse(currentCard.Answer.Split(' ').Last()))
			{
				correct = true;
			}
			else
			{
				correct = false;
			}
		}

		if(correct)
		{
			ResetAnswer();
			yesPile.Add(currentCard);
			RemoveCurrentCard();
		
			NextCard();
		}
		else
		{
			No();
		}
	}

	public void No()
    {
		ResetAnswer();
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
			MathPanel.SetActive(false);
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

		MathPanel.SetActive(false);
		if(!string.IsNullOrEmpty(currentCard.Answer))
		{
			var tokens = currentCard.Answer.Trim().Split(' ');
			if(int.TryParse(tokens.Last(), out int answer))
			{
				MathPanel.SetActive(true);
			}
		}
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
