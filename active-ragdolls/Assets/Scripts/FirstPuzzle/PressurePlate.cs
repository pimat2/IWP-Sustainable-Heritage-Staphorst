using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    /* Script that handles the up and down movement of the pressure plates in the first puzzle */
    [Tooltip("Assign a tag to the object that you want to activate the pressure plate and type it in the inspector field")]
    public string activatorTag;
    [SerializeField]
    private Animator animator;
     private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(activatorTag)){
            animator.SetBool("shouldMoveDown", true);
        }
     }
     private void OnTriggerExit(Collider other) {
        if(other.CompareTag(activatorTag)){
            animator.SetBool("shouldMoveDown", false);
        }
     }
    
}
