using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public sealed class GlobalVars
{
    //Singleton declarations, makes GlobalVars a shared singleton within the program, which is quite useful given it's meant to share information between every object
    private static readonly GlobalVars instance = new GlobalVars();

    private GlobalVars() { }

    public static GlobalVars Instance
    {
        get
        {
            return instance;
        }
    }

	public bool inInventory;

	private string[] firstNames = {"Edward", "Lenny", "Chris", "Toby", "Evan", "Kevin", "Raphael", "Reid", "Buddy", "Michael", "Regan", "Tristan", "Leighton", "Anya ", "Lauren ", "Erika ", "Renee", "Emmeline ", "Cora ", "Margot ", "Faith ", "Amelie", "Paisley"};
    private string[] lastNames = {"Wilkinson", "Baker", "Green", "Porter", "Gray", "Dean", "Adams", "Howard", "Miller", "Murray", "Hughes", "Parker", "Bell", "Webb", "Rees", "Knight", "Reynolds", "Mccarthy"};

    public Person victim;
    public List<Person> suspects = new List<Person>();
    public int murdererIndex;

    public List<Clue> CollectedClues = new List<Clue>();
	public int quizScore = 0;

    public void setupVars()
    {
        System.Random rng = new System.Random();
        //Make sure list of clues is empty
        CollectedClues.RemoveRange(0, CollectedClues.Count);

        //Create a victim

        //Male 0, Female 1
        victim = new Person(firstNames[rng.Next(firstNames.Length)],
                            lastNames[rng.Next(lastNames.Length)]);

        //Fill up the suspect list with named entities, using 3 suspects for this version
        //List is structured as "spouse", "lover", "friend".
        //Simplifying to set gender ratios, every run has 2 males and 2 females, not dealing with any controversy
        murdererIndex = rng.Next(3);
        suspects.Add(new Person(firstNames[rng.Next(firstNames.Length)],
                                 lastNames[rng.Next(lastNames.Length)]));
        suspects.Add(new Person(firstNames[rng.Next(firstNames.Length)],
                                 lastNames[rng.Next(lastNames.Length)]));
        suspects.Add(new Person(firstNames[rng.Next(firstNames.Length)],
                                 lastNames[rng.Next(lastNames.Length)]));
    }

	public float getClueTotal()
	{
		float totalVal = 0;
		foreach (Clue clue in CollectedClues)
		{
			totalVal += clue.weight;
		}
		return totalVal;
	}
}
