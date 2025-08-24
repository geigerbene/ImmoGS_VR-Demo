using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_TempleSingle_Quiz : MonoBehaviour
{
    public GameObject activationArea;

    public GameObject uiQuizIntroduction;
    
    
    public GameObject uiQuizQuestion1;
    public GameObject uiQuizQuestion2;
    public GameObject uiQuizQuestion3;
    

    
    public AudioSource quizQuestionCorrect1;
    public AudioSource quizQuestionCorrect2;
    public AudioSource quizQuestionCorrect3;
    public AudioSource quizQuestionIncorrect;
    public AudioSource quizComeBack;
    

    [SerializeField] private Animator AnimatorController_TempleBunQuiz_Breakdance1990;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {

        AnimatorController_TempleBunQuiz_Breakdance1990.SetBool("Near", true);

        if (!uiQuizIntroduction.activeSelf && !uiQuizQuestion1.activeSelf && !uiQuizQuestion2.activeSelf && !uiQuizQuestion3.activeSelf)
        {
            uiQuizIntroduction.SetActive(true);
            AnimatorController_TempleBunQuiz_Breakdance1990.Play("Introduction");
        }


    }


    public void question1_ask()
    {
        AnimatorController_TempleBunQuiz_Breakdance1990.SetBool("Take Quiz?", true);
        AnimatorController_TempleBunQuiz_Breakdance1990.Play("Question 1");
    }

    public void question1_correct()
    {
        AnimatorController_TempleBunQuiz_Breakdance1990.SetBool("Correct Q1", true);
        AnimatorController_TempleBunQuiz_Breakdance1990.Play("Correct 1");
        quizQuestionCorrect1.Play();
        Invoke("question2_ask", 3);
    }

    public void question2_ask()
    {
        AnimatorController_TempleBunQuiz_Breakdance1990.Play("Question 2");
        uiQuizQuestion2.SetActive(true);
    }

    public void question2_correct()
    {
        AnimatorController_TempleBunQuiz_Breakdance1990.SetBool("Correct Q2", true);
        AnimatorController_TempleBunQuiz_Breakdance1990.Play("Correct 2");
        quizQuestionCorrect2.Play();
        Invoke("question3_ask", 3);
    }

    public void question3_ask()
    {
        AnimatorController_TempleBunQuiz_Breakdance1990.Play("Question 3");
        uiQuizQuestion3.SetActive(true);
    }

    public void question3_correct()
    {
        AnimatorController_TempleBunQuiz_Breakdance1990.SetBool("Correct Q3", true);
        AnimatorController_TempleBunQuiz_Breakdance1990.Play("Correct 3");
        quizQuestionCorrect3.Play();
        Invoke("loadScene_templeSingleAward", 3);
    }

    private void loadScene_templeSingleAward()
    {
        SceneManager.LoadScene("02_TempleSingle_Award");
    }

    public void incorrect()
    {
        AnimatorController_TempleBunQuiz_Breakdance1990.SetBool("Incorrect", true);
        AnimatorController_TempleBunQuiz_Breakdance1990.Play("Incorrect");
        quizQuestionIncorrect.Play();

        AnimatorController_TempleBunQuiz_Breakdance1990.SetBool("Near", false);
        AnimatorController_TempleBunQuiz_Breakdance1990.SetBool("Take Quiz?", false);
        AnimatorController_TempleBunQuiz_Breakdance1990.SetBool("Correct Q1", false);
        AnimatorController_TempleBunQuiz_Breakdance1990.SetBool("Correct Q2", false);
        AnimatorController_TempleBunQuiz_Breakdance1990.SetBool("Correct Q3", false);

        uiQuizQuestion1.SetActive(false);
        uiQuizQuestion2.SetActive(false);
        uiQuizQuestion3.SetActive(false);
    }


    public void dontTakeQuiz()
    {
        AnimatorController_TempleBunQuiz_Breakdance1990.SetBool("Near", false);
        AnimatorController_TempleBunQuiz_Breakdance1990.SetBool("Take Quiz?", false);

        AnimatorController_TempleBunQuiz_Breakdance1990.Play("Idle");
        quizComeBack.Play();
    }

}
