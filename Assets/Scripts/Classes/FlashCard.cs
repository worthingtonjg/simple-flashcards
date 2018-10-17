using System;

[Serializable]
public class FlashCard
{
    public string CardId;
    public string Text;

    public FlashCard(string text)
    {
        Text = text;
        CardId = Guid.NewGuid().ToString();
    }
}