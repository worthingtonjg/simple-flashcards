using System.Collections.Generic;

public class PrebuiltSightwords
{
    public Dictionary<string, string> Result { get; set; }

    public PrebuiltSightwords()
    {
        Result = new Dictionary<string, string>();

        LevelA();
        LevelB();
        LevelC();
        LevelD();     
    }

    public void LevelA()
	{
		Result.Add("Sight Words - Level A", 
			@"am
			at
			can
			go
			is
			like
			me
			see
			the
			to");

	}

	public void LevelB()
	{
		Result.Add("Sight Words - Level B", 
			@"dad
			he
			in
			it
			look
			mom
			my
			on
			up
			we");
	}

	public void LevelC()
	{
		Result.Add("Sight Words - Level C", 
			@"and
			are
			come
			for
			got
			here
			not
			play
			said
			you");
	}

	public void LevelD()
	{
		Result.Add("Sight Words - Level D", 
			@"day
			down
			into
			looking
			she
			they
			went
			where
			will
			you");
	}	

	      
}
