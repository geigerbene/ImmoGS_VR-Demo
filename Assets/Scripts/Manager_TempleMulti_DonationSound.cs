using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_TempleMulti_DonationSound : MonoBehaviour
{

    public AudioSource audio_donation;
    public const float countDown_const = 3;

    private float countDown;


    // Start is called before the first frame update
    void Start()
    {
        countDown = countDown_const;
    }

    // Update is called once per frame
    void Update()
    {
     
        if(countDown > 0)
        {
            countDown -= Time.deltaTime;
        }

        if(countDown <= 0)
        {
            audio_donation.Play();
            countDown = countDown_const;
        }

    }
}
