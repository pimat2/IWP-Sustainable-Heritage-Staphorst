using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DualTriggerCheck : MonoBehaviour
{
    public string animatorBoolString;
    public Animator gateAnimator;
    bool isFirstTriggerActive = false;
    bool isSecondTriggerActive = false;
   
   public void ActivateTrigger(int triggerNumber, bool isActive){
        if(triggerNumber  == 1){
            isFirstTriggerActive = isActive;
        }
        else if(triggerNumber == 2){
            isSecondTriggerActive = isActive;
        }
        CheckTriggers();
        
   }
   void CheckTriggers(){
    if(isFirstTriggerActive && isSecondTriggerActive){
        gateAnimator.SetBool(animatorBoolString, true);
    }
   }
}
