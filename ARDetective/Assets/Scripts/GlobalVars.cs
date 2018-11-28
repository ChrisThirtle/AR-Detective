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

    enum gender {MALE, FEMALE}

    private string[] maleNames = {"Edward", "Lenny", "Chris", "Toby", "Evan", "Kevin", "Raphael", "Reid", "Buddy", "Michael", "Regan", "Tristan", "Leighton"};
    private string[] femaleNames = {"Anya ", "Lauren ", "Erika ", "Renee", "Emmeline ", "Cora ", "Margot ", "Faith ", "Amelie", "Paisley"};
    private string[] lastNames = {"Wilkinson", "Baker", "Green", "Porter", "Gray", "Dean", "Adams", "Howard", "Miller", "Murray", "Hughes", "Parker", "Bell", "Webb", "Rees", "Knight", "Reynolds", "Mccarthy"};

    public Victim victim;
    public List<Suspect> suspects = new List<Suspect>();
    public int murdererIndex;

    public List<Clue> CollectedClues = new List<Clue>();

    public setupVars()
    {
        Random rng = new Random();
        //Make sure list of clues is empty
        CollectedClues.RemoveRange(0, CollectedClues.Count);

        //Create a victim

        //Male 0, Female 1
        int vicGender = rng.Next() % 2;
        if(vicGender == gender.FEMALE) {
            victim = newVictim(femaleNames[rng.Next(femaleNames.Length)],
                               lastNames[rng.Next(lastNames.Length)]);
        }
        else {
            victim = newVictim(maleNames[rng.Next(maleNames.Length)],
                               lastNames[rng.Next(lastNames.Length)]);
        }

        //Fill up the suspect list with named entities, using 3 suspects for this version
        //List is structured as "spouse", "lover", "friend".
        //Simplifying to set gender ratios, every run has 2 males and 2 females, not dealing with any controversy
        murdererIndex = rng.Next(3);
        if (vicGender == gender.FEMALE) {
            suspects.Add(new Suspect(maleNames[rng.Next(maleNames.Length)],
                                     lastNames[rng.Next(lastNames.Length)],
                                     gender.MALE));
            suspects.Add(new Suspect(maleNames[rng.Next(maleNames.Length)],
                                     lastNames[rng.Next(lastNames.Length)],
                                     gender.MALE));
            suspects.Add(new Suspect(femaleNames[rng.Next(femaleNames.Length)],
                                     lastNames[rng.Next(lastNames.Length)],
                                     gender.FEMALE));
        }
        else {
            suspects.Add(new Suspect(femaleNames[rng.Next(femaleNames.Length)],
                                     lastNames[rng.Next(lastNames.Length)],
                                     gender.FEMALE));
            suspects.Add(new Suspect(maleNames[rng.Next(maleNames.Length)],
                                     lastNames[rng.Next(lastNames.Length)],
                                     gender.FEMALE));
            suspects.Add(new Suspect(maleNames[rng.Next(maleNames.Length)],
                                     lastNames[rng.Next(lastNames.Length)],
                                     gender.MALE));
        }
    }
}
