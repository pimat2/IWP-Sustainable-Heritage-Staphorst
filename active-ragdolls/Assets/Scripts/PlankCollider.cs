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
