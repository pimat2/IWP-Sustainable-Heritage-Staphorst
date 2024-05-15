using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateAnimation : MonoBehaviour
{
    public  static int activatedPressurePlatesCount = 0;
    public int totalPressurePlatesCount = 3;
    void Start() {
        activatedPressurePlatesCount = Mathf.Clamp(activatedPressurePlatesCount, 0 , totalPressurePlatesCount);    
    }
    public void PressurePlateFullyDown(){
        Debug.Log("Pressure plate has gone fully DOWN");
        activatedPressurePlatesCount ++;
        Debug.Log(activatedPressurePlatesCount);
        if(activatedPressurePlatesCount >= totalPressurePlatesCount){
            AllPressurePlatesActivated();
        }
        
    }
    public void PressurePlateFullyUp(){
        Debug.Log("Pressure plate has gone fully UP");
        if(activatedPressurePlatesCount <= 0){
            return;
        }
        else{
            activatedPressurePlatesCount --;
        }
        Debug.Log(activatedPressurePlatesCount);
    }
    public void AllPressurePlatesActivated(){
        Debug.Log("ALL PRESSURE PLATES HAVE BEEN ACTIVATED");
    }
}
