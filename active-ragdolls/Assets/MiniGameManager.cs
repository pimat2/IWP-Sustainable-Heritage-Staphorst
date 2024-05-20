using System;
using System.Collections;
using System.Collections.Generic;
using ActiveRagdoll;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField]
    GameObject activeRagdollPrefab;
    [SerializeField]
    GameObject player1, player2;
    [SerializeField]
    GameObject staticplayer1, staticplayer2;
    public Camera sideCamera;
    public GameObject minigameSlider;
    [SerializeField]
    bool player1Turn = true;
    public bool miniGameActive;
    public bool indicatorIn;
    [SerializeField]
    Animator beetrootAnimator;
    public int animatorState = 0;
    public GameObject beetrootCollider;
    [SerializeField]
    GameObject spawnPoint1, spawnPoint2;
    Vector3 spawnLocation1, spawnLocation2;

    private void Start() {
        spawnLocation1 = spawnPoint1.transform.position;
        spawnLocation2 = spawnPoint2.transform.position;
    }
    public void StartMinigame(){
        Debug.Log("MINIGAME SHOULD START");
        player1.SetActive(false);
        player2.SetActive(false);
        staticplayer1.SetActive(true);
        staticplayer2.SetActive(true);
        miniGameActive = true;
        sideCamera.enabled = true;
        minigameSlider.SetActive(true);
    }
    private void Update() {
        if(miniGameActive){
            if(player1Turn && Input.GetKeyDown(KeyCode.Q)){
                CheckInputTiming();
            }
            else if(!player1Turn && Input.GetKeyDown(KeyCode.RightBracket)){
                CheckInputTiming();
            }
            else if(Input.GetKeyDown(KeyCode.Escape)){
                FinishMiniGame();
            }
        }
    }

    private void CheckInputTiming()
    {
        if(indicatorIn && player1Turn){
            Debug.Log("PLAYER 1 HAS PULLED THE BEETROOT");
            animatorState++;
            indicatorIn = false;
            player1Turn = false;
            beetrootAnimator.SetInteger("beetrootState",animatorState);
        }
        else if(indicatorIn && !player1Turn){
            Debug.Log("PLAYER 2 HAS PULLED THE BEETROOT");
            animatorState++;
            indicatorIn = false;
            player1Turn = true;
            beetrootAnimator.SetInteger("beetrootState",animatorState);
        }
    }
    public void FinishMiniGame(){
        Destroy(beetrootCollider);
        miniGameActive = false;
        sideCamera.enabled = false;
        minigameSlider.SetActive(false);
        Destroy(staticplayer1);
        Destroy(staticplayer2);
        // staticplayer1.SetActive(false);
        // staticplayer2.SetActive(false);
        // player2.SetActive(true); //is bugged look for a fix
        // player1.SetActive(true);
        GameObject newPlayer1 = Instantiate(activeRagdollPrefab, spawnLocation1, Quaternion.identity);
        GameObject newPlayer2 = Instantiate(activeRagdollPrefab, spawnLocation2, Quaternion.identity);
        CameraModule cameraModule = newPlayer1.GetComponent<CameraModule>();
        cameraModule.viewPortX = 0;
    }
}
