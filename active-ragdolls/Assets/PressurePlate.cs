using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PressurePlate : MonoBehaviour
{
     public float activationHeight = -0.1f; // Height difference when plate is pressed
    public float deactivationHeight = 0.0f; // Original height of the plate
    public float pressSpeed = 0.01f; // Speed at which the plate moves
    public LayerMask triggerLayers; // Layers of objects that will activate the plate

    private bool isPressed = false;
    private Vector3 originalPosition;
    private Rigidbody rb;
    private int objectsOnPlate = 0; // To keep track of multiple objects

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // Move the plate up or down based on whether it is pressed
        Vector3 targetPosition = originalPosition;
        if (isPressed)
        {
            targetPosition += Vector3.up * activationHeight;
        }
        else
        {
            targetPosition += Vector3.up * deactivationHeight;
        }

        // Lerp to create smooth movement
        rb.MovePosition(Vector3.Lerp(transform.localPosition, targetPosition, pressSpeed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object is in the specified layer
        if ((triggerLayers.value & (1 << other.gameObject.layer)) > 0)
        {
            objectsOnPlate++;
            isPressed = true;
            Debug.Log("SomethingShouldHappen");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the object is in the specified layer
        if ((triggerLayers.value & (1 << other.gameObject.layer)) > 0)
        {
            objectsOnPlate--;
            if (objectsOnPlate <= 0)
            {
                isPressed = false;
                objectsOnPlate = 0; // Reset to avoid negative count
                Debug.Log("Something should STOP happening");
            }
        }
    }
}
