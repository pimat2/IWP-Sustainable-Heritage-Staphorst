using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetrootAnimator : MonoBehaviour
{
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
