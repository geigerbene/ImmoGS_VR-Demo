using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_TempleMulti_CheckKwan_FlowerGarland : MonoBehaviour
{
    public bool checkKwan_FlowerGarland = false;

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
            checkKwan_FlowerGarland = true;

            Debug.Log("***** KWAN FLOWER ***** " + checkKwan_FlowerGarland);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        checkKwan_FlowerGarland = false;
    }

}
