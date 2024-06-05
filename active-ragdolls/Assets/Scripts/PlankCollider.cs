using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankCollider : MonoBehaviour
{
    [SerializeField]
    GameObject bridgePlank;
    [SerializeField]
    GameObject inactivePlank;
    public bool isSecondPlankCollider;
    /* Unfreezes the rotation of the plank on the X axis, allowing it to fall in place
    the second plank collider makes the physical plank get destroyed and activates a static plank to be used like a bridge by the players */
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("BridgePlank")){
            Rigidbody bridgeRigidbody = bridgePlank.GetComponent<Rigidbody>();
            bridgeRigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationX;
            if(isSecondPlankCollider == true){
                Destroy(other.gameObject);
                if(inactivePlank.activeSelf == false){
                    inactivePlank.SetActive(true);
                }
            }
        }
    }
}
