using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSystemCollider : MonoBehaviour
{
   public GameObject waterGate;
   private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("WaterSystemPlank"))
        {
            if(waterGate.activeSelf == false){
                waterGate.SetActive(true);
                Destroy(other.gameObject);
            }
            else{
                return;
            }
        }
   }
}
