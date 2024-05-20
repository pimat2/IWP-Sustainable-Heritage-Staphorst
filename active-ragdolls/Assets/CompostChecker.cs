using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompostChecker : MonoBehaviour
{
    [SerializeField]
    GameObject treeofLifePart;
    [SerializeField]
    GameObject treeofLifeTrigger;
    public bool isBeetrootComposted;
    public bool isLeavesComposted;

    public void CheckCompost(){
        if(isBeetrootComposted && isLeavesComposted){
            if(treeofLifePart.activeSelf == false){
                treeofLifeTrigger.SetActive(true);
                treeofLifePart.SetActive(true);
            }
            Debug.Log("BEETROOT PUZZLE COMPLETE");
        
        }
    }
}
