using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_TempleMulti_CheckBun_Praying : MonoBehaviour
{
    public bool checkBun_Praying = false;

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
        if (other.name == "BunToken01" || other.name == "BunToken02")
        {
            checkBun_Praying = true;

            Debug.Log("***** BUN PRAYING ***** " + checkBun_Praying);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        checkBun_Praying = false;
    }

}
