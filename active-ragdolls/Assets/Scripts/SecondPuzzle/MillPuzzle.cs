using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillPuzzle : MonoBehaviour
{
   /* The general checker for the mill puzzle, 
   rotating the static lever piece into the trigger zone freezes the rotation of the rigidbody and starts rotating the actual water mill outside */
   
   public Vector3 millRotation;
   [SerializeField]
   bool startMillRotation;
   SecondPuzzleChecker secondPuzzleChecker;
   [Tooltip("The water mill outside that starts rotating when puzzle is complete")]
   public GameObject rotatingMill;
   [Tooltip("The mill lever object that gets frozen when on trigger gets called")]
   public GameObject millLever;
   MeshRenderer meshRenderer;
   private void Start() {
      secondPuzzleChecker = FindObjectOfType<SecondPuzzleChecker>();
   }
   /* The OnTriggerEnter event gets the rigidbody of the millLever gameobject and freezes it,
   starts the rotation of the outside water mill, calls a function in the second puzzle checker script 
   and deactivates itself */
   void OnTriggerEnter(Collider col) {
        if(col.CompareTag("RotatingLever")){
            Debug.Log("MillPuzzle is Complete");
            Rigidbody mL = millLever.GetComponent<Rigidbody>();
            mL.freezeRotation = true;
            startMillRotation = true;
            secondPuzzleChecker.CompleteFirstPuzzle(1,true);
            meshRenderer = gameObject.GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
        }
   }
   /* Controls the rotation of the outside water mill */
   void Update() {
      if(startMillRotation == true){
         rotatingMill.transform.Rotate(millRotation * Time.deltaTime);
      }   
   }
}

