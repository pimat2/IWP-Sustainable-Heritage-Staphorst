using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankCollider : MonoBehaviour
{
    [SerializeField]
    GameObject bridgePlank;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("BridgePlank")){
            Rigidbody bridgeRigidbody = bridgePlank.GetComponent<Rigidbody>();
            bridgeRigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationX;
        }
    }
}
