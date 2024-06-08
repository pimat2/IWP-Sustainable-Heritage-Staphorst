using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button startGame;
    [SerializeField] Button optionsButton;
    [SerializeField] Button mainMenuBackButton;
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas optionsCanvas;


    
    void Start()
    {
        startGame.onClick.AddListener(StartGameOnClick);
        optionsButton.onClick.AddListener(OnOptionsButtonClick);
        mainMenuBackButton.onClick.AddListener(OnBackButtonClick);
    }

    private void StartGameOnClick()
    {
        StartCoroutine(WaitSomeSeconds());
    }

    IEnumerator WaitSomeSeconds()
    {
        yield return new WaitForSeconds(0.5f);
        ManagerScenes.Instance.LoadGame();
    }

    private void OnOptionsButtonClick()
    {
        optionsCanvas.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(false);
    }

    private void OnBackButtonClick()
    {
        optionsCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    }
}
