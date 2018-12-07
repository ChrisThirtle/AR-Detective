using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public sealed class GlobalVars
{
    //Singleton declarations, makes GlobalVars a shared singleton within the program, which is quite useful given it's meant to share information between every object
    private static readonly GlobalVars instance = new GlobalVars();

    private GlobalVars() { setupVars(); }

    public static GlobalVars Instance
    {
        get
        {
            return instance;
        }
    }

    /// <summary>
    /// GameObjects wont persist in a static class,
    /// so save clue info then reinstantiate
    /// a new object with it.
    /// </summary>
    [System.Serializable]
    public struct srlzClue
    {
        public float w;
        public string name;

        public srlzClue(Clue c)
        {
            int parenIndex = c.name.IndexOf("(");//cut the "clone" out of the name
            name = c.name.Substring(0,parenIndex);
            w = c.weight;
        }

        /// <summary>
        /// if this Serialized Clue is already in scene, return its GO
        /// else, instantiate and return it.
        /// </summary>
        /// <returns>a gameobject containing this srlzClue</returns>
        public GameObject Instantiate()
        {
            GameObject existing = GameObject.Find(name);
            if (existing == null)
            {
                try
                {
                    GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("CluePrefabs/" + name));
                    return go;
                }
                catch (ArgumentException)
                {
                    Debug.Log("Resources.Load couldnt find "+name+" in CluePrefabs.");
                    return existing;
                }
                
                
            }
            else
            {
                return existing;
            }
            
        }
    }

    private string[] firstNames = {"Edward", "Lenny", "Chris", "Toby", "Evan", "Kevin", "Raphael", "Reid", "Buddy", "Michael", "Regan", "Tristan", "Leighton", "Anya", "Lauren", "Erik", "Renee", "Emmeline", "Cora", "Margot", "Faith", "Amelie", "Paisley"};
    private string[] lastNames = {"Wilkinson", "Baker", "Green", "Porter", "Gray", "Dean", "Adams", "Howard", "Miller", "Murray", "Hughes", "Parker", "Bell", "Webb", "Rees", "Knight", "Reynolds", "Mccarthy"};

    public Person victim;
    public List<Person> suspects = new List<Person>();
    public int murdererIndex;

	public bool inInventory = false;
    public List<srlzClue> CollectedClues = new List<srlzClue>();
	public int quizScore = 0;
	public float FinalScore;

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
		//Everything is random.
        murdererIndex = rng.Next(3);
		while(suspects.Count < 3)
		{
			Person nextSuspect = new Person(firstNames[rng.Next(firstNames.Length)],
									 lastNames[rng.Next(lastNames.Length)]);
			if (nextSuspect == victim) continue;
			if (suspects.Contains(nextSuspect)) continue;
			suspects.Add(nextSuspect);
		}
    }

	public static float getClueTotal()
	{
		float totalVal = 0;
		foreach (srlzClue clue in Instance.CollectedClues)
		{
			totalVal += clue.w;
		}
		return totalVal;
	}
	/// <summary>
	/// Replaces text in input string with victim and suspect names using string.Format()
	/// {0} becomes victim, {1} to {3} become suspects, {4} is the murderer
	/// </summary>
	public static string nameReplace(string input)
	{
		List<string> people = new List<string>();
		people.Add(Instance.victim.fullName);
		foreach (Person person in GlobalVars.Instance.suspects)
		{
			people.Add(person.fullName);
		}
		people.Add(GlobalVars.Instance.suspects[GlobalVars.Instance.murdererIndex].fullName);
		return string.Format(input, people.ToArray());
	}

}
