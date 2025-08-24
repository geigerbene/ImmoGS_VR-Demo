using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Award : MonoBehaviour
{
    public float sceneTransitionTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneTransitionTime > 0)
        {
            sceneTransitionTime -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("01_PrivateArea");
        }
    }
}
