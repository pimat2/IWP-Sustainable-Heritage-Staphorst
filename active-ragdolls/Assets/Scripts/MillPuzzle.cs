using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillPuzzle : MonoBehaviour
{
   public Vector3 millRotation;
   [SerializeField]
   bool startMillRotation;
   public GameObject rotatingMill;
   public GameObject millLever;
   void OnTriggerEnter(Collider col) {
        if(col.CompareTag("RotatingLever")){
         Debug.Log("WAWAWAW");
         Rigidbody mL = millLever.GetComponent<Rigidbody>();
         mL.freezeRotation = true;
         startMillRotation = true;
        }
   }
   void Update() {
      if(startMillRotation == true){
         rotatingMill.transform.Rotate(millRotation * Time.deltaTime);
      }   
   }
}

