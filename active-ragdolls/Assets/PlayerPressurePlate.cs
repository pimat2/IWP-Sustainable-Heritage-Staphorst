using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPressurePlate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Debug.Log("WAAWAWAWAW");
    }
    private void OnTriggerExit(Collider other) {
            Debug.Log("NANANANNA");
    }
}
