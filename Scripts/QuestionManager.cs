using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Assets.Scripts;
using System.Collections;

public class QuestionManager : MonoBehaviour
{
    public GameObject[] buttonz;
    public Text questionText;
    public Text scoreText;
    public Timer timer;
    public GameObject startButton;
    public GameObject QBF;
    public GameObject failTextField;
    public GameObject restartButton;

    private int currentQuestionIndex;
    private int score;
    private int questionOrder;
    private AudioSource audioSource;
    
    private Dictionary<int, Question> currentLevelQuestions;

    void Start()
    {
        currentQuestionIndex = 0;

        audioSource = GetComponent<AudioSource>();
        switch (PlayerPrefs.GetInt("CurrentScene"))
        {
            case 0:
                currentLevelQuestions = QuestionDrawer.ForestQuestions;
                break;
            case 2:
                currentLevelQuestions = QuestionDrawer.MountainQuestions;
                break;
            case 3:
                currentLevelQuestions = QuestionDrawer.VillageQuestions;
                break;
            default:
                Debug.Log("Not implemented");
                break;
        }
    }

    void Update()
    {
        if (timer.TimerEnded)
        {            
            OnLevelFailed();
        } 
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2);
    }

    public void LoadQuestion()
    {
        if (currentQuestionIndex == 4)
        {
            switch (PlayerPrefs.GetInt("CurrentScene"))
            {
                case 1:
                    StartCoroutine(WaitTime());
                    SceneChanger.LoadScene2();
                    break;
                case 2:
                    StartCoroutine(WaitTime());
                    SceneChanger.LoadScene3();
                    break;
                case 3:
                    StartCoroutine(WaitTime());
                    SceneChanger.LoadScene4();
                    break;
            }
        }

        startButton.SetActive(false);
        QBF.SetActive(true);

        if (currentLevelQuestions.Count == 0)
        {
            // No more questions
            return;
        }

        // Generate question choice
        Question question = currentLevelQuestions[questionOrder];

        // Set question text
        questionText.text = question.QuestionText;

        // Generate the correct answer index
        int correctAnswerIndex = Random.Range(0, currentLevelQuestions.Last().Key + 1);

        // Generate the wrong answer indices
        List<int> wrongAnswerIndices = Enumerable.Range(0, 4)
                                                .Except(new[] { correctAnswerIndex })
                                                .OrderBy(x => Random.value)
                                                .ToList();
        // Assign correct answer
        buttonz[correctAnswerIndex].GetComponentInChildren<Text>().text = question.CorrectAnswer;
        buttonz[correctAnswerIndex].GetComponent<Button>().onClick.RemoveAllListeners();
        buttonz[correctAnswerIndex].GetComponent<Button>().onClick.AddListener(() => 
        {
            OnCorrectAnswer();
        });

        for (int i = 0; i < 3; i++)
        {
            buttonz[wrongAnswerIndices[i]].GetComponentInChildren<Text>().text = question.WrongAnswers[i];
            buttonz[wrongAnswerIndices[i]].GetComponent<Button>().onClick.RemoveAllListeners();
            buttonz[wrongAnswerIndices[i]].GetComponent<Button>().onClick.AddListener(() => 
            {
                OnWrongAnswer();
            });
        }
        
        Debug.Log(currentLevelQuestions.Count + " questions left");
        questionOrder++;

        Debug.Log(questionOrder + " question order");
        Debug.Log(score + " score");
    }
    
    public void OnCorrectAnswer()
    {
        score++;
        scoreText.text = $"Score: {score}";
        LoadQuestion();
    }

    public void OnWrongAnswer()
    {
        currentQuestionIndex++;
        score--;
        scoreText.text = $"Score: {score}";
        LoadQuestion();
    }

    public void OnLevelFailed()
    { 
        failTextField.SetActive(true);
        QBF.SetActive(false);
        currentQuestionIndex++;
        score = 0;
        scoreText.text = $"Score: {score}";
        restartButton.SetActive(true);
    }
}