using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillPuzzle : MonoBehaviour
{
   public Vector3 millRotation;
   [SerializeField]
   bool startMillRotation;
   [SerializeField]
   SecondPuzzleChecker secondPuzzleChecker;
   public GameObject rotatingMill;
   public GameObject millLever;
   void OnTriggerEnter(Collider col) {
        if(col.CompareTag("RotatingLever")){
            Debug.Log("MillPuzzle is Complete");
            Rigidbody mL = millLever.GetComponent<Rigidbody>();
            mL.freezeRotation = true;
            startMillRotation = true;
            secondPuzzleChecker.CompleteFirstPuzzle(1,true);
            gameObject.SetActive(false);
        }
   }
   void Update() {
      if(startMillRotation == true){
         rotatingMill.transform.Rotate(millRotation * Time.deltaTime);
      }   
   }
}

