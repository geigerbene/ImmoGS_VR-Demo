using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimations_FloatingMarket : MonoBehaviour
{

    [SerializeField] private Animator animationController_FloatingMarket_MaleAsian01_PullPlant, animationController_FloatingMarket_MaleAsian02_PickingFruit, AnimatorController_FemaleAsian02_TalkSitting, animationController_FloatingMarket_MaleAsian03_SittingTalking, animationController_FloatingMarket_MaleAsian04_Bartending, animationController_FloatingMarket_MaleAsian05_StandingPushing;
    // Start is called before the first frame update
    void Start()
    {
        animationController_FloatingMarket_MaleAsian01_PullPlant.Play("Pulling Plant");
        animationController_FloatingMarket_MaleAsian02_PickingFruit.Play("Picking Fruit");
        AnimatorController_FemaleAsian02_TalkSitting.Play("Sitting Talking");
        animationController_FloatingMarket_MaleAsian03_SittingTalking.Play("Sitting Talking");
        animationController_FloatingMarket_MaleAsian04_Bartending.Play("Bartending");
        animationController_FloatingMarket_MaleAsian05_StandingPushing.Play("Standing Pushing");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
