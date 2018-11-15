using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestionsGenerator
{

    private static int AmountQuestions = 8;   // var holds the total number of questions we're creating
    private int AnswersFileIdx;        // var holds index into the answersFile array
    public QuizQuestion[] ListOfQuestions = new QuizQuestion[AmountQuestions];   // array of class QzQuestion holds 8 questions with answers
    public Dictionary<int, QuizQuestion> QuizQuestionDict = new Dictionary<int, QuizQuestion>();
    // public ShuffeArray Shuffler = new ShuffeArray();

// Use this for initialization
    public IDictionary<int, QuizQuestion> GenerateList (TextAsset Answers, TextAsset Questions) 
    {

        string[] AnswersFile = Answers.ToString().Split('\n');
        string[] QuestionsFile = Questions.ToString().Split('\n');

        for (int i = 0; i < AmountQuestions; i++)     // build amount of questions entered
        {
            QuizQuestion CurrentQ = new QuizQuestion();
            CurrentQ.QuestionStr = QuestionsFile[i];
            CurrentQ.Answers = new Answer[4];
            AnswersFileIdx = i * 8;         // 0,8,16... each question is 8 lines of answerFile the answer on one line, rating next
            for (int j = 0; j < 4; j++)
            {
                Answer Ans = new Answer
                {
                    AnswerString = AnswersFile[AnswersFileIdx],     // add line from file to ans property
                    Rating = float.Parse(AnswersFile[AnswersFileIdx + 1])  // next line holds the rating
                };      // create answer struct
                AnswersFileIdx += 2;    // go to next answer and rating
                CurrentQ.Answers[j] = Ans;   // save the answer to the array of the current question
            }
            QuizQuestionDict.Add(i, CurrentQ);  // add key-value pair to the Dictionary
        }
        return QuizQuestionDict;
    }

    void Reshuffle(QuizQuestion[] QuestionsList)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < QuestionsList.Length; t++)
        {
            QuizQuestion tmp = QuestionsList[t];
            int r = Random.Range(t, QuestionsList.Length);
            QuestionsList[t] = QuestionsList[r];
            QuestionsList[r] = tmp;
        }
    }
}
