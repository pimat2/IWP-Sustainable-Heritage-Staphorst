using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class PressurePlateAnimation : MonoBehaviour
{
    /* Controls the logic behind the animation of the pressure plate going up and down, as well as acts as a puzzle completion checker.
    When all pressure plates have been activated enables the tree of life moving piece. */
    public  static int activatedPressurePlatesCount = 0;
    public int totalPressurePlatesCount = 3;
    bool pressurePlateDown;
    [Tooltip("The tree of life part gameobject that gets activated")]
    [SerializeField]
    GameObject gameObjectToActivate;
    [Tooltip("The trigger inside the tree of life part pedestal that checks for player proximity")]
    [SerializeField]
    GameObject treeOfLifeTrigger;
    void Start() {
        activatedPressurePlatesCount = Mathf.Clamp(activatedPressurePlatesCount, 0 , totalPressurePlatesCount);    
    }
    /* This function gets called inside the animation of each individual pressure plate */
    public void PressurePlateFullyDown(){
        activatedPressurePlatesCount ++;
        Debug.Log(activatedPressurePlatesCount);
        pressurePlateDown = true;
        if(activatedPressurePlatesCount >= totalPressurePlatesCount){
            AllPressurePlatesActivated();
        }
        
    }
    /* This function gets called inside the animation of each individual pressure plate */
    public void PressurePlateFullyUp(){
        if(activatedPressurePlatesCount <= 0){
            return;
        }
        else if(pressurePlateDown == false){
            return;
        }
        else{
            activatedPressurePlatesCount --;
        }
        Debug.Log(activatedPressurePlatesCount);
    }
    public void AllPressurePlatesActivated(){
        Debug.Log("ALL PRESSURE PLATES HAVE BEEN ACTIVATED");
        if(gameObjectToActivate.activeSelf == false){
            treeOfLifeTrigger.SetActive(true);
            gameObjectToActivate.SetActive(true);
        }
        else{
            return;
        }
        
    }
}
