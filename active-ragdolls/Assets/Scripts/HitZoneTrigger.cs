using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZoneTrigger : MonoBehaviour
{
    [SerializeField]
    MiniGameManager miniGameManager;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("MovingLine")){
            miniGameManager.indicatorIn = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("MovingLine")){
            miniGameManager.indicatorIn = false;
        }
    }
}
