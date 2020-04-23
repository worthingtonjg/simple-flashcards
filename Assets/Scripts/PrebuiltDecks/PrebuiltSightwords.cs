using System.Collections.Generic;

public class PrebuiltSightwords
{
    public Dictionary<string, List<string>> Result { get; set; }

    public PrebuiltSightwords()
    {
        Result = new Dictionary<string, List<string>>();

        LevelA();
        LevelB();
        LevelC();
        LevelD();     
    }

    public void LevelA()
	{
		Result.Add("Sight Words - Level A", 
			new List<string> {@"am
			at
			can
			go
			is
			like
			me
			see
			the
			to", null});

	}

	public void LevelB()
	{
		Result.Add("Sight Words - Level B", 
			new List<string> {@"dad
			he
			in
			it
			look
			mom
			my
			on
			up
			we", null});
	}

	public void LevelC()
	{
		Result.Add("Sight Words - Level C", 
			new List<string> {@"and
			are
			come
			for
			got
			here
			not
			play
			said
			you", null});
	}

	public void LevelD()
	{
		Result.Add("Sight Words - Level D", 
			new List<string> {@"day
			down
			into
			looking
			she
			they
			went
			where
			will
			you", null});
	}	

	      
}
