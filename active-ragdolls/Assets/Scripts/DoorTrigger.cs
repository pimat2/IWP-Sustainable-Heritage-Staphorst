using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    Rigidbody doorRigidbody;
   private void OnTriggerEnter(Collider other) {
    if(other.CompareTag("PullableDoor")){
        Debug.Log("DOOR NEEDS TO BE FROZEN");
        doorRigidbody.isKinematic = true;
    }
   }
}
