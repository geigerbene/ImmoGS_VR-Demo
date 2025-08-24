using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCountdown : MonoBehaviour
{
    // Time (in seconds) for which the object is active
    public float activateTime = 10;


    // Update is called once per frame
    void Update()
    {
        // Decrease the time for which the object is active for evewry passing second
        // Deactivate the object, when the time is over
        if (activateTime > 0)
        {
            activateTime -= Time.deltaTime;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
