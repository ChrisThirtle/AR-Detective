using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestionsGenerator
{

    public QuizQuestion CreateQuestion(GameObject clue)
    {
        QuizQuestion question = new QuizQuestion();
        Answer ans1 = new Answer();
        Answer ans2 = new Answer();
        Answer ans3 = new Answer();
        Answer ans4 = new Answer();

        //The rating doesn't matter as it's calculated after button press
        ans1.AnswerString = GlobalVars.nameReplace("{0}");
        ans1.Rating = 0.1f;
        ans2.AnswerString = GlobalVars.nameReplace("{1}");
        ans2.Rating = 0.1f;
        ans3.AnswerString = GlobalVars.nameReplace("{2}");
        ans3.Rating = 0.1f;
        ans4.AnswerString = GlobalVars.nameReplace("{3}");
        ans4.Rating = 0.1f;

        //ans1.AnswerString = "This";
        //ans1.Rating = 0.1f;
        //ans2.AnswerString = "Better";
        //ans2.Rating = 0.1f;
        //ans3.AnswerString = "Show";
        //ans3.Rating = 0.1f;
        //ans4.AnswerString = "Up";
        //ans4.Rating = 0.1f;

        question.QuestionStr = GlobalVars.nameReplace(clue.GetComponent<Clue>().question);//nre
            
        question.Answers[0] = ans1;
        question.Answers[1] = ans2;
        question.Answers[2] = ans3;
        question.Answers[3] = ans4;

        return question;
    }
}
