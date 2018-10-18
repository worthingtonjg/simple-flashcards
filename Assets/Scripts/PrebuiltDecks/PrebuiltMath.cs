using System.Collections.Generic;

public class PrebuiltMath
{
    public Dictionary<string, string> Result { get; set; }

    public PrebuiltMath()
    {
        Result = new Dictionary<string, string>();

        Addition1();
        Addition2();
        Subtraction();
        MultiplicationBySet("Math - Multiplcation (2's)", 2);
        MultiplicationBySet("Math - Multiplcation (3's)", 3);
        MultiplicationBySet("Math - Multiplcation (4's)", 4);
        MultiplicationBySet("Math - Multiplcation (5's)", 5);
        MultiplicationBySet("Math - Multiplcation (6's)", 6);
        MultiplicationBySet("Math - Multiplcation (7's)", 7);
        MultiplicationBySet("Math - Multiplcation (8's)", 8);
        MultiplicationBySet("Math - Multiplcation (9's)", 9);
        MultiplicationBySet("Math - Multiplcation (10's)", 10);
        MultiplicationBySet("Math - Multiplcation (11's)", 11);
        MultiplicationBySet("Math - Multiplcation (12's)", 12);
        Multiplication();
        Division();
    }

    public void Addition1()
    {
        string delimited = string.Empty;
        
        for(int x = 0; x <= 12; x++)
        {
            for(int y = 0; y <= 12; y++)
            {
                if(x+y <= 10)
                {
                    delimited += x.ToString() + " + " + y.ToString() + "\n";
                }
            }
        }

        Result.Add("Math - Addition Easy", delimited);
    }


    public void Addition2()
    {
        string delimited = string.Empty;
        
        for(int x = 0; x <= 12; x++)
        {
            for(int y = 0; y <= 12; y++)
            {
                if(x+y > 10 && x+y <= 20)
                {
                    delimited += x.ToString() + " + " + y.ToString() + "\n";
                }
            }
        }

        Result.Add("Math - Addition Intermediate", delimited);
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

    public void MultiplicationBySet(string name, int set)
    {
        string delimited = string.Empty;
        
        for(int y = 0; y <= 12; y++)
        {
            delimited += set.ToString() + " x " + y.ToString() + "\n";
        }

        Result.Add(name, delimited);
    }

    public void Division()
    {
        string delimited = string.Empty;
        
        for(int x = 2; x <= 144; x++)
        {
            for(int y = 2; y <= 12; y++)
            {
                if(x % y == 0 && x != y && x / y <= 12)
                {
                    delimited += x.ToString() + " % " + y.ToString() + "\n";
                }
            }
        }

        Result.Add("Math - Division", delimited);
    }

}
