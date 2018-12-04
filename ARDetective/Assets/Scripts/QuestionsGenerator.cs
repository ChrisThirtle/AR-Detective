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

        switch (clue.GetComponent<Clue>().name)
        {
            case "Black Journal":
                question.QuestionStr = string.Format("Who did {0} recently get in a fight with?", GlobalVars.Instance.suspects[0]);
                break;
            case "Bullet":
                question.QuestionStr = "Whose prints were found on the bullet?";
                break;
            case "Bullets":
                question.QuestionStr = "Whose prints were found on the bullets?";
                break;
            case "Casings":
                question.QuestionStr = "Whose prints were found on the casings?";
                break;
            case "Deodorant":
                question.QuestionStr = "This is whose favorite deodorant?";
                break;
            case "Flashlight":
                question.QuestionStr = string.Format("This may have belonged to {0}, but whose prints were found?", GlobalVars.Instance.suspects[0]);
                break;
            case "Gray Plate":
                question.QuestionStr = "Who recently used this?";
                break;
            case "Handgun":
                question.QuestionStr = "There were no prints found, but who was it registered to?";
                break;
            case "Handgun Magazine":
                question.QuestionStr = string.Format("The gun is registered to {0}, but who did the prints belong to?", GlobalVars.Instance.suspects[1]);
                break;
            case "Kukri":
                question.QuestionStr = string.Format("Who does this belong to?");
                break;
            case "Navy Plate":
                question.QuestionStr = "Whose prints are on this plate?";
                break;
            case "Pipe Wrench":
                question.QuestionStr = "Whose prints are all over this pipe wrench?";
                break;
            case "Red Book":
                question.QuestionStr = "Who wrote the notes on the paper in this book?";
                break;
            case "Shell":
                question.QuestionStr = "Whose prints were discovered on this shell?";
                break;
            case "Smartphone":
                question.QuestionStr = "To whom does this phone belong to?";
                break;
            case "Tanto":
                question.QuestionStr = "Who owns this knife?";
                break;
            case "Unspent Bullet":
                question.QuestionStr = "There were prints found on the unspent round, who do they belong to?";
                break;
            case "Yellow Plate":
                question.QuestionStr = "Whose prints on this yellow plate do these belonging to?";
                break;
            default:
                question.QuestionStr = "Could not switch to item";
                break;
        }

        question.Answers[0] = ans1;
        question.Answers[1] = ans2;
        question.Answers[2] = ans3;
        question.Answers[3] = ans4;

        return question;
    }
}
