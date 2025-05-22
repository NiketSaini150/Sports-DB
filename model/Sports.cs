using System;
using System.Runtime.CompilerServices;

public class Sport 
{
	public int SportsID { get; set; } 
	public string SportsName { get; set; }
	


    public Sport( int sportsId, string sportsname)
	{
		SportsID = sportsId ;
		SportsName = sportsname ;
	}
}

