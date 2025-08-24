using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_TempleSingle_Kwan_Head : MonoBehaviour
{

    public GameObject kwan_happy;
    public GameObject kwan_unhappy;
    public GameObject uiHead;
    public GameObject uiDontTouchHead;

    public AudioSource audio_dontTouchMyHead;

    public float delayTime_UI;

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
        kwan_happy.SetActive(true);
        kwan_unhappy.SetActive(true);
        uiHead.SetActive(true);

        Invoke("playAudio", delayTime_UI);
    }

    private void OnTriggerExit(Collider other)
    {
        kwan_happy.SetActive(false);
        kwan_unhappy.SetActive(false);
        uiHead.SetActive(false);
        uiDontTouchHead.SetActive(false);
    }

    private void playAudio()
    {
        audio_dontTouchMyHead.Play();
        uiDontTouchHead.SetActive(true);
    }

}
