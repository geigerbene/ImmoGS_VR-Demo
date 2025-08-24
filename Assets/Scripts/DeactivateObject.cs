using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{

    public GameObject deactivationObject;
    public float activeTime;

    private void Start()
    {
        Invoke("deactivate", activeTime);

    }


    private void deactivate()
    {
        deactivationObject.SetActive(false);
    }

}
