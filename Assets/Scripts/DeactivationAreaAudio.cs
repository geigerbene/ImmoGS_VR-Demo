using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivationAreaAudio : MonoBehaviour
{


    public GameObject deactivationObject;

    private void OnTriggerExit(Collider other)
    {
        deactivationObject.SetActive(false);
    }
}
