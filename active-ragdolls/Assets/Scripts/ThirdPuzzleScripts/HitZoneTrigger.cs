
using UnityEngine;

public class HitZoneTrigger : MonoBehaviour
{
    /* Paret of the minigame puzzle. Checks if the Moving Line is in the trigger zone for players to press the neccessarry button */
    [SerializeField]
    MiniGameManager miniGameManager;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("MovingLine")){
            miniGameManager.indicatorIn = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("MovingLine")){
            miniGameManager.indicatorIn = false;
        }
    }
}
