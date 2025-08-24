using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_TempleMulti_CheckKwan_Head : MonoBehaviour
{
    public bool checkKwan_Head = false;

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
        if (other.name == "KwanToken01" || other.name == "KwanToken02")
        {
            checkKwan_Head = true;

            Debug.Log("***** KWAN HEAD ***** " + checkKwan_Head);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        checkKwan_Head = false;
    }

}
