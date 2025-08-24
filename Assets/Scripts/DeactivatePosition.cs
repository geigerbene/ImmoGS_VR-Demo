using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePosition : MonoBehaviour
{
    public GameObject positionVisual;



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            positionVisual.SetActive(false);
        }

        Invoke("revisualize", 5);
    }

    private void revisualize()
    {
        positionVisual.SetActive(true);
    }

}
