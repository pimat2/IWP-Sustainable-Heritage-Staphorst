using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompostTrigger : MonoBehaviour
{
   [SerializeField]
    GameObject treeofLifepart;
   [SerializeField]
   GameObject compost;
   CompostChecker compostChecker;

   private void Start() {
        compostChecker = FindAnyObjectByType<CompostChecker>();
   }
   bool isTriggerActive = true;
   private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Beetroot") && isTriggerActive == true){
            Destroy(other.gameObject);
            if(compost.activeSelf == false){
                compost.SetActive(true);
            }
            isTriggerActive = false;
            if(compostChecker != null){
                compostChecker.isBeetrootComposted = true;
                compostChecker.CheckCompost();
            }
        }
        else if(other.CompareTag("BeetrootLeaves") && isTriggerActive == true){
            Destroy(other.gameObject);
            if(compost.activeSelf == false){
                compost.SetActive(true);
            }
            isTriggerActive = false;
            if(compostChecker != null){
                compostChecker.isLeavesComposted = true;
                compostChecker.CheckCompost();
            }
        }
        
   }
   
}
