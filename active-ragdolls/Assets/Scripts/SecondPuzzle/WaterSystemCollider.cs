using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class WaterSystemCollider : MonoBehaviour
{
    SecondPuzzleChecker secondPuzzleChecker;
    public bool hasBeenComplete;
    [Tooltip("The static Water Gate objects in the level")]
    public GameObject waterGate;
    private void Start() {
    secondPuzzleChecker = FindObjectOfType<SecondPuzzleChecker>();
    }
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
