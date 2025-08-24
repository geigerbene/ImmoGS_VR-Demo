using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_TempleMulti_CheckBun_Donation : MonoBehaviour
{
    public bool checkBun_Donation = false;

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
            checkBun_Donation = true;

            Debug.Log("***** BUN DONATION ***** " + checkBun_Donation);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        checkBun_Donation = false;
    }

}
