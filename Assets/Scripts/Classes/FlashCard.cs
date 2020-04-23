using System;

[Serializable]
public class FlashCard
{
    public string CardId;
    public string Question;
    public string Answer;
    
    public FlashCard(string question, string answer)
    {
        Question = question;
        Answer = answer;
        CardId = Guid.NewGuid().ToString();
    }
}