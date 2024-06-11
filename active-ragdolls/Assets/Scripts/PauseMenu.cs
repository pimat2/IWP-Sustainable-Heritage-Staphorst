using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject controlsImage;
    public void LoadMainMenu(){
        SceneManager.LoadScene("Main_Menu");
        Time.timeScale = 1;
    }
    public void RestartGame(){
        SceneManager.LoadScene("GreenQuest_Blockout");
        Time.timeScale = 1;
    }
    public void ShowControls(){
        if(controlsImage.activeSelf == false){
            controlsImage.SetActive(true);
        }
        else{
            controlsImage.SetActive(false);
        }
    }
}
