using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSystem : MonoBehaviour
{
    public GameObject controlText;
    public GameObject[] imageSections; 
    private int currentIndex = 0; 
    private bool isPlayerinProximity;

    void Start()
    {
        if (imageSections.Length != 4)
        {
            Debug.LogError("You must assign exactly 4 GameObjects.");
            return;
        }
        if(controlText.activeSelf == true){
            controlText.SetActive(false);
        }
        foreach (GameObject obj in imageSections)
        {
            obj.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PlayerFoot")){
            controlText.SetActive(true);
            isPlayerinProximity = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("PlayerFoot")){
            controlText.SetActive(false);
            isPlayerinProximity = false;
        }
    }

    void Update()
    {
        DisplayHints();
        
    }

    private void DisplayHints()
    {
        if (Input.GetKeyDown(KeyCode.H) && isPlayerinProximity == true)
        {
            if (currentIndex < imageSections.Length)
            {
                // Activate the current section
                imageSections[currentIndex].SetActive(true);
                currentIndex++;
            }
            else
            {
                Debug.Log("All sections are already activated.");
            }
        }
    }
}
