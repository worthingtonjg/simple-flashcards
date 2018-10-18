using System.Collections.Generic;
using System.Linq;

public class PrebuiltNumbers
{
    public Dictionary<string, string> Result { get; set; }

    public PrebuiltNumbers()
    {
        Result = new Dictionary<string, string>();

        CountBy("Numbers 0 to 10", 1, 0, 10);
        CountBy("Numbers 0 to 20", 1, 0, 20);
        CountBy("Numbers 0 to 100", 1, 0, 100);
        CountBy("Count by Twos", 2, 0, 100);        
        CountBy("Count by Threes", 3, 0, 100);        
        CountBy("Count by Fours", 4, 0, 100);        
        CountBy("Count by Fives", 5, 0, 100);        
        CountBy("Count by Sixes", 6, 0, 100);        
        CountBy("Count by Sevens", 7, 0, 100);        
        CountBy("Count by Eights", 8, 0, 100);        
        CountBy("Count by Nines", 9, 0, 100);        
        CountBy("Count by Tens", 10, 0, 100);        
        CountBy("Count by Hundreds", 100, 0, 1000);

    }
    
    private void CountBy(string name, int countBy, int countFrom, int countTo)
    {
        string delimited = string.Empty;
        for(int i = countFrom; i <= countTo; i++)
        {
            if(i % countBy == 0)
            {
                delimited += i.ToString() + "\n";
            }
        }
        
        Result.Add(name, delimited);
    }
}