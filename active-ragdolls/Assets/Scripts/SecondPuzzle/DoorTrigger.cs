using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    Rigidbody doorRigidbody;
    
    private void OnTriggerEnter(Collider other) {
    if(other.CompareTag("PullableDoor")){
        Debug.Log("DOOR NEEDS TO BE FROZEN");
        doorRigidbody = other.GetComponentInParent<Rigidbody>();
        if(doorRigidbody != null){
            doorRigidbody.isKinematic = true;
        }
        else{
            return;
        }
    }
   }
}
