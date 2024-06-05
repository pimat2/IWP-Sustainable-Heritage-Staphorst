
using UnityEngine;

public class BeetrootAnimator : MonoBehaviour
{
    /* This script controls the ending of the minigame when the beetroot has been pulled
    The PullBeetroot function gets called in the animation of the beetroot */
    MiniGameManager miniGameManager;
    private void Start() {
        miniGameManager = FindObjectOfType<MiniGameManager>();
    }
    public void PullBeetroot(){
        if(miniGameManager != null){
            miniGameManager.FinishMiniGame();
        }
    }
}
