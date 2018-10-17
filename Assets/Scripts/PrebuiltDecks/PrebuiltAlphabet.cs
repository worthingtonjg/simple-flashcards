using System.Collections.Generic;

public class PrebuiltAlphabet
{
    public Dictionary<string, string> Result { get; set; }

    public PrebuiltAlphabet()
    {
        Result = new Dictionary<string, string>();

        UpperCaseAbc();    
        LowerCaseAbc();    
    }

	public void UpperCaseAbc()
	{
		Result.Add("Uppercase ABC's", 
			@"A
			B
			C
			D
			E
			F
			G
			H
			I
			J
			K
			L
			M
			N
			O
			P
			Q
			R
			S
			T
			U
			V
			W
			X
			Y
			Z");	
	}

	public void LowerCaseAbc()
	{
		Result.Add("Lowercase ABC's", 
			@"a
			b
			c
			d
			e
			f
			g
			h
			i
			j
			k
			l
			m
			n
			o
			p
			q
			r
			s
			t
			u
			v
			w
			x
			y
			z");	
	}

      
}
