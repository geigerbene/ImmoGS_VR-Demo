using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateUI_Multi : MonoBehaviour
{
    public float countdown;
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown > 0)
        {
            countdown -= Time.deltaTime;
        }

        if(countdown <= 0)
        {
            ui.transform.position = new Vector3(-100, 0, 0);
        }
    }
}
