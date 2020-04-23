using System.Collections.Generic;

public class PrebuiltMath
{
    public Dictionary<string, List<string>> Result { get; set; }

    public PrebuiltMath()
    {
        Result = new Dictionary<string, List<string>>();

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
        string questions = string.Empty;
        string answers = string.Empty;
        
        for(int x = 0; x <= 12; x++)
        {
            for(int y = 0; y <= 12; y++)
            {
                if(x+y <= 10)
                {
                    questions += $"{x} + {y}\n";
                    answers += $"{x} + {y} = {x+y}\n";
                }
            }
        }

        Result.Add("Math - Addition Easy", new List<string> {questions, answers});
    }


    public void Addition2()
    {
        string questions = string.Empty;
        string answers = string.Empty;
        
        for(int x = 0; x <= 12; x++)
        {
            for(int y = 0; y <= 12; y++)
            {
                if(x+y > 10 && x+y <= 20)
                {
                    questions += $"{x} + {y}\n";
                    answers += $"{x} + {y} = {x+y}\n";
                }
            }
        }

        Result.Add("Math - Addition Intermediate", new List<string> {questions, answers});
    }

    public void Subtraction()
    {
        string questions = string.Empty;
        string answers = string.Empty;
        
        for(int x = 1; x <= 12; x++)
        {
            for(int y = 0; y <= 12; y++)
            {
                if(y <= x)
                {
                    questions += $"{x} - {y}\n";
                    answers += $"{x} - {y} = {x-y}\n";
                }
            }
        }

        Result.Add("Math - Subtraction", new List<string> {questions, answers});
    }

    public void Multiplication()
    {
        string questions = string.Empty;
        string answers = string.Empty;
        
        for(int x = 0; x <= 12; x++)
        {
            for(int y = 0; y <= 12; y++)
            {
                    questions += $"{x} x {y}\n";
                    answers += $"{x} x {y} = {x*y}\n";
            }
        }

        Result.Add("Math - Multiplication", new List<string> {questions, answers});
    }

    public void MultiplicationBySet(string name, int set)
    {
        string questions = string.Empty;
        string answers = string.Empty;
        
        for(int y = 0; y <= 12; y++)
        {
            questions += $"{set} x {y}\n";
            answers += $"{set} x {y} = {set*y}\n";
        }

        Result.Add(name, new List<string> {questions, answers});
    }

    public void Division()
    {
        string questions = string.Empty;
        string answers = string.Empty;
        
        for(int x = 2; x <= 144; x++)
        {
            for(int y = 2; y <= 12; y++)
            {
                if(x % y == 0 && x != y && x / y <= 12)
                {
                    questions += $"{x} % {y}\n";
                    answers += $"{x} % {y} = {x%y}\n";
                }
            }
        }

        Result.Add("Math - Division", new List<string> {questions, answers});
    }

}
