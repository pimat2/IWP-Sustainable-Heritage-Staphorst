using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSystem : MonoBehaviour
{
    public GameObject[] imageSections; 
    private int currentIndex = 0; 

    void Start()
    {
        if (imageSections.Length != 4)
        {
            Debug.LogError("You must assign exactly 4 GameObjects.");
            return;
        }

        foreach (GameObject obj in imageSections)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
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
