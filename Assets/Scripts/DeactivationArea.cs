using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationArea : MonoBehaviour
{

    public GameObject activationObject;


    private void OnTriggerEnter(Collider other)
    {
        activationObject.SetActive(true);
    }

}
