using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPressurePlate : MonoBehaviour
{
    [SerializeField]
    DualTriggerCheck dualTriggerCheck;
    public string triggerTag;
    
    [SerializeField]
    int triggerNumber;
    private void OnTriggerEnter(Collider other) {
       if(other.CompareTag(triggerTag)){
            dualTriggerCheck.ActivateTrigger(triggerNumber, true);
            Debug.Log("WAWWAAWWAAWAW");
       }
       else{
            return;
       }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag(triggerTag)){
            dualTriggerCheck.ActivateTrigger(triggerNumber, false);
            Debug.Log("NANNANANA");
        }
        else{
            return;
        }
    }
}
