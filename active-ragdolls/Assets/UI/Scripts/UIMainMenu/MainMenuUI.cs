using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button startGame;


    
    void Start()
    {
        startGame.onClick.AddListener(StartGameOnClick);
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
}
