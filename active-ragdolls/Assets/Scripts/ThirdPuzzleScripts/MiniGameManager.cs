
using ActiveRagdoll;
using UnityEngine;
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
    [Header("The slider for the minigame")]
    public GameObject minigameSlider;
    [SerializeField]
    bool player1Turn = true;
    [SerializeField]
    bool miniGameActive;
    public bool indicatorIn;
    [SerializeField]
    Animator beetrootAnimator;
    [SerializeField]
    int animatorState = 0;
    [Header("The collider of the beetroot that checks if both players are in")]
    public GameObject beetrootCollider;
    [Header("Spawn Points for the players after the minigame finishes")]
    [SerializeField]
    GameObject spawnPoint1, spawnPoint2;
    [Header("Locations of the SpawnPoints")]
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
    public Canvas menuCanvas;
    [Header("SET TRUE IF PLAYERS GET INVERTED")]
    public bool controlsInverted;
    

    private void Start() {
        spawnLocation1 = spawnPoint1.transform.position;
        spawnLocation2 = spawnPoint2.transform.position;
    }
    /* Checks for player inputs if minigameActive is true
    Quits the minigame when escape is pressed, otherwise quits the game */
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
            PauseGame();
        }
    }
    /* Checks for the input timings, if the indicator is inside the trigger
    Switches the turns of the players, player 1 is the first to start by default
    Changes the state of the beetroot animation by 1*/
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
    /* This section controls the end of the MiniGame.
    1. Destroys the beetrootCollider that checks for starting the minigame so the minigame doesn't start again
    2. Disables the objects related to the minigame(sidecamera, minigame slider)
    3. Sets the rigidbodies of the beetroot fruit and the leaves to non-kinematic so players can grab them and bring them to the compost */
    
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
    /* When the minigame finishes, the static ragdolls used for visual representations of the players inside the minigame are destroyed
    as well as the previous players(because of a bug with the ragdolls)
    Instantiates new active ragdoll player prefabs and adjusts the settings of their components to avoid player confusion(sometimes a bug can happen that will switch the camera views of the players)*/
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
    /* Disables the text objects for the controls of the minigame and reenables the old control overlay */
    private void FinishMinigameUI(){
        controlsText1.enabled = true;
        controlsText2.enabled = true;
        beetrootText1.enabled = false;
        beetrootText2.enabled = false;
    }

    private void PauseGame(){
        if(menuCanvas.gameObject.activeSelf == false){
            menuCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ResumeGame(){
        if(menuCanvas.gameObject.activeSelf == true){
            menuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
