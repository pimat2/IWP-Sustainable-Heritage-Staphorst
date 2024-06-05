
using UnityEngine;

public class CompostChecker : MonoBehaviour
{
    /* Trigger check for the compost checker
    When the fruit of the beetroot and the leaves have been "put" in the compost 
    activates the tree of life */
    [Tooltip("The tree of life part that gets activated")]
    [SerializeField]
    GameObject treeofLifePart;
    [Tooltip("The tree of life trigger on the pedestal that checks for player proximity")]
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
