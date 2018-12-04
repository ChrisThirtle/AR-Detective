using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.

public class PopulateQuestion : MonoBehaviour
{

    public Text AnswerOneText = null;
    public Text AnswerTwoText = null;
    public Text AnswerThreeText = null;
    public Text AnswerFourText = null;
    public Text QuestionText = null;
    public static QuestionsGenerator QG = new QuestionsGenerator();
    public QuizQuestion CurrentQuestion;
    public List<float> AnswerRatings = new List<float>();
    public int ClueIndex = 0;
    public TextAsset Answers = null;
    public TextAsset Questions = null;
    public List<GameObject> ClueList = new List<GameObject>();

    void Start()
    {
        NextQuestion();
    }

    void Update()
    {

    }

    // This method is called every time an answer is given, based on the question number asked, it will return a QuizQuestion value
    void NextQuestion()
    {
        // Get QuizQuestion based on shuffled clues found
        // index into shuffled clues and pull that key and get its value from the dictionary
        // Get next clue from collected clue and create a question based on it

        GameObject CurrentClue = GlobalVars.Instance.CollectedClues[ClueIndex];
        //GameObject CurrentClue = ClueList[ClueIndex];
        CurrentQuestion = QG.CreateQuestion(CurrentClue);
        ReshuffleAnswer(CurrentQuestion.Answers);
        QuestionText.text = CurrentQuestion.QuestionStr;
        AnswerOneText.text = CurrentQuestion.Answers[0].AnswerString;
        AnswerTwoText.text = CurrentQuestion.Answers[1].AnswerString;
        AnswerThreeText.text = CurrentQuestion.Answers[2].AnswerString;
        AnswerFourText.text = CurrentQuestion.Answers[3].AnswerString;
        Canvas.ForceUpdateCanvases();
    }

    public void Clicked(Text b)
    {
        GameObject CurrentClue = GlobalVars.Instance.CollectedClues[ClueIndex];
        string ClueDescription = CurrentClue.GetComponent<Clue>().description;
        ClueIndex++;
        if (ClueDescription.Contains(b.text))  //GlobalVars.Instance.suspects[4].fullName)
        {
            AnswerRatings.Add(1);
        }
        else
        {
            AnswerRatings.Add(0.2f);
        }


        // Check if all questions asked have been answered
        if (ClueIndex == 4)      //(GlobalVars.Instance.CollectedClues.Count))
        {
            CalculateAnswerRatings();
            Destroy(this);
            return;
        }
        NextQuestion();
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

    void CalculateAnswerRatings()
    {
        float AnswersEvaluation = 0;
        for (int i = 0; i < AnswerRatings.Count; i++)
        {
            AnswersEvaluation += AnswerRatings[i];
        }
        GlobalVars.Instance.FinalScore = AnswersEvaluation;
        SceneManager.LoadSceneAsync("Credits");
    }
}


//    void ReshuffleClue(int[] CurrentCluesSet)
//    {
//        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
//        for (int t = 0; t < CurrentCluesSet.Length; t++)
//        {
//            int tmp = CurrentCluesSet[t];
//            int r = Random.Range(t, CurrentCluesSet.Length);
//            CurrentCluesSet[t] = CluesFound[r];
//            CurrentCluesSet[r] = tmp;
//        }
//    }


