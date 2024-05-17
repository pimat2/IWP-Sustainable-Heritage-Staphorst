using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPressurePlate : MonoBehaviour
{
    [SerializeField]
    DualTriggerCheck dualTriggerCheck;
    
    [SerializeField]
    int triggerNumber;
    private void OnTriggerEnter(Collider other) {
       if(other.CompareTag("PlayerFoot")){
            dualTriggerCheck.ActivateTrigger(triggerNumber, true);
            Debug.Log("WAWWAAWWAAWAW");
       }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("PlayerFoot")){
            dualTriggerCheck.ActivateTrigger(triggerNumber, false);
            Debug.Log("NANNANANA");
        }
    }
}
