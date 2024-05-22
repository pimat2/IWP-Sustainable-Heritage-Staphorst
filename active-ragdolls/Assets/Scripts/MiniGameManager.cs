using System;
using System.Collections;
using System.Collections.Generic;
using ActiveRagdoll;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering;
using TMPro;

public class MiniGameManager : MonoBehaviour
{
    [Header("Active Ragdoll Prefab to Spawn after Beetroot Puzzle")]
    [SerializeField]
    GameObject activeRagdollPrefab;
    
    [Header("Initial player gameobjects")]
    [SerializeField]
    GameObject player1;
    [SerializeField]
    GameObject player2;
    [Header("Static Ragdolls for puzzle camera view")]
    [SerializeField]
    GameObject staticplayer1;
    [SerializeField]
    GameObject staticplayer2;
    [Header("Side Camera")]
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
    [Header("Beetroot Rigidbodies")]
    [SerializeField]
    Rigidbody beetrootRigidbody;
    [SerializeField]
    Rigidbody leavesRigidbody;
     [Header("UI Control Overlays")]
    public TextMeshProUGUI controlsText1;
    public TextMeshProUGUI controlsText2; 
    public TextMeshProUGUI beetrootText1; 
    public TextMeshProUGUI beetrootText2;
    [Header("SET TRUE IF PLAYERS GET INVERTED")]
    public bool controlsInverted;
    

    private void Start() {
        spawnLocation1 = spawnPoint1.transform.position;
        spawnLocation2 = spawnPoint2.transform.position;
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
        if(miniGameActive == false && Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
            
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
    /*This section controls the start and end of the beetroot minigame.
    At the start it destroys the ragdoll players in order to enable the side camera to become the main camera of the game
    as well as enabling the correct UI control overlays. */ 
    public void StartMinigame(){
        Debug.Log("MINIGAME SHOULD START");
        StartMinigamePlayers();
        miniGameActive = true;
        sideCamera.enabled = true;
        minigameSlider.SetActive(true);
        StartMinigameUI();
    }
    private void StartMinigameUI(){
        controlsText1.enabled = false;
        controlsText2.enabled = false;
        beetrootText1.enabled = true;
        beetrootText2.enabled = true;
    }
    private void StartMinigamePlayers(){
        player1.SetActive(false);
        player2.SetActive(false);
        staticplayer1.SetActive(true);
        staticplayer2.SetActive(true);
    }

    
    public void FinishMiniGame(){
        Destroy(beetrootCollider);
        miniGameActive = false;
        sideCamera.enabled = false;
        minigameSlider.SetActive(false);
        FinishMinigamePlayers();
        if(beetrootRigidbody.isKinematic == true){
            beetrootRigidbody.isKinematic = false;
        }
        if(leavesRigidbody.isKinematic == true){
            leavesRigidbody.isKinematic = false;
        }
        FinishMinigameUI();
    }
    
    private void FinishMinigamePlayers(){
        Destroy(staticplayer1);
        Destroy(staticplayer2);
        Destroy(player1);
        Destroy(player2);
        GameObject newPlayer1 = Instantiate(activeRagdollPrefab, spawnLocation1, Quaternion.identity);
        GameObject newPlayer2 = Instantiate(activeRagdollPrefab, spawnLocation2, Quaternion.identity);
        CameraModule cameraModule = newPlayer1.GetComponent<CameraModule>();
        CameraModule cameraModule1 = newPlayer2.GetComponent<CameraModule>();
        Material player2Material = newPlayer2.GetComponentInChildren<Renderer>().material;
        Material player1Material = newPlayer1.GetComponentInChildren<Renderer>().material;
        if(controlsInverted == true){
            player2Material.color = Color.red;
            player1Material.color = Color.HSVToRGB(196, 74, 66);
            cameraModule1.viewPortX = 0f;
            cameraModule.viewPortX = 0.5f;
        }
        else{
            player2Material.color = Color.blue;
            player1Material.color = Color.red;
            cameraModule1.viewPortX = 0.5f;
            cameraModule.viewPortX = 0f;
        }
    }
    private void FinishMinigameUI(){
        controlsText1.enabled = true;
        controlsText2.enabled = true;
        beetrootText1.enabled = false;
        beetrootText2.enabled = false;
    }
}
