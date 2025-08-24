using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_FloatingMarketMulti_TrayA : MonoBehaviour
{

    public AudioSource audio_drop;

    public GameObject waterA;
    public GameObject bookA;
    public GameObject riceA;
    public GameObject shirtA;

    public GameObject waterB;
    public GameObject bookB;
    public GameObject riceB;
    public GameObject shirtB;

    public Transform waterA_onSideB;
    public Transform bookA_onSideB;
    public Transform riceA_onSideB;
    public Transform shirtA_onSideB;

    public Transform waterB_onSideB;
    public Transform bookB_onSideB;
    public Transform riceB_onSideB;
    public Transform shirtB_onSideB;

    public GameObject languageProgramManager;

    
    public GameObject B_askFor_RiceA_checked;
    public Transform transformIN_B_askFor_RiceA_checked;

    public GameObject B_askFor_ShirtA_checked;
    public Transform transformIN_B_askFor_ShirtA_checked;

    public GameObject B_askFor_WaterA_checked;
    public Transform transformIN_B_askFor_WaterA_checked;

    public GameObject B_askFor_BookA_checked;
    public Transform transformIN_B_askFor_BookA_checked;



    public GameObject A_askFor_RiceB_checked;
    public Transform transformIN_A_askFor_RiceB_checked;

    public GameObject A_askFor_ShirtB_checked;
    public Transform transformIN_A_askFor_ShirtB_checked;

    public GameObject A_askFor_WaterB_checked;
    public Transform transformIN_A_askFor_WaterB_checked;

    public GameObject A_askFor_BookB_checked;
    public Transform transformIN_A_askFor_BookB_checked;



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




        // ObjectsA from SideA to SideB


        if (other.name == "WaterA" || other.name == "Water Attach Transform A")
        {
            waterA.transform.position = waterA_onSideB.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_WaterA_onSideB = true;

            B_askFor_WaterA_checked.transform.position = transformIN_B_askFor_WaterA_checked.position;
        }

        if (other.name == "BookA" || other.name == "Book Attach Transform A")
        {
            bookA.transform.position = bookA_onSideB.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_BookA_onSideB = true;

            B_askFor_BookA_checked.transform.position = transformIN_B_askFor_BookA_checked.position;
        }

        if (other.name == "RiceA" || other.name == "Rice Attach Transform A")
        {
            riceA.transform.position = riceA_onSideB.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_RiceA_onSideB = true;

            B_askFor_RiceA_checked.transform.position = transformIN_B_askFor_RiceA_checked.position;
        }

        if (other.name == "ShirtA" || other.name == "Shirt Attach Transform A")
        {
            shirtA.transform.position = shirtA_onSideB.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_ShirtA_onSideB = true;

            B_askFor_ShirtA_checked.transform.position = transformIN_B_askFor_ShirtA_checked.position;
        }


        // ObjectsB from SideA to SideB


        if (other.name == "WaterB" || other.name == "Water Attach Transform B")
        {
            waterB.transform.position = waterB_onSideB.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_WaterB_onSideA = false;

            A_askFor_WaterB_checked.transform.position = new Vector3(100, 0, 0);
        }

        if (other.name == "BookB" || other.name == "Book Attach Transform B")
        {
            bookB.transform.position = bookB_onSideB.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_BookB_onSideA = false;

            A_askFor_BookB_checked.transform.position = new Vector3(100, 0, 0);
        }

        if (other.name == "RiceB" || other.name == "Rice Attach Transform B")
        {
            riceB.transform.position = riceB_onSideB.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_RiceB_onSideA = false;

            A_askFor_RiceB_checked.transform.position = new Vector3(100, 0, 0);
        }

        if (other.name == "ShirtB" || other.name == "Shirt Attach Transform B")
        {
            shirtB.transform.position = shirtB_onSideB.position;
            languageProgramManager.GetComponent<Manager_FloatingMarketMulti>().check_ShirtB_onSideA = false;

            A_askFor_ShirtB_checked.transform.position = new Vector3(100, 0, 0);
        }
    }

}
