
using UnityEngine;

public class CompostTrigger : MonoBehaviour
{
   [Tooltip("The compost gameobject in scene that gets activated when player puts the beetroot or the leaves")]
   [SerializeField]
   GameObject compost;
   CompostChecker compostChecker;
   bool isTriggerActive = true;

   private void Start() {
        compostChecker = FindAnyObjectByType<CompostChecker>();
   }
   /* When player puts the beetroot fruit or the leaves in the compost trigger
   1. Destroys the beetroot or the leaves gameobject
   2. Activates the compost gameobject
   3. Disables the trigger for this compost
   4. Sets the appropriate bool and calls the functiuon inside CompostChecker to check if the puzzle has been completed */
   private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Beetroot") && isTriggerActive == true){
            Destroy(other.gameObject);
            if(compost.activeSelf == false){
                compost.SetActive(true);
            }
            isTriggerActive = false;
            if(compostChecker != null){
                compostChecker.isBeetrootComposted = true;
                compostChecker.CheckCompost();
            }
        }
        else if(other.CompareTag("BeetrootLeaves") && isTriggerActive == true){
            Destroy(other.gameObject);
            if(compost.activeSelf == false){
                compost.SetActive(true);
            }
            isTriggerActive = false;
            if(compostChecker != null){
                compostChecker.isLeavesComposted = true;
                compostChecker.CheckCompost();
            }
        }
        
   }
   
}
