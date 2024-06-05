using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Timeline;

public class SecondPuzzleChecker : MonoBehaviour
{
    /* A puzzle checker for the second puzzle, 
    keeps track of multiple objects */
    [Tooltip("The invisible wall that gets deactivated after all parts from second puzzle have been completed")]
    [SerializeField]
    GameObject secondInvisibleWall;
    [SerializeField]
    Color dirtyWaterColor;
    [SerializeField]
    Color cleanWaterColor;
    [SerializeField]
    GameObject waterPlane;
    private Renderer waterRenderer;
    [Tooltip("Gets activated after all parts from second puzzle have been completed")]
    [SerializeField]
    GameObject secondBridge;
    [Tooltip("Gets activated after all parts from second puzzle have been completed")]
    [SerializeField]
    GameObject secondTreeofLife;
    bool isFirstPuzzleComplete;
    bool isSecondPuzzleComplete;
    [Tooltip("An array of all the water plank collider scripts")]
    public WaterSystemCollider[] waterColliders;
    /* Gets the renderer of the waterPlane and sets it to the dirtywater color */
    private void Start() {
        waterRenderer = waterPlane.GetComponent<Renderer>();
        waterRenderer.material.SetColor("_BaseColor", dirtyWaterColor);
    }

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
    /* Activates and deactivates neccessarry objects when the mill puzzle and the water planks puzzle have been completed
    Also sets the color of the water to the cleanWaterColor */
    void CheckPuzzles(){
        if(isFirstPuzzleComplete && isSecondPuzzleComplete){
            Debug.Log("Puzzles are complete");
            if(secondBridge.activeSelf == false){
                secondBridge.SetActive(true);
                secondInvisibleWall.SetActive(false);
            }
            else{
                return;
            }
            if(secondTreeofLife.activeSelf == false){
                secondTreeofLife.SetActive(true);
                waterRenderer.material.SetColor("_BaseColor", cleanWaterColor);
            }
            else{
                return;
            }
        }
    }
}
