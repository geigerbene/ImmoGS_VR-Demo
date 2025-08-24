using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_TempleMulti : MonoBehaviour
{
    // Socles
    public GameObject Socle_Kwan_FlowerGarland;
    public GameObject Socle_Kwan_HappyUnhappy;
    public GameObject Socle_Bun_Donation;
    public GameObject Socle_Bun_Praying;

    // Tokens
    public GameObject token_Bun_01;
    public GameObject token_Bun_02;
    public GameObject token_Kwan_01;
    public GameObject token_Kwan_02;

    // Award
    public GameObject award;


    // Export
    public GameObject audio_backgroundStandard;
    public GameObject bun01;
    // public GameObject bun02;
    // public GameObject kwan01;
    public GameObject kwan02;
    public GameObject ui_exercise;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Bun Donation: " + Socle_Bun_Donation.GetComponent<Manager_TempleMulti_CheckBun_Donation>().checkBun_Donation);
        Debug.Log("Bun Praying: " + Socle_Bun_Praying.GetComponent<Manager_TempleMulti_CheckBun_Praying>().checkBun_Praying);
        Debug.Log("Kwan Flower: " + Socle_Kwan_FlowerGarland.GetComponent<Manager_TempleMulti_CheckKwan_FlowerGarland>().checkKwan_FlowerGarland);
        Debug.Log("Kwan Head: " + Socle_Kwan_HappyUnhappy.GetComponent<Manager_TempleMulti_CheckKwan_Head>().checkKwan_Head);

        if (Socle_Bun_Donation.GetComponent<Manager_TempleMulti_CheckBun_Donation>().checkBun_Donation == true && Socle_Bun_Praying.GetComponent<Manager_TempleMulti_CheckBun_Praying>().checkBun_Praying == true && Socle_Kwan_FlowerGarland.GetComponent<Manager_TempleMulti_CheckKwan_FlowerGarland>().checkKwan_FlowerGarland == true && Socle_Kwan_HappyUnhappy.GetComponent<Manager_TempleMulti_CheckKwan_Head>().checkKwan_Head == true)
        {

            Debug.Log("***** HAT GEKLAPPT!*****");
            // *** IMPORT ***
            award.transform.position = Vector3.zero;


            // *** EXPORT ***
            audio_backgroundStandard.transform.position = new Vector3(59, 0, 0);

            bun01.transform.position = new Vector3(59, 0, 0);
            // bun02.transform.position = new Vector3(59, 0, 0);
            // kwan01.transform.position = new Vector3(59, 0, 0);
            kwan02.transform.position = new Vector3(59, 0, 0);

            ui_exercise.transform.position = new Vector3(59, 0, 0);
        }
        
    }
}
