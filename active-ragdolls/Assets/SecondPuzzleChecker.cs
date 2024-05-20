using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPuzzleChecker : MonoBehaviour
{
    [SerializeField]
    GameObject secondBridge;
    [SerializeField]
    GameObject secondTreeofLife;
    bool isFirstPuzzleComplete;
    bool isSecondPuzzleComplete;
    public WaterSystemCollider[] waterColliders;

    public void CompleteFirstPuzzle(int puzzleNumber, bool isComplete){
        if(puzzleNumber == 1){
             isFirstPuzzleComplete = isComplete;
        }
        Debug.Log("FIRST MILL PUZZLE HAS BEEN COMPLETED");
        CheckPuzzles();
    } 
    public void CheckWaterTriggers(){
        foreach(WaterSystemCollider waterCollider in waterColliders){
            if(waterCollider.hasBeenComplete == false){
                return;
            }
        }
        CompleteSecondPuzzle();
    }

    private void CompleteSecondPuzzle()
    {
        isSecondPuzzleComplete = true;
        Debug.Log("SECOND MILL PUZZLE HAS BEEN COMPLETED");
        CheckPuzzles();
    }

    void CheckPuzzles(){
        if(isFirstPuzzleComplete && isSecondPuzzleComplete){
            Debug.Log("Puzzles are complete");
            if(secondBridge.activeSelf == false){
                secondBridge.SetActive(true);
            }
            else{
                return;
            }
            if(secondTreeofLife.activeSelf == false){
                secondTreeofLife.SetActive(true);
            }
            else{
                return;
            }
        }
    }
}
