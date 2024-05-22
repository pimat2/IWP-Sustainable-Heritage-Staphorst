using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
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
