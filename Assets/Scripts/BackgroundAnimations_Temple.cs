using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimations_Temple : MonoBehaviour
{

    [SerializeField] private Animator animationController_Temple_MaleAsian01_Praying;
    // Start is called before the first frame update
    void Start()
    {
        animationController_Temple_MaleAsian01_Praying.Play("Praying");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
