using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetrootMinigameTrigger : MonoBehaviour
{
    MiniGameManager miniGameManager;

    public GameObject player1, player2;
    [SerializeField]
    bool player1InPosition, player2InPosition;

    private void Start() {
        miniGameManager = FindAnyObjectByType<MiniGameManager>();
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player1Foot")){
            player1InPosition = true;
        }
        if(other.CompareTag("Player2Foot")){
            player2InPosition = true;
        }
        StartMinigame();
    }
    void OnTriggerExit(Collider other) {
        if(other.gameObject == player1){
            player1InPosition = false;
        }
        if(other.gameObject == player2){
            player2InPosition = false;
        }
    }

    void StartMinigame()
    {
        if(player1InPosition && player2InPosition){
            miniGameManager.StartMinigame();
        }
    }
}
