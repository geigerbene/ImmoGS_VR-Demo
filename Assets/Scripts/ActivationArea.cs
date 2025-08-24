using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivationArea : MonoBehaviour
{

    public GameObject deactivationObject;


    private void OnTriggerEnter(Collider other)
    {
        deactivationObject.SetActive(false);
    }

}
