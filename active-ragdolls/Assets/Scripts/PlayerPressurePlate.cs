using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPressurePlate : MonoBehaviour
{
    [SerializeField]
    DualTriggerCheck dualTriggerCheck;
    [Tooltip("Assign a string matching the name of the tag that you want to be able to activate the pressure plate")]
    public string triggerTag;
    
    [SerializeField]
    [Tooltip("Assign an individual number to each pressure plate")]
    int triggerNumber;
    private void OnTriggerEnter(Collider other) {
       if(other.CompareTag(triggerTag)){
            dualTriggerCheck.ActivateTrigger(triggerNumber, true);
            Debug.Log("Player has entered the pressure plate");
       }
       else{
            return;
       }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag(triggerTag)){
            dualTriggerCheck.ActivateTrigger(triggerNumber, false);
            Debug.Log("Player has exited the pressure plate");
        }
        else{
            return;
        }
    }
}
