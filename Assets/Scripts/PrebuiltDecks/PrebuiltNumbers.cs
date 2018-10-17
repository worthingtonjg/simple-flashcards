using System.Collections.Generic;

public class PrebuiltNumbers
{
    public Dictionary<string, string> Result { get; set; }

    public PrebuiltNumbers()
    {
        Result = new Dictionary<string, string>();

        Numbers0to10();    
        Numbers0to20();    
        Numbers0to100();    
    }

    private void Numbers0to10()
    {
        string delimited = string.Empty;
        for(int i = 0; i <= 10; i++)
        {
            delimited += i.ToString() + "\n";
        }

        Result.Add("Numbers 0 to 10", delimited);
    }

    private void Numbers0to20()
    {
        string delimited = string.Empty;
        for(int i = 0; i <= 20; i++)
        {
            delimited += i.ToString() + "\n";
        }

        Result.Add("Numbers 0 to 20", delimited);

    }
    private void Numbers0to100()
    {
        string delimited = string.Empty;
        for(int i = 0; i <= 100; i++)
        {
            delimited += i.ToString() + "\n";
        }

        Result.Add("Numbers 0 to 100", delimited);
    }    
}