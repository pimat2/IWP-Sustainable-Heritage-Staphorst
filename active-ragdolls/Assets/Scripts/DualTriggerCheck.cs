using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DualTriggerCheck : MonoBehaviour
{
    /* For Purple pressure plates. Checks if both players are standing on a pressure plate.
    Sets a bool inside the gateAnimator in order to open it */
    [Tooltip("This string should be named exactly like the name of the bool that needs to be changed inside the animator of the fence")]
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
