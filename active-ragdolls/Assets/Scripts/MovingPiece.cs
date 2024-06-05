using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPiece : MonoBehaviour
{
    /* Simple mover and rotator of objects using the sine wave math function */
    [Range(0.0f, 10.0f)]
    public float amplifier; 
    [Range(0.0f, 10.0f)]
    public float frequency;
    [SerializeField]
    Vector3 objectRotation;
    Vector3 initialPosition;
    [SerializeField]
    bool moveSideways;

    private void Start() {
        initialPosition = transform.position;
    }
    void Update()
    {
        MoveAndRotate();
    }
    private void MoveAndRotate()
    {
        if(moveSideways == true){
            transform.position = new Vector3(Mathf.Sin(Time.time * frequency) * amplifier + initialPosition.x,initialPosition.y,initialPosition.z);
        }
        else{
             transform.position = new Vector3(initialPosition.x,Mathf.Sin(Time.time * frequency) * amplifier + initialPosition.y,initialPosition.z);
        }
        gameObject.transform.Rotate(objectRotation * Time.deltaTime);
    }
}
