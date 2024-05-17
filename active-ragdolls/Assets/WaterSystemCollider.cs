using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSystemCollider : MonoBehaviour
{
    [SerializeField]
    SecondPuzzleChecker secondPuzzleChecker;
    public bool hasBeenComplete;
   public GameObject waterGate;
   private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("WaterSystemPlank"))
        {
            if(waterGate.activeSelf == false){
                waterGate.SetActive(true);
                Destroy(other.gameObject);
                hasBeenComplete = true;
                secondPuzzleChecker.CheckWaterTriggers();
            }
            else{
                return;
            }
        }
   }
}
