using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateAnimation : MonoBehaviour
{
    public  static int activatedPressurePlatesCount = 0;
    public int totalPressurePlatesCount = 3;
    [SerializeField]
    GameObject gameObjectToActivate;
    void Start() {
        activatedPressurePlatesCount = Mathf.Clamp(activatedPressurePlatesCount, 0 , totalPressurePlatesCount);    
    }
    public void PressurePlateFullyDown(){
        activatedPressurePlatesCount ++;
        Debug.Log(activatedPressurePlatesCount);
        if(activatedPressurePlatesCount >= totalPressurePlatesCount){
            AllPressurePlatesActivated();
        }
        
    }
    public void PressurePlateFullyUp(){
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
        if(gameObjectToActivate.activeSelf == false){
            gameObjectToActivate.SetActive(true);
        }
        else{
            return;
        }
        
    }
}
