using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeofLifePuzzle : MonoBehaviour
{
    [SerializeField]
    GameObject treeofLifeFirstPart;
    [SerializeField]
    GameObject treeofLifeSecondPart;
    [SerializeField]
    GameObject treeofLifeThirdPart;
    [SerializeField]
    GameObject bridgeToActivate;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("TreeofLifeFirstPart")){
            if(treeofLifeFirstPart.activeSelf == false){
                treeofLifeFirstPart.SetActive(true);
                Destroy(other.gameObject);
                if(bridgeToActivate.activeSelf == false){
                    bridgeToActivate.SetActive(true);
                }
            }
        }
        else if(other.CompareTag("TreeofLifeSecondPart")){
            if(treeofLifeSecondPart.activeSelf == false){
                treeofLifeSecondPart.SetActive(true);
                Destroy(other.gameObject);
            }
        }
        else if(other.CompareTag("TreeofLifeThirdPart")){
            if(treeofLifeThirdPart.activeSelf == false){
                treeofLifeThirdPart.SetActive(true);
                Destroy(other.gameObject);
            }
        }
    }
}
