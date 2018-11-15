using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizQuestion 
{
   
    public string QuestionStr { get; set; }     // Holds the question
    public Answer[] Answers { get; set; }       // Array that holds 4 answers and their ratings

    public override string ToString() // ToString function for debugging
    {
        string str;
        str = QuestionStr;
        foreach (Answer Ans in Answers)
        {
            str += "\n";
            str += Ans.AnswerString + "    " + Ans.Rating;
        }
        return str;
    }

}
