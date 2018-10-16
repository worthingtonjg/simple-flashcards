using System.Collections.Generic;

public class PrebuiltMath
{
    public Dictionary<string, string> Result { get; set; }

    public PrebuiltMath()
    {
        Result = new Dictionary<string, string>();

        Addition();
        Subtraction();
        Multiplication();
        Division();
    }

    public void Addition()
    {
        string delimited = string.Empty;
        
        for(int x = 0; x <= 12; x++)
        {
            for(int y = 0; y <= 12; y++)
            {
                delimited += x.ToString() + " + " + y.ToString() + "\n";
            }
        }

        Result.Add("Math - Addition", delimited);
    }

    public void Subtraction()
    {
        string delimited = string.Empty;
        
        for(int x = 1; x <= 12; x++)
        {
            for(int y = 0; y <= 12; y++)
            {
                if(y <= x)
                {
                    delimited += x.ToString() + " - " + y.ToString() + "\n";
                }
            }
        }

        Result.Add("Math - Subtraction", delimited);
    }

    public void Multiplication()
    {
        string delimited = string.Empty;
        
        for(int x = 0; x <= 12; x++)
        {
            for(int y = 0; y <= 12; y++)
            {
                delimited += x.ToString() + " x " + y.ToString() + "\n";
            }
        }

        Result.Add("Math - Multiplication", delimited);
    }

    public void Division()
    {
        string delimited = string.Empty;
        
        for(int x = 2; x <= 144; x++)
        {
            for(int y = 2; y <= 12; y++)
            {
                if(x % y == 0 && x != y)
                {
                    delimited += x.ToString() + " % " + y.ToString() + "\n";
                }
            }
        }

        Result.Add("Math - Division", delimited);
    }

}
