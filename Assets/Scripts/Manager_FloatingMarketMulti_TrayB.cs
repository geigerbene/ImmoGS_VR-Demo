using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_FloatingMarketMulti_TrayB : MonoBehaviour
{

    public AudioSource audio_drop;

    public GameObject waterB;
    public GameObject bookB;
    public GameObject riceB;
    public GameObject shirtB;

    public GameObject waterA;
    public GameObject bookA;
    public GameObject riceA;
    public GameObject shirtA;

    public Transform waterB_onSideA;
    public Transform bookB_onSideA;
    public Transform riceB_onSideA;
    public Transform shirtB_onSideA;

    public Transform waterA_onSideA;
    public Transform bookA_onSideA;
    public Transform riceA_onSideA;
    public Transform shirtA_onSideA;

    public GameObject languageProgramManager;


    public GameObject A_askFor_RiceB_checked;
    public Transform transformIN_A_askFor_RiceB_checked;

    public GameObject A_askFor_ShirtB_checked;
    public Transform transformIN_A_askFor_ShirtB_checked;

    public GameObject A_askFor_WaterB_checked;
    public Transform transformIN_A_askFor_WaterB_checked;

    public GameObject A_askFor_BookB_checked;
    public Transform transformIN_A_askFor_BookB_checked;



    public GameObject B_askFor_RiceA_checked;
    public Transform transformIN_B_askFor_RiceA_checked;

    public GameObject B_askFor_ShirtA_checked;
    public Transform transformIN_B_askFor_ShirtA_checked;

    public GameObject B_askFor_WaterA_checked;
    public Transform transformIN_B_askFor_WaterA_checked;

    public GameObject B_askFor_BookA_checked;
    public Transform transformIN_B_askFor_BookA_checked;


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

        // ***** Play drop-audio when user drops item *****
        if (other.gameObject.layer == 9)
        {
            audio_drop.Play();
        }


        // ObjectsB from SideB to SideA


        if (other.name == "WaterB" || other.name == "Water Attach Transform B")
        {
            waterB.transform.position = waterB_onSideA.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_WaterB_onSideA = true;

            A_askFor_WaterB_checked.transform.position = transformIN_A_askFor_WaterB_checked.position;
        }

        if (other.name == "BookB" || other.name == "Book Attach Transform B")
        {
            bookB.transform.position = bookB_onSideA.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_BookB_onSideA = true;

            A_askFor_BookB_checked.transform.position = transformIN_A_askFor_BookB_checked.position;
        }

        if (other.name == "RiceB" || other.name == "Rice Attach Transform B")
        {
            riceB.transform.position = riceB_onSideA.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_RiceB_onSideA = true;

            A_askFor_RiceB_checked.transform.position = transformIN_A_askFor_RiceB_checked.position;
        }

        if (other.name == "ShirtB" || other.name == "Shirt Attach Transform B")
        {
            shirtB.transform.position = shirtB_onSideA.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_ShirtB_onSideA = true;

            A_askFor_ShirtB_checked.transform.position = transformIN_A_askFor_ShirtB_checked.position;
        }



        // ObjectsA from SideB to SideA


        if (other.name == "WaterA" || other.name == "Water Attach Transform A")
        {
            waterA.transform.position = waterA_onSideA.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_WaterA_onSideB = false;

            B_askFor_WaterA_checked.transform.position = new Vector3(-100, 0, 0);
        }

        if (other.name == "BookA" || other.name == "Book Attach Transform A")
        {
            bookA.transform.position = bookA_onSideA.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_BookA_onSideB = false;
            
            B_askFor_BookA_checked.transform.position = new Vector3(-100, 0, 0);
        }

        if (other.name == "RiceA" || other.name == "Rice Attach Transform A")
        {
            riceA.transform.position = riceA_onSideA.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_RiceA_onSideB = false;
            
            B_askFor_RiceA_checked.transform.position = new Vector3(-100, 0, 0);
        }

        if (other.name == "ShirtA" || other.name == "Shirt Attach Transform A")
        {
            shirtA.transform.position = shirtA_onSideA.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_ShirtA_onSideB = false;
            
            B_askFor_ShirtA_checked.transform.position = new Vector3(-100, 0, 0);
        }
    }

}
