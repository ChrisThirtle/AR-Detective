using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.

public class PopulateQuestion : MonoBehaviour
{

    public Text AnswerOneText = null;
    public Text AnswerTwoText = null;
    public Text AnswerThreeText = null;
    public Text AnswerFourText = null;
    public Text QuestionText = null;
    public static QuestionsGenerator QG = new QuestionsGenerator();
    public static IDictionary<int, QuizQuestion> QuizQuestionDict = null;  // generate the dictionary
    public QuizQuestion CurrentQuestion;
    public float[] AnswerRatings = null;
    private int[] CluesFound = {0,1,3,5,6,2,4,7};
    public int ClueIndex = 0;
    public TextAsset Answers = null;
    public TextAsset Questions = null;


    void Start()
    {
        // Generate QuizQuestionDictionary
        QuizQuestionDict = QG.GenerateList(Answers,Questions);

        //  ReshuffleQ(ListOfQuestions);
        AnswerRatings = new float[CluesFound.Length];
        ReshuffleClue(CluesFound);
        NextQuestion(ClueIndex);
    }

    void Update()
    {
        QuestionText.text = CurrentQuestion.QuestionStr;
        AnswerOneText.text = CurrentQuestion.Answers[0].AnswerString;
        AnswerTwoText.text = CurrentQuestion.Answers[1].AnswerString;
        AnswerThreeText.text = CurrentQuestion.Answers[2].AnswerString;
        AnswerFourText.text = CurrentQuestion.Answers[3].AnswerString;

    }

    // This method is called every time an answer is given, based on the question number asked, it will return a QuizQuestion value
    void NextQuestion(int ClueIndex)
    {
        // Get QuizQuestion based on shuffled clues found
        // index into shuffled clues and pull that key and get its value from the dictionary
        QuizQuestionDict.TryGetValue(CluesFound[ClueIndex], out CurrentQuestion);
        ReshuffleAnswer(CurrentQuestion.Answers);

    }

    public void Clicked(int ButtonNumber)
    {
        AnswerRatings[ClueIndex] = CurrentQuestion.Answers[ButtonNumber].Rating;

        // Check if all questions asked have been answered
        if(ClueIndex == (CluesFound.Length - 1))
        {
            CalculateAnswerRatings(this.AnswerRatings);
            Destroy(this);
            return;
        }

        ClueIndex++;
        NextQuestion(ClueIndex);
        Canvas.ForceUpdateCanvases();
    }


    void ReshuffleAnswer(Answer[] CurrentAnswerSet)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < CurrentAnswerSet.Length; t++)
        {
            Answer tmp = CurrentAnswerSet[t];
            int r = Random.Range(t, CurrentAnswerSet.Length);
            CurrentAnswerSet[t] = CurrentAnswerSet[r];
            CurrentAnswerSet[r] = tmp;
        }
    }

    void ReshuffleClue(int[] CurrentCluesSet)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < CurrentCluesSet.Length; t++)
        {
            int tmp = CurrentCluesSet[t];
            int r = Random.Range(t, CurrentCluesSet.Length);
            CurrentCluesSet[t] = CluesFound[r];
            CurrentCluesSet[r] = tmp;
        }
    }

    void CalculateAnswerRatings(float[] AnswersRating)
    {
        float AnswersEvaluation = 0;
        for (int i = 0; i < AnswerRatings.Length; i++)
        {
            AnswersEvaluation += AnswerRatings[i];
        }
        Debug.Log(AnswersEvaluation.ToString());
    }
}
