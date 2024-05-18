using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProximityTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject movingObject;
    private MovingPiece scriptComponent;
    private Rigidbody rigidbodyComponent;

    private void Start() {
        scriptComponent = movingObject.GetComponent<MovingPiece>();
        rigidbodyComponent = movingObject.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PlayerFoot")){
            if(scriptComponent != null){
                scriptComponent.enabled = !scriptComponent.enabled;
            }
            else{
                return;
            }
            if(rigidbodyComponent != null){
                rigidbodyComponent.isKinematic = false;
            }
        }
    }
}
