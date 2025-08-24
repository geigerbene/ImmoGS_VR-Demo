// using CSCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_FloatingMarketSingle_Intro : MonoBehaviour
{

    public AudioSource audio_hello_woman;
    public AudioSource audio_hello_man;
    public AudioSource audio_talk1_woman;
    public AudioSource audio_talk1_man;
    public AudioSource audio_talk2_woman;
    public AudioSource audio_talk2_man;


    public GameObject ui_womanGreeting;
    public GameObject ui_manGreeting;
    public GameObject ui_womantalking1;
    public GameObject ui_mantalking1;
    public GameObject ui_womantalking2_hello;
    public GameObject ui_womantalking2_khaKrap;
    public GameObject ui_mantalking2_want;
    public GameObject ui_mantalking2_water;
    public GameObject ui_mantalking2_rice;
    public GameObject ui_mantalking2_book;
    public GameObject ui_mantalking2_shirt;


    [SerializeField] private Animator FloatingMarketSingle_Intro_Woman;
    [SerializeField] private Animator FloatingMarketSingle_Intro_Man;


    // Start is called before the first frame update
    void Start()
    {
        animationWoman_idle1();
        animationMan_idle1();

        Invoke("animationWoman_wave", 2);
        Invoke("animationMan_wave", 4);

    }

    // Update is called once per frame
    void Update()
    {
        // Audio: Woman Hello
        if (FloatingMarketSingle_Intro_Woman.GetCurrentAnimatorStateInfo(0).IsName("Woman Greeting"))
        {
            if (FloatingMarketSingle_Intro_Woman.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.1)
            {
                audio_hello_woman.Play();
            }
        }

        // Audio: Man Hello
        if (FloatingMarketSingle_Intro_Man.GetCurrentAnimatorStateInfo(0).IsName("Man Greeting"))
        {
            if (FloatingMarketSingle_Intro_Man.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.1)
            {
                audio_hello_man.Play();
            }
        }


        // Audio: Woman Introduction 1
        if (FloatingMarketSingle_Intro_Woman.GetCurrentAnimatorStateInfo(0).IsName("Woman Talking 1"))
        {
            if (FloatingMarketSingle_Intro_Woman.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.1)
            {
                audio_talk1_woman.Play();
            }
        }


        // Audio: Man Introduction 1
        if (FloatingMarketSingle_Intro_Man.GetCurrentAnimatorStateInfo(0).IsName("Man Talking 1"))
        {
            if (FloatingMarketSingle_Intro_Man.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.1)
            {
                audio_talk1_man.Play();
            }
        }


        // Audio: Woman Introduction 2
        if (FloatingMarketSingle_Intro_Woman.GetCurrentAnimatorStateInfo(0).IsName("Woman Talking 2"))
        {
            if (FloatingMarketSingle_Intro_Woman.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.1)
            {
                audio_talk2_woman.Play();
            }
        }


        // Audio: Man Introduction 2
        if (FloatingMarketSingle_Intro_Man.GetCurrentAnimatorStateInfo(0).IsName("Man Talking 2"))
        {
            if (FloatingMarketSingle_Intro_Woman.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.03)
            {
                audio_talk2_man.Play();
            }
        }

    }


    private void animationWoman_idle1()
    {
        FloatingMarketSingle_Intro_Woman.Play("Woman Idle 1");
    }


    private void animationMan_idle1()
    {
        FloatingMarketSingle_Intro_Man.Play("Man Idle 1");
    }


    private void animationWoman_wave()
    {
        FloatingMarketSingle_Intro_Woman.Play("Woman Greeting");

        StartCoroutine(ActivateUI(ui_womanGreeting, 1f));

    }

    private void animationMan_wave()
    {
        FloatingMarketSingle_Intro_Man.Play("Man Greeting");

        StartCoroutine(ActivateUI(ui_manGreeting, 1f));

        Invoke("animationWoman_introduction1", 3);
    }

    private void animationWoman_introduction1()
    {

        FloatingMarketSingle_Intro_Woman.Play("Woman Talking 1");
        FloatingMarketSingle_Intro_Man.Play("Man Idle 2");
        
        deactivateUI();
        StartCoroutine(ActivateUI(ui_womantalking1, 14f));

        Invoke("animationMan_introduction1", 26);
    }

    private void animationMan_introduction1()
    {
        FloatingMarketSingle_Intro_Man.SetBool("Woman Talk 1 Finished", true);
        FloatingMarketSingle_Intro_Woman.SetBool("Woman Talk 1 Finished", true);

        FloatingMarketSingle_Intro_Man.Play("Man Talking 1");
        FloatingMarketSingle_Intro_Woman.Play("Woman Idle 2");

        deactivateUI();
        StartCoroutine(ActivateUI(ui_mantalking1, 0f));

        Invoke("animationWoman_introduction2", 12);
    }



    private void animationWoman_introduction2()
    {
        FloatingMarketSingle_Intro_Man.SetBool("Man Talk 1 Finished", true);
        FloatingMarketSingle_Intro_Woman.SetBool("Man Talk 1 Finished", true);

        FloatingMarketSingle_Intro_Woman.Play("Woman Talking 2");
        FloatingMarketSingle_Intro_Man.Play("Man Idle 3");

        deactivateUI();
        StartCoroutine(ActivateUI(ui_womantalking2_hello, 1f));
        Invoke("deactivateUI", 6.5f);
        StartCoroutine(ActivateUI(ui_womantalking2_khaKrap, 7f));

        Invoke("animationMan_introduction2", 34);
    }


    private void animationMan_introduction2()
    {
        FloatingMarketSingle_Intro_Man.SetBool("Woman Talk 2 Finished", true);
        FloatingMarketSingle_Intro_Woman.SetBool("Woman Talk 2 Finished", true);

        FloatingMarketSingle_Intro_Man.Play("Man Talking 2");
        FloatingMarketSingle_Intro_Woman.Play("Woman Idle 3");

        deactivateUI();
        StartCoroutine(ActivateUI(ui_mantalking2_want, 13.5f));
        Invoke("deactivateUI", 17f);
        StartCoroutine(ActivateUI(ui_mantalking2_water, 17.5f));
        Invoke("deactivateUI", 20f);
        StartCoroutine(ActivateUI(ui_mantalking2_rice, 20.5f));
        Invoke("deactivateUI", 23f);
        StartCoroutine(ActivateUI(ui_mantalking2_book, 23.5f));
        Invoke("deactivateUI", 26.5f);
        StartCoroutine(ActivateUI(ui_mantalking2_shirt, 27f));
        Invoke("deactivateUI", 30.5f);

        Invoke("animationMan_idle4", 39);
    }


    private void animationMan_idle4()
    {
        FloatingMarketSingle_Intro_Man.SetBool("Man Talk 2 Finished", true);

        FloatingMarketSingle_Intro_Man.Play("Man Idle 4");

        deactivateUI();

        Invoke("loadScene", 2);
    }


    IEnumerator ActivateUI(GameObject uiElement, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        uiElement.SetActive(true);
    }

    private void deactivateUI()
    {
        ui_womanGreeting.SetActive(false);
        ui_manGreeting.SetActive(false);
        ui_womantalking1.SetActive(false);
        ui_mantalking1.SetActive(false);
        ui_womantalking2_hello.SetActive(false);
        ui_womantalking2_khaKrap.SetActive(false);
        ui_mantalking2_want.SetActive(false);
        ui_mantalking2_water.SetActive(false);
        ui_mantalking2_rice.SetActive(false);
        ui_mantalking2_book.SetActive(false);
        ui_mantalking2_shirt.SetActive(false);
    }


    private void loadScene()
    {
        SceneManager.LoadScene("02_FloatingMarketSingle_Listening");
    }

}
