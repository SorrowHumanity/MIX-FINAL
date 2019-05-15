using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Dialog : MonoBehaviour
{

    public Text textDisplay;
    public string[] sentences;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject questionsButton;
    public GameObject restartButton;
    public GameObject startButton;
    public GameObject answerA;
    public GameObject answerB;
    public GameObject answerC;
    public GameObject answerD;
    public Transform laserTransform;

    private int index;
    private AudioSource audioSource;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        if(sentences.Length != 0)
        {
            StartCoroutine(Type());
        }
        
    }

    void Update()
    {
        if (sentences.Length != 0)
        {
            if (textDisplay.text == sentences[index])
            {
                continueButton.SetActive(true);
            }
        }
            
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            RaycastLaser();
        }
    }

    private void RaycastLaser()
    {
        RaycastHit hit;

        if (Physics.Raycast(laserTransform.position, laserTransform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("ContinueButton"))
            {
                continueButton.GetComponent<Button>().onClick.Invoke();
            }
            else if (hit.collider.gameObject.CompareTag("QuestionsButton"))
            {
                questionsButton.GetComponent<Button>().onClick.Invoke();
            }
            else if (hit.collider.gameObject.CompareTag("StartButton"))
            {
                startButton.GetComponent<Button>().onClick.Invoke();
            }
            else if (hit.collider.gameObject.CompareTag("AnswerA"))
            {
                answerA.GetComponent<Button>().onClick.Invoke();
            }
            else if (hit.collider.gameObject.CompareTag("AnswerB"))
            {
                answerB.GetComponent<Button>().onClick.Invoke();
            }
            else if (hit.collider.gameObject.CompareTag("AnswerC"))
            {
                answerC.GetComponent<Button>().onClick.Invoke();
            }
            else if (hit.collider.gameObject.CompareTag("AnswerD"))
            {
                answerD.GetComponent<Button>().onClick.Invoke();
            }
        }                      
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("CurrentScene"));
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index])
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        audioSource.Play();

        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            questionsButton.SetActive(true);
        }
    }
}