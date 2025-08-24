using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_FloatingMarketMulti : MonoBehaviour
{

    public bool check_WaterA_onSideB = false;
    public bool check_BookA_onSideB = false;
    public bool check_RiceA_onSideB = false;
    public bool check_ShirtA_onSideB = false;

    public bool check_WaterB_onSideA = false;
    public bool check_BookB_onSideA = false;
    public bool check_RiceB_onSideA = false;
    public bool check_ShirtB_onSideA = false;


    public GameObject award;
    public GameObject audioManager;
    public GameObject exerciseUI;


    public GameObject WaterA;
    public GameObject WaterB;

    public GameObject RiceA;
    public GameObject RiceB;

    public GameObject BookA;
    public GameObject BookB;

    public GameObject ShirtA;
    public GameObject ShirtB;



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


        if (check_WaterA_onSideB == true && check_BookA_onSideB == true && check_RiceA_onSideB == true && check_ShirtA_onSideB == true   &&   check_WaterB_onSideA == true && check_BookB_onSideA == true && check_RiceB_onSideA == true && check_ShirtB_onSideA == true)
        {
            Debug.Log("***** HAT GEKLAPPT! *****");

            // Import
            award.transform.position = Vector3.zero;


            // Export
            audioManager.transform.position = new Vector3(-100, 0, 0);
            exerciseUI.transform.position = new Vector3(-100, 0, 0);
        }
        


        // Notebooks bug fix

        if(WaterA.transform.position.z > 43)
        {
            B_askFor_WaterA_checked.transform.position = transformIN_B_askFor_WaterA_checked.position;
        }

        if (WaterA.transform.position.z < 41)
        {
            B_askFor_WaterA_checked.transform.position = new Vector3(-100, 0, 0);
        }

        if (BookA.transform.position.z > 43)
        {
            B_askFor_BookA_checked.transform.position = transformIN_B_askFor_BookA_checked.position;
        }

        if (BookA.transform.position.z < 41)
        {
            B_askFor_BookA_checked.transform.position = new Vector3(-100, 0, 0);
        }

        if (RiceA.transform.position.z > 43)
        {
            B_askFor_RiceA_checked.transform.position = transformIN_B_askFor_RiceA_checked.position;
        }

        if (RiceA.transform.position.z < 41)
        {
            B_askFor_RiceA_checked.transform.position = new Vector3(-100, 0, 0);
        }

        if (ShirtA.transform.position.z > 43)
        {
            B_askFor_ShirtA_checked.transform.position = transformIN_B_askFor_ShirtA_checked.position;
        }

        if (ShirtA.transform.position.z < 41)
        {
            B_askFor_ShirtA_checked.transform.position = new Vector3(-100, 0, 0);
        }



        if (WaterB.transform.position.z < 39)
        {
            A_askFor_WaterB_checked.transform.position = transformIN_A_askFor_WaterB_checked.position;
        }

        if (WaterB.transform.position.z > 41.5)
        {
            A_askFor_WaterB_checked.transform.position = new Vector3(100, 0, 0);
        }

        if (BookB.transform.position.z < 39)
        {
            A_askFor_BookB_checked.transform.position = transformIN_A_askFor_BookB_checked.position;
        }

        if (BookB.transform.position.z > 41.5)
        {
            A_askFor_BookB_checked.transform.position = new Vector3(100, 0, 0);
        }

        if (RiceB.transform.position.z < 39)
        {
            A_askFor_RiceB_checked.transform.position = transformIN_A_askFor_RiceB_checked.position;
        }

        if (RiceB.transform.position.z > 41.5)
        {
            A_askFor_RiceB_checked.transform.position = new Vector3(100, 0, 0);
        }

        if (ShirtB.transform.position.z < 39)
        {
            A_askFor_ShirtB_checked.transform.position = transformIN_A_askFor_ShirtB_checked.position;
        }

        if (ShirtB.transform.position.z > 41.5)
        {
            A_askFor_ShirtB_checked.transform.position = new Vector3(100, 0, 0);
        }


    }
}
