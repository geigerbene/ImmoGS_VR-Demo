using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene_02TempleSingle_Kwan_FlowerGarland : MonoBehaviour
{

    public GameObject uIFlowerGarland;

    public float sceneTransitionTime;

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
        if (other.name == "RightHand Base Controller" || other.name == "LeftHand Base Controller")
        {
            uIFlowerGarland.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        uIFlowerGarland.SetActive(false);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("02_TempleSingle_Kwan_PhuangMalai");
    }
    
    public void LoadScene_02TempleKwanPhuangMalai()
    {
        // Call method to load scene after delay
        Invoke("LoadScene", sceneTransitionTime); 
    }
    
}
