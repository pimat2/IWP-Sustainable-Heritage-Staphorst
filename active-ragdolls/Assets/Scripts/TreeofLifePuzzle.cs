using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeofLifePuzzle : MonoBehaviour
{
    /* Checks for collision with the tree of life objects.
    When this happens, activates the static tree of life pieces in the entrance of the house.
    For puzzles 1 and 2 it enables the bridges that allow players to progress */
    [SerializeField]
    GameObject invisibleWallToDeactivate;
    [Header("The gameobject pieces of the tree of life that are on the entrance of the house")]
    [SerializeField]
    GameObject treeofLifeFirstPart;
    [SerializeField]
    GameObject treeofLifeSecondPart;
    [SerializeField]
    GameObject treeofLifeThirdPart;
    [Header("The bridges that get activated when players complete puzzle 1 or 2 in order to enable progress")]
    [SerializeField]
    GameObject bridgeToActivate;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("TreeofLifeFirstPart")){
            if(treeofLifeFirstPart.activeSelf == false){
                treeofLifeFirstPart.SetActive(true);
                Destroy(other.gameObject);
                if(bridgeToActivate.activeSelf == false){
                    bridgeToActivate.SetActive(true);
                    invisibleWallToDeactivate.SetActive(false);
                }
                if(gameObject.activeSelf == true){
                    gameObject.SetActive(false);
                }
            }
        }
        else if(other.CompareTag("TreeofLifeSecondPart")){
            if(treeofLifeSecondPart.activeSelf == false){
                treeofLifeSecondPart.SetActive(true);
                Destroy(other.gameObject);
            }
            if(gameObject.activeSelf == true){
                    gameObject.SetActive(false);
            }
        }
        else if(other.CompareTag("TreeofLifeThirdPart")){
            if(treeofLifeThirdPart.activeSelf == false){
                treeofLifeThirdPart.SetActive(true);
                Destroy(other.gameObject);
            }
            if(gameObject.activeSelf == true){
                    gameObject.SetActive(false);
            }
        }
    }
}
