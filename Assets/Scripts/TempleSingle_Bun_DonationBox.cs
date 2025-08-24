using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleSingle_Bun_DonationBox : MonoBehaviour
{


    public GameObject coin1;
    public GameObject coin2;

    public AudioSource coinDrop;


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
        if(other.name == "Coin1")
        {
            coin1.SetActive(false);
        }
        if (other.name == "Coin2")
        {
            coin2.SetActive(false);
        }

        coinDrop.Play();
    
    }
}
